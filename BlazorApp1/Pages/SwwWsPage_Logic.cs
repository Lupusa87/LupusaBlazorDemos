using BlazorWebWorkerHelper;
using BlazorWebWorkerHelper.classes;
using BlazorWebWorkerHelper.WsClasses;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static BlazorWebSocketHelper.Classes.BwsEnums;
using static BlazorWebWorkerHelper.classes.BwwEnums;

namespace BlazorApp1.Pages
{
    public class SwwWsPage_Logic: BlazorComponent
    {
        protected int TransportCode = 0;

        protected List<SwwWs_Item> log_list = new List<SwwWs_Item>();

        public bool IsDisabled = true;

        //https://www.WebWorker.org/echo.html


        protected WebWorkerHelper WebWorkerHelper1;

        public string Ww_URL = "SharedWebWorkerWebSocket.js";
        public string Ww_Name = "MySharedWW3";
        protected string Ww_Button = "connect";
        protected string Ww_Status = "null";
        protected string Ww_Message = "abc";

        public string Ws_URL = "wss://demos.kaazing.com/echo";
        protected string Ws_Button = "connect";
        protected string Ws_Status = "null";
        public bool WsIsDisabled = true;

        protected override void OnInit()
        {
            WwCreate();

            base.OnInit();
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
            BwwBag b = par_message.WwBag;

            if (par_message.TransportType == BwwTransportType.Text)
            {
                
                
                BResultType r = (BResultType)b.Cmd;
                switch (r)
                {
                    case BResultType.ActualMessage:
                        SwwWs_Item i = new SwwWs_Item
                        {
                            GUID = Guid.NewGuid().ToString(),
                            Date = DateTime.Now,
                            Caption = b.data,
                            ClientID = b.ClientID,
                        };

                        log_list.Insert(0,i);

                        StateHasChanged();
                        break;
                    case BResultType.StateChange:
                        BwwState s = ((BwwState)short.Parse(b.data));
                        if (s == BwwState.Close)
                        {
                            WwClose();
                        }
                        else
                        {

                            Ws_Status = s.ToString();
                            WebWorkerHelper1.Ws_List.Single(x => x.bWebSocketID == WebWorkerHelper1.Active_WebSocket_ID).state = s;
                        }



                        StateHasChanged();
                        break;
                    case BResultType.MultyPurposeItem1:
                        WsCreateInternal(b.data);
                        break; 
                    default:
                        break;
                }
            }
            else
            {
                
                BResultType r = (BResultType)b.Cmd;
                switch (r)
                {
                    case BResultType.ActualMessage:
                        SwwWs_Item i = new SwwWs_Item
                        {
                            GUID = Guid.NewGuid().ToString(),
                            Date = DateTime.Now,
                            Caption = Encoding.UTF8.GetString(b.binarydata) + " [" + string.Join(", ", b.binarydata) + "]",
                            ClientID = b.ClientID,
                        };

                        log_list.Insert(0,i);
                        
                        StateHasChanged();
                        break;
                    case BResultType.StateChange:
                        WebWorkerHelper1.Ws_List.Single(x => x.bWebSocketID == WebWorkerHelper1.Active_WebSocket_ID).state = (BwwState)short.Parse(b.data);
                        break;
                    default:
                        break;
                }
            }
           
           

           
        }


        public void WwCreate()
        {
            if (Ww_Button == "connect")
            {

                WebWorkerHelper1 = new WebWorkerHelper(Ww_URL, Ww_Name, BWorkerType.shared, BwwTransportType.Text)
                {
                    DoLog = false,
                    OnStateChange = WwOnStateChange
                };

                Ww_Status = BwwState.Open.ToString();
                WebWorkerHelper1.LogMaxCount = 8;

                WebWorkerHelper1.OnMessage = WwOnMessage;
                WebWorkerHelper1.OnError = WwOnError;


                WsCreate();


                IsDisabled = false;

                Ww_Button = "disconnect";
            }
            else
            {
                WwClose();
            }


        }


        public void WwClose()
        {
            log_list = new List<SwwWs_Item>();

            WsClose();


            WebWorkerHelper1.Send(BCommandType.WwDisconnect, "any");
            WebWorkerHelper1.Dispose();

            IsDisabled = true;

            Ww_Button = "connect";
        }

            public void WsCreate()
        {
            if (Ws_Button == "connect")
            {

                WebWorkerHelper1.Send(BCommandType.MultyPurposeItem1, Ws_URL);

                
                WsIsDisabled = false;

                Ws_Button = "disconnect";
            }
            else
            {

                WsClose();
            }

        }

        public void WsClose()
        {
            foreach (var item in WebWorkerHelper1.Ws_List)
            {
                WebWorkerHelper1.Send(BCommandType.WsRemove, item.id);
            }

            WsIsDisabled = true;
            Ws_Status = BwwState.Close.ToString();
            Ws_Button = "connect";
        }


        private void WsCreateInternal(string ExistingWsID)
        {
           
            if (ExistingWsID.Equals("null", StringComparison.InvariantCultureIgnoreCase))
            {
              
                BWebSocket b = new BWebSocket(WebWorkerHelper1._id)
                {
                    bWebSocketID = GetNewIDFromWebSocketsList(),
                    id = BwwFunctions.Cmd_Get_UniqueID(),
                    url = Ws_URL
                };
                WebWorkerHelper1.Ws_List.Add(b);
                WebWorkerHelper1.Active_WebSocket_ID = b.bWebSocketID;

                WebWorkerHelper1.Send(BCommandType.WsAdd, Json.Serialize(new { b.id, b.url }));
            }
            else
            {
                
                BWebSocket b = new BWebSocket(WebWorkerHelper1._id)
                {
                    bWebSocketID = GetNewIDFromWebSocketsList(),
                    id = ExistingWsID,
                    url = Ws_URL
                };
                WebWorkerHelper1.Ws_List.Add(b);
                WebWorkerHelper1.Active_WebSocket_ID = b.bWebSocketID;

                WebWorkerHelper1.Send(BCommandType.MultyPurposeItem2, b.id);
            }

         
        }

        private ushort GetNewIDFromWebSocketsList()
        {

            if (WebWorkerHelper1.Ws_List.Any())
            {
                return (ushort)(WebWorkerHelper1.Ws_List.Max(x => x.bWebSocketID) + 1);
            }
            else
            {
                return 1;
            }
        }



        public async void GenerateNew()
        {


            Ww_Message = await BApp1JsInterop.GenerateNewUser();
            StateHasChanged();

        }


        public void WwSendMessage()
        {

            if (WebWorkerHelper1.bwwState == BwwState.Open)
            {
                if (!string.IsNullOrEmpty(Ww_Message))
                {


                    BWebSocket bWebSocket = WebWorkerHelper1.Ws_List.Single(x => x.bWebSocketID == WebWorkerHelper1.Active_WebSocket_ID);


                    if (bWebSocket.state == BwwState.Open)
                    {
                        switch (WebWorkerHelper1.bwwTransportType)
                        {
                            case BwwTransportType.Text:

                                WebWorkerHelper1.Send(BCommandType.send,
                                Json.Serialize(new { wsID = bWebSocket.id, wsMessage = Ww_Message }));
                                Ww_Message = string.Empty;
                                StateHasChanged();

                                break;
                            case BwwTransportType.Binary:
                                byte[] data = Encoding.UTF8.GetBytes(Json.Serialize(new { wsID = bWebSocket.id, wsMessage = Ww_Message }));
                                WebWorkerHelper1.Send(BCommandType.send, data);
                                Ww_Message = string.Empty;
                                StateHasChanged();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        BwwJsInterop.Alert("Connection to web socket (!) is closed");
                    }

                }
                else
                {
                    BwwJsInterop.Alert("Please input message");
                }
            }
            else
            {
                BwwJsInterop.Alert("Connection to web worker (!) is closed");
            }
        }




        public void cmd_SetTransport(int Par_transportCode)
        {
            if (TransportCode != Par_transportCode)
            {
                TransportCode = Par_transportCode;

                WebWorkerHelper1.SetTransportType((BwwTransportType)(TransportCode));

                
            }
        }

    }


    public class SwwWs_Item
    {
        public string GUID { get; set; }
        public DateTime Date { get; set; }
        public string Caption { get; set; }
        public short ClientID { get; set; }

    }
}
