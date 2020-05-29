using LupusaBlazorDemos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos
{
    public class LBDLocalData
    {
        public static bool IsLayoutVisible = true;
        public static bool ShouldCallPrintDialog = false;

        public static MainLayout mainLayout { get; set; } = new MainLayout();
        public static int TimezoneOffset { get; set; } = -99999;
    }
}
