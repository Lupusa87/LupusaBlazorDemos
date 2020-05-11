using BlazorSplitterComponent;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Demos
{
    public partial class PageSplitter
    {
        [Inject]
        private IJSRuntime jsRuntime { get; set; }

        public List<CompBlazorSplitter> CompBlazorSplitters_List_Cols = new List<CompBlazorSplitter>();

        public List<CompBlazorSplitter> CompBlazorSplitters_List_Rows = new List<CompBlazorSplitter>();

        public List<BsSettings> bsSettings_List_Cols { get; set; } = new List<BsSettings>();


        public List<BsSettings> bsSettings_List_Rows { get; set; } = new List<BsSettings>();


        public List<int> Width_list_Cols = new List<int>();
        public List<int> Height_list_Rows = new List<int>();



        public int Col_Min_width = 50;
        public int Col_Max_width = 300;

        public int Row_Min_height = 20;
        public int Row_Max_height = 100;


        public string[,] Values_Matrix = new string[5, 5];

        protected override void OnInitialized()
        {
            BSplitterCJsInterop.jsRuntime = jsRuntime;

            for (int i = 0; i < 6; i++)
            {
                CompBlazorSplitters_List_Cols.Add(new CompBlazorSplitter());
                Width_list_Cols.Add(100);

                CompBlazorSplitters_List_Rows.Add(new CompBlazorSplitter());
                Height_list_Rows.Add(30);
            }



            for (int i = 0; i < Values_Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Values_Matrix.GetLength(1); j++)
                {
                    Values_Matrix[i, j] = Guid.NewGuid().ToString("d").Substring(1, 4);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                bsSettings_List_Cols.Add(new BsSettings("VerticalScroll" + i)
                {
                    index = bsSettings_List_Cols.Count,
                    width = 5,
                    height = 40,
                    BgColor = "#bfbfbf",
                });


                bsSettings_List_Rows.Add(new BsSettings("HorizontalScroll" + 1)
                {
                    VerticalOrHorizontal = true,
                    index = bsSettings_List_Rows.Count,
                    width = 30,
                    height = 5,
                    BgColor = "#b3ffb3",
                });
            }


            base.OnInitialized();
        }


        public void OnPositionChange(bool b, int index, int p)
        {

            if (b)
            {

                int old_Value_row = Height_list_Rows[index];

                Height_list_Rows[index] += p;


                if (Height_list_Rows[index] + p < Row_Min_height)
                {
                    Height_list_Rows[index] = Row_Min_height;
                }
                if (Height_list_Rows[index] > Row_Max_height)
                {
                    Height_list_Rows[index] = Row_Max_height;
                }


                if (Height_list_Rows[index] != old_Value_row)
                {
                    StateHasChanged();
                }
            }
            else
            {
                int old_Value_col = Width_list_Cols[index];

                Width_list_Cols[index] += p;


                if (Width_list_Cols[index] + p < Col_Min_width)
                {
                    Width_list_Cols[index] = Col_Min_width;
                }
                if (Width_list_Cols[index] > Col_Max_width)
                {
                    Width_list_Cols[index] = Col_Max_width;
                }


                if (Width_list_Cols[index] != old_Value_col)
                {
                    StateHasChanged();
                }
            }

        }


    }
}
