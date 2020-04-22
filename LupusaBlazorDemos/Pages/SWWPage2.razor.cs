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
    public partial class SWWPage2
    {
        [Inject]
        IJSRuntime jsRuntime { get; set; }

        protected int TransportCode = 0;

        protected List<SwwWs_Item> log_list = new List<SwwWs_Item>();

        public bool IsDisabled = true;

        //https://www.WebWorker.org/echo.html
        public string Ww_URL = "SharedWebWorker2.js";
        public string Ww_Name = "MySharedWW2";
        protected WebWorkerHelper WebWorkerHelper1;



        protected string Ww_Button = "connect";


        protected string Ww_Status = "null";


        protected string Ww_Message;


        BwwJsInterop bwwJsInterop;


        protected override void OnInitialized()
        {

            bwwJsInterop = new BwwJsInterop(jsRuntime);

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

            bwwJsInterop.Alert(par_error);
        }


        public void WwOnMessage(BwwMessage par_message)
        {
          
            BwwBag b =par_message.WwBag;

            if (par_message.TransportType == BwwTransportType.Text)
            {
                

                if ((BResultType)b.Cmd == BResultType.ActualMessage)
                { 
               
                        SwwWs_Item i = new SwwWs_Item
                        {
                            GUID = Guid.NewGuid().ToString(),
                            Date = DateTime.Now,
                            Caption = b.data,
                            ClientID = b.ClientID,
                        };

                        log_list.Insert(0,i);

                        StateHasChanged();
                       
                }
            }
            else
            {
               
                if ((BResultType)b.Cmd == BResultType.ActualMessage)
                { 
                    
                        SwwWs_Item i = new SwwWs_Item
                        {
                            GUID = Guid.NewGuid().ToString(),
                            Date = DateTime.Now,
                            Caption = Encoding.UTF8.GetString(b.binarydata) + " [" + string.Join(", ", b.binarydata) + "]",
                            ClientID = b.ClientID,
                        };

                        log_list.Insert(0,i);

                        StateHasChanged();
                        
                }
            }

        }


        public void WwCreate()
        {


            if (Ww_Button == "connect")
            {


                WebWorkerHelper1 = new WebWorkerHelper(Ww_URL,Ww_Name, BWorkerType.shared, BwwTransportType.Text, jsRuntime);
                WebWorkerHelper1.DoLog = false;
                WebWorkerHelper1.OnStateChange = WwOnStateChange;
                Ww_Status = BwwState.Open.ToString();
                WebWorkerHelper1.LogMaxCount = 8;

                WebWorkerHelper1.OnMessage = WwOnMessage;
                WebWorkerHelper1.OnError = WwOnError;

                IsDisabled = false;

                Ww_Button = "disconnect";
            }
            else
            {
                log_list = new List<SwwWs_Item>();
                WebWorkerHelper1.Send(BCommandType.WwDisconnect, "any", string.Empty);
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
                    bwwJsInterop.Alert("Please input message");
                }
            }
            else
            {
                bwwJsInterop.Alert("Connection is closed");
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
