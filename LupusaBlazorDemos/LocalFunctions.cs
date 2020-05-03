using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos
{
    public static class LocalFunctions
    {
        static readonly Dictionary<string, string> UrlsDict = new Dictionary<string, string>()
        {
            {"calculatorpage", "lupblazorcalculator" },
            {"chesspage", "lupblazorchess" },
            {"clockcanvas", "lupblazorclockcanvas" },
            {"clocksvg", "lupblazorclocksvg" },
            {"doughnutchartpage", "lupblazordoughnutchart" },
            {"gamesnakepage", "lupblazorsnake" },
            {"loancalculatorpage", "lupblazorloancalculator" },
            {"paintpage", "lupblazorpaint" },
            {"passwordpatternpage", "lupblazorpasswordpattern" },
            {"performancechartpage", "lupblazorperfchart" },
            {"spreadsheetpage", "lupblazorspreadsheet" },
            {"treeviewpage", "lupblazortreevisualizer" },
            {"virtualizedlistpage", "lupblazorvirtuiallist" },
        };

        internal static void RedirectIfNeeded(NavigationManager navigationManager)
        {
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
            if (LocalData.TimezoneOffset != -99999)
            {

                return d.AddHours(-LocalData.TimezoneOffset);
            }
            else
            {
                return d;
            }
        }
    }
}
