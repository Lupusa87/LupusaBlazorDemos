var canvas_array = [];

var img_Corner_Shape;
var img_array;

let ImgIsLoaded = false;


var grad;

function draw_Gauge(ctx, color, arc_params) {


    var gradient = ctx.createRadialGradient(0, 0, 0, 0, 0, arc_params.r);
    gradient.addColorStop(0, 'white');
    gradient.addColorStop(1, color);



    ctx.beginPath();
    ctx.moveTo(0, 0); //important to have expected shape!
    ctx.arc(arc_params.x, arc_params.y, arc_params.r, arc_params.sAngle, arc_params.eAngle);
    ctx.fillStyle = gradient;;
    ctx.closePath();
    ctx.fill();
}



function ctx(canvasID, RealOrOffScreen = false) {

    var index = -1;


    if (canvasID.includes("Bg")) {
        index = canvas_array.findIndex(x => x.id === canvasID.replace("Bg", ""));
        return canvas_array[index].ctxBG;
    }
    else if (canvasID.includes("Top")) {
        index = canvas_array.findIndex(x => x.id === canvasID.replace("Top", ""));
        return canvas_array[index].ctxTop;
    }
    else {
        index = canvas_array.findIndex(x => x.id === canvasID);

        if (RealOrOffScreen) {
            return canvas_array[index].ctxReal;
        }
        else {
            return canvas_array[index].ctxOffScreen;
        }
    }


}


window.JsInteropClockCanvas = {



    Log_Canvas_Array: function () {


        console.log(canvas_array);
        console.log(document.getElementsByTagName("canvas"));

        return true;
    },


    Add_Canvas: function (obj) {



        var a = document.getElementById(obj["canvasID"]);

        var offscreenCanvas = document.createElement('canvas');
        offscreenCanvas.width = a.clientWidth;
        offscreenCanvas.height = a.clientHeight;

        var b = {
            id: a.id,
            ctxTop: document.getElementById(obj["topCanvasID"]).getContext("2d"),
            ctxBG: document.getElementById(obj["bgCanvasID"]).getContext("2d"),
            ctxReal: a.getContext("2d"),
            ctxOffScreen: offscreenCanvas.getContext('2d'),
        };

        canvas_array.push(b);


        return true;
    },


    Remove_Canvas: function (canvasID) {

        var result = true;


        var index = canvas_array.findIndex(x => x.id === canvasID)

        if (index > -1) {
            canvas_array.splice(index, 1);
        }
        else {
            result = false;
        }


        return result;
    },



    Prompt: function (message) {
        return prompt(message, 'Type anything here');
    },


    Alert: function (message) {
        alert(message);
        return true;
    },


    Draw_Circle: function (obj) {

        var arc_params = obj["transferParameters"];

        ctx(obj["canvasID"]).arc(arc_params.x, arc_params.y, arc_params.r, arc_params.sAngle, arc_params.eAngle);

        return true;
    },

    CanvasSaveState: function (canvasID) {

        ctx(canvasID).save();

        return true;
    },

    CanvasRestoreState: function (canvasID) {

        ctx(canvasID).restore();

        return true;
    },

    Draw_Image: function (obj) {

        var ctx1 = ctx(obj["canvasID"]);

        ctx1.drawImage(img_Corner_Shape, obj["transferImageParameters"].x, obj["transferImageParameters"].y, obj["transferImageParameters"].width, obj["transferImageParameters"].height);

        return true;
    },


    Draw_Gauge: function (obj) {

        draw_Gauge(ctx(obj["canvasID"]), obj["color"], obj["transferParameters"]);


        return true;
    },





    Fill_Text: function (obj) {

        ctx(obj["canvasID"]).fillText(obj["transferFillTextParameters"].text,
            obj["transferFillTextParameters"].x,
            obj["transferFillTextParameters"].y);


        return true;
    },


    Set_Property: function (obj) {


        var prt = obj["transferCanvasProperty"].propertyName;

        if (prt) {
            ctx(obj["canvasID"])[prt] = obj["transferCanvasProperty"].propertyValue;
        }

        return true;
    },


    draw_Full_Size_Rect: function (obj) {


        var ctx1 = ctx(obj["canvasID"]);

        ctx1.beginPath();
        ctx1.fillStyle = obj["color"];
        ctx1.fillRect(0, 0, ctx1.canvas.clientWidth, ctx1.canvas.clientHeight);

        return true;
    },


    Clear_Canvas: function (canvasID) {

        var ctx1 = ctx(canvasID);


        ctx1.setTransform(1, 0, 0, 1, 0, 0);
        ctx1.clearRect(0, 0, ctx1.canvas.clientWidth, ctx1.canvas.clientHeight);

        return true;
    },


    Translate: function (obj) {

        ctx(obj["canvasID"]).translate(obj["x"], obj["y"]);

        return true;
    },



    Move_To: function (obj) {


        ctx(obj["canvasID"]).moveTo(obj["x"], obj["y"]);

        return true;
    },


    Line_To: function (obj) {


        ctx(obj["canvasID"]).lineTo(obj["x"], obj["y"]);

        return true;
    },


    Rotate: function (obj) {

        ctx(obj["canvasID"]).rotate(obj["angle"]);

        return true;
    },

    Set_Transform: function (canvasID) {


        ctx(canvasID).setTransform(1, 0, 0, 1, 0, 0);

        return true;
    },

    Begin_Path: function (canvasID) {

        ctx(canvasID).beginPath();
        return true;
    },


    Stroke: function (canvasID) {

        ctx(canvasID).stroke();

        return true;
    },


    Fill: function (canvasID) {

        ctx(canvasID).fill();

        return true;
    },

    Stroke_Rect: function (obj) {

        ctx(obj["canvasID"]).strokeRect(obj["transferRectParameters"].x,
            obj["transferRectParameters"].y,
            obj["transferRectParameters"].w,
            obj["transferRectParameters"].h);

        return true;
    },





    Preload_Image: function () {
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
    },



    Create_Radial_Gradient: function (obj) {


        grad = ctx(obj["canvasID"]).createRadialGradient(
            obj["transferRadialGradientParameters"].x0,
            obj["transferRadialGradientParameters"].y0,
            obj["transferRadialGradientParameters"].r0,
            obj["transferRadialGradientParameters"].x1,
            obj["transferRadialGradientParameters"].y1,
            obj["transferRadialGradientParameters"].r1);


        return true;
    },

    Gradient_Add_Color_Stop: function (obj) {



        grad.addColorStop(obj["stop"], obj["color"]);


        return true;
    },


    Gradient_Set_Stoke_Or_Fill_Style: function (obj) {


        if (obj["strokeOrFill"]) {
            ctx(obj["canvasID"]).strokeStyle = grad;
        }
        else {
            ctx(obj["canvasID"]).fillStyle = grad;
        }

        return true;
    },


    Render_To_UI: function (canvasID) {

        ctx(canvasID, true).drawImage(ctx(canvasID).canvas, 0, 0);

        return true;
    },


    Execute_Dynamic_Script: function (cmd) {

        var f = new Function(cmd);
        f();

        return true;
    },


};