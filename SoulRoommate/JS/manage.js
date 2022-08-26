window.onload = function () {

    //找到id为ul2的ul列表，并进行遍历，记住被点击的li的索引，使得这个被点击的li的文字颜色按照代码要求发生改变
    var ul1 = document.getElementById('ul2').getElementsByTagName('li');
    var a4List2 = document.getElementById('a4');
    var imgEmail = document.getElementById('imgEmail');
    for (var i = 0; i < ul1.length; i++) {
        ul1[i].xb = i;
        //当鼠标点击某一个li上时，此li的文字颜色发生改变
        ul1[i].onclick = function () {
            console.log(this.xb)
            for (var j = 0; j < ul1.length; j++) {
                ul1[j].style.color = '#9ba4b6'
            }
            ul1[this.xb].style.cssText = "color:black;"
        }

        //鼠标点击id为imgEmail的图片上时，页面顶端所有文字颜色变为#9ba4b6色
        imgEmail.onclick = function () {
            for (var j = 0; j < ul1.length; j++) {
                ul1[j].style.color = '#9ba4b6'
            }
        }

        //鼠标点击code模块的任何一个内容时，页面顶端所有文字颜色变为#9ba4b6色
        a4List2.onclick = function () {
            for (var j = 0; j < ul1.length; j++) {
                ul1[j].style.color = '#9ba4b6'
            }
        }
    }

    //鼠标在id为imgEmail的图片上时，此图片出现放大效果
    var email = document.getElementById('imgEmail');
    var count = document.getElementById('lbMsgCount');
    email.onmouseover = function () {
        email.style.cssText = "width: 55px; height: 40px;";
        count.style.cssText = "width: 30px; height: 30px;font-size: 21px;border-radius: 15px;";
    }
    //鼠标离开id为imgEmail的图片右上角未读消息个数时，图片的大小恢复原来的状态
    email.onmouseout = function () {
        email.style.cssText = "width: 50px; height: 35px;";
        count.style.cssText = "width: 26px; height: 26px;font-size: 20px;border-radius: 13px;";
    }
    //鼠标在id为imgEmail的图片上时，此图片出现放大效果
    count.onmouseover = function () {
        email.style.cssText = "width: 55px; height: 40px;";
        count.style.cssText = "width: 30px; height: 30px;font-size: 21px;border-radius: 15px;";
    }
    //鼠标离开id为imgEmail的图片右上角未读消息个数时，图片的大小恢复原来的状态
    count.onmouseout = function () {
        email.style.cssText = "width: 50px; height: 35px;";
        count.style.cssText = "width: 26px; height: 26px;font-size: 20px;border-radius: 13px;";
    }

    var imgArrow = document.getElementById('imgArrow');
    var box = document.getElementById('a4');
    var user = document.getElementById('lbUser');

    //当鼠标在图片imageArrow上时，id为a4的box模块显示
    imgArrow.onmouseover = function () {
        box.style.display = "block";
    };
    //当鼠标在user模块上时，id为a4的box模块显示
    user.onmouseover = function () {
        box.style.display = "block";
    };
    //当鼠标在box模块本身的部分时，box模块显示
    box.onmouseover = function () {
        box.style.display = "block";
    };
    //当鼠标从box模块本身的移开时，box模块隐藏
    box.onmouseout = function () {
        box.style.display = "none";
    };

    //当鼠标从box模块上的某一个li上时，相应的li模块出现阴影效果
    var a4List = document.getElementById('a4').getElementsByTagName('li');
    for (var i = 0; i < a4List.length; i++) {
        a4List[i].xb = i;
        a4List[i].onmouseover = function () {
            console.log(this.xb)
            for (var j = 0; j < a4List.length; j++) {
                a4List[this.xb].style.cssText = "background-color:white;";
            }
            a4List[this.xb].style.cssText = "background-color:lightgrey;";
        }
        a4List[i].onmouseout = function () {
            for (var j = 0; j < a4List.length; j++) {
                a4List[this.xb].style.cssText = "background-color:white;";
            }
        }
    }
}

//用JQuery实现的各种效果
$(function () {
    //点击ul2中的某一li时实现联动效果
    $("#ul2 li").click(function () {
        var index = $(this).index();
        $(".right").css({ display: "none" });
        $(".main").eq(index).css({ display: "block" }).siblings(".main").css({ display: "none" });
    });

    //code中的列表li模块时，实现相应的联动效果
    $("#ul1 li").click(function () {
        var index = $(this).index();
        $(".main").css({ display: "none" });
        $(".right").eq(index).css({ display: "block" }).siblings(".right").css({ display: "none" });
        if (index == 2) {
            //window.location.herf = 'http://localhost:55161/Login.aspx';
            window.history.back(-1);/*可以实现*/
        }
    });

    //鼠标点击id为imgEmail的图片上时，其它所有模块隐藏，main5模块显示
    $("#imgEmail").click(function () {
        $(".main").css({ display: "none" });
        $("#main5").css({ display: "block" });
        $(".right").css({ display: "none" });
    });
})