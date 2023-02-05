$(function () {
    console.log(1);

    require([
        "esri/config",
        "esri/Map",
        "esri/views/MapView",

        "esri/widgets/Search",
        "esri/rest/locator"

    ], function (esriConfig, Map, MapView, Search, locator) {

        esriConfig.apiKey = "AAPK7e9a4bdcce884c9ea77f3cb1801dfd7bk0_qidfJ68YqKbDYey3Lj5mbppuCTPUdCAxVRyPXhLR3sOThVxgdtrtezgSJKBkK";

        const map = new Map({
            basemap: "arcgis-navigation"
        });

        const view = new MapView({
            container: "viewDiv",
            map: map,
            center: [23.3751838, 42.6619214],
            zoom: 7
        });

        const search = new Search({  //Add Search widget
            view: view
        });

        view.ui.add(search, "top-right"); //Add to the map

        const serviceUrl = "http://geocode-api.arcgis.com/arcgis/rest/services/World/GeocodeServer";

        view.on("click", function (evt) {
            const params = {
                location: evt.mapPoint
            };

            locator.locationToAddress(serviceUrl, params)
                .then(function (response) { // Show the address found
                    const address = response.address;
                    showAddress(address, evt.mapPoint);
                }, function (err) { // Show no address found
                    showAddress("No address found.", evt.mapPoint);
                });

        });

        function showAddress(address, pt) {
            view.popup.open({
                title: address,
                content: + Math.round(pt.longitude * 100000) / 100000 + ", " + Math.round(pt.latitude * 100000) / 100000,
                location: pt
            });

            let latitudeInput = document.getElementById("latitudeInput");
            latitudeInput.value = pt.latitude;
            let longitudeInput = document.getElementById("longitudeInput");
            longitudeInput.value = pt.longitude;
        }

    });


})