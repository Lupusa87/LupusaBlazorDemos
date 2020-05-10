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

      
        protected override void OnInitialized()
        {

            if (IsFirstLoad)
            {
                Cmd_Prepare_Icons();
                Cmd_LoadData();
                IsFirstLoad = false;


                updateCompsList();

                LocalData.compBlazorTreeVisualizer = this;
            }
            

            base.OnInitialized();
        }


        public void updateCompsList()
        {
            //LocalData.Components_List = new List<CompChild>();
           
            //foreach (var item in LocalData.dynamic_List.Where(x => x.Tree_IsVisible).OrderBy(x => x.Tree_SequenceNumber))
            //{
               
            //    LocalData.Components_List.Add(new CompChild() { Par_ID = item.Tree_ID, Comp_ID = item.Tree_ID.ToString() +  Cmd_Get_UniqueID()  });
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
            int k = -1;


            builder.OpenElement(k++, "button");
            builder.AddAttribute(k++, "width", 100);
            builder.AddAttribute(k++, "height", 100);
            builder.AddAttribute(k++, "onclick", EventCallback.Factory.Create(this, Cmd_Button_Click));
            builder.AddAttribute(k++, "class", "btn btn-primary");
            builder.AddContent(k++, "delete selected");
            builder.CloseElement();

            builder.OpenElement(k++, "br");
            builder.CloseElement();

            builder.OpenElement(k++, "br");
            builder.CloseElement();

            foreach (var item in LocalData.dynamic_List.Where(x => x.Tree_IsVisible).OrderBy(x => x.Tree_SequenceNumber))
            {
                builder.OpenComponent<CompChild>(k++);
                builder.AddAttribute(k++, "Par_ID", item.Tree_ID);
                builder.AddAttribute(k++, "Comp_ID", item.Tree_ID+Cmd_Get_UniqueID());
                builder.CloseComponent();
            }

           

            //builder.OpenElement(k++, "br");
            //builder.CloseElement();

            //builder.OpenElement(k++, "br");
            //builder.CloseElement();

            //foreach (var item in LocalData.dynamic_List.OrderBy(x => x.Tree_SequenceNumber))
            //{
            //    builder.OpenElement(k++, "div");
            //    builder.AddContent(k++, item.Tree_Column + " " + item.Tree_IsVisible + " " + item.Tree_IsSelected);
            //    builder.CloseElement();
            //}

            base.BuildRenderTree(builder);
        }

        private string Cmd_Get_UniqueID()
        {
            long j = DateTime.Now.Ticks;
            string a = j.ToString();

            return a.Substring(a.Length - 4, 4) + Guid.NewGuid().ToString("d").Substring(1, 4);
        }

            private void Cmd_Button_Click()
        {

            if (LocalData.Current_Tree_ID > 0)
            {
                if (LocalData.dynamic_List.Any(x => x.Tree_ID == LocalData.Current_Tree_ID))
                {


                    if (!LocalData.dynamic_List.Any(x => x.Tree_ParentID == LocalData.Current_Tree_ID))
                    {
                        LocalData.dynamic_List.Remove(LocalData.dynamic_List.Single(x => x.Tree_ID == LocalData.Current_Tree_ID));
                        LocalData.Current_Tree_ID = 0;


                        int k = 0;
                        foreach (TreeItem item in LocalData.dynamic_List.OrderBy(x => x.Tree_SequenceNumber))
                        {

                            k++;
                            item.Tree_SequenceNumber = (double)k;
                            item.Tree_IsLastItemInLevel = LocalTreeFunctions.Cmd_Check_If_Item_Is_Last_In_This_Level(item.Tree_ID);
                            item.Tree_HasChildren = LocalData.dynamic_List.Any(x => x.Tree_ParentID == item.Tree_ID);
                        }

                    }
                    else
                    {
                        jsRuntime.InvokeVoidAsync("alert", "Parent node can't be deleted!");
                    }
                }
            }

            update();

            //int Par_ID = 1;


            //TreeItem Curr_Item = LocalData.dynamic_List.Single(x => x.Tree_ID == Par_ID);
            //if (Curr_Item.Tree_HasChildren)
            //{

            //    Curr_Item.Tree_IsExpanded = !Curr_Item.Tree_IsExpanded;

            //    LocalTreeFunctions.Cmd_ChangeVisibility(Curr_Item.Tree_ID, Curr_Item.Tree_IsExpanded, true);


            //}

            //update();
           
        }


            private void Cmd_Prepare_Icons()
        {
            if (LocalData.Tree_Icon_Line is null)
            {
                   
                LocalData.Tree_Icon_Line = LocalTreeFunctions.Cmd_Create_Icon_Line();
                LocalData.Tree_Icon_Item = LocalTreeFunctions.Cmd_Create_Icon_Item();
                LocalData.Tree_Icon_LastItem = LocalTreeFunctions.Cmd_Create_Icon_LastItem();

                LocalData.Tree_Icon_Minus = LocalTreeFunctions.Cmd_Create_Icon_Minus_Or_Plus(true);
                LocalData.Tree_Icon_Minus_Top = LocalTreeFunctions.Cmd_Create_Icon_Minus_Or_Plus_Top(true);
                LocalData.Tree_Icon_Minus_Bottom = LocalTreeFunctions.Cmd_Create_Icon_Minus_Or_Plus_Bottom(true);
                LocalData.Tree_Icon_Minus_Top_Bottom = LocalTreeFunctions.Cmd_Create_Icon_Minus_Or_Plus_Top_Bottom(true);

                LocalData.Tree_Icon_Plus = LocalTreeFunctions.Cmd_Create_Icon_Minus_Or_Plus(false);
                LocalData.Tree_Icon_Plus_Top = LocalTreeFunctions.Cmd_Create_Icon_Minus_Or_Plus_Top(false);
                LocalData.Tree_Icon_Plus_Bottom = LocalTreeFunctions.Cmd_Create_Icon_Minus_Or_Plus_Bottom(false);
                LocalData.Tree_Icon_Plus_Top_Bottom = LocalTreeFunctions.Cmd_Create_Icon_Minus_Or_Plus_Top_Bottom(false);

            }
          
        }



        public void Cmd_LoadData()
        {

            initialize_data();

            try
            {
                PublicData.dynamic_Original_List = PublicData.dynamic_Original_List.OrderBy(x => x.Tree_SequenceNumber).ToList();
                LocalData.dynamic_List = new List<TreeItem>();
                //  LocalData.dynamic_List = PublicData.dynamic_Original_List.OrderBy(x => x.Tree_SequenceNumber).ToList();

                foreach (TreeItem item in PublicData.dynamic_Original_List.OrderBy(x => x.Tree_SequenceNumber).ToList())
                {
                    LocalData.dynamic_List.Add(item);
                }


                Cmd_Prepare_Tree_Data();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), MethodBase.GetCurrentMethod());
                //LocalFunctions.Display_Message(ex.ToString(), MethodBase.GetCurrentMethod());
            }
        }



        public void Cmd_Prepare_Tree_Data()
        {
            try
            {
                LocalData.My_MaxLevel = LocalData.dynamic_List.Max(x => x.Tree_Level);
                LocalData.My_MinLevel = LocalData.dynamic_List.Min(x => x.Tree_Level);
                LocalData.My_Levels_Count = LocalData.My_MaxLevel - LocalData.My_MinLevel + 1;

                int k = 0;

                foreach (TreeItem item in LocalData.dynamic_List.OrderBy(x => x.Tree_SequenceNumber))
                {

                    k++;
                    item.Tree_SequenceNumber = (double)k;

                    item.Tree_Level = item.Tree_Level - LocalData.My_MinLevel + 1;
                    item.Tree_IsLastItemInLevel = LocalTreeFunctions.Cmd_Check_If_Item_Is_Last_In_This_Level(item.Tree_ID);
                    item.Tree_IsVisible = true;
                    item.Tree_IsExpanded = true;
                    item.Tree_HasChildren = LocalData.dynamic_List.Any(x => x.Tree_ParentID == item.Tree_ID);
                }



                //LocalData.dynamic_List.Single(x => x.Tree_ID == 5).Tree_IsExpanded = false;
                //LocalData.dynamic_List.Single(x => x.Tree_ID == 6).Tree_IsVisible = false;
                //LocalData.dynamic_List.Single(x => x.Tree_ID == 7).Tree_IsVisible = false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), MethodBase.GetCurrentMethod());
                //LocalFunctions.Display_Message(ex.ToString(), MethodBase.GetCurrentMethod());
            }

        }


        private void initialize_data()
        {

            List<TreeItem> tmp_list = new List<TreeItem>();

            tmp_list.Add(new TreeItem()
            {
                Tree_ID = 1,
                Tree_Level = 0,
                Tree_Column = "New York",
                Tree_ParentID = 0,
                Tree_SequenceNumber = 1,
            });


            tmp_list.Add(new TreeItem()
            {
                Tree_ID = 2,
                Tree_Level = 1,
                Tree_Column = "Brooklyn",
                Tree_ParentID = 1,
                Tree_SequenceNumber = 2,
            });


            tmp_list.Add(new TreeItem()
            {
                Tree_ID = 3,
                Tree_Level = 0,
                Tree_Column = "New Jersey",
                Tree_ParentID = 0,
                Tree_SequenceNumber = 3,
            });


            tmp_list.Add(new TreeItem()
            {
                Tree_ID = 4,
                Tree_Level = 1,
                Tree_Column = "Jersey City",
                Tree_ParentID = 3,
                Tree_SequenceNumber = 4,
            });
            tmp_list.Add(new TreeItem()
            {
                Tree_ID = 5,
                Tree_Level = 1,
                Tree_Column = "Newark",
                Tree_ParentID = 3,
                Tree_SequenceNumber = 5,
                Tree_IsExpanded = false,
            });



            tmp_list.Add(new TreeItem()
            {
                Tree_ID = 6,
                Tree_Level = 2,
                Tree_Column = "Upper Clinton Hill",
                Tree_ParentID = 5,
                Tree_SequenceNumber = 6,
            });

            tmp_list.Add(new TreeItem()
            {
                Tree_ID = 7,
                Tree_Level = 2,
                Tree_Column = "Lower Clinton Hill",
                Tree_ParentID = 5,
                Tree_SequenceNumber = 7,
            });


            tmp_list.Add(new TreeItem()
            {
                Tree_ID = 8,
                Tree_Level = 1,
                Tree_Column = "Union",
                Tree_ParentID = 3,
                Tree_SequenceNumber = 8,
            });

            PublicData.dynamic_Original_List = tmp_list.ToList<TreeItem>();
        }

    }
}
