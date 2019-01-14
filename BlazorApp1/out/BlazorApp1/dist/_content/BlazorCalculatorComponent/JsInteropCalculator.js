
document.onkeyup = function (evt) {
    evt = evt || window.event;
    DotNet.invokeMethodAsync('BlazorCalculatorComponent', 'KeyUpFromjs', evt.keyCode);

   
};






