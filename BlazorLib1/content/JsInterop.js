var canvas_array = [];

var img_Corner_Shape;
var img_array;

let ImgIsLoaded = false;


var grad;

Blazor.registerFunction('BlazorLib1.JsInterop.Log_Canvas_Array', () => {


    console.log(canvas_array);
    console.log(document.getElementsByTagName("canvas"));

    return true;
});






Blazor.registerFunction('BlazorLib1.JsInterop.Add_Canvas', (canvasID) => {

    var a = document.getElementById(canvasID);
   
    var b = {
        id: a.id,
        canvasWidth: a.clientWidth,
        canvasHeight: a.clientHeight,
        ctx: a.getContext("2d"),
    };

    canvas_array.push(b);

    return true;
});


Blazor.registerFunction('BlazorLib1.JsInterop.Remove_Canvas', (canvasID) => {

    var result = true;


    var index = canvas_array.findIndex(x => x.id === canvasID)
    
    if (index > -1) {
        canvas_array.splice(index, 1);
    }
    else {
        result = false;
    }


    return result;
});



Blazor.registerFunction('BlazorLib1.JsInterop.Prompt', function (message) {
    return prompt(message, 'Type anything here');
});


Blazor.registerFunction('BlazorLib1.JsInterop.Alert', (message) => {
        alert(message);
    return true;
    });


Blazor.registerFunction('BlazorLib1.JsInterop.Draw_Circle', (obj) => {

    var arc_params = obj["transferParameters"];
   
    ctx(obj["canvasID"]).arc(arc_params.x, arc_params.y, arc_params.r, arc_params.sAngle, arc_params.eAngle);
   
    return true;
});

Blazor.registerFunction('BlazorLib1.JsInterop.CanvasSaveState', (canvasID) => {

    ctx(canvasID).save();

    return true;
});

Blazor.registerFunction('BlazorLib1.JsInterop.CanvasRestoreState', (canvasID) => {

    ctx(canvasID).restore();

    return true;
});

Blazor.registerFunction('BlazorLib1.JsInterop.Draw_Image', (obj) => {

    var ctx1 = ctx(obj["canvasID"]);

    ctx1.drawImage(img_Corner_Shape, obj["transferImageParameters"].x, obj["transferImageParameters"].y, obj["transferImageParameters"].width, obj["transferImageParameters"].height);
 
    return true;
});


Blazor.registerFunction('BlazorLib1.JsInterop.Draw_Gauge', (obj) => {

    draw_Gauge(ctx(obj["canvasID"]), obj["color"], obj["transferParameters"]);


    return true;
});

function draw_Gauge(ctx, color, arc_params) {


    var gradient = ctx.createRadialGradient(0, 0, 0, 0, 0, arc_params.r);
    gradient.addColorStop(0, 'white');
    gradient.addColorStop(1, color);
 


    ctx.beginPath();
    ctx.moveTo(0,0); //important to have expected shape!
    ctx.arc(arc_params.x, arc_params.y, arc_params.r, arc_params.sAngle, arc_params.eAngle);
    ctx.fillStyle = gradient;;
    ctx.closePath();
    ctx.fill();
}



Blazor.registerFunction('BlazorLib1.JsInterop.Fill_Text', (obj) => {

    ctx(obj["canvasID"]).fillText(obj["transferFillTextParameters"].text,
                                    obj["transferFillTextParameters"].x,
                                    obj["transferFillTextParameters"].y);
   

    return true;
});


Blazor.registerFunction('BlazorLib1.JsInterop.Set_Property', (obj) => {

    var prt = obj["transferCanvasProperty"].propertyName;

    if (prt) {
        ctx(obj["canvasID"])[prt] = obj["transferCanvasProperty"].propertyValue;
    }
   
    return true;
});


Blazor.registerFunction('BlazorLib1.JsInterop.Draw_Rect', (obj) => {

    draw_Rect(canvas(obj["canvasID"]), obj["color"]);

    return true;
});


Blazor.registerFunction('BlazorLib1.JsInterop.Clear_Canvas', (canvasID) => {


    var canvas1 = canvas(canvasID);
   
    canvas1.ctx.setTransform(1, 0, 0, 1, 0, 0);
    canvas1.ctx.clearRect(0, 0, canvas1.canvasWidth, canvas1.canvasHeight);

    return true;
});


function canvas(canvasID) {

    var index = canvas_array.findIndex(x => x.id === canvasID);

    return canvas_array[index];

}


function ctx(canvasID) {

    var index = canvas_array.findIndex(x => x.id === canvasID);

    return canvas_array[index].ctx; 

}



Blazor.registerFunction('BlazorLib1.JsInterop.Translate', (obj) => {

    ctx(obj["canvasID"]).translate(obj["x"], obj["y"]);

    return true;
});



Blazor.registerFunction('BlazorLib1.JsInterop.Move_To', (obj) => {


    ctx(obj["canvasID"]).moveTo(obj["x"], obj["y"]);

    return true;
});


Blazor.registerFunction('BlazorLib1.JsInterop.Line_To', (obj) => {

   
    ctx(obj["canvasID"]).lineTo(obj["x"], obj["y"]);
   
    return true;
});


Blazor.registerFunction('BlazorLib1.JsInterop.Rotate', (obj) => {

    ctx(obj["canvasID"]).rotate(obj["angle"]);

    return true;
});

Blazor.registerFunction('BlazorLib1.JsInterop.Set_Transform', (canvasID) => {


    ctx(canvasID).setTransform(1, 0, 0, 1, 0, 0);

    return true;
});

Blazor.registerFunction('BlazorLib1.JsInterop.Begin_Path', (canvasID) => {

    ctx(canvasID).beginPath();
    return true;
});


Blazor.registerFunction('BlazorLib1.JsInterop.Stroke', (canvasID) => {

    ctx(canvasID).stroke();

    return true;
});


Blazor.registerFunction('BlazorLib1.JsInterop.Fill', (canvasID) => {

    ctx(canvasID).fill();

    return true;
});

Blazor.registerFunction('BlazorLib1.JsInterop.Stroke_Rect', (obj) => {

    ctx(obj["canvasID"]).strokeRect(obj["transferRectParameters"].x,
        obj["transferRectParameters"].y,
        obj["transferRectParameters"].w,
        obj["transferRectParameters"].h);

    return true;
});


function draw_Rect(canvas, color) {

    canvas.ctx.beginPath();
    canvas.ctx.fillStyle = color;
    canvas.ctx.fillRect(0, 0, canvas.canvasWidth, canvas.canvasHeight);
    canvas.ctx.fill();
}



Blazor.registerFunction("BlazorLib1.JsInterop.Preload_Image", function () {
    return new Promise(resolve => {


        if (!ImgIsLoaded) {
            img_Corner_Shape = new Image();

            img_Corner_Shape.onload = () => {
                ImgIsLoaded = true;
                resolve("promise resolved, loading done");
            };
            img_Corner_Shape.src = "/content/1.png";
        }
        else {
           
            resolve("image already loaded");
        }
    });
});



Blazor.registerFunction('BlazorLib1.JsInterop.Create_Radial_Gradient', (obj) => {


    grad = ctx(obj["canvasID"]).createRadialGradient(
        obj["transferRadialGradientParameters"].x0,
        obj["transferRadialGradientParameters"].y0,
        obj["transferRadialGradientParameters"].r0,
        obj["transferRadialGradientParameters"].x1,
        obj["transferRadialGradientParameters"].y1,
        obj["transferRadialGradientParameters"].r1);


    return true;
});

Blazor.registerFunction('BlazorLib1.JsInterop.Gradient_Add_Color_Stop', (obj) => {



    grad.addColorStop(obj["stop"], obj["color"]);

    
    return true;
});


Blazor.registerFunction('BlazorLib1.JsInterop.Gradient_Set_Stoke_Or_Fill_Style', (obj) => {


    if (obj["strokeOrFill"]) {
        ctx(obj["canvasID"]).strokeStyle = grad;
    }
    else {
        ctx(obj["canvasID"]).fillStyle = grad;
    }

    return true;
});
