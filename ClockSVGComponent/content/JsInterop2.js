var TotalAddedSeconds = 0;

var svgClock;
var seconds;
var minutes;
var hours;

var tmp_number;

var radius;
var radius90;

function setClock() {


    var date = new Date();

    //date = new Date(date.getTime() + TotalAddedSeconds * 1000);
    //TotalAddedSeconds = TotalAddedSeconds + 1;

    //if (typeof svgClock === 'undefined') {
    //    svgClock = document.getElementById("svgclock");
    //    radius = svgClock.getBBox().width / 2;
    //    radius90 = radius * 0.81;
    //    seconds = document.getElementById("GaugeSecond");
    //    minutes = document.getElementById("GaugeMinute");
    //    hours = document.getElementById("GaugeHour");
    //}



        var s = (date.getUTCSeconds() + date.getMilliseconds() / 1000);
        var m = date.getUTCMinutes() + s / 60;
        var h = date.getUTCHours() - 5;
        if (h < 0) {
            h = h + 12
        }
        h = h % 12;
        h = h + m / 60;
        h = h * 5;


        adjust(seconds, s, radius90 * 0.64);
        adjust(minutes, m, radius90 * 0.55 * 1.03);
        adjust(hours, h, radius90 * 0.35 * 1.08);


        adjustNumber(s);
    
}

function adjustNumber(s) {


   

    var a;
    var _opacity = 1;
    var _font_Size = 15;
    var _font_Bold = false;
    var _font_Bold_String = "normal";
    var c = s / 5;

    for (var num = 0; num < 12; num++) {


        if (Math.abs(c - num) < 0.3) {
            _opacity = 1;

            _font_Size = radius90 * 0.20;


            if (num % 3 === 0) {
                _font_Bold = true;
                _font_Size = radius90 * 0.25;
            }
        }
        else {
            _opacity = 0.7;

            _font_Size = radius90 * 0.15;


            if (num % 3 === 0) {
                _font_Bold = true;
                _font_Size = radius90 * 0.2;
            }

        }



        if (num === 0) {
            a = "12";
        }
        else {
            a = num;
        }


      
        tmp_number = document.getElementById("Number" + a);
       

        if (tmp_number !== null) {


            if (tmp_number.getAttribute("opacity") !== _opacity) {

                tmp_number.setAttribute("opacity", _opacity);

            }


            if (tmp_number.getAttribute("font-size") !== _font_Size) {

                tmp_number.setAttribute("font-size", _font_Size);

            }



            if (_font_Bold) {
                _font_Bold_String = "bold";
            }
            else {
                _font_Bold_String = "normal";
            }


            if (tmp_number.getAttribute("font-wight") !== _font_Bold_String) {

                tmp_number.setAttribute("font-wight", _font_Bold_String);

            }

        }

    }

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

function GetPoint(angle, r, radiusOrigin) {
    var radians = (angle - 90) * (Math.PI / 180);


    var obj = {
        x: radiusOrigin + r * Math.cos(radians),
        y: radiusOrigin + r * Math.sin(radians),
    };

    return obj;

}


window.JsInterop2 = {

    Run: function () {



        
        svgClock = document.getElementById("svgclock");
        radius = svgClock.getBBox().width / 2;
        radius90 = radius * 0.81;
        seconds = document.getElementById("GaugeSecond");
        minutes = document.getElementById("GaugeMinute");
        hours = document.getElementById("GaugeHour");
        

        setInterval("setClock()", 200);


        return true;
    }

};


