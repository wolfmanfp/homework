function startGame() {
    $(".get_token").click(function(){
        $("#form").show();
        $("#intro").hide();
        $("#status").text("");
        $("div.get_token").hide();
        $("#game").show();
        $("#guess").select();
        $.get("http://api.gamer365.hu/numgame/register", function (data) {
            if (data.status == "ok") {
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
        var $status = $("#status");
        if ($.isNumeric(number) && number>=1 && number<=100) {
            $.post("http://api.gamer365.hu/numgame/guess",
                {
                    token: token,
                    value: number
                },
                function(response){
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
                                    $("#game").hide();
                                    $status.text("You win! Number of guesses: "+guesses);
                                    $("div.get_token").show();
                                    break;
                            }
                            break;
                        case "invalid token":
                            $status.text("Invalid token!");
                            break;
                    }
                });
        } else {
            $status.text("Invalid number!");
        }
    });
}

$(document).ready(function(){
    startGame();
});