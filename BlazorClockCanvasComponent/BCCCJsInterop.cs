using System;
using System.Threading.Tasks;
using BlazorClockCanvasComponent.Classes;
using Microsoft.JSInterop;

namespace BlazorClockCanvasComponent
{
    public static class BCCCJsInterop
    {

        public static IJSRuntime jsRuntime;

        public static ValueTask<string> Prompt(string message)
        {
            return jsRuntime.InvokeAsync<string>(
                "JsInteropClockCanvas.Prompt",
                message);
        }


        public static ValueTask<bool> Alert(string message)
        {
            return jsRuntime.InvokeAsync<bool>(
                "JsInteropClockCanvas.Alert",
                message);
        }


        public static ValueTask<bool> Log_Canvas_Array()
        {
            return jsRuntime.InvokeAsync<bool>(
                "JsInteropClockCanvas.Log_Canvas_Array");
        }

        public static ValueTask<bool> Render_To_UI(string canvasID)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Render_To_UI", canvasID);
        }

        

        public static ValueTask<bool> Draw_Circle(string canvasID, TransferParameters transferParameters)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Draw_Circle",
                new { canvasID, transferParameters });
        }

        public static ValueTask<bool> Stroke_Rect(string canvasID, TransferRectParameters transferRectParameters)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Stroke_Rect",
                new { canvasID, transferRectParameters });
        }


        

        public static ValueTask<bool> Draw_Image(string canvasID, string imgName, TransferImageParameters transferImageParameters)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Draw_Image",
                new { canvasID, imgName, transferImageParameters });
        }


        public static ValueTask<bool> Draw_Gauge(string canvasID, string color, TransferParameters transferParameters)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Draw_Gauge",
                new { canvasID, color, transferParameters });
        }

        public static ValueTask<bool> Set_Property(string canvasID, TransferCanvasProperty transferCanvasProperty)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Set_Property",
                new { canvasID, transferCanvasProperty });
        }

        public static ValueTask<bool> Fill_Text(string canvasID, TransferFillTextParameters transferFillTextParameters)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Fill_Text",
                new { canvasID, transferFillTextParameters });
        }

        public static ValueTask<bool> Create_Radial_Gradient(string canvasID, TransferRadialGradientParameters transferRadialGradientParameters)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Create_Radial_Gradient",
                new { canvasID, transferRadialGradientParameters });
        }
        

        public static ValueTask<bool> Clear_Canvas(string canvasID)
        {
            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Clear_Canvas", canvasID);
        }

  

        public static ValueTask<bool> Save_State(string canvasID)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.CanvasSaveState", canvasID);
        }

        public static ValueTask<bool> Restore_State(string canvasID)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.CanvasRestoreState", canvasID);
        }

        public static ValueTask<bool> Set_Transform(string canvasID)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Set_Transform", canvasID);
        }

        public static ValueTask<bool> Begin_Path(string canvasID)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Begin_Path", canvasID);
        }


        public static ValueTask<bool> Stroke(string canvasID)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Stroke", canvasID);
        }

        public static ValueTask<bool> Fill(string canvasID)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Fill", canvasID);
        }

        public static ValueTask<bool> Draw_Full_Size_Rect(string canvasID, string color)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.draw_Full_Size_Rect", new { canvasID, color });
        }


        public static ValueTask<bool> Translate(string canvasID, float x, float y)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Translate",
                new { canvasID, x, y });
        }

        public static ValueTask<bool> Rotate(string canvasID, float angle)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Rotate",new { canvasID, angle });
        }



        public static ValueTask<bool> Move_To(string canvasID, float x, float y)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Move_To",
                new {canvasID, x, y });
        }

        public static ValueTask<bool> Line_To(string canvasID, float x, float y)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Line_To",
                new { canvasID, x, y });
        }


        public static ValueTask<bool> Add_Canvas(string canvasID, string BgCanvasID, string TopCanvasID)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Add_Canvas",new { canvasID, BgCanvasID, TopCanvasID });


        }


        public static ValueTask<bool> Remove_Canvas(string canvasID)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Remove_Canvas", canvasID);
        }


        public static ValueTask<bool> DrawPieChart(string canvasID)
        {
        
                return jsRuntime.InvokeAsync<bool>("JavaScriptDrawPieChart", canvasID);
        }



        public static async Task<string> Preload_Image()
        {

            return await jsRuntime.InvokeAsync<string>("JsInteropClockCanvas.Preload_Image");
        }


        public static ValueTask<bool> Gradient_Add_Color_Stop(float stop, string color)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Gradient_Add_Color_Stop",
                new { stop, color });
        }


        public static ValueTask<bool> Gradient_Set_Stoke_Or_Fill_Style(string canvasID, bool StrokeOrFill)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Gradient_Set_Stoke_Or_Fill_Style",
                new { canvasID, StrokeOrFill });
        }

        public static ValueTask<bool> Execute_Dynamic_Script(string cmd)
        {

            return jsRuntime.InvokeAsync<bool>("JsInteropClockCanvas.Execute_Dynamic_Script", cmd);
        }

    }
}
