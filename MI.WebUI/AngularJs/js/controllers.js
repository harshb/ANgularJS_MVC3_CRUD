'use strict';

/* Controllers */

function PhoneListCtrl($scope, $http) {
  $http.get('/Angular/GetPhones').success(function(data) {
    $scope.phones = data;
  });

$scope.orderProp = 'age';

$scope.newrecord = function () {
    alert('ok');
};


}




function PhoneDetailCtrl($scope, $routeParams, $http) {

    if ($routeParams.phoneId == 0) {

        return;
    }

    $http.get('/Angular/GetPhoneDetail/' + $routeParams.phoneId).success(function (data) {
       
        $scope.form = data;
    });


    $scope.save = function () {

        var postform = JSON.stringify($scope.form);
        
        $http.put('/Angular/SavePhone', postform).success(function (data) {
            data.preventDefault;
        });

    }
    

   

   /*
    $scope.save = function () {
        $.ajax({
            url: '/Angular/SavePhone/',
            data: JSON.stringify($scope.form),
            //success: success,
           // error: error,
            type: 'POST',
            contentType: 'application/json, charset=utf-8',
            dataType: 'json'
        });

    }
    */
    


} //PhoneDetailCtr



 