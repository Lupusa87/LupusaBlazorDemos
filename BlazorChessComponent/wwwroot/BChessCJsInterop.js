window.BChessCJsInterop = {
  alert: function (message) {
    return alert(message);
    },
    GetElementBoundingClientRect: function (obj) {
        let rect = document.getElementById(obj["id"]).getBoundingClientRect();
        obj["dotnethelper"].invokeMethodAsync('invokeFromjs', obj["id"], rect.left.toFixed(2), rect.top.toFixed(2));
        return true;
    },
    SetCursor: function (cursorStyle) {
        document.body.style.cursor = cursorStyle;
        return true;
    },
};
