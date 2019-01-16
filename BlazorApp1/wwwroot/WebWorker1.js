function fib(num) {
    var result = 0;

    if (num < 2) {
        result = num;
    } else {
        result = fib(num - 1) + fib(num - 2);
    }

    return result;
}

onmessage = function (e) {
    postMessage(fib(e.data).toString());
};





