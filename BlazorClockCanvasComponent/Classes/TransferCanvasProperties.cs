using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClockCanvasComponent.Classes
{
    public class TransferCanvasProperty
    {

        /// <summary>
        /// HTML canvas font Property
        /// </summary>
        public string propertyName { get; set; } = string.Empty;


        /// <summary>
        /// HTML canvas textBaseline Property
        /// </summary>
        public string propertyValue { get; set; } = string.Empty;

      


        public TransferCanvasProperty(string _propertyName, string _propertyValue)
        {
            propertyName = _propertyName;

            propertyValue = _propertyValue;


        }
    }
    }
