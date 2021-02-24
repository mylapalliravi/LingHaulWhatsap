/// <reference path="angular.min.js" />


var app1 = angular.module('ProfileApp', []);

app1.controller('ProfileController', function ($scope, $http) {


    

    $scope.Update_password = function () {
        
        $http({
            method: 'POST',
            url: '/Customer/Update_Password',
            data: { current_Password: $scope.current_Password, new_Password: $scope.new_Password, confirm_Password: $scope.confirm_Password }
        }).success(function (d) {
           
            if (d == "Updated Successfully...")
            {
                Swal.fire('Thank you...', 'Updated succesfully!', 'success')
               // window.location.href = '/Home/Index'
                setTimeout('window.location="/Home/Index"',4000)
            }
            else
            {
                alert(d);
            }

        }).error(function () {
            alert('Failed');
        });
    };

    
});