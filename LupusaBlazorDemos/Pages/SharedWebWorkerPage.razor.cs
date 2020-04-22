using BlazorWebWorkerHelper;
using BlazorWebWorkerHelper.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlazorWebWorkerHelper.classes.BwwEnums;

namespace LupusaBlazorDemos.Pages
{
    public partial class SharedWebWorkerPage
    {
        [Inject]
        IJSRuntime jsRuntime { get; set; }

        protected int TransportCode = 0;

        public bool IsDisabled = true;

        //https://www.WebWorker.org/echo.html
        public string Ww_URL = "SharedWebWorker1.js";
        public string Ww_Name = "MySharedWW1";
        protected WebWorkerHelper WebWorkerHelper1;



        protected string Ww_Button = "connect";


        protected string Ww_Status = "null";


        protected string Ww_Message;


        protected override void OnInitialized()
        {
            WwCreate();

            base.OnInitialized();
        }

        public void WwOnStateChange(short par_state)
        {

            Ww_Status = WebWorkerHelper1.bwwState.ToString();

            StateHasChanged();
        }


        public void WwOnError(string par_error)
        {

            BwwJsInterop.Alert(par_error);
        }


        public void WwOnMessage(BwwMessage par_message)
        {
            StateHasChanged();
        }


        public void WwCreate()
        {


            if (Ww_Button == "connect")
            {


                WebWorkerHelper1 = new WebWorkerHelper(Ww_URL, Ww_Name, BWorkerType.shared, BwwTransportType.Text)
                {
                    LogMaxCount = 8,
                    OnStateChange = WwOnStateChange
                };
                Ww_Status = BwwState.Open.ToString();
                

                WebWorkerHelper1.OnMessage = WwOnMessage;
                WebWorkerHelper1.OnError = WwOnError;

                IsDisabled = false;

                Ww_Button = "disconnect";
            }
            else
            {
                WebWorkerHelper1.Send(BCommandType.WwDisconnect, string.Empty, string.Empty);
                WebWorkerHelper1.Dispose();

                IsDisabled = true;

                Ww_Button = "connect";
            }


        }




        public async void GenerateNew()
        {


            Ww_Message = await LBDJsInterop.GenerateNewUser(jsRuntime);
            StateHasChanged();

        }


        public void WwSendMessage()
        {
            if (WebWorkerHelper1.bwwState == BwwState.Open)
            {
                if (!string.IsNullOrEmpty(Ww_Message))
                {

                    switch (WebWorkerHelper1.bwwTransportType)
                    {
                        case BwwTransportType.Text:

                            WebWorkerHelper1.Send(BCommandType.send, Ww_Message, string.Empty);
                            Ww_Message = string.Empty;
                            StateHasChanged();

                            break;
                        case BwwTransportType.Binary:
                            byte[] data = Encoding.UTF8.GetBytes(Ww_Message);
                            WebWorkerHelper1.Send(BCommandType.send, data, string.Empty);

                            Ww_Message = string.Empty;
                            StateHasChanged();

                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    BwwJsInterop.Alert("Please input message");
                }
            }
            else
            {
                BwwJsInterop.Alert("Connection is closed");
            }
        }


        public void Cmd_SetTransport(int Par_transportCode)
        {
            if (TransportCode != Par_transportCode)
            {
                TransportCode = Par_transportCode;

                BwwTransportType b = (BwwTransportType)(TransportCode);


                if (WebWorkerHelper1.bwwTransportType != b)
                {
                    WebWorkerHelper1.SetTransportType(b);
                    WebWorkerHelper1.Send(BCommandType.MultyPurposeItem1, TransportCode.ToString(), string.Empty, false);
                };


            }
        }

    }
}
