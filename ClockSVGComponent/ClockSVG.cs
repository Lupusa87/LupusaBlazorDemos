using BlazorSvgHelper;
using BlazorSvgHelper.Classes;
using BlazorSvgHelper.Classes.SubClasses;
using ClockSVGComponent.Classes;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.RenderTree;
using System;
using System.Text;


namespace ClockSVGComponent
{
    public class ClockSVG : BlazorComponent
    {

   
            [Parameter]
            public double WidthAndHeight { get; set; }

            [Parameter]
            public int TimeDiff { get; set; }

            svg _Svg = null;

            string CurrentTime = string.Empty;


            protected override void BuildRenderTree(RenderTreeBuilder builder)
            {
                ClockSettings.radius_2_Times = WidthAndHeight;
                ClockSettings.radius_Origin = WidthAndHeight / 2;
                ClockSettings.radius_90_Percent = ClockSettings.radius_Origin * 0.9;


                
                SvgHelper.Cmd_Render(_Svg, 0, builder);

                if (ClockSettings.FastMode)
                {

                    JsInterop2.Run(new TransferParameters(ClockSettings.timerInterval, ClockSettings.FastMode_Increment));
                }
                else
                {
                    JsInterop2.Run(new TransferParameters(ClockSettings.timerInterval, 0));
                }
            }


            public void Generate_Clock_SVG()
            {
                _Svg = new svg
                {
                    id = "svgclock",
                    width = ClockSettings.radius_2_Times,
                    height = ClockSettings.radius_2_Times,
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
                });

                _radialGradient.Children.Add(new stop
                {
                    stop_color = "LightSkyBlue",
                    offset = "1",
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

                });

                _radialGradient2.Children.Add(new stop
                {
                    stop_color = "wheat",
                    offset = "1",
                    stop_opacity = "0.8",
                });

                _defs1.Children.Add(_radialGradient2);


                radialGradient _radialGradient3 = new radialGradient
                {
                    id = "grad3",
                    //cx = "50%",
                    //cy = "50%",
                    //r = "55%",
                    //fx = "50%",
                    //fy = "50%",
                    //fr = "44%",
                };



                _radialGradient3.Children.Add(new stop
                {
                    stop_color = "wheat",
                    offset = "0",
                });

                _radialGradient3.Children.Add(new stop
                {
                    stop_color = "DarkSlateBlue",
                    offset = "1",
                });

                _defs1.Children.Add(_radialGradient3);


                radialGradient _radialGradient4 = new radialGradient
                {
                    id = "grad4",
                    //cx = "50%",
                    //cy = "50%",
                    //r = "55%",
                    //fx = "50%",
                    //fy = "50%",
                    //fr = "44%",
                };



                _radialGradient4.Children.Add(new stop
                {
                    stop_color = "white",
                    offset = "0",
                });

                _radialGradient4.Children.Add(new stop
                {
                    stop_color = "lightblue",
                    offset = "1",
                });

                _defs1.Children.Add(_radialGradient4);


                radialGradient _radialGradient5 = new radialGradient
                {
                    id = "grad5",
                    //cx = "50%",
                    //cy = "50%",
                    //r = "55%",
                    //fx = "50%",
                    //fy = "50%",
                    //fr = "44%",
                };



                _radialGradient5.Children.Add(new stop
                {
                    stop_color = "white",
                    offset = "0",
                });

                _radialGradient5.Children.Add(new stop
                {
                    stop_color = "yellow",
                    offset = "1",
                });

                _defs1.Children.Add(_radialGradient5);


                radialGradient _radialGradient6 = new radialGradient
                {
                    id = "grad6",
                    //cx = "50%",
                    //cy = "50%",
                    //r = "55%",
                    //fx = "50%",
                    //fy = "50%",
                    //fr = "44%",
                };



                _radialGradient6.Children.Add(new stop
                {
                    stop_color = "white",
                    offset = "0",
                });

                _radialGradient6.Children.Add(new stop
                {
                    stop_color = "green",
                    offset = "1",
                });

                _defs1.Children.Add(_radialGradient6);

                _Svg.Children.Add(_defs1);


                _Svg.Children.Add(new rect
                {
                    width = ClockSettings.radius_2_Times,
                    height = ClockSettings.radius_2_Times,
                    fill = "wheat",
                    stroke = "url(#grad1)",
                    stroke_width = ClockSettings.radius_Origin * 0.01
                });



                image img1 = new image
                {
                    x = 0,
                    y = 0,
                    width = ClockSettings.radius_Origin * 0.6,
                    height = ClockSettings.radius_Origin * 0.6,
                    href = "content/1.png",
                    opacity = 0,
                };

                img1.Children.Add(new animate()
                {
                    attributeName = "opacity",
                    attributeType = "xml",
                    from = 0,
                    to = 1,
                    dur = 2,
                    repeatCount = "1",
                    fill = "freeze",
                });

                _Svg.Children.Add(img1);


                double wh = ClockSettings.radius_Origin * 0.6;
                double wh2 = wh / 2;

                double x1 = ClockSettings.radius_2_Times - wh;
                double y1 = ClockSettings.radius_2_Times - wh;

                image img2 = new image
                {
                    x = 0,
                    y = 0,
                    width = wh,
                    height = wh,
                    href = ClockSettings.Image_Url,
                    transform = "translate (" + x1 + "," + 0 + ") rotate(" + 90 + ", " + wh2 + "," + wh2 + ")",
                };


                img2.Children.Add(new animate()
                {
                    attributeName = "opacity",
                    attributeType = "xml",
                    from = 0,
                    to = 1,
                    dur = 2,
                    repeatCount = "1",
                    fill = "freeze",
                });


                _Svg.Children.Add(img2);

                image img3 = new image
                {
                    x = 0,
                    y = 0,
                    width = wh,
                    height = wh,
                    href = ClockSettings.Image_Url,
                    transform = "translate (" + x1 + "," + y1 + ") rotate(" + 180 + ", " + wh2 + "," + wh2 + ")",
                };

                img3.Children.Add(new animate()
                {
                    attributeName = "opacity",
                    attributeType = "xml",
                    from = 0,
                    to = 1,
                    dur = 2,
                    repeatCount = "1",
                    fill = "freeze",
                });


                _Svg.Children.Add(img3);

                image img4 = new image
                {
                    x = 0,
                    y = 0,
                    width = wh,
                    height = wh,
                    href = ClockSettings.Image_Url,
                    transform = "translate (" + 0 + "," + y1 + ") rotate(" + 270 + ", " + wh2 + "," + wh2 + ")",
                };

                img4.Children.Add(new animate()
                {
                    attributeName = "opacity",
                    attributeType = "xml",
                    from = 0,
                    to = 1,
                    dur = 2,
                    repeatCount = "1",
                    fill = "freeze",
                });


                _Svg.Children.Add(img4);


                _Svg.Children.Add(new circle
                {
                    cx = 0,
                    cy = 0,
                    r = ClockSettings.radius_90_Percent,
                    stroke = "url(#grad2)",
                    stroke_width = ClockSettings.radius_Origin * 0.06,
                    fill = "Gainsboro",
                    transform = "translate(" + ClockSettings.radius_Origin + "," + ClockSettings.radius_Origin + ")",
                });


                _Svg.Children.Add(new circle
                {
                    cx = 0,
                    cy = 0,
                    r = ClockSettings.radius_90_Percent * 0.9,
                    fill = "wheat",
                    transform = "translate(" + ClockSettings.radius_Origin + "," + ClockSettings.radius_Origin + ")",
                    stroke = "DarkSlateBlue",
                    stroke_width = ClockSettings.radius_90_Percent * 0.01,

                });





                _Svg.Children.Add(cmd_Draw_60_Lines());



                cmd_drawTime();


                _Svg.Children.Add(new circle
                {
                    cx = 0,
                    cy = 0,
                    r = ClockSettings.radius_90_Percent * 0.085,
                    fill = "url(#grad3)",
                    transform = "translate(" + ClockSettings.radius_Origin + "," + ClockSettings.radius_Origin + ")",
                });

                
            }




            public void cmd_drawTime()
            {

                double AnimationDurationCorrection = 1;

                if (ClockSettings.FastMode)
                {
                    if (!ClockSettings.SecondOnlyOneStep)
                    {
                        if (ClockSettings.timerInterval != 1000)
                        {
                            AnimationDurationCorrection = 0.001 * ClockSettings.timerInterval;
                        }
                    }
                }



                DateTime now = DateTime.Now.AddHours(TimeDiff);



                CurrentTime = now.ToString(@"hh:mm:ss");

                if (ClockSettings.FastMode && !ClockSettings.SecondOnlyOneStep)
                {
                    now = now.AddSeconds(ClockSettings.currentCount);
                }


                double hour = now.Hour % 12;
                double minute = now.Minute;


                double second = now.Second;


                if (!ClockSettings.SecondOnlyOneStep)
                {
                    second += now.Millisecond / 1000.0;

                }

                hour = (hour + minute / 60.0) * 5;


                minute = minute + second / 60;

                _Svg.Children.Add(drawGauge(second, "url(#grad4)", ClockSettings.Second_Hand_Lenght, "GaugeSecond"));
                _Svg.Children.Add(drawGauge(minute, "url(#grad5)", ClockSettings.Minute_Hand_Lenght * 1.03, "GaugeMinute"));
                _Svg.Children.Add(drawGauge(hour, "url(#grad6)", ClockSettings.Hour_Hand_Lenght * 1.08, "GaugeHour"));

                cmd_draw_Numbers(second);



                drawHand(hour,
                    ClockSettings.radius_90_Percent * ClockSettings.Hour_Hand_Lenght,
                    ClockSettings.Clock_Center_Small_Point_Color,
                    ClockSettings.radius_90_Percent * 0.05,
                    1.042,
                    1,
                    43200 * AnimationDurationCorrection);




                drawHand(minute,
                    ClockSettings.radius_90_Percent * ClockSettings.Minute_Hand_Lenght,
                    ClockSettings.Clock_Center_Small_Point_Color,
                    ClockSettings.radius_90_Percent * 0.04,
                    1.041,
                    1,
                    3600 * AnimationDurationCorrection);




                cmd_draw_Second_Shadow_Lines(second, 60 * AnimationDurationCorrection);

                drawHand(second,
                    ClockSettings.radius_90_Percent * ClockSettings.Second_Hand_Lenght,
                    ClockSettings.Clock_Second_Arrow_Color,
                    ClockSettings.radius_90_Percent * 0.02,
                    1.04,
                    1.5,
                    60 * AnimationDurationCorrection);


            }


            public void cmd_draw_Second_Shadow_Lines(double second, double animationDuration)
            {



                double s = 0;

                int k = 6;

                double opacity = 1.0;

                double lenght = ClockSettings.radius_90_Percent * ClockSettings.Second_Hand_Lenght;





                for (int i = k; i > 0; i--)
                {

                    s = second - i;

                    if (s < 0)
                    {
                        s = s + 60;
                    }


                    opacity = Math.Round((1.0 / (k + 2) * (k - i)), 2);


                    drawHandEnd(s,
                                 lenght,
                                 k - i,
                                 ClockSettings.Clock_Second_Arrow_Color,
                                 ClockSettings.radius_90_Percent * 0.01,
                                 opacity,
                                 animationDuration);

                    s = 0;
                }





            }


            void drawHand(double pos,
                            double length,
                            string color,
                            double Line_Width,
                            double satelite_Pos,
                            double satelite_R,
                            double animationDuration)
            {




                pos = pos * 6;

                //MyPoint p = GetPoint(pos, length);


                //_Svg.Children.Add(new line()
                //{
                //    x1 = ClockSettings.radius_Origin,
                //    y1 = ClockSettings.radius_Origin,
                //    x2 = p.x,
                //    y2 = p.y,
                //    opacity = 1,
                //    stroke = color,
                //    stroke_width = Line_Width,
                //    stroke_linecap = strokeLinecap.round,
                //});



                pos = pos - 90;
                line l = new line()
                {
                    x1 = 0,
                    y1 = 0,
                    x2 = length,
                    y2 = 0,
                    opacity = 1,
                    stroke = color,
                    stroke_width = Line_Width,
                    stroke_linecap = strokeLinecap.round,
                    transform = "translate (" + ClockSettings.radius_Origin + "," + ClockSettings.radius_Origin + ") rotate(" + pos + ")"
                };

                l.Children.Add(new animateTransform()
                {
                    attributeName = "transform",
                    attributeType = "xml",
                    by = 360,
                    dur = animationDuration,
                    repeatCount = "indefinite",
                    type = "rotate",

                });

                _Svg.Children.Add(l);

                //MyPoint p2 = GetPoint(pos, ClockSettings.radius_90_Percent * satelite_Pos);


                //_Svg.Children.Add(new circle()
                //{
                //    cx =p2.x,
                //    cy= p2.y,
                //    r = Line_Width/2 * satelite_R,
                //    fill = color,
                //});





                circle c = new circle()
                {
                    cx = ClockSettings.radius_90_Percent * satelite_Pos,
                    cy = 0,
                    r = Line_Width / 2 * satelite_R,
                    fill = color,
                    transform = "translate (" + ClockSettings.radius_Origin + "," + ClockSettings.radius_Origin + ") rotate(" + pos + ")"
                };

                c.Children.Add(new animateTransform()
                {
                    attributeName = "transform",
                    attributeType = "xml",
                    by = 360,
                    dur = animationDuration,
                    repeatCount = "indefinite",
                    type = "rotate",

                });

                _Svg.Children.Add(c);



            }

            void drawHandEnd(double pos, double length, double q, string color, double Line_Width, double _opacity, double animationDuration)
            {
                pos = pos * 6;

                //MyPoint p1 = GetPoint(pos, length - length * q * 0.07);
                //MyPoint p2 = GetPoint(pos, length);

                //line result =new line()
                //{
                //    x1 = p1.x,
                //    y1 = p1.y,
                //    x2 = p2.x,
                //    y2 = p2.y,
                //    opacity = _opacity,
                //    stroke = color,
                //    stroke_width = Line_Width,
                //    stroke_linecap = strokeLinecap.round,
                //};



                //MyPoint p1 = GetPoint(pos, length - length * q * 0.07);
                //MyPoint p2 = GetPoint(pos, length);

                pos = pos - 90;
                line l = new line()
                {
                    x1 = length - length * q * 0.07,
                    y1 = 0,
                    x2 = length,
                    y2 = 0,
                    opacity = _opacity,
                    stroke = color,
                    stroke_width = Line_Width,
                    stroke_linecap = strokeLinecap.round,
                    transform = "translate (" + ClockSettings.radius_Origin + "," + ClockSettings.radius_Origin + ") rotate(" + pos + ")",
                };


                l.Children.Add(new animateTransform()
                {
                    attributeName = "transform",
                    attributeType = "xml",
                    by = 360,
                    dur = animationDuration,
                    repeatCount = "indefinite",
                    type = "rotate",

                });

                _Svg.Children.Add(l);



            }



            private void cmd_draw_Numbers(double second)
            {

                double _font_Size = ClockSettings.radius_90_Percent * 0.15;
                double _opacity = 1;
                bool _font_Bold = false;


                g result = new g()
                {
                    font_family = "arial",
                };

                string a = string.Empty;

                double ang;

                double r = ClockSettings.radius_90_Percent * 0.8;

                double c = second / 5.0;




                for (int num = 0; num < 12; num++)
                {

                    if (Math.Abs(c - num) < 0.3)
                    {
                        _opacity = 1;

                        _font_Size = ClockSettings.radius_90_Percent * 0.20;


                        if (num % 3 == 0)
                        {
                            _font_Bold = true;
                            _font_Size = ClockSettings.radius_90_Percent * 0.25;
                        }
                    }
                    else
                    {
                        _opacity = 0.7;

                        _font_Size = ClockSettings.radius_90_Percent * 0.15;


                        if (num % 3 == 0)
                        {
                            _font_Bold = true;
                            _font_Size = ClockSettings.radius_90_Percent * 0.2;
                        }

                    }


                    ang = num * 30;


                    if (num == 0)
                    {
                        a = "12";
                    }
                    else
                    {
                        a = num.ToString();
                    }





                    MyPoint p = GetPoint(ang, r);

                    text t = new text()
                    {
                        id = "Number" + a,
                        x = p.x,
                        y = p.y,
                        content = a,
                        opacity = _opacity,
                        font_size = _font_Size,
                        font_weight = _font_Bold ? "bold" : "normal",
                        text_anchor = "middle",
                        dominant_baseline = "middle",
                        transform_origin = "center",
                        fill = ClockSettings.Clock_Center_Small_Point_Color,
                    };

                    //t.Children.Add(new animateTransform()
                    //{
                    //    attributeName = "transform",
                    //    attributeType = "xml",
                    //    values = "1;1.1;1.1;1",
                    //    keyTimes = "0;0.2;0.8;1",
                    //    dur = 3,
                    //    type = "scale",
                    //    id = "ScaleNumber" + a,
                    //    repeatCount = "indefinite",
                    //});

                    //t.Children.Add(new animate()
                    //{
                    //    attributeName = "font-size",
                    //    attributeType = "xml",
                    //    values = _font_Size + ";" + (_font_Size * 1.2) + ";" + _font_Size,
                    //    //   keyTimes = "0;0.2;1",
                    //    dur = 3,
                    //    id = "fontSizeNumber" + a,
                    //    repeatCount = "indefinite",
                    //});
                    //t.Children.Add(new animate()
                    //{
                    //    attributeName = "opacity",
                    //    attributeType = "xml",
                    //    values = _opacity + ";1;1;" + _opacity,
                    //    //   keyTimes = "0;0.2;0.8;1",
                    //    dur = 3,
                    //    id = "OpacityNumber" + a,
                    //    repeatCount = "indefinite",
                    //});

                    result.Children.Add(t);


                }

                _Svg.Children.Add(result);
            }




            private path drawGauge(double angle, string color, double r, string Gauge_ID)
            {

                double _opacity = angle / 60;




                angle = angle * 6;
                r = r * ClockSettings.radius_90_Percent;


                //https://stackoverflow.com/questions/5736398/how-to-calculate-the-svg-path-for-an-arc-of-a-circle
                //https://www.w3.org/TR/SVG2/paths.html#PathDataEllipticalArcCommands
                double l = ClockSettings.radius_Origin - r;
                MyPoint p = GetPoint(angle, r);


                StringBuilder sb = new StringBuilder();
                sb.Append("M");
                sb.Append(ClockSettings.radius_Origin);
                sb.Append(" ");
                sb.Append(ClockSettings.radius_Origin);
                sb.Append(" ");
                sb.Append("L");
                sb.Append(ClockSettings.radius_Origin);
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

                sb.Append(" ");
                sb.Append("Z");



                return new path()
                {
                    id = Gauge_ID,
                    fill = color,
                    d = sb.ToString(),
                    opacity = _opacity,
                };

            }



            private MyPoint GetPoint(double angle, double r, bool FromCenter = true)
            {
                double radians = (angle - 90) * (Math.PI / 180);

                if (FromCenter)
                {
                    return new MyPoint()
                    {
                        x = ClockSettings.radius_Origin + r * Math.Cos(radians),
                        y = ClockSettings.radius_Origin + r * Math.Sin(radians),
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


            private g cmd_Draw_60_Lines()
            {

                ClockSettings.radius_90_Percent = ClockSettings.radius_90_Percent * 0.9;
                double _strokeWidth = ClockSettings.radius_90_Percent * 0.01;
                double _opacity = 1;

                g result = new g()
                {
                    stroke = "DarkSlateBlue",
                    stroke_width = _strokeWidth,
                };




                double k = 0;

                double _x1 = 0;
                for (int i = 1; i <= 60; i++)
                {

                    if (i % 5 == 0)
                    {
                        if (i % 15 == 0)
                        {
                            _strokeWidth = ClockSettings.radius_90_Percent * 0.02;
                            _opacity = 1.0;
                            _x1 = ClockSettings.radius_90_Percent * 0.92;
                            k = ClockSettings.radius_90_Percent * 0.007;
                        }
                        else
                        {
                            _strokeWidth = ClockSettings.radius_90_Percent * 0.015;
                            _opacity = 0.8;
                            _x1 = ClockSettings.radius_90_Percent * 0.935;
                            k = ClockSettings.radius_90_Percent * 0.005;
                        }
                    }
                    else
                    {
                        _strokeWidth = ClockSettings.radius_90_Percent * 0.01;
                        _opacity = 0.7;
                        _x1 = ClockSettings.radius_90_Percent * 0.95;
                        k = 0;
                    }



                    result.Children.Add(new line()
                    {
                        x1 = _x1,
                        y1 = 0,
                        x2 = ClockSettings.radius_90_Percent + k,
                        y2 = 0,
                        opacity = _opacity,
                        stroke_width = _strokeWidth,
                        transform = "translate (" + ClockSettings.radius_Origin + "," + ClockSettings.radius_Origin + ") rotate(" + i * 6 + ", " + 0 + "," + 0 + ")",
                    });

                }

                return result;
            }

            public void Dispose()
            {

            }

    }
}
