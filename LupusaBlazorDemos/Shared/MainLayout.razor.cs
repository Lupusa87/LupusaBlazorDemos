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
        //[Inject]
        //HttpClient httpClient { get; set; }

        [Inject]
        NavigationManager navigationManager { get; set; }

        [Inject]
        IJSRuntime jsRuntime { get; set; }


        protected override async Task OnInitializedAsync()
        {

            CounterHelper.Initialize();

            LocalFunctions.RedirectIfNeeded(navigationManager);

            LBDJsInterop.jsRuntime = jsRuntime;
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

            await base.OnInitializedAsync();

            return;
        }


        protected async override Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
                BWHelperFunctions.CheckIfMobile();
            }

            await CounterHelper.CmdAddCounter(new TSCounter() { Source = navigationManager.Uri, Action = "visit" });

            await base.OnAfterRenderAsync(firstRender);
        }



    }




}
