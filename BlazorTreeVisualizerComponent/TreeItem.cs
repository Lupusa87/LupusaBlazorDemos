using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTreeVisualizerComponent
{
    public class TreeItem
    {

        public int ID { get; set; }

        public int ParentID { get; set; }


        public double SequenceNumber { get; set; }


        public string Text { get; set; } = string.Empty;


        public int Level { get; set; }

        internal bool IsSelected { get; set; }

        public bool IsExpanded { get; set; }


        internal bool IsVisible { get; set; }


        internal bool IsLastItemInLevel { get; set; }


        internal bool HasChildren { get; set; }

        public string IconSource { get; set; }
    }
}
