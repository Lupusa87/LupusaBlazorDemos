

var svgClock;
var seconds;
var minutes;
var hours;
var radius;
var radius90;

function setClock(date) {

    if (svgClock === undefined) {
        svgClock = document.getElementById("svgclock");
        radius = svgClock.getBBox().width / 2;
        radius90 = radius * 0.81;
        seconds = document.getElementById("GaugeSecond");
        minutes = document.getElementById("GaugeMinute");
        hours = document.getElementById("GaugeHour");
    }


    var s = (date.getUTCSeconds() + date.getMilliseconds() / 1000);
    var m = date.getUTCMinutes() + s / 60;
    var h = date.getUTCHours() - 5;
    h = h % 12;
    h = h + m / 60;
    h = h * 5;
  

    adjust(seconds, s, radius90 * 0.64);
    adjust(minutes, m, radius90 * 0.55*1.03);
    adjust(hours, h, radius90 * 0.35*1.08);

}

function adjust(element, angle, r) {
    
    var _opacity = angle / 60;
  

    angle = angle * 6;

    var l = radius - r;

    var a = 0;


    if (angle > 180) {
        a = 1;
    }



    var p = GetPoint(angle, r, radius);


    var _d = "M " + radius + " " + radius +
        " L" + radius + " " + l +
        " A" + r + " " + r +
        " 0 " + a + " 1 " + p.x + " " + p.y + " Z";

    element.setAttribute("d", _d);
    element.setAttribute("opacity", _opacity);

}

function GetPoint(angle, r, radiusOrigin)
{
    var radians = (angle - 90) * (Math.PI / 180);

    
    var obj = {
        x: radiusOrigin + r * Math.cos(radians),
        y: radiusOrigin + r * Math.sin(radians),
    };

    return obj;
  
}



Blazor.registerFunction('BlazorLib2.JsInterop2.Run', (obj) => {


    setInterval("setClock(new Date())", 500);
   

    return true;
});