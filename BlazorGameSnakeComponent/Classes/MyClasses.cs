using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGameSnakeComponent.Classes
{

    public static class SoundEffect
    {
        //http://www.bfxr.net/ 27.06.2015
        public static MySound take_target = new MySound(1, "sounds/take_target.wav");
        public static MySound game_over = new MySound(2, "sounds/game_over.wav");
        //http://www.playonloop.com/2016-music-loops/clockwork-tale/
        public static MySound bg_sound = new MySound(3, "sounds/abc.wav", true);


    }


    public class MySound
    {
        public int id { get; set; }
        public string path { get; set; }
        public bool loop { get; set; }

        public MySound(int _id, string p, bool _loop = false)
        {
            path = p;
            id = _id;
            loop = _loop;
            BGSnakeCJsInterop.InitializeSound(id, path, loop);
        }

        public void play()
        {
            BGSnakeCJsInterop.ManageSound(id, "play");

        }

        public void pause()
        {
            BGSnakeCJsInterop.ManageSound(id, "pause");
        }
    }

    public class Board_Element
    {
        public MyPoint Point { get; set; }
        public MyValueType MyValue { get; set; }
    }

    public class Snake_Element
    {
        public MyPoint Point { get; set; }
        public bool Is_Main { get; set; }
    }

    public class MyPoint
    {
        public int x { get; set; }
        public int y { get; set; }

        public MyPoint(int p_x, int p_y)
        {
            x = p_x;
            y = p_y;
        }
    }


    public class rect
    {
        public double x { get; set; }
        public double y { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public string style { get; set; }
    }

    public class wall
    {
        public int lenght { get; set; }
        public DirectionType direction { get; set; }
        public MyPoint startpoint { get; set; }
    }




}
