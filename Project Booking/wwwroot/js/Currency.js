$(document).ready(function () {
    // set endpoint and your access key
    endpoint = 'live'
    access_key = '57b908ec82d3f40eb06ff39ad6465ae0';

    // get the most recent exchange rates via the "live" endpoint:
    $.ajax({
        url: 'http://api.currencylayer.com/' + endpoint + '?access_key=' + access_key,
        dataType: 'jsonp',
        success: function (json) {

            // exchange rata data is stored in json.quotes
            alert(json.quotes.USDGBP);

            // source currency is stored in json.source
            alert(json.source);

            // timestamp can be accessed in json.timestamp
            alert(json.timestamp);

        }
    });
});