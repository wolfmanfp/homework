var cellNumber = 21;

function createTable() {
    var $tableholder = $('#maze');
    var $table= $('<table>');

    for (var i = 0; i < cellNumber; i++) {
        var $tr = $('<tr>');
        for (var j = 0; j < cellNumber; j++) {
            var $td = $('<td>').attr('x', i).attr('y', j);
            $tr.append($td);
        }
        $table.append($tr);
    }
    $tableholder.append($table);
}

function loadData() {
    var data;
    $.getJSON("http://music.elvis.hu/maze/gen.php",
            function(newData) {
                data = newData;
                loadLevel(data);
            }
        );
}

function loadLevel(data) {
    var maze = data.maze;
    var start = data.start;
    var end = data.end;
    var gems = data.gems;

    for (var i = 0; i < cellNumber; i++) {
        for (var j = 0; j < cellNumber; j++) {
            if (maze[i][j] == 0) {
                var $td = $('td[x=\"' + i + '\"][y=\"' + j + '\"]');
                $td.addClass("wall");
            }
        }
    }

    var $start = $('td[x=\"' + start.x + '\"][y=\"' + start.y + '\"]');
    $start.addClass("player");

    var $end = $('td[x=\"' + end.x + '\"][y=\"' + end.y + '\"]');
    $end.addClass("end");

    gems.forEach(function(gem) {
        var $gem = $('td[x=\"' + gem.x + '\"][y=\"' + gem.y + '\"]');
        $gem.addClass("gem");
    });
}

function controlPlayer() {
    $(document).keydown(function(e) {
        var key = e.keyCode;
        var currentPosX;
        var currentPosY;
        var newPosX;
        var newPosY;

        if (key == '38') {
            
        } else if (key == '40') {
            
        } else if (key == '37') {
            
        } else if (key == '39') {
            
        }

    });
}

$(document).ready(function() {
    createTable();
    loadData();
    controlPlayer();
});
