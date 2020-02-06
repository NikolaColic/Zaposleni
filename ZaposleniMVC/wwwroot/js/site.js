

    $('#btn').on('click', function (e) {
        var filters = $('#datum').val();
        Obicno(filters);
    });


function Obicno(datum2) {
   
   
        $.ajax({
            type: 'POST',
            url: '/Radnik/Vrati',
            data: { datum: datum2 },
            cache: false,
            async: true,
            dataType: "html",

        })
            .done(function (result) {

                return $('#ubaci').html(result);
            }
            ).fail(function (xhr) {
                console.log('error : ' + xhr.status + ' - ' + xhr.statusText + ' - ' + xhr.responseText);
            });
    
       
}

function Sort(filters) {
    $.ajax({
        url: '/Zaposleni/Sort1',
        type: 'POST',
        cache: false,
        async: true,
        dataType: "html",
        data: filters
    })
        .done(function (result) {
            $('#ubaci').html(result[0].smena);
        }
            ).fail(function (xhr) {
            console.log('error : ' + xhr.status + ' - ' + xhr.statusText + ' - ' + xhr.responseText);
        });

}