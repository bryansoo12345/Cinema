


$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');

    // Close
    $(document).on('click', '.close-modal-btn', function () {
        $(this).closest('.modal').modal('hide');
    });

    // Edit / Save
    $(document).ready(function () {
        // Event delegation for edit/save buttons
        $(document).on('click', 'button[data-toggle="ajax-modal"]', function () {
            //Retrieve id
            var button = $(this);
            var id = button.data('id');

            var url = $(this).data('url');
            $.get(url, { id: id }).done(function (data) {
                $('#PlaceHolderHere').html(data);
                $('#PlaceHolderHere').find('.modal').modal('show');
            });
        });
    });

    // OnSave
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
                    console.log("Movie created successfully. Movie ID: " + data.movieId);
                    PlaceHolderElement.find('.modal').modal('hide');
                    updateMovieList();
                } else {
                    console.log("Error creating movie:", data.errors);
                }
            }
        });
    });


})

    // Delete
    $(document).ready(function () {
        // Event delegation for delete buttons
        $(document).on('click', '.delete-movie-btn', function () {
            var id = $(this).data('id');
            var url = $(this).data('url');
            var rowToDelete = $(this).closest('tr');

            if (confirm('Are you sure you want to delete this movie?')) {
                $.post(url, { id: id })
                    .done(function (data) {
                        rowToDelete.remove();
                    })
                    .fail(function (xhr, status, error) {
                        // Handle failure
                    });
            }
        });
    });

