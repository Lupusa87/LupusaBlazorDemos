using BlazorLib1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLib1
{
    public class LupCanvas
    {
        private string canvasID;
        private string FgCanvasID;
        private string BgCanvasID;
        private string TopCanvasID;
        private JsInteropExecutionMode _JsInteropExecutionMode = JsInteropExecutionMode.Dynamic;

        private Dictionary<string, string> PropertiesDictionary = new Dictionary<string, string>();



        private StringBuilder sb = new StringBuilder();


        public LupCanvas(string _FgCanvasID, string _BgCanvasID, string _TopCanvasID)
        {
            FgCanvasID = _FgCanvasID;
            BgCanvasID = _BgCanvasID;
            TopCanvasID = _TopCanvasID;
            canvasID = FgCanvasID;
        }




        public void Swith_To_Canvas(ClockCanvasType clockCanvasType)
        {
            switch (clockCanvasType)
            {
                case ClockCanvasType.ForeGround:
                    canvasID = TopCanvasID;
                    break;
                case ClockCanvasType.Middle:
                    canvasID = FgCanvasID;
                    break;
                case ClockCanvasType.Background:
                    canvasID = BgCanvasID;
                    break;
                default:
                    canvasID = FgCanvasID;
                    break;
            }


            
        }

        #region Methods

        public void Add_Canvas()
        {
            JsInterop.Add_Canvas(FgCanvasID, BgCanvasID, TopCanvasID);
        }

        public void Remove_Canvas()
        {
            JsInterop.Remove_Canvas(FgCanvasID);
        }

        public void Log_Canvas_Array()
        {
            JsInterop.Log_Canvas_Array();
        }


        public void RenderToUI()
        {
            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Render_To_UI(canvasID);
            }
            else
            {
                SB_Append("ctx(\""+canvasID+"\", true).drawImage(ctx1.canvas, 0, 0);");
            }

        }

        

        public void Translate(float x, float y)
        {
            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Translate(canvasID, x, y);
            }
            else
            {
                SB_Append("ctx1.translate(" + x + ", " + y + ");");
            }
        }

        public void Move_To(float x, float y)
        {
            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Move_To(canvasID, x, y);
            }
            else
            {
                SB_Append("ctx1.moveTo(\"" + x + "\", \"" + y + "\");");
            }

            
        }


        public void Line_To(float x, float y)
        {
            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Line_To(canvasID, x, y);
            }
            else
            {
                SB_Append("ctx1.lineTo(\"" + x + "\", \"" + y + "\");");
            }

            
        }


        public void SetTransform()
        {

            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Set_Transform(canvasID);
            }
            else
            {
                SB_Append(" ctx1.setTransform(1, 0, 0, 1, 0, 0);");
            }

            
        }

        public void ClearCanvas()
        {
            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Clear_Canvas(canvasID);
            }
            else
            {
                SB_Append(" ctx1.setTransform(1, 0, 0, 1, 0, 0);");
                SB_Append(" ctx1.clearRect(0, 0, ctx1.canvas.clientWidth, ctx1.canvas.clientHeight);");
            }


            
        }


        public void DrawFullSizeRect(string color)
        {

            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Draw_Full_Size_Rect(canvasID, color);
            }
            else
            {
                SB_Append(" ctx1.beginPath();");
                SB_Append(" ctx1.fillStyle = \"" + color + "\";");
                SB_Append(" ctx1.fillRect(0, 0, ctx1.canvas.clientWidth, ctx1.canvas.clientHeight);");
            }
        }


        public void Begin_Path()
        {
            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Begin_Path(canvasID);
            }
            else
            {
                SB_Append("ctx1.beginPath();");
            }

            
        }

        public void Stroke()
        {
            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Stroke(canvasID);
            }
            else
            {
                SB_Append("ctx1.stroke();");
            }
        }


        public void Fill()
        {

            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Fill(canvasID);
            }
            else
            {
                SB_Append("ctx1.fill();");
            }

           
        }

        public void Rotate(float angle)
        {
            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Rotate(canvasID, angle);
            }
            else
            {
                SB_Append("ctx1.rotate(" + angle + ");");

            }

        }


        public void Fill_Text(TransferFillTextParameters transferFillTextParameters)
        {
            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Fill_Text(canvasID, transferFillTextParameters);
            }
            else
            {

                SB_Append("ctx1.fillText(\"" + transferFillTextParameters.text + "\","+ transferFillTextParameters.x +","+ transferFillTextParameters.y + ");");
            }

           
        }


        public void StrokeRect(TransferRectParameters transferRectParameters)
        {

            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Stroke_Rect(canvasID, transferRectParameters);
            }
            else
            {

                SB_Append("ctx1.strokeRect(" + transferRectParameters.x +
                    "," + transferRectParameters.y + 
                    "," + transferRectParameters.w +
                    "," + transferRectParameters.h + ");");
            }
            


        }

        

        public void SaveState()
        {

            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Save_State(canvasID);
            }
            else
            {

                SB_Append("ctx1.saveState();");
                   
            }
            
        }

        public void RestoreState()
        {
            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Restore_State(canvasID);
            }
            else
            {

                SB_Append("ctx1.restoreState();");

            }

        }

        public void SetProperty(TransferCanvasProperty transferCanvasProperty)
        {

            if (_JsInteropExecutionMode == 0)
            {
                string key = canvasID + transferCanvasProperty.propertyName;
                string value = string.Empty;
                if (PropertiesDictionary.TryGetValue(canvasID + transferCanvasProperty.propertyName, out value))
                {
                    if (!value.Equals(transferCanvasProperty.propertyValue, StringComparison.InvariantCultureIgnoreCase))
                    {
                        PropertiesDictionary[key] = transferCanvasProperty.propertyValue;
                        JsInterop.Set_Property(canvasID, transferCanvasProperty);
                    }
                }
                else
                {
                    PropertiesDictionary.Add(key, transferCanvasProperty.propertyValue);
                    JsInterop.Set_Property(canvasID, transferCanvasProperty);
                }
            }
            else
            {
                SB_Append("ctx1[\""+ transferCanvasProperty.propertyName+ "\"] = \""+ transferCanvasProperty.propertyValue + "\";");

               

            }

            

            
        }


        

        public void FillCircle(TransferParameters transferParameters)
        {


            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Draw_Circle(canvasID, transferParameters);
            }
            else
            {
                SB_Append(" ctx1.arc(" + transferParameters.x + 
                    ", " + transferParameters.y +
                    ", " + transferParameters.r +
                    ", " + transferParameters.sAngle +
                    ", " + transferParameters.eAngle + ");");
            }

            
        }

        public void CreateRadialGradient(TransferRadialGradientParameters transferRadialGradientParameters)
        {


            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Create_Radial_Gradient(canvasID, transferRadialGradientParameters);
            }
            else
            { 

                SB_Append(" grad =  ctx1.createRadialGradient(" + transferRadialGradientParameters.x0 +
                    ", " + transferRadialGradientParameters.y0 +
                    ", " + transferRadialGradientParameters.r0 +
                    ", " + transferRadialGradientParameters.x1 +
                    ", " + transferRadialGradientParameters.y1 +
                    ", " + transferRadialGradientParameters.r1 + ");");
            }

            
        }

        public void GradientAddColorStop(double stop, string color)
        {
            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Gradient_Add_Color_Stop((float)stop, color);
            }
            else
            {
              
                SB_Append(" grad.addColorStop("+stop+", \""+color+ "\");");
                   
            }

            
        }

        public void GradientSetStokeOrFillStyle(bool StrokeOrFill)
        {

            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Gradient_Set_Stoke_Or_Fill_Style(canvasID, StrokeOrFill);
            }
            else
            {
                if (StrokeOrFill)
                {
                    SB_Append(" ctx1.strokeStyle = grad;");
                }
                else
                {
                    SB_Append(" ctx1.fillStyle = grad;");
                }

            }

        }




        public void Draw_Image(string imgName, TransferImageParameters transferImageParameters)
        {
          

            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Draw_Image(canvasID, imgName, transferImageParameters);
            }
            else
            {
                SB_Append(" ctx1.drawImage(img_Corner_Shape," + transferImageParameters.x + ","
                     + transferImageParameters.y + ","
                      + transferImageParameters.width + ","
                       + transferImageParameters.height + ");");

            }

          
        }


        public void FillGauge(string color, TransferParameters transferParameters)
        {
            if (_JsInteropExecutionMode == 0)
            {
                JsInterop.Draw_Gauge(canvasID, color, transferParameters);
            }
            else
            {
                SB_Append(" var gradient = ctx1.createRadialGradient(0, 0, 0, 0, 0, " + transferParameters.r + ");");
                SB_Append(" gradient.addColorStop(0, 'white');");
                SB_Append(" gradient.addColorStop(1, \"" + color + "\");");

                SB_Append(" ctx1.beginPath();");
                SB_Append(" ctx1.moveTo(0, 0);");
                SB_Append(" ctx1.arc(" + transferParameters.x + ", " 
                    + transferParameters.y + ", "
                    + transferParameters.r + ", "
                    + transferParameters.sAngle +
                    ", " + transferParameters.eAngle + ");");
                SB_Append(" ctx1.fillStyle = gradient;");
                SB_Append(" ctx1.closePath();");
                SB_Append(" ctx1.fill();");

            }
   
        }

      
        


        public async Task<string> PreloadImage()
        {
          return await JsInterop.Preload_Image();
        }

        public void SB_Clear()
        {
            sb.Clear();
            sb = new StringBuilder();
        }


        public void SB_Append(string a, bool addCtx1 = false)
        {
            if(addCtx1)
            {
                SB_Clear();
                sb.AppendLine("var ctx1 = ctx(\"" + canvasID + "\");");
            }
            sb.AppendLine(a);
        }

        public void SB_Execute()
        {
            JsInterop.Execute_Dynamic_Script(sb.ToString());
            SB_Clear();
        }


        #endregion
    }
}
