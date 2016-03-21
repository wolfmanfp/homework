function startGame() {
    $(".start").click(function(){
        $("#intro").hide();
        $("#game").show();
        $.get("http://api.gamer365.hu/numgame/register", function(data){
            if(data.status=="ok") {
                var token = data.token;
                guess(token);
            }
        });
    });
}

function guess(token) {
    $("#game").submit(function(){
        $guess = $("#guess");
        var number = $guess.val();
        $guess.val("");
        if ($.isNumeric(number) && number>=1 && number<=100) {
            $.post("http://api.gamer365.hu/numgame/guess",
                {
                    token: token,
                    value: number
                },
                function(response){
                    var $status = $("#status");
                    switch (response.status) {
                        case "ok":
                            switch(response.answer) {
                                case "toolow":
                                    $status.text("Too low!");
                                    break;
                                case "toohigh":
                                    $status.text("Too high!");
                                    break;
                                case "win":
                                    var guesses = response.guesses;
                                    $status.text("You win! Number of guesses: "+guesses);
                                    break;
                            }
                            break;
                        case "invalid token":
                            alert("Invalid token!");
                            break;
                    }
                });
        } else {
            alert("Invalid number!");
        }
    });
}

$(document).ready(function(){
    startGame();
});