

window.addEventListener("scroll", updatePosition, false);
window.addEventListener("resize", updatePosition, false);


function updatePosition() {
    let rect = document.getElementById("PaintArea1").getBoundingClientRect();

    let myleft = rect.left.toFixed(2) + window.scrollX;
    let mytop = rect.top.toFixed(2) + window.scrollY;

    DotNet.invokeMethodAsync('BlazorPaintComponent', 'invokeFromjs_UpdateSVGPosition', myleft, mytop);

}




window.JsInteropBPaintComp = {
    alert: function (message) {
        return alert(message);
    },
    log: function (message) {
        return log(message);
    },
    GetElementBoundingClientRect: function (obj) {
        let rect = document.getElementById(obj["id"]).getBoundingClientRect();

        let myleft = rect.left.toFixed(2) + window.scrollX;
        let mytop = rect.top.toFixed(2) + window.scrollY;





        obj["dotnethelper"].invokeMethodAsync('invokeFromjs', obj["id"], myleft, mytop);
        return true;
    },
    SetCursor: function (cursorStyle) {
        document.body.style.cursor = cursorStyle;
        return true;
    },
};