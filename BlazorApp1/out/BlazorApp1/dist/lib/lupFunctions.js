function fib(num) {

    var result = 0;

    if (num < 2) {
        result = num;
    } else {
        result = fib(num - 1) + fib(num - 2);
    }

    return result;
}

function createGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}  



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

function convertUTCDateToLocalDate(date) {

    date = new Date(date);

    var localOffset = date.getTimezoneOffset() * 60000;

    var localTime = date.getTime();

    date = localTime - localOffset;

    return date;

};