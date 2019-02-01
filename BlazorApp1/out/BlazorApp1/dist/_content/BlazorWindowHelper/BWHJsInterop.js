
var OnOrOff = false;

document.onkeyup = function (evt) {

    if (OnOrOff===true) {
        evt = evt || window.event;
        DotNet.invokeMethodAsync('BlazorWindowHelper', 'InvokeKeyUp', evt.keyCode);
    }
};


window.addEventListener("scroll", onScroll, false);
window.addEventListener("resize", onResize, false);


function onScroll() {
    if (OnOrOff === true) {
        DotNet.invokeMethodAsync('BlazorWindowHelper', 'InvokeOnScroll');
    }
}

function onResize() {
    if (OnOrOff === true) {
        DotNet.invokeMethodAsync('BlazorWindowHelper', 'InvokeOnResize');
    }
}


window.BWHJsFunctions = {
    showPrompt: function (message) {
    return prompt(message, 'Type anything here');
    },
    alert: function (message) {
        alert(message);
        return true;
    },
    log: function (message) {
        console.log(message);
        return true;
    },
    logWithTime: function (message) {
        console.log(getTime() +" " + message);
        return true;
    },
    setOnOrOff: function (b) {
        console.log(b);
        OnOrOff = b;
        console.log(OnOrOff);
        return true;
    },
};
