using BlazorSvgHelper.Classes.SubClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorTreeVisualizerComponent
{
    internal static class LocalTreeFunctions
    {

        internal static g Cmd_Create_Icon_Line()
        {
            g g1 = new g
            {
               // height = LocalData.My_Tree_Icon_With_And_Heigth * 2,
               // width = LocalData.My_Tree_Icon_With_And_Heigth * 2
            };


            line line1 = new line();

            if (LocalData.My_IsLineDashed)
            {
                line1.x1 = 27;
                line1.y1 = 2;
                line1.x2 = 27;
                line1.y2 = 50;
            }
            else
            {
                line1.x1 = 27;
                line1.y1 = 0;
                line1.x2 = 27;
                line1.y2 = 52;
            }

            line1.stroke_width = LocalData.MyTree_Line_StrokeThickness;
            line1.stroke = LocalData.MyTree_Line_Color.Name;

            if (LocalData.My_IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.My_DashArray_Value + ", " +LocalData.My_DashArray_Value;
            }

            g1.Children.Add(line1);

            return g1;

        }

        internal static g Cmd_Create_Icon_Item()
        {
            g g1 = new g
            {
                //height = LocalData.My_Tree_Icon_With_And_Heigth * 2,
                //width = LocalData.My_Tree_Icon_With_And_Heigth * 2
            };

            line line1 = new line();

            if (LocalData.My_IsLineDashed)
            {
                line1.x1 = 27;
                line1.y1 = 2;
                line1.x2 = 27;
                line1.y2 = 52;
            }
            else
            {
                line1.x1 = 27;
                line1.y1 = 0;
                line1.x2 = 27;
                line1.y2 = 52;
            }


            line1.stroke_width = LocalData.MyTree_Line_StrokeThickness;
            line1.stroke = LocalData.MyTree_Line_Color.Name;

            if (LocalData.My_IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.My_DashArray_Value +" " + LocalData.My_DashArray_Value;
            }

            line line2 = new line();
            if (LocalData.My_IsLineDashed)
            {
                line2.x1 = 32;
                line2.y1 = 27;
                line2.x2 = 48;
                line2.y2 = 27;
            }
            else
            {
                line2.x1 = 27;
                line2.y1 = 27;
                line2.x2 = 48;
                line2.y2 = 27;
            }

            line2.stroke_width = LocalData.MyTree_Line_StrokeThickness;
            line2.stroke = LocalData.MyTree_Line_Color.Name;

            if (LocalData.My_IsLineDashed)
            {
                line2.stroke_dasharray = LocalData.My_DashArray_Value +", "+ LocalData.My_DashArray_Value;
            }

            g1.Children.Add(line1);
            g1.Children.Add(line2);

            return g1;
            
        }


        internal static g Cmd_Create_Icon_LastItem()
        {
            g g1 = new g
            {
                //height = LocalData.My_Tree_Icon_With_And_Heigth * 2,
                //width = LocalData.My_Tree_Icon_With_And_Heigth * 2
            };

            line line1 = new line();

            if (LocalData.My_IsLineDashed)
            {
                line1.x1 = 27;
                line1.y1 = 2;
                line1.x2 = 27;
                line1.y2 = 28;
            }
            else
            {
                line1.x1 = 27;
                line1.y1 = 0;
                line1.x2 = 27;
                line1.y2 = 28;
            }


            line1.stroke_width = LocalData.MyTree_Line_StrokeThickness;
            line1.stroke = LocalData.MyTree_Line_Color.Name;

            if (LocalData.My_IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.My_DashArray_Value +", " + LocalData.My_DashArray_Value;
            }

            line line2 = new line();

            if (LocalData.My_IsLineDashed)
            {
                line2.x1 = 32;
                line2.y1 = 27;
                line2.x2 = 48;
                line2.y2 = 27;
            }
            else
            {
                line2.x1 = 27;
                line2.y1 = 27;
                line2.x2 = 48;
                line2.y2 = 27;
            }

            line2.stroke_width = LocalData.MyTree_Line_StrokeThickness;
            line2.stroke = LocalData.MyTree_Line_Color.Name; 

            if (LocalData.My_IsLineDashed)
            {
                line2.stroke_dasharray = LocalData.My_DashArray_Value + ", " + LocalData.My_DashArray_Value;
            }

            g1.Children.Add(line1);
            g1.Children.Add(line2);

            return g1;
        }


        internal static g Cmd_Create_Icon_Minus_Or_Plus(bool Par_Minus_Or_Plus)
        {

            g g1 = new g
            {
                //height = LocalData.My_Tree_Icon_With_And_Heigth * 2,
                //width = LocalData.My_Tree_Icon_With_And_Heigth * 2
            };


            rect rectangle_1 = new rect();
            rectangle_1.onclick = "sas";
            rectangle_1.height = LocalData.My_Tree_Icon_With_And_Heigth;
            rectangle_1.width = LocalData.My_Tree_Icon_With_And_Heigth;



            rectangle_1.stroke_width = LocalData.MyTree_MinusOrPlus_Border_StrokeThickness;
            rectangle_1.stroke = LocalData.MyTree_MinusOrPlus_Border_Color.Name;
            rectangle_1.fill = "white";


            rectangle_1.rx = 4;
            rectangle_1.ry = 4;

            rectangle_1.x = 14;
            rectangle_1.y = 12;

            g1.Children.Add(rectangle_1);

            if (!Par_Minus_Or_Plus)
            {
                line line2 = new line();
                //line2.onclick = "sas";
                //line2.id = "p"+DateTime.Now.Ticks;
                line2.x1 = 27;
                line2.y1 = 19;
                line2.x2 = 27;
                line2.y2 = 31;

                line2.stroke_width = LocalData.MyTree_MinusOrPlus_StrokeThickness;


                line2.stroke = LocalData.MyTree_MinusOrPlus_Color.Name;


                g1.Children.Add(line2);

            }

            line line1 = new line();
            //line1.onclick = "sas";
            //line1.id = "plus2";
            line1.x1 = 21;
            line1.y1 = 25;
            line1.x2 = 33;
            line1.y2 = 25;


            line1.stroke_width = LocalData.MyTree_MinusOrPlus_StrokeThickness;
            line1.stroke = LocalData.MyTree_MinusOrPlus_Color.Name;

            g1.Children.Add(line1);


            line line3 = new line();
            line3.x1 = 40;
            line3.y1 = 25;
            line3.x2 = 52;
            line3.y2 = 25;

            

            line3.stroke_width = LocalData.MyTree_Line_StrokeThickness;
            line3.stroke = Color.Red.Name;

            if (LocalData.My_IsLineDashed)
            {
                line3.stroke_dasharray = LocalData.My_DashArray_Value + ", " + LocalData.My_DashArray_Value;
            }

            g1.Children.Add(line3);
            
            return g1;
        }


        internal static g Cmd_Create_Icon_Minus_Or_Plus_Top(bool Par_Minus_Or_Plus)
        {

            g g1 = Cmd_Create_Icon_Minus_Or_Plus(Par_Minus_Or_Plus);

           
            
            line line1 = new line();
            line1.x1 = 27;
            line1.y1 = 0;
            line1.x2 = 27;
            line1.y2 = 12;

            line1.stroke_width = LocalData.MyTree_Line_StrokeThickness;
            line1.stroke = LocalData.MyTree_Line_Color.Name;

            if (LocalData.My_IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.My_DashArray_Value + ", " + LocalData.My_DashArray_Value;
            }

            g1.Children.Add(line1);

            return g1;
            
        }


        internal static g Cmd_Create_Icon_Minus_Or_Plus_Bottom(bool Par_Minus_Or_Plus)
        {
            g g1 = Cmd_Create_Icon_Minus_Or_Plus(Par_Minus_Or_Plus);


            line line1 = new line();
            line1.x1 = 27;
            line1.y1 = 38;
            line1.x2 = 27;
            line1.y2 = 52;

            line1.stroke_width= LocalData.MyTree_Line_StrokeThickness;
            line1.stroke = LocalData.MyTree_Line_Color.Name;

            if (LocalData.My_IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.My_DashArray_Value + ", " + LocalData.My_DashArray_Value;
            }

            g1.Children.Add(line1);

            return g1;
        }

        internal static g Cmd_Create_Icon_Minus_Or_Plus_Top_Bottom(bool Par_Minus_Or_Plus)
        {
            g g1 = Cmd_Create_Icon_Minus_Or_Plus(Par_Minus_Or_Plus);

            line line1 = new line();
            line1.x1 = 27;
            line1.y1 = 0;
            line1.x2 = 27;
            line1.y2 = 12;

           
            line1.stroke_width = LocalData.MyTree_Line_StrokeThickness;
            line1.stroke = LocalData.MyTree_Line_Color.Name;

            if (LocalData.My_IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.My_DashArray_Value + ", " + LocalData.My_DashArray_Value;
            }

            line line2 = new line();
            line2.x1 = 27;
            line2.y1 = 38;
            line2.x2 = 27;
            line2.y2 = 52;

            line2.stroke_width = LocalData.MyTree_Line_StrokeThickness;
            line2.stroke = LocalData.MyTree_Line_Color.Name;

            if (LocalData.My_IsLineDashed)
            {
                line2.stroke_dasharray = LocalData.My_DashArray_Value + ", " + LocalData.My_DashArray_Value;
            }

            g1.Children.Add(line1);
            g1.Children.Add(line2);


            return g1;
        }

        internal static bool Cmd_Check_If_Item_Is_Last_In_This_Level(int Par_ID)
        {
            bool result = false;

            if (Par_ID > -1)
            {
                TreeItem Curr_dynamics = LocalData.dynamic_List.Single(x => x.Tree_ID == Par_ID);

                if (Curr_dynamics.Tree_Level == 1)
                {
                    return true;
                }

                List<TreeItem> tmp_List = LocalData.dynamic_List.Where(x => x.Tree_ParentID == Curr_dynamics.Tree_ParentID).OrderBy(x => x.Tree_SequenceNumber).ToList();

                if (tmp_List.Count > 0)
                {
                    if (Par_ID == tmp_List[tmp_List.Count - 1].Tree_ID)
                    {
                        return true;
                    }
                }
            }
            return result;
        }


        internal static svg Cmd_Create_Dynamic_Icon(TreeItem Par_dynamic)
        {

            svg svg1 = new svg();
            svg1.id = Par_dynamic.Tree_ID.ToString();
            svg1.width = Par_dynamic.Tree_Level * LocalData.My_Tree_Icon_With_And_Heigth + 10;
            svg1.height = LocalData.My_Tree_Icon_With_And_Heigth;

          //  svg1.onclick = "aaa";


            g g1 = null;
           

           
            int Tmp_IconType = -1;

            #region Detect_Icon_Type
            if (Par_dynamic.Tree_HasChildren)
            {
                if (Par_dynamic.Tree_IsExpanded)
                {
                    Tmp_IconType = 0;
                }
                else
                {
                    Tmp_IconType = 1;
                }
            }
            else
            {
                if (Par_dynamic.Tree_Level > 1)
                {
                    if (!Par_dynamic.Tree_IsLastItemInLevel)
                    {
                        Tmp_IconType = 2;
                    }
                    else
                    {
                        Tmp_IconType = 3;
                    }
                }
                else
                {

                    Tmp_IconType = -1;
                }
            }
            #endregion



            if (Tmp_IconType > -1)
                {


                #region Get_Relevant_Icon
                switch (Tmp_IconType)
                {
                    case 0:
                        if (Par_dynamic.Tree_Level > 1)
                        {
                            if (Par_dynamic.Tree_IsLastItemInLevel)
                            {
                                g1 = LocalData.Tree_Icon_Minus_Top;
                            }
                            else
                            {
                                g1 = LocalData.Tree_Icon_Minus_Top_Bottom;
                            }
                        }
                        else
                        {
                            if (Par_dynamic.Tree_IsLastItemInLevel)
                            {
                               g1 = LocalData.Tree_Icon_Minus;
                            }
                            else
                            {
                               g1 = LocalData.Tree_Icon_Minus_Bottom;
                            }
                        }
                        break;
                    case 1:
                        if (Par_dynamic.Tree_Level > 1)
                        {
                            if (Par_dynamic.Tree_IsLastItemInLevel)
                            {
                               g1 = LocalData.Tree_Icon_Plus_Top;
                            }
                            else
                            {
                               g1 = LocalData.Tree_Icon_Plus_Top_Bottom;
                            }
                        }
                        else
                        {
                            if (Par_dynamic.Tree_IsLastItemInLevel)
                            {
                               g1 = LocalData.Tree_Icon_Plus;
                            }
                            else
                            {
                               g1 = LocalData.Tree_Icon_Plus_Bottom;
                            }
                        }
                        break;
                    case 2:
                        g1 = LocalData.Tree_Icon_Item;
                        break;
                    case 3:
                        g1 = LocalData.Tree_Icon_LastItem;
                        break;
                    default:
                        g1 = LocalData.Tree_Icon_Minus;
                        break;
                }
                #endregion


              
                g1.transform = "translate(" + (Par_dynamic.Tree_Level * LocalData.My_Tree_Icon_With_And_Heigth - LocalData.My_Tree_Icon_With_And_Heigth) + ",0) scale(0.5, 0.5)";


                svg1.Children.Add(g1);
                }

            #region Add_Lines_If_Needs
            if (Par_dynamic.Tree_Level > 1)
            {
                for (int i = 1; i < Par_dynamic.Tree_Level - 1; i++)
                {
                    int k = Cmd_Get_ParentID_By_Steps(Par_dynamic.Tree_ID, Par_dynamic.Tree_Level - i - 1);
                    if (k > 0)
                    {
                        if (LocalData.dynamic_List.Any(x => x.Tree_ID == k))
                        {
                            TreeItem tmp_dynamics = LocalData.dynamic_List.Single(x => x.Tree_ID == k);

                            if (!tmp_dynamics.Tree_IsLastItemInLevel)
                            {
                                g g2 = LocalData.Tree_Icon_Line;


                                g2.transform = "translate(" + (i * LocalData.My_Tree_Icon_With_And_Heigth) + ",0) scale(0.5, 0.5)";

                                svg1.Children.Add(g2);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            #endregion




            return svg1;
        }


        private static int Cmd_Get_ParentID_By_Steps(int Par_ID, int Par_Steps)
        {
            int result = -1;
            int Tmp_ID = Par_ID;

            //try
            //{
            for (int i = 0; i < Par_Steps; i++)
            {
                if (LocalData.dynamic_List.Any(x => x.Tree_ID == Tmp_ID))
                {
                    TreeItem tmp_dynamics = LocalData.dynamic_List.Single(x => x.Tree_ID == Tmp_ID);
                    result = tmp_dynamics.Tree_ParentID;
                    Tmp_ID = tmp_dynamics.Tree_ParentID;
                }
                else
                {
                    return -1;
                }
            }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(this.GetType().Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.ToString());
            //}


            return result;
        }


        public static void Cmd_ChangeVisibility(int Par_ParentID, bool b, bool One_Or_All_Levels)
        {
            try
            {
                foreach (TreeItem item in LocalData.dynamic_List.Where(x => x.Tree_ParentID == Par_ParentID))
                {
                    item.Tree_IsVisible = b;

                    if (item.Tree_HasChildren)
                    {

                        if (One_Or_All_Levels == true)
                        {
                            if (b)
                            {
                                if (item.Tree_IsExpanded == true)
                                {
                                    Cmd_ChangeVisibility(item.Tree_ID, true, true);
                                }
                                else
                                {
                                    Cmd_ChangeVisibility(item.Tree_ID, false, true);
                                }
                            }
                            else
                            {
                                Cmd_ChangeVisibility(item.Tree_ID, b, One_Or_All_Levels);
                            }
                        }
                        else
                        {
                            item.Tree_IsExpanded = b;
                            Cmd_ChangeVisibility(item.Tree_ID, b, One_Or_All_Levels);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + " " + MethodBase.GetCurrentMethod());
                //LocalFunctions.Display_Message(ex.ToString(), MethodBase.GetCurrentMethod());
            }
        }
    }
}
