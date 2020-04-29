using BlazorWebSocketHelper;
using BlazorWebSocketHelper.Classes;
using BlazorWindowHelper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static BlazorWebSocketHelper.Classes.BwsEnums;


namespace LupusaBlazorDemos.Pages
{
    public partial class WebSocketPage
    {
        [Inject]
        IJSRuntime jsRuntime { get; set; }

        BwsJsInterop bwsJsInterop;

        protected int TransportCode = 0;

        public bool IsDisabled = true;

        //https://www.websocket.org/echo.html
        public string Ws_URL = "wss://echo.websocket.org"; //"wss://demos.kaazing.com/echo"; // "ws://192.168.1.17:9000/Data/";

        public WebSocketHelper WebSocketHelper1;

        protected List<BwsMessage> log = new List<BwsMessage>();

        protected string Ws_Button = "connect";


        protected string Ws_Status = "undefined";


        protected string Ws_Message = "abc";

        protected override void OnInitialized()
        {
            bwsJsInterop = new BwsJsInterop(jsRuntime);

            BlazorWindowHelper.BlazorWindowHelper.Initialize();

            

            WsConnect();

            base.OnInitialized();
        }

        public void WsOnStateChange(short par_state)
        {
            Ws_Status = WebSocketHelper1.bwsState.ToString();

            if (WebSocketHelper1.bwsState == BwsState.Close)
            {
                WebSocketHelper1.Dispose();
            }


            StateHasChanged();
        }


        public void Cmd_SetTransport(int Par_transportCode)
        {
            if (TransportCode != Par_transportCode)
            {
                TransportCode = Par_transportCode;

                BwsTransportType b = (BwsTransportType)(TransportCode);


                if (WebSocketHelper1.TransportType != b)
                {
                    WebSocketHelper1.SetTransportType(b);
                };
            }
        }





        public void WsOnError(string par_error)
        {

            bwsJsInterop.Alert(par_error);
        }


        public void WsOnMessage(BwsMessage par_message)
        {
         
            par_message.ID = GetNewIDFromLog();
            log.Add(par_message);


            StateHasChanged();


        }


        public void WsConnect()
        {


            if (Ws_Button == "connect")
            {

                WebSocketHelper1 = new WebSocketHelper(Ws_URL, (BwsTransportType)(TransportCode), jsRuntime)
                {
                    DoLog = false,
                    OnStateChange = WsOnStateChange,
                    OnMessage = WsOnMessage,
                    OnError = WsOnError
                };

                IsDisabled = false;
                log = new List<BwsMessage>();
                Ws_Button = "disconnect";
            }
            else
            {

                WebSocketHelper1.Close();
                IsDisabled = true;
                Ws_Button = "connect";
                log = new List<BwsMessage>();
            }


        }



        public void WsSendMessage()
        {

           
            if (WebSocketHelper1.bwsState == BwsState.Open)
            {
                if (!string.IsNullOrEmpty(Ws_Message))
                {


                    switch (WebSocketHelper1.TransportType)
                    {
                        case BwsTransportType.Text:
                            log.Add(new BwsMessage()
                            {
                                ID = GetNewIDFromLog(),
                                Date = DateTime.Now,
                                Message = Ws_Message,
                                MessageType = BwsMessageType.send,
                                TransportType = WebSocketHelper1.TransportType,
                            });
                            WebSocketHelper1.Send(Ws_Message);
                            break;
                        case BwsTransportType.ArrayBuffer:

                            byte[] data = Encoding.UTF8.GetBytes(Ws_Message);
                            BwsMessage b = new BwsMessage()
                            {
                                ID = GetNewIDFromLog(),
                                Date = DateTime.Now,
                                Message = Ws_Message,
                                MessageBinary = data,
                                MessageType = BwsMessageType.send,
                                TransportType = WebSocketHelper1.TransportType,
                            };


                            WebSocketHelper1.Send(b.MessageBinary);

                            b.MessageBinaryVisual = string.Join(", ", data);

                            log.Add(b);
                     
                            break;
                        case BwsTransportType.Blob:
                            break;
                        default:
                            break;
                    }

                    Ws_Message = string.Empty;

                }
                else
                {
                    bwsJsInterop.Alert("Please input message");
                }
            }
            else
            {
                bwsJsInterop.Alert("Connection is closed");
            }
        }



        private int GetNewIDFromLog()
        {

            if (log.Any())
            {
                return log.Max(x => x.ID) + 1;
            }
            else
            {
                return 1;
            }
        }

        public async void WsGetStatus()
        {
            Ws_Status = await WebSocketHelper1.Get_WsStatus();
            await bwsJsInterop.Alert(Ws_Status);
            StateHasChanged();
        }

        public void ClearLog()
        {
            if (log.Any())
            {
                log = new List<BwsMessage>();
                StateHasChanged();
            }
        }


    }
}
