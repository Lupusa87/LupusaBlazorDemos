using BlazorSpreadsheetComponent.BussinesLayer;
using BlazorSpreadsheetComponent.Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSpreadsheetComponent
{
    public partial class CompBlazorSpreadsheet: IDisposable
    {
        [Inject]
        IJSRuntime jsRuntime { get; set; }

        public string Curr_Value = string.Empty;
        public string Curr_Value_old = string.Empty;


        public string Curr_Address= string.Empty;

        public BTable Current_BTable=new BTable();


        protected override void OnInitialized()
        {
            Current_BTable.Initialize();

            SelectionChange(Current_BTable.Table_List.FirstOrDefault().ID);

            base.OnInitialized();
        }


        public void SelectionChange(int Par_CellId)
        {


             Current_BTable.ActiveCell = Current_BTable.Table_List.Single(x => x.ID == Par_CellId);
            if (string.IsNullOrEmpty(Current_BTable.ActiveCell.Formula))
            {
                Curr_Value = Current_BTable.ActiveCell.Value;
            }
            else
            {
                Curr_Value = Current_BTable.ActiveCell.Formula.Replace("$!?",null).Replace("?!$", null);
            }


            Curr_Value_old = Curr_Value;

            Curr_Address = Current_BTable.ActiveCell.Address;
            Current_BTable.SelectActiveCell();

            StateHasChanged();
        }



        public void Cmd_Update()
        {
            if (!string.IsNullOrEmpty(Curr_Value))
            {
                if (Curr_Value.Substring(0, 1) == "=")
                {


                    string a = MyFunctions.MarkReferencedCells(Curr_Value.ToUpper());
                    if (!Current_BTable.CheckFormulaForCircuitReference(a, Current_BTable.ActiveCell.Address))
                    {
                        Current_BTable.ActiveCell.Formula = a;
                        Current_BTable.Calculate();
                        Curr_Value_old = Curr_Value;

                        Current_BTable.Cmd_Select_Referenced_Cells();

                    }
                    else
                    {
                        jsRuntime.InvokeVoidAsync("alert", "Detected circuit reference!");
                        Curr_Value = Curr_Value_old;
                    }
                }
                else
                {
                    Current_BTable.ActiveCell.Value = Curr_Value;
                }
            }
            else
            {
                Current_BTable.ActiveCell.Value = string.Empty;
            }

            

            StateHasChanged();
        }


        public void Cmd_Select_Referenced_Cells()
        {
            if (string.IsNullOrEmpty(Curr_Value)) return;

            Current_BTable.Cmd_Select_Referenced_Cells();
        }

        public void Dispose()
        {

        }

    }
}
