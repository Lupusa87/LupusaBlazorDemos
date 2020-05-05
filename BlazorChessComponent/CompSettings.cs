using BlazorSvgHelper.Classes.SubClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChessComponent
{
    public class CompSettings
    {
        public CompBlazorChess Curr_comp = null;
        public CompChildBoard Curr_Comp_Board = null;
        public CompChildShape Curr_Comp_Shape = null;
        public CompChildStat Curr_Comp_Stat = null;


        public List<rect> rects_list = new List<rect>();

        public List<string> Moves_list = new List<string>();

        public List<string> Log_list = new List<string>();


        public List<image> KilledFigures_list = new List<image>();

        public double CompWidth = 500.0;
        public double CompHeight = 500.0;

        public double BoardPositionX = 0;
        public double BoardPositionY = 0;
    }
}
