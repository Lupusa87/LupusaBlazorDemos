using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClockCanvasComponent.Classes
{
    public class TransferImageParameters
    {
   
        public float x { get; set; }


        public float y { get; set; }

      
        public float width { get; set; }

     
        public float height { get; set; }

        public TransferImageParameters(float _x, float _y, float _width, float _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
        }



    }


    public class TransferRadialGradientParameters
    {

        public float x0 { get; set; }


        public float y0 { get; set; }


        public float r0 { get; set; }

        public float x1 { get; set; }


        public float y1 { get; set; }


        public float r1 { get; set; }


    
        public TransferRadialGradientParameters(double _x0, double _y0, double _r0, double _x1, double _y1, double _r1)
        {
            x0 = (float)_x0;
            y0 = (float)_y0;
            r0 = (float)_r0;
            x1 = (float)_x1;
            y1 = (float)_y1;
            r1 = (float)_r1;
        }



    }


    public class TransferRectParameters
    {

        public float x { get; set; }


        public float y { get; set; }


        public float w { get; set; }

        public float h { get; set; }


        


        public TransferRectParameters(double _x, double _y, double _w, double _h)
        {
            x = (float)_x;
            y = (float)_y;
            w = (float)_w;
            h = (float)_h;
            
        }



    }
}
