using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1
{
    public static class LocalData
    {

        public static List<ProjectUpdate> ProjectUpdates_List = new List<ProjectUpdate>() {
        new ProjectUpdate() { N=1, Done = true,
            OpenDate = new DateTime(2018,7,6,17,0,0),
            CloseDate = new DateTime(2018,7,7,12,0,0),
            Name = "delete component",
            Comment ="now we are able to delete any component",
            TimeSpent = new TimeSpan(3,0,0),
            Importancy = "Very high"},

        new ProjectUpdate() { N=2, Done = true,
            OpenDate = new DateTime(2018,7,7,12,10,0),
            CloseDate = new DateTime(2018,7,7,13,0,0),
            Name = "change inputes",
            Comment ="TimeDiff input type now is number between -12 and 14, WidthAndHeight is also number between 100 and 500",
            TimeSpent = new TimeSpan(0,5,0),
            Importancy = "medium"},

        new ProjectUpdate() { N=3, Done = true,
            OpenDate = new DateTime(2018,7,7,13,30,0),
            CloseDate = new DateTime(2018,7,7,14,0,0),
            Name = "This track of changes and todos",
            Comment ="now we can see done and coming changes in project",
            TimeSpent = new TimeSpan(0,20,0),
            Importancy = "High"},

        new ProjectUpdate() { N=4, Done = false,
            OpenDate = new DateTime(2018,7,7,18,16,0),
            CloseDate = new DateTime(),
            Name = "Performance improvement",
            Comment ="should be tested some drawing optimizations",
            TimeSpent = new TimeSpan(0,0,0),
            Importancy = "High"},

         new ProjectUpdate() { N=5, Done = true,
            OpenDate = new DateTime(2018,7,10,09,30,0),
            CloseDate = new DateTime(2018,7,13,21,24,0),
            Name = "Add visual complexity to clock",
            Comment ="I try to touch more drawing aspects, don't care about beauty",
            TimeSpent = new TimeSpan(20,0,0),
            Importancy = "High"},
        };




        public class ProjectUpdate
        {
            public int N { get; set; }
            public bool Done { get; set; }
            public DateTime OpenDate { get; set; }
            public DateTime CloseDate { get; set; }
            public string Name { get; set; }
            public string Comment { get; set; }
            public TimeSpan TimeSpent { get; set; }
            public string Importancy { get; set; }

        }
    }
}
