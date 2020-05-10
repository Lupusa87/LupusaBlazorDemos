using BlazorSpreadsheetComponent.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSpreadsheetComponent.Classes
{
    public class BTable
    {
        public int ID { get; set; }
        public List<BCell> Table_List { get; set; } = new List<BCell>();

        public BCell ActiveCell = new BCell();

        public void Initialize()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Table_List.Add(new BCell()
                    {
                        ID = Table_List.Count+1,
                        Row = i,
                        Column = j,
                    });
                }
            }


            foreach (var item in Table_List)
            {
                item.Initialize();
            }


            BCell b = Table_List.Single(x => x.Row == 1 && x.Column == 0);
            b.Formula = "=25+1";
            b = Table_List.Single(x => x.Row == 1 && x.Column == 1);
            b.Formula = "=$!?A2?!$+$!?C2?!$"; 

            b = Table_List.Single(x => x.Row == 1 && x.Column == 2);
            b.Value = "14";

            b = Table_List.Single(x => x.Row == 4 && x.Column == 3);
            b.Value = "hello";

            b = Table_List.Single(x => x.Row == 0 && x.Column == 0);
            b.Formula = "=$!?A2?!$+$!?C2?!$+$!?B2?!$+$!?K10?!$";

            b = Table_List.Single(x => x.Row == 5 && x.Column == 1);
            b.Formula = "=2.58+2*(125-2)";


            b = Table_List.Single(x => x.Row == 9 && x.Column == 9);
            b.Formula = "=$!?B2?!$";


           


            Calculate();
        }

        public bool CheckFormulaForCircuitReference(string a, string Curr_Cell_Address)
        {
            bool result = false;


            if (a.IndexOf("$!?") > -1)
            {
                List<string> tmp_list = MyFunctions.ExtractReferencedCells(a);

                if (tmp_list.Any())
                {
                    if (tmp_list.Any(x => x == Curr_Cell_Address))
                    {
                        return true;
                    }
                    else
                    {
                        return Check_Dependecies_Recursively(tmp_list, Curr_Cell_Address);
                    }
                }
            }
            return result;
        }


        public bool Check_Dependecies_Recursively(List<string> tmp_list, string Curr_Cell_Address)
        {
            foreach (var item in tmp_list)
            {
                List<string> tmp_list2 = MyFunctions.ExtractReferencedCells(Table_List.Single(x=>x.Address.Equals(item)).Formula);

                if (tmp_list2.Any())
                {
                    if (tmp_list2.Any(x => x == Curr_Cell_Address))
                    {
                        return true;
                    }
                    else
                    {
                        Check_Dependecies_Recursively(tmp_list2, Curr_Cell_Address);
                    }
                }
            }

            return false;
        }



        public void Calculate()
        {

            foreach (var item in Table_List)
            {
                item.IsCalculated=false;
                item.CheckIfNeedsCalculation();
                
            }

            if (Table_List.Any())
            {
                if (Table_List.Any(x => x.NeedsCalculation))
                {
                    if (Table_List.Any(x => x.NeedsCalculation && x.IsCalculated == false))
                    {
                        RecursiveCalc();
                    }
                }
            }


        }

        private bool AreCalculateReferencedCells(BCell par_item)
        {
            bool result = true;
            List<string> tmp_list = par_item.ExtractReferencedCells();

            if (tmp_list.Any())
            {
                List<BCell> cells_list = new List<BCell>();
                foreach (var item in tmp_list)
                {
                    cells_list.Add(Table_List.Single(x => x.Address.Equals(item)));
                }


                if (cells_list.Any(x=>x.IsCalculated==false))
                {
                    return false;
                }
                else
                {

                    foreach (var item in cells_list)
                    {
                        par_item.FormulaTemp = par_item.FormulaTemp.Replace("$!?" + item.Address + "?!$", item.Value);
                    }

                    
                }
                
            }

            return result;
        }

        private void RecursiveCalc()
        {

            foreach (var item in Table_List.Where(x=>x.NeedsCalculation && x.IsCalculated==false).OrderBy(x=>x.ID))
            {
                if (AreCalculateReferencedCells(item))
                {
                    item.Calculate();
                }
            }



            if (Table_List.Any(x => x.NeedsCalculation))
            {
                if (Table_List.Any(x => x.NeedsCalculation && x.IsCalculated == false))
                {
                    RecursiveCalc();
                }
            }

        }


        public void Cmd_Clear_Selection()
        {
            foreach (var item in Table_List.Where(x => x.Selected))
            {
                item.Selected = false;
            }

            foreach (var item in Table_List)
            {
                item.bStyle = new BStyle();
            }
        }



        public void SelectActiveCell()
        {
            Cmd_Clear_Selection();


            ActiveCell.Selected = true;

            ActiveCell.bStyle = new BStyle()
            {
                BorderColor = "blue",
                BorderWidth = 2,
                BackgroundColor = "wheat",
            };

        }

        public void HiglightCell(BCell Par_BCell, string Par_Color)
        {
            Par_BCell.bStyle = new BStyle()
            {
                BorderColor = Par_Color,
                BackgroundColor = "yellow",
                ForeColor = "blue",
                BorderWidth = 2,
            };
        }

        public void Cmd_Select_Referenced_Cells()
        {
            if (string.IsNullOrEmpty(ActiveCell.Formula)) return;

            if (ActiveCell.Formula.Substring(0, 1) == "=")
            {

                SelectActiveCell();

                if (ActiveCell.Formula.IndexOf("$!?") > -1)
                {
                    List<string> tmp_list = MyFunctions.ExtractReferencedCells(ActiveCell.Formula);

                    if (tmp_list.Any())
                    {
                        foreach (var item in tmp_list)
                        {
                            HiglightCell(Table_List.Single(x => x.Address.Equals(item)), "red");
                        }
                    }
                }

            }
            
        }
    }
}
