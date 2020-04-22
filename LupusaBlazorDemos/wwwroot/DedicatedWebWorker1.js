importScripts('lib/lupEnums.js');
importScripts('lib/lupFunctions.js');

onmessage = function (e) {

   
    if (e.data.cmd === CommandType.WW.Send) {

        
        if (e.data.msg instanceof Object)
        {
            let s = new TextDecoder("utf-8").decode(e.data.msg);


            if (isNaN(s)) {
                console.log(getTime() + " Error: not valid number!");
            }
            else {
                var q = new TextEncoder("utf-8").encode(fib(s).toString());

                let b = {
                    Cmd: 0,
                    isBinary: true,
                    binarydata: q,
                    data: '',
                    ClientID: 0
                };
                postMessage(b);
            }
        }
        else
        {
            if (isNaN(e.data.msg)) {
                console.log(getTime() + " Error: not valid number!");
            }
            else {

                let b = {
                    Cmd: 0,
                    isBinary: false,
                    binarydata: null,
                    data: fib(e.data.msg).toString(),
                    ClientID: 0
                };

                postMessage(b);
            }
        }

       

    }
    
};





