function WeatherFunction() {

    var city = $("#city").val();

        $.ajax({

            url: 'https://api.openweathermap.org/data/2.5/weather?q=' + city + "&units=metric" + "&appid=9362797e51644912cbb8f8d8b1617626",
            type: "GET",
            dataType: "jsonp",
            success: function (data) {
                var widget = show(data);
                $("#show").html(widget);
                $("#city").val('');
            }
        });
}

function show(data) {
    return '<div >' +
        '<div style="text-align:center">' +
        "<img style='width:150x;height:130px; margin-top:5px;' src='http://openweathermap.org/img/wn/" + data.weather[0].icon + ".png' />" +
        '<h5><br><strong>Temperature</strong>: ' + data.main.temp + '&deg;C</h5>' +
        '<h5><strong>Weather</strong>: ' + data.weather[0].main + '</h5>' +
        '<h5><strong>Wind Speed</strong>: ' + data.wind.speed + 'm/s</h5>' +
        '<h5><strong>Wind Direction</strong>: ' + data.wind.deg + '&deg;</h5>' +
        '</div>' +
        '</div>';
}

