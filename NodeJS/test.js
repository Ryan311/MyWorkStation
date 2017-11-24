var events = require('events');
var eventEmitter = new events.EventEmitter();

var connectHandler = function connected()
{
    console.log('Connect OK');
    eventEmitter.emit('data_received');
}

eventEmitter.on('connection', connectHandler);
eventEmitter.on('data_received', function(){
    console.log('data received OK');
});

eventEmitter.emit('connect');
console.log('Program over');