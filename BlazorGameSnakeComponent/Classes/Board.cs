using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGameSnakeComponent.Classes
{
    public static class Board
    {

        public static List<wall> Walls_List = new List<wall>();

        public static Board_Element[,] Matrix = new Board_Element[1, 1];

        public static void initialize_Matrix()
        {

            Matrix = new Board_Element[Game.x_Length, Game.y_Length];


            for (var index_x = 0; index_x < Game.x_Length; index_x++)
            {
                for (var index_y = 0; index_y < Game.y_Length; index_y++)
                {
                    Matrix[index_x, index_y] = new Board_Element()
                    {
                        Point = new MyPoint(index_x,index_y),
                        MyValue = MyValueType.free
                    };
                }

            }

        }


        public static void generate_walls()
        {
            Walls_List = new List<wall>();

            for (var i = 0; i < LocalData.walls_count; i++)
            {
                wall new_wall = new wall();
                new_wall.startpoint = new MyPoint(0, 0);
                new_wall.lenght = MyFunctions.get_Random_Int(LocalData.walls_min_length, LocalData.walls_max_length);
                new_wall.direction = (DirectionType)MyFunctions.get_Random_Int(0, 3);



                if ((int)new_wall.direction > 1)
                {
                    new_wall.startpoint = new MyPoint(
                        MyFunctions.get_Random_Int(0, Game.x_Length - new_wall.lenght - 1),
                        MyFunctions.get_Random_Int(0, Game.y_Length - 1)
                    );


                    for (var index = new_wall.startpoint.x; index < new_wall.startpoint.x + new_wall.lenght; index++)
                    {
                        Matrix[index, new_wall.startpoint.y].MyValue = MyValueType.wall;
                    }
                }
                else
                {
                    new_wall.startpoint = new MyPoint(
                        MyFunctions.get_Random_Int(0, Game.x_Length - 1),
                        MyFunctions.get_Random_Int(0, Game.y_Length - new_wall.lenght - 1)
                    );


                    for (var index = new_wall.startpoint.y; index < new_wall.startpoint.y + new_wall.lenght; index++)
                    {
                        Matrix[new_wall.startpoint.x, index].MyValue = MyValueType.wall;
                    }
                }

                Walls_List.Add(new_wall);
            }

        }



        

    }
}
