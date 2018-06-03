

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
                    return "<button class='btn btn-danger js-delete' data-customer-id=" + data + "><i class='fa fa-trash'></i></button>";
                }
            }
        ]
    });

