/// <reference path="angular.js" />
/// <reference path="AngularContactScriptMain.js" />
/// <reference path="" />
angular.module('angularcontactmainapp')
    .directive('cardView', function () {
        return {
            templateUrl: 'Cardview.html'
        };
    });

angular.module('angularcontactmainapp')
    .directive('listView', function () {
        return {
            templateUrl: 'listview.html'
        };
    });