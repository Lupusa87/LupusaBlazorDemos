using BlazorSvgHelper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static BlazorTreeVisualizerComponent.LocalEnums;

namespace BlazorTreeVisualizerComponent
{
    public class CompBlazorTreeVisualizer: ComponentBase, IDisposable
    {
        [Inject]
        IJSRuntime jsRuntime { get; set; }

        bool IsFirstLoad = true;


        [Parameter] 
        public int TreeVizualizationItemCode { get; set; }


        Random rnd = new Random();
      
        protected override void OnInitialized()
        {

            if (IsFirstLoad)
            {
                CmdPrepareIcons();
                CmdLoadData();
                IsFirstLoad = false;


                updateCompsList();

                LocalData.compBlazorTreeVisualizer = this;
            }
            

            base.OnInitialized();
        }


        public void updateCompsList()
        {
            //LocalData.ComponentsList = new List<CompChild>();
           
            //foreach (var item in LocalData.dynamicList.Where(x => x.IsVisible).OrderBy(x => x.SequenceNumber))
            //{
               
            //    LocalData.ComponentsList.Add(new CompChild() { ParID = item.ID, CompID = item.ID.ToString() +  CmdGetUniqueID()  });
            //}
        }

        public void update()
        {

            //updateCompsList();
            StateHasChanged();

        }

        public void Dispose()
        {
        
        }


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            int k = 0;
  
            foreach (var item in LocalData.dynamicList.Where(x => x.IsVisible).OrderBy(x => x.SequenceNumber))
            {
                builder.OpenComponent<CompChild>(k++);
                builder.AddAttribute(k++, "ParID", item.ID);
                builder.AddAttribute(k++, "CompID", item.ID+CmdGetUniqueID());
                builder.SetKey(item);
                builder.CloseComponent();
            }

            base.BuildRenderTree(builder);
        }

        private string CmdGetUniqueID()
        {
            long j = DateTime.Now.Ticks;
            string a = j.ToString();

            return a.Substring(a.Length - 4, 4) + Guid.NewGuid().ToString("d").Substring(1, 4);
        }

        public void CmdDeleteSelected()
        {

            if (LocalData.CurrentID > 0)
            {
                if (LocalData.dynamicList.Any(x => x.ID == LocalData.CurrentID))
                {


                    if (!LocalData.dynamicList.Any(x => x.ParentID == LocalData.CurrentID))
                    {
                        LocalData.dynamicList.Remove(LocalData.dynamicList.Single(x => x.ID == LocalData.CurrentID));
                        LocalData.CurrentID = 0;


                        int k = 0;
                        foreach (TreeItem item in LocalData.dynamicList.OrderBy(x => x.SequenceNumber))
                        {

                            k++;
                            item.SequenceNumber = (double)k;
                            item.IsLastItemInLevel = LocalTreeFunctions.CmdCheckIfItemIsLastInThisLevel(item.ID);
                            item.HasChildren = LocalData.dynamicList.Any(x => x.ParentID == item.ID);
                        }

                    }
                    else
                    {
                        jsRuntime.InvokeVoidAsync("alert", "Parent node can't be deleted!");
                    }
                }
            }

            update();

            //int ParID = 1;


            //TreeItem CurrItem = LocalData.dynamicList.Single(x => x.ID == ParID);
            //if (CurrItem.HasChildren)
            //{

            //    CurrItem.IsExpanded = !CurrItem.IsExpanded;

            //    LocalTreeFunctions.CmdChangeVisibility(CurrItem.ID, CurrItem.IsExpanded, true);


            //}

            //update();
           
        }


            private void CmdPrepareIcons()
        {
            if (LocalData.IconLine is null)
            {
                   
                LocalData.IconLine = LocalTreeFunctions.CmdCreateIconLine();
                LocalData.IconItem = LocalTreeFunctions.CmdCreateIconItem();
                LocalData.IconLastItem = LocalTreeFunctions.CmdCreateIconLastItem();

                LocalData.IconMinus = LocalTreeFunctions.CmdCreateIconMinusOrPlus(true);
                LocalData.IconMinusTop = LocalTreeFunctions.CmdCreateIconMinusOrPlusTop(true);
                LocalData.IconMinusBottom = LocalTreeFunctions.CmdCreateIconMinusOrPlusBottom(true);
                LocalData.IconMinusTopBottom = LocalTreeFunctions.CmdCreateIconMinusOrPlusTopBottom(true);

                LocalData.IconPlus = LocalTreeFunctions.CmdCreateIconMinusOrPlus(false);
                LocalData.IconPlusTop = LocalTreeFunctions.CmdCreateIconMinusOrPlusTop(false);
                LocalData.IconPlusBottom = LocalTreeFunctions.CmdCreateIconMinusOrPlusBottom(false);
                LocalData.IconPlusTopBottom = LocalTreeFunctions.CmdCreateIconMinusOrPlusTopBottom(false);

            }
          
        }



        public void CmdLoadData()
        {

            try
            {
                PublicDataTree.dynamicOriginalList = PublicDataTree.dynamicOriginalList.OrderBy(x => x.SequenceNumber).ToList();
                LocalData.dynamicList = new List<TreeItem>();
                //  LocalData.dynamicList = PublicData.dynamicOriginalList.OrderBy(x => x.SequenceNumber).ToList();

                foreach (TreeItem item in PublicDataTree.dynamicOriginalList.OrderBy(x => x.SequenceNumber).ToList())
                {
                    LocalData.dynamicList.Add(item);
                }


                CmdPrepareData();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), MethodBase.GetCurrentMethod());
                //LocalFunctions.DisplayMessage(ex.ToString(), MethodBase.GetCurrentMethod());
            }
        }



        public void CmdPrepareData()
        {
            try
            {
                LocalData.MaxLevel = LocalData.dynamicList.Max(x => x.Level);
                LocalData.MinLevel = LocalData.dynamicList.Min(x => x.Level);
                LocalData.LevelsCount = LocalData.MaxLevel - LocalData.MinLevel + 1;

                int k = 0;

                foreach (TreeItem item in LocalData.dynamicList.OrderBy(x => x.SequenceNumber))
                {

                    k++;
                    item.SequenceNumber = (double)k;

                    item.Level = item.Level - LocalData.MinLevel + 1;
                    item.IsLastItemInLevel = LocalTreeFunctions.CmdCheckIfItemIsLastInThisLevel(item.ID);
                    item.IsVisible = true;
                    item.IsExpanded = true;
                    item.HasChildren = LocalData.dynamicList.Any(x => x.ParentID == item.ID);
                }



                //LocalData.dynamicList.Single(x => x.ID == 5).IsExpanded = false;
                //LocalData.dynamicList.Single(x => x.ID == 6).IsVisible = false;
                //LocalData.dynamicList.Single(x => x.ID == 7).IsVisible = false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), MethodBase.GetCurrentMethod());
                //LocalFunctions.DisplayMessage(ex.ToString(), MethodBase.GetCurrentMethod());
            }

        }





       

    }
}
