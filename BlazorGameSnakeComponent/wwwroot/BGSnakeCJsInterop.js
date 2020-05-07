var audio_array = [];

window.BGSnakeCJsInterop = {
    Alert: function (a) {
        alert(a);
        return true;
    },
    InitializeSound: function(obj) {
        var index = audio_array.findIndex(x => x === obj["id"]);
        if (index === -1) {
            var audio = new Audio(obj["path"]);
            if (obj["loop"]) {
                audio.loop = true;
            }
            audio_array.push(audio);
        }
        return true;
    },
    ManageSound: function (obj) {
        var audio = audio_array[obj["id"]];
            if (obj["command"] === "play") {
                audio.currentTime = 0;
                audio.play();
            }
            else {
                audio.pause();
            }
        return true;
    }
};
