using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTreeVisualizerComponent
{
    public static class PublicDataTree
    {
        public static List<TreeItem> dynamicOriginalList = new List<TreeItem>();

        public static string ParTreeColumnName = string.Empty;
        public static string ParCurrentViewName = string.Empty;
    }
}
