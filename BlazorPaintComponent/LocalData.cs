using BlazorPaintComponent.classes;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPaintComponent
{
    public static class LocalData
    {

        public static MyPoint SVGPosition = new MyPoint(0, 0);

        [JSInvokable]
        public static void invokeFromjs_UpdateSVGPosition(string par_x, string par_y)
        {
            SVGPosition = new MyPoint(double.Parse(par_x), double.Parse(par_y));

        }

      
    }
}
