using BlazorSvgHelper.Classes;
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
            g g1 = new g();

            line line1 = new line
            {
                x1 = LocalData.TreeIconBoxSize50,
                y1 = 0,
                x2 = LocalData.TreeIconBoxSize50,
                y2 = LocalData.VisualParams.TreeIconBoxSize,


                stroke_width = LocalData.VisualParams.LineStrokeThickness,
                stroke = LocalData.VisualParams.LineColor.Name
            };

            if (LocalData.VisualParams.IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.VisualParams.DashArrayValue + " " + LocalData.VisualParams.DashArrayValue;
            }

            g1.Children.Add(line1);

            return g1;

        }

        internal static g CmdCreateIconItem()
        {
            g g1 = new g();

            line line1 = new line
            {
                x1 = LocalData.TreeIconBoxSize50,
                y1 = 0,
                x2 = LocalData.TreeIconBoxSize50,
                y2 = LocalData.VisualParams.TreeIconBoxSize,



                stroke_width = LocalData.VisualParams.LineStrokeThickness,
                stroke = LocalData.VisualParams.LineColor.Name
            };

            if (LocalData.VisualParams.IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.VisualParams.DashArrayValue + " " + LocalData.VisualParams.DashArrayValue;
            }

            line line2 = new line
            {
                x1 = LocalData.TreeIconBoxSize50,
                y1 = LocalData.TreeIconBoxSize50,
                x2 = LocalData.VisualParams.TreeIconBoxSize,
                y2 = LocalData.TreeIconBoxSize50,


                stroke_width = LocalData.VisualParams.LineStrokeThickness,
                stroke = LocalData.VisualParams.LineColor.Name
            };

            if (LocalData.VisualParams.IsLineDashed)
            {
                line2.stroke_dasharray = LocalData.VisualParams.DashArrayValue + " " + LocalData.VisualParams.DashArrayValue;
            }

            g1.Children.Add(line1);
            g1.Children.Add(line2);

            return g1;

        }


        internal static g CmdCreateIconLastItem()
        {
            g g1 = new g();


            line line1 = new line
            {
                x1 = LocalData.TreeIconBoxSize50,
                y1 = 0,
                x2 = LocalData.TreeIconBoxSize50,
                y2 = LocalData.TreeIconBoxSize50,



                stroke_width = LocalData.VisualParams.LineStrokeThickness,
                stroke = LocalData.VisualParams.LineColor.Name
            };

            if (LocalData.VisualParams.IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.VisualParams.DashArrayValue + " " + LocalData.VisualParams.DashArrayValue;
            }

            line line2 = new line
            {
                x1 = LocalData.TreeIconBoxSize50,
                y1 = LocalData.TreeIconBoxSize50,
                x2 = LocalData.VisualParams.TreeIconBoxSize,
                y2 = LocalData.TreeIconBoxSize50,


                stroke_width = LocalData.VisualParams.LineStrokeThickness,
                stroke = LocalData.VisualParams.LineColor.Name
            };

            if (LocalData.VisualParams.IsLineDashed)
            {
                line2.stroke_dasharray = LocalData.VisualParams.DashArrayValue + " " + LocalData.VisualParams.DashArrayValue;
            }

            g1.Children.Add(line1);
            g1.Children.Add(line2);

            return g1;
        }


        internal static g CmdCreateIconMinusOrPlus(bool ParMinusOrPlus)
        {

            g g1 = new g
            {
                onclick = BoolOptionsEnum.Yes
            };

            rect rectangle1 = new rect
            {
                height = LocalData.TreeIconBoxSize50,
                width = LocalData.TreeIconBoxSize50,

                stroke_width = LocalData.VisualParams.MinusOrPlusBorderStrokeThickness,
                stroke = LocalData.VisualParams.MinusOrPlusBorderColor.Name,
                fill = "transparent",


                rx = LocalData.VisualParams.TreeIconBoxSize * 0.1,
                ry = LocalData.VisualParams.TreeIconBoxSize * 0.1,

                x = LocalData.TreeIconBoxSize25,
                y = LocalData.TreeIconBoxSize25
            };

            g1.Children.Add(rectangle1);

            if (!ParMinusOrPlus)
            {
                line line2 = new line
                {
                    x1 = LocalData.TreeIconBoxSize50,
                    y1 = LocalData.TreeIconBoxSize37,
                    x2 = LocalData.TreeIconBoxSize50,
                    y2 = LocalData.TreeIconBoxSize62,

                    stroke_width = LocalData.VisualParams.MinusOrPlusStrokeThickness,
                    stroke = LocalData.VisualParams.MinusOrPlusColor.Name
                };


                g1.Children.Add(line2);

            }

            line line1 = new line
            {
                x1 = LocalData.TreeIconBoxSize37,
                y1 = LocalData.TreeIconBoxSize50,
                x2 = LocalData.TreeIconBoxSize62,
                y2 = LocalData.TreeIconBoxSize50,


                stroke_width = LocalData.VisualParams.MinusOrPlusStrokeThickness,
                stroke = LocalData.VisualParams.MinusOrPlusColor.Name
            };

            g1.Children.Add(line1);


            line line3 = new line
            {
                x1 = LocalData.TreeIconBoxSize75,
                y1 = LocalData.TreeIconBoxSize50,
                x2 = LocalData.VisualParams.TreeIconBoxSize,
                y2 = LocalData.TreeIconBoxSize50,



                stroke_width = LocalData.VisualParams.LineStrokeThickness,
                stroke = Color.Red.Name
            };

            if (LocalData.VisualParams.IsLineDashed)
            {
                line3.stroke_dasharray = LocalData.VisualParams.DashArrayValue + " " + LocalData.VisualParams.DashArrayValue;
            }

            g1.Children.Add(line3);

            return g1;
        }


        internal static g CmdCreateIconMinusOrPlusTop(bool ParMinusOrPlus)
        {

            g g1 = CmdCreateIconMinusOrPlus(ParMinusOrPlus);



            line line1 = new line
            {
                x1 = LocalData.TreeIconBoxSize50,
                y1 = 0,
                x2 = LocalData.TreeIconBoxSize50,
                y2 = LocalData.TreeIconBoxSize25,

                stroke_width = LocalData.VisualParams.LineStrokeThickness,
                stroke = LocalData.VisualParams.LineColor.Name
            };

            if (LocalData.VisualParams.IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.VisualParams.DashArrayValue + " " + LocalData.VisualParams.DashArrayValue;
            }

            g1.Children.Add(line1);

            return g1;

        }


        internal static g CmdCreateIconMinusOrPlusBottom(bool ParMinusOrPlus)
        {
            g g1 = CmdCreateIconMinusOrPlus(ParMinusOrPlus);


            line line1 = new line
            {
                x1 = LocalData.TreeIconBoxSize50,
                y1 = LocalData.TreeIconBoxSize75,
                x2 = LocalData.TreeIconBoxSize50,
                y2 = LocalData.VisualParams.TreeIconBoxSize,

                stroke_width = LocalData.VisualParams.LineStrokeThickness,
                stroke = LocalData.VisualParams.LineColor.Name
            };

            if (LocalData.VisualParams.IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.VisualParams.DashArrayValue + " " + LocalData.VisualParams.DashArrayValue;
            }

            g1.Children.Add(line1);

            return g1;
        }

        internal static g CmdCreateIconMinusOrPlusTopBottom(bool ParMinusOrPlus)
        {
            g g1 = CmdCreateIconMinusOrPlus(ParMinusOrPlus);

            line line1 = new line
            {
                x1 = LocalData.TreeIconBoxSize50,
                y1 = 0,
                x2 = LocalData.TreeIconBoxSize50,
                y2 = LocalData.TreeIconBoxSize25,


                stroke_width = LocalData.VisualParams.LineStrokeThickness,
                stroke = LocalData.VisualParams.LineColor.Name
            };

            if (LocalData.VisualParams.IsLineDashed)
            {
                line1.stroke_dasharray = LocalData.VisualParams.DashArrayValue + " " + LocalData.VisualParams.DashArrayValue;
            }

            line line2 = new line
            {
                x1 = LocalData.TreeIconBoxSize50,
                y1 = LocalData.TreeIconBoxSize75,
                x2 = LocalData.TreeIconBoxSize50,
                y2 = LocalData.VisualParams.TreeIconBoxSize,

                stroke_width = LocalData.VisualParams.LineStrokeThickness,
                stroke = LocalData.VisualParams.LineColor.Name
            };

            if (LocalData.VisualParams.IsLineDashed)
            {
                line2.stroke_dasharray = LocalData.VisualParams.DashArrayValue + " " + LocalData.VisualParams.DashArrayValue;
            }

            g1.Children.Add(line1);
            g1.Children.Add(line2);


            return g1;
        }

        internal static bool CmdCheckIfItemIsLastInThisLevel(List<TreeItem> SourceList, int ParID)
        {
            bool result = false;

            if (ParID > -1)
            {
                TreeItem Currdynamics = SourceList.Single(x => x.ID == ParID);

                if (Currdynamics.Level == 1)
                {
                    return true;
                }

                List<TreeItem> tmpList = SourceList.Where(x => x.ParentID == Currdynamics.ParentID).OrderBy(x => x.SequenceNumber).ToList();

                if (tmpList.Count > 0)
                {
                    if (ParID == tmpList[^1].ID)
                    {
                        return true;
                    }
                }
            }
            return result;
        }


        internal static svg CmdCreateDynamicIcon(List<TreeItem> SourceList, TreeItem Pardynamic)
        {

            svg svg1 = new svg
            {
                id = Pardynamic.ID.ToString(),
                width = Pardynamic.Level * LocalData.VisualParams.TreeIconBoxSize,
                height = LocalData.VisualParams.TreeIconBoxSize
            };

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

                g1.transform = "translate(" + (Pardynamic.Level * LocalData.VisualParams.TreeIconBoxSize - LocalData.VisualParams.TreeIconBoxSize) + ",0)";


                svg1.Children.Add(g1);
            }

            #region AddLinesIfNeeds
            if (Pardynamic.Level > 1)
            {
                for (int i = 1; i < Pardynamic.Level - 1; i++)
                {
                    int k = CmdGetParentIDBySteps(SourceList, Pardynamic.ID, Pardynamic.Level - i - 1);
                    if (k > 0)
                    {
                        if (SourceList.Any(x => x.ID == k))
                        {
                            TreeItem tmpdynamics = SourceList.Single(x => x.ID == k);

                            if (!tmpdynamics.IsLastItemInLevel)
                            {
                                g g2 = LocalData.IconLine;


                                g2.transform = "translate(" + (i * LocalData.VisualParams.TreeIconBoxSize) + ",0)";

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


        private static int CmdGetParentIDBySteps(List<TreeItem> SourceList, int ParID, int ParSteps)
        {
            int result = -1;
            int TmpID = ParID;


            for (int i = 0; i < ParSteps; i++)
            {
                if (SourceList.Any(x => x.ID == TmpID))
                {
                    TreeItem tmpdynamics = SourceList.Single(x => x.ID == TmpID);
                    result = tmpdynamics.ParentID;
                    TmpID = tmpdynamics.ParentID;
                }
                else
                {
                    return -1;
                }
            }



            return result;
        }


        public static void CmdChangeVisibility(List<TreeItem> SourceList, int ParParentID, bool b, bool OneOrAllLevels)
        {
            try
            {
                foreach (TreeItem item in SourceList.Where(x => x.ParentID == ParParentID))
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
                                    CmdChangeVisibility(SourceList, item.ID, true, true);
                                }
                                else
                                {
                                    CmdChangeVisibility(SourceList, item.ID, false, true);
                                }
                            }
                            else
                            {
                                CmdChangeVisibility(SourceList, item.ID, b, OneOrAllLevels);
                            }
                        }
                        else
                        {
                            item.IsExpanded = b;
                            CmdChangeVisibility(SourceList, item.ID, b, OneOrAllLevels);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PrintError(ex.Message, MethodBase.GetCurrentMethod());
            }
        }


        public static void PrintError(string pError, MethodBase pMethod)
        {

            Console.WriteLine("Error:" + pError + " in " + getMethodName(pMethod));

        }

        public static string getMethodName(MethodBase Par_Method)
        {
            return Par_Method.Name + "." + Par_Method.DeclaringType.FullName;
        }

        public static string CmdGetUniqueID()
        {

            string a = DateTime.Now.Ticks.ToString();

            return a.Substring(a.Length - 4, 4) + Guid.NewGuid().ToString("d").Substring(1, 4);
        }

    }
}
