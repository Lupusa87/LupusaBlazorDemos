using BlazorWebWorkerHelper.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlazorWebWorkerHelper.classes.BwwEnums;

namespace BlazorApp1.Components
{

    public class CompWwMessage : ComponentBase, IDisposable
    {

        [Parameter]
        protected BwwMessage bwwMessage { get; set; }


        [Parameter]
        protected ComponentBase parent { get; set; }


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {


            int k = -1;



            builder.OpenElement(k++, "div");
            builder.AddAttribute(k++, "id", "listitem" + bwwMessage.ID); // + Guid.NewGuid().ToString("d").Substring(1, 4));
            builder.AddAttribute(k++, "style", "width:800px;max-height:26px;position:relative;margin:5px");
            builder.OpenElement(k++, "span");





            if (bwwMessage.MessageType == BwwMessageType.send)
            {
                builder.AddAttribute(k++, "style", "position:absolute;top:0px;cursor:pointer;color:blue");
            }
            else
            {
                builder.AddAttribute(k++, "style", "position:absolute;top:0px;cursor:pointer;color:green");
            }


            switch (bwwMessage.MessageType)
            {
                case BwwMessageType.send:

                    switch (bwwMessage.TransportType)
                    {
                        case BwwTransportType.Text:
                            builder.AddContent(k++, bwwMessage.MessageType.ToString() + ": " + bwwMessage.WwBag.data);
                            break;
                        case BwwTransportType.Binary:
                            string d = Encoding.UTF8.GetString(bwwMessage.WwBag.binarydata);
                            builder.AddContent(k++, bwwMessage.MessageType.ToString() + ": " + d +
                               " [" + string.Join(", ", bwwMessage.WwBag.binarydata) +
                               "]");
                            break;

                        default:
                            break;
                    }

                    break;
                case BwwMessageType.received:


                    switch (bwwMessage.TransportType)
                    {
                        case BwwTransportType.Text:
                            builder.AddContent(k++, bwwMessage.MessageType.ToString() + ": " + bwwMessage.WwBag.data);
                            break;
                        case BwwTransportType.Binary:
                            builder.AddContent(k++, bwwMessage.MessageType.ToString() + ": " + Encoding.UTF8.GetString(bwwMessage.WwBag.binarydata) +
                               " [" + string.Join(", ", bwwMessage.WwBag.binarydata) +
                               "]");
                            break;

                        default:
                            break;
                    }

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
