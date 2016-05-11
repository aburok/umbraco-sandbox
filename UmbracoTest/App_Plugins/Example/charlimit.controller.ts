angular.module("umbraco")
    .controller("Example.CharLimitController", [
        '$scope',
        ($scope) => {
            var limit = $scope.model.config.limit;

            $scope.limitchars = () => {
                if (!$scope.model.value)
                    return;

                if ($scope.model.value.length > limit) {
                    $scope.model.value = $scope.model.value.substr(0, limit);
                }
            }

            $scope.$watch('model.value', () => {
                if (!$scope.model.value)
                    return;

                if ($scope.model.value.length >= limit) {
                    $scope.info = "You cannot write more than " + limit + " characters.";
                } else {
                    $scope.info = "You have " + (limit - $scope.model.value.length) + " characters left.";
                }
            }, true);
        }
    ]);