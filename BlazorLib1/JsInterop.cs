using System;
using System.Threading.Tasks;
using BlazorLib1.Classes;
using Microsoft.AspNetCore.Blazor.Browser.Interop;

namespace BlazorLib1
{
    public static class JsInterop
    {
        public static string Prompt(string message)
        {
            return RegisteredFunction.Invoke<string>(
                "BlazorLib1.JsInterop.Prompt",
                message);
        }


        public static bool Alert(string message)
        {
            return RegisteredFunction.Invoke<bool>(
                "BlazorLib1.JsInterop.Alert",
                message);
        }


        public static bool Log_Canvas_Array()
        {
            return RegisteredFunction.Invoke<bool>(
                "BlazorLib1.JsInterop.Log_Canvas_Array");
        }

        public static bool Render_To_UI(string canvasID)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Render_To_UI", canvasID);
        }

        

        public static bool Draw_Circle(string canvasID, TransferParameters transferParameters)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Draw_Circle",
                new { canvasID, transferParameters });
        }

        public static bool Stroke_Rect(string canvasID, TransferRectParameters transferRectParameters)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Stroke_Rect",
                new { canvasID, transferRectParameters });
        }


        

        public static bool Draw_Image(string canvasID, string imgName, TransferImageParameters transferImageParameters)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Draw_Image",
                new { canvasID, imgName, transferImageParameters });
        }


        public static bool Draw_Gauge(string canvasID, string color, TransferParameters transferParameters)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Draw_Gauge",
                new { canvasID, color, transferParameters });
        }

        public static bool Set_Property(string canvasID, TransferCanvasProperty transferCanvasProperty)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Set_Property",
                new { canvasID, transferCanvasProperty });
        }

        public static bool Fill_Text(string canvasID, TransferFillTextParameters transferFillTextParameters)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Fill_Text",
                new { canvasID, transferFillTextParameters });
        }

        public static bool Create_Radial_Gradient(string canvasID, TransferRadialGradientParameters transferRadialGradientParameters)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Create_Radial_Gradient",
                new { canvasID, transferRadialGradientParameters });
        }
        

        public static bool Clear_Canvas(string canvasID)
        {
            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Clear_Canvas", canvasID);
        }

  

        public static bool Save_State(string canvasID)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.CanvasSaveState", canvasID);
        }

        public static bool Restore_State(string canvasID)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.CanvasRestoreState", canvasID);
        }

        public static bool Set_Transform(string canvasID)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Set_Transform", canvasID);
        }

        public static bool Begin_Path(string canvasID)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Begin_Path", canvasID);
        }


        public static bool Stroke(string canvasID)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Stroke", canvasID);
        }

        public static bool Fill(string canvasID)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Fill", canvasID);
        }

        public static bool Draw_Full_Size_Rect(string canvasID, string color)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.draw_Full_Size_Rect", new { canvasID, color });
        }


        public static bool Translate(string canvasID, float x, float y)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Translate",
                new { canvasID, x, y });
        }

        public static bool Rotate(string canvasID, float angle)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Rotate",new { canvasID, angle });
        }



        public static bool Move_To(string canvasID, float x, float y)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Move_To",
                new {canvasID, x, y });
        }

        public static bool Line_To(string canvasID, float x, float y)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Line_To",
                new { canvasID, x, y });
        }


        public static bool Add_Canvas(string canvasID, string BgCanvasID, string TopCanvasID)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Add_Canvas",new { canvasID, BgCanvasID, TopCanvasID });


        }


        public static bool Remove_Canvas(string canvasID)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Remove_Canvas", canvasID);
        }


        public static bool DrawPieChart(string canvasID)
        {
        
                return RegisteredFunction.Invoke<bool>("JavaScriptDrawPieChart", canvasID);
        }



        public static async Task<string> Preload_Image()
        {

            return await RegisteredFunction.InvokeAsync<string>("BlazorLib1.JsInterop.Preload_Image");
        }


        public static bool Gradient_Add_Color_Stop(float stop, string color)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Gradient_Add_Color_Stop",
                new { stop, color });
        }


        public static bool Gradient_Set_Stoke_Or_Fill_Style(string canvasID, bool StrokeOrFill)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Gradient_Set_Stoke_Or_Fill_Style",
                new { canvasID, StrokeOrFill });
        }

        public static bool Execute_Dynamic_Script(string cmd)
        {

            return RegisteredFunction.Invoke<bool>("BlazorLib1.JsInterop.Execute_Dynamic_Script", cmd);
        }

    }
}
