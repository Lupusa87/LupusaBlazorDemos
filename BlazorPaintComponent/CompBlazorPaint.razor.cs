using BlazorPaintComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPaintComponent
{
    public partial class CompBlazorPaint:IDisposable
    {

        public BPaintMode Curr_Mode = BPaintMode.none;


        public bool MultiSelect = true;

        protected double Curr_Scale_X = 1.0;
        protected double Curr_Scale_Y = 1.0;

        protected CompUsedColors Curr_CompUsedColors = new CompUsedColors();
        protected CompMySVG Curr_CompMySVG = new CompMySVG();


        public List<BPaintObject> ObjectsList = new List<BPaintObject>();


        protected string Color1 = "#ffffff";//"#fc3807";

        protected int LineWidth1 = 3;

        protected int StepSize = 5;


        protected int FigureCode = 1;


        protected override void OnInitialized()
        {
            BlazorWindowHelper.BlazorWindowHelper.Initialize();
            BlazorWindowHelper.BWHJsInterop.SetOnOrOff(true);
            BlazorWindowHelper.BlazorWindowHelper.OnScroll = OnScroll;
            BlazorWindowHelper.BlazorWindowHelper.OnResize = OnScroll;
            base.OnInitialized();
        }


        protected void OnScroll()
        {
            BPaintCJsInterop.UpdateSVGPosition("PaintArea1");
        }

        protected override void OnAfterRender(bool firstRender)
        {
         

            if (firstRender)
            {
                GetBoundingClientRect("PaintArea1");

                Curr_CompUsedColors.ActionColorClicked = ColorSelected;
            }

            base.OnAfterRender(firstRender);

        }


        private void ColorSelected(string a)
        {
            Color1 = a;

            if (Curr_Mode == BPaintMode.edit)
            {
                if (ObjectsList.Any())
                {
                    foreach (var item in ObjectsList.Where(x=>x.Selected))
                    {
                        item.Color = Color1;
                    }
                }
            }


            StateHasChanged();



        }



        protected void cmd_Size_Changed(ChangeEventArgs e)
        {
            if (e?.Value != null)
            {
                LineWidth1 = int.Parse(e.Value as string);

                if (Curr_Mode == BPaintMode.edit)
                {
                    if (ObjectsList.Any())
                    {
                        foreach (var item in ObjectsList.Where(x => x.Selected))
                        {
                            item.width = LineWidth1;
                        }
                    }
                }


                cmd_RefreshSVG();

            }
        }


        public void cmd_clear()
        {
            if (ObjectsList.Any())
            {
                ObjectsList = new List<BPaintObject>();
                cmd_RefreshSVG();
            }
        }


        public void cmd_undo()
        {
            if (ObjectsList.Any())
            {
                ObjectsList.Remove(ObjectsList.Last());
                cmd_RefreshSVG();
            }
        }


        public void cmd_onmousedown(MouseEventArgs e)
        {

            Curr_Mode = BPaintMode.draw;

            if (FigureCode == 1)
            {
                cmd_prepareDraw(e);
            }

            if (FigureCode == 2)
            {
                cmd_prepareLine(e);
            }

        }

        protected void cmd_scale_x(ChangeEventArgs e)
        {
            if (e?.Value != null)
            {
                Curr_Scale_X =double.Parse(e.Value as string);


               

                if (ObjectsList.Any())
                {

                    foreach (var item in ObjectsList.Where(x => x.Selected))
                    {
                        item.Scale.x = Curr_Scale_X;
                        item.Scale.y = Curr_Scale_Y;
                    }

                   

                    cmd_RefreshSVG();

                   
                }
            }
        }


        protected void cmd_scale_y(ChangeEventArgs e)
        {
            if (e?.Value != null)
            {
                Curr_Scale_Y = double.Parse(e.Value as string);




                if (ObjectsList.Any())
                {

                    foreach (var item in ObjectsList.Where(x => x.Selected))
                    {
                        item.Scale.x = Curr_Scale_X;
                        item.Scale.y = Curr_Scale_Y;
                    }



                    cmd_RefreshSVG();


                }
            }
        }


        public void cmd_prepareDraw(MouseEventArgs e)
        {
            MyPoint CurrPosition = new MyPoint(e.ClientX - LocalData.SVGPosition.x, e.ClientY - LocalData.SVGPosition.y);

            BPaintHandDraw new_BPaintHandDraw = new BPaintHandDraw();


            if (ObjectsList.Any())
            {
                new_BPaintHandDraw.ObjectID = ObjectsList.Max(x => x.ObjectID) + 1;

                cmd_Clear_Selection();
                cmd_Clear_Editing();
            }
            else
            {
                new_BPaintHandDraw.ObjectID = 1;
            }

            new_BPaintHandDraw.ObjectType = BPaintOpbjectType.HandDraw;
            new_BPaintHandDraw.Selected = true;
            new_BPaintHandDraw.EditMode = true;
            new_BPaintHandDraw.Color = Color1;
            new_BPaintHandDraw.width = LineWidth1;
            new_BPaintHandDraw.StartPosition = new MyPoint(CurrPosition.x, CurrPosition.y);
            new_BPaintHandDraw.data = new List<MyPoint>();
            

            ObjectsList.Add(new_BPaintHandDraw);

        }



        public void cmd_Clear_Selection()
        {
            foreach (var item in ObjectsList.Where(x => x.Selected))
            {
                item.Selected = false;
            }
        }

        public void cmd_Clear_Editing()
        {
            foreach (var item in ObjectsList.Where(x => x.EditMode))
            {
                item.EditMode = false;
            }
        }


        public void cmd_prepareLine(MouseEventArgs e)
        {
            MyPoint CurrPosition = new MyPoint(e.ClientX - LocalData.SVGPosition.x, e.ClientY - LocalData.SVGPosition.y);

            BPaintLine new_BPaintLine = new BPaintLine();


            if (ObjectsList.Any())
            {
                new_BPaintLine.ObjectID = ObjectsList.Max(x => x.ObjectID) + 1;


                cmd_Clear_Selection();
                cmd_Clear_Editing();
            }
            else
            {
                new_BPaintLine.ObjectID = 1;
            }


            new_BPaintLine.ObjectType = BPaintOpbjectType.Line;
            new_BPaintLine.Selected = true;
            new_BPaintLine.EditMode = true;
            new_BPaintLine.Color = Color1;
            new_BPaintLine.width = LineWidth1;
            new_BPaintLine.StartPosition = new MyPoint(CurrPosition.x, CurrPosition.y);
            new_BPaintLine.end = new_BPaintLine.StartPosition;
            ObjectsList.Add(new_BPaintLine);
        }


        public void cmd_onmousemove(MouseEventArgs e)
        {
            if (Curr_Mode == BPaintMode.draw)
            {
                if (ObjectsList.Any(x=>x.EditMode))
                {
                   
                    if (FigureCode == 1)
                    {
                        cmd_draw(e);
                    }

                    if (FigureCode == 2)
                    {
                        cmd_Line(e);
                    }
                }
            }
        }

        protected void cmd_unselect_all_objects()
        {
            cmd_select_all(false);
        }

        protected void cmd_select_all_objects()
        {
            cmd_select_all(true);
        }


        protected void cmd_select_all(bool b)
        {
            if (ObjectsList.Any())
            {

                foreach (var item in ObjectsList)
                {
                    item.Selected = b;
                }
            }
        }

        protected void cmd_delete_object()
        {
            if (ObjectsList.Any())
            {

                if (ObjectsList.Any(x => x.Selected))
                {

                    ObjectsList.Remove(ObjectsList.Where(x => x.Selected).First());
                    BPaintObject b = ObjectsList.Single(i => i.ObjectID == ObjectsList.Min(x => x.ObjectID));
                    b.Selected = true;

                    cmd_RefreshSVG();
                }

            }
        }


        protected void cmd_duplicate_object()
        {
            if (ObjectsList.Any())
            {

                if (ObjectsList.Any(x => x.Selected))
                {
                    BPaintObject old_o = ObjectsList.Where(x => x.Selected).First();


                   


                    foreach (var item in ObjectsList.Where(x => x.Selected))
                    {
                        item.Selected = false;
                    }

                    BPaintObject new_o = BPaintFunctions.CopyObject<BPaintObject>(old_o);
                    new_o.ObjectID = ObjectsList.Max(x => x.ObjectID) + 1;
                    new_o.Selected = true;
                    new_o.PositionChange.x += 20;
                    new_o.PositionChange.y += 20;
                    ObjectsList.Add(new_o);
                   
                    cmd_RefreshSVG();
                }

            }
        }



        public void cmd_draw(MouseEventArgs e)
        {
            if (ObjectsList.Any(x=>x.EditMode))
            {
                MyPoint CurrPosition = new MyPoint(e.ClientX - LocalData.SVGPosition.x,e.ClientY - LocalData.SVGPosition.y);


                BPaintHandDraw Curr_Object = (BPaintHandDraw)ObjectsList.Single(x => x.EditMode);

                if (Curr_Object.data.Any())
                {

                    MyPoint LastPoint = Curr_Object.data.Last();

                    if (LastPoint.x != CurrPosition.x || LastPoint.y != CurrPosition.y)
                    {
                        Curr_Object.data.Add(CurrPosition);
                        cmd_RefreshSVG();
                    }
                }
                else
                {
                    Curr_Object.data.Add(CurrPosition);
                    cmd_RefreshSVG();
                }
            }
        }

        public void cmd_Line(MouseEventArgs e)
        {
            if (ObjectsList.Any(x => x.EditMode))
            {
                MyPoint CurrPosition = new MyPoint(e.ClientX - LocalData.SVGPosition.x, e.ClientY - LocalData.SVGPosition.y);


                BPaintLine Curr_Object = (BPaintLine)ObjectsList.Single(x => x.EditMode);


                if (Curr_Object.end.x != CurrPosition.x || Curr_Object.end.y != CurrPosition.y)
                {
                    Curr_Object.end = CurrPosition;
                    cmd_RefreshSVG();
                }
            }
        }


        public void cmd_onmouseup(MouseEventArgs e)
        {
            Curr_Mode = BPaintMode.none;


            if (ObjectsList.Any())
            {
                BPaintObject o = ObjectsList.Single(x => x.EditMode == true);

                switch (o.ObjectType)
                {
                    case BPaintOpbjectType.HandDraw:


                        if (!(o as BPaintHandDraw).IsValid())
                        {
                            ObjectsList.Remove(o);
                        }

                        break;
                    case BPaintOpbjectType.Line:

                        if (!(o as BPaintLine).IsValid())
                        {
                            ObjectsList.Remove(o);
                        }

                        break;
                    default:
                        break;
                }

            }


            cmd_Clear_Editing();
            cmd_RefreshSVG();
        }


        public void cmd_RefreshSVG()
        {
            Curr_CompMySVG.Refresh();
            StateHasChanged();

        }



        protected void cmd_ColorChange(ChangeEventArgs e)
        {
            if (e?.Value != null)
            {
                Color1 = e.Value as string;

                if (Curr_CompUsedColors.UsedColors_List.Any(x => x == Color1))
                {
                    Curr_CompUsedColors.UsedColors_List.Remove(Curr_CompUsedColors.UsedColors_List.Single(x => x == Color1));
                }

                if (Curr_CompUsedColors.UsedColors_List.Count > 9)
                {
                    Curr_CompUsedColors.UsedColors_List.RemoveAt(0);
                }

                Curr_CompUsedColors.UsedColors_List.Add(Color1);


                Cmd_RefreshUsedColorsSVG();
            }
        }

        public void Cmd_RefreshUsedColorsSVG()
        {
            Curr_CompUsedColors.Refresh();
            StateHasChanged();
        }

        public void Dispose()
        {

        }



        


        protected void cmd_Move(BPaintMoveDirection Par_Direction)
        {

           

            if (ObjectsList.Any())
            {
       
                foreach (var item in ObjectsList.Where(x=>x.Selected))
                {

               

                switch (Par_Direction)
                {
                    case BPaintMoveDirection.left:
                        item.PositionChange.x -= StepSize;
                        break;
                    case BPaintMoveDirection.right:
                        item.PositionChange.x += StepSize;
                        break;
                    case BPaintMoveDirection.up:
                        item.PositionChange.y -= StepSize;
                        break;
                    case BPaintMoveDirection.down:
                        item.PositionChange.y += StepSize;
                        break;
                    default:
                        break;
                }

                }

                cmd_RefreshSVG();

            }
          
        }


        public void GetBoundingClientRect(string ElementID)
        {
            BPaintCJsInterop.GetElementBoundingClientRect(ElementID, DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public void invokeFromjs(string id, string par_x, string par_y)
        {
          LocalData.SVGPosition = new MyPoint(double.Parse(par_x),double.Parse(par_y));
            
        }

    }
}
