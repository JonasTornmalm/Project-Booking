﻿$(document).ready(function () {

    $('#submitWeather').click(function () {

        var city = $("#city").val();

        if (city != '') {

            $.ajax({

                url: 'https://api.openweathermap.org/data/2.5/weather?q=' + city + "&units=metric" +"&appid=9362797e51644912cbb8f8d8b1617626",
                type: "GET",
                dataType: "jsonp",
                success: function (data) {
                    var widget = show(data);
                    $("#show").html(widget);
                    $("#city").val('');
                }   
            });

        } else {
            $("#error").html('field cannot be empty');
        }

    });


});

function show(data) {
    return "<h3><strong> Name</strong>: " + data.name + "</h3>" +
           "<h3><strong> Weather</strong>: " + data.weather[0].main + "</h3>" +
           "<h3><strong> Description</strong>: <img src= 'http://openweathermap.org/img/wn/" + data.weather[0].icon + ".png'>" + data.weather[0].description + "</h3>" +
           "<h3><strong> Temperature</strong>: " + data.main.temp + "&deg;C</h3>" +
           "<h3><strong> Pressure</strong>: " + data.main.pressure + "hPa</h3>" +
           "<h3><strong> Humidity</strong>: " + data.main.humidity + "%</h3>" +
        "<h3><strong> Min. Temperature</strong>: " + data.main.temp_min + "&deg;C</h3>" +
        "<h3><strong> Max. Temperature</strong>: " + data.main.temp_max + "&deg;C</h3>" +
           "<h3><strong> Wind Speed</strong>: " + data.wind.speed + "m/s</h3>" +
        "<h3><strong> Wind Direction</strong>: " + data.wind.deg + "&deg;C</h3>";



}