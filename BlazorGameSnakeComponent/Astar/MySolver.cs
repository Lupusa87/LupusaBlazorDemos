using BlazorGameSnakeComponent.Astar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGameSnakeComponent.Astar
{
    public class MySolver<TPathNode, TUserContext> : SpatialAStar<TPathNode,
    TUserContext> where TPathNode : IPathNode<TUserContext>
    {
        protected override Double Heuristic(PathNode inStart, PathNode inEnd)
        {
            return Math.Abs(inStart.X - inEnd.X) + Math.Abs(inStart.Y - inEnd.Y);
        }

        protected override Double NeighborDistance(PathNode inStart, PathNode inEnd)
        {
            return Heuristic(inStart, inEnd);
        }

        public MySolver(TPathNode[,] inGrid)
            : base(inGrid)
        {
        }
    }
}
