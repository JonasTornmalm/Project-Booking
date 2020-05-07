
$(document).ready(function () {
    var lastday = new Date(document.getElementById("checkout").value);
    var firstday = new Date(document.getElementById("checkin").value);
    var timeDiff = (lastday.getTime() - firstday.getTime());
    var daysDiff = timeDiff / (1000 * 3600 * 24);

    if (isNaN(daysDiff)) {
        document.getElementById("days").innerHTML = "Pick a check-in and a check-out date"
    }
    else {
        document.getElementById("days").innerHTML = daysDiff;
    }
    updateDue();
});