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
        this[v] = t;
        return true;
    },
    GetData: function (v) {
        var result = this[v];
        delete this[v];
        return result;
    },
    ProcessData: function (v) {
        this[v] = this[v].split("").reverse().join("");
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
};