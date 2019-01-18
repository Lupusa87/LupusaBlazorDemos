
importScripts('faker.js');


function addZero(i, j = 1) {
    if (i < 10) {
        i = "0" + i;
    }
    if (j === 2) {
        if (i < 100) {
            i = "0" + i;
        }
    }
    return i;
}

function getTime() {
    var d = new Date();
    var h = addZero(d.getHours());
    var m = addZero(d.getMinutes());
    var s = addZero(d.getSeconds());
    var ms = addZero(d.getMilliseconds(), 2);
    return h + ":" + m + ":" + s + "." + ms;
}



var i = 0;
var x = 0;

function abc() {

    x = Math.floor(Math.random() * 2500) + 500;
    i = i + 1;
    //https://github.com/Marak/faker.js
    var workerResult = getTime() + " N" + i.toString() + ", " + faker.name.findName() + ", " + faker.address.country() + ", Age " + (Math.floor(Math.random() * 50) + 15) + ", " + x.toString() + "ms";

    clients.forEach(function (client) {
        client.postMessage(workerResult);
    });

    setTimeout("abc()", x);
}



setTimeout(abc, 1000);

var clients = [];

onconnect = function (e) {
    var port = e.ports[0];




    clients.push(port);


    port.addEventListener('message', function (e) {

        if (e.data === 'CmdDisconnect') {

            clients.splice(clients.indexOf(port), 1);

            if (clients.length === 0) {

                self.close();
            }
        }
        else {

            i = i + 1;
            var workerResult = getTime() + " N" + i.toString() + ", " + e.data + ", 1ms";


            clients.forEach(function (client) {
                client.postMessage(workerResult);
            });
        }




    });

    port.start();
};