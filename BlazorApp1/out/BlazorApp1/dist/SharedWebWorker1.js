importScripts('lib/lupEnums.js');
importScripts('lib/lupFunctions.js');
importScripts('lib/faker.js');


var i = 0;
var x = 0;
var clients = [];
var TextOrBinary = false;

function abc() {
 
    x = Math.floor(Math.random() * 2500) + 500;
    i = i + 1;
    //https://github.com/Marak/faker.js
    var workerResult = getTime() + " N" + i.toString() + ", " + faker.name.findName() + ", " + faker.address.country() + ", Age " + (Math.floor(Math.random() * 50) + 15) + ", " + x.toString()+"ms";


    myPush(workerResult);

    

    setTimeout("abc()", x);

}



setTimeout(abc, 1000);



function myPush(msg) {
    
    if (TextOrBinary === false) {

        let b = {
            Cmd: 0,
            isBinary: false,
            binarydata: null,
            data: msg,
            ClientID: 0
        };

        clients.forEach(function (client) {
            client.postMessage(b);
        });
    }
    else {

        var q = new TextEncoder("utf-8").encode(msg);

        let b = {
            Cmd: 0,
            isBinary: true,
            binarydata: q,
            data: '',
            ClientID: 0
        };

        clients.forEach(function (client) {
            client.postMessage(b);
        });

    }
}



onconnect = function (e) {
    var port = e.ports[0];


    clients.push(port);

    port.addEventListener('message', function (e) {

        switch (e.data.cmd) {
            case CommandType.WW.Send:
                i = i + 1;
               
                var s;
                if (e.data.msg instanceof Object) {
                    s = new TextDecoder("utf-8").decode(e.data.msg);
                }
                else {
                    s = e.data.msg;
                }

                var a = getTime() + " N" + i.toString() + ", " + s + ", 1ms";
               
                myPush(a);

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