$('#btnPre').on('click', function (e) {
    var filters = $('#pretraga').val();
    
    Pretrazi(filters);
}); 

$('#btnSort').on('click', function (e) {
    var filters = $('#sortID').val();

    Sortiraj(filters);
}); 

function Pretrazi(datum2) {
    $.ajax({
        type: 'GET',
        url: '/Zaposleni/Pretraga',
        data: { "pretraga": datum2 },
        cache: false,

        dataType: "html",
        success: function (result) {

            $('#dodajSearch').html(result);
        }
    })
        .done(function (result) {

            $('#dodajSearch').html(result);
        })
        .fail(function (xhr) {
            console.log('error : ' + xhr.status + ' - ' + xhr.statusText + ' - ' + xhr.responseText);
        })


}




$('#btnPretrazi').on('click', function (e) {
        var filters = $('#datum').val();
        Obicno(filters);
});



function Sortiraj(datum2) {
    $.ajax({
        type: 'GET',
        url: '/Zaposleni/Sortiraj',
        data: { "sort": datum2 },
        cache: false,

        dataType: "html",
        success: function (result) {

            $('#dodaj').html(result);
        }
    })
        .fail(function (xhr) {
            console.log('error : ' + xhr.status + ' - ' + xhr.statusText + ' - ' + xhr.responseText);
        });


}


function Obicno(datum2) {
   
   
        $.ajax({
            type: 'POST',
            url: '/Radnik/Vrati',
            data: { datum: datum2 },
            cache: false,
           
            dataType: "html",
            success: function (result) {

                $('#ubaci').html(result);
            }
        })
            .done(function (result) {

                $('#ubaci').html(result);
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