var WebSockets_array = [];

function WsOnOpen(e) {
    OnSocketMessage("1", 1);
}

function WsOnClose(e) {
    OnSocketMessage("2", 1);
}

function WsOnError(e) {
    OnSocketMessage("3", 1);
    console.log("invoked WsOnError - " + e.message);

}

function WsOnMessage(e) {

    OnSocketMessage(e.data, 0);
}


function WsAdd(par_id, par_url) {

    var b = {
        id: par_id,
        url: par_url,
        ws: new WebSocket(par_url)
    };

    OnSocketMessage("0", 1);
    b.ws.onopen = WsOnOpen;

    b.ws.onclose = WsOnClose;
    b.ws.onerror = WsOnError;
    b.ws.onmessage = WsOnMessage;
    WebSockets_array.push(b);


    return true;
}

function WsSetBinaryType(wsID, wsBinaryType) {
    var result = true;
    var index = WebSockets_array.findIndex(x => x.id === wsID);

    if (index > -1) {

        WebSockets_array[index].ws.binaryType = wsBinaryType;
    }
    else {
        result = false;
    }

    return result;
}

function WsClose(WsID) {
    var result = true;
    var index = WebSockets_array.findIndex(x => x.id === WsID);

    if (index > -1) {
        OnSocketMessage("2", 1);
        WebSockets_array[index].ws.close();
    }
    else {
        result = false;
    }

    return result;
}

function WsRemove(WsID) {
    var result = true;
    var index = WebSockets_array.findIndex(x => x.id === WsID);

    if (index > -1) {
        OnSocketMessage("2", 1);
        WebSockets_array[index].ws.close();
        WebSockets_array.splice(index, 1);
    }
    else {
        result = false;
    }

    return result;
}

function WsSend(wsID, wsMessage) {
    var result = false;

    var index = WebSockets_array.findIndex(x => x.id === wsID);

    if (index > -1) {

        WebSockets_array[index].ws.send(wsMessage);

        result = true;

    }

    return result;
}


function WsCheckIfExistAready(wsURL) {

    var index = WebSockets_array.findIndex(x => x.url === wsURL);

    if (index > -1) {
        OnSocketMessage(WebSockets_array[index].id, 2);
    }
    else {
        OnSocketMessage("null", 2);
    }
}

function WsGetStatus(WsID) {

    var index = WebSockets_array.findIndex(x => x.id === WsID);

    if (index > -1) {
        OnSocketMessage(WebSockets_array[index].ws.readyState.toString(), 1);

    }
}


