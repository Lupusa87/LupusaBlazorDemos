using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDoughnutChartComponent
{
    public static class MyGradient
    {

        private static List<Color> Colors_List = new List<Color>();



        static MyGradient()
        {

            GetGradientColors(Color.Red, Color.LightGreen);
        }

        public static void Initialize(string startColor, string endColor)
        {

            GetGradientColors(ColorConvertor.GetColorFromHex(startColor),
                ColorConvertor.GetColorFromHex(endColor));

        }


        public static string Get_Color(int Position)
        {
            Position -= 1;

            if (Position > -1 && Position < Colors_List.Count)
            {

                return "#" + ColorConvertor.ColorToHexString(Colors_List[Position]);

            }
            else
            {
                return "#FFFFFF";
            }

        }


       

        private static void GetGradientColors(Color start, Color end)
        {
            Colors_List = new List<Color>();


            int size = 100;

            for (int i = 0; i < size; i++)
            {
                var rAverage = start.R + (int)((end.R - start.R) * i / size);
                var gAverage = start.G + (int)((end.G - start.G) * i / size);
                var bAverage = start.B + (int)((end.B - start.B) * i / size);
                Colors_List.Add(Color.FromArgb(rAverage, gAverage, bAverage));
            }

        }


       



    }



    public class ColorConvertor
    {

        static char[] hexDigits = {
         '0', '1', '2', '3', '4', '5', '6', '7',
         '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
       

        public static string ColorToHexString(Color color)
        {
            byte[] bytes = new byte[3];
            bytes[0] = color.R;
            bytes[1] = color.G;
            bytes[2] = color.B;
            char[] chars = new char[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }
            return new string(chars);
        }


        public static Color GetColorFromHex(string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            if (hex.Length != 6) throw new Exception("Color not valid");

            return Color.FromArgb(
                int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));
        }

    }


}
