
$(document).ready(function () {
    var lastday = new Date(document.getElementById("checkout").value);
    var firstday = new Date(document.getElementById("checkin").value);
    var timeDiff = (lastday.getTime() - firstday.getTime());
    var daysDiff = timeDiff / (1000 * 3600 * 24);
    document.getElementById("checkDates").style.display = 'none';

    if (isNaN(daysDiff)) {
        document.getElementById("days").innerHTML = "Please check your dates"
    }
    else {
        document.getElementById("days").innerHTML = daysDiff;
    }
    updateDue();
});
    