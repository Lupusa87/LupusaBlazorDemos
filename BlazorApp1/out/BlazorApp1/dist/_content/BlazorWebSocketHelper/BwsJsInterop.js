var WebSockets_array = [];

function WsOnOpen(e, dotnethelper) {
    dotnethelper.invokeMethodAsync('InvokeStateChanged', 1);
}

function WsOnClose(e, dotnethelper) {
    dotnethelper.invokeMethodAsync('InvokeStateChanged', 3);
}

function WsOnError(e, dotnethelper) {
    dotnethelper.invokeMethodAsync('InvokeOnError', "Connection Error!");
}


function WsOnMessage(e, dotnethelper) {
    dotnethelper.invokeMethodAsync('InvokeOnMessage', e.data);
}

window.BwsJsFunctions = {
    alert: function (message) {
        return alert(message);
    },
    showPrompt: function (message) {
        return prompt(message, 'Type anything here');
    },
    WsAdd: function (obj) {
      
        var b = {
            id: obj.wsID,
            ws: new WebSocket(obj.wsUrl)
        };

        obj.dotnethelper.invokeMethodAsync('InvokeStateChanged', 0);

        b.ws.onopen = function (e) { WsOnOpen(e, obj.dotnethelper); };
        //b.ws.onopen = function (evt) {

        //    obj.dotnethelper.invokeMethodAsync('InvokeOnOpen', 1);

        //};
        b.ws.onclose = function (e) { WsOnClose(e, obj.dotnethelper); };
        b.ws.onerror = function (e) { WsOnError(e, obj.dotnethelper); };
        b.ws.onmessage = function (e) { WsOnMessage(e, obj.dotnethelper); };
        WebSockets_array.push(b);


        return true;
    },
    WsClose: function (WsID) {
        var result = true;
        var index = WebSockets_array.findIndex(x => x.id === WsID);

        if (index > -1) {
            WebSockets_array[index].ws.close(); 
        }
        else {
            result = false;
        }

        return result;
    },
    WsRemove: function (WsID) {
        var result = true;
        var index = WebSockets_array.findIndex(x => x.id === WsID);

        if (index > -1) {
            WebSockets_array.splice(index, 1);
        }
        else {
            result = false;
        }

        return result;
    },
    WsSend: function (obj) {
        var result = false;

        var index = WebSockets_array.findIndex(x => x.id === obj.wsID);

        if (index > -1) {

            WebSockets_array[index].ws.send(obj.wsMessage);
            result = true;
            
        }

        return result;
    },
    WsGetStatus: function (WsID) {

        var result = -1;

        var index = WebSockets_array.findIndex(x => x.id === WsID);

        if (index > -1) {
            result = WebSockets_array[index].ws.readyState;
        }
       
        return result;
    },
};
