using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Net.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using project.Business.Base;
using System.Linq;
using project.Entity.Base;

namespace project.Presentation.Base
{
    public partial class Service : AbstractPmPage, System.Web.UI.ICallbackEventHandler
    {
        protected string userid = "";
        Business.Sys.BusinessUserInfo user = new project.Business.Sys.BusinessUserInfo();
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpCookie hc = getCookie("1");
                if (hc != null)
                {
                    string str = hc.Value.Replace("%3D", "=");
                    userid = Encrypt.DecryptDES(str, "1");
                    user.load(userid);
                    CheckRight(user.Entity, "pm/Base/Service.aspx");

                    if (!Page.IsCallback)
                    {
                        if (user.Entity.UserType.ToUpper() != "ADMIN")
                        {
                            string sqlstr = "select a.RightCode from Sys_UserRight a left join sys_menu b on a.MenuId=b.MenuID " +
                                "where a.UserType='" + user.Entity.UserType + "' and menupath='pm/Base/Service.aspx'";
                            DataTable dt = obj.PopulateDataSet(sqlstr).Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                string rightCode = dt.Rows[0]["RightCode"].ToString();
                                if (rightCode.IndexOf("insert") >= 0)
                                    Buttons += "<a href=\"javascript:;\" onclick=\"insert()\" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe600;</i> 添加</a>&nbsp;&nbsp;";
                                if (rightCode.IndexOf("update") >= 0)
                                    Buttons += "<a href=\"javascript:;\" onclick=\"update()\" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe60c;</i> 修改</a>&nbsp;&nbsp;";
                                if (rightCode.IndexOf("delete") >= 0)
                                    Buttons += "<a href=\"javascript:;\" onclick=\"del()\" class=\"btn btn-danger radius\"><i class=\"Hui-iconfont\">&#xe6e2;</i> 删除</a>&nbsp;&nbsp;";
                                if (rightCode.IndexOf("vilad") >= 0)
                                    Buttons += "<a href=\"javascript:;\" onclick=\"valid()\" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe615;</i> 启用/停用</a>&nbsp;&nbsp;";
                            }
                        }
                        else
                        {
                            Buttons += "<a href=\"javascript:;\" onclick=\"insert()\" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe600;</i> 添加</a>&nbsp;&nbsp;";
                            Buttons += "<a href=\"javascript:;\" onclick=\"update()\" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe60c;</i> 修改</a>&nbsp;&nbsp;";
                            Buttons += "<a href=\"javascript:;\" onclick=\"del()\" class=\"btn btn-danger radius\"><i class=\"Hui-iconfont\">&#xe6e2;</i> 删除</a>&nbsp;&nbsp;";
                            Buttons += "<a href=\"javascript:;\" onclick=\"valid()\" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe615;</i> 启用/停用</a>&nbsp;&nbsp;";
                        }

                        list = createList(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 1);

                        //第一级服务类别
                        Business.Base.BusinessServiceType bst = new project.Business.Base.BusinessServiceType();
                        foreach (Entity.Base.EntityServiceType it in bst.GetListQuery(string.Empty, string.Empty, "null", string.Empty, true))
                        {
                            ServiceTypeList += string.Format("<option value='{0}'>{1}</option>", it.SRVTypeNo, it.SRVTypeName);
                        }
                        //服务商
                        Business.Base.BusinessServiceProvider bsp = new project.Business.Base.BusinessServiceProvider();
                        foreach (Entity.Base.EntityServiceProvider it in bsp.GetListQuery(string.Empty, string.Empty, true))
                        {
                            ProviderList += string.Format("<option value='{0}'>{1}</option>", it.SPNo, it.SPShortName);
                        }
                        //公式
                        Business.Base.BusinessFormula bf = new Business.Base.BusinessFormula();
                        foreach (EntityFormula it in bf.GetList(string.Empty, string.Empty, string.Empty, 0, 0))
                        {
                            FormulaList += string.Format("<option value='{0}' data-tip='{1}'>{2}</option>", it.ID, it.Explanation, it.Name);
                        }
                    }
                }
                else
                {
                    Response.Write(errorpage);
                    return;
                }
            }
            catch
            {
                Response.Write(errorpage);
                return;
            }
        }

        Data obj = new Data();
        protected string list = "";
        protected string Buttons = "";
        protected string ProviderList = string.Empty;
        protected string ServiceTypeList = string.Empty;
        protected string FormulaList = string.Empty;
        private string createList(string SRVNo, string SRVName, string SRVTypeNo1, string SRVTypeNo2, string SRVSPNo, int page)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("");

            sb.Append("<table class=\"table table-border table-bordered table-hover table-bg table-sort\" id=\"tablelist\">");
            sb.Append("<thead>");
            sb.Append("<tr class=\"text-c\">");
            sb.Append("<th width=\"5%\">序号</th>");
            sb.Append("<th width='8%'>费用编号</th>");
            sb.Append("<th width='10%'>费用名称</th>");
            sb.Append("<th width='8%'>服务大类</th>");
            sb.Append("<th width='8%'>服务子类</th>");
            sb.Append("<th width='8%'>服务商</th>");
            sb.Append("<th width='8%'>公式编号</th>");
            sb.Append("<th width='8%'>费用单价</th>");
            sb.Append("<th width='8%'>取整方式</th>");
            sb.Append("<th width='10%'>财务科目编号</th>");
            sb.Append("<th width='10%'>财务科目名称</th>");
            //sb.Append("<th width='15%'>备注</th>");
            sb.Append("<th width='5%'>状态</th>");
            sb.Append("</tr>");
            sb.Append("</thead>");

            int r = 1;
            sb.Append("<tbody>");
            Business.Base.BusinessService bc = new project.Business.Base.BusinessService();
            foreach (Entity.Base.EntityService it in bc.GetListQuery(SRVNo, SRVName, SRVTypeNo1, SRVTypeNo2, SRVSPNo, page, pageSize))
            {
                sb.Append("<tr class=\"text-c\" id=\"" + it.SRVNo + "\">");
                sb.Append("<td align='center'>" + r.ToString() + "</td>");
                sb.Append("<td>" + it.SRVNo + "</td>");
                sb.Append("<td>" + it.SRVName + "</td>");
                sb.Append("<td>" + it.SRVTypeNo1Name + "</td>");
                sb.Append("<td>" + it.SRVTypeNo2Name + "</td>");
                sb.Append("<td>" + it.SRVSPName + "</td>");
                sb.Append("<td>" + it.SRVFormulaID + "</td>");
                sb.Append("<td>" + it.SRVPrice.ToString("0.####") + "</td>");
                sb.Append("<td>" + it.SRVRoundTypeName + "</td>");
                sb.Append("<td>" + it.SRVFinanceFeeCode + "</td>");
                sb.Append("<td>" + it.SRVFinanceFeeName + "</td>");
                //sb.Append("<td>" + it.SRVRemark + "</td>");
                sb.Append("<td class=\"td-status\"><span class=\"label " + (it.SRVStatus ? "label-success" : "") + " radius\">" + (it.SRVStatus ? "有效" : "已失效") + "</span></td>");
                sb.Append("</tr>");
                r++;
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append(Paginat(bc.GetListCount(SRVNo, SRVName, SRVTypeNo1, SRVTypeNo2, SRVSPNo), pageSize, page, 7));

            return sb.ToString();
        }
        /// <summary>
        /// 服务器端ajax调用响应请求方法
        /// </summary>
        /// <param name="eventArgument">客户端回调参数</param>
        void System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent(string eventArgument)
        {
            this._clientArgument = eventArgument;
        }
        private string _clientArgument = "";

        string System.Web.UI.ICallbackEventHandler.GetCallbackResult()
        {
            string result = "";
            JsonArrayParse jp = new JsonArrayParse(this._clientArgument);
            if (jp.getValue("Type") == "delete")
                result = deleteaction(jp);
            else if (jp.getValue("Type") == "update")
                result = updateaction(jp);
            else if (jp.getValue("Type") == "submit")
                result = submitaction(jp);
            else if (jp.getValue("Type") == "jump")
                result = jumpaction(jp);
            else if (jp.getValue("Type") == "valid")
                result = validaction(jp);
            else if (jp.getValue("Type") == "getServiceType")
                result = GetServiceType(jp);
            return result;
        }

        private string updateaction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 0;
            try
            {
                Business.Base.BusinessService bs = new project.Business.Base.BusinessService();
                bs.load(jp.getValue("id"));
                collection.Add(new JsonStringValue("data", JsonConvert.SerializeObject(bs.Entity)));
            }
            catch (Exception ex)
            {
                flag = 2;
                collection.Add(new JsonStringValue("ex", ex.ToString()));
            }
            collection.Add(new JsonStringValue("type", "update"));
            collection.Add(new JsonNumericValue("flag", flag));
            return collection.ToString();
        }
        private string deleteaction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 0;
            try
            {
                Business.Base.BusinessService bs = new project.Business.Base.BusinessService();
                bs.load(jp.getValue("id"));
                if (bs.delete() <= 0) flag = 1;
            }
            catch (Exception ex)
            {
                flag = 2;
                collection.Add(new JsonStringValue("ex", ex.ToString()));
            }
            collection.Add(new JsonStringValue("type", "delete"));
            collection.Add(new JsonNumericValue("flag", flag));
            return collection.ToString();
        }
        private string submitaction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 1;
            string msg = string.Empty;
            try
            {
                BusinessService bs = null;
                string operation = jp.getValue("operation");
                if (operation == "insert")
                {
                    var entity = JsonConvert.DeserializeObject<EntityService>(jp.getValue("data"));
                    bs = new BusinessService();
                    bool isSRVNoExist = false;
                    try
                    {
                        bs.load(entity.SRVNo);
                        isSRVNoExist = true;
                    }
                    catch { }
                    if (!isSRVNoExist)
                    {
                        bs = new BusinessService(entity);
                        if (bs.Save("insert") <= 0) msg = "保存失败！";
                        else flag = 0;
                    }
                    else msg = "编号已存在！";
                    
                }
                else if (operation == "update")
                {
                    var entity = JsonConvert.DeserializeObject<EntityService>(jp.getValue("data"));
                    bs = new BusinessService(entity);
                    if (bs.Save("update") <= 0) msg = "更新失败！";
                    else flag = 0;
                }
                else msg = "指令有误！";
            }
            catch (Exception ex)
            {
                flag = 2;
                collection.Add(new JsonStringValue("ex", ex.ToString()));
            }
            //catch (SqlException ex)
            //{
            //    if (ex.Number == 2601) msg = "编号重复！";
            //    else
            //    {
            //        flag = 2;
            //        collection.Add(new JsonStringValue("ex", ex.ToString()));
            //    }
            //}

            collection.Add(new JsonStringValue("type", "submit"));
            collection.Add(new JsonNumericValue("flag", flag));
            collection.Add(new JsonStringValue("msg", msg));
            return collection.ToString();
        }
        private string jumpaction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 0;
            try
            {
                collection.Add(new JsonStringValue("liststr", createList(jp.getValue("SRVNo"),
                    jp.getValue("SRVName"), jp.getValue("SRVTypeNo1"), jp.getValue("SRVTypeNo2"),
                    jp.getValue("SRVSPNo"), ParseIntForString(jp.getValue("page")))));
            }
            catch (Exception ex)
            {
                flag = 2;
                collection.Add(new JsonStringValue("ex", ex.ToString()));
            }
            collection.Add(new JsonStringValue("type", "jump"));
            collection.Add(new JsonNumericValue("flag", flag));
            return collection.ToString();
        }
        private string validaction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 0;
            try
            {
                Business.Base.BusinessService bc = new project.Business.Base.BusinessService();
                bc.load(jp.getValue("id"));
                bc.Entity.SRVStatus = !bc.Entity.SRVStatus;

                if (bc.valid() <= 0) flag = 1;
                else
                {
                    if (bc.Entity.SRVStatus)
                        collection.Add(new JsonStringValue("stat", "<span class=\"label label-success radius\">有效</span>"));
                    else
                        collection.Add(new JsonStringValue("stat", "<span class=\"label radius\">已失效</span>"));
                }
            }
            catch (Exception ex)
            {
                flag = 2;
                collection.Add(new JsonStringValue("ex", ex.ToString()));
            }
            collection.Add(new JsonStringValue("id", jp.getValue("id")));
            collection.Add(new JsonStringValue("type", "valid"));
            collection.Add(new JsonNumericValue("flag", flag));
            return collection.ToString();
        }

        /*
         * 新增获取下拉列表数据
         */
        private string GetServiceType(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 0;
            try
            {
                string parentNo = string.IsNullOrEmpty(jp.getValue("parentNo")) ? "null" : jp.getValue("parentNo");
                Business.Base.BusinessServiceType bst = new Business.Base.BusinessServiceType();
                var serviceList = new List<EntityServiceType>();
                foreach (EntityServiceType item in bst.GetListQuery(string.Empty, string.Empty, parentNo, string.Empty, true))
                {
                    serviceList.Add(item);
                }
                collection.Add(new JsonStringValue("data", JsonConvert.SerializeObject(serviceList.Select(a => new { a.SRVTypeNo, a.SRVTypeName }))));
                collection.Add(new JsonStringValue("bindID", jp.getValue("bindID")));
                collection.Add(new JsonStringValue("selectNo", jp.getValue("selectNo")));
            }
            catch (Exception ex)
            {
                flag = 2;
                collection.Add(new JsonStringValue("ex", ex.ToString()));
            }
            collection.Add(new JsonStringValue("type", "getServiceType"));
            collection.Add(new JsonNumericValue("flag", flag));
            return collection.ToString();
        }

        private string GetProvider(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 0;
            try
            {
                Business.Base.BusinessServiceProvider bsp = new Business.Base.BusinessServiceProvider();
                var providerList = new List<EntityServiceProvider>();
                foreach (EntityServiceProvider item in bsp.GetListQuery(string.Empty, string.Empty, true))
                {
                    providerList.Add(item);
                }
                collection.Add(new JsonStringValue("data", JsonConvert.SerializeObject(providerList.Select(a => new { a.SPNo, a.SPShortName }))));
            }
            catch (Exception ex)
            {
                flag = 2;
                collection.Add(new JsonStringValue("ex", ex.ToString()));
            }
            collection.Add(new JsonStringValue("type", "getProvider"));
            collection.Add(new JsonNumericValue("flag", flag));
            return collection.ToString();

        }

        private string GetFormula(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 0;
            try
            {
                Business.Base.BusinessFormula bf = new Business.Base.BusinessFormula();
                var formulaList = new List<EntityFormula>();
                foreach (EntityFormula item in bf.GetList(string.Empty, string.Empty, string.Empty, 0, 0))
                {
                    formulaList.Add(item);
                }
                collection.Add(new JsonStringValue("data", JsonConvert.SerializeObject(formulaList.Select(a => new { a.ID, a.Name, a.Explanation }))));
            }
            catch (Exception ex)
            {
                flag = 2;
                collection.Add(new JsonStringValue("ex", ex.ToString()));
            }
            collection.Add(new JsonStringValue("type", "getFormula"));
            collection.Add(new JsonNumericValue("flag", flag));
            return collection.ToString();
        }
    }
}