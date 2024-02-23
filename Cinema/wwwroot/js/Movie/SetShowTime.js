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

        seatElements.forEach(function (seat) {
            var seatCode = seat.id;
            //add into SeatList
            seatCodes.push(seatCode);
            console.log("Seat Code:", seatCode);
        });

        var movieShow = {
            Id: 1, 
            MovieShowTimeCode: showTimeCode,
            MovieName: "American Psycho", 
            MovieCode: "AP-001",
            MallCode: "OUGSC",
            HallCode: "OUGSC-H7",
            SeatCodes: seatCodes 
        };

        var url = "https://localhost:44372/Movie/ConfirmShowTime";
        $.post(url, { movieShow })
            .done(function (data) {
                alert("Movie Show Time Set!");
            })
            .fail(function (xhr, status, error) {

            });
             
    });
});

