var WebWorkers_array = [];

function WwOnMessage(e, dotnethelper) {
    dotnethelper.invokeMethodAsync('InvokeOnMessage', e.data);
}

function WwOnError(e, dotnethelper) {
    dotnethelper.invokeMethodAsync('InvokeOnError', e.message);
}


window.BwwJsFunctions = {
  alert: function (message) {
      return alert(message);
  },
  showPrompt: function (message) {
    return prompt(message, 'Type anything here');
  },
  WwAddDedicated: function (obj) {

        var b = {
            id: obj.wwID,
            ww: new Worker(obj.wwUrl),
            type:0
        };

        obj.dotnethelper.invokeMethodAsync('InvokeStateChanged', 1);


        b.ww.onmessage = function (e) { WwOnMessage(e, obj.dotnethelper); };

        b.ww.addEventListener('error', function (e) { WwOnError(e, obj.dotnethelper); }, false);
       
        WebWorkers_array.push(b);


        return true;
    },
    WwAddShared: function (obj) {

        var b = {
            id: obj.wwID,
            ww: new SharedWorker(obj.wwUrl),
            type:1
        };

        obj.dotnethelper.invokeMethodAsync('InvokeStateChanged', 1);


        b.ww.port.onmessage = function (e) { WwOnMessage(e, obj.dotnethelper); };

        b.ww.addEventListener('error', function (e) { WwOnError(e, obj.dotnethelper); }, false);

        WebWorkers_array.push(b);

        return true;
    },
    WwRemove: function (WwID) {
        var result = true;
        var index = WebWorkers_array.findIndex(x => x.id === WwID);

        if (index > -1) {
            WebWorkers_array[index].ww.terminate();
            WebWorkers_array.splice(index, 1);
        }
        else {
            result = false;
        }

        return result;
    },
    WwSendDedicated: function (obj) {
        var result = false;

        var index = WebWorkers_array.findIndex(x => x.id === obj.wwID);

        if (index > -1) {

            WebWorkers_array[index].ww.postMessage(obj.wwMessage);
            result = true;

        }

        return result;
    },
    WwSendShared: function (obj) {
        var result = false;

        var index = WebWorkers_array.findIndex(x => x.id === obj.wwID);

        if (index > -1) {

            WebWorkers_array[index].ww.port.postMessage(obj.wwMessage);
            result = true;
        }

        return result;
    },
};
