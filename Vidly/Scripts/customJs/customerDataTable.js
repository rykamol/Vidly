 
$(document).ready(function () {
    var table = $("#customers").DataTable({
        ajax: {
            url: "/api/customers",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, customer) {
                    return "<a href='/customers/edit/" + customer.id + "'>" + customer.name + "</a>";
                }
            },
            {
                data: "memberShipTypeDto.name"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-customer-id=" + data + ">Delete</button>";
                }
            }
        ]
    });
      $("#customers").on("click", ".js-delete", function () {
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
                            table.row(button.parents("tr")).remove().draw();
                            //button.parents("tr").remove();
                            // location.reload();
                        }
                    });
                }
            });
        });
    });