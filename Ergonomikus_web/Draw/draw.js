var color = 'black';

function createTable() {
    var i, j;
    var $tableholder = $('#tableholder');
    var $table= $('<table>');

    for (i = 0; i < 10; i++) {
        var $tr = $('<tr>');
        for (j = 0; j < 10; j++) {
            var $td = $('<td>').click(
                function(event) {
                    $(this).toggleClass(color);
                }
            );
            $tr.append($td);
        };
        $table.append($tr);
    };
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
        function(event) {
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

function savePicture(picture){
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
    console.log(pictureJSON);
    localStorage.setItem('picture', picture);
}

function loadPicture() {

}

window.onload = function(){
    createTable();
    changeColor();
    loadButtons();
}
