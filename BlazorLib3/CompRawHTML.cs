using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.RenderTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorLib3
{
    public class CompRawHTML : BlazorComponent
    {
        [Parameter]
        public string RawHTML { get; set; }


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            LupParser lp1 = new LupParser(RawHTML);


            if (lp1.Validate())
            {
                try
                {
                    lp1.Parse();
                }
                catch (Exception ex)
                {
                    lp1.Display_Error(ex.Message);
                }
            }


            int k = 0;

            //builder.OpenElement(k++, "style");
            //string a = @"table {
            //                    font-family: arial, sans-serif;
            //                    border-collapse: collapse;
            //                    width: 100%;
            //                }

            //                    td, th {
            //                    border: 1px solid #dddddd;
            //                    text-align: left;
            //                    padding: 8px;
            //                }

            //                tr:nth-child(even)
            //                {
            //                    background - color: #dddddd;
            //                }";

            //builder.AddContent(k++, a);
            //builder.CloseElement();



            foreach (var item in lp1.HtmlElements_List)
            {
                Cmd_Render(item, k, builder);
            }


        }

    

        public void Cmd_Render(HtmlElement _item, int k, RenderTreeBuilder builder)
        {

            builder.OpenElement(k++, _item.Name);
            Console.WriteLine("open " + _item.Name);


            if (_item.attributes.Any())
            {
                foreach (var item in _item.attributes)
                {
                    builder.AddAttribute(k++, item.Key, item.Value.Replace("|","/"));
                    Console.WriteLine("set attribute - " + item.Key + " = " + item.Value);
                }
            }

            if (!string.IsNullOrEmpty(_item.Content))
            {
                builder.AddContent(k++, _item.Content);
                Console.WriteLine("set content - " + _item.Content);
            }

        

            if (_item.children.Any())
            {

                foreach (HtmlElement item in _item.children)
                {
                    Cmd_Render(item, k, builder);
                }
            }

            builder.CloseElement();
            Console.WriteLine("close element " + _item.GetType().Name.ToLower());
        }


        public void Dispose()
        {

        }
    }
}
