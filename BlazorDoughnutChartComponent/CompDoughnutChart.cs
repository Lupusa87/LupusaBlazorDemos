﻿using BlazorSvgHelper;
using BlazorSvgHelper.Classes;
using BlazorSvgHelper.Classes.SubClasses;
using BlazorDoughnutChartComponent;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorDoughnutChartComponent
{


    public class CompDoughnutChart : ComponentBase
    {
        [Parameter]
        public double WidthAndHeight { get; set; }

        [Parameter]
        public int ActualValue { get; set; }

        [Parameter]
        public Action<int> ActualValueChanged { get; set; }

        [Parameter]
        public string ForeColor1 { get; set; }

        [Parameter]
        public string ForeColor2 { get; set; }

        svg _Svg = null;


        SvgHelper SvgHelper1 = new SvgHelper();

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

            ComponentSettings.radius_2_Times = WidthAndHeight;


            ComponentSettings.radius_Origin = WidthAndHeight / 2;
            ComponentSettings.radius_BigCircle = ComponentSettings.radius_Origin * 0.9;
            ComponentSettings.radius_SmallCircle = ComponentSettings.radius_Origin * 0.6;
            ComponentSettings.CircleWidth = ComponentSettings.radius_BigCircle - ComponentSettings.radius_SmallCircle;


            Initialize_Gradient();

            Generate_SVG();


            SvgHelper1.Cmd_Render(_Svg,0, builder);


            base.BuildRenderTree(builder);
        }



        public void Generate_SVG()
        {
            _Svg = new svg
            {
                id = "svgDoughnutChart",
                width = ComponentSettings.radius_2_Times,
                height = ComponentSettings.radius_2_Times,
                xmlns = "http://www.w3.org/2000/svg",
            };


            _Svg.Children.Add(new rect
            {
                width = ComponentSettings.radius_2_Times,
                height = ComponentSettings.radius_2_Times,
                fill = ComponentSettings.BG_Color,
                stroke = "blue",
                stroke_width = ComponentSettings.radius_Origin * 0.01
            });


            _Svg.Children.Add(new circle
            {
                cx = 0,
                cy = 0,
                r = ComponentSettings.radius_BigCircle,
                fill = ComponentSettings.BigCircle_Color,
                transform = "translate(" + ComponentSettings.radius_Origin + "," + ComponentSettings.radius_Origin + ")",

            });


            _Svg.Children.Add(new circle
            {
                cx = 0,
                cy = 0,
                r = ComponentSettings.radius_SmallCircle,
                fill = ComponentSettings.BG_Color,
                transform = "translate(" + ComponentSettings.radius_Origin + "," + ComponentSettings.radius_Origin + ")",

            });


            _Svg.Children.Add(new text
            {
                content = ActualValue + "%",
                fill = GetColor(), 
                font_size = 35,
                text_anchor = "middle",
                dominant_baseline = "middle",
                transform_origin = "center",
                font_weight = "bold",
                transform = "translate(" + ComponentSettings.radius_Origin + "," + ComponentSettings.radius_Origin + ")",

            });




            _Svg.Children.Add(drawGauge());

        }



        private path drawGauge()
        {
            double angle = ActualValue * 3.60;
            if (angle==360)
            {
                angle=359.99;
            }

            double r = ComponentSettings.radius_SmallCircle + ComponentSettings.CircleWidth / 2;

            double l = ComponentSettings.radius_Origin - r;
            MyPoint p = GetPoint(angle, r);


            StringBuilder sb = new StringBuilder();

            sb.Append("M");
            sb.Append(ComponentSettings.radius_Origin);
            sb.Append(" ");
            sb.Append(l);
            sb.Append(" ");

            sb.Append("A");
            sb.Append(r);
            sb.Append(" ");
            sb.Append(r);
            sb.Append(" ");
            sb.Append("0");
            sb.Append(" ");
            if (angle > 180)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }
            sb.Append(" ");
            sb.Append("1");
            sb.Append(" ");

            sb.Append(p.x);
            sb.Append(" ");

            sb.Append(p.y);



            return new path()
            {
                id = "Path1",
                fill = "none",
                stroke = GetColor(),
                stroke_width = ComponentSettings.CircleWidth,
                d = sb.ToString(),
            };

        }



        private void Initialize_Gradient()
        {
            if (!ForeColor1.Equals(ForeColor2, StringComparison.InvariantCultureIgnoreCase))
            {
                
                MyGradient.Initialize(ForeColor1, ForeColor2);
            }

        }

        private string GetColor()
        {
            if (ForeColor1.Equals(ForeColor2, StringComparison.InvariantCultureIgnoreCase))
            {
                return ForeColor1;
            }
            else
            {
                return MyGradient.Get_Color(ActualValue);
            }
 
        }




            private MyPoint GetPoint(double angle, double r, bool FromCenter = true)
        {
            double radians = (angle - 90) * (Math.PI / 180);

            if (FromCenter)
            {
                return new MyPoint()
                {
                    x = ComponentSettings.radius_Origin + r * Math.Cos(radians),
                    y = ComponentSettings.radius_Origin + r * Math.Sin(radians),
                };
            }
            else
            {
                return new MyPoint()
                {
                    x = r * Math.Cos(radians),
                    y = r * Math.Sin(radians),
                };
            }

        }


        public void Dispose()
        {

        }
    }

}
