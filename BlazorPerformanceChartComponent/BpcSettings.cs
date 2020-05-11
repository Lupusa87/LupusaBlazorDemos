using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BlazorPerformanceChartComponent
{
    public class BpcSettings: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string ConfigurationName { get; set; } = "config 1";

        private double _initialWidth { get; set; } = 800;
        public double InitialWidth
        {
            get
            {
                return _initialWidth;
            }
            set
            {
                _initialWidth = value;
                OnPropertyChanged();
            }
        }

        private double _extendedWidth { get; set; } = 800;
        public double ExtendedWidth
        {
            get
            {
                return _extendedWidth;
            }
            set
            {
                _extendedWidth = value;
                OnPropertyChanged();
            }
        }

        private double _InitialHeight { get; set; } = 400;
        public double InitialHeight { get
            {
                return _InitialHeight;
            }
            set
            {
                _InitialHeight = value;
                _extendedWidth = value;
                OnPropertyChanged();
            }
        }


        private double _stackHeight { get; set; } = 50;
        public double StackHeight
        {
            get
            {
                return _stackHeight;
            }
            set
            {
                _stackHeight = value;
                OnPropertyChanged();
            }
        }


        private double _stackWidth { get; set; }  = 30;
        public double StackWidth
        {
            get
            {
                return _stackWidth;
            }
            set
            {
                _stackWidth = value;
                OnPropertyChanged();
            }
        }

        private bool _drawStack { get; set; } = true;
        public bool DrawStack
        {
            get
            {
                return _drawStack;

            }
            set
            {
                _drawStack = value;
                OnPropertyChanged();
            }
        }


        private bool _drawPoints { get; set; } = true;
        public bool DrawPoints
        {
            get
            {
                return _drawPoints;

            }
            set
            {
                _drawPoints = value;
                OnPropertyChanged();
            }
        }


        private bool _drawArea { get; set; } = true;
        public bool DrawArea
        {
            get
            {
                return _drawArea;

            }
            set
            {
                _drawArea = value;
                OnPropertyChanged();
            }
        }


        private string _stackColor { get; set; }  = "#e6e6ff";
        public string StackColor
        {
            get
            {
                return _stackColor;

            }
            set
            {
                _stackColor = value;
                OnPropertyChanged();
            }
        }


        private string _areaColor { get; set; }  = "#c2c2f0";
        public string AreaColor
        {
            get
            {
                return _areaColor;

            }
            set
            {
                _areaColor = value;
                OnPropertyChanged();
            }
        }

        private string _lineColor { get; set; }  = "#3333cc";
        public string LineColor
        {
            get
            {
                return _lineColor;

            }
            set
            {
                _lineColor = value;
                OnPropertyChanged();
            }
        }

        private string _pointStroke { get; set; } = "#ff3300";
        public string PointStroke
        {
            get
            {
                return _pointStroke;

            }
            set
            {
                _pointStroke = value;
                OnPropertyChanged();
            }
        }


        private string _pointFill { get; set; } = "#ffff00";
        public string PointFill
        {
            get
            {
                return _pointFill;

            }
            set
            {
                _pointFill = value;
                OnPropertyChanged();
            }
        }


        private string _boardBorderColor { get; set; } = "#3333cc";
        public string BoardBorderColor
        {
            get
            {
                return _boardBorderColor;

            }
            set
            {
                _boardBorderColor = value;
                OnPropertyChanged();
            }
        }

        private string _boardBGColor { get; set; } = "#ffffe6";
        public string BoardBGColor
        {
            get
            {
                return _boardBGColor;

            }
            set
            {
                _boardBGColor = value;
                OnPropertyChanged();
            }
        }


        private double _stackLineWidth { get; set; } = 1;
        public double StackLineWidth
        {
            get
            {
                return _stackLineWidth;

            }
            set
            {
                _stackLineWidth = value;
                OnPropertyChanged();
            }
        }

        private double _lineWidth { get; set; } = 1;
        public double LineWidth
        {
            get
            {
                return _lineWidth;

            }
            set
            {
                _lineWidth = value;
                OnPropertyChanged();
            }
        }

        private double _boardBorderWidth { get; set; } = 3;
        public double BoardBorderWidth
        {
            get
            {
                return _boardBorderWidth;

            }
            set
            {
                _boardBorderWidth = value;
                OnPropertyChanged();
            }
        }

        private double _pointLineWidth { get; set; } = 2;
        public double PointLineWidth
        {
            get
            {
                return _pointLineWidth;

            }
            set
            {
                _pointLineWidth = value;
                OnPropertyChanged();
            }
        }

        private double _pointRadius { get; set; } = 5;
        public double PointRadius
        {
            get
            {
                return _pointRadius;

            }
            set
            {
                _pointRadius = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Invoke_PropertyChanged(string Par_PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Par_PropertyName));
        }

        public void Invoke_PropertyChanged_For_All()
        {
            foreach (PropertyInfo item in this.GetType().GetProperties())
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(item.Name));
            }
        }
    }
}
