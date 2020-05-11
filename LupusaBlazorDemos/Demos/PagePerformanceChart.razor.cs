using BlazorPerformanceChartComponent;
using BlazorPerformanceChartComponent.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Demos
{
    public partial class PagePerformanceChart
    {
        protected CompBlazorPerformanceChart BPChart1;

        protected string PcButton = "Continue";

        Random rnd1 = new Random();

        Timer timer1;

        Timer timer2;


        public int TimerSpeed = 1000;

        public List<MyChartPoint> Points_List = new List<MyChartPoint>();

        public BpcSettings ChartSettings1 = new BpcSettings();
    


        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {

                BPChart1.PointsList = Points_List;
            }


            base.OnAfterRender(firstRender);
        }


        protected override void OnInitialized()
        {
            timer2 = new Timer(Timer2Callback, null, 1, 1);

            ChartSettings1.PropertyChanged += ChartSettings1_PropertyChanged;

            Points_List = new List<MyChartPoint>();
            for (int i = 0; i < 10; i++)
            {
                GeneratePoint();
            }

            base.OnInitialized();
        }




        private void ChartSettings1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            BPChart1.Redraw();
        }


        public void GenerateRandomConfiguration()
        {
            BpcSettings b = new BpcSettings
            {
                ConfigurationName = "config_1",

                StackHeight = rnd1.Next(3, 7) * 10,
                StackWidth = rnd1.Next(2, 4) * 10,

                DrawStack = rnd1.Next(1, 5) < 4,
                DrawPoints = rnd1.Next(1, 5) < 4,
                DrawArea = rnd1.Next(1, 5) < 4,

                StackColor = GetRandomColor(),
                AreaColor = GetRandomColor(),
                LineColor = GetRandomColor(),
                PointStroke = GetRandomColor(),
                PointFill = GetRandomColor(),

                BoardBorderColor = GetRandomColor(),
                BoardBGColor = GetRandomColor(),

                StackLineWidth = rnd1.Next(1, 3),
                LineWidth = rnd1.Next(1, 3),
                BoardBorderWidth = rnd1.Next(2, 5),

                PointLineWidth = rnd1.Next(1, 3),
                PointRadius = rnd1.Next(3, 7),
            };

            b.PropertyChanged += ChartSettings1_PropertyChanged;


            ChartSettings1 = b;

            StateHasChanged();
            BPChart1.Redraw();

        }

        public string GetRandomColor()
        {
            return string.Format("#{0:X6}", rnd1.Next(0x1000000));
        }





        public void GeneratePoint()
        {
            MyChartPoint p = new MyChartPoint
            {
                Time = "aaa",
                Value = -1,
                Percentage = rnd1.Next(10, 100),
            };



            Points_List.Add(p);

        }

        public void PcReset()
        {
            Reset();

            if (PcButton != "Continue")
            {
                PcButton = "Continue";
                StateHasChanged();
            }
        }


        public void PcStart()
        {


            if (PcButton == "Continue")
            {


                Start();

                PcButton = "Pause";
            }
            else
            {

                Stop();
                PcButton = "Continue";
            }


        }




        public void Reset()
        {
            Stop();
            Points_List = new List<MyChartPoint>();
            BPChart1.PointsList = Points_List;
            StateHasChanged();
        }

        public void Start()
        {

            BPChart1.PointsList = Points_List;
            timer1 = new Timer(Timer1Callback, null, 0, TimerSpeed);

        }


        public void CmdOnIntervalChange()
        {

            if (PcButton == "Pause")
            {
                PcStart();
            }
        }



        public void Stop()
        {
            if (timer1 != null)
            {
                timer1.Dispose();
            }
        }


        public void Timer1Callback(object o)
        {


            GeneratePoint();
            BPChart1.PointsList = Points_List;
            //BPChart1.Redraw();


            StateHasChanged();




        }


        public void Timer2Callback(object o)
        {

            BPChart1.Redraw();
            timer2.Dispose();
        }
    }
}
