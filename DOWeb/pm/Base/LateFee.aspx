<%@ Page Language="C#" AutoEventWireup="true" Inherits="project.Presentation.Base.LateFee,project" %>

<!DOCTYPE>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head1" runat="server">
    <title>违约金费用科目设置</title>
    <!--[if lt IE 9]>
    <script type="text/javascript" src="../jscript/html5.js"></script>
    <script type="text/javascript" src="../jscript/respond.min.js"></script>
    <![endif]-->
    <link href="../../css/H-ui.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/H-ui.admin.css" rel="stylesheet" type="text/css" />
    <link href="../../lib/iconfont/iconfont.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function transmitData(submitData) {
            var data = submitData;
            <%=ClientScript.GetCallbackEventReference(this, "data", "BandResuleData", null) %>
        }
    </script>
</head>
<body>
    <form id="form1" runat="server"></form>
    <nav class="breadcrumb"><i class="Hui-iconfont">&#xe67f;</i> 首页 <span class="c-gray en">&gt;</span> 基础资料 <span class="c-gray en">&gt;</span> 违约金费用科目设置 <a class="btn btn-success radius r mr-20" style="line-height: 1.6em; margin-top: 2px" href="javascript:location.replace(location.href);" title="刷新"><i class="Hui-iconfont">&#xe68f;</i></a></nav>
    <div id="list" class="pt-5 pr-20 pb-5 pl-20">
        <div class="cl pd-3 bg-1 bk-gray mt-2">
             &nbsp;&nbsp;
            <span style="display: inline-block; height: 31px; font-size: 14px; line-height: 31px;">服务商：</span>&nbsp;
            <select id="SSPNo" class="input-text required" style="width: 100px;">
                <option value='' selected>全部</option>
                <%=Provider %>
            </select>
            &nbsp;&nbsp;
            <span style="display: inline-block; height: 31px; font-size: 14px; line-height: 31px;">费用名称：</span>&nbsp;
            <input type="text" class="input-text size-MINI" style="width: 150px; height: 31px; font-size: 14px;" placeholder="费用名称" id="SSRVName" />
            &nbsp;&nbsp;
            <span style="display: inline-block;height: 31px; font-size: 14px; line-height: 31px;">违约金名称：</span>&nbsp;
            <input type="text" class="input-text size-MINI" style="width: 150px; height: 31px; font-size: 14px;" placeholder="违约金名称" id="SLateSRVName" />
            &nbsp;&nbsp;
            <button type="submit" class="btn btn-success radius" onclick="javascript:page=1;select();"><i class="Hui-iconfont">&#xe665;</i> 查询</button>
            <span>
                <%=Buttons %>
                <input type="hidden" id="selectKey" />
            </span>
        </div>
        <div class="mt-5" id="outerlist">
            <%=list %>
        </div>
    </div>
    <div id="edit" class="pt-5 pr-20 pb-5 pl-20" style="display: none;">
        <div class="form form-horizontal bk-gray mt-15 pb-10" id="editlist">
            <div class="row cl">
                <label class="form-label col-2"><span class="c-red">*</span>服务商：</label>
                <div class="formControls col-4">
                    <select id="SPNo" class="input-text required" data-valid="isNonEmpty" data-error="服务商不能为空" onchange="getFee(this.value)">
                        <option value='' selected>请选择</option>
                        <%=Provider %>
                    </select>
                </div>
                <div class="col-3"></div>
            </div>
            <div class="row cl">
                <label class="form-label col-2"><span class="c-red">*</span>费用科目：</label>
                <div class="formControls col-4">
                    <%--<%=SRVNoStr %>--%>
                    <select id="SRVNo" class="input-text required" data-valid="isNonEmpty" data-error="费用科目不能为空">
                    </select>
                </div>
                <div class="col-3"></div>
            </div>
            <div class="row cl">
                <label class="form-label col-2"><span class="c-red">*</span>对应违约金科目：</label>
                <div class="formControls col-4">
                    <%-- <%=LateFeeSRVNoStr %>--%>
                    <select id="LateFeeSRVNo" class="input-text required" data-valid="isNonEmpty" data-error="对应违约金科目不能为空">
                    </select>
                </div>
                <div class="col-3"></div>
            </div>
            <div class="row cl">
                <div class="col-9 col-offset-3">
                    <input class="btn btn-primary radius" type="button" onclick="submit()" value="&nbsp;&nbsp;提&nbsp;&nbsp;交&nbsp;&nbsp;" />
                    <input class="btn btn-default radius" type="button" onclick="cancel()" value="&nbsp;&nbsp;取&nbsp;&nbsp;消&nbsp;&nbsp;" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="../../jscript/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../../jscript/script_common.js"></script>
    <script type="text/javascript" src="../../jscript/script_ajax.js"></script>
    <script type="text/javascript" src="../../jscript/json2.js"></script>
    <script type="text/javascript" src="../../jscript/H-ui.js"></script>
    <script type="text/javascript" src="../../jscript/H-ui.admin.js"></script>
    <script type="text/javascript" src="../../lib/layer/layer.js"></script>
    <script type="text/javascript" src="../../lib/validate/jquery.validate.js"></script>
    <script type="text/javascript">
        function BandResuleData(temp) {
            var vjson = JSON.parse(temp);
            if (vjson.type == "select") {
                if (vjson.flag == 1) {
                    $("#outerlist").html(vjson.liststr);
                    $("#selectKey").val("");
                    reflist();
                    //layer.msg("数据刷新成功！");
                } else {
                    //layer.msg("数据刷新失败！");
                }
            }
            if (vjson.type == "delete") {
                if (vjson.flag == "1") {
                    $("#outerlist").html(vjson.liststr);
                    $("#selectKey").val("");
                    layer.msg("删除成功！");
                    select();
                }
                else {
                    layer.alert("数据操作出错！");
                }
                return;
            }
            if (vjson.type == "submit") {
                if (vjson.flag == "1") {
                    $("#selectKey").val("");
                    $("#list").css("display", "");
                    $("#edit").css("display", "none");
                    layer.msg("提交成功！");
                    select();
                }
                else if (vjson.flag == "3") {
                    showMsg("SRVNo", "此费用项目在已存在", "1");
                }
                else {
                    layer.msg("数据操作出错！");
                }
                return;
            }
            if (vjson.type == "update") {
                var html = "";
                if (vjson.flag == "1") {
                    $("#SPNo").val(vjson.SPNo);
                    $.each(JSON.parse(vjson.FeeList), function (key, item) {
                        html += "<option value='" + item.SRVNo + "'>" + item.SRVName + "</option>";
                    });
                    $("#SRVNo").append(html);
                    $("#SRVNo").val(vjson.SRVNo);
                    html = "";
                    $.each(JSON.parse(vjson.LateFeeList), function (key, item) {
                        html += "<option value='" + item.SRVNo + "'>" + item.SRVName + "</option>";
                    });
                    $("#LateFeeSRVNo").append(html);
                    $("#LateFeeSRVNo").val(vjson.LateFeeSRVNo);

                    $("#list").css("display", "none");
                    $("#edit").css("display", "");
                }
                else {
                    layer.alert("数据操作出错！");
                }
                return;
            }
            if (vjson.type == "getFee") {
                var html = "";
                if (vjson.flag == 1) {

                    $.each(JSON.parse(vjson.FeeList), function (key, item) {
                        html += "<option value='" + item.SRVNo + "'>" + item.SRVName + "</option>";
                    });
                    $("#SRVNo").append(html);
                    html = "";
                    $.each(JSON.parse(vjson.LateFeeList), function (key, item) {
                        html += "<option value='" + item.SRVNo + "'>" + item.SRVName + "</option>";
                    });
                    $("#LateFeeSRVNo").append(html);
                }
                else {
                    html += "<option value='' selected>获取数据失败！</option>";
                    $("#SRVNo").empty().append(html);
                    $("#LateFeeSRVNo").empty().append(html);
                }

                return;
            }
        }
        function getFee(SPNo) {
            $("#SRVNo").empty().append("<option value='' selected>请选择</option>");
            $("#LateFeeSRVNo").empty().append("<option value='' selected>请选择</option>");
            if (SPNo != "") {
                var submitData = new Object();
                submitData.Type = "getFee";
                submitData.SPNo = SPNo;
                transmitData(datatostr(submitData));
            }
            return;
        }
        function insert() {
            $('#editlist').validate('reset');
            id = "";
            type = "insert";
            $("#SPNo").val("");
            $("#SRVNo").empty().append("<option value='' selected>请选择</option>");
            $("#LateFeeSRVNo").empty().append("<option value='' selected>请选择</option>");

            $("#list").css("display", "none");
            $("#edit").css("display", "");
            return;
        }
        function update() {
            if ($("#selectKey").val() == "") {
                layer.msg("请先选择要修改的信息", { icon: 3, time: 1000 });
                return;
            }
            $('#editlist').validate('reset');
            $("#SPNo").val("");
            $("#SRVNo").empty().append("<option value='' selected>请选择</option>");
            $("#LateFeeSRVNo").empty().append("<option value='' selected>请选择</option>");
            id = $("#selectKey").val();
            type = "update";
            var submitData = new Object();
            submitData.Type = "update";
            submitData.id = id;

            transmitData(datatostr(submitData));
            return;
        }
        function submit() {
            if ($('#editlist').validate('submitValidate')) {
                var submitData = new Object();
                submitData.Type = "submit";
                submitData.id = id;
                submitData.SPNo = $("#SPNo").val();
                submitData.SRVNo = $("#SRVNo").val();
                submitData.LateFeeSRVNo = $("#LateFeeSRVNo").val();
                submitData.tp = type;
                transmitData(datatostr(submitData));
            }
            return;
        }

        function del() {
            if ($("#selectKey").val() == "") {
                layer.msg("请先选择一条记录", { icon: 3, time: 1000 });
                return;
            }
            layer.confirm('确认要删除吗？', function (index) {
                var submitData = new Object();
                submitData.Type = "delete";
                submitData.id = $("#selectKey").val();
                transmitData(datatostr(submitData));
                layer.close(index);
            });
            return;
        }
        function select() {
            var submitData = new Object();
            submitData.Type = "select";
            submitData.SPNo = $("#SSPNo").val();
            submitData.SRVName = $("#SSRVName").val();
            submitData.LateSRVName = $("#SLateSRVName").val();
            submitData.Page = page;
            transmitData(datatostr(submitData));
            return;
        }
        function jump(pageindex) {
            page = pageindex;
            select();
            transmitData(datatostr(submitData));
            return;
        }
        function cancel() {
            id = "";
            $("#list").css("display", "");
            $("#edit").css("display", "none");
            return;
        }

        $('#editlist').validate({
            onFocus: function () {
                this.parent().addClass('active');
                return false;
            },
            onBlur: function () {
                var $parent = this.parent();
                var _status = parseInt(this.attr('data-status'));
                $parent.removeClass('active');
                if (!_status) {
                    $parent.addClass('error');
                }
                return false;
            }
        }, tiptype = "1");
        var page = 1;

        var trid = "";
        reflist();
    </script>
</body>
</html>
