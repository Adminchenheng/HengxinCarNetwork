var app=angular.module("appDemo",[]);
app.controller("contDemo", function ($scope, $http) {
    headMouse();

    //登录请求服务
    $http({
        method: "post",
        url: "../ashx/LoginData.ashx",
    }).success(function (data) {
        $scope.UserPhone = data;
    }).error(function (msg) {
        alert(msg);
    });

    //统计新汽车数据服务
    $http({
        method: "post",
        url:"../ashx/DataCountashx.ashx",
        params: { "Paramter": "TrueFalse=0" }
    }).success(function (data) {
        $scope.newCarCount = data;
    }).error(function (msg) {
        alert(msg);
        });
    //汽车品牌信息服务
    $http({
        method: "post",
        url: "../ashx/CarTypeData.ashx",
        params: { "record": 5 ,"CarType":"Brand"}
    }).success(function (data) {
        $scope.BrandList = data;
    }).error(function (msg) {
        alert(msg);
        });
    //汽车价格类型服务
    $http({
        method: "get",
        url: "../ashx/CarTypeData.ashx",
        params: { "record": 4 ,"CarType":"Money"}
    }).success(function (data) {
        $scope.CarMoneyList = data;       
    }).error(function (msg) {
        alert(msg);
        });
    //汽车车身类型服务
    $http({
        method: "post",
        url: "../ashx/CarTypeData.ashx",
        params: { "record": 5,"CarType": "Body"}
    }).success(function (data) {
        $scope.BodyList = data;
    }).error(function (msg) {
        alert(msg);
        });

    
    //汽车信息服务
    $http({
        method: "post",
        url: "../ashx/CarInfoData.ashx",
        params: { "record": 8,"Style":0}
    }).success(function (data) {    
        var count = 0;
        var dataOne = new Array;
        var dataTow = new Array;
        for (var i = 0; i < data.length; i++) {
            if (i <= 3)
                dataOne[i] = data[i]
            else {
                dataTow[count++] = data[i];
            }
            $scope.newCarInfoOne = dataOne;
            $scope.newCarInfoTow = dataTow;
        }              
    }).error(function (msg) {
        alert(msg);
        });
    //二手车信息服务
    $http({
        method: "post",
        url: "../ashx/CarInfoData.ashx",
        params: { "record": 4,"Style":1}
    }).success(function (data) {
        $scope.secondData = data;
    }).error(function (msg) {
        alert(msg);
    });
    //根据品牌查询二手车信息服务
    $scope.CarDataShow = function (event) {
        $http({
            method: "post",
            url: "../ashx/CarInfoData.ashx",
            params: { "record": 4, "CarBrandID": $(event.target).attr('id') }
        }).success(function (data) {
            $scope.secondData = data;
        }).error(function (msg) {
            alert(msg);
        });
    }

    //车险信息服务
    $http({
        method: "post",
        url: "../ashx/InsuranceData.ashx"
    }).success(function (data) {
        var count = 0;
        $scope.dataOne = new Array;
        $scope.dataTow = new Array;
        for (var i = 0; i < data.length; i++) {
            if (i <= 2)
                $scope.dataOne[i] = data[i];
            else 
                $scope.dataTow[count++] = data[i];
        }
    }).error(function (msg) {
        alert(msg);
    });
});

//标题头部鼠标访问函数
var headMouse=function(){
	var $Car1=$('.CarType-head>ul>li:first-child');
	var $Car2=$('.CarType-head>ul>li:nth-child(2)');	
	$Car1.click(function(){
		headclick($Car1.index());
	}).mouseover(function(){
		headclick($Car1.index());
	})
	$Car2.click(function(){		
		headclick($Car2.index());
	}).mousemove(function(){
		headclick($Car2.index());
	})
	var headclick=function(index){
		if(index==0){
			$Car2.css({"border":'none',"color":"#222222"});
			$Car1.css({"border-bottom":"solid 2px red","color":"red"});
		}
		else{
			$Car1.css({"border":'none',"color":"#222222"});
			$Car2.css({"border-bottom":"solid 2px red","color":"red"});
		}
	}	
	var $menu=$('.menu').mouseover(function(){
		$('.CarType-brand').css("border","none");
	}).mouseout(function(){
		$('.CarType-brand').css("border-bottom","solid 1px #CCCCCC");
	});
	
	var $CarScreen=$('.CarInfo-Screen').mouseover(function(){
		$('.CarType-brand').css("border","none");
	}).mouseout(function(){
		$('.CarType-brand').css("border-bottom","solid 1px #CCCCCC");
	})
	
	var $brand=$('.brand-CarInfo>ul>li');
	$brand.mouseover(function(){
		eachli($(this));
	})	
	var eachli=function($event){
		$brand.each(function(i,obj){
			if($event.index()==i)
				$event.css("border-top","solid 2px red");
			else 
				$(this).css("border-top","none");
		});
	}
}

$(function(){
	
})
