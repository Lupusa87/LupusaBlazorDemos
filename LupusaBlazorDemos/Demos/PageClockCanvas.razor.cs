using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorClockCanvasComponent;
using BlazorClockCanvasComponent.Classes;

namespace LupusaBlazorDemos.Demos
{
    public partial class PageClockCanvas
    {

        City Curr_City = new City();


        List<City> Cities_List = new List<City>() {
              new City() { ID=1, Name = "New York", WidthAndHeight = 400, TimeDiff=0,
                DivClass ="position:relative; width:400px; height:400px;"},
            // new City() { ID=2, Name = "Tbilisi", WidthAndHeight = 400, TimeDiff=3},
            // new City() { ID=3, Name = "London", WidthAndHeight = 400, TimeDiff=1},
        };




        void Add_Clock()
        {
            if (Cities_List.Count == 5)
            {
                BCCCJsInterop.Alert("You can't add more than 5 clocks!");
                return;
            }

            if (string.IsNullOrEmpty(Curr_City.Name))
            {
                BCCCJsInterop.Alert("City name is required!");
            }
            else
            {



                if (Cities_List.Any())
                {
                    Curr_City.ID = Cities_List.Max(x => x.ID) + 1;
                }
                else
                {
                    Curr_City.ID = 1;

                }

                if (Curr_City.WidthAndHeight == 0)
                {
                    Curr_City.WidthAndHeight = 300;

                }

                Curr_City.DivClass = "position:relative; width:" + Curr_City.WidthAndHeight + "px; height:" + Curr_City.WidthAndHeight + "px;";


                Cities_List.Add(Curr_City);
                Curr_City = new City();


                this.StateHasChanged();
            }
        }




        protected override void OnAfterRender(bool firstRender)
        {

            //Console.WriteLine("       ------");
            //Console.WriteLine("onafterrender ");
            //foreach (var item in Cities_List)
            //{
            //    item.component1_related.Canvas_ID = item.component1_related.Canvas_ID;
            //    Console.WriteLine(item.Name + " " + item.component1_related.city.Name + " " + item.component1_related.Canvas_ID);
            //}
            //Console.WriteLine("       ------");

            //foreach (City city in Cities_List.Where(x => x.component1_related.IsSubscribedForOnDelete == false))
            //{

            //    city.component1_related.onDelete += HandleOnDelete;
            //    city.component1_related.IsSubscribedForOnDelete = true;
            //}



        }


        void RemoveComponent(int ID)
        {

            RemoveCity(ID);

        }

        void RemoveCity(City c)
        {

            Cities_List.Remove(c);
            this.StateHasChanged();

        }

        void RemoveCity(int ID)
        {

            City c = Cities_List.Single(X => X.ID == ID);

            RemoveCity(c);

        }


        void HandleOnDelete(object sender, EventArgs e)
        {
            RemoveCity(((CompClockCanvas)sender).city.ID);
        }

    }
}

