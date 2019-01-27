importScripts('lib/lupEnums.js');
importScripts('lib/lupFunctions.js');

var clients = [];
var messages = [];

var TextOrBinary = false;




function myPush(msg, prt) {

    var b;
    if (TextOrBinary === false) {

        b = {
            Cmd: 0,
            isBinary: false,
            binarydata: null,
            data: msg,
            ClientID: clients.indexOf(prt) + 1
        };

    }
    else {

        var q = new TextEncoder("utf-8").encode(msg);

        b = {
            Cmd: 0,
            isBinary: true,
            binarydata: Array.from(new Int8Array(q)),
            data: '',
            ClientID: clients.indexOf(prt) + 1
        };
    }

    messages.push(b);

    clients.forEach(function (client) {
        client.postMessage(b);
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

        switch (e.data.cmd) {
            case CommandType.WW.Send:

                var s;
                if (e.data.msg instanceof Object) {
                    s = new TextDecoder("utf-8").decode(e.data.msg);
                }
                else {
                    s = e.data.msg;
                }

                myPush(s, port);
                
                break;

            case CommandType.WW.Disconnect:

                clients.splice(clients.indexOf(port), 1);

                if (clients.length === 0) {

                    self.close();
                }

                break;
            case CommandType.MultyPurpose.Item1:
                TextOrBinary = e.data.msg;
                break;
        }

    });

    port.start();
};