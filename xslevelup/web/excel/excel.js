function createRandomTable(cols, rows) {
    var i, j;
    var $table, $tr, $td;
    $table = $('<table>');
    for (i = 0; i < rows; i++) {
        $tr = $('<tr>');
        for (j = 0; j < cols; j++) {
            $td = $('<td>').html(Math.round(Math.random() * 100));
            $tr.append($td);
        }
        $table.append($tr);
    }
    return $table;
}

function excelize($table) {
    $table.addClass('excel');

    // add column heads
    var $headrow = $table.find('tr:first').clone();
    var index = 1;
    $headrow.find('td').addClass('head')
        .attr('type','col')
        .each(function() {
            $(this).attr('num', index-1)
                .html(index++);
        });
    $table.prepend($headrow);

    // add row heads
    index = 0;
    $table.find('tr').each(
        function() {
            $(this).
            prepend(
                $('<td>')
                    .addClass('head')
                    .attr('type','row')
                    .attr('num', index-1)
                    .html(index++)
            )
        }
    );
    $table.find('tr:first td:first').removeClass('head').html('');

    // create cells
    $table.find('tr:not(:first) td:not(.head)').each(function() {
        var value = $(this).html();
        var index = $(this).index()-1;
        var rowindex = $(this).parent().index()-1;
        $(this).html(
            $('<input type="text">').val(value).change(function() {
                limit($(this));
                calc($table);
            }).keyup(function() {
                limit($(this));
                calc($table);
            }).attr('row', rowindex).attr('col', index)
        );
    });

    // create col sums
    var $sumrow = $table.find('tr:first').clone();
    $sumrow.find('td:not(:first)').removeClass('head').addClass('sum').html('0');
    $sumrow.find('td:first').removeClass('head').html('sum');
    $table.append($sumrow);

    // create row sums
    $table.find('tr').append($('<td>'));

    $table.find('tr:not(:first)').each(
        function() {
            $(this).
            find('td:last').
            addClass('sum').
            html('0');
        }
    );
    $table.find('tr:first td:last').html('sum');
}

function calc($table) {
    $table.find('tr:not(:first):not(:last)').each(function() {
        var sum = 0;
        $(this).find('input').each(
            function() {
                sum = sum + parseInt($(this).val());
            }
        );
        $(this).find('td:last').html(sum);
    });

    $table.find('tr:first td.head').each(function() {
        var sum = 0;
        var colnum = parseInt($(this).html()) + 1;

        $table.find(
            'tr td:nth-child(' + colnum + ') input').each(
            function() {
                sum = sum + parseInt($(this).val());
            });
        $table.find('tr:last td:nth-child(' + colnum + ')').html(sum);
    });

    var sum = 0;
    $table.find('input').each(function() {
        var value = $(this).val();
        value = parseInt(value);
        sum = sum + value;
    });
    $table.find('tr:last td:last').html(sum);
}

function limit($input) {
    var value = parseInt($input.val()); // kivesszük az értéket
    if (isNaN(value) || value < 0) value = 0; // ha az nem szám, vagy kisebb, mint 0, akkor az értéke legyen 0
    if (value > 100) value = 100; // ha az érték nagyobb mint 100, akkor az érték legyen 100
    $input.val(value); // visszaírjuk az input-ba a módosított értéket
}

function graph($table) {
    // létrehozzuk a grafikon divet és beszúrjuk a dom-ba
    var $graph = $('<div>').addClass('graph');
    $('body').append($graph);

    // a táblázat összes head class-ú cellájára ráteszünk egy click kezelőt
    $table.find('td.head').click(function() {
        // innen a this az a cella, amin a kattintás történt
        var value;
        var $inputs = [];
        var $bar;

        var max = 100, unit = 255 / 100, volume;
        var r, g, b = 0;
        var type, number;

        $graph.html(''); // ürítjük a grafikon div tartalmát

        type = $(this).attr('type'); // lekérdezzük a kattintott cella type értékét (sor vagy oszlop)
        number = $(this).attr('num'); // lekérdezzük a kattintott cella sorszámát

        // megkeressük a kattintásnak megfelelő inputokat és eltároljuk azokat az $inputs tömbben
        $table.find('input[' + type + '=' + number + ']').each(
            function() {
                $inputs.push($(this));
            }
        );

        // egy ciklusban végigmegyünk az $inputs tömb elemein
        for (var i = 0; i < $inputs.length; i++) {
            value = $inputs[i].val(); // az aktuális inputból kivesszük az értéket

            // kiszámoljuk az adott értékhez tartozó szín r, g, b komponenseit
            volume = Math.ceil(value * unit);
            r = g = 255;
            b = 0;

            if (volume > 128) r = (255 - volume) * 2;
            else g = volume * 2;

            // létehozzuk az oszlop div-et és megadjuk a css értékeket hozzá
            $bar = $('<div>').
            height(value + 'px'). // magasság
            css('border-top', max - value + 'px solid black'). // felső fekete - nem látható - keret
            css('background-color', 'rgb(' + r + ',' + g + ',' + b + ')'); // háttérszín a kiszámolt színkomponensek alapján

            // hozzákapcsoljuk a grafikon oszlophoz a hozzá tartozó input elemet
            $bar.prop('input', $inputs[i]);

            // az alábbi eseménykezelőkben a this mindig az adott grafikon oszlop div
            $bar.mouseover(function() { // amikor az elem fölé visszük az egeret
                $(this).prop('input').addClass('barover'); // kijelöljük a hozzá kapcsolt inputot
            }).mouseout(function() { // amikor elmozgatjuk az adott elem fölül az egeret
                $(this).prop('input').removeClass('barover'); // levesszük a kapcsolt inputról a kijelölést
            }).click(function(event) { // kattintás esetén
                var value = 100 - event.offsetY; // kiszámoljuk az elem magasságát a kattintás pozíciója alapján

                // kiszámoljuk az adott értékhez tartozó szín r, g, b komponenseit
                var volume = Math.ceil(value * 255 / 100);
                var r = 255, g = 255, b = 0;
                if (volume > 128) r = (255 - volume) * 2; else g = volume * 2;

                $(this).prop('input').val(value); // beállítjuk az értéket a kapcsolt input elemben

                // átállítjuk a grafikon oszlop div css értékeit
                $(this).
                height(value + 'px'). // magasság
                css('border-top', 100 - value + 'px solid black'). // felső border
                css('background-color', 'rgb(' + r + ',' + g + ',' + b + ')'); // háttérszín
            });

            // hozzáadjuk az oszlop div-et a grafikon div-hez
            $graph.append($bar);
        }
    });
}

$(document).ready(function() {
    var $table = createRandomTable(5, 5);
    $('body').append($table);
    excelize($table);
    calc($table);
    graph($table);
});