using BlazorChessComponent;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Demos
{
    public partial class PageGameChess
    {
        [Inject]
        IJSRuntime jsRuntime { get; set; }


      

        CompBlazorChess CompBlazorChess_Player;
        CompBlazorChess CompBlazorChess_Opposite;

        Timer timer_Game;


        protected override void OnInitialized()
        {
           
            BChessCJsInterop.jsRuntime = jsRuntime;

         

            base.OnInitialized();
        }


        protected override void OnAfterRender(bool firstRender)
        {

            CompBlazorChess_Player.MadeMove += PlayerMadeMoveCallback;
            CompBlazorChess_Opposite.MadeMove += OppositeMadeMoveCallback;

            CompBlazorChess_Player.GameOver += GameOverCallback;
            CompBlazorChess_Opposite.GameOver += GameOverCallback;


            if (firstRender)
            {
                timer_Game = new Timer(TimerGameCallback, null, 1000, 1000);
            }

            base.OnAfterRender(firstRender);

        }


        public void TimerGameCallback(object stateInfo)
        {

            CompBlazorChess_Player.TimerTick();
            CompBlazorChess_Opposite.TimerTick();

        }


        private void GameOverCallback()
        {
            if (timer_Game != null)
            {
                timer_Game.Dispose();

            }
        }




        private void PlayerMadeMoveCallback(string _move)
        {
            CompBlazorChess_Opposite.SetBoardOpacity(1.0);
            CompBlazorChess_Opposite.ChessEngine1.svlis_gaketeba_misamartidan(_move, CompBlazorChess_Opposite.ChessEngine1.OppositeColor);

        }


        private void OppositeMadeMoveCallback(string _move)
        {


            CompBlazorChess_Player.SetBoardOpacity(1.0);
            CompBlazorChess_Player.ChessEngine1.svlis_gaketeba_misamartidan(_move, CompBlazorChess_Player.ChessEngine1.OppositeColor);

        }
    }
}
