using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Demos
{
    public partial class PageBeep
    {

        bool AutoPlay = true;

        protected int _Volume = 50;
        protected int _Frequency = 500;
        protected int _Duration = 100;

        protected int CurrVolume
        {
            get
            {
                return _Volume;
            }

            set
            {
                _Volume = value;

                if (AutoPlay) CmdBeep();
            }
        }

        protected int CurrFrequency
        {
            get
            {
                return _Frequency;
            }

            set
            {
                _Frequency = value;

                if (AutoPlay) CmdBeep();
            }
        }

        protected int CurrDuration
        {
            get
            {
                return _Duration;
            }

            set
            {
                _Duration = value;

                if (AutoPlay) CmdBeep();
            }
        }



        public void CmdBeep()
        {
            LBDJsInterop.Beep(CurrVolume, CurrFrequency, CurrDuration);
        }


    }
}
