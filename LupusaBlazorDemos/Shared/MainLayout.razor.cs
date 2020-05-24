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

        private string CurrentURI;


        bool DisableCounters = false;

        protected override async Task OnInitializedAsync()
        {

            CounterHelper.Initialize();

            LocalFunctions.RedirectIfNeeded(navigationManager);

            LBDJsInterop.jsRuntime = jsRuntime;
            BWHJsInterop.jsRuntime = jsRuntime;
          

            await CheckCounterIsDisabled();


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
                await CheckCounterIsDisabled();

                BWHelperFunctions.CheckIfMobile();
            }

          

            if (!DisableCounters)
            {
                if (!navigationManager.Uri.Equals(CurrentURI))
                {
                    CurrentURI = navigationManager.Uri;
                   
                    await CounterHelper.CmdAddCounter(new TSCounter() { Source = navigationManager.Uri, Action = "visit" });
                }
            }

            await base.OnAfterRenderAsync(firstRender);
        }


        protected async Task<bool> CheckCounterIsDisabled()
        {
            string result = await BWHJsInterop.LocalStorageGetItem("DisableCounters");

            if (!string.IsNullOrEmpty(result))
            {
                DisableCounters = result.Equals("1");
            }

            return true;
        }
    }




}
