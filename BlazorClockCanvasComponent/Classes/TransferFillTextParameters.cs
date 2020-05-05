using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClockCanvasComponent.Classes
{
    public class TransferFillTextParameters
    {

        public string text { get; set; }

        public float x { get; set; }


       
        public float y { get; set; }


        public TransferFillTextParameters(string _text, float _x, float _y)
        {
            text = _text;
            x = _x;
            y = _y;
           
        }
    }
}
