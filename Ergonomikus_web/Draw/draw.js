var color = 'black';

function createTable() {
    var i, j;
    var $tableholder = $('#tableholder');
    var $table= $('<table>');

    for (i = 0; i < 10; i++) {
        var $tr = $('<tr>');
        for (j = 0; j < 10; j++) {
            var $td = $('<td>').click(
                function() {
                    $(this).toggleClass(color);
                }
            );
            $tr.append($td);
        }
        $table.append($tr);
    }
    $tableholder.append($table);
}

function changeColor() {
    var $colors = $('#colors');
    $colors.append(addColor('red'));
    $colors.append(addColor('green'));
    $colors.append(addColor('blue'));
    $colors.append(addColor('black'));
}

function addColor(colorName) {
    return $('<div>').addClass(colorName).click(
        function() {
            color = colorName;
        }
    );
}

function loadButtons() {
    var $buttons = $('#buttons');
    $buttons.append($('<div>')
        .addClass('save')
        .text('Save')
        .click(
            function() {
                savePicture();
            }
        ));
    $buttons.append($('<div>')
        .addClass('load')
        .text('Load')
        .click(
            function() {
                loadPicture();
            }
        ));
}

function savePicture(){
    var picture = [];
    $('#tableholder tr').each(function() {
        var td = [];
        $(this).children().each(function(){
            var className = $(this).attr('class');
            if (className == 'red') td.push("r");
            else if (className == 'green') td.push("g");
            else if (className == 'blue') td.push("b");
            else if (className == 'black') td.push("k");
            else td.push('');
        });
        picture.push(td);
    });
    var pictureJSON = JSON.stringify(picture);
    localStorage.setItem('picture', pictureJSON);
}

function loadPicture() {
    var picture;
    var pictureJSON = localStorage.getItem('picture');
    try {
        picture = JSON.parse(pictureJSON);
    } catch (e) {
        picture = null;
    }
    var $tableholder = $('#tableholder');

    $tableholder.empty();
    for (var i = 0; i < picture.length; i++) {
        var $tr = $('<tr>');
        var row = picture[i];

        for (var j = 0; j < row.length; j++) {
            var color = row[j];
            var $td = $('<td>');
            if (color == 'r') $td.addClass('red');
            else if (color == 'g') $td.addClass('green');
            else if (color == 'b') $td.addClass('blue');
            else if (color == 'k') $td.addClass('black');
            $tr.append($td);
        }

        $tableholder.append($tr);
    }
}

window.onload = function(){
    createTable();
    changeColor();
    loadButtons();
};
