using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGameSnakeComponent.Classes
{
    public static class MyFunctions
    {
        private static Random rnd1 = new Random();

        public static int get_Random_Int(int min, int max)
        {
            return rnd1.Next(min,max);
        }

        public static MyPoint Clone_MyPoint(MyPoint Par_Source)
        {
            return new MyPoint(Par_Source.x,Par_Source.y);
        }
    }
}
