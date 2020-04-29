////////////// Shared Web Worker ///////////////
var clients = [];
var messages = [];

function OnSocketMessage(e) {
   
        messages.push(e);
        clients.forEach(function (client) {
            client.postMessage(e);
        });
}

onconnect = function (e) {
    var port = e.ports[0];

    clients.push(port);

    if (messages.length > 0) {
        messages.forEach(function (msg) {
            port.postMessage(msg);
        });
    }

    port.addEventListener('message', function (e) {

        WsSend(new Uint8Array(e.data));

    });


    if (WebSocket1 === null) {
        WsAdd("wss://echo.websocket.org");
    }

    port.start();
};


///////////// Web Socket /////////////

var WebSocket1 = null;


function WsOnOpen(e) {

}

function WsOnClose(e) {

}

function WsOnError(e) {

    console.log("invoked WsOnError - " + e.message);

}

function WsOnMessage(e) {
  
    OnSocketMessage(e.data);
}


function WsAdd(par_url) {

    WebSocket1 = new WebSocket(par_url);
    WebSocket1.binaryType = "arraybuffer";

    WebSocket1.onopen = WsOnOpen;
    WebSocket1.onclose = WsOnClose;
    WebSocket1.onerror = WsOnError;
    WebSocket1.onmessage = WsOnMessage;

    return true;
}



function WsSend(wsMessage) {
    var result = false;

    WebSocket1.send(wsMessage);
   
    return result;
}