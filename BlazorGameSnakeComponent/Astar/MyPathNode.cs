using BlazorGameSnakeComponent.Astar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGameSnakeComponent.Astar
{
    
        public class MyPathNode : IPathNode<Object>
        {
            public Int32 X { get; set; }
            public Int32 Y { get; set; }
            public Boolean IsWall { get; set; }

            public bool IsWalkable(Object unused)
            {
                return !IsWall;
            }
        }
    
}
