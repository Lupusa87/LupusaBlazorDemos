using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClockSvgComponent.Classes
{
    public class TransferParameters
    {

        /// <summary>
        /// interval
        /// </summary>
        public double interval { get; set; }


        /// <summary>
        /// this value will be added to date as second on each iteration to achieve times fast going
        /// </summary>
        public double fastModeIncrement { get; set; }




        public TransferParameters(double _interval, double _fastModeIncrement)
        {
            interval = _interval;
            fastModeIncrement = _fastModeIncrement;
        }

    }
}
