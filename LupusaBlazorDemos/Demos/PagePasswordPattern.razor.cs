using BlazorPasswordPatternComponent;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Demos
{
    public partial class PagePasswordPattern
    {
        CompBlazorPassword CompBlazorPassword1 = new CompBlazorPassword();

        string Password = string.Empty;


        protected override void OnInitialized()
        {
          //  CompBlazorPassword1.PasswordUpdated = PassswordUpdated;
            base.OnInitialized();
        }

        //protected override void OnAfterRender(bool firstRender)
        //{
        //    //if (firstRender)
        //    //{
        //        CompBlazorPassword1.PasswordUpdated = PassswordUpdated;
        //    //}

        //    base.OnAfterRender(firstRender);
        //}


        void Reset()
        {
            CompBlazorPassword1.Reset();
        }


        void PassswordUpdated()
        {
            Password = CompBlazorPassword1.Password;
            StateHasChanged();
        }

    
    }
}
