var table = $("#movies").DataTable({
    ajax: {
        url: "/api/movies",
        dataSrc: ""
    },
    columns: [
        {
            data: "name"
        },
        {
            data: "genreDto.name"
        },
        {
            data: "id",
            render: function(data) {
                return "<button class='btn btn-primary js-edit' " +
                    "data-movie-id=" +
                    data +
                    "><i class='fa fa-edit'></i></button> " +
                    "| <button class='btn btn-danger js-delete'" +
                    " data-movie-id=" +
                    data +
                    "><i class='fa fa-trash'></i></button>";

            },
            width: "110px"
        }
    ]
});