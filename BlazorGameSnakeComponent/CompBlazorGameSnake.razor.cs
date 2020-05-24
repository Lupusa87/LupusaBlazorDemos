using BlazorGameSnakeComponent.Classes;
using BlazorWindowHelper;
using BlazorWindowHelper.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGameSnakeComponent
{
    public partial class CompBlazorGameSnake: IDisposable
    {

        bool IsPageLoaded = false;

     
        public bool input_Is_Bot_Mode
        {
            get
            {
                return Game.Is_Bot_Mode;
            }
            set
            {
                Game.Is_Bot_Mode = value;
                Console.WriteLine(Game.Is_Bot_Mode);
                run();
            }

        }



        public bool input_Is_Enable_Audio
        {

            get
            {
                return Game.Is_Enabled_Audio;
            }
            set
            {

                Game.Is_Enabled_Audio = value;
                run();

            }

        }




      
        public bool Are_Borders_Open
        {

            get
            {
                return Game.Are_Borders_Open;
            }


            set
            {
               
                Game.Are_Borders_Open = value;
                run();

            }

        }


        public int input_speed
        {

            get
            {
                return LocalData.global_speed;
            }


            set
            {

                LocalData.global_speed = value;
                run();

            }

        }


        public int input_X_Count
        {

            get
            {
                return Game.x_Length;
            }


            set
            {

                Game.x_Length = value;
                Game.y_Length = input_Y_Count;
                Game.points_Count = Game.x_Length * Game.y_Length;
                Game.point_Width = Math.Round(LocalData.CompWidth * 1.0 / Game.x_Length, 2);
                Game.point_Height = Math.Round(LocalData.CompHeight * 1.0 / Game.y_Length, 2);

                run();

            }

        }

      

        public int input_Y_Count
        {

            get
            {
                return Game.y_Length;
            }


            set
            {
                Game.y_Length = value;
                Game.points_Count = Game.x_Length * Game.y_Length;
                Game.point_Width = Math.Round(LocalData.CompWidth * 1.0 / Game.x_Length, 2);
                Game.point_Height = Math.Round(LocalData.CompHeight * 1.0 / Game.y_Length, 2);

                run();

            }

        }



        public int walls_count
        {
            get
            {
                return LocalData.walls_count;
            }
            set
            {
                LocalData.walls_count = value;
                run();
            }
        }

        public int walls_min_length
        {
            get
            {
                return LocalData.walls_min_length;
            }
            set
            {
                LocalData.walls_min_length = value;
                run();
            }
        }

        public int walls_max_length
        {
            get
            {
                return LocalData.walls_max_length;
            }
            set
            {
                LocalData.walls_max_length = value;
                run();
            }
        }


        public string CurrPoint = "Point 0";




        protected override void OnInitialized()
        {

            BWHJsInterop.SetOnOrOff(true);
            BWHKeyboardHelper.OnKeyDown = KeyDownFromJS;
            BWHKeyboardHelper.OnKeyUp = KeyUpFromJS;

            Game.points_Count = Game.x_Length * Game.y_Length;
            Game.point_Width = Math.Round(LocalData.CompWidth * 1.0 / Game.x_Length, 2);
            Game.point_Height = Math.Round(LocalData.CompHeight * 1.0 / Game.y_Length, 2);
            Game.reset();

            base.OnInitialized();
        }

        public void run()
        {

            if (IsPageLoaded)
            {
                Game.reset();
                StateHasChanged();
                LocalData.Curr_Comp_Board.Refresh();
                LocalData.Curr_Comp_Walls.Refresh();
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {

            LocalData.Curr_comp = this;

            base.OnAfterRender(firstRender);

            IsPageLoaded = true;
        }


        public void Refresh()
        {
            StateHasChanged();
        }


        public void input_X_Count_onchange()
        {
            run();

        }

        public void input_Y_Count_onchange()
        {
            run();
        }


        public void KeyDownFromJS(BWHKeyboardState keyboardState)
        {

            if (Game.Is_Enabled)
            {
                if (!Game.Is_Bot_Mode)
                {
                    

                    if (Game.Is_Started && keyboardState.ctrl && !Game.CtrlDoubleSpeed)
                    {
                        Game.CtrlDoubleSpeed = true;
                        
                        LocalData.global_speed /= 2;
                        Game.TimerReset();
                    }


                    if (Game.Is_Started && keyboardState.shift && !Game.ShiftHalfSpeed)
                    {
                        Game.ShiftHalfSpeed = true;

                        LocalData.global_speed *= 2;
                        Game.TimerReset();
                    }
                }
            }

        }

        public void KeyUpFromJS(BWHKeyboardState keyboardState)
        {
           
            if (Game.Is_Enabled)
            {
                if (!Game.Is_Bot_Mode)
                {
                    if (Game.Is_Started && !keyboardState.ctrl && Game.CtrlDoubleSpeed)
                    {
                        Game.CtrlDoubleSpeed = false;
                        LocalData.global_speed *= 2;
                        Game.TimerReset();
                    }


                    if (Game.Is_Started && !keyboardState.shift && Game.ShiftHalfSpeed)
                    {
                        Game.ShiftHalfSpeed = false;
                        LocalData.global_speed /= 2;
                        Game.TimerReset();
                    }

                    switch (keyboardState.consoleKey)
                    {

                        case ConsoleKey.DownArrow:
                            if (LocalData.Curr_Direction != DirectionType.Up)
                            {
                                LocalData.Curr_Direction = DirectionType.Down;
                            }
                            if (!Game.Is_Started)
                            {
                                Game.start();
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (LocalData.Curr_Direction != DirectionType.Left)
                            {
                                LocalData.Curr_Direction = DirectionType.Right;
                            }
                            if (!Game.Is_Started)
                            {
                                Game.start();
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (LocalData.Curr_Direction != DirectionType.Down)
                            {
                                LocalData.Curr_Direction = DirectionType.Up;
                            }
                            if (!Game.Is_Started)
                            {
                                Game.start();
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (LocalData.Curr_Direction != DirectionType.Right)
                            {
                                LocalData.Curr_Direction = DirectionType.Left;
                            }
                            if (!Game.Is_Started)
                            {
                                Game.start();
                            }
                            break;
                        default:
                            break;
                    }

                }
            }

        }


        protected void cmd_Move(DirectionType Par_Direction)
        {
            if (Game.Is_Enabled)
            {
                if (!Game.Is_Bot_Mode)
                {

                    switch (Par_Direction)
                    {

                        case DirectionType.Down:
                            if (LocalData.Curr_Direction != DirectionType.Up)
                            {
                                LocalData.Curr_Direction = DirectionType.Down;
                            }
                            if (!Game.Is_Started)
                            {
                                Game.start();
                            }
                            break;
                        case DirectionType.Right:
                            if (LocalData.Curr_Direction != DirectionType.Left)
                            {
                                LocalData.Curr_Direction = DirectionType.Right;
                            }
                            if (!Game.Is_Started)
                            {
                                Game.start();
                            }
                            break;
                        case DirectionType.Up:
                            if (LocalData.Curr_Direction != DirectionType.Down)
                            {
                                LocalData.Curr_Direction = DirectionType.Up;
                            }
                            if (!Game.Is_Started)
                            {
                                Game.start();
                            }
                            break;
                        case DirectionType.Left:
                            if (LocalData.Curr_Direction != DirectionType.Right)
                            {
                                LocalData.Curr_Direction = DirectionType.Left;
                            }
                            if (!Game.Is_Started)
                            {
                                Game.start();
                            }
                            break;
                        default:
                            break;
                    }

                }
            }
        }




        public void Dispose()
        {
            //BlazorWindowHelper.BWHJsInterop.Log("called dispose on gamesmake");

            SoundEffect.bg_sound.pause();
            Game.reset();
        }

    }
}
