using BlazorWindowHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LupusaBlazorDemos.Demos
{
    public partial class PagePrint : IDisposable
    {
        protected override void OnAfterRender(bool firstRender)
        {

            if (firstRender)
            {

                if (LBDLocalData.ShouldCallPrintDialog)
                {
                    BWHJsInterop.Print();
                    LBDLocalData.ShouldCallPrintDialog = false;
                }
            }

            base.OnAfterRender(firstRender);
        }

        public void Dispose()
        {
            LBDLocalData.IsLayoutVisible = true;
            LBDLocalData.mainLayout.Refresh();
        }
    }
}
