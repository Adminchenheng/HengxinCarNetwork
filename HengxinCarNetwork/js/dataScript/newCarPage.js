var app = angular.module("appContent", []);
app.controller("contCarType", function ($scope, $http) {
    showhide(true);
    //登录标签请求
    $http({
        method: "post",
        url: "../ashx/LoginData.ashx",
        params: {"Name":"CarBrand"}
    }).success(function (data) {
        $scope.UserPhone = data;
        }).error(function (msg) {
            alert(msg);
        });
    //车品牌服务请求
    $http({
        method: "post",
        url: "../ashx/CarTypeData.ashx",
        params: { "record": 0, "CarType": "Brand" }
    }).success(function (data) {
        $scope.BrandList = data;
    }).error(function (msg) {
        alert(msg);
        });
    //汽车价格类型服务
    $http({
        method: "post",
        url: "../ashx/CarTypeData.ashx",
        params: { "record": 0, "CarType": "Money" }
    }).success(function (data) {
        $scope.MoneyList = data;
    }).error(function (msg) {
        alert(msg);
        });
    //汽车车身类型服务
    $http({
        method: "post",
        url: "../ashx/CarTypeData.ashx",
        params: { "record": 0, "CarType": "Body" }
    }).success(function (data) {
        $scope.BodyList = data;
    }).error(function (msg) {
        alert(msg);
        });
    //汽车分页动态生成控件服务
    $http({
        method: "get",
        url: "../ashx/DataCountashx.ashx",
        params: { "Paramter": "TrueFalse=0", "record": 1 }
    }).success(function (data) {
        $scope.PageList = data;
    }).error(function (msg) {
        alert(msg);
    })
    //点击全部服务函数
    $scope.allData = function () {
        showhide(false);
        $scope.Page = 1;
        seleHtml();
        upnextPage();
    }
    //点击汽车信息跳转服务
    $scope.ninin = function ($event) {
        $http({
            method: "post",
            url: "../ashx/SaveCarInfo.ashx",
            params: { "CarID": $($event.target).attr('id'), "rocord": 0 }
        }).success(function (data) {
            if (data != null)
                window.location.href = "newCarDetailInfo.html";
        }).error(function (msg) {
            alert(msg);
            });
    }
    
    //下页请求服务
    $scope.bottomPage = function () {
        if ($scope.Page != $scope.PageList.length)
            $scope.Page = $scope.Page + 1;
        seleHtml();
        PageData();
        upnextPage();
    }
    //上一页事件服务请求
    $scope.topPage = function () {
        if ($scope.Page!=1)
            $scope.Page = $scope.Page - 1;
        seleHtml();
        PageData();
        upnextPage();
    }

    //汽车信息服务
    var PageData = function () {
        $http({
            method: "post",
            url: "../ashx/CarInfoData.ashx",
            params: { "index": $scope.Page, "endIndex": 12, "Style": 0 }
        }).success(function (data) {
            $scope.CarList = data;
        }).error(function (msg) {
            alert(msg);
        });
    }
    $scope.Page = 1;
    PageData();

    //汽车品牌点击服务请求
    $scope.BrandShow = function (event) {
        $scope.BrandID = $(event.target).attr("value");
        CarDataInfo();
    }
    //汽车价格类型点击服务请求
    $scope.MoneyShow = function (event) {
        $scope.moneyID = $(event.target).attr("value");
        CarDataInfo();
    }
    //汽车车身类型点击服务请求
    $scope.BodyShow = function () {
        $scope.bodyID = $(event.target).attr("value");
        CarDataInfo();
    }
    //根据条件查询汽车信息服务请求
    var CarDataInfo = function () {
         $http({
            method: "post",
            url: "../ashx/QueryCarInfoData.ashx",
            params: { "BrandID": $scope.BrandID, "MoneyID": $scope.moneyID, "BodyID": $scope.bodyID, "Paramter": "0" }
        }).success(function (data) {
            if (data == "")
                display("很抱歉！没有找到你想要的车辆!");
            else
                $scope.CarList = data;
        }).error(function (msg) {
            alert(msg);
        });
    }
    //汽车搜索服务
    $scope.ShowData = function () {
        if ($('input[name=txtName]').val() == "")
            display("亲、请输入您想要搜索的汽车品牌或车名!");
        else {
            $http({
                method: "post",
                url: "../ashx/QueryCarInfoData.ashx",
                params: { "CarName": $('input[name=txtName]').val(), "Paramter": "0" }
            }).success(function (data) {
                if (data == "")
                    display("很抱歉!没有找到您想要的车辆!");
                else
                    $scope.CarList = data;
            }).error(function (msg) {
                alert(msg);
            });
        }
    }
    //当前分页控件点击服务请求
    $scope.pageShow = function (event) {
        $scope.Page = $(event.target).index() - 1;
        upnextPage();
        PageData();
        seleHtml();
    }
    //上、下分页控件点亮函数
    var upnextPage = function () {
        if ($scope.Page == 1) {
            $('a[name=upPage]').addClass('astle');
            $('a[name=nextPage]').removeClass('astle');
        }
        else if ($scope.Page == $scope.PageList.length) {
            $('a[name=nextPage]').addClass('astle');
            $('a[name=upPage]').removeClass('astle');
        }
        else if ($scope.Page > 1 && $scope.Page < $scope.PageList.length) {
            $('a[name=upPage]').removeClass('astle');
            $('a[name=nextPage]').removeClass('astle');
        }
    }
    //设置分页控件样式函数
    var seleHtml = function () {
        $('#rowTow>div').find("span").each(function (i) {
            if ($(this).html() == $scope.Page)
                $(this).addClass('spanslle');
            else
                $(this).removeClass('spanslle');
        });
    }
});
//设置动态标签脚本
var showhide = function (data) {
    if (data == true) {
        $('.row>div>a:first-child').show();
        $('.row>div>a:last-child').hide();
        $('.row>div>a:nth-child(2)').hide();
        $('.row>div>span').hide();
    }
    else {
        $('.row>div>a:first-child').hide();
        $('.row>div>a:last-child').show();
        $('.row>div>a:nth-child(2)').show();
        $('.row>div>span').show();
    }
}
//提示函数
var display = function (data) {
    $('.Promt>span').html(data);
    $(".occ").fadeIn(500);
    $(".occ").delay(1000).hide(500);
}
