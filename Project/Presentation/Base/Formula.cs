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
using project.Business.Base;
using project.Entity.Base;
using Newtonsoft.Json;

namespace project.Presentation.Base
{
    public partial class Formula : AbstractPmPage, System.Web.UI.ICallbackEventHandler
    {
        protected string userid = "";
        Business.Sys.BusinessUserInfo user = new project.Business.Sys.BusinessUserInfo();
        Data obj = new Data();
        protected string list = "";
        protected string Buttons = "";
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
                    CheckRight(user.Entity, "pm/Base/CalcMethod.aspx");

                    if (!Page.IsCallback)
                    {
                        if (user.Entity.UserType.ToUpper() != "ADMIN")
                        {
                            string sqlstr = "select a.RightCode from Sys_UserRight a left join sys_menu b on a.MenuId=b.MenuID " +
                                "where a.UserType='" + user.Entity.UserType + "' and menupath='pm/Base/CalcMethod.aspx'";
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

                        list = createList(string.Empty, string.Empty, string.Empty, 1);
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


        private string createList(string id, string name, string explanation, int pageIndex)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("");

            sb.Append("<table class=\"table table-border table-bordered table-hover table-bg table-sort\" id=\"tablelist\">");
            sb.Append("<thead>");
            sb.Append("<tr class=\"text-c\">");
            sb.Append("<th width=\"5%\">序号</th>");
            sb.Append("<th width='10%'>编号</th>");
            sb.Append("<th width='15%'>名称</th>");
            sb.Append("<th width='30%'>描述</th>");
            sb.Append("<th width='30%'>备注</th>");
            sb.Append("</tr>");
            sb.Append("</thead>");

            int r = 1;
            sb.Append("<tbody>");
            BusinessFormula bc = new BusinessFormula();
            foreach (EntityFormula it in bc.GetList(id, name, explanation, pageIndex, pageSize))
            {
                sb.Append("<tr class=\"text-c\" id=\"" + it.ID + "\">");
                sb.Append("<td style=\"text-align:center;\">" + r.ToString() + "</td>");
                sb.Append("<td>" + it.ID + "</td>");
                sb.Append("<td>" + it.Name + "</td>");
                sb.Append("<td>" + it.Explanation + "</td>");
                sb.Append("<td>" + it.Remark + "</td>");
                sb.Append("</tr>");
                r++;
            }
            sb.Append("</tbody>");
            sb.Append("</table>");

            sb.Append(Paginat(bc.GetCount(id, name, explanation), pageSize, pageIndex, 7));

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
            if (jp.getValue("Type") == "select")
                result = SelectAction(jp);
            else if (jp.getValue("Type") == "jump")
                result = JumpAction(jp);
            else if (jp.getValue("Type") == "find")
                result = FindAction(jp);
            else if (jp.getValue("Type") == "add")
                result = AddAction(jp);
            else if (jp.getValue("Type") == "modify")
                result = ModifyAction(jp);
            else if (jp.getValue("Type") == "delete")
                result = DeleteAction(jp);
            return result;
        }

        private string SelectAction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 0;
            try
            {
                BusinessFormula bc = new BusinessFormula();
                collection.Add(new JsonStringValue("list", createList(jp.getValue("id"), jp.getValue("name"), jp.getValue("explanation"),1)));
            }
            catch (Exception ex)
            {
                flag = 2;
                collection.Add(new JsonStringValue("ex", ex.Message));
            }
            collection.Add(new JsonStringValue("type", "select"));
            collection.Add(new JsonNumericValue("flag", flag));
            return collection.ToString();
        }

        private string JumpAction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 0;
            try
            {
                BusinessFormula bc = new BusinessFormula();
                collection.Add(new JsonStringValue("list", createList(jp.getValue("id"), jp.getValue("name"), jp.getValue("explanation"), ParseIntForString(jp.getValue("pageIndex")))));
            }
            catch (Exception ex)
            {
                flag = 2;
                collection.Add(new JsonStringValue("ex", ex.Message));
            }
            collection.Add(new JsonStringValue("type", "select"));
            collection.Add(new JsonNumericValue("flag", flag));
            return collection.ToString();
        }

        private string FindAction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 0;
            try
            {
                BusinessFormula bc = new BusinessFormula();
                bc.GetByID(jp.getValue("id"));
                if(!string.IsNullOrEmpty(bc.Entity.ID)) collection.Add(new JsonStringValue("data", JsonConvert.SerializeObject(bc.Entity)));
                else
                {
                    flag = 1;
                    collection.Add(new JsonStringValue("msg", "该数据不存在！"));
                }

            }
            catch (Exception ex)
            {
                flag = 2;
                collection.Add(new JsonStringValue("ex", ex.Message));
            }
            collection.Add(new JsonStringValue("type", "find"));
            collection.Add(new JsonNumericValue("flag", flag));
            return collection.ToString();
        }
        private string AddAction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 1;
            try
            {
                BusinessFormula bc = new BusinessFormula();
                bc.Entity.ID = jp.getValue("id");
                bc.Entity.Name = jp.getValue("name");
                bc.Entity.Explanation = jp.getValue("explanation");
                bc.Entity.Remark = jp.getValue("remark");
                if (bc.Create() > 0)
                {
                    flag = 0;
                    collection.Add(new JsonStringValue("list", createList("", "", "", 1)));
                }
            }
            catch (Exception ex)
            {
                flag = 2;
                collection.Add(new JsonStringValue("ex", ex.Message));
            }
            collection.Add(new JsonStringValue("type", "add"));
            collection.Add(new JsonNumericValue("flag", flag));
            return collection.ToString();
        }

        private string ModifyAction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 1;
            try
            {
                BusinessFormula bc = new BusinessFormula();
                bc.GetByID(jp.getValue("id"));
                bc.Entity.Name = jp.getValue("name");
                bc.Entity.Explanation = jp.getValue("explanation");
                bc.Entity.Remark = jp.getValue("remark");
                if (bc.Update() > 0)
                {
                    flag = 0;
                    collection.Add(new JsonStringValue("list", createList("", "", "", 1)));
                }
            }
            catch (Exception ex)
            {
                flag = 2;
                collection.Add(new JsonStringValue("ex", ex.Message));
            }
            collection.Add(new JsonStringValue("type", "modify"));
            collection.Add(new JsonNumericValue("flag", flag));
            return collection.ToString();
        }
        private string DeleteAction(JsonArrayParse jp)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            int flag = 1;
            try
            {
                BusinessFormula bc = new BusinessFormula();
                bc.GetByID(jp.getValue("id"));
                if (bc.Delete() > 0)
                {
                    flag = 0;
                    collection.Add(new JsonStringValue("list", createList("", "", "", 1)));
                }
            }
            catch (Exception ex)
            {
                flag = 2;
                collection.Add(new JsonStringValue("ex", ex.Message));
            }
            collection.Add(new JsonStringValue("type", "delete"));
            collection.Add(new JsonNumericValue("flag", flag));
            return collection.ToString();
        }
    }
}
