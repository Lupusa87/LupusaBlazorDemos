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



        int VDivHeight1 = 100;
        int VDivHeight2 = 100;

        int HDivWidth1 = 100;
        int HDivWidth2 = 100;


        public List<BsSettings> bsSettings_List_Rows { get; set; } = new List<BsSettings>();
        public BsSettings bsSettingPanel1 { get; set; } = new BsSettings();
        public BsSettings bsSettingPanel2 { get; set; } = new BsSettings();



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



            bsSettingPanel1 =new BsSettings("HorizontalScrollpanel")
            {
                VerticalOrHorizontal = true,
                index = 0,
                width = 200,
                height = 4,
                BgColor = "#bfbfbf",
            };


            bsSettingPanel2 = new BsSettings("VerticalScrollpanel")
            {
                VerticalOrHorizontal = false,
                index = 0,
                width = 4,
                height = 200,
                BgColor = "#b3ffb3",
            };


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

        public void OnPositionChangePanel1(bool b, int index, int p)
        {
            if (p>0)
            {
                if (VDivHeight1 < 160)
                {
                    correctSizesV(p);
                }
            }
            else
            {
                if (VDivHeight1 > 40)
                {
                    correctSizesV(p);    
                }
            }
        }

        public void correctSizesV(int p)
        {

            VDivHeight1 += p;
            VDivHeight2 -= p;

            if (VDivHeight1 > 160) VDivHeight1 = 160;
            if (VDivHeight2 > 160) VDivHeight2 = 160;
            if (VDivHeight1 < 40) VDivHeight1 = 40;
            if (VDivHeight2 < 40) VDivHeight2= 40;

            StateHasChanged();
        }

            public string cmdGetStyle1Div1()
        {
            return "background-color:#bfbfbf;width:200px;min-height:40px;max-height:160px;height:" + VDivHeight1 + "px";
        }
        public string cmdGetStyle1Div2()
        {
            return "background-color:#b3ffb3;width:200px;min-height:40px;max-height:160px;height:" + VDivHeight2 + "px";
        }

        public void OnPositionChangePanel2(bool b, int index, int p)
        {
            Console.WriteLine(p);

            if (p > 0)
            {
                if (HDivWidth1 < 160)
                {
                    correctSizesH(p);
                }
            }
            else
            {
                if (HDivWidth1 > 40)
                {
                    correctSizesH(p);
                }
            }
        }

        public void correctSizesH(int p)
        {

            HDivWidth1 += p;
            HDivWidth2 -= p;

            if (HDivWidth1 > 160) HDivWidth1 = 160;
            if (HDivWidth2 > 160) HDivWidth2 = 160;
            if (HDivWidth1 < 40) HDivWidth1 = 40;
            if (HDivWidth2 < 40) HDivWidth2 = 40;

            StateHasChanged();
        }

        public string cmdGetStyle2Div1()
        {
            return "background-color:#bfbfbf;height:200px;min-width:40px;max-width:160px;width:" + HDivWidth1 + "px";
        }
        public string cmdGetStyle2Div2()
        {
            return "background-color:#b3ffb3;height:200px;min-width:40px;max-width:160px;width:" + HDivWidth2 + "px";
        }
    }
}
