using BlazorSharedWebWorkerWebSocketHelper;
using BlazorWebWorkerHelper;
using BlazorWebWorkerHelper.classes;
using BlazorWebWorkerHelper.WsClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Pages
{
    public partial class SwwWsPage2
    {
        [Inject]
        IJSRuntime jsRuntime { get; set; }

        protected List<SwwWs2_Item> log_list = new List<SwwWs2_Item>();

        public bool IsDisabled = true;

        BSwwWsJsInterop bSwwWsJsInterop;
        BwwJsInterop bwwJsInterop;

        protected SharedWebWorkerWebSocketHelper SharedWebWorkerWebSocketHelper1;

        public string Sww_URL = "SharedWebWorkerWebSocket2.js";
        public string Sww_Name = "MySharedWW4";
        protected string Sww_Button = "connect";
        protected string Sww_Status = "null";
        protected string Sww_Message = "abc";


        //This is only for UI, If you need actual change check SharedWebWorkerWebSocket2.js
        public string Ws_URL = "wss://demos.kaazing.com/echo";




        protected override void OnInitialized()
        {
            bSwwWsJsInterop = new BSwwWsJsInterop(jsRuntime);
            bwwJsInterop = new BwwJsInterop(jsRuntime);

            SwwCreate();

            base.OnInitialized();
        }

        public void SwwOnStateChange(short par_state)
        {

            Sww_Status = SharedWebWorkerWebSocketHelper1.bSwwWsState.ToString();

            StateHasChanged();
        }


        public void SwwOnError(string par_error)
        {

            bSwwWsJsInterop.Alert(par_error);
        }


        public void SwwOnMessage(byte[] par_message)
        {


            SwwWs2_Item i = new SwwWs2_Item
            {
                GUID = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                Caption = Encoding.UTF8.GetString(par_message) + " [" + string.Join(", ", par_message.Take(100)) + "]",
            };

            log_list.Insert(0, i);

            //BlazorWindowHelper.BlazorTimeAnalyzer.Log();

            StateHasChanged();

        }


        public void SwwCreate()
        {
            if (Sww_Button == "connect")
            {

                SharedWebWorkerWebSocketHelper1 = new SharedWebWorkerWebSocketHelper(Sww_URL, Sww_Name, jsRuntime)
                {
                    OnStateChange = SwwOnStateChange
                };

                Sww_Status = BSwwWsState.Open.ToString();


                SharedWebWorkerWebSocketHelper1.OnMessage = SwwOnMessage;
                SharedWebWorkerWebSocketHelper1.OnError = SwwOnError;

                IsDisabled = false;

                Sww_Button = "disconnect";
            }
            else
            {
                log_list = new List<SwwWs2_Item>();


                SharedWebWorkerWebSocketHelper1.Dispose();

                IsDisabled = true;

                Sww_Button = "connect";

            }


        }




        public void SwwSendMessage()
        {
            //BlazorWindowHelper.BlazorTimeAnalyzer.Reset();
            //BlazorWindowHelper.BlazorTimeAnalyzer.Add("WwSendMessage", MethodBase.GetCurrentMethod());

            if (SharedWebWorkerWebSocketHelper1.bSwwWsState == BSwwWsState.Open)
            {
                if (!string.IsNullOrEmpty(Sww_Message))
                {

                    SharedWebWorkerWebSocketHelper1.Send(Encoding.UTF8.GetBytes(Sww_Message));

                    Sww_Message = string.Empty;
                    StateHasChanged();
                }
                else
                {
                    bwwJsInterop.Alert("Please input message");
                }
            }
            else
            {
                bwwJsInterop.Alert("Connection to web worker is closed");
            }
        }


    }


    public class SwwWs2_Item
    {
        public string GUID { get; set; }
        public DateTime Date { get; set; }
        public string Caption { get; set; }
    }
}
