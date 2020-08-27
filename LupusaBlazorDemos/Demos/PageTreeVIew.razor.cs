using BlazorClockCanvasComponent;
using BlazorTreeVisualizerComponent;
using BlazorWindowHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Demos
{
    public partial class PageTreeView
    {
        Random rnd = new Random();


        private CompTreeView treeview = new CompTreeView();

        List<TreeItem> Treelist = new List<TreeItem>();
        TreeVisualParams visualParams = new TreeVisualParams();
        TreeCssClasses cssClasses = new TreeCssClasses()
        {

            Div = "trdiv",
            Icon = "trimg",
            Span = "trsp",
            SpanSelected = "trspsel",
            SpanWithChildren = "trspch"
        };

        SizeInt WindowSize { get; set; } = new SizeInt();
        int VHUnitInPixels { get; set; } = 1;

        protected override async Task OnInitializedAsync()
        {
            WindowSize.H = (int)await BWHJsInterop.GetWindowHeight();
            VHUnitInPixels = (int)(WindowSize.H * 0.01);

            visualParams.TreeIconBoxSize = WindowSize.H * 0.04;
            visualParams.SmalestSizeUnit = VHUnitInPixels;

            initializedata();

            await base.OnInitializedAsync();
        }



        public async void MeasureWindowSize()
        {
            
        }

        private void CmdButtonClick()
        {
            treeview.CmdDeleteSelected();
        }


        private void CmdPrintClick()
        {
            LBDLocalData.ShouldCallPrintDialog = true;
            LBDLocalData.IsLayoutVisible = false;
            LBDLocalData.mainLayout.Refresh();
            LocalFunctions.CmdNavigate("print");
        }


        private void initializedata()
        {

            Treelist.Add(new TreeItem()
            {
                ID = 1,
                Level = 0,
                Text = "New York",
                ParentID = 0,
                SequenceNumber = 1,
            });


            Treelist.Add(new TreeItem()
            {
                ID = 2,
                Level = 1,
                Text = "Brooklyn",
                ParentID = 1,
                SequenceNumber = 2,
            });


            Treelist.Add(new TreeItem()
            {
                ID = 3,
                Level = 0,
                Text = "New Jersey",
                ParentID = 0,
                SequenceNumber = 3,
            });


            Treelist.Add(new TreeItem()
            {
                ID = 4,
                Level = 1,
                Text = "Jersey City",
                ParentID = 3,
                SequenceNumber = 4,
            });

            Treelist.Add(new TreeItem()
            {
                ID = 5,
                Level = 1,
                Text = "Newark",
                ParentID = 3,
                SequenceNumber = 5,
                IsExpanded = false,
            });



            Treelist.Add(new TreeItem()
            {
                ID = 6,
                Level = 2,
                Text = "Upper Clinton Hill",
                ParentID = 5,
                SequenceNumber = 6,
            });

            Treelist.Add(new TreeItem()
            {
                ID = 7,
                Level = 2,
                Text = "Lower Clinton Hill",
                ParentID = 5,
                SequenceNumber = 7,
            });


            Treelist.Add(new TreeItem()
            {
                ID = 8,
                Level = 1,
                Text = "Union",
                ParentID = 3,
                SequenceNumber = 8,
            });


            int k = 0;
            foreach (var item in Treelist)
            {
                k = rnd.Next(0, 10);
                if (k > 0 && k < 8)
                {
                    item.IconSource = "icons/icon" + k + ".png";
                }
            }


           
        }



    }

    public class SizeInt
    {
        public int W { get; set; }
        public int H { get; set; }

        public SizeInt(int pW = 0, int pH = 0)
        {
            W = pW;
            H = pH;
        }
    }
}
