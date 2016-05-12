angular.module("umbraco")
    .controller("Location.LocationEditorController", [
    "$scope",
    "assetsService",
    "notificationsService",
    function ($scope, assetsService, notificationsService) {
        function initMap() {
            var myLatLng = new google.maps.LatLng($scope.model.value.latitude, $scope.model.value.longitude);
            var map = new google.maps.Map(document.getElementById('map-canvas'), {
                zoom: 4,
                center: myLatLng
            });
            var marker = new google.maps.Marker({
                position: myLatLng,
                map: map,
                title: 'Hello World!',
                draggable: true
            });
            google.maps.event.addListener(marker, "position_changed", function (e) {
                var position = marker.getPosition();
                $scope.model.value.latitude = position.lat();
                $scope.model.value.longitude = position.lng();
                if (position.lat() > 55 || position.lat() < 50
                    || position.lng() < 14 || position.lng() > 24) {
                    notificationsService.error("Please select location in Poland, latitude between 50 and 55 and longitude between 14 and 24.");
                }
            });
        }
        assetsService.loadJs("http://www.google.com/jsapi")
            .then(function () {
            google.load("maps", "3", {
                callback: initMap,
                other_params: "sensor-false"
            });
        });
    }
]);
