
document.onkeyup = function (evt) {
    evt = evt || window.event;

   
    try {
        DotNet.invokeMethodAsync('BlazorPasswordPatternComponent', 'KeyUpFromjs', evt.keyCode);
    }
    catch (err) {

    }
    


    try {
        DotNet.invokeMethodAsync('BlazorCalculatorComponent', 'KeyUpFromjs', evt.keyCode);
    }
    catch (err) {
       
    }

    try {
        DotNet.invokeMethodAsync('BlazorGameSnakeComponent', 'KeyUpFromjs', evt.keyCode);
    }
    catch (err) {
       
    }
};