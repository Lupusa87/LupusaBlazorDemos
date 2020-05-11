using BlazorScrollbarComponent;
using BlazorScrollbarComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Demos
{
    public partial class PageScrollbar
    {
        [Inject]
        private IJSRuntime jsRuntime { get; set; }

        public CompBlazorScrollbar CompBlazorScrollbar1;
        public CompBlazorScrollbar CompBlazorScrollbar2;

        public int P1 = 0;
        public int P2 = 0;

        private bool FirtsLoad = true;
        public BsbSettings bsbSettings1 { get; set; } = new BsbSettings();

        public BsbSettings bsbSettings2 { get; set; } = new BsbSettings();


        protected override void OnInitialized()
        {

            BScrollbarCJsInterop.jsRuntime = jsRuntime;

            bsbSettings1 = new BsbSettings("VericalScroll")
            {
                VerticalOrHorizontal = true,
                width = 15,
                height = 200,
                ScrollVisibleSize = 100,
                ScrollTotalSize = 1000,
                //bsbStyle = new BsbStyle
                //{
                //    ThumbWayColor = "lightgreen",
                //    ThumbColor = "red",
                //    ButtonColor = "green"
                //}

            };
            bsbSettings1.initialize();


            bsbSettings2 = new BsbSettings("HorizontalScroll")
            {
                VerticalOrHorizontal = false,
                width = 200,
                height = 15,
                ScrollVisibleSize = 400,
                ScrollTotalSize = 1000,
                //bsbStyle = new BsbStyle
                //{
                //    ThumbWayColor = "lightgreen",
                //    ThumbColor = "red",
                //    ButtonColor = "green"
                //}
            };
            bsbSettings2.initialize();


            base.OnInitialized();
        }


        protected override void OnAfterRender(bool firstRender)
        {
            if (FirtsLoad)
            {
                FirtsLoad = false;
                CompBlazorScrollbar1.OnPositionChange = OnPositionChanged1;
                CompBlazorScrollbar2.OnPositionChange = OnPositionChanged2;

            }

            base.OnAfterRender(firstRender);

        }


        private void OnPositionChanged1(double p)
        {

            P1 = (int)p;
            StateHasChanged();
        }

        private void OnPositionChanged2(double p)
        {
            P2 = (int)p;

            StateHasChanged();
        }

        public void Cmd1()
        {

            CompBlazorScrollbar1.SetScrollTotalWidth(1200);

            Cmd2();


        }

        public void Cmd2()
        {
            CompBlazorScrollbar1.SetScrollPosition(10);

        }

    }
}
