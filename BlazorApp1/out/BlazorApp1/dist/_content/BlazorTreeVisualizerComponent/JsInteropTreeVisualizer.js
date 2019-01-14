window.JsInteropTreeVisualizer = {
    showPrompt: function (message) {
    return prompt(message, 'Type anything here');
    },
    alert: function (message) {
        alert(message);
        return true;
    },
    addLog: function (message) {
        console.log(message);
        return true;
    },
    clearTree: function () {

         var myNode = document.getElementById("mytree1");
         while (myNode.firstChild) {
             myNode.removeChild(myNode.firstChild);
         }
        return true;
    }
};
