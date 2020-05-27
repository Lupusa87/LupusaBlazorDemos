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

        internal static g CmdCreateIconLine()
        {
            g g1 = new g
            {
               // height = LocalData.IconWithAndHeigth * 2,
               // width = LocalData.IconWithAndHeigth * 2
            };


            line line1 = new line();

            if (LocalData.IsLineDashed)
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

            line1.stroke_width = LocalData.LineStrokeThickness;
            line1.stroke = LocalData.LineColor.Name;

            if (LocalData.IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.DashArrayValue + ", " +LocalData.DashArrayValue;
            }

            g1.Children.Add(line1);

            return g1;

        }

        internal static g CmdCreateIconItem()
        {
            g g1 = new g
            {
                //height = LocalData.IconWithAndHeigth * 2,
                //width = LocalData.IconWithAndHeigth * 2
            };

            line line1 = new line();

            if (LocalData.IsLineDashed)
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


            line1.stroke_width = LocalData.LineStrokeThickness;
            line1.stroke = LocalData.LineColor.Name;

            if (LocalData.IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.DashArrayValue +" " + LocalData.DashArrayValue;
            }

            line line2 = new line();
            if (LocalData.IsLineDashed)
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

            line2.stroke_width = LocalData.LineStrokeThickness;
            line2.stroke = LocalData.LineColor.Name;

            if (LocalData.IsLineDashed)
            {
                line2.stroke_dasharray = LocalData.DashArrayValue +", "+ LocalData.DashArrayValue;
            }

            g1.Children.Add(line1);
            g1.Children.Add(line2);

            return g1;
            
        }


        internal static g CmdCreateIconLastItem()
        {
            g g1 = new g
            {
                //height = LocalData.IconWithAndHeigth * 2,
                //width = LocalData.IconWithAndHeigth * 2
            };

            line line1 = new line();

            if (LocalData.IsLineDashed)
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


            line1.stroke_width = LocalData.LineStrokeThickness;
            line1.stroke = LocalData.LineColor.Name;

            if (LocalData.IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.DashArrayValue +", " + LocalData.DashArrayValue;
            }

            line line2 = new line();

            if (LocalData.IsLineDashed)
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

            line2.stroke_width = LocalData.LineStrokeThickness;
            line2.stroke = LocalData.LineColor.Name; 

            if (LocalData.IsLineDashed)
            {
                line2.stroke_dasharray = LocalData.DashArrayValue + ", " + LocalData.DashArrayValue;
            }

            g1.Children.Add(line1);
            g1.Children.Add(line2);

            return g1;
        }


        internal static g CmdCreateIconMinusOrPlus(bool ParMinusOrPlus)
        {

            g g1 = new g
            {
                //height = LocalData.IconWithAndHeigth * 2,
                //width = LocalData.IconWithAndHeigth * 2
            };


            rect rectangle1 = new rect();
            rectangle1.onclick = "sas";
            rectangle1.height = LocalData.IconWithAndHeigth;
            rectangle1.width = LocalData.IconWithAndHeigth;



            rectangle1.stroke_width = LocalData.MinusOrPlusBorderStrokeThickness;
            rectangle1.stroke = LocalData.MinusOrPlusBorderColor.Name;
            rectangle1.fill = "white";


            rectangle1.rx = 4;
            rectangle1.ry = 4;

            rectangle1.x = 14;
            rectangle1.y = 12;

            g1.Children.Add(rectangle1);

            if (!ParMinusOrPlus)
            {
                line line2 = new line();
                //line2.onclick = "sas";
                //line2.id = "p"+DateTime.Now.Ticks;
                line2.x1 = 27;
                line2.y1 = 19;
                line2.x2 = 27;
                line2.y2 = 31;

                line2.stroke_width = LocalData.MinusOrPlusStrokeThickness;


                line2.stroke = LocalData.MinusOrPlusColor.Name;


                g1.Children.Add(line2);

            }

            line line1 = new line();
            //line1.onclick = "sas";
            //line1.id = "plus2";
            line1.x1 = 21;
            line1.y1 = 25;
            line1.x2 = 33;
            line1.y2 = 25;


            line1.stroke_width = LocalData.MinusOrPlusStrokeThickness;
            line1.stroke = LocalData.MinusOrPlusColor.Name;

            g1.Children.Add(line1);


            line line3 = new line();
            line3.x1 = 40;
            line3.y1 = 25;
            line3.x2 = 52;
            line3.y2 = 25;

            

            line3.stroke_width = LocalData.LineStrokeThickness;
            line3.stroke = Color.Red.Name;

            if (LocalData.IsLineDashed)
            {
                line3.stroke_dasharray = LocalData.DashArrayValue + ", " + LocalData.DashArrayValue;
            }

            g1.Children.Add(line3);
            
            return g1;
        }


        internal static g CmdCreateIconMinusOrPlusTop(bool ParMinusOrPlus)
        {

            g g1 = CmdCreateIconMinusOrPlus(ParMinusOrPlus);

           
            
            line line1 = new line();
            line1.x1 = 27;
            line1.y1 = 0;
            line1.x2 = 27;
            line1.y2 = 12;

            line1.stroke_width = LocalData.LineStrokeThickness;
            line1.stroke = LocalData.LineColor.Name;

            if (LocalData.IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.DashArrayValue + ", " + LocalData.DashArrayValue;
            }

            g1.Children.Add(line1);

            return g1;
            
        }


        internal static g CmdCreateIconMinusOrPlusBottom(bool ParMinusOrPlus)
        {
            g g1 = CmdCreateIconMinusOrPlus(ParMinusOrPlus);


            line line1 = new line();
            line1.x1 = 27;
            line1.y1 = 38;
            line1.x2 = 27;
            line1.y2 = 52;

            line1.stroke_width= LocalData.LineStrokeThickness;
            line1.stroke = LocalData.LineColor.Name;

            if (LocalData.IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.DashArrayValue + ", " + LocalData.DashArrayValue;
            }

            g1.Children.Add(line1);

            return g1;
        }

        internal static g CmdCreateIconMinusOrPlusTopBottom(bool ParMinusOrPlus)
        {
            g g1 = CmdCreateIconMinusOrPlus(ParMinusOrPlus);

            line line1 = new line();
            line1.x1 = 27;
            line1.y1 = 0;
            line1.x2 = 27;
            line1.y2 = 12;

           
            line1.stroke_width = LocalData.LineStrokeThickness;
            line1.stroke = LocalData.LineColor.Name;

            if (LocalData.IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.DashArrayValue + ", " + LocalData.DashArrayValue;
            }

            line line2 = new line();
            line2.x1 = 27;
            line2.y1 = 38;
            line2.x2 = 27;
            line2.y2 = 52;

            line2.stroke_width = LocalData.LineStrokeThickness;
            line2.stroke = LocalData.LineColor.Name;

            if (LocalData.IsLineDashed)
            {
                line2.stroke_dasharray = LocalData.DashArrayValue + ", " + LocalData.DashArrayValue;
            }

            g1.Children.Add(line1);
            g1.Children.Add(line2);


            return g1;
        }

        internal static bool CmdCheckIfItemIsLastInThisLevel(int ParID)
        {
            bool result = false;

            if (ParID > -1)
            {
                TreeItem Currdynamics = LocalData.dynamicList.Single(x => x.ID == ParID);

                if (Currdynamics.Level == 1)
                {
                    return true;
                }

                List<TreeItem> tmpList = LocalData.dynamicList.Where(x => x.ParentID == Currdynamics.ParentID).OrderBy(x => x.SequenceNumber).ToList();

                if (tmpList.Count > 0)
                {
                    if (ParID == tmpList[tmpList.Count - 1].ID)
                    {
                        return true;
                    }
                }
            }
            return result;
        }


        internal static svg CmdCreateDynamicIcon(TreeItem Pardynamic)
        {

            svg svg1 = new svg();
            svg1.id = Pardynamic.ID.ToString();
            svg1.width = Pardynamic.Level * LocalData.IconWithAndHeigth + 10;
            svg1.height = LocalData.IconWithAndHeigth;

          //  svg1.onclick = "aaa";


            g g1 = null;
           

           
            int TmpIconType = -1;

            #region DetectIconType
            if (Pardynamic.HasChildren)
            {
                if (Pardynamic.IsExpanded)
                {
                    TmpIconType = 0;
                }
                else
                {
                    TmpIconType = 1;
                }
            }
            else
            {
                if (Pardynamic.Level > 1)
                {
                    if (!Pardynamic.IsLastItemInLevel)
                    {
                        TmpIconType = 2;
                    }
                    else
                    {
                        TmpIconType = 3;
                    }
                }
                else
                {

                    TmpIconType = -1;
                }
            }
            #endregion



            if (TmpIconType > -1)
                {


                #region GetRelevantIcon
                switch (TmpIconType)
                {
                    case 0:
                        if (Pardynamic.Level > 1)
                        {
                            if (Pardynamic.IsLastItemInLevel)
                            {
                                g1 = LocalData.IconMinusTop;
                            }
                            else
                            {
                                g1 = LocalData.IconMinusTopBottom;
                            }
                        }
                        else
                        {
                            if (Pardynamic.IsLastItemInLevel)
                            {
                               g1 = LocalData.IconMinus;
                            }
                            else
                            {
                               g1 = LocalData.IconMinusBottom;
                            }
                        }
                        break;
                    case 1:
                        if (Pardynamic.Level > 1)
                        {
                            if (Pardynamic.IsLastItemInLevel)
                            {
                               g1 = LocalData.IconPlusTop;
                            }
                            else
                            {
                               g1 = LocalData.IconPlusTopBottom;
                            }
                        }
                        else
                        {
                            if (Pardynamic.IsLastItemInLevel)
                            {
                               g1 = LocalData.IconPlus;
                            }
                            else
                            {
                               g1 = LocalData.IconPlusBottom;
                            }
                        }
                        break;
                    case 2:
                        g1 = LocalData.IconItem;
                        break;
                    case 3:
                        g1 = LocalData.IconLastItem;
                        break;
                    default:
                        g1 = LocalData.IconMinus;
                        break;
                }
                #endregion


              
                g1.transform = "translate(" + (Pardynamic.Level * LocalData.IconWithAndHeigth - LocalData.IconWithAndHeigth) + ",0) scale(0.5, 0.5)";


                svg1.Children.Add(g1);
                }

            #region AddLinesIfNeeds
            if (Pardynamic.Level > 1)
            {
                for (int i = 1; i < Pardynamic.Level - 1; i++)
                {
                    int k = CmdGetParentIDBySteps(Pardynamic.ID, Pardynamic.Level - i - 1);
                    if (k > 0)
                    {
                        if (LocalData.dynamicList.Any(x => x.ID == k))
                        {
                            TreeItem tmpdynamics = LocalData.dynamicList.Single(x => x.ID == k);

                            if (!tmpdynamics.IsLastItemInLevel)
                            {
                                g g2 = LocalData.IconLine;


                                g2.transform = "translate(" + (i * LocalData.IconWithAndHeigth) + ",0) scale(0.5, 0.5)";

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


        private static int CmdGetParentIDBySteps(int ParID, int ParSteps)
        {
            int result = -1;
            int TmpID = ParID;

            //try
            //{
            for (int i = 0; i < ParSteps; i++)
            {
                if (LocalData.dynamicList.Any(x => x.ID == TmpID))
                {
                    TreeItem tmpdynamics = LocalData.dynamicList.Single(x => x.ID == TmpID);
                    result = tmpdynamics.ParentID;
                    TmpID = tmpdynamics.ParentID;
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


        public static void CmdChangeVisibility(int ParParentID, bool b, bool OneOrAllLevels)
        {
            try
            {
                foreach (TreeItem item in LocalData.dynamicList.Where(x => x.ParentID == ParParentID))
                {
                    item.IsVisible = b;

                    if (item.HasChildren)
                    {

                        if (OneOrAllLevels == true)
                        {
                            if (b)
                            {
                                if (item.IsExpanded == true)
                                {
                                    CmdChangeVisibility(item.ID, true, true);
                                }
                                else
                                {
                                    CmdChangeVisibility(item.ID, false, true);
                                }
                            }
                            else
                            {
                                CmdChangeVisibility(item.ID, b, OneOrAllLevels);
                            }
                        }
                        else
                        {
                            item.IsExpanded = b;
                            CmdChangeVisibility(item.ID, b, OneOrAllLevels);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + " " + MethodBase.GetCurrentMethod());
                //LocalFunctions.DisplayMessage(ex.ToString(), MethodBase.GetCurrentMethod());
            }
        }
    }
}
