using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTreeVisualizerComponent
{
   
        public class TreeItem
        {
            
            public int Tree_ID { get; set; }

            
            public DateTime Tree_Date { get; set; }

            
            public int Tree_IconsID { get; set; }

            
            public bool Tree_IsDynamic { get; set; }

            
            public int Tree_ParentID { get; set; }

            
            public double Tree_SequenceNumber { get; set; }

            
            public string Tree_Column { get; set; } = string.Empty;

            
            public int Tree_Level { get; set; }

        public bool Tree_IsSelected { get; set; }

        public bool Tree_IsExpanded { get; set; }

            
            public bool Tree_IsVisible { get; set; }

            
            public bool Tree_IsLastItemInLevel { get; set; }

            
            public bool Tree_HasChildren { get; set; }
        }
    
}
