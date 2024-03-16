$(function () {

    // OnSave
    var saveChangesButton = document.querySelector('button[data-save="modal"]');
    saveChangesButton.addEventListener('click', function () {
        // API call logic goes here
        console.log('Save changes button clicked');
        // Example API call using fetch
        fetch('your-api-endpoint', {
            method: 'POST', // or 'PUT'
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                // Your payload here
            }),
        })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    });

})