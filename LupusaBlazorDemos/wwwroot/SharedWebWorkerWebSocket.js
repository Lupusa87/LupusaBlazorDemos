importScripts('lib/lupEnums.js');
importScripts('lib/lupFunctions.js');
importScripts('lib/lupWebSoket.js');




var curr_port = 0;
var clients = [];
var messages = [];



function OnSocketMessage(e, c) {
    if (c === 0) {
        //binarydata: Array.from(new Int8Array(e))
        var b;
        if (e instanceof ArrayBuffer) {
            b = {
                Cmd: c,
                isBinary: true,
                binarydata: e,
                data: '',
                ClientID: clients.indexOf(curr_port) + 1,
            };
        }
        else {
            b = {
                Cmd: c,
                isBinary: false,
                binarydata: null,
                data: e,
                ClientID: clients.indexOf(curr_port) + 1,
            };
        }


        messages.push(b);
        clients.forEach(function (client) {
            client.postMessage(b);
        });

    }
    else {

        let b = {
            Cmd: c,
            isBinary: false,
            binarydata: null,
            data: e,
            ClientID: clients.indexOf(curr_port) + 1,
        };

        curr_port.postMessage(b);
    }
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
        curr_port = port;

        switch (e.data.cmd) {
            case CommandType.WW.Send:
                if (e.data.msg instanceof Object) {
                    WsSend(e.data.args, new Uint8Array(e.data.msg));
                }
                else {
                    WsSend(e.data.args, e.data.msg);
                }
                break;
            case CommandType.WW.Sync:
                if (messages.length > 0) {
                    messages.forEach(function (msg) {
                        port.postMessage(msg);
                    });
                }
                break;
            case CommandType.WW.Disconnect:
                clients.splice(clients.indexOf(port), 1);
                if (clients.length === 0) {
                    WebSockets_array.forEach(function (ws) {
                        ws.close();
                    });
                    self.close();
                }
                break;
            case CommandType.WS.Add:
                WsAdd(e.data.msg, e.data.args);
                break;
            case CommandType.WS.Remove:
                if (clients.length <= 1) {
                    WsRemove(e.data.msg);
                }
                break;
            case CommandType.WS.SetBinaryType:
                WsSetBinaryType(e.data.args, e.data.msg);
                break;
            case CommandType.MultyPurpose.Item1:
                WsCheckIfExistAready(e.data.msg);
                break;
            case CommandType.MultyPurpose.Item2:
                WsGetStatus(e.data.msg);
                break;
        }

    });

    port.start();
};

