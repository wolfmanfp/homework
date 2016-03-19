function startGame() {
    $.get("http://api.gamer365.hu/numgame/register", function(data){
        if(data.status=="ok") {
            var token = data.token;
            console.log(token);
        }
    });
}

$(document).ready(function(){
    startGame();
});