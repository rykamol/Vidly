 
    $(document).ready(function () {
        $('#newCustomerButton').click(function () {
            document.location = '@Url.Action("New","Customers")';
        });

        $("#customers .js-delete").on("click", function () {
            var button = $(this);

            bootbox.confirm({
                title:"Confirmation Box",
                message: "Are you sure that you want to delete the customer it?",
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
                        url: "/api/customers/" + button.attr("data-customer-id"),
                        method: "DELETE",
                        success: function () {
                            //button.parents("tr").remove();
                            location.reload();
                        }
                    });
                }
            });
        });
    });