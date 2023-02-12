
function showMapPoint(latitude, longtitude, hospitalLatitude, hospitaLongtitude) {
    $(function () {
        console.log(1);

        require([
            "esri/config",
            "esri/Map",
            "esri/views/MapView",
            "esri/Graphic",
            "esri/layers/GraphicsLayer"

        ], function (esriConfig, Map, MapView, Graphic, GraphicsLayer) {

            esriConfig.apiKey = "AAPK7e9a4bdcce884c9ea77f3cb1801dfd7bk0_qidfJ68YqKbDYey3Lj5mbppuCTPUdCAxVRyPXhLR3sOThVxgdtrtezgSJKBkK";

            const map = new Map({
                basemap: "arcgis-navigation"
            });

            const view = new MapView({
                container: "viewDivCustom",
                map: map,
                center: [longtitude, latitude],
                zoom: 12
            });

            const graphicsLayer = new GraphicsLayer();
            map.add(graphicsLayer);

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

            

            graphicsLayer.add(pointGraphic);
            graphicsLayer.add(hospitalPointGraphic);

            const serviceUrl = "http://geocode-api.arcgis.com/arcgis/rest/services/World/GeocodeServer";
        });


    })
}