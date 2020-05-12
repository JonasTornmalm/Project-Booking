var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/hotel",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [

            { "data": "hotelPictureBig", "render": function (data) { return `<img class="responsive" src=${data} width="100%" >`; },  },
            {
                "data": null, render: function (data, type, row) {
                    return row.city + '<br><br> ' + row.hotelName;
                }, "width": "15%" 
            },
            { "data": "hotelInfo", "width": "35%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/HotelDetails?id=${data}" class="btn btn-dark mt-5" style='cursor:pointer; width:100%;'>
                            Book Hotel
                        </a>
                        
                        </div>`

                       ;
                }, "width": "10%"
            }
           


        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}
