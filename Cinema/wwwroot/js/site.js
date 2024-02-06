// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');

    $('button[data-toggle="ajax-modal"]').click(function (event) {
        //Retrieve id
        var button = $(this);
        var id = button.data('id');

        var url = $(this).data('url');
        $.get(url, { id: id }).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })

    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
        var form = $(this).parents('.modal').find('form')[0];
        var ActionUrl = form.action;

        var formData = new FormData(form);

        $.ajax({
            type: 'POST',
            url: ActionUrl,
            data: formData,
            contentType: false,
            processData: false,
            success: function (data) {
                console.log(data);

                if (data.success) {
                    // Handle success, you can access additional data like movieId
                    console.log("Movie created successfully. Movie ID: " + data.movieId);
                    PlaceHolderElement.find('.modal').modal('hide');
                } else {
                    // Handle errors
                    console.log("Error creating movie:", data.errors);
                }
            }
        });
    });


    //PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
    //    var form = $(this).parents('.modal').find('form');
    //    var ActionUrl = form.attr('action');
    //    var ControllerUrl = form.attr('id');
    //    var sendData = form.serialize();
    //    var ApiURL = ControllerUrl + '/' + ActionUrl;

    //    $.post(ApiURL, sendData)
    //        .done(function (data) {
    //            if (data.success) {
    //                PlaceHolderElement.find('.modal').modal('hide');
    //            } 
    //        })
    //});


})

