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

window.onload = function(){
    createTable();
    changeColor();
}
