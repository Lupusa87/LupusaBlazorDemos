using BlazorWebSocketHelper.Classes;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.RenderTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlazorWebSocketHelper.Classes.BwsEnums;

namespace BlazorWebSocketWebWorker.Client.Components
{


    public class CompMessage : BlazorComponent, IDisposable
    {

        [Parameter]
        protected BwsMessage bwsMessage { get; set; }


        [Parameter]
        protected BlazorComponent parent { get; set; }


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {


            int k = -1;



            builder.OpenElement(k++, "div");
            builder.AddAttribute(k++, "id", "listitem" + bwsMessage.ID); // + Guid.NewGuid().ToString("d").Substring(1, 4));
            builder.AddAttribute(k++, "style", "width:400px;max-height:26px;position:relative;margin:5px");
            builder.OpenElement(k++, "span");





            if (bwsMessage.MessageType == BwsMessageType.send)
            {
                builder.AddAttribute(k++, "style", "position:absolute;top:0px;cursor:pointer;color:blue");
            }
            else
            {
                builder.AddAttribute(k++, "style", "position:absolute;top:0px;cursor:pointer;color:green");
            }

            switch (bwsMessage.TransportType)
            {
                case BwsTransportType.Text:
                    builder.AddContent(k++, bwsMessage.ID + " " +
                        bwsMessage.Date.ToString("HH:mm:ss.fff") + " " +
                        bwsMessage.MessageType.ToString() + " " +
                        bwsMessage.TransportType.ToString().ToLower() + ": " +
                        bwsMessage.Message);
                    break;
                case BwsTransportType.ArrayBuffer:
                    builder.AddContent(k++, bwsMessage.ID + " " +
                        bwsMessage.Date.ToString("HH:mm:ss.fff") + " " +
                        bwsMessage.MessageType.ToString() + " " +
                        bwsMessage.TransportType.ToString().ToLower() + ": " +
                        Encoding.UTF8.GetString(bwsMessage.MessageBinary) +
                        " [" + ByteArrayToVisualString(bwsMessage.MessageBinary) + "]");
                    break;
                case BwsTransportType.Blob:
                    break;
                default:
                    break;
            }



            builder.CloseElement();

            builder.CloseElement();


            base.BuildRenderTree(builder);
        }

        private string ByteArrayToVisualString(byte[] par_b)
        {

            if (par_b.Length > 0)
            {
                StringBuilder s = new StringBuilder();
                for (int i = 0; i < par_b.Length; i++)
                {
                    s.Append(par_b[i] + ",");
                }
                s.Remove(s.Length - 1, 1);

                return s.ToString();

            }


            return string.Empty;


        }

        public void Dispose()
        {

        }
    }
}
