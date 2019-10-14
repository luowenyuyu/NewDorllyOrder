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
using System.Text;
using Newtonsoft.Json;

namespace project.Presentation.Base
{
    public partial class LateFee : AbstractPmPage, System.Web.UI.ICallbackEventHandler
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
                    CheckRight(user.Entity, "pm/Base/LateFee.aspx");

                    if (!Page.IsCallback)
                    {
                        if (user.Entity.UserType.ToUpper() != "ADMIN")
                        {
                            string sqlstr = "select a.RightCode from Sys_UserRight a left join sys_menu b on a.MenuId=b.MenuID " +
                                "where a.UserType='" + user.Entity.UserType + "' and menupath='pm/Base/LateFee.aspx'";
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
                            }
                        }
                        else
                        {
                            Buttons += "<a href=\"javascript:;\" onclick=\"insert()\" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe600;</i> 添加</a>&nbsp;&nbsp;";
                            Buttons += "<a href=\"javascript:;\" onclick=\"update()\" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe60c;</i> 修改</a>&nbsp;&nbsp;";
                            Buttons += "<a href=\"javascript:;\" onclick=\"del()\" class=\"btn btn-danger radius\"><i class=\"Hui-iconfont\">&#xe6e2;</i> 删除</a>&nbsp;&nbsp;";
                        }

                        list = createList(null, null, null, null, 1);

                        //服务商下拉列表
                        Business.Base.BusinessServiceProvider bsp = new Business.Base.BusinessServiceProvider();
                        //Provider += "<select id=\"SPNo\" class=\"input-text required\" data-valid=\"isNonEmpty\" data-error=\"服务商不能为空\">";
                        //Provider += "<option value='' selected>请选择</option>";
                        foreach (Entity.Base.EntityServiceProvider it in bsp.GetListQuery("", "", true))
                        {
                            Provider += "<option value='" + it.SPNo + "'>" + it.SPShortName + "</option>";
                        }
                        //Business.Base.BusinessService srv = new Business.Base.BusinessService();
                        //SRVNoStr += "<select id=\"SRVNo\" class=\"input-text required\" data-valid=\"isNonEmpty\" data-error=\"费用科目不能为空\">";
                        //SRVNoStr += "<option value=''></option>";
                        //LateFeeSRVNoStr += "<select id=\"LateFeeSRVNo\" class=\"input-text required\" data-valid=\"isNonEmpty\" data-error=\"对应违约金科目不能为空\">";
                        //LateFeeSRVNoStr += "<option value=''></option>";

                        //foreach (Entity.Base.EntityService it in srv.GetListQuery("", "", "", "", ""))
                        //{
                        //    SRVNoStr += "<option value='" + it.SRVNo + "'>" + it.SRVName + "</option>";
                        //    LateFeeSRVNoStr += "<option value='" + it.SRVNo + "'>" + it.SRVName + "</option>";
                        //}
                        //SRVNoStr += "</select>";
                        //LateFeeSRVNoStr += "</select>";
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
        protected string Provider = "";
        protected string SRVNoStr = "";
        protected string LateFeeSRVNoStr = "";
        private string createList(string SPNo, string SRVNo, string SRVName, string LateSRVName, int page)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("");

            sb.Append("<table class=\"table table-border table-bordered table-hover table-bg table-sort\" id=\"tablelist\">");
            sb.Append("<thead>");
            sb.Append("<tr class=\"text-c\">");
            sb.Append("<th width=\"10%\">序号</th>");
            sb.Append("<th width='20%'>服务商</th>");
            sb.Append("<th width='30%'>费用科目</th>");
            sb.Append("<th width='30%'>对应违约金科目</th>");
            sb.Append("</tr>");
            sb.Append("</thead>");

            int r = 1;
            sb.Append("<tbody>");
            Business.Base.BusinessLateFee bc = new project.Business.Base.BusinessLateFee();
            foreach (Entity.Base.EntityLateFee it in bc.GetListQuery(SPNo, SRVNo, SRVName, LateSRVName, page, pageSize))
            {
                sb.Append("<tr class=\"text-c\" id=\"" + it.RowPointer + "\">");
                sb.Append("<td style=\"text-align:center;\">" + r.ToString() + "</td>");
                sb.Append("<td style=\"text-align:left;\">" + it.SPShortName + "</td>");
                sb.Append("<td style=\"text-align:left;\">" + it.SRVName + "</td>");
                sb.Append("<td style=\"text-align:left;\">" + it.LateFeeSRVName + "</td>");
                sb.Append("</tr>");
                r++;
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append(Paginat(bc.GetListCount(SPNo, SRVNo, SRVName, LateSRVName), pageSize, page, 7));
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
            else if (jp.getValue("Type") == "select")
                result = selectaction(jp);
            else if (jp.getValue("Type") == "getFee")
                result = getFeeAction(jp);
            return result;
        }
        private string getFeeAction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 0;
            try
            {
                string fee = string.Empty;
                string lateFee = string.Empty;

                StringBuilder sb = new StringBuilder("SELECT SRVNo,SRVName FROM Mstr_Service WHERE SRVStatus=1 ");
                sb.AppendFormat("AND SRVSPNo='{0}' ", jp.getValue("SPNo"));
                fee = JsonConvert.SerializeObject(obj.PopulateDataSet(sb.ToString() + "AND SRVTypeNo1!='FWLB-007'").Tables[0]);
                lateFee = JsonConvert.SerializeObject(obj.PopulateDataSet(sb.ToString() + "AND SRVTypeNo1='FWLB-007'").Tables[0]);
                collection.Add(new JsonStringValue("FeeList", fee));
                collection.Add(new JsonStringValue("LateFeeList", lateFee));
                flag = 1;
            }
            catch (Exception ex)
            {
                collection.Add(new JsonStringValue("ex", ex.ToString()));
            }
            collection.Add(new JsonStringValue("type", "getFee"));
            collection.Add(new JsonNumericValue("flag", flag));
            return collection.ToString();
        }


        private string updateaction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            string flag = "1";
            try
            {
                Business.Base.BusinessLateFee bc = new project.Business.Base.BusinessLateFee();
                bc.load(jp.getValue("id"));
                collection.Add(new JsonStringValue("SPNo", bc.Entity.SPNo));
                collection.Add(new JsonStringValue("SRVNo", bc.Entity.SRVNo));
                collection.Add(new JsonStringValue("LateFeeSRVNo", bc.Entity.LateFeeSRVNo));
                StringBuilder sb = new StringBuilder("SELECT SRVNo,SRVName FROM Mstr_Service WHERE SRVStatus=1 ");
                sb.AppendFormat("AND SRVSPNo='{0}' ", bc.Entity.SPNo);
                string fee = JsonConvert.SerializeObject(obj.PopulateDataSet(sb.ToString() + "AND SRVTypeNo1!='FWLB-007'").Tables[0]);
                string lateFee = JsonConvert.SerializeObject(obj.PopulateDataSet(sb.ToString() + "AND SRVTypeNo1='FWLB-007'").Tables[0]);
                collection.Add(new JsonStringValue("FeeList", fee));
                collection.Add(new JsonStringValue("LateFeeList", lateFee));

            }
            catch
            { flag = "2"; }

            collection.Add(new JsonStringValue("type", "update"));
            collection.Add(new JsonStringValue("flag", flag));
            return collection.ToString();
        }
        private string deleteaction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            string flag = "1";
            try
            {
                Business.Base.BusinessLateFee bc = new project.Business.Base.BusinessLateFee();
                bc.load(jp.getValue("id"));
                int r = bc.delete();
                if (r <= 0)
                    flag = "2";
            }
            catch { flag = "2"; }

            collection.Add(new JsonStringValue("type", "delete"));
            collection.Add(new JsonStringValue("flag", flag));
            return collection.ToString();
        }
        private string submitaction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            string flag = "1";
            try
            {
                Business.Base.BusinessLateFee bc = new project.Business.Base.BusinessLateFee();
                if (jp.getValue("tp") == "update")
                {
                    bc.load(jp.getValue("id"));
                    bc.Entity.SPNo = jp.getValue("SPNo");
                    bc.Entity.SRVNo = jp.getValue("SRVNo");
                    bc.Entity.LateFeeSRVNo = jp.getValue("LateFeeSRVNo");
                    bc.Entity.UpdateUser = user.Entity.UserName;
                    bc.Entity.UpdateDate = GetDate();
                    int r = bc.Save();

                    if (r <= 0)
                        flag = "2";
                }
                else
                {
                    Data obj = new Data();
                    DataTable dt = obj.PopulateDataSet("select cnt=COUNT(*) from Mstr_LateFee where SRVNo='" + jp.getValue("SRVNo") + "'").Tables[0];
                    if (int.Parse(dt.Rows[0]["cnt"].ToString()) > 0)
                        flag = "3";
                    else
                    {
                        bc.Entity.SPNo = jp.getValue("SPNo");
                        bc.Entity.SRVNo = jp.getValue("SRVNo");
                        bc.Entity.LateFeeSRVNo = jp.getValue("LateFeeSRVNo");
                        bc.Entity.CreateUser = user.Entity.UserName;
                        bc.Entity.CreateDate = GetDate();
                        bc.Entity.UpdateUser = user.Entity.UserName;
                        bc.Entity.UpdateDate = GetDate();
                        int r = bc.Save();
                        if (r <= 0)
                            flag = "2";
                    }
                }
            }
            catch { flag = "2"; }


            collection.Add(new JsonStringValue("type", "submit"));
            collection.Add(new JsonStringValue("flag", flag));
            return collection.ToString();
        }

        private string selectaction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 0;
            try
            {
                collection.Add(new JsonStringValue("liststr",
                    createList(jp.getValue("SPNo"),"",jp.getValue("SRVName"),jp.getValue("LateSRVName"),
                    ParseIntForString(jp.getValue("Page")))));
                flag = 1;
            }
            catch (Exception ex)
            {
                collection.Add(new JsonStringValue("ex", ex.ToString()));
            }
            collection.Add(new JsonStringValue("type", "select"));
            collection.Add(new JsonNumericValue("flag", flag));

            return collection.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spno">服务商编码</param>
        /// <param name="feeno">费用编码</param>
        /// <param name="type">fee,获取费用;latefee,获取违约费用</param>
        /// <returns></returns>
        private string getFee(string spno, string type)
        {
            //FWLB-007,违约费用大类
            StringBuilder sb = new StringBuilder("SELECT SRVNo,SRVName");
            sb.AppendFormat("FROM Mstr_Service WHERE SRVStatus=1 AND SRVSPNo='{0}' ", spno);
            if (type.Equals("fee")) sb.AppendFormat("AND SRVTypeNo1!='FWLB-007'");
            else sb.AppendFormat("AND SRVTypeNo1='FWLB-007'");
            return JsonConvert.SerializeObject(obj.PopulateDataSet(sb.ToString()).Tables[0]);
        }



    }
}