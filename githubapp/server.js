var express = require('express')
var app = express()


app.all('/', function (req, res) {
    console.log(req.rawHeaders);
    console.log(req.r);
    console.log(req.method);
    Object.keys(req.headers).forEach(x => console.log(x + ": " + req.headers[x]))
    console.log(JSON.stringify(req.headers));
    console.log(req.body)
    res.send('OK')
})


// app.get('/', function (req, res) {
//     console.log('Get');
//     console.log(JSON.stringify(req.));
//     console.log(req.body)
//     res.send('OK')
// })

// app.put('/', function (req, res) {
//     console.log('Put');
//     console.log(JSON.stringify(req.headers));
//     console.log(req.body)
//     res.send('OK')
// })

// app.delete('/', function (req, res) {
//     console.log('Delete');
//     console.log(JSON.stringify(req.headers));
//     console.log(req.body)
//     res.send('OK')
// })

// app.patch('/', function (req, res) {
//     console.log('Patch');
//     console.log(JSON.stringify(req.headers));
//     console.log(req.body)
//     res.send('OK')
// })

app.listen(8001, function () {
    console.log('listening on port 8000')
})