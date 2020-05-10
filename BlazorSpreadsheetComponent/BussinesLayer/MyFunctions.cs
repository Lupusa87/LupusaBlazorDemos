using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSpreadsheetComponent.BussinesLayer
{
    public static class MyFunctions
    {

        private static string Letters = "ABCDEFGIJKLMNOP";
        private static string Digits = "0123456789";

        public static string GetLetter(int index)
        {
            if (index > -1)
            {
                if (index < Letters.Length)
                {
                    return Letters[index].ToString();
                }

                else
                {
                    return "error";
                }

            }
            else
            {
                return "error";
            }
        }

        public static string CalculateFormula(string Par_Input)
        {

            DataTable dt = new DataTable();
            var result = dt.Compute(Par_Input, string.Empty);
            return result.ToString();
        }



        public static List<string> ExtractReferencedCells(string Par_Input)
        {

            List<string> result = new List<string>();

            if (!string.IsNullOrEmpty(Par_Input))
            {
                if (Par_Input.IndexOf("$!?") > -1)
                {

                    while (Par_Input.IndexOf("$!?") > -1)
                    {
                        int k1 = Par_Input.IndexOf("$!?");
                        int k2 = Par_Input.IndexOf("?!$");

                        result.Add(Par_Input.Substring(k1 + 3, k2 - k1 - 3));

                     
                        Par_Input = Par_Input.Substring(k2 + 3, Par_Input.Length - (k2 + 3));

                    }
                }
            }



            return result;
        }

        public static bool IsLetter(string Par_Input)
        {
            return Letters.IndexOf(Par_Input) > -1;

        }


        public static bool IsDigit(string Par_Input)
        {
            return Digits.IndexOf(Par_Input) > -1;

        }

        public static string MarkReferencedCells(string Par_Input)
        {

            string result = string.Empty;


            bool b = false;

            for (int i = 0; i < Par_Input.Length; i++)
            {
                string a = Par_Input[i].ToString();
                if (IsLetter(a))
                {
                    result += "$!?" + a;
                    b = true;
                }
                else
                {
                    if (b)
                    {
                        if (IsDigit(a))
                        {
                            result += a;
                        }
                        else
                        {
                            result += "?!$" + a;
                            b = false;
                        }
                    }
                    else
                    {
                        result += a;
                    }

                }

            }



            if (b)
            {
                result += "?!$";
            }

            return result;
        }

    }
}
