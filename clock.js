function drawClock() {
    var canvas = document.getElementById("clock");
    var ctx = canvas.getContext("2d");

    ctx.beginPath();
    ctx.arc(250,250,200,0,2*Math.PI);
    ctx.stroke();

   /* for (var i = 0; i < 12; i++) {
        ctx.moveTo(250,250);
        ctx.lineTo(250,100);
        ctx.stroke();
    };*/


    ctx.fillStyle = "#000000";
    ctx.beginPath();
    ctx.arc(250,250,8,0,2*Math.PI);
    ctx.closePath();
    ctx.fill();
    ctx.stroke();


    ctx.beginPath();
    ctx.moveTo(250,250);
    ctx.lineTo(250,90);
    ctx.lineWidth = 5;
    ctx.stroke();

    ctx.beginPath();
    ctx.moveTo(250,250);
    ctx.lineTo(125,250);
    ctx.lineWidth = 8;
    ctx.stroke();

    ctx.beginPath();
    ctx.moveTo(250,250);
    ctx.lineTo(375,375);
    ctx.lineWidth = 1;
    ctx.stroke();
}

window.onload = function() {
    drawClock();
};