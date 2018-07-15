using BlazorLib1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib1
{
    public class LupCanvas
    {
        private string canvasID;


        public LupCanvas(string par_canvasID)
        {
            canvasID = par_canvasID;
        }


        #region Methods

        public void Add_Canvas(string canvasID)
        {
            JsInterop.Add_Canvas(canvasID);
        }

        public void Remove_Canvas(string canvasID)
        {
            JsInterop.Remove_Canvas(canvasID);
        }

        public void Log_Canvas_Array()
        {
            JsInterop.Log_Canvas_Array();
        }
        


        public void Translate(float x, float y)
        {
            JsInterop.Translate(canvasID, x, y);
        }

        public void Move_To(float x, float y)
        {
            JsInterop.Move_To(canvasID, x, y);
        }


        public void Line_To(float x, float y)
        {
            JsInterop.Line_To(canvasID, x, y);
        }


        public void SetTransform()
        {
            JsInterop.Set_Transform(canvasID);
        }

        public void ClearRect()
        {
            JsInterop.Clear_Canvas(canvasID);
        }


        public void FillRect()
        {
            JsInterop.Draw_Rect(canvasID, Clock.BG_Color);
        }


        public void Begin_Path()
        {
            JsInterop.Begin_Path(canvasID);
        }

        public void Stroke()
        {
            JsInterop.Stroke(canvasID);
        }


        public void Fill()
        {
            JsInterop.Fill(canvasID);
        }

        public void Rotate(float angle)
        {
            JsInterop.Rotate(canvasID, angle);
        }


        public void Fill_Text(TransferFillTextParameters transferFillTextParameters)
        {
            JsInterop.Fill_Text(canvasID, transferFillTextParameters);
        }


        public void StrokeRect(TransferRectParameters transferRectParameters)
        {
            JsInterop.Stroke_Rect(canvasID, transferRectParameters);
        }

        

        public void SaveState()
        {
            JsInterop.Save_State(canvasID);
        }

        public void RestoreState()
        {
            JsInterop.Restore_State(canvasID);
        }

        public void SetProperty(TransferCanvasProperty transferCanvasProperty)
        {
            JsInterop.Set_Property(canvasID, transferCanvasProperty);
        }


        

        public void FillCircle(TransferParameters transferParameters)
        {
            JsInterop.Draw_Circle(canvasID, transferParameters);
        }

        public void CreateRadialGradient(TransferRadialGradientParameters transferRadialGradientParameters)
        {
            JsInterop.Create_Radial_Gradient(canvasID, transferRadialGradientParameters);
        }

        public void GradientAddColorStop(double stop, string color)
        {
            JsInterop.Gradient_Add_Color_Stop((float)stop, color);
        }

        public void GradientSetStokeOrFillStyle(bool StrokeOrFill)
        {
            JsInterop.Gradient_Set_Stoke_Or_Fill_Style(canvasID, StrokeOrFill);
        }

   


        public bool Draw_Image(string imgName, TransferImageParameters transferImageParameters)
        {
           return JsInterop.Draw_Image(canvasID, imgName, transferImageParameters);
        }

       
        public void FillGauge(string color, TransferParameters transferParameters)
        {
            JsInterop.Draw_Gauge(canvasID, color, transferParameters);
        }


        public async Task<string> PreloadImage()
        {
          return await JsInterop.Preload_Image();
        }

        

        #endregion
    }
}
