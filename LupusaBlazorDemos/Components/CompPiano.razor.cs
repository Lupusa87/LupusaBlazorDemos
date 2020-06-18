using BlazorWindowHelper;
using BlazorWindowHelper.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Components
{
    public partial class CompPiano
    {

        string CurrentKey = string.Empty;


        [Parameter]
        public int Volume { get; set; }

        List<KeyNote> Keys = new List<KeyNote> {
            new KeyNote { freq = 523, letter = 'a' },
            new KeyNote { freq = 587, letter = 's' },
            new KeyNote { freq = 659, letter = 'd' },
            new KeyNote { freq = 698, letter = 'f' },
            new KeyNote { freq = 783, letter = 'g' },
            new KeyNote { freq = 880, letter = 'h' },
            new KeyNote { freq = 987, letter = 'j' }
        };

        

        protected override void OnInitialized()
        {


            BWHJsInterop.SetOnOrOff(true);
            BWHKeyboardHelper.OnKeyDown = KeyDownFromJS;
            BWHKeyboardHelper.OnKeyUp = KeyUpFromJS;

            base.OnInitialized();
        }


        public void Play(KeyNote key)
        {
            ReleaseKeys();
            key.IsPressed = true;
            LBDJsInterop.PianoPlay(Volume,key.freq);
        }


        public void Stop()
        {
            LBDJsInterop.PianoStop();
            ReleaseKeys();
            
        }


        public void KeyDownFromJS(BWHKeyboardState keyboardState)
        {
            
            string letter = keyboardState.consoleKey.ToString().ToLower();


            if (letter != CurrentKey)
            {
                Stop();
                CurrentKey = letter;

                if (!string.IsNullOrEmpty(letter))
                {
                    char c = letter[0];

                    if (Keys.Any(x => x.letter == c))
                    {
                        Play(Keys.Single(x => x.letter == c));
                        StateHasChanged();
                    }

                }
            }
        }

        public void KeyUpFromJS(BWHKeyboardState keyboardState)
        {
            CurrentKey = string.Empty;
            Stop();
            StateHasChanged();
        }

        public void ReleaseKeys()
        {
            if (Keys.Any(x => x.IsPressed))
            {
                Keys.Single(x => x.IsPressed).IsPressed = false;
            }
        }

        

        public string getClass(bool b)
        {
            if (b)
            {
                return "key keyPressed";
            }
            else
            {
                return "key keyRegular";
            }
        }
    }


    public class KeyNote
    {
        public int freq { get; set; }

        public char letter { get; set; }

        public bool IsPressed { get; set; }
    }
}
