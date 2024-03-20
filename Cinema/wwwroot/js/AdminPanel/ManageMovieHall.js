
$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');
    //edit
    $(document).ready(function () {
        $(document).on('click', '#addNewHallButton', function () {
            var button = $(this);
            var url = button.data('url');
            $.get(url).done(function (data) {
                $('#PlaceHolderHere').html(data);
                $('#PlaceHolderHere').find('.modal').modal('show');
                attachSaveChangesListener();
            });
        });
    });

    $(document).ready(function () {
        $(document).on('click', '#FilterHallButton', function () {
            var button = $(this);
            var url = button.data('url');
            $.get(url).done(function (data) {
                $('#PlaceHolderHere').html(data);
                $('#PlaceHolderHere').find('.modal').modal('show');
                attachSaveChangesListener();
            });
        });
    });

    $(document).ready(function () {
        $(document).on('click', '#AddMovieShow', function () {
            var button = $(this);
            var url = button.data('url');

            //Id
            var id = button.data('id');

            //Data
            var DefaultDate = button.data('defaultdate');
            var parts = DefaultDate.match(/(\d{1,2})\/(\d{1,2})\/(\d{4}) (\d{1,2}):(\d{2}):(\d{2}) (\w{2})/);
            var hours = +parts[4]; 
            if (parts[7] === 'PM' && hours < 12) {
                hours += 12;
            } else if (parts[7] === 'AM' && hours === 12) {
                hours = 0; 
            }

            var pDate = new Date(parts[3], parts[2] - 1, parts[1], hours, parts[5], parts[6]);
            pDate.setHours(pDate.getHours() - 4);
            var pDefaultDate = pDate.toISOString();

            //HallCode
            var button = $(this);
            var HallCode = button.data('hallcode');

            $.get(url, { id: id, DefaultDate: pDefaultDate, HallCode:HallCode }).done(function (data) {
                $('#PlaceHolderHere').html(data);
                $('#PlaceHolderHere').find('.modal').modal('show');
                attachSaveMovieShowListener();
            });
        });
    });

    function attachSaveChangesListener() {
        var saveChangesButton = document.querySelector('button[data-save="modal"]');
        console.log(saveChangesButton); // Log to see if button is being selected
        if (saveChangesButton) {
            saveChangesButton.addEventListener('click', function () {
                // API call logic goes here
                console.log('Save changes button clicked');
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
        }
    }
    function attachSaveMovieShowListener() {
        var saveChangesButton = document.querySelector('button[data-save="modal"]');
        console.log(saveChangesButton); // Log to see if button is being selected
        if (saveChangesButton) {
            saveChangesButton.addEventListener('click', function () {
                // API call logic goes here
                console.log('Save changes button clicked');
                // Assuming this code is triggered by an event, e.g., form submission or button click.
                var form = $(this).parents('.modal').find('form')[0];
                var formData = new FormData(form);
                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: formData, // Ensure data is a JSON string
                    contentType: false, // Specify the content type as JSON
                    processData: false,
                    success: function (data) {
                        // Handle success
                    },
                    error: function (error) {
                        // Handle error
                        console.error("Error:", error);
                    }
                });
            });
        }
    }

    // Delete
    $(document).ready(function () {
        // Event delegation for delete buttons
        $(document).on('click', '.delete-movie-btn', function () {
            var id = $(this).data('id');
            var url = $(this).data('url');
            var rowToDelete = $(this).closest('tr');

            if (confirm('Are you sure you want to delete this movie?')) {
                $.post(url, { id2: id })
                    .done(function (data) {
                        rowToDelete.remove();
                    })
                    .fail(function (xhr, status, error) {
                        // Handle failure
                    });
            }
        });
    });

    //Manage Movie Hall
    $(document).on('click', '.seat', function () {
        $(this).toggleClass('selected');
        // Additional logic for handling the selection
    });

})