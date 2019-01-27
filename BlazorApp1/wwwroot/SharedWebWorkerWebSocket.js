importScripts('lib/lupEnums.js');
importScripts('lib/lupFunctions.js');
importScripts('lib/lupWebSoket.js');

var curr_port = 0;
var clients = [];
var messages = [];



function OnSocketMessage(e, c) {
  
    if (c === 0) {

        var b;
        if (e instanceof ArrayBuffer)
        {
            b = {
                Cmd: c,
                isBinary: true,
                binarydata: Array.from(new Int8Array(e)),
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
                  
                    s = new TextDecoder("utf-8").decode(e.data.msg);
                    s = JSON.parse(s);
                 
                    let b = {
                        wsID: s.wsID,
                        wsMessage: new Uint8Array(new TextEncoder("utf-8").encode(s.wsMessage)),
                    };
                   
                    WsSend(b);
                }
                else {
                    WsSend(JSON.parse(e.data.msg));
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
                WsAdd(JSON.parse(e.data.msg));
                break;
            case CommandType.WS.Remove:
                if (clients.length <= 1) {
                    WsRemove(e.data.msg);
                }
                break;
            case CommandType.WS.SetBinaryType:
                WsSetBinaryType(JSON.parse(e.data.msg));
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

