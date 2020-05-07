using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGameSnakeComponent.Astar
{
    //lupusa - 8/14/2018
    //original typescript version for this snake game was using another astar typscript version

    //after porting to blazor I found c# version bellow
    //https://www.codeproject.com/Articles/118015/Fast-A-Star-2D-Implementation-for-C


    //only one change I made was disable diagonal move in StoreNeighborNodes method for SpatialAStar class
    //for snake it is not usefull, for another games we can uncomment changes and it will work as original version
}
