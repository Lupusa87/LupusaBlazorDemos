using BlazorCounterHelper;
using BlazorWindowHelper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Shared
{
    public partial class MainLayout
    {
        [Inject]
        HttpClient httpClient { get; set; }

        [Inject]
        NavigationManager navigationManager { get; set; }

        [Inject]
        IJSRuntime jsRuntime { get; set; }


        protected override async Task OnInitializedAsync()
        {
            LocalFunctions.RedirectIfNeeded(navigationManager);

            BWHJsInterop.jsRuntime = jsRuntime;




            //if (WebApiFunctions.httpClient is null)
            //{
            //    WebApiFunctions.httpClient = httpClient;
            //    WebApiFunctions.httpClient.BaseAddress = LocalData.WebApi_Uri;
            //    WebApiFunctions.httpClient.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);

            //    WebApiFunctions.CmdGetVisitor();
            //}

            //if (LocalData.IsDevelopmentMode)
            //{
            //    if (!BlazorWindowHelper.BWHJsInterop.IsReady)
            //    {
            //        BlazorWindowHelper.BWHJsInterop.jsRuntime = jsRuntime;
            //        BlazorWindowHelper.BWHJsInterop.IsReady = true;
            //    }

            //}


            if (LocalData.TimezoneOffset == -99999)
            {
                LocalData.TimezoneOffset = await BWHJsInterop.GetTimezoneOffset();
            }


            CounterHelper.Initialize();
            await CounterHelper.CmdAddCounter(new TSCounter() { Source = navigationManager.Uri, Action = "visit" });

            await base.OnInitializedAsync();

            return;
        }

        protected override void OnAfterRender(bool firstRender)
        {

            if (firstRender)
            {



              BWHelperFunctions.CheckIfMobile();




            }

            base.OnAfterRender(firstRender);
        }



      



    }




}
