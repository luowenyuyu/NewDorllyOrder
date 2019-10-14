<%@ Page Language="C#" AutoEventWireup="true" Inherits="project.Presentation.Base.Formula,project" %>

<!DOCTYPE>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head1" runat="server">
    <title>费用项目税率设置</title>
    <!--[if lt IE 9]>
    <script type="text/javascript" src="../jscript/html5.js"></script>
    <script type="text/javascript" src="../jscript/respond.min.js"></script>
    <![endif]-->
    <link href="../../css/H-ui.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/H-ui.admin.css" rel="stylesheet" type="text/css" />
    <link href="../../lib/iconfont/iconfont.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/JsInput.css" rel="stylesheet" />
    <script type="text/javascript">
        function transmitData(submitData) {
            var data = submitData;
            <%=ClientScript.GetCallbackEventReference(this, "data", "BandResuleData", null) %>
        }
    </script>
    <style>
        .selectform .form-label{
            height:27px;
            line-height:27px;
            text-align:right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server"></form>
    <nav class="breadcrumb"><i class="Hui-iconfont">&#xe67f;</i> 首页 <span class="c-gray en">&gt;</span> 基础资料 <span class="c-gray en">&gt;</span>计算公式设置 <a class="btn btn-success radius r mr-20" style="line-height: 1.6em; margin-top: 2px" href="javascript:location.replace(location.href);" title="刷新"><i class="Hui-iconfont">&#xe68f;</i></a></nav>
    <div id="list" class="pt-5 pr-20 pb-5 pl-20">
        <div class="cl pd-5 bg-1 bk-gray mt-2">
            <span class="l">
                <%--<a href="javascript:;" onclick="insert()" class="btn btn-primary radius"><i class="Hui-iconfont">&#xe600;</i> 添加</a>
                <a href="javascript:;" onclick="update()" class="btn btn-primary radius"><i class="Hui-iconfont">&#xe60c;</i> 修改</a>--%>
                <%=Buttons %>
                <input type="hidden" id="selectKey" />
            </span>
        </div>

        <div class="cl pd-10  bk-gray mt-2 selectform">
            <div class="row">
                <div class="form-label col-1">公式编号：</div>
                <div class="formControls col-2">
                    <input type="text" class="input-text size-MINI" placeholder="公式编号" id="selectID" />
                </div>
                <div class="form-label col-1">公式名称：</div>
                <div class="formControls col-2">
                    <input type="text" class="input-text size-MINI" placeholder="公式名称" id="selectName" />
                </div>
                <div class="form-label col-1">公式描述：</div>
                <div class="formControls col-2">
                    <input type="text" class="input-text size-MINI" placeholder="公式描述" id="selectExplanation" />
                </div>
                 <div class="form-label col-1">
                <button type="submit" class="btn btn-success radius" onclick="select()"><i class="Hui-iconfont">&#xe665;</i> 查询</button>
            </div>
            </div>
           
        </div>
        <div class="mt-5" id="table">
            <%=list %>
        </div>
    </div>
    <div id="edit" class="pt-5 pr-20 pb-5 pl-20 " style="display: none;">
        <div class="form form-horizontal bk-gray mt-15 pb-10" id="editlist">
            <div class="row cl">
                <label class="form-label col-2"><span class="c-red">*</span>公式编号：</label>
                <div class="formControls col-3">
                    <input type="text" class="input-text required" placeholder="公式编号" id="editID" data-valid="isNonEmpty||between:1-30" data-error="不能为空||长度为30位" />
                </div>
                <div class="col-3"></div>
            </div>
            <div class="row cl">
                <label class="form-label col-2"><span class="c-red">*</span>公式名称：</label>
                <div class="formControls col-3">
                    <input type="text" class="input-text required" placeholder="公式名称" id="editName" data-valid="isNonEmpty||between:1-80" data-error="不能为空||长度为80位" />
                </div>
                <div class="col-3"></div>
            </div>
            <div class="row cl">
                <label class="form-label col-2"><span class="c-red">*</span>公式描述：</label>
                <div class="formControls col-3">
                    <input type="text" class="input-text required" placeholder="公式描述" id="editExplanation" data-valid="isNonEmpty||between:1-200" data-error="不能为空||长度为200位" />
                </div>
                <div class="col-3"></div>
            </div>
            <div class="row cl">
                <label class="form-label col-2">公式备注：</label>
                <div class="formControls col-3">
                    <textarea cols="" rows="3" class="textarea" placeholder="备注" id="editRemark" data-valid="between:0-200" data-error="长度为0-200位"></textarea>
                </div>
                <div class="col-3"></div>
            </div>
            <div class="row cl">
                <div class="col-6 col-offset-2">
                    <input class="btn btn-primary radius" type="button" onclick="submit()" value="提 交" />
                    <input class="btn btn-default radius" type="button" onclick="cancel()" value="取 消" />
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
    <script src="../../jscript/JsInputDate.js"></script>
    <script type="text/javascript">
        function BandResuleData(temp) {
            var vjson = JSON.parse(temp);
            if (vjson.type == "select") {
                if (vjson.flag == 0) {
                    $("#table").html(vjson.list);
                    $("#selectKey").val("");
                    page = 1;
                    reflist();
                } else {
                    layer.msg("查询异常！");
                    console.log(vjson.ex);
                }
            }
            if (vjson.type == "jump") {
                if (vjson.flag == 0) {
                    $("#table").html(vjson.list);
                    $("#selectKey").val("");
                    reflist();
                } else {
                    layer.msg("查询异常！");
                    console.log(vjson.ex);
                }
            }
            if (vjson.type == "add") {
                if (vjson.flag == 0) {
                    $("#table").html(vjson.list);
                    $("#selectKey").val("");
                    $("#list").show();
                    $("#edit").hide();
                    layer.msg("新增成功！");
                    reflist();
                } else if (vjson.flag == 1) {
                    layer.msg("新增失败！");
                } else {
                    layer.msg("新增异常！");
                    console.log(vjson.ex);
                }
                return;
            }
            if (vjson.type == "modify") {
                if (vjson.flag == 0) {
                    $("#table").html(vjson.list);
                    $("#selectKey").val("");
                    $("#list").show();
                    $("#edit").hide();
                    layer.msg("更新成功！");
                    reflist();
                } else if (vjson.flag == 1) {
                    layer.msg("更新失败！");
                } else {
                    layer.msg("更新异常！");
                    console.log(vjson.ex);
                }
                return;
            }
            if (vjson.type == "find") {
                if (vjson.flag == 0) {
                    var obj = JSON.parse(vjson.data);
                    $("#editID").val(obj.ID).attr("disabled","disabled");
                    $("#editName").val(obj.Name);
                    $("#editExplanation").val(obj.Explanation);
                    $("#editRemark").val(obj.Remark);
                    $("#list").hide();
                    $("#edit").show();
                }
                else {
                    layer.msg("查找数据失败！");
                }
                return;
            }
            if (vjson.type == "delete") {
                if (vjson.flag == 0) {
                    layer.msg("删除成功！");
                    $("#selectKey").val("");
                    $("#table").html(vjson.list);
                    reflist();
                }
                else if (vjson.flag == 1) {
                    layer.msg("删除失败！");
                } else {
                    layer.msg("删除异常！");
                    console.log(vjson.ex);
                }
                return;
            }

        }

        function insert() {
            id = "";           
            $('#editlist').validate('reset');
            $('#editlist').validate('init');
            $("#editlist input[type='text']").val("").removeAttr("disabled");
            $("#editlist textarea").val("");
            $("#list").hide();
            $("#edit").show();
            type = "add";
            return;
        }
        function update() {
            if ($("#selectKey").val() == "") {
                layer.msg("请先选择要修改的信息", { icon: 3, time: 1000 });
                return;
            }
            $('#editlist').validate('reset');
            $('#editlist').validate('init');
            $("#editlist input[type='text']").val("");
            $("#editlist textarea").val("");
            id = $("#selectKey").val();
            var submitData = new Object();
            submitData.Type = "find";
            submitData.id = id;
            transmitData(datatostr(submitData));
            type = "modify";
            return;
        }
        function submit() {
            if ($('#editlist').validate('submitValidate')) {
                var submitData = new Object();
                submitData.Type = type;
                submitData.id = $("#editID").val();
                submitData.name = $("#editName").val();
                submitData.explanation = $("#editExplanation").val();
                submitData.remark = $("#editRemark").val();
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
            submitData.id = $("#selectID").val();
            submitData.name = $("#selectName").val();
            submitData.explanation = $("#selectExplanation").val();
            submitData.page = 1;
            transmitData(datatostr(submitData));
            return;
        }
        function cancel() {
            id = "";
            $("#list").show();
            $("#edit").hide();
            return;
        }
        var page = 1;
        function jump(pageIndex) {
            page = pageIndex;
            var submitData = new Object();
            submitData.Type = "jump";
            submitData.id = $("#selectID").val();
            submitData.name = $("#selectName").val();
            submitData.explanation = $("#selectExplanation").val();
            submitData.pageIndex = pageIndex;
            transmitData(datatostr(submitData));
            return;
        }

        //$('#editlist').validate({
        //    onFocus: function () {
        //        this.parent().addClass('active');
        //        return false;
        //    },
        //    onBlur: function () {
        //        var $parent = this.parent();
        //        var _status = parseInt(this.attr('data-status'));
        //        $parent.removeClass('active');
        //        if (!_status) {
        //            $parent.addClass('error');
        //        }
        //        return false;
        //    }
        //}, tiptype = "1");

        var trid = "";
        reflist();
    </script>
</body>
</html>
