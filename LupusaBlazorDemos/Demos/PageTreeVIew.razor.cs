using BlazorTreeVisualizerComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Demos
{
    public partial class PageTreeView
    {
        Random rnd = new Random();


        private CompBlazorTreeVisualizer treeview = new CompBlazorTreeVisualizer();

        protected override void OnInitialized()
        {

            initializedata();


            base.OnInitialized();
        }



        private void CmdButtonClick()
        {
            treeview.CmdDeleteSelected();
        }


        private void initializedata()
        {

            List<TreeItem> tmplist = new List<TreeItem>();

            tmplist.Add(new TreeItem()
            {
                ID = 1,
                Level = 0,
                Column = "New York",
                ParentID = 0,
                SequenceNumber = 1,
            });


            tmplist.Add(new TreeItem()
            {
                ID = 2,
                Level = 1,
                Column = "Brooklyn",
                ParentID = 1,
                SequenceNumber = 2,
            });


            tmplist.Add(new TreeItem()
            {
                ID = 3,
                Level = 0,
                Column = "New Jersey",
                ParentID = 0,
                SequenceNumber = 3,
            });


            tmplist.Add(new TreeItem()
            {
                ID = 4,
                Level = 1,
                Column = "Jersey City",
                ParentID = 3,
                SequenceNumber = 4,
            });
            tmplist.Add(new TreeItem()
            {
                ID = 5,
                Level = 1,
                Column = "Newark",
                ParentID = 3,
                SequenceNumber = 5,
                IsExpanded = false,
            });



            tmplist.Add(new TreeItem()
            {
                ID = 6,
                Level = 2,
                Column = "Upper Clinton Hill",
                ParentID = 5,
                SequenceNumber = 6,
            });

            tmplist.Add(new TreeItem()
            {
                ID = 7,
                Level = 2,
                Column = "Lower Clinton Hill",
                ParentID = 5,
                SequenceNumber = 7,
            });


            tmplist.Add(new TreeItem()
            {
                ID = 8,
                Level = 1,
                Column = "Union",
                ParentID = 3,
                SequenceNumber = 8,
            });


            int k = 0;
            foreach (var item in tmplist)
            {
                k = rnd.Next(0, 10);
                if (k > 0 && k < 8)
                {
                    item.HasIcon = true;
                    item.IconSource = "icons/icon" + k + ".png";
                }
            }


            PublicDataTree.dynamicOriginalList = tmplist.ToList<TreeItem>();
        }
    }
}
