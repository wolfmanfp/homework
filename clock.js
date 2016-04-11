var canvas = document.getElementById("clock");
var ctx = canvas.getContext("2d");
var date = new Date;
var pi = Math.PI;
var w = canvas.width;
var h = canvas.height;
var angle;

function drawClock() {
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
    ctx.beginPath();
    ctx.moveTo(250,250);
    ctx.lineTo(125,250);
    ctx.lineWidth = 4;
    ctx.stroke();
}

function drawMinutes() {
    var minutes = date.getMinutes();
    ctx.beginPath();
    ctx.moveTo(250,250);
    ctx.lineTo(250,90);
    ctx.lineWidth = 4;
    ctx.stroke();
}

function drawSeconds() {
    var seconds = date.getSeconds();
    ctx.beginPath();
    ctx.moveTo(250,250);
    ctx.lineTo(375,375);
    ctx.lineWidth = 1;
    ctx.stroke();
}

window.onload = function() {
    setInterval(drawClock(), 1000);
};