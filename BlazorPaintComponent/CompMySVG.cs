using BlazorPaintComponent.classes;
using BlazorSvgHelper;
using BlazorSvgHelper.Classes.SubClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPaintComponent
{
    public class CompMySVG: ComponentBase, IDisposable
    {

        [Parameter] 
        public ComponentBase parent { get; set; }

        [Parameter]
        public double par_width { get; set; }

        [Parameter]
        public double par_height { get; set; }

       
        svg _Svg = null;


        SvgHelper SvgHelper1 = new SvgHelper();



        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            Generate_SVG();

            SvgHelper1.Cmd_Render(_Svg,0, builder);

            base.BuildRenderTree(builder);
        }

        public void Generate_SVG()
        {
            _Svg = new svg
            {
                id = "svgPaint",
                width = par_width,
                height = par_height,
                xmlns = "http://www.w3.org/2000/svg",
            };

            _Svg.Children.Add(new rect
            {
                width = par_width,
                height = par_height,
                fill = "wheat",
                stroke = "red",
                stroke_width = 1,
            });



            foreach (var item in (parent as CompBlazorPaint).ObjectsList.OrderBy(x=>x.SequenceNumber))
            {
                switch (item.ObjectType)
                {
                    case BPaintOpbjectType.HandDraw:
                        _Svg.Children.Add(drawPath(item as BPaintHandDraw));


                        if (item.Selected)
                        {
                            MyPointRect p_rect = BPaintFunctions.Get_Border_Points(item as BPaintHandDraw);

                            _Svg.Children.Add(new rect
                            {
                                x = p_rect.x,
                                y = p_rect.y,
                                width = p_rect.width,
                                height = p_rect.height,
                                fill = "none",
                                stroke = "red",
                                stroke_width = 1,
                                style = "opacity:0.2",
                            });
                        }

                        break;
                    case BPaintOpbjectType.Line:
                        BPaintLine currLine = item as BPaintLine;
                        _Svg.Children.Add(drawLine(currLine));
                        if (item.Selected)
                        {
                            circle c1 = new circle()
                            {
                                cx = currLine.StartPosition.x + currLine.PositionChange.x,
                                cy = currLine.StartPosition.y + currLine.PositionChange.y,
                                r = currLine.width * 1.5,
                                fill = "wheat",
                                stroke = currLine.Color,
                                stroke_width = 2,
                                
                            };

                            if (currLine.Scale.x != 0 || currLine.Scale.y != 0)
                            {
                                c1.transform = "scale(" + currLine.Scale.x + "," + currLine.Scale.y + ")";
                            }
                            _Svg.Children.Add(c1);

                            circle c2 = new circle()
                            {
                                cx = currLine.end.x + currLine.PositionChange.x,
                                cy = currLine.end.y + currLine.PositionChange.y,
                                r = currLine.width * 1.5,
                                fill = "wheat",
                                stroke = currLine.Color,
                                stroke_width = 2,
                            };

                            if (currLine.Scale.x != 0 || currLine.Scale.y != 0)
                            {
                                c2.transform = "scale(" + currLine.Scale.x + "," + currLine.Scale.y + ")";
                            }
                            _Svg.Children.Add(c2);


                            MyPointRect p_rect = BPaintFunctions.Get_Border_Points(item as BPaintLine);

                            _Svg.Children.Add(new rect
                            {
                                x = p_rect.x,
                                y = p_rect.y,
                                width = p_rect.width,
                                height = p_rect.height,
                                fill = "none",
                                stroke = "red",
                                stroke_width = 1,
                                style = "opacity:0.2",
                            });
                        }

                        
                        break;
                    default:
                        break;
                }
            }

        }



        private line drawLine(BPaintLine Par_Object)
        {
            line l = new line()
            {
                x1 = Par_Object.StartPosition.x + Par_Object.PositionChange.x,
                y1 = Par_Object.StartPosition.y + Par_Object.PositionChange.y,
                x2 = Par_Object.end.x + Par_Object.PositionChange.x,
                y2 = Par_Object.end.y + Par_Object.PositionChange.y,
               // opacity = 1,
                stroke = Par_Object.Color,
                stroke_width = Par_Object.width,
               // stroke_linecap = strokeLinecap.round,

               

               
            };


            if (Par_Object.Scale.x!=0 || Par_Object.Scale.y!=0)
            {
                l.transform = "scale(" + Par_Object.Scale.x + "," + Par_Object.Scale.y + ")";
            }

            return l;
        }


        private path drawPath(BPaintHandDraw Par_Object)
        {

            StringBuilder sb = new StringBuilder();

            bool IsFirst = true;


            sb.Append("M");
            sb.Append(Par_Object.StartPosition.x + Par_Object.PositionChange.x);
            sb.Append(" ");
            sb.Append(Par_Object.StartPosition.y + Par_Object.PositionChange.y);
            sb.Append(" ");

            for (int i = 0; i < Par_Object.data.Count; i++)
            {
                sb.Append("L");
                sb.Append(Par_Object.data[i].x + Par_Object.PositionChange.x);
                sb.Append(" ");
                sb.Append(Par_Object.data[i].y + Par_Object.PositionChange.y);
                sb.Append(" ");
            }


            path p = new path()
            {
                id = "path" + Par_Object.ObjectID,
                fill = "none",
                stroke = Par_Object.Color,
                d = sb.ToString(),
                // opacity = _opacity,
                stroke_width = Par_Object.width,
                
            };


            if (Par_Object.Scale.x != 0 || Par_Object.Scale.y != 0)
            {
                p.transform = "scale(" + Par_Object.Scale.x + "," + Par_Object.Scale.y + ")";
            }


            return p;
        }


        public void Refresh()
        {
            StateHasChanged();
        }


        public void Dispose()
        {

        }

    }
}
