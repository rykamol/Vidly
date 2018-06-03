$("#movies").on("click", ".js-edit", function () {
    var button = $(this);
    bootbox.confirm({
        title: "Confirmation Box",
        message: "Are you sure that you want to delete the movie?",
        buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-success'
            },
            cancel: {
                label: 'No',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result === false)
                return;

            $.ajax({
                url: "/api/movies/" + button.attr("data-movie-id"),
                method: "DELETE",
                success: function () {
                    table.row(button.parents("tr")).remove().draw();
                    //button.parents("tr").remove();
                    // location.reload();
                }
            });
        }
    });
});
$("#movies").on("click", ".js-delete", function () {
    var button = $(this);
    bootbox.confirm({
        title: "Confirmation Box",
        message: "Are you sure that you want to delete the movie?",
        buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-success'
            },
            cancel: {
                label: 'No',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result === false)
                return;

            $.ajax({
                url: "/api/movies/" + button.attr("data-movie-id"),
                method: "DELETE",
                success: function () {
                    table.row(button.parents("tr")).remove().draw();
                    //button.parents("tr").remove();
                    // location.reload();
                }
            });
        }
    });

});