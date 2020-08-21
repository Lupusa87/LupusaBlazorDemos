using BlazorWindowHelper;
using BlazorWindowHelper.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPasswordPatternComponent
{

    public partial class CompBlazorPassword: IDisposable
    {
        [Parameter]
        public double CompWidth { get; set; }

        [Parameter]
        public double CompHeight { get; set; }

        public string Password { get; set; } = string.Empty;

        public ChildLine ChildLine1 = new ChildLine();

        public Action PasswordUpdated;


        protected override void OnInitialized()
        {

           
            BWHJsInterop.SetOnOrOff(true);
            BWHKeyboardHelper.OnKeyUp += KeyUpFromJS;

            ComponentSettings.compWidth = CompWidth;
            ComponentSettings.compHeight = CompHeight;

            ComponentSettings.h = ComponentSettings.compWidth / ComponentSettings.CountHorizontal;

            ComponentSettings.w = ComponentSettings.compHeight / ComponentSettings.CountVertical;


            ComponentSettings.r = ComponentSettings.w;

            if (ComponentSettings.r > ComponentSettings.h)
            {
                ComponentSettings.r = ComponentSettings.h;
            }

            ComponentSettings.r /= 2;
            ComponentSettings.r *= 0.65;

            
        }

        protected override void OnAfterRender(bool firstRender)
        {
            UpdateLines();

            base.OnAfterRender(firstRender);
        }



        public void Dispose()
        {

        }

        public void UpdateLines()
        {
            if (ComponentSettings.SelectedCircles_List.Count > 1)
            {
                ChildLine1.Update();
            }
        }

        public void Clicked(string e)
        {
            if (!ComponentSettings.SelectedCircles_List.Any(x => x == e))
            {

                ComponentSettings.SelectedCircles_List.Add(e);
                
                UpdatePassword();
                
                StateHasChanged();
            }
        }


        public void Reset()
        {
            ComponentSettings.SelectedCircles_List = new List<string>();
            UpdatePassword();
            StateHasChanged();
        }


        public void UnselectLast()
        {
            if (ComponentSettings.SelectedCircles_List.Count > 0)
            {
                ComponentSettings.SelectedCircles_List.Remove(ComponentSettings.SelectedCircles_List.LastOrDefault());
            }
            UpdatePassword();
            StateHasChanged();
        }





        public void UpdatePassword()
        {
            Password = string.Empty;
            foreach (var item in ComponentSettings.SelectedCircles_List)
            {

                switch (item)
                {
                    case "00":
                        Password += "7";
                        break;
                    case "10":
                        Password += "8";
                        break;
                    case "20":
                        Password += "9";
                        break;
                    case "01":
                        Password += "4";
                        break;
                    case "11":
                        Password += "5";
                        break;
                    case "21":
                        Password += "6";
                        break;
                    case "02":
                        Password += "1";
                        break;
                    case "12":
                        Password += "2";
                        break;
                    case "22":
                        Password += "3";
                        break;
                    default:
                        break;
                }

               
            }

 
            PasswordUpdated?.Invoke();



        }




        public void KeyUpFromJS(BWHKeyboardState keyboardState)
        {

            switch (keyboardState.consoleKey)
            {
                case ConsoleKey.D0:
                    Reset();
                    break;
                case ConsoleKey.D1:
                    Clicked("02");
                    break;
                case ConsoleKey.D2:
                    Clicked("12");
                    break;
                case ConsoleKey.D3:
                    Clicked("22");
                    break;
                case ConsoleKey.D4:
                    Clicked("01");
                    break;
                case ConsoleKey.D5:
                    Clicked("11");
                    break;
                case ConsoleKey.D6:
                    Clicked("21");
                    break;
                case ConsoleKey.D7:
                    Clicked("00");
                    break;
                case ConsoleKey.D8:
                    Clicked("10");
                    break;
                case ConsoleKey.D9:
                    Clicked("20");
                    break;
                case ConsoleKey.NumPad0:
                    Reset();
                    break;
                case ConsoleKey.NumPad1:
                    Clicked("02");
                    break;
                case ConsoleKey.NumPad2:
                    Clicked("12");
                    break;
                case ConsoleKey.NumPad3:
                    Clicked("22");
                    break;
                case ConsoleKey.NumPad4:
                    Clicked("01");
                    break;
                case ConsoleKey.NumPad5:
                    Clicked("11");
                    break;
                case ConsoleKey.NumPad6:
                    Clicked("21");
                    break;
                case ConsoleKey.NumPad7:
                    Clicked("00");
                    break;
                case ConsoleKey.NumPad8:
                    Clicked("10");
                    break;
                case ConsoleKey.NumPad9:
                    Clicked("20");
                    break;
                case ConsoleKey.Escape:
                    Reset();
                    break;
                case ConsoleKey.Backspace:
                    UnselectLast();
                    break;
                default:
                    break;
            }
        }
    }



}
