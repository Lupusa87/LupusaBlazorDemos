using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorGameSnakeComponent.Astar;


namespace BlazorGameSnakeComponent.Classes
{
    public static class Game
    {

        public static Timer timer;


        public static bool Is_Bot_Mode=false;
        public static bool Is_Found_Right_Path;
        public static List<MyPoint> Right_Path;
        public static int Recursion_Counter;
        public static int x_Length = 44;
        public static int y_Length = 24;
        public static int points_Count;
        public static double point_Width;
        public static double point_Height;
        public static bool Is_Started = false;
        public static bool Is_Enabled = false;
        public static List<Snake_Element> SnakeElements;
        public static bool Are_Borders_Open = true;
        public static MyPoint target_position;
        public static bool Is_Enabled_Audio = true;

        public static void move_to_direction()
        {
            MyPoint new_point;
            MyPoint old_point;

            Snake_Element Main_element = SnakeElements.Where(x => x.Is_Main).ToList()[0];

            new_point = MyFunctions.Clone_MyPoint(Main_element.Point);
            old_point = MyFunctions.Clone_MyPoint(Main_element.Point);

            if (Is_Bot_Mode)
            {
                if (Right_Path.Count  > 0)
                {
                   
                    new_point.x = Right_Path[0].x;
                    new_point.y = Right_Path[0].y;
                    Right_Path.Remove(Right_Path[0]);
                  
                }
                else
                {
                  throw new Exception("error expected right path element but not found!");
                }
            }
            else
            {


                switch (LocalData.Curr_Direction)
                {
                    case DirectionType.Down:
                        if (new_point.y < y_Length - 1)
                        {
                            new_point.y+= 1;
                        }
                        else
                        {
                            if (Are_Borders_Open)
                            {
                                new_point.y = 0;
                            }
                            else
                            {
                                Game_Over();
                                return;
                            }
                        }
                        break;
                    case DirectionType.Up:
                        if (new_point.y >= 1)
                        {
                            new_point.y-=1;
                        }
                        else
                        {
                            if (Are_Borders_Open)
                            {
                                new_point.y = y_Length - 1;
                            }
                            else
                            {
                                Game_Over();
                                return;
                            }
                        }
                        break;
                    case DirectionType.Right:
                        if (new_point.x < x_Length - 1)
                        {
                            new_point.x+= 1;
                        }
                        else
                        {
                            if (Are_Borders_Open)
                            {
                                new_point.x = 0;
                            }
                            else
                            {
                                Game_Over();
                                return;
                            }
                        }
                        break;
                    case DirectionType.Left:
                        if (new_point.x >= 1)
                        {
                            new_point.x-= 1;
                        }
                        else
                        {
                            if (Are_Borders_Open)
                            {
                                new_point.x = x_Length - 1;
                            }
                            else
                            {
                                Game_Over();
                                return;
                            }
                        }
                        break;

                    default:
                        break;
                }
            }



           
            switch (Board.Matrix[new_point.x,new_point.y].MyValue)
            {
                case MyValueType.free:
                  
                    Board.Matrix[SnakeElements[0].Point.x,SnakeElements[0].Point.y].MyValue = MyValueType.free;
                    Main_element.Is_Main = false;
                    SnakeElements.RemoveAt(0);
                    SnakeElements.Add(new Snake_Element { Point = new_point, Is_Main = true });
                    Board.Matrix[new_point.x,new_point.y].MyValue = MyValueType.snake;
                    break;
                case MyValueType.snake:
                    Game_Over();
                    break;
                case MyValueType.target:
                    if (Is_Enabled_Audio)
                    {
                        SoundEffect.take_target.play();
                    }
                    Board.Matrix[SnakeElements[0].Point.x,SnakeElements[0].Point.y].MyValue = MyValueType.free;
                    Main_element.Is_Main = false;
                    Board.Matrix[old_point.x,old_point.y].MyValue = MyValueType.snake;
                    Board.Matrix[new_point.x,new_point.y].MyValue = MyValueType.snake;
                    SnakeElements.Add(new Snake_Element{ Point = new_point, Is_Main = true });
                    Board.Matrix[new_point.x,new_point.y].MyValue = MyValueType.snake;

                    paint_Random_Target();
                    paint_Score();

                    if (Is_Bot_Mode)
                    {
                        Find_Right_Path();
                    }

                    break;
                case MyValueType.wall:
                    Game_Over();
                    break;
                default:

                    break;
            }
        }


        public static void Find_Right_Path()
        {

            MyPathNode[,] grid = new MyPathNode[x_Length, y_Length];
            bool isWall = false;
            for (var index_x = 0; index_x < x_Length; index_x++)
            {

                for (var index_y = 0; index_y < y_Length; index_y++)
                {
                    isWall = false;
                    switch (Board.Matrix[index_x, index_y].MyValue)
                    {
                        case MyValueType.snake:
                            isWall = true;
                            break;
                        case MyValueType.wall:
                            isWall = true;
                            break;
                        default:
                            break;
                    }

                    grid[index_x, index_y] = new MyPathNode()
                    {
                        IsWall = isWall,
                        X = index_x,
                        Y = index_y,
                    };
                }

            }

            Snake_Element Main_element = SnakeElements.Where(x => x.Is_Main).ToList()[0];

            MySolver<MyPathNode, Object> aStar = new MySolver<MyPathNode, object>(grid);

            LinkedList<MyPathNode> path = aStar.Search(new Point(Main_element.Point.x, Main_element.Point.y),
               new Point(target_position.x, target_position.y), null);

            if (path == null)
            {
                Game_Over();
                
            }
            else
            {
                if (path.Count == 0)
                {

                    Game_Over();

                }
            }


            foreach (var item in path)
            {
                Right_Path.Add(new MyPoint(item.X, item.Y));
            }

            

            Right_Path.RemoveAt(0);

        }

        

        public static void Game_Over()
        {
            if (Is_Enabled_Audio)
            {
                SoundEffect.bg_sound.pause();
                SoundEffect.game_over.play();
            }

            timer.Dispose();
            BGSnakeCJsInterop.Alert("Game Over");
        }

        public static Board_Element get_Free_Point()
        {
            Board_Element result = new Board_Element();

            bool b = false;

            for (var index = 0; index < points_Count * 10; index++)
            {
                result = Board.Matrix[MyFunctions.get_Random_Int(0, x_Length - 1), MyFunctions.get_Random_Int(0, y_Length - 1)];
                if (result.MyValue == MyValueType.free)
                {

                    if (check_if_one_of_neighbors_if_free(result.Point.x, result.Point.y))
                    {
                        b = true;
                        break;
                    }
                }
            }

            if (!b)
            {
                BGSnakeCJsInterop.Alert("Can't find free point!!!");
            }

            return result;
        }

        public static bool check_if_one_of_neighbors_if_free(int par_x, int par_y)
        {
            bool result = false;
            //left
            if (par_x > 0)
            {
                if (Board.Matrix[par_x-1, par_y].MyValue == MyValueType.free)
                {
                    return true;
                }
            }

            //right
            if (par_x < x_Length - 2)
            {
                if (Board.Matrix[par_x +1, par_y].MyValue == MyValueType.free)
                {
                    return true;
                }
            }

            //up
            if (par_y > 0)
            {
                if (Board.Matrix[par_x,par_y -1].MyValue == MyValueType.free)
                {
                    return true;
                }
            }
            //down
            if (par_y < y_Length - 2)
            {
                if (Board.Matrix[par_x,par_y + 1].MyValue == MyValueType.free)
                {
                    return true;
                }
            }

            return result;

        }

        public static void paint_Random_Target()
        {

            Board_Element free_Board_Element = get_Free_Point();

            Board.Matrix[free_Board_Element.Point.x,free_Board_Element.Point.y].MyValue = MyValueType.target;
            target_position = new MyPoint( free_Board_Element.Point.x, free_Board_Element.Point.y);

        }



        public static void reset()
        {
            Is_Enabled = false;
            Is_Started = false;

            Right_Path = new List<MyPoint>();

            Board.initialize_Matrix();

            Board.generate_walls();

            paint_Random_Target();

           
            paint_Score();

            LocalData.Curr_Direction = DirectionType.empty;

            SnakeElements = new List<Snake_Element>();

            Board_Element Free_Board_Element = get_Free_Point();

            Board.Matrix[Free_Board_Element.Point.x,Free_Board_Element.Point.y].MyValue = MyValueType.snake;

            SnakeElements.Add(new Snake_Element {
                Point = new MyPoint(Free_Board_Element.Point.x,Free_Board_Element.Point.y),
                Is_Main = true });


            if (Is_Bot_Mode)
            {
                Find_Right_Path();
            }

            
            Is_Enabled = true;

            if (Is_Bot_Mode)
            {
                start();
            }
        }

        public static void start()
        {
            if (Is_Enabled_Audio)
            {
                SoundEffect.bg_sound.play();
            }
            Is_Started = true;
           

            timer = new Timer(TimerCallback, null, 0, LocalData.global_speed);

            
        }


        public static void TimerCallback(Object stateInfo)
        {
            move_to_direction();
            LocalData.Curr_Comp_Board.Refresh();
        }


        public static void paint_Score()
        {

            if (LocalData.Curr_comp != null)
            {
                int q = SnakeElements.Count - 1;
                if (q < 0)
                {
                    q = 0;
                }
                LocalData.Curr_comp.CurrPoint = "Point " + q.ToString();
                LocalData.Curr_comp.Refresh();
            }



        }
    }

}
