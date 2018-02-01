//创建应用程序模板
var app = angular.module("appDemo", []);
//创建控制器
app.controller("contDemo", function ($scope, $http) {
    $scope.dataRegis = function () {
        var UserName = $('input[name=txtUserName]').val();//用户名
        var Pwd = $('input[name=txtPwd]').val();//获取密码
        var Phone = $('input[name=txtPhone]').val();//获取电话号码
        var Entity = $('input[name=txtEntity]').val();//获取身份证号码
        if (UserName == "" || Pwd == "" || Phone == "" || Entity == "")
            display("请将信息填写完整!");
        else if (Pwd.length <= 5 || Pwd.length >= 16)
            display("密码长度不允许小于6位或超出16位!");
        else if (!(/^1[3|4|5|8][0-9]\d{4,8}$/.test(Phone)))
            display("请输入合法手机号码");
        else if (Pwd != $('input[name=txtRePwd]').val())
            display("两次密码不一致!");
        else if (!/^\d{17}(\d|x)$/i.test(Entity))
            display("请输入有效身份证号码");
        else {
                $.ajax({
                    type: "post",
                    url: "../ashx/RegisData.ashx",
                    data: { "UserName": UserName, "Pwd": Pwd, "Phone": Phone, "Entity": Entity },
                    success: function (data) {
                        display(data);
                    },
                    error: function (msg) {
                        alert(msg);
                    }
                });
        }
    }
});
var display = function (data) {
    $('.Promt>span').html(data);
    $(".occ").fadeIn(500);
    $(".occ").delay(1000).hide(500);
}

$(function () {
    $(".column2>span").hide();
    $("input[placeholder$='用户名']").focus(function () {
        $("span[id=s1]").show(500);
    }).blur(function () {
        $("span[id=s1]").hide(500);
    })

    $("input[placeholder$='字符组合']").focus(function () {
        $("span[id=s2]").show(500);
    }).blur(function () {
        $("span[id=s2]").hide(500);
    })

    $("input[placeholder$='输入密码']").focus(function () {
        $("span[id=s3]").show(500);
    }).blur(function () {
        $("span[id=s3]").hide(500);
    })

    $("input[placeholder$='联系电话']").focus(function () {
        $("span[id=s4]").show(500);
    }).blur(function () {
        $("span[id=s4]").hide(500);
    })

    $("input[placeholder$='身份证号码']").focus(function () {
        $("span[id=s5]").show(500);
    }).blur(function () {
        $("span[id=s5]").hide(500);
    })
})

