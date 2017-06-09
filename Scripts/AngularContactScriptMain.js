var angularCntMap = angular.module('angularcontactmainapp', ['ngRoute']);
var configurationCnt = angularCntMap.config(function ($routeProvider) {
    $routeProvider
    .when("/main", {
        templateUrl: 'welcome.html'
    })
    .when('/add',
    {
        templateUrl: '/pages/newcontact.html'
    })
    .when('/edit',
    {
        templateUrl: '/pages/editcontact.html'
    })
    .when('/delete', {
        templateUrl: '/pages/editcontact.html'
    })
    .when('/list', {
        templateUrl: '/pages/listcontacts.html'
    })
   .otherwise
    {
        redirectTo: '/main'
    }
});


var controller = angularCntMap.controller('angularcontactmaincontroller', function ($scope) {

    $scope.showList = false;
    $scope.showCard = true;

    $scope.ShowListView = function ShowListView()
    {        
        $scope.showList = true;
        $scope.showCard = false;
    }

    $scope.ShowCardView = function ShowCardView()
    {
        $scope.showList = false;
        $scope.showCard = true;
    }

});


