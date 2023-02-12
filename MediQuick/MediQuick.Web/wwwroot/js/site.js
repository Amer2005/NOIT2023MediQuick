// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function sendPosition(position) {
    $.ajax({
        url: "/api/MapApi/UpdateAmbulanceLocation",
        type: "POST",
        data: JSON.stringify({
            Latitude: position.coords.latitude,
            Longitude: position.coords.longitude
        }),
        contentType: 'application/json'
    })
}

function startUpdatingLocation() {
    setInterval(function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(sendPosition);
        } else {

        }
    }, 5000);
}
