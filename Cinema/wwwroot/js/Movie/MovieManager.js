function updateMovieList() {
    $.get("/Movie/GetMovies")
        .done(function (data) {
            $("#movieList").html(data);
        })
        .fail(function () {
            console.log("Failed to update movie list.");
        });
}