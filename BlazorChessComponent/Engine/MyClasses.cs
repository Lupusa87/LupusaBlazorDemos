using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChessComponent.Engine
{

    
    public class myCell
    {
        public double width { get; set; } = 35;
        public double height { get; set; } = 35;
        public string white_color { get; set; } 
        public string black_color { get; set; } 

        public myCell(string P_white_color, string P_black_color)
        {
            white_color = P_white_color;
            black_color = P_black_color;
        }
    }

    public class myPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
       
    }


    public class myFigure
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int index { get; set; } = -1;
        public string kodi { get; set; } = string.Empty;
        public bool isDefined { get; set; } = false;
    }


    public class myColors
    {
        public string selected_cell { get; set; } = "yellow";
        public string potenciuri_svla { get; set; } = "green";
        public string paikis_gayvanis_charcho { get; set; } = "red";
        public string paikis_gayvanis_monishvna { get; set; } = "saddlebrown";
        public string moklulebis_foni { get; set; } = "lightyellow";
        public string moklulebis_charcho { get; set; } = "#FFA500";
        public string shaxi_an_garde { get; set; } = "red";
    }


    public class mylineWidths
    {
        public int selected_cell { get; set; } = 3;
        public int potenciuri_svla { get; set; } = 2;
        public int mtliani_charcho { get; set; } = 3;
        public int dafis_charcho { get; set; } = 3;
        public int paikis_gayvanis_charcho { get; set; } = 3;
        public int paikis_gayvanis_monishvna { get; set; } = 2;
       
        public int moklulebis_charcho { get; set; } = 3;
        public int shaxi_an_garde { get; set; } = 3;
    }


    }
