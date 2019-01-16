
importScripts('faker.js');


var i = 0;
var x = 0;

function abc() {

    x = Math.floor(Math.random() * 990) + 10;
    i = i + 1;
    //https://github.com/Marak/faker.js
    var workerResult = "N" + i.toString() + ", " + faker.name.findName() + ", " + faker.address.country() + ", Age " + (Math.floor(Math.random() * 50) + 15) + ", " + x.toString()+"ms";

    clients.forEach(function (client) {
        client.postMessage(workerResult);
    });

    setTimeout("abc()", x);
}



setTimeout(abc, 500);

var clients = [];

onconnect = function (e) {
    var port = e.ports[0];


    

    clients.push(port);


    port.addEventListener('message', function (e) {

        if (e.data === 'close') {
            self.close();
        };

    });

    port.start();
};