using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTreeVisualizerComponent
{
    public class TreeItem
    {

        public int ID { get; set; }


        public DateTime Date { get; set; }


        public int IconsID { get; set; }


        public bool IsDynamic { get; set; }


        public int ParentID { get; set; }


        public double SequenceNumber { get; set; }


        public string Column { get; set; } = string.Empty;


        public int Level { get; set; }

        public bool IsSelected { get; set; }

        public bool IsExpanded { get; set; }


        public bool IsVisible { get; set; }


        public bool IsLastItemInLevel { get; set; }


        public bool HasChildren { get; set; }

        public bool HasIcon { get; set; }

        public string IconSource { get; set; }
    }
}
