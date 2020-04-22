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
    public partial class DedicatedWebWorkerPage
    {

        [Inject]
        IJSRuntime jsRuntime { get; set; }

        protected int TransportCode = 0;

        public bool IsDisabled = true;

        //https://www.WebWorker.org/echo.html
        public string Ww_URL = "DedicatedWebWorker1.js";
       

        protected WebWorkerHelper WebWorkerHelper1;



        protected string Ww_Button = "connect";


        protected string Ww_Status = "null";


        protected string Ww_Message;


        BwwJsInterop bwwJsInterop;

        protected override void OnInitialized()
        {

            bwwJsInterop = new BwwJsInterop(jsRuntime);

            _create(false);

            base.OnInitialized();
        }

        public void WwOnStateChange(short par_state)
        {
            Ww_Status = WebWorkerHelper1.bwwState.ToString();

            StateHasChanged();
        }


        public void WwOnError(string par_error)
        {

            bwwJsInterop.Alert(par_error);
        }


        public void WwOnMessage(BwwMessage par_message)
        {
            StateHasChanged();
        }

        public void WwCreate()
        {
            _create();
        }


        private void _create(bool Refresh = true)
        {


            if (Ww_Button == "connect")
            {


                WebWorkerHelper1 = new WebWorkerHelper(Ww_URL, string.Empty, BWorkerType.dedicated, BwwTransportType.Text, jsRuntime)
                {
                    OnStateChange = WwOnStateChange,
                    LogMaxCount = 6,
                };
                Ww_Status = BwwState.Open.ToString();

                WebWorkerHelper1.OnMessage = WwOnMessage;
                WebWorkerHelper1.OnError = WwOnError;

                IsDisabled = false;
                Ww_Button = "disconnect";
            }
            else
            {

                Ww_Status = BwwState.Close.ToString();
                WebWorkerHelper1.Dispose();
                IsDisabled = true;
                Ww_Button = "connect";
            }

            if (Refresh)
            {
                StateHasChanged();
            }
        }





        public void WwSendMessage()
        {
            if (WebWorkerHelper1.bwwState == BwwState.Open)
            {
                if (!string.IsNullOrEmpty(Ww_Message))
                {
                    if (int.TryParse(Ww_Message, out int k))
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
                        bwwJsInterop.Alert("Not valid integer!");
                    }

                }
                else
                {
                    bwwJsInterop.Alert("Please input message");
                }
            }
            else
            {
                bwwJsInterop.Alert("Connection is closed");
            }
        }



        public async void WwCalculateJS()
        {

            if (!string.IsNullOrEmpty(Ww_Message))
            {
                int arg = 0;
                if (int.TryParse(Ww_Message, out arg))
                {

                    bwwJsInterop.Alert((await LBDJsInterop.CalcFib(jsRuntime, arg)).ToString());
                    Ww_Message = string.Empty;
                    StateHasChanged();
                }
                else
                {
                    bwwJsInterop.Alert("Please input valid integer");
                }

            }
            else
            {
                bwwJsInterop.Alert("Please input message");
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
                };


            }
        }

        //private int fib(int num)
        //{
        //    var result = 0;

        //    if (num < 2)
        //    {
        //        result = num;
        //    }
        //    else
        //    {
        //        result = fib(num - 1) + fib(num - 2);
        //    }

        //    return result;
        //}
    }
}
