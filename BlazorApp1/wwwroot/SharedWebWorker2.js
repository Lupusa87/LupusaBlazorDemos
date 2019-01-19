function createGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}


function convertUTCDateToLocalDate(date) {

    date = new Date(date);

    var localOffset = date.getTimezoneOffset() * 60000;

    var localTime = date.getTime();

    date = localTime - localOffset;

    return date;

};






var clients = [];
var messages = [];

onconnect = function (e) {
    var port = e.ports[0];


    clients.push(port);


    console.log("connected new");
    console.log("messages to push " + messages.length);
    if (messages.length > 0) {
        messages.forEach(function (msg) {
            console.log("pushed " + msg);
            port.postMessage(msg);
        });
    }
    console.log("sync done");

    port.addEventListener('message', function (e) {

        if (e.data === 'CmdDisconnect') {

            clients.splice(clients.indexOf(port), 1);

            if (clients.length === 0) {

                self.close();
            }

        }
        else {


            var b = {
                GUID: createGuid(),
                Caption: e.data,
                TimeStamp: convertUTCDateToLocalDate(Date.now()),
                ClientID: clients.indexOf(port) + 1
            };


            var a = JSON.stringify(b);
            messages.push(a);

            clients.forEach(function (client) {
                client.postMessage(a);
            });
        }




    });

    port.start();
};