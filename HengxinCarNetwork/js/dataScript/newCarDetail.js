var app = angular.module("appDemo", []);
app.controller("contDemo", function ($scope, $http) {
    //登录信息服务请求
    $http({
        method: "post",
        url: "../ashx/LoginData.ashx"
    }).success(function (data) {
        $scope.UserPhone = data;
    }).error(function (msg) {
        alert(msg);
    });
    //汽车基本信息服务
    $http({
        method: "post",
        url: "../ashx/SaveCarInfo.ashx"
    }).success(function (data) {
        $scope.CarList = data;
    }).error(function (msg) {
        alert(msg);
        });
    //相关图片请求
    $http({
        method: "post",
        url: "../ashx/CarPic.ashx",
        params:{"rocrod":0}
    }).success(function (data) {
        $scope.newCarPic = data;
        }).error(function (msg) {
            alert(msg);
        })
});	