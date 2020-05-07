using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPaintComponent.classes
{
    [Serializable]
    public class BPaintLine : BPaintObject
    {
        
        public MyPoint end;
        

        public bool IsValid()
        {

            return (!end.Equals(StartPosition));

        }

    }
}
