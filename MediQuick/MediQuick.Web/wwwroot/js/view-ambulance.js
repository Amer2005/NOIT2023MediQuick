
function showMapPoint(latitude, longtitude, hospitalLatitude, hospitaLongtitude) {
    $(function () {
        console.log(1);

        require([
            "esri/config",
            "esri/Map",
            "esri/views/MapView",
            "esri/Graphic",
            "esri/layers/GraphicsLayer",
            "esri/rest/route",
            "esri/rest/support/RouteParameters",
            "esri/rest/support/FeatureSet"

        ], function (esriConfig, Map, MapView, Graphic, GraphicsLayer, route, RouteParameters, FeatureSet) {
            const routeUrl =
                "https://route-api.arcgis.com/arcgis/rest/services/World/Route/NAServer/Route_World";

            const routeLayer = new GraphicsLayer();

            // Setup the route parameters
            const routeParams = new RouteParameters({
                // An authorization string used to access the routing service
                apiKey: "AAPK7e9a4bdcce884c9ea77f3cb1801dfd7bk0_qidfJ68YqKbDYey3Lj5mbppuCTPUdCAxVRyPXhLR3sOThVxgdtrtezgSJKBkK",
                stops: new FeatureSet(),
                outSpatialReference: {
                    // autocasts as new SpatialReference()
                    wkid: 3857
                }
            });

            const routeSymbol = {
                type: "simple-line", // autocasts as SimpleLineSymbol()
                color: [255, 0, 0, 0.7],
                width: 5
            };

            esriConfig.apiKey = "AAPK7e9a4bdcce884c9ea77f3cb1801dfd7bk0_qidfJ68YqKbDYey3Lj5mbppuCTPUdCAxVRyPXhLR3sOThVxgdtrtezgSJKBkK";

            const map = new Map({
                basemap: "arcgis-navigation",
                layers: [routeLayer]
            });

            const view = new MapView({
                container: "viewDivCustom",
                map: map,
                center: [longtitude, latitude],
                zoom: 12
            });

            const point = { //Create a point
                type: "point",
                longitude: longtitude,
                latitude: latitude
            };

            const hospitalPoint = { //Create a point
                type: "point",
                longitude: hospitaLongtitude,
                latitude: hospitalLatitude
            };

            const simpleSquareMarkerSymbol = {
                type: "simple-marker",
                style: "square",
                color: [0, 0, 255],
                outline: {
                    color: [255, 255, 255], // White
                    width: 1
                }
            };

            const simpleMarkerSymbol = {
                type: "simple-marker",
                color: [255, 0, 0],
                outline: {
                    color: [255, 255, 255], // White
                    width: 1
                }
            };

            const hospitalPointGraphic = new Graphic({
                geometry: hospitalPoint,
                symbol: simpleSquareMarkerSymbol
            });

            const pointGraphic = new Graphic({
                geometry: point,
                symbol: simpleMarkerSymbol
            });

           

            routeLayer.add(hospitalPointGraphic);
            routeLayer.add(pointGraphic);

            routeParams.stops.features.push(hospitalPointGraphic);
            routeParams.stops.features.push(pointGraphic);

            route.solve(routeUrl, routeParams).then(showRoute);

            const serviceUrl = "http://geocode-api.arcgis.com/arcgis/rest/services/World/GeocodeServer";

            function showRoute(data) {
                const routeResult = data.routeResults[0].route;
                routeResult.symbol = routeSymbol;
                routeLayer.add(routeResult);
            }
        });


    })
}