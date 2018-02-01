var app = angular.module("appDemo", []);
app.controller("contDemo", function ($scope,$http) {
    //登录信息服务请求
    $http({
        method: "post",
        url: "../ashx/LoginData.ashx",
    }).success(function (data) {
        $scope.UserPhone=data;
    }).error(function (msg) {
        alert(msg);
        });
    //点击登录按钮服务请求
    $scope.LoginShow = function () {
        $http({
            method: "post",
            url: "../ashx/LoginData.ashx",
            params: { "Uid": $('input[name=txtUid]').val(), "Pwd": $('input[name=txtPwd]').val() }
        }).success(function (data) {
            if (data == "密码不正确，请重新输入!")
                display(data);
            else if (data == "没有此用户")
                display(data);
            else {
                //alert(data[0]);
                $scope.UserPhone = data[0];
                display(data[1]);
            }                
        }).error(function (msg) {
            alert(msg);
        });
    };
});
var display = function (data) {
    $('.Promt>span').html(data);
    $(".occ").fadeIn(500);
    $(".occ").delay(1000).hide(500);
}