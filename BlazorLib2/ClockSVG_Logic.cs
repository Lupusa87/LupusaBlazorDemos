using BlazorLib2.Classes;
using BlazorLib2.Classes.SubClasses;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.RenderTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorLib2
{
   
    public class ClockSVG : BlazorComponent
    {
        [Parameter]
        public clockSettings clSettings{ get; set; }

        private double radius_Origin = 0;
        private double radius_90_Percent = 0;


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            radius_Origin = clSettings.width / 2;
            radius_90_Percent = radius_Origin * 0.9;


            svg _svg = Generate_Clock_SVG();
            Cmd_Render(_svg, 0, builder);
        }


        public svg Generate_Clock_SVG()
        {
            svg _Svg = new svg
            {
                width = clSettings.width,
                height = clSettings.heigh,
                xmlns = "http://www.w3.org/2000/svg",
            };




            defs _defs1 = new defs();


            radialGradient _radialGradient = new radialGradient
            {
                 id = "grad1",
                //cx = "50%",
                //cy = "50%",
                r = "53%",
                //fx = "50%",
                //fy = "50%",
                fr = "50%",
            };



            _radialGradient.Children.Add(new stop
            {
                stop_color = "blue",
                offset = "0",
                
               // stop_opacity = "10%",
            });

            _radialGradient.Children.Add(new stop
            {
                stop_color = "LightSkyBlue",
                offset = "1",
                
               // stop_opacity = "100%",
            });

            _defs1.Children.Add(_radialGradient);




            radialGradient _radialGradient2 = new radialGradient
            {
                id = "grad2",
                //cx = "50%",
                //cy = "50%",
                r = "55%",
                //fx = "50%",
                //fy = "50%",
                fr = "44%",
            };



            _radialGradient2.Children.Add(new stop
            {
                stop_color = "blue",
                offset = "0",

                // stop_opacity = "10%",
            });

            _radialGradient2.Children.Add(new stop
            {
                stop_color = "wheat",
                offset = "1",
                stop_opacity = "0.8",
            });

            _defs1.Children.Add(_radialGradient2);

            _Svg.Children.Add(_defs1);


            _Svg.Children.Add(new rect
            {
                width = clSettings.width,
                height = clSettings.heigh,
                fill = "wheat",
                stroke = "url(#grad1)", 
                stroke_width = radius_Origin * 0.01
            });



            _Svg.Children.Add(new image
            {
                x = 0,
                y = 0,
                width = radius_Origin * 0.6,
                height = radius_Origin * 0.6,
                href = "content/1.png",
            });



            double wh = radius_Origin * 0.6;
            double wh2 = wh / 2;

            double x1 = clSettings.heigh - wh;
            double y1 = clSettings.width - wh;

            _Svg.Children.Add(new image
            {
                x = 0,
                y = 0,
                width = wh,
                height = wh,
                href = clSettings.Image_Url,
                transform = "translate (" + x1 + "," + 0 + ") rotate(" + 90 + ", " + wh2 + "," + wh2 + ")",
            });

            _Svg.Children.Add(new image
            {
                x = 0,
                y = 0,
                width = wh,
                height = wh,
                href = clSettings.Image_Url,
                transform = "translate (" + x1 + "," + y1 + ") rotate(" + 180 + ", " + wh2 + "," + wh2 + ")",
            });

            _Svg.Children.Add(new image
            {
                x = 0,
                y = 0,
                width = wh,
                height = wh,
                href = clSettings.Image_Url,
                transform = "translate (" + 0 + "," + y1 + ") rotate(" + 270 + ", " + wh2 + "," + wh2 + ")",
            });




            _Svg.Children.Add(new circle
            {
                cx = 0,
                cy = 0,
                r = radius_90_Percent,
                stroke = "url(#grad2)",
                stroke_width = radius_Origin*0.06,
                fill = "Gainsboro",
                transform = "translate("+radius_Origin+","+radius_Origin+")",
            });


            //_Svg.Children.Add(new rect
            //{
            //    width = 30,
            //    height = 50,
            //    style = "fill:rgb(0,0,255);stroke-width:3;stroke:rgb(0,0,0)",
            //});


            //_Svg.Children.Add(new ellipse
            //{
            //    cx = 200,
            //    cy = 80,
            //    rx = 100,
            //    ry = 50,
            //    style = "fill:yellow;stroke:purple;stroke-width:2",
            //});

            //_Svg.Children.Add(new line
            //{
            //    x1 = 0,
            //    y1 = 0,
            //    x2 = 200,
            //    y2 = 200,
            //    style = "stroke:rgb(255,0,0);stroke-width:2",
            //});

            //_Svg.Children.Add(new polygon
            //{
            //    points = "220,10 300,210 170,250 123,234",
            //    style = "fill:lime;stroke:purple;stroke-width:1",
            //});

            //_Svg.Children.Add(new polygon
            //{
            //    points = "20,20 40,25 60,40 80,120 120,140 200,180",
            //    style = "fill:none;stroke:black;stroke-width:3",
            //});


            //_Svg.Children.Add(new path
            //{
            //    d = "M150 0 L75 200 L225 200 Z",
            //    fill = "red",
            //});

            //_Svg.Children.Add(new path
            //{
            //    d = "M 100 350 l 150 -300",
            //    stroke = "red",
            //    stroke_width = 3,
            //    fill = "none",
            //});

            //_Svg.Children.Add(new path
            //{
            //    d = "M 250 50 l 150 300",
            //    stroke = "red",
            //    stroke_width = 3,
            //    fill = "none",
            //});

            //_Svg.Children.Add(new path
            //{
            //    d = "M 175 200 l 150 0",
            //    stroke = "green",
            //    stroke_width = 3,
            //    fill = "none",
            //});

            //_Svg.Children.Add(new path
            //{
            //    d = "M 100 350 q 150 -300 300 0",
            //    stroke = "blue",
            //    stroke_width = 5,
            //    fill = "none",
            //});

            //g _g = new g()
            //{
            //    stroke = "black",
            //    stroke_width = 3,
            //    fill = "black",
            //};

            //_g.Children.Add(new circle
            //{
            //    cx = 100,
            //    cy = 350,
            //    r = 3,
            //});

            //_g.Children.Add(new circle
            //{
            //    cx = 250,
            //    cy = 50,
            //    r = 3,
            //});

            //_g.Children.Add(new circle
            //{
            //    cx = 400,
            //    cy = 350,
            //    r = 3,
            //});

            //_Svg.Children.Add(_g);



            //g _g2 = new g()
            //{
            //    font_size = 30,
            //    font_family = "sans-serif",
            //    text_anchor = "middle",
            //    stroke = "none",
            //    fill = "black",
            //};

            //_g2.Children.Add(new text
            //{
            //    x = 100,
            //    y = 350,
            //    dx = -30,
            //    content = "A",
            //});

            //_g2.Children.Add(new text
            //{
            //    x = 250,
            //    y = 50,
            //    dy = -10,
            //    content = "B",
            //});

            //_g2.Children.Add(new text
            //{
            //    x = 400,
            //    y = 350,
            //    dx = 30,
            //    content = "C",
            //});

            //_Svg.Children.Add(_g2);


            //_Svg.Children.Add(new path
            //{
            //    d = "M5 60 l215 0",
            //    stroke ="blue",
            //    stroke_width = 10,
            //    stroke_linecap = strokeLinecap.round,
            //    stroke_dasharray = "20,10,5,5,5,10",
            //});


            return _Svg;
        }


        public bool Check_Type(PropertyInfo pi)
        {
            Console.WriteLine(pi.PropertyType);


            //Console.WriteLine(nameof(System.String));
            //switch (pi.PropertyType.Name.ToLower())
            //{
            //    case nameof(System.String):
            //        return true;
            //    case nameof(System.Int32):
            //        return true;
            //    case nameof(System.Double):
            //        return true;
            //    default:
            //        return false;
            //}

            return true;
        }

        public void Cmd_Render<T>(T _Item,int k, RenderTreeBuilder builder)
        {
            object _value;
            string _attrName = string.Empty;

            builder.OpenElement(k++, _Item.GetType().Name);
            Console.WriteLine("open " + _Item.GetType().Name);

            foreach (PropertyInfo pi in _Item.GetType().GetProperties().Where(x=> !x.PropertyType.Name.Contains("ICollection")))
            {
                Console.WriteLine("11prop name - " + pi.Name +" ; type- " + pi.PropertyType.Name + " isclass = "+ pi.PropertyType.IsClass.ToString());
                _value = pi.GetValue(_Item, null);
                _attrName = pi.Name;

                if (_value != null && !string.IsNullOrEmpty(_value.ToString()))
                {
                    if (_attrName.Equals("content"))
                    {
                        builder.AddContent(k++, _value.ToString());
                    }
                    else
                    {
                        if (_attrName.Contains("_"))
                        {
                            _attrName = _attrName.Replace("_", "-");
                        }

                        //if (_attrName.Contains("99"))
                        //{
                        //    _attrName = _attrName.Replace("99", ":");
                        //}

                        builder.AddAttribute(k++, _attrName, _value.ToString());
                        Console.WriteLine("set attribute - " + _attrName + " = " + _value.ToString());
                    }
                    
                }
            }


            PropertyInfo pi_Children = _Item.GetType().GetProperty("Children");

            if (pi_Children != null)
            {
                List<object> children = pi_Children.GetValue(_Item) as List<object>;

                foreach (object item in children)
                {
                    Cmd_Render(item, k, builder);
                }
            }

            builder.CloseElement();
            Console.WriteLine("close element " + _Item.GetType().Name.ToLower());
        }


        public void Dispose()
        {
          
        }


        

    }
}
