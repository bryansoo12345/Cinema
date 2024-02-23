const container = document.querySelector('.container');
const seats = document.querySelectorAll('.row .seat:not(.occupied)');
const count = document.getElementById('count');
const total = document.getElementById('total');
const movieSelect = document.getElementById('movie');

let ticketPrice = +movieSelect.value;

//Update total and count
//function updateSelectedCount() {
//    const selectedSeats = document.querySelectorAll('.row .seat.selected');
//    const selectedSeatsCount = selectedSeats.length;
//    count.innerText = selectedSeatsCount;
//    total.innerText = selectedSeatsCount * ticketPrice;
//}

//Movie Select Event
movieSelect.addEventListener('change', e => {
    ticketPrice = +e.target.value;
    //updateSelectedCount();
});

//Seat click event
container.addEventListener('click', e => {
    if (e.target.classList.contains('seat') &&
        !e.target.classList.contains('occupied')) {
        e.target.classList.toggle('selected');
    }
    //updateSelectedCount();
});

document.addEventListener("DOMContentLoaded", function () {
    var submitButton = document.querySelector('[data-save="modal"]');
    submitButton.addEventListener("click", function () {
        var seatElements = document.querySelectorAll(".seat");
        var showTimeCode = document.querySelector(".code").value;

        var seatCodes = [];
        var desiredSeats = [];

        seatElements.forEach(function (seat) {
            var seatCode = seat.id;
            seatCodes.push(seatCode);

            if (seat.classList.contains("selected")) {
                desiredSeats.push(seatCode);
            }

        });
        var BookMovie = {
            Id: 1, 
            MovieShowTimeCode: showTimeCode,
            DesiredSeats: desiredSeats 
        };

        var url = "https://localhost:44372/Movie/ConfirmBookMovie";
        $.post(url, { BookMovie })
            .done(function (data) {
                alert("Booked Seats Successful!");
            })
            .fail(function (xhr, status, error) {

            });
             
    });
});

