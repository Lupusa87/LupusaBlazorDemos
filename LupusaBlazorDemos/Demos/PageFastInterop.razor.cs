using BlazorCounterHelper;
using BlazorJsFastDataExchanger;
using BlazorWindowHelper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Demos
{
    public partial class PageFastInterop
    { 
        [Inject]
        IJSRuntime jsRuntime { get; set; }

        [Inject]
        NavigationManager navigationManager { get; set; }


        public bool IsDisabled = false;

        protected string JsMessage = "fastinterop";

        protected List<string> log = new List<string>();



        //protected override void OnInitialized()
        //{

        //    base.OnInitialized();
        //}


        public async void JsSendMessage()
        {

            if (!string.IsNullOrEmpty(JsMessage))
            {

                await CounterHelper.CmdAddCounter(new TSCounter() { Source = navigationManager.Uri, Action = "ClickButtonRegular" });


                ExpandData();

                log.Add(JsMessage);


                BlazorTimeAnalyzer.Reset();
                BlazorTimeAnalyzer.Add("set data", MethodBase.GetCurrentMethod());
                await LBDJsInterop.SetData("myTmpVar1", JsMessage);

                BlazorTimeAnalyzer.Add("process data", MethodBase.GetCurrentMethod());
                LBDJsInterop.ProcessData("myTmpVar1");


                BlazorTimeAnalyzer.Add("get data", MethodBase.GetCurrentMethod());
                log.Add(await LBDJsInterop.GetData("myTmpVar1"));

                BlazorTimeAnalyzer.LogAll();


                JsMessage = string.Empty;

            }
            else
            {
                await LBDJsInterop.Alert("Please input message");
            }


            StateHasChanged();
        }

        public async void JsSendMessageFast()
        {

            if (!string.IsNullOrEmpty(JsMessage))
            {
                await CounterHelper.CmdAddCounter(new TSCounter() { Source = navigationManager.Uri, Action = "ClickButtonFast" });

                ExpandData();

                log.Add(JsMessage);


                BlazorTimeAnalyzer.Reset();
                BlazorTimeAnalyzer.Add("set data", MethodBase.GetCurrentMethod());
                JsFastDataExchanger.SetStringData("myTmpVar1", JsMessage);

                BlazorTimeAnalyzer.Add("process data", MethodBase.GetCurrentMethod());
                LBDJsInterop.ProcessData("myTmpVar1");


                BlazorTimeAnalyzer.Add("get data", MethodBase.GetCurrentMethod());
                log.Add(JsFastDataExchanger.GetStringData("myTmpVar1"));


                BlazorTimeAnalyzer.LogAll();

                JsMessage = string.Empty;

            }
            else
            {
                await LBDJsInterop.Alert("Please input message");
            }


            StateHasChanged();
        }


        public void ExpandData()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 100000; i++)
            {
                sb.Append(JsMessage);
            }

            JsMessage = sb.ToString();

        }


        public void ClearLog()
        {
            if (log.Any())
            {
                log = new List<string>();

            }
        }
    }
}
