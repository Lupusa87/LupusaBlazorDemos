using BlazorCalculatorComponent.Classes;
using BlazorWindowHelper;
using BlazorWindowHelper.Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCalculatorComponent
{
    public partial class CompBlazorCalculator
    {


        [Inject]
        IJSRuntime jsRuntime { get; set; }

        public string CurrInput;
        public string CurrExpression;
        public string CurrAnswer ="Current answer 0";

        public List<MyCalculatorOperation> MyCalculatorOperationsList = new List<MyCalculatorOperation>();

        public event EventHandler CalculatorViewer_Closed;

        string Previous_Operator = string.Empty;
        double Global_Result = 0;
        bool reset = true;



        protected override void OnInitialized()
        {

            BWHWindowHelper.jsRuntime = jsRuntime;
            
            BWHJsInterop.SetOnOrOff(true);
            BWHKeyboardHelper.OnKeyUp += KeyUpFromBWH;
            base.OnInitialized();
        }


        public void AddString(string s)
        {

            if (reset == true)
            {
                reset = false;
                CurrInput = string.Empty;
            }

            CurrInput += s;

        }


        public void buttonComp_Click()
        {
            double k = Convert.ToDouble(CurrInput.Replace(".", ","));
            k = -k;
            CurrInput = k.ToString();
        }

        public void buttonDot_Click()
        {
            Cmd_Add_Dot();
        }

        public void Cmd_Add_Dot()
        {

            if (!CurrInput.Contains("."))
            {
                AddString(".");
            }
        }


        public void Cmd_Add_Operator(string Par_Operator)
        {
            
            if (!string.IsNullOrEmpty(CurrInput))
            {
                CurrInput = CurrInput.Replace(".", ",");
                if (!string.IsNullOrEmpty(Previous_Operator))
                {
                    
                    switch (Previous_Operator)
                    {
                        case "+":
                            Global_Result += Convert.ToDouble(CurrInput);
                            break;
                        case "-":
                            Global_Result -= Convert.ToDouble(CurrInput);
                            break;
                        case "*":
                            Global_Result *= Convert.ToDouble(CurrInput);
                            break;
                        case "/":
                            Global_Result /= Convert.ToDouble(CurrInput);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Global_Result = Convert.ToDouble(CurrInput);
                }

                Previous_Operator = Par_Operator;

                CurrExpression += CurrInput.Trim();
                CurrExpression += " " + Par_Operator + " ";
                CurrInput = string.Empty;

                CurrAnswer = "Current answer - " + Global_Result.ToString();
            }
        }

        public void Cmd_EQ()
        {

            if (!string.IsNullOrEmpty(CurrInput) && !string.IsNullOrEmpty(Previous_Operator))
            {
                Cmd_Add_Operator("=");

                Cmd_Add_Operation_In_History(CurrExpression.Trim() + " " + CurrInput.ToString().Trim());

                Cmd_Off();
            }

        }


        public void buttonEQ_Click()
        {

            Cmd_EQ();

        }

        public void Cmd_Add_Operation_In_History(string Par_Operation)
        {
            MyCalculatorOperation Tmp_MyCalculatorOperation = new MyCalculatorOperation();
            Tmp_MyCalculatorOperation.ID = MyCalculatorOperationsList.Count + 1;
            Tmp_MyCalculatorOperation.AddDate = DateTime.Now;
            Tmp_MyCalculatorOperation.Answer = Global_Result.ToString();
            Tmp_MyCalculatorOperation.Operation = Par_Operation + Global_Result.ToString().Replace(",", ".");
            MyCalculatorOperationsList.Add(Tmp_MyCalculatorOperation);
            StateHasChanged();
        }



        public void buttonclear_Click()
        {
            Cmd_Off();
        }

        public void buttonoff_Click()
        {
            Cmd_Off();
            MyCalculatorOperationsList = new List<MyCalculatorOperation>();
            StateHasChanged();
        }

        public void Cmd_Off()
        {
            reset = true;
            Global_Result = 0;
            CurrInput = string.Empty;
            CurrExpression = string.Empty;
            Previous_Operator = string.Empty;
            CurrAnswer = "Current answer 0";
        }



        public void SLWindow_Unloaded()
        {
            CalculatorViewer_Closed(this, new EventArgs());
        }

        public void buttonBackSpace_Click()
        {
            Cmd_BackSpace();

        }

        public void Cmd_BackSpace()
        {
            if (!string.IsNullOrEmpty(CurrInput))
            {
                CurrInput = CurrInput.Substring(0, CurrInput.Length - 1);
            }

        }

        public void KeyUpFromBWH(BWHKeyboardState keyboardState)
        {

            switch (keyboardState.consoleKey)
            {
                case ConsoleKey.D0:
                    AddString("0");
                    StateHasChanged();
                    break;
                case ConsoleKey.D1:
                    AddString("1");
                    StateHasChanged();
                    break;
                case ConsoleKey.D2:
                    AddString("2");
                    StateHasChanged();
                    break;
                case ConsoleKey.D3:
                    AddString("3");
                    StateHasChanged();
                    break;
                case ConsoleKey.D4:
                    AddString("4");
                    StateHasChanged();
                    break;
                case ConsoleKey.D5:
                    AddString("5");
                    StateHasChanged();
                    break;
                case ConsoleKey.D6:
                    AddString("6");
                    StateHasChanged();
                    break;
                case ConsoleKey.D7:
                    AddString("7");
                    StateHasChanged();
                    break;
                case ConsoleKey.D8:
                    AddString("8");
                    StateHasChanged();
                    break;
                case ConsoleKey.D9:
                    AddString("9");
                    StateHasChanged();
                    break;
                case ConsoleKey.NumPad0:
                    AddString("0");
                    StateHasChanged();
                    break;
                case ConsoleKey.NumPad1:
                    AddString("1");
                    StateHasChanged();
                    break;
                case ConsoleKey.NumPad2:
                    AddString("2");
                    StateHasChanged();
                    break;
                case ConsoleKey.NumPad3:
                    AddString("3");
                    StateHasChanged();
                    break;
                case ConsoleKey.NumPad4:
                    AddString("4");
                    StateHasChanged();
                    break;
                case ConsoleKey.NumPad5:
                    AddString("5");
                    StateHasChanged();
                    break;
                case ConsoleKey.NumPad6:
                    AddString("6");
                    StateHasChanged();
                    break;
                case ConsoleKey.NumPad7:
                    AddString("7");
                    StateHasChanged();
                    break;
                case ConsoleKey.NumPad8:
                    AddString("8");
                    StateHasChanged();
                    break;
                case ConsoleKey.NumPad9:
                    AddString("9");
                    StateHasChanged();
                    break;
                case ConsoleKey.Add:
                    Cmd_Add_Operator("+");
                    StateHasChanged();
                    break;
                case ConsoleKey.Subtract:
                    Cmd_Add_Operator("-");
                    StateHasChanged();
                    break;
                case ConsoleKey.Divide:
                case ConsoleKey.Oem2:
                    Cmd_Add_Operator("/");
                    StateHasChanged();
                    break;
                case ConsoleKey.Multiply:
                    Cmd_Add_Operator("*");
                    StateHasChanged();
                    break;
                case ConsoleKey.Decimal:
                    Cmd_Add_Dot();
                    StateHasChanged();
                    break;
                case ConsoleKey.OemPeriod:
                    Cmd_Add_Dot();
                    StateHasChanged();
                    break;
                case ConsoleKey.Enter:
                    Cmd_EQ();
                    StateHasChanged();
                    break;
                case ConsoleKey.Escape:
                    Cmd_Off();
                    StateHasChanged();
                    break;
                case ConsoleKey.Backspace:
                    Cmd_BackSpace();
                    StateHasChanged();
                    break;
                default:
                    break;
            }
        }



        public void Cmd_KeyUp(KeyboardEventArgs e)
        {
          
            switch (e.Key)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    AddString(e.Key);
                    break;
                case ".":
                    Cmd_Add_Dot();
                    break;
                case "Escape":
                    Cmd_Off();
                    break;
                case "Backspace":
                    Cmd_BackSpace();
                    break;
                case "Enter":
                    Cmd_EQ();
                    break;
                case "+":   
                case "-":   
                case "*":
                case "/":
                    Cmd_Add_Operator(e.Key);
                    break;
                default:
                    break;
            }


            
        }


        public void CurrAnswer_MouseLeftButtonUp()
        {
            CurrInput = Global_Result.ToString();
        }

        public void Button_Power_2_Click()
        {
            if (!string.IsNullOrEmpty(CurrInput))
            {
                Global_Result = Convert.ToDouble(CurrInput.Replace(".", ","));
                Global_Result = Math.Pow(Global_Result, 2);
                Cmd_Add_Operation_In_History(CurrInput.Trim() + " ^ 2 = ");
                Cmd_Off();
            }
        }

        public void Button_Power_3_Click()
        {
            if (!string.IsNullOrEmpty(CurrInput))
            {
                Global_Result = Convert.ToDouble(CurrInput.Replace(".", ","));
                Global_Result = Math.Pow(Global_Result, 3);
                Cmd_Add_Operation_In_History(CurrInput.Trim() + " ^ 3 = ");
                Cmd_Off();
            }
        }

        public void Button_SQRT_Click()
        {
            if (!string.IsNullOrEmpty(CurrInput))
            {
                Global_Result = Convert.ToDouble(CurrInput.Replace(".", ","));
                Global_Result = Math.Sqrt(Global_Result);
                Cmd_Add_Operation_In_History(CurrInput.Trim() + " √ 2 = ");
                Cmd_Off();
            }
        }

        public void Button_CRT_Click()
        {
            if (!string.IsNullOrEmpty(CurrInput))
            {
                Global_Result = Convert.ToDouble(CurrInput.Replace(".", ","));
                Global_Result = Math.Pow(Global_Result, 0.3333333333333333333333);
                Cmd_Add_Operation_In_History(CurrInput.Trim() + " √ 3 = ");
                Cmd_Off();
            }
        }

        public void Dispose()
        {

        }
    }
}
