$(function () {
    // Assuming the close button has the class 'close' and data-dismiss='modal'
    $('.modal').on('click', '.close', function () {
        $(this).closest('.modal').modal('hide');
    });
});