using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Demos
{
    public partial class PageDragAndDrop
    {

        [Inject]
        private IJSRuntime jsRuntime { get; set; }

        public List<MyDraggable> listDraggable = new List<MyDraggable>();

        public List<MyDragTarget> listDragTarget = new List<MyDragTarget>();

        protected override void OnInitialized()
        {

            for (int i = 0; i < 3; i++)
            {
                listDragTarget.Add(new MyDragTarget
                {
                    ID = listDragTarget.Count,
                    ElementID = "DropTargetdDiv" + listDragTarget.Count,

                });
            }

            foreach (var item in listDragTarget)
            {
                for (int i = 0; i < 5; i++)
                {
                    AddItem(item.ID);
                }
            }


            base.OnInitialized();
        }


        private void AddItem(int parentID)
        {
            int _id = listDraggable.Count + 1;
            listDraggable.Add(new MyDraggable
            {
                ID = _id,
                Name = "item" + _id,
                ElementID = "draggableDiv" + _id,
                ParentID = parentID,
            });
        }


        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                RegisterJsEvents();
            }


            base.OnAfterRender(firstRender);
        }

        public void RegisterJsEvents()
        {
            foreach (var item in listDragTarget)
            {
                LBDJsInterop.HandleDrop(jsRuntime, item.ElementID, item.ID, DotNetObjectReference.Create(this));
            }
        }


        public void OnMouseDown(MouseEventArgs e, MyDraggable item)
        {
            LBDJsInterop.HandleDrag(jsRuntime, item.ElementID, item.ID, DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public void InvokeDragStartFromJS(int id)
        {
            //if you need to know for some reason when drag is started this method will be invoked
        }

        [JSInvokable]
        public void InvokeDropFromJS(object args)
        {
           
            string[] a = args.ToString().Replace("[", null).Replace("]", null).Replace("\"", null).Split(",");

            int parentID = int.Parse(a[0]);
            int id = int.Parse(a[1]);
           
            if (listDraggable.Any(x => x.ID == id))
            {
                listDraggable.Single(x => x.ID == id).ParentID = parentID;

                StateHasChanged();
            }
        }

    }


    public class MyDraggable
    {

        public int ID { get; set; }

        public string ElementID { get; set; }
        public string Name { get; set; }
        public int ParentID { get; set; }
    }

    public class MyDragTarget
    {

        public int ID { get; set; }

        public string ElementID { get; set; }
    }
}
