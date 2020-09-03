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
    public class CompTreeView: ComponentBase, IDisposable
    {
        [Inject]
        IJSRuntime jsRuntime { get; set; }


        [Parameter]
        public int FirstItemID { get; set; } = 0;

        [Parameter]
        public List<TreeItem> SourceList { get; set; } = new List<TreeItem>();


        [Parameter]
        public TreeVisualParams VisualParams { get; set; } = new TreeVisualParams();
        


        [Parameter]
        public EventCallback<int> ItemOnClick { get; set; }

        [Parameter]
        public TreeCssClasses CssClasses { get; set; } = new TreeCssClasses();

        internal int CurrentID = 0;

        
      
        protected override void OnInitialized()
        {
          

            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {

            LocalData.IconLine = null;


            bootstrap();
            CmdPrepareIcons();
            CmdLoadData();
           

            base.OnParametersSet();
        }


        private void bootstrap()
        {
            
            LocalData.VisualParams = VisualParams;

            LocalData.TreeIconBoxSize25 = LocalData.VisualParams.TreeIconBoxSize * 0.25;
            LocalData.TreeIconBoxSize37 = LocalData.VisualParams.TreeIconBoxSize * 0.375;
            LocalData.TreeIconBoxSize50 = LocalData.VisualParams.TreeIconBoxSize * 0.5;
            LocalData.TreeIconBoxSize62 = LocalData.VisualParams.TreeIconBoxSize * 0.625;
            LocalData.TreeIconBoxSize75 = LocalData.VisualParams.TreeIconBoxSize * 0.75;
            
          
        }

        public void Refresh()
        {

          
            StateHasChanged();

        }

        public void Dispose()
        {
        
        }


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            int k = 0;
  
            foreach (var item in SourceList.Where(x => x.IsVisible).OrderBy(x => x.SequenceNumber))
            {
                builder.OpenComponent<CompChild>(k++);
                builder.AddAttribute(k++, "ParID", item.ID);
                builder.AddAttribute(k++, "parent", this);
                builder.AddAttribute(k++, "CompID", item.ID + LocalTreeFunctions.CmdGetUniqueID());
                builder.SetKey(item);
                builder.CloseComponent();
            }

            base.BuildRenderTree(builder);
        }

       

        public void CmdDeleteSelected()
        {

            if (CurrentID > 0)
            {
                if (SourceList.Any(x => x.ID == CurrentID))
                {


                    if (!SourceList.Any(x => x.ParentID == CurrentID))
                    {
                        SourceList.Remove(SourceList.Single(x => x.ID == CurrentID));
                        CurrentID = 0;


                        int k = 0;
                        foreach (TreeItem item in SourceList.OrderBy(x => x.SequenceNumber))
                        {

                            k++;
                            item.SequenceNumber = (double)k;
                            item.IsLastItemInLevel = LocalTreeFunctions.CmdCheckIfItemIsLastInThisLevel(SourceList, item.ID);
                            item.HasChildren = SourceList.Any(x => x.ParentID == item.ID);
                        }

                    }
                    else
                    {
                        jsRuntime.InvokeVoidAsync("alert", "Parent node can't be deleted!");
                    }
                }
            }

            StateHasChanged();

           
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
                SourceList = SourceList.OrderBy(x => x.SequenceNumber).ToList();

                CmdPrepareData();

            }
            catch (Exception ex)
            {
                LocalTreeFunctions.PrintError(ex.Message, MethodBase.GetCurrentMethod());
            }
        }



        public void CmdPrepareData()
        {
            try
            {
                LocalData.MaxLevel = SourceList.Max(x => x.Level);
                LocalData.MinLevel = SourceList.Min(x => x.Level);
                LocalData.LevelsCount = LocalData.MaxLevel - LocalData.MinLevel + 1;

                int k = 0;

                foreach (TreeItem item in SourceList.OrderBy(x => x.SequenceNumber))
                {

                    k++;
                    item.SequenceNumber = (double)k;

                    item.Level = item.Level - LocalData.MinLevel + 1;
                    item.IsLastItemInLevel = LocalTreeFunctions.CmdCheckIfItemIsLastInThisLevel(SourceList,item.ID);
                    item.IsVisible = true;
                    item.IsExpanded = true;
                    item.HasChildren = SourceList.Any(x => x.ParentID == item.ID);
                }


            }
            catch (Exception ex)
            {
                LocalTreeFunctions.PrintError(ex.Message, MethodBase.GetCurrentMethod());
            }

        }





       

    }
}
