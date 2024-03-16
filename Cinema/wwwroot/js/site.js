


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

    //Manage User Account
    document.addEventListener("DOMContentLoaded", function () {
        var accountTypeSelect = document.getElementById("accountTypeSelect");
        var branchManagerTextbox = document.getElementById("branchManagerTextbox");
        var managerBranchSelect = document.getElementById("ManagerBranch");

        function toggleBranchManagerTextbox() {
            if (accountTypeSelect.value === "BranchManager") {
                branchManagerTextbox.classList.remove("d-none");

                // Call the API to get branch data
                fetch('/UserAccounts/GetBranch') // Adjust the URL to your actual API endpoint
                    .then(response => response.json())
                    .then(data => {
                        // Assuming 'data' is an array of branches
                        // Clear existing options first
                        managerBranchSelect.innerHTML = '';

                        // Optionally add a default or placeholder option
                        var defaultOption = document.createElement('option');
                        defaultOption.text = 'Select a Branch';
                        defaultOption.value = '';
                        managerBranchSelect.add(defaultOption);

                        // Populate select with new options
                        data.forEach(branch => {
                            var option = document.createElement('option');
                            option.text = `${branch.mallCode} - ${branch.mallName}`; // Display text
                            option.value = branch.mallCode; // Value to be submitted, which should match the BranchCode
                            managerBranchSelect.add(option);
                        });
                    })
                    .catch(error => console.error('Error fetching branch data:', error));

            } else {
                branchManagerTextbox.classList.add("d-none");
            }
        }

        // Event listener for dropdown changes
        accountTypeSelect.addEventListener("change", toggleBranchManagerTextbox);

        // Optionally, call the function immediately in case the form is being reloaded
        // with a previously selected value (useful for edit forms or if preserving state)
        toggleBranchManagerTextbox();
    });