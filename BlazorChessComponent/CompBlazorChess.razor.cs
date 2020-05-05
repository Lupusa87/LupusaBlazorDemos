using BlazorChessComponent.Engine;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChessComponent
{
    public partial class CompBlazorChess: IDisposable
    {
        bool IsCompLoaded = false;

        [Parameter]
        public bool PlayerOrOpposite { get; set; } = true;

        [Parameter]
        public double BoardOpacity { get; set; } = 1.0;


        public string BoardBoorderColor ="#FFA500";


        public string PlayerTime="05:00";
        public string OppositeTime = "05:00";

        public Action<string> MadeMove;

        public Action GameOver;

        public ChessEngine ChessEngine1 = null;

        public string CompID = "Chess" + Guid.NewGuid().ToString("d").Substring(1, 4);
        public string RectID;
        public string PlayerTimerID;
        public string OppositeTimerID;


        protected override void OnInitialized()
        {
            
            RectID = "rect" + CompID;
            PlayerTimerID = "PlayerTimer" + CompID;
            OppositeTimerID = "OppositeTimer" + CompID;


        ChessEngine1 = new ChessEngine(PlayerOrOpposite);


            if (PlayerOrOpposite)
            {
                BoardBoorderColor = "Red";
            }
            else
            {
                BoardBoorderColor = "#FFA500"; 
            }


            if (ChessEngine1.compSettings.Curr_comp == null)
            {
                ChessEngine1.compSettings.Curr_comp = this;
            }


            ChessEngine1.MyCell.width = ChessEngine1.compSettings.CompHeight / 9;
            ChessEngine1.MyCell.height = ChessEngine1.compSettings.CompHeight / 9;


            ChessEngine1.MyCell_Moklulebi.width = 350 / 10.0;
            ChessEngine1.MyCell_Moklulebi.height = 150 / 4.4;


            base.OnInitialized();
        }


        protected override void OnAfterRender(bool firstRender)
        {
            if (IsCompLoaded == false)
            {
                ChessEngine1.GetBoundingClientRect(RectID);

                // ChessEngine1.StartTimer();
                IsCompLoaded = true;
            }


            base.OnAfterRender(firstRender);
        }

        public void Refresh()
        {
            if (IsCompLoaded)
            {
                StateHasChanged();
            }
        }

        public void cmd_a()
        {
            ChessEngine1.svlis_gaketeba_misamartidan("A7A6", 2);
        }

        public void cmd_Replay()
        {
            ChessEngine1.Cmd_Replay();
        }

        public void cmd_mouseDown(MouseEventArgs e)
        {
            ChessEngine1.cmd_mouseDown(e);
        }

        public void cmd_mouseUp(MouseEventArgs e)
        {
            //JsInterop.alert("a");
            // ChessEngine1.cmd_mouseUp(e);
        }

        public void cmd_mouseMove(MouseEventArgs e)
        {

            // ChessEngine1.cmd_mouseMove(e);
        }


        public void SetBoardOpacity(double p)
        {
            BoardOpacity = p;
            BoardBoorderColor = "Red";

            StateHasChanged();
        }


        public void Dispose()
        {

        }



        public void TimerTick()
        {
           
            ChessEngine1.Timertick();
        }

        public void NotifyMadeMove(string _move)
        {
            MadeMove?.Invoke(MyFunctions.reverseMove(_move));

            BoardOpacity = 0.8;
            BoardBoorderColor = "#FFA500";

            StateHasChanged();
        }


        public void NotifyGameOver()
        {
            GameOver?.Invoke();

            BoardOpacity = 1.0;
            BoardBoorderColor = "#FFA500";

            StateHasChanged();
        }


        public void Alert(string message)
        {
            BChessCJsInterop.alert(message);
        }
    }



}
