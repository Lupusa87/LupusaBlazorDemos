using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos
{
    public static class LocalFunctions
    {
        public static NavigationManager navigationManager { get; set; } = null;


        static readonly Dictionary<string, string> UrlsDict = new Dictionary<string, string>()
        {
            // {"calculatorpage", "lupblazorcalculator" },
            //{"chesspage", "lupblazorchess" },
            // {"clockcanvas", "lupblazorclockcanvas" },
            // {"clocksvg", "lupblazorclocksvg" },
            //  {"doughnutchartpage", "lupblazordoughnutchart" },
            //  {"gamesnakepage", "lupblazorsnake" },
            //  {"loancalculatorpage", "lupblazorloancalculator" },
            // {"paintpage", "lupblazorpaint" },
            //  {"passwordpatternpage", "lupblazorpasswordpattern" },
            //  {"performancechartpage", "lupblazorperfchart" },
            //  {"spreadsheetpage", "lupblazorspreadsheet" },
            //  {"treeviewpage", "lupblazortreevisualizer" },
            //  {"virtualizedlistpage", "lupblazorvirtuiallist" },
        };

        public static void CmdNavigate(string ParRoute = "")
        {
            navigationManager.NavigateTo("/" + ParRoute);
        }


        

        internal static void RedirectIfNeeded(NavigationManager navigationManager)
        {

            return;

            string page;

            if (!navigationManager.BaseUri.Equals(navigationManager.Uri))
            {

                page = navigationManager.Uri[navigationManager.BaseUri.Length..].ToLower();

                if (UrlsDict.TryGetValue(page, out string redirectUri))
                {
                    navigationManager.NavigateTo("https://" + redirectUri + ".z20.web.core.windows.net/");
                }

                //navigationManager.NavigateTo("/");
            }

        }


        public static DateTime ToLocalDate(DateTime d)
        {
            if (LBDLocalData.TimezoneOffset != -99999)
            {

                return d.AddHours(-LBDLocalData.TimezoneOffset);
            }
            else
            {
                return d;
            }
        }

        public static string GetShortenedItem(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                if (item.Length > 100)
                {
                    return item.Substring(0, 100);
                }
                else
                {
                    return item;
                }

            }
            else
            {
                return "empty";
            }
        }
    }
}
