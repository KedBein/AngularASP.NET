app.controller('MainCtrl', ['$scope', 'PostService', 'mwMultiSelectService', function ($scope, PostService, mwMultiSelectService) {
    
    //datepicker range popup
    $scope.activeDate = null;
    $scope.selectedDates = [];
    $scope.open = function () {
        $scope.opened = true;
    };
    $scope.opened = false;
    $scope.options = {
        minDate: new Date()
    };
    $scope.parsed_date = {};

    //datepicker popup
    $scope.activeDate2 = null;
    $scope.open2 = function () {
        $scope.opened2 = true;
    };
    $scope.opened2 = false;
    $scope.options2 = {
        minDate: new Date()
    };

    //datepicker range
    $scope.activeDate3 = null;
    $scope.selectedDates3 = [new Date().setHours(0, 0, 0, 0)];
    $scope.options3 = {
        startingDay: 1,
        minDate: new Date()
    };
    $scope.parsed_date2 = {};
    //datepicker
    $scope.activeDate4 = null;
    $scope.options4 = {
        startingDay: 1,
        minDate: new Date()
    };

    $scope.parse_date = function () {
        "use strict";
        $scope.parsed_date = mwMultiSelectService.parse($scope.selectedDates, 'dd.MM.y');
        $scope.parsed_date2 = mwMultiSelectService.parse($scope.selectedDates3);
    };

    $scope.rowCollection = [];
    
    //Получаем все записи из БД Get запросом
    $scope.fillList = function () {
        var httpreq = '/Home/GetPeople/';
        var _mailAddress = PostService.getAll(httpreq);
        _mailAddress.then(function (response) {
            $scope.rowCollection = response.data;
        },
        function (error) {
            console.log("Error: " + error);
        });
    };
    $scope.fillList();

}]);