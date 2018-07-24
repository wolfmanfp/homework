var canvas = document.getElementById("clock");
var ctx = canvas.getContext("2d");
var date;
var pi = Math.PI;
var w = canvas.width;
var h = canvas.height;
var angle;

function drawClock() {
    date = new Date();

    ctx.clearRect(0,0,w,h);

    ctx.beginPath();
    ctx.arc(w/2,h/2,200,0,2*pi);
    ctx.lineWidth = 5;
    ctx.stroke();

    ctx.fillStyle = "#000000";
    ctx.beginPath();
    ctx.arc(w/2,h/2,8,0,2*pi);
    ctx.closePath();
    ctx.fill();
    ctx.stroke();

    drawMarks();
    drawHours();
    drawMinutes();
    drawSeconds();
}

function drawMarks() {
    for (var i = 0; i < 60; i++) {
        angle = i*pi*2/60;
        ctx.beginPath();
        ctx.moveTo(w/2+Math.cos(angle)*190, h/2+Math.sin(angle)*190);
        ctx.lineTo(w/2+Math.cos(angle)*180, h/2+Math.sin(angle)*180);
        if (i%5 == 0) {
            ctx.lineWidth = 3;
        } else {
            ctx.lineWidth = 1;
        }
        ctx.stroke();
    }
}

function drawHours() {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    angle = 2*pi*(hours*5+minutes/60*5)/60 - 2*pi/4;
    ctx.beginPath();
    ctx.moveTo(w/2,h/2);
    ctx.lineTo(w/2+Math.cos(angle)*125, h/2+Math.sin(angle)*125);
    ctx.lineWidth = 4;
    ctx.stroke();
}

function drawMinutes() {
    var minutes = date.getMinutes();
    angle = 2*pi*minutes/60 - 2*pi/4;
    ctx.beginPath();
    ctx.moveTo(w/2,h/2);
    ctx.lineTo(w/2+Math.cos(angle)*170, h/2+Math.sin(angle)*170);
    ctx.lineWidth = 4;
    ctx.stroke();
}

function drawSeconds() {
    var seconds = date.getSeconds();
    angle = 2*pi*seconds/60 - 2*pi/4;
    ctx.beginPath();
    ctx.moveTo(w/2,h/2);
    ctx.lineTo(w/2+Math.cos(angle)*190, h/2+Math.sin(angle)*190);
    ctx.lineWidth = 1;
    ctx.stroke();
}

window.onload = function() {
    setInterval(drawClock, 500);
};