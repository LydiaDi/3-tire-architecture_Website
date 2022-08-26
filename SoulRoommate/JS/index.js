window.onload = function () {
    //找到id为ul1的ul列表，并进行遍历，记住被点击的li的索引，使得这个被点击的li的文字颜色按照代码要求发生改变
    var ul1 = document.getElementById('ul1').getElementsByTagName('li');
    for (var i = 0; i < ul1.length; i++) {
        ul1[i].xb = i;
        ////当鼠标在li上时，鼠标所在文字部分变成黑色
        //ul1[i].onmouseover = function () {
        //    console.log(this.xb)
        //    for (var j = 0; j < ul1.length; j++) {
        //        ul1[j].style.color = '#939391'
        //    }
        //    ul1[this.xb].style.color = 'black';
        //}
        ////当鼠标不在任意一个li上时，li文字颜色全部变为#939391
        //ul1[i].onmouseout = function () {
        //    for (var j = 0; j < ul1.length; j++) {
        //        //if (ul1[j].style.border == '0') {
        //        //    ul1[j].style.color = '#939391'
        //        //}
        //        //else {
        //        //    ul1[j].style.color = 'black'
        //        //}
        //        //ul1[j].style.color = '#939391'
        //    }
        //}
        //当鼠标点击某一个li上时，此li的边框及文字颜色发生相应的改变
        ul1[i].onclick = function () {
            console.log(this.xb)
            for (var j = 0; j < ul1.length; j++) {
                ul1[j].style.color = '#939391'
                ul1[j].style.border = '0';
            }
            ul1[this.xb].style.cssText = "border-bottom:5px solid #60C1D4;color:black;"
        }
    }

    

    //与上面类似——找到id为code3的盒子，当点击此div区域时，调用creatRndCode3方法
    var code3 = document.getElementById('code3');
    code3.onclick = function () {
        NumCode3 = creatRndCode3();
        console.log('返回值:' + NumCode3);
    }
    function creatRndCode3() {
        var chars3 = ['a', 'b', 'c', '1', '2', '3'];
        var randCode3 = "";
        for (var j = 0; j < 4; j++) {
            var randPos3 = Math.floor(Math.random() * (chars3.length));
            randCode3 += chars3[randPos3];
        }
        code3.innerHTML = randCode3;
        return randCode3;
    }
    //找到id为code的盒子，当点击此div区域时，调用creatRndCode方法
    var code = document.getElementById('code');
    code.onclick = function () {
        NumCode = creatRndCode();
        console.log('返回值:' + NumCode);//在控制台输出生成的验证码
    }
    function creatRndCode() {
        var chars = ['a', 'b', 'c', '1', '2', '3'];
        var randCode = "";
        for (var i = 0; i < 4; i++) {
            var randPos = Math.floor(Math.random() * (chars.length));//随机生成一个数字
            randCode += chars[randPos];
        }
        code.innerHTML = randCode;//将随机生成的验证码写在code区域内
        return randCode;
    }
}

//验证验证码是否输入正确
var NumCode;//全局变量NumCode
function checkoutCode() {
    let code1 = document.getElementById('txtCode2');//用let创建临时变量，使用完毕后，存储空间就空出来了，节省空间
    console.log('1：' + NumCode);//输出点击code区域时生成的验证码
    console.log('2：' + code1.value);//输出控件txtCode2中填写的值
    if (code1.value == NumCode) {//判断验证码与控件中填写的值是否相同
        console.log('success');
        return true;
    }
    confirm("验证码有误！");//以弹窗方式提示验证码输入有误
    return false;
}
//与上面类似——验证验证码是否输入正确
var NumCode3;
function checkoutCode3() {
    let codeb = document.getElementById('txtCode3');
    console.log('1：' + NumCode3);
    console.log('2：' + codeb.value);
    if (codeb.value == NumCode3) {
        console.log('success');
        return true;
    }
    confirm("验证码有误！");
    return false;
}

//用JQuery实现联动效果——点击的id为ul1的li时，显示相应的main模块
$(function () {
    //
    $("#ul1 li").click(function () {
        var index = $(this).index();
        $(".main").eq(index).css({ display: "block" }).siblings(".main").css({ display: "none" });
    });
})