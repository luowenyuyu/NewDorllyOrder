﻿
function gettoday()
{    
    var now = new Date();
    var year = now.getFullYear(); 
    var month = now.getMonth();
    var date = now.getDate();
    
    month = month + 1;
    if (month < 10) month = "0" + month;
    if (date < 10) date = "0" + date;
    var time = "";
    time = year + "-" + month + "-" + date;

    return time;
}
function getfirstday()
{
    var today=new Date(); 
    var month = today.getMonth();
    month = month + 1;
    if (month < 10) month = "0" + month;
    return today.getFullYear() + "-" + month + "-01";
}
function getdatenow()
{    
    var now = new Date();
    var year = now.getFullYear(); 
    var month = now.getMonth();
    var date = now.getDate();
    var hour = now.getHours();
    var minu = now.getMinutes();
    var sec = now.getSeconds();
    
    month = month + 1;
    if (month < 10) month = "0" + month;
    if (date < 10) date = "0" + date;
    if (hour < 10) hour = "0" + hour;
    if (minu < 10) minu = "0" + minu;
    if (sec < 10) sec = "0" + sec;
    var time = "";
    time = year + "-" + month + "-" + date + " " + hour + ":" + minu + ":" + sec;

    return time;
}
function getPreMonth(date) {
    var arr = date.split('-');
    var year = arr[0]; //获取当前日期的年份
    var month = arr[1]; //获取当前日期的月份
    var day = arr[2]; //获取当前日期的日
    var days = new Date(year, month, 0);
    days = days.getDate(); //获取当前日期中月的天数
    var year2 = year;
    var month2 = parseInt(month) - 1;
    if (month2 == 0) {
        year2 = parseInt(year2) - 1;
        month2 = 12;
    }
    var day2 = day;
    var days2 = new Date(year2, month2, 0);
    days2 = days2.getDate();
    if (day2 > days2) {
        day2 = days2;
    }
    if (month2 < 10) {
        month2 = '0' + month2;
    }
    var t2 = year2 + '-' + month2 + '-' + day2;
    return t2;
}
function getNextMonth(date) {
    var arr = date.split('-');
    var year = arr[0]; //获取当前日期的年份
    var month = arr[1]; //获取当前日期的月份
    var day = arr[2]; //获取当前日期的日
    var days = new Date(year, month, 0);
    days = days.getDate(); //获取当前日期中的月的天数
    var year2 = year;
    var month2 = parseInt(month) + 1;
    if (month2 == 13) {
        year2 = parseInt(year2) + 1;
        month2 = 1;
    }
    var day2 = day;
    var days2 = new Date(year2, month2, 0);
    days2 = days2.getDate();
    if (day2 > days2) {
        day2 = days2;
    }
    if (month2 < 10) {
        month2 = '0' + month2;
    }

    var t2 = year2 + '-' + month2 + '-' + day2;
    return t2;
}

function validInt(itemid) {
    var val;
    try {
        val = parseInt($("#" + itemid).val());
    } catch (r) { }

    if (isNaN(val)) {
        $("#" + itemid).val("");
        return;
    }
    if (val < 0) val = -val;
    if (val.toString().length > 9) {
        alert("数字长度超出范围！");
        $("#" + itemid).focus();
        return;
    }
    $("#" + itemid).val(val);
}

function validDecimal(itemid) {
    var val;
    try {
        val = parseFloat($("#" + itemid).val());
    } catch (r) { }

    if (isNaN(val)) {
        $("#" + itemid).val("");
        return;
    }
    if (val < 0) val = -val;
    if (val.toString().indexOf(".") > 0)
        $("#" + itemid).val(val.toFixed(4));
    else
        $("#" + itemid).val(val);
}

function validDecimal6(itemid) {
    var val;
    try {
        val = parseFloat($("#" + itemid).val());
    } catch (r) { }

    if (isNaN(val)) {
        $("#" + itemid).val("");
        return;
    }
    if (val < 0) val = -val;
    if (val.toString().indexOf(".") > 0)
        $("#" + itemid).val(val.toFixed(6));
    else
        $("#" + itemid).val(val);
}

function addZeroLeft(order, length) {
    order += "";
    while (order.length < length) {
        order = "0" + order;
    }
    return order;
}

function getEndValue(value, length) {
    var endValue = null;
    if (value.length < length) {
        endValue = addZeroLeft(value, length);
    }
    else {
        endValue = value.substring(value.length - length);
    }
    return endValue;
}

function GUID() {
	var guid = "";
	for (var i = 1; i <= 32; i++) {
		var n = Math.floor(Math.random() * 16.0).toString(16);
		guid += n;
		if ((i == 8) || (i == 12) || (i == 16) || (i == 20)) {
			guid += "-";
		}
	}
	return guid;
}

function RandomName() {
    var chars = "abcdefghijklmnopqrstuvwxyz";
    var maxPos = chars.length;  
    var str = "";  
    for (i = 0; i < 10; i++) {
        str += chars.charAt(Math.floor(Math.random() * maxPos));
    }
    return str;
}

function getYears() {
    var now = new Date();
    var year = now.getFullYear();
    
    var arr = new Array();
    for (var i = year; i <= year + 10; i++) {
        arr.push(i);
    }
    return arr;
}

function doLogin() {
    var uname = $("#UserNo").val();
    var upassword = $("#Password").val();
    var ret = ajaxresponse("type=2&uname=" + escape(uname) + "&upassword=" + upassword);
    var vjson = JSON.parse(ret);
    if (vjson.flag == "1") {
        setCookie(ajaxresponse("type=3&lg=1"), vjson.id, 20);
        window.location = "index.aspx";
    }
    else {
        alert("用户名或密码有误"); return;
    }
}

function trim(str){
    return str.replace(/(^\s*)|(\s*$)/g, "");
}
function ltrim(str){
    return str.replace(/(^\s*)/g,"");
}
function rtrim(str){
    return str.replace(/(\s*$)/g,"");
}

function datatostr(data) {
    var resultstr = "";
    for (var prop in data) {
        try {
            resultstr = resultstr + prop + ":" + data[prop].replace(/:/g, "[~&*!^%]").replace(/;/g, "[^%$#*]") + ";";
        }
        catch (e) {
            resultstr = resultstr + prop + ":" + data[prop] + ";";
        }
    }
    return resultstr;
}

function ChooseBasic(id, type) {
    var temp = getRootPath().replace("/pm", "").replace("/paltform", "").replace("/Op", "") + "/pm/Base/ChooseBasic.aspx?id=" + id + "&type=" + type;
    layer_show("选择页面", temp, 600, 600);
}

function ChooseBasicCheck(id, type) {
    var temp = getRootPath().replace("/pm", "").replace("/paltform", "").replace("/Op", "") + "/pm/Base/ChooseBasicCheck.aspx?id=" + id + "&type=" + type;
    layer_show("选择页面", temp, 600, 600);
}

function check(id, type) {
    if ($("#" + id + "Name").val() == "") {
        $("#" + id).val("");
        return;
    }
    var submitData = new Object();
    submitData.Type = "check";
    submitData.val = $("#" + id + "Name").val();
    submitData.tp = type;
    submitData.id = id;
    transmitData(datatostr(submitData));
    return;
}
        
var PicId = "";
function PicChange() {
    var path = $('#photofile').val();
    if (path == '') {
        return;
    }
    var patn = /\.jpg$|\.jpeg$|\.png$|\.bmp$|\.gif/i;
    if (!patn.test(path)) {
        alert('对不起，不支持上传此类扩展名的文件'); 
        return;
    }
    document.getElementById('upload').submit();
}

function upstate(relt) {
    if (relt.split('@')[0].toString() == "-1") {
        alert("文件格式不正确");
        return;
    }
    else if (relt.split('@')[0].toString() == "-2") {
        alert("文件大于1M，不能上传");
        return;
    }
    else if (relt.split('@')[0].toString() == "1") {
        $("#" + PicId + "Name").val(relt.split('@')[2].toString());
        $("#" + PicId).attr("src", "../upload/" + relt.split('@')[2].toString());
        $("#a" + PicId).attr("href", "../upload/" + relt.split('@')[2].toString());
    }
    else {
        alert("上传出现故障，请确认文件是否删除");
    }
    closeBg();
    relt = "";
}


function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

function showUpload(id) {
    var temp = "upload.html?id=" + id;
    layer_show("文件上传", temp, 400, 200);
}

function reflist() {
    $("#tablelist tr").mousedown(function () {
        if (this.id == "") return;
        if ($("#selectKey").val() != "")
            $("#" + $("#selectKey").val().replace(/\//g, '\\/')).removeClass('active');
        $("#selectKey").val(this.id);
        if ($("#" + this.id.replace(/\//g, '\\/') + " td").eq(7).text() == "已审核")
            $("[onclick='approve()']").html("<i class=\"Hui-iconfont\">&#xe615;</i>&nbsp;取消审核");
        else
            $("[onclick='approve()']").html("<i class=\"Hui-iconfont\">&#xe615;</i>&nbsp;审核");
        trid = this;
        $(this).addClass('active');
        //树形菜单展开，主要服务抄表记录
        if (typeof expandNode == "function") {
            expandNode($(this).find(".td-meterno").text());
        }
    });
}

function layer_show(title, url, w, h) {
    if (title == null || title == '') {
        title = false;
    };
    if (url == null || url == '') {
        url = "404.html";
    };
    if (w == null || w == '') {
        w = 800;
    };
    if (h == null || h == '') {
        h = ($(window).height() - 50);
    };
    layer.open({
        type: 2,
        area: [w + 'px', h + 'px'],
        fix: true, //固定
        maxmin: true,
        scrollbar: false, //不允许浏览器滚动
        shade: 0.5,
        title: title,
        content: url
    });
}
/*关闭弹出框口*/
function layer_close() {
    var index = parent.layer.getFrameIndex(window.name);
    parent.layer.close(index);
}