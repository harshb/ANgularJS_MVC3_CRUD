'use strict';

/* Controllers */

function PhoneListCtrl($scope, $http) {
    $http.get('/Angular/GetPhones').success(function (data) {
    $scope.phones = data;
  });

  $scope.orderProp = 'age';
}

//PhoneListCtrl.$inject = ['$scope', '$http'];
