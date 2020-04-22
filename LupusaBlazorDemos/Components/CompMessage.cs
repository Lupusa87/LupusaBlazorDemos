using BlazorWebSocketHelper.Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlazorWebSocketHelper.Classes.BwsEnums;

namespace LupusaBlazorDemos.Components
{

    public class CompMessage : ComponentBase, IDisposable
    {

        [Parameter]
        public BwsMessage bwsMessage { get; set; }


        [Parameter]
        public ComponentBase parent { get; set; }


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
                       bwsMessage.Message +
                       " [" + bwsMessage.MessageBinaryVisual +
                       "]");
                    //}
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

        public void Dispose()
        {

        }
    }

}
