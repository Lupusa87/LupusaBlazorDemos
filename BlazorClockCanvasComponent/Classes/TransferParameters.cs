using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClockCanvasComponent.Classes
{
    //https://www.w3schools.com/tags/canvas_arc.asp
    public class TransferParameters
    {
        /// <summary>
        /// The x-coordinate of the center of the circle
        /// </summary>
        public float x { get; set; }

        /// <summary>
        /// The y-coordinate of the center of the circle
        /// </summary>
        public float y { get; set; }

        /// <summary>
        /// The radius of the circle
        /// </summary>
        public float r { get; set; }

        /// <summary>
        /// The starting angle, in radians(0 is at the 3 o'clock position of the arc's circle)
        /// </summary>
        public float sAngle { get; set; }


        /// <summary>
        /// The ending angle, in radians
        /// </summary>
        public float eAngle { get; set; }
        

        public TransferParameters(float _x, float _y, float _r, float _sAngle, float _eAngle)
        {
            x = _x;
            y = _y;
            r = _r;
            sAngle = _sAngle;
            eAngle = _eAngle;
        }



    }
}
