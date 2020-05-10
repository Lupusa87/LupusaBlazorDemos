using BlazorSpreadsheetComponent.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSpreadsheetComponent.Classes
{
    public class BCell
    {

        public int ID { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string ColLetter { get; set; }
        public string Address { get; set; }
        public string Value { get; set; }
        public string Formula { get; set; }
        public string FormulaTemp { get; set; }

        public bool NeedsCalculation { get; set; }
        public bool IsCalculated { get; set; }




        public bool Selected { get; set; }

        public BStyle bStyle { get; set; } = new BStyle();

        public void Initialize()
        {
            ColLetter = MyFunctions.GetLetter(Column);
            Address = ColLetter + (Row+1);
        }



        public string GetStyle()
        {

            StringBuilder sb1 = new StringBuilder();


            sb1.Append("border-style:solid;width:70px;height:35px;margin:1px;padding:2px;");

            if (!string.IsNullOrEmpty(bStyle.BackgroundColor))
            {
                sb1.Append("background-color:" + bStyle.BackgroundColor + ";");
            }

            if (!string.IsNullOrEmpty(bStyle.ForeColor))
            {
                sb1.Append("color:" + bStyle.ForeColor + ";");
            }
            if (!string.IsNullOrEmpty(bStyle.BorderColor))
            {
                sb1.Append("border-color:" + bStyle.BorderColor + ";");
            }

            if (Selected)
            {

                sb1.Append("cursor:pointer;");

            }
            else
            {
                sb1.Append("cursor:cell;");
                
            }


            if (bStyle.BorderWidth > -1)
            {
                sb1.Append("border-width:" + bStyle.BorderWidth + "px;");
            }

            else
            {
                sb1.Append("border-width:1px;");
            }

            return sb1.ToString();

        }


        public void CheckIfNeedsCalculation()
        {
            NeedsCalculation = false;
            IsCalculated = true;
            if (!string.IsNullOrEmpty(Formula))
            {
                Value = "empty";

                if (Formula.Substring(0, 1) == "=")
                {
                    NeedsCalculation = true;
                    IsCalculated = false;
                    FormulaTemp = Formula.Substring(1, Formula.Length-1);
                }
                else
                {
                    Value = "Error! formula shoud start with \"=\"";
                    IsCalculated = true;
                }

            }

        }


        public List<string> ExtractReferencedCells()
        {
           
                return MyFunctions.ExtractReferencedCells(FormulaTemp);
            

        }


        public void Calculate()
        {
            if (NeedsCalculation)
            {
               Value = MyFunctions.CalculateFormula(FormulaTemp);
               IsCalculated = true;
               
            }
            
        }
    }
}
