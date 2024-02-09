$(document).ready(function () {
    // Navbar item click event handler
    $('a.nav-link[data-partial]').click(function (e) {
        e.preventDefault(); // Prevent default link behavior

        var partialName = $(this).data('partial'); // Get the data-partial attribute value

        // AJAX request to load the partial view
        $.get('/Admin/LoadPartial?partial=' + partialName, function (data) {
            $('.container-fluid').html(data); // Replace the container content with the loaded partial view
        });
    });
});