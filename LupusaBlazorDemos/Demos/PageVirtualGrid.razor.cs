using BlazorVirtualGridComponent;
using BlazorVirtualGridComponent.classes;
using BlazorVirtualGridComponent.ExternalSettings;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Demos
{
    public partial class PageVirtualGrid
    { 
        [Inject]
        private IJSRuntime jsRuntime { get; set; }

        Random rnd1 = new Random();

        public CompBlazorVirtualGrid<MyItem> CurrBVG1;
        public CompBlazorVirtualGrid<MyItem2> CurrBVG2;

        public bool FirstOrSecond = true;


        public string TableName1 { get; set; } = "Table 1";
        public string TableName2 { get; set; } = "Table 2";

        public IList<MyItem> list1 { get; set; } = new List<MyItem>();

        public IList<MyItem2> list2 { get; set; } = new List<MyItem2>();

        public BvgSettings<MyItem> bvgSettings1 { get; set; } = new BvgSettings<MyItem>();
        public BvgSettings<MyItem2> bvgSettings2 { get; set; } = new BvgSettings<MyItem2>();



        Dictionary<string, ValuesContainer<Tuple<string, ushort>>> SavedColumnWitdths_Dict = new Dictionary<string, ValuesContainer<Tuple<string, ushort>>>();



        protected override void OnInitialized()
        {

            BVirtualGridCJsInterop.jsRuntime = jsRuntime;

            FillList(200, 200);


            bvgSettings1.LayoutFixedOrAuto = false;

            ConfigureBvgSettings1();


            bvgSettings1.FrozenColumnsListOrdered = new ValuesContainer<string>();
            bvgSettings1.FrozenColumnsListOrdered
                .Add(nameof(MyItem.C3))
                .Add(nameof(MyItem.Date));

            bvgSettings1.ColumnWidthsDictionary = new ValuesContainer<Tuple<string, ushort>>();
            bvgSettings1.ColumnWidthsDictionary
                .Add(Tuple.Create(nameof(MyItem.C3), (ushort)200))
                .Add(Tuple.Create(nameof(MyItem.Date), (ushort)200));


            PropertyInfo[] props = typeof(MyItem).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var item in props.Where(x => x.Name != "Date" && x.Name != "C3"))
            {
                bvgSettings1.ColumnWidthsDictionary
                    //.Add(Tuple.Create(item.Name, bvgSettings1.ColWidthMin));
                    .Add(Tuple.Create(item.Name, (ushort)rnd1.Next(bvgSettings1.ColWidthMin, bvgSettings1.ColWidthMax)));

            }


            //foreach (var item in props.Where(x => x.Name.Contains("C")))
            //{
            //    bvgSettings1.HiddenColumns
            //    .Add(item.Name);
            //}

            bvgSettings1.HiddenColumns
                // .Add(nameof(MyItem.SomeBool))
                .Add(nameof(MyItem.C2));

            base.OnInitialized();
        }


        public void GetColumnsWidth1()
        {

            if (SavedColumnWitdths_Dict.ContainsKey(CurrBVG1.bvgGrid.Name))
            {
                SavedColumnWitdths_Dict[CurrBVG1.bvgGrid.Name] = CurrBVG1.bvgGrid.GetColumnWidths();
            }
            else
            {
                SavedColumnWitdths_Dict.Add(CurrBVG1.bvgGrid.Name, CurrBVG1.bvgGrid.GetColumnWidths());
            }
        }


        public void GetColumnsWidth2()
        {

            if (SavedColumnWitdths_Dict.ContainsKey(CurrBVG2.bvgGrid.Name))
            {
                SavedColumnWitdths_Dict[CurrBVG2.bvgGrid.Name] = CurrBVG2.bvgGrid.GetColumnWidths();
            }
            else
            {
                SavedColumnWitdths_Dict.Add(CurrBVG2.bvgGrid.Name, CurrBVG2.bvgGrid.GetColumnWidths());
            }
        }


        public void ConfigureBvgSettings1()
        {

            bvgSettings1.NonFrozenCellStyle = new BvgStyle
            {
                BackgroundColor = "#cccccc",
                ForeColor = "#00008B",
                BorderColor = "#000000",
                BorderWidth = 1,
            };
            bvgSettings1.AlternatedNonFrozenCellStyle = new BvgStyle
            {
                BackgroundColor = "#a7f1a7",
                ForeColor = "#00008B",
                BorderColor = "#000000",
                BorderWidth = 1,
            };
            bvgSettings1.FrozenCellStyle = new BvgStyle
            {
                BackgroundColor = "#C0C0C0",
                ForeColor = "#00008B",
                BorderColor = "#000000",
                BorderWidth = 1,
            };
            bvgSettings1.AlternatedFrozenCellStyle = new BvgStyle
            {
                BackgroundColor = "#90EE90",
                ForeColor = "#00008B",
                BorderColor = "#000000",
                BorderWidth = 1,
            };
            bvgSettings1.SelectedCellStyle = new BvgStyle
            {
                BackgroundColor = "#4d88ff",
                ForeColor = "#FFFFFF",
                BorderColor = "#000000",
                BorderWidth = 1,
            };
            bvgSettings1.ActiveCellStyle = new BvgStyle
            {
                BackgroundColor = "#4d88ff",
                ForeColor = "#FFFFFF",
                BorderColor = "#FFFFFF",
                BorderWidth = 2,
            };
            bvgSettings1.HeaderStyle = new BvgStyle
            {
                BackgroundColor = "#b3b3b3",
                ForeColor = "#0000FF",
                BorderColor = "#000000",
                BorderWidth = 1,
            };
            bvgSettings1.ActiveHeaderStyle = new BvgStyle
            {
                BackgroundColor = "#b3b3b3",
                ForeColor = "#00008B",
                BorderColor = "#000000",
                BorderWidth = 1,
            };

            bvgSettings1.RowHeight = 40;
            bvgSettings1.HeaderHeight = 50;
            //bvgSettings1.ColWidthMin = 220;
            //bvgSettings1.ColWidthMax = 400;

            //bvgSettings1.VerticalScrollStyle = new BvgStyleScroll
            //{
            //    ButtonColor = "#008000",
            //    ThumbColor = "#FF0000",
            //    ThumbWayColor = "#90EE90",
            //};

            //bvgSettings1.HorizontalScrollStyle = new BvgStyleScroll
            //{
            //    ButtonColor = "#008000",
            //    ThumbColor = "#FF0000",
            //    ThumbWayColor = "#90EE90",
            //};

        }

        public void ConfigureBvgSettings2()
        {


            bvgSettings2.NonFrozenCellStyle = new BvgStyle
            {
                BackgroundColor = "#cccccc",
                ForeColor = "#00008B",
                BorderColor = "#000000",
                BorderWidth = 1,
            };
            bvgSettings2.AlternatedNonFrozenCellStyle = new BvgStyle
            {
                BackgroundColor = "#a7f1a7",
                ForeColor = "#00008B",
                BorderColor = "#000000",
                BorderWidth = 1,
            };
            bvgSettings2.FrozenCellStyle = new BvgStyle
            {
                BackgroundColor = "#C0C0C0",
                ForeColor = "#00008B",
                BorderColor = "#000000",
                BorderWidth = 1,
            };
            bvgSettings2.AlternatedFrozenCellStyle = new BvgStyle
            {
                BackgroundColor = "#90EE90",
                ForeColor = "#00008B",
                BorderColor = "#000000",
                BorderWidth = 1,
            };
            bvgSettings2.SelectedCellStyle = new BvgStyle
            {
                BackgroundColor = "#4d88ff",
                ForeColor = "#FFFFFF",
                BorderColor = "#000000",
                BorderWidth = 1,
            };
            bvgSettings2.ActiveCellStyle = new BvgStyle
            {
                BackgroundColor = "#4d88ff",
                ForeColor = "#FFFFFF",
                BorderColor = "#000000",
                BorderWidth = 1,
            };
            bvgSettings2.HeaderStyle = new BvgStyle
            {
                BackgroundColor = "#b3b3b3",
                ForeColor = "#0000FF",
                BorderColor = "brown",
                BorderWidth = 2,
            };
            bvgSettings2.ActiveHeaderStyle = new BvgStyle
            {
                BackgroundColor = "#b3b3b3",
                ForeColor = "#00008B",
                BorderColor = "#000000",
                BorderWidth = 2,
            };
            bvgSettings2.RowHeight = 40;
            bvgSettings2.HeaderHeight = 50;

        }

        public void CmdNewList1()
        {

            FirstOrSecond = true;


            GetColumnsWidth1();

            FillList(200, 300);


            bvgSettings1.LayoutFixedOrAuto = false;

            ConfigureBvgSettings1();

            bvgSettings1.FrozenColumnsListOrdered = new ValuesContainer<string>();
            bvgSettings1.FrozenColumnsListOrdered
                .Add(nameof(MyItem.C3))
                .Add(nameof(MyItem.Date));



            if (SavedColumnWitdths_Dict.ContainsKey(TableName1))
            {
                bvgSettings1.ColumnWidthsDictionary = SavedColumnWitdths_Dict[TableName1];
            }


            StateHasChanged();


        }


        public void CmdNewList2()
        {
            FirstOrSecond = false;

            GetColumnsWidth2();

            FillList2(200, 300);


            bvgSettings2.LayoutFixedOrAuto = false;

            ConfigureBvgSettings2();

            bvgSettings2.FrozenColumnsListOrdered = new ValuesContainer<string>();
            bvgSettings2.FrozenColumnsListOrdered
                .Add(nameof(MyItem2.Gender));

            bvgSettings2.HiddenColumns = new ValuesContainer<string>();
            bvgSettings2.HiddenColumns
                .Add(nameof(MyItem2.LastName));


            if (SavedColumnWitdths_Dict.ContainsKey(TableName1))
            {
                bvgSettings1.ColumnWidthsDictionary = SavedColumnWitdths_Dict[TableName1];
            }


            StateHasChanged();
        }


        private void FillList(int Par_Min, int Par_Max)
        {
            list1 = new List<MyItem>();

            PropertyInfo[] AllProps = typeof(MyItem).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.Name.StartsWith("C")).ToArray();


            for (ushort i = 1; i <= rnd1.Next(Par_Min, Par_Max); i++)
            {
                MyItem n = new MyItem
                {
                    ID = i,
                    Name = string.Concat("Item " + i),

                    SomeBool = rnd1.Next(0, 5) > 1,
                    Date = DateTime.Now.AddDays(-i),
                };


                for (int j = 0; j < AllProps.Count(); j++)
                {
                    AllProps[j].SetValue(n, AllProps[j].Name + "R" + i);
                }


                list1.Add(n);
            }
        }

        private void FillList2(int Par_Min, int Par_Max)
        {
            list2 = new List<MyItem2>();
            for (int i = 1; i <= rnd1.Next(Par_Min, Par_Max); i++)
            {
                list2.Add(new MyItem2
                {
                    ID = (ushort)i,
                    FirstName = Guid.NewGuid().ToString("d").Substring(1, 4),
                    LastName = Guid.NewGuid().ToString("d").Substring(1, 4),
                    Gender = rnd1.Next(0, 5) == 0,
                    BirthDate = DateTime.Now.AddDays(-rnd1.Next(1, 5000)).AddHours(-rnd1.Next(1, 5000)).AddSeconds(-rnd1.Next(1, 5000)),

                });
            }
        }



        public void CmdShowColumnsManager()
        {
            CurrBVG1.ShowColumnsManager();

        }


        public void CmdShowStyleDesigner()
        {
            CurrBVG1.ShowStyleDesigner();
        }



        public class MyItem
        {
            public ushort ID { get; set; }
            public string Name { get; set; }
            public bool SomeBool { get; set; }
            public DateTime Date { get; set; }
            public string C1 { get; set; }
            public string C2 { get; set; }
            public string C3 { get; set; }
            public string C4 { get; set; }
            public string C5 { get; set; }
            public string C6 { get; set; }
            public string C7 { get; set; }
            public string C8 { get; set; }
            public string C9 { get; set; }
            public string C10 { get; set; }
            public string C11 { get; set; }
            public string C12 { get; set; }
            public string C13 { get; set; }
            public string C14 { get; set; }
            public string C15 { get; set; }
            public string C16 { get; set; }
            public string C17 { get; set; }
            public string C18 { get; set; }
            public string C19 { get; set; }
            public string C20 { get; set; }
            public string C21 { get; set; }
            public string C22 { get; set; }
            public string C23 { get; set; }
            public string C24 { get; set; }
            public string C25 { get; set; }
            public string C26 { get; set; }
            public string C27 { get; set; }
            public string C28 { get; set; }
            public string C29 { get; set; }
            public string C30 { get; set; }

        }


        public class MyItem2
        {
            public ushort ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }
            public bool Gender { get; set; }
        }
    }
}
