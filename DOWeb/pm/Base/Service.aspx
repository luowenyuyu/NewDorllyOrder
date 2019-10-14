<%@ Page Language="C#" AutoEventWireup="true" Inherits="project.Presentation.Base.Service,project" %>

<!DOCTYPE>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head1" runat="server">
    <title>费用资料</title>
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
    <style>
        .condition {
            padding: 6px;
        }

            .condition .row {
                margin: 0px;
            }

                .condition .row:not(:first-child) {
                    margin-top: 8px;
                }
            /*下拉框调整*/
            .condition .select-input {
                width: 10%;
            }
            /*标题调整*/
            .condition .form-label {
                padding-right: 1px;
                width: 7%;
                height: 27px;
                margin: 0px;
                line-height: 27px;
            }
            /*文本框调整*/
            .condition .formControls {
                padding-right: 5px;
            }

        #edit .form-label {
            width: 10%;
        }

        #edit select {
            height: 31px;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server"></form>
    <nav class="breadcrumb"><i class="Hui-iconfont">&#xe67f;</i> 首页 <span class="c-gray en">&gt;</span> 基础资料 <span class="c-gray en">&gt;</span> 费用资料 <a class="btn btn-success radius r mr-20" style="line-height: 1.6em; margin-top: 2px" href="javascript:location.replace(location.href);" title="刷新"><i class="Hui-iconfont">&#xe68f;</i></a></nav>
    <div id="list" class="pt-5 pr-20 pb-5 pl-20">
        <div class="cl pd-5 bg-1 bk-gray mt-2">
            <span class="l">
                <%--<a href="javascript:;" onclick="insert()" class="btn btn-primary radius"><i class="Hui-iconfont">&#xe600;</i> 添加</a>
                <a href="javascript:;" onclick="update()" class="btn btn-primary radius"><i class="Hui-iconfont">&#xe60c;</i> 修改</a> 
                <a href="javascript:;" onclick="del()" class="btn btn-danger radius"><i class="Hui-iconfont">&#xe6e2;</i> 删除</a>
                <a href="javascript:;" onclick="valid()" class="btn btn-primary radius"><i class="Hui-iconfont">&#xe615;</i> 启用/停用</a>--%>
                <%=Buttons %>
                <input type="hidden" id="selectKey" />
            </span>
        </div>

        <div class="cl pd-10  bk-gray mt-2 form-horizontal condition">
            <div class="row">
                <div class="form-label col-1">服务大类：</div>
                <div class="formControls col-1 select-input">
                    <select class="input-text required size-MINI" id="s_service1" onchange="getServiceType('s_service2',this.value)">
                        <option value="" selected>全部</option>
                        <%=ServiceTypeList %>
                    </select>
                </div>
                <div class="form-label col-1">服务小类：</div>
                <div class="formControls col-1 select-input">
                    <select class="input-text required size-MINI" id="s_service2">
                        <option value="" selected>全部</option>
                    </select>
                </div>
                <div class="form-label col-1">服务商：</div>
                <div class="formControls col-1 select-input">
                    <select class="input-text required size-MINI" id="s_provider">
                        <option value="" selected>全部</option>
                        <%=ProviderList %>
                    </select>
                </div>
            </div>
            <div class="row">
                <div class="form-label col-1">费用编号：</div>
                <div class="formControls col-2">
                    <input type="text" class="input-text size-MINI" placeholder="费用编号" id="s_srvno" />
                </div>
                <div class="form-label col-1">费用名称：</div>
                <div class="formControls col-2">
                    <input type="text" class="input-text size-MINI" placeholder="费用名称" id="s_srvname" />
                </div>
                <div class="formControls col-1">
                    <button type="submit" class="btn btn-success radius" onclick="jump(1)"><i class="Hui-iconfont">&#xe665;</i> 查询</button>
                </div>
            </div>

        </div>
        <div class="mt-5" id="outerlist">
            <%=list %>
        </div>
    </div>
    <div id="edit" class="pt-5 mr-20 pb-5 ml-20 form form-horizontal bk-gray mt-15 pb-10" style="display: none;">
        <form id="feeInfo">
            <div class="row cl">
                <div class="col-1"></div>
                <label class="form-label col-2"><span class="c-red">*</span>费用编号：</label>
                <div class="formControls col-2">
                    <input type="text" class="input-text required" placeholder="费用编号" id="SRVNo" name="SRVNo" data-valid="isNonEmpty||between:1-30" data-error="费用编号不能为空||费用编号长度为1-30位" />
                </div>
                <div class="col-2"></div>
                <label class="form-label col-2"><span class="c-red">*</span>费用名称：</label>
                <div class="formControls col-2">
                    <input type="text" class="input-text required" placeholder="费用名称" id="SRVName" name="SRVName" data-valid="isNonEmpty||between:2-50" data-error="费用名称不能为空||费用名称长度为2-50位" />
                </div>
                <div class="col-2"></div>
            </div>
            <div class="row cl">
                <div class="col-1"></div>
                <label class="form-label col-2"><span class="c-red">*</span>财务科目编码：</label>
                <div class="formControls col-2">
                    <input type="text" class="input-text required" placeholder="财务科目编码" id="SRVFinanceFeeCode" name="SRVFinanceFeeCode" data-valid="isNonEmpty||between:1-30" data-error="财务科目编码不能为空||财务科目编码长度为1-30位" />
                </div>
                <div class="col-2"></div>
                <label class="form-label col-2"><span class="c-red">*</span>财务科目名称：</label>
                <div class="formControls col-2">
                    <input type="text" class="input-text required" placeholder="财务科目名称" id="SRVFinanceFeeName" name="SRVFinanceFeeName" data-valid="isNonEmpty||between:2-50" data-error="财务科目名称不能为空||财务科目名称长度为2-50位" />
                </div>
                <div class="col-2"></div>
            </div>
            <div class="row cl">
                <div class="col-1"></div>
                <label class="form-label col-2"><span class="c-red">*</span>财务应收编码：</label>
                <div class="formControls col-2">
                    <input type="text" class="input-text required" placeholder="财务应收编码" id="SRVFinanceReceivableCode" name="SRVFinanceReceivableCode" data-valid="isNonEmpty||between:1-30" data-error="财务应收编码不能为空||财务应收编码长度为1-30位" />
                </div>
                <div class="col-2"></div>
                <label class="form-label col-2"><span class="c-red">*</span>服务商：</label>
                <div class="formControls col-2">
                    <select class="input-text required size-MINI" id="SRVSPNo" name="SRVSPNo" data-valid="isNonEmpty" data-error="服务商不能为空">
                        <option value="" selected>请选择</option>
                        <%=ProviderList %>
                    </select>
                </div>
                <div class="col-2"></div>
            </div>
            <div class="row cl">
                <div class="col-1"></div>
                <label class="form-label col-2"><span class="c-red">*</span>服务大类：</label>
                <div class="formControls col-2">
                    <select class="input-text required size-MINI" id="SRVTypeNo1" name="SRVTypeNo1" data-valid="isNonEmpty" data-error="服务大类不能为空" onchange="getServiceType('SRVTypeNo2',this.value)">
                        <option value="" selected>请选择</option>
                        <%=ServiceTypeList %>
                    </select>
                </div>
                <div class="col-2"></div>
                <label class="form-label col-2"><span class="c-red">*</span>服务小类：</label>
                <div class="formControls col-2">
                    <select class="input-text required size-MINI" id="SRVTypeNo2" name="SRVTypeNo2" data-valid="isNonEmpty" data-error="服务小类不能为空">
                        <option value="" selected>请选择</option>
                    </select>
                </div>
                <div class="col-2"></div>
            </div>

            <div class="row cl">
                <div class="col-1"></div>
                <label class="form-label col-2"><span class="c-red">*</span>取整方式：</label>
                <div class="formControls col-2">
                    <select class="input-text required" id="SRVRoundType" name="SRVRoundType" data-valid="isNonEmpty" data-error="请选择取整方式">
                        <option value="">请选择</option>
                        <option value="round">四舍五入</option>
                        <option value="ceiling">向上取位</option>
                        <option value="floor">向下取位</option>
                    </select>
                </div>
                <div class="col-2"></div>
                <label class="form-label col-2"><span class="c-red">*</span>取值方式：</label>
                <div class="formControls col-2">
                    <select class="input-text required" id="SRVPriceType" name="SRVPriceType" data-valid="isNonEmpty" data-error="请选择取值方式">
                        <option value="">请选择</option>
                        <option value="1">合同取值</option>
                        <option value="2">配置取值</option>
                    </select>
                </div>
                <div class="col-2"></div>
            </div>
            <div class="row cl">
                <div class="col-1"></div>
                <label class="form-label col-2"><span class="c-red">*</span>单价：</label>
                <div class="formControls col-2">
                    <input type="text" class="input-text required" placeholder="单价" id="SRVPrice" name="SRVPrice" onchange="validDecimal(this.id)" data-valid="isNonEmpty" data-error="请填写单价" />
                </div>
                <div class="col-2"></div>
                <label class="form-label col-2"><span class="c-red">*</span>税率：</label>
                <div class="formControls col-2">
                    <input type="text" class="input-text required" placeholder="税率" id="SRVTaxRate" name="SRVTaxRate" onchange="validDecimal(this.id)" data-valid="isNonEmpty" data-error="请填写税率" />
                </div>
                <div class="col-2"></div>
            </div>
            <div class="row cl">
                <div class="col-1"></div>
                <label class="form-label col-2"><span class="c-red">*</span>计算公式：</label>
                <div class="formControls col-2">
                    <select class="input-text required size-MINI" id="SRVFormulaID" name="SRVFormulaID" data-valid="isNonEmpty" onchange="showFormulaTip(this)" data-error="计算公式不能为空">
                        <option value="" selected>请选择</option>
                        <%=FormulaList %>
                    </select>

                </div>
                <div class="col-2" id="tip">
                    <%--<span style="color: blue; font-weight: bold; height: 31px; display: inline-block; line-height: 31px; margin-left: 27px; display:none;" id="formulaTip"></span>--%>
                </div>
                <label class="form-label col-2"><span class="c-red">*</span>收费周期：</label>
                <div class="formControls col-2">
                    <select class="input-text required size-MINI" id="SRVCalcCycle" name="SRVCalcCycle" data-valid="isNonEmpty" data-error="收费周期不能为空">
                        <option value="0" selected>不参与</option>
                        <option value="1">本月收费</option>
                        <option value="2">下月收费</option>
                    </select>
                </div>
                <div class="col-2">
                </div>
            </div>
            <div class="row cl">
                <div class="col-1"></div>
                <label class="form-label col-2">备注：</label>
                <div class="formControls col-2">
                    <textarea cols="1" rows="2" class="textarea required" placeholder="备注" id="SRVRemark" name="SRVRemark" data-valid="between:0-300" data-error="备注长度为0-300位"></textarea>
                </div>
                <div class="col-2"></div>
            </div>
            <div class="row cl mt-15 mb-20">
                <div style="text-align: center;">
                    <button class="btn btn-primary radius mr-10" type="button" onclick="submitt()">&nbsp;&nbsp;提&nbsp;&nbsp;交&nbsp;&nbsp;</button>
                    <button class="btn btn-default radius" type="button" onclick="cancel()">&nbsp;&nbsp;取&nbsp;&nbsp;消&nbsp;&nbsp;</button>
                </div>
            </div>
        </form>
    </div>

    <script type="text/javascript" src="../../jscript/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../../jscript/script_common.js"></script>
    <script type="text/javascript" src="../../jscript/json2.js"></script>
    <script type="text/javascript" src="../../jscript/H-ui.js"></script>
    <script type="text/javascript" src="../../jscript/H-ui.admin.js"></script>
    <script type="text/javascript" src="../../lib/layer/layer.js"></script>
    <script type="text/javascript" src="../../lib/validate/jquery.validate.js"></script>
    <script type="text/javascript">
        function BandResuleData(temp) {
            var vjson = JSON.parse(temp);
            if (vjson.type == "jump") {
                if (vjson.flag == 0) {
                    $("#outerlist").html(vjson.liststr);
                    $("#selectKey").val("");
                    reflist();
                } else {
                    layer.msg("获取数据异常！");
                }
                return;
            }
            if (vjson.type == "delete") {
                if (vjson.flag == 0) {
                    layer.msg("删除成功！");
                    jump(page);
                }
                else {
                    layer.alert("删除失败！", { icon: 2 });
                    console.log(vjson.ex);
                }
                return;
            }
            if (vjson.type == "submit") {
                if (vjson.flag == 0) {
                    layer.msg("操作成功!", { icon: 1 });
                    $("#list").show();
                    $("#edit").hide();
                    jump(page);
                }
                else if (vjson.flag == 1) {
                    layer.alert(vjson.msg, { icon: 2 });
                }
                else {
                    layer.alert("操作失败！", { icon: 2 });
                    console.log(vjson.ex);
                }
                return;
            }
            if (vjson.type == "update") {
                if (vjson.flag == 0) {
                    var obj = JSON.parse(vjson.data);
                    deserializeObject(obj);
                    $("#SRVNo").attr("disabled", true);
                    getServiceType("SRVTypeNo2", obj.SRVTypeNo1, obj.SRVTypeNo2);
                    showFormulaTip($("#SRVFormulaID"));
                    $("#list").hide();
                    $("#edit").show();
                }
                else {
                    layer.alert("获取数据失败！", { icon: 2 });
                    console.log(vjson.ex);
                }
                return;
            }
            if (vjson.type == "valid") {
                if (vjson.flag == 0) {
                    $("#" + vjson.id).find(".td-status").html(vjson.stat);
                    layer.msg("操作成功！", { icon: 1 });
                }
                else {
                    layer.alert("操作失败！", { icon: 2 });
                    console.log(vjson.ex);
                }
                return;
            }
            if (vjson.type == "getServiceType") {
                if (vjson.flag == 0) {
                    var list = JSON.parse(vjson.data);
                    var selectNo = vjson.selectNo;
                    var html = "";
                    $.each(list, function (index, obj) {
                        if (obj.SRVTypeNo == selectNo) {
                            html += "<option value='" + obj.SRVTypeNo + "' selected>" + obj.SRVTypeName + "</option>";
                        } else {
                            html += "<option value='" + obj.SRVTypeNo + "'>" + obj.SRVTypeName + "</option>";
                        }
                    });
                    $("#" + vjson.bindID).append(html);
                } else {
                    console.log(vjson.ex);
                }
            }
        }
        //显示公式描述
        function showFormulaTip(e) {
            $("#tip").empty();
            if ($(e).val() != "") {
                var html = " <span style='color: blue; height: 31px; display: inline-block; line-height: 31px; margin-left: 27px;' >"
                    + $(e).find("option:selected").attr("data-tip")
                    + "</span>";
                $("#tip").append(html);
            }
        }
        //编辑区域的表单重设
        function editReset() {
            //$(".valid_message").remove();
            $('#edit').validate('reset');
            $("#edit input").val("");
            $("#edit textarea").val("");
            $("#edit select").val("");
            $("#SRVCalcCycle").val("0");
            $("#tip").empty();
        }
        function getEditParam(submitData) {
            submitData.SRVNo = $("#SRVNo").val();
            submitData.SRVName = $("#SRVName").val();
            submitData.SRVFinanceFeeCode = $("#SRVFinanceFeeCode").val();
            submitData.SRVFinanceFeeName = $("#SRVFinanceFeeName").val();
            submitData.SRVFinanceReceivableCode = $("#SRVFinanceReceivableCode").val();
            submitData.SRVTypeNo1 = $("#SRVTypeNo1").val();
            submitData.SRVTypeNo2 = $("#SRVTypeNo2").val();
            submitData.SRVSPNo = $("#SRVSPNo").val();
            submitData.SRVPrice = $("#SRVPrice").val();
            submitData.SRVPriceType = $("#SRVPriceType").val();
            submitData.SRVCalcCycle = $("#SRVCalcCycle").val();
            submitData.SRVTaxRate = $("#SRVTaxRate").val();
            submitData.SRVFormula = $("#SRVFormula").val();
            submitData.SRVRoundType = $("#SRVRoundType").val();
            submitData.SRVRemark = $("#SRVRemark").val();
        }
        function getSelectParam(submitData) {
            submitData.SRVNo = $("#s_srvno").val();
            submitData.SRVName = $("#s_srvname").val();
            submitData.SRVTypeNo1 = $("#s_service1").val();
            submitData.SRVTypeNo2 = $("#s_service2").val();
            submitData.SRVSPNo = $("#s_provider").val();
        }
        function insert() {
            id = "";
            type = "insert";
            $("#SRVNo").removeAttr("disabled");
            editReset();
            $("#list").hide();
            $("#edit").show();
            return;
        }
        function update() {
            if ($("#selectKey").val() == "") {
                layer.msg("请先选择要修改的信息", { icon: 3, time: 1000 });
                return;
            }
            editReset();
            id = $("#selectKey").val();
            type = "update";
            var submitData = new Object();
            submitData.id = id;
            submitData.Type = type;
            transmitData(datatostr(submitData));
            return;
        }
        function submitt() {
            if (type == "update") {
                $("#SRVNo").removeAttr("disabled");
            }
            var obj = $("#feeInfo").serializeObject();
            if (type == "update") {
                $("#SRVNo").attr("disabled", true);
            }
            if ($('#edit').validate('submitValidate')) {
                var submitData = new Object();
                submitData.Type = "submit";
                submitData.id = id;
                submitData.operation = type;
                submitData.data = JSON.stringify(obj);
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
        var page = 1;
        function jump(pageIndex) {
            page = pageIndex;
            var submitData = new Object();
            submitData.Type = "jump";
            submitData.page = pageIndex;
            getSelectParam(submitData);
            transmitData(datatostr(submitData));
            return;
        }
        function valid() {
            if ($("#selectKey").val() == "") {
                layer.msg("请先选择要停止(启用)的信息！");
                return;
            }
            layer.confirm('你确定停止(启用)吗？', function (index) {
                var submitData = new Object();
                submitData.Type = "valid";
                submitData.id = $("#selectKey").val();
                transmitData(datatostr(submitData));
            });
            return;
        }
        function cancel() {
            id = "";
            $("#list").show();
            $("#edit").hide();
            return;
        }
        //服务类别下拉数据获取
        function getServiceType(bindID, parentNo, selectNo) {
            $("#" + bindID + " option:not(:first)").remove();
            if (parentNo != "") {
                var submitData = new Object();
                submitData.Type = "getServiceType";
                submitData.bindID = bindID;
                submitData.parentNo = parentNo;
                submitData.selectNo = selectNo;
                transmitData(datatostr(submitData));
            }
            return;
        }



        $('#edit').validate({
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

        var trid = "";
        reflist();
    </script>
</body>
</html>
