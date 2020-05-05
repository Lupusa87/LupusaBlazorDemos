using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChessComponent.Engine
{
    public static class MyFunctions
    {
        public static bool Get_Cell_Color_By_Index(int index)
        {
            // false = თეთრი უჯრა;
            // true = შავი უჯრა;

            bool result = false;

            result = index % 2 == 0;

            if (((index - index % 8) / 8) % 2 == 0)
            {
                result = !result;
            }

            return result;
        }


        public static bool is_lower_case(string p)
        {
            return "rkbqap".IndexOf(p) > -1;
        }


        public static string reverseMove(string input)
        {
            int k = 0;

            string[] Board_Array_Letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };

            string p1 = input.Substring(0, 1);
            k = Board_Array_Letters.ToList().IndexOf(p1);
            k = reverseNumber((k+2).ToString());
            p1 = Board_Array_Letters[k];


            string p2 = reverseNumber(input.Substring(1, 1)).ToString();

            string p3 = input.Substring(2, 1);
            k = Board_Array_Letters.ToList().IndexOf(p3);
            k = reverseNumber((k+2).ToString());
            p3 = Board_Array_Letters[k];



            string p4 = reverseNumber(input.Substring(3, 1)).ToString();


            return p1+ p2+ p3+ p4;
        }


        private static int reverseNumber(string input)
        {
            return 9 - int.Parse(input);
        }
        }
}
