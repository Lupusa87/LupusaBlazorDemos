var audioCtx;
var Osctor;

function getArrayBufferFromFileAsync(file, o) {
    const reader = new FileReader();
    return new Promise((resolve, reject) => {
        reader.onload = function () { resolve(reader.result); };
        reader.onprogress = function (e) {
            window.BJSFDEJsFunctions.InvokeOnProgressAction("loadprogress," + e.loaded + "," + e.total);
        };
        reader.onerror = function (err) { reject(err); };

        switch (o) {
            case 0:
                reader.readAsArrayBuffer(file);
                break;
            case 1:
                reader.readAsText(file);
                break;
            default:
                reader.readAsArrayBuffer(file);
        }


    });
}



function dragstart1(e, id, dotnetHelper) {
    e.dataTransfer.setData('text', id.toString());
    dotnetHelper.invokeMethodAsync('InvokeDragStartFromJS', id);
}


function drop1(e, el, id, dotnetHelper) {

    if (e.preventDefault) { e.preventDefault(); }
    if (e.stopPropagation) { e.stopPropagation(); }

    dotnetHelper.invokeMethodAsync('InvokeDropFromJS', [id, e.dataTransfer.getData("text")]);

    document.getElementById(el).removeEventListener('dragstart', null);

    return false;
}


window.LBDJsFunctions = {
    calcfib: function (num) {
        return fib(num);
    },
    generateNewUser: function () {
        return faker.name.findName() + ", " + faker.address.country() + ", Age " + (Math.floor(Math.random() * 50) + 15);
    },
    Alert: function (message) {
        return alert(message);
    },
    SetData: function (v, t) {
        window[v] = t;
        return true;
    },
    GetData: function (v) {
        var result = window[v];
        delete window[v];
        return result;
    },
    ProcessData: function (v) {
        window[v] = window[v].split("").reverse().join("");
    },
    HasFile: async function (inputFile) {
        return document.getElementById(inputFile).files.length > 0;
    },
    ReadFile: async function (v, inputFile) {
        window[v] = await getArrayBufferFromFileAsync(document.getElementById(inputFile).files[0], 0);
        window.BJSFDEJsFunctions.InvokeOnMessageAction("fileloadingdone");
        return true;
    },
    GetFile: async function (v, inputFile) {
        return await getArrayBufferFromFileAsync(document.getElementById(inputFile).files[0], 1);
    },
    handleDragStart: function (el, id, dotnetHelper) {
        if (document.getElementById(el) !== null) {

            document.getElementById(el).addEventListener('dragstart', function (e) { dragstart1(e, id, dotnetHelper); }, true);
            return true;
        }
        else {
            console.log("can't find element");
        }

        return false;
    },
    handleDrop: function (el, id, dotnetHelper) {
        if (document.getElementById(el) !== null) {
            document.getElementById(el).addEventListener('drop', function (e) { drop1(e, el, id, dotnetHelper); }, true);
            return true;
        }
        else {
            console.log("can't find element");
        }

        return false;
    },
    Beep: function (vol, freq, duration) {
        if (audioCtx === undefined) {
            audioCtx = new AudioContext();
        }
        v = audioCtx.createOscillator();
        u = audioCtx.createGain();
        v.connect(u);
        v.frequency.value = freq;
        v.type = "square";
        u.connect(audioCtx.destination);
        u.gain.value = vol * 0.01;
        v.start(audioCtx.currentTime);
        v.stop(audioCtx.currentTime + duration * 0.001);

        return true;
    },
    PianoPlay: function (vol, freq) {
        if (audioCtx === undefined) {
            audioCtx = new AudioContext();
        }

        
        Osctor = audioCtx.createOscillator();
        u = audioCtx.createGain();
        Osctor.connect(u);
        Osctor.frequency.value = freq;
        Osctor.type = "square";
        u.connect(audioCtx.destination);
        u.gain.value = vol * 0.01;
        Osctor.start(audioCtx.currentTime);
        //v.stop(audioCtx.currentTime + duration * 0.001);

        return true;
    },
    PianoStop: function () {
        if (Osctor !== undefined) {
            Osctor.stop();
        }
        return true;
    }
};