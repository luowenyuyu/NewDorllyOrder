using project.Business.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services;
using Newtonsoft.Json;
using project.CustSystem;

/// <summary>
/// ImportService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
// [System.Web.Script.Services.ScriptService]
public class CustomerSync : WebService
{
    public CustomerSync() { }
    Data dataObj = new Data();
    [WebMethod]
    public string HelloWorld(string hello)
    {
        return hello;
    }

    /// <summary>
    /// 各系统都要实现此函数。
    /// 目前暂时只做一次同步一条数据的。
    /// </summary>
    /// <param name="customerInfo">客户信息。其中CustNo 是必须的。</param> 
    /// <returns>对于综合客户管理系统，增加成功时返回CustIdOnCenterServer，失败时返回空字符串。　</returns>
    [WebMethod]
    public string CustomerInsert(CustomerInfo customerInfo)
    {
        string result = string.Empty;
        try
        {
            var bc = new BusinessCustomer();
            bc.Entity.CustNo = customerInfo.CustIdOnCenterServer;
            bc.Entity.CustName = customerInfo.CustName;
            bc.Entity.CustShortName = customerInfo.CustShortName;
            bc.Entity.CustBank = customerInfo.CustBank;
            bc.Entity.CustBankAccount = customerInfo.CustBankAccount;
            bc.Entity.CustBankTitle = customerInfo.CustBankTitle;
            bc.Entity.CustContact = customerInfo.CustContact;
            bc.Entity.CustTel = customerInfo.CustTel;
            bc.Entity.BusinessScope = customerInfo.BusinessScope;
            bc.Entity.CustContactMobile = customerInfo.CustContactMobile;
            bc.Entity.CustEmail = customerInfo.CustEmail;
            bc.Entity.RepIDCard = customerInfo.RepIDCard;
            bc.Entity.Representative = customerInfo.Representative;
            bc.Entity.CustType = customerInfo.CustType;
            bc.Entity.CustLicenseNo = customerInfo.CustLicenseNO;
            bc.Entity.IsExternal = Convert.ToBoolean(customerInfo.IsExternal);
            bc.Entity.CustCreator = "客户系统同步";
            bc.Entity.CustCreateDate = DateTime.Now;
            result = Save("insert", bc);
        }
        catch (Exception ex)
        {
            result = ex.ToString();
        }
        return result;
    }

    /// <summary>
    /// 各系统都要实现此函数。
    /// 暂时只做一次更新一行
    /// </summary>
    /// <param name="customerInfo">其中CustNo 是必须的。在更新的时候，除CustNo之外的字段，如果为null则进行更新，不为null的则不更新。</param>
    /// <param name="sourceSystemShortName">软件名称</param>
    /// <param name="softwareInstanceShortName">软件所部署的实例名</param>
    /// <returns>更新的行数</returns>
    [WebMethod]
    public string CustomerUpdate(CustomerInfo customerInfo)
    {
        string result = string.Empty;
        try
        {
            var bc = new BusinessCustomer();
            bc.load(customerInfo.CustIdOnCenterServer);
            if (!string.IsNullOrEmpty(customerInfo.CustName)) bc.Entity.CustName = customerInfo.CustName;
            if (!string.IsNullOrEmpty(customerInfo.CustShortName)) bc.Entity.CustShortName = customerInfo.CustShortName;
            bc.Entity.CustBank = customerInfo.CustBank;
            bc.Entity.CustBankAccount = customerInfo.CustBankAccount;
            bc.Entity.CustBankTitle = customerInfo.CustBankTitle;
            bc.Entity.CustContact = customerInfo.CustContact;
            bc.Entity.CustTel = customerInfo.CustTel;
            bc.Entity.BusinessScope = customerInfo.BusinessScope;
            bc.Entity.CustContactMobile = customerInfo.CustContactMobile;
            bc.Entity.CustEmail = customerInfo.CustEmail;
            bc.Entity.RepIDCard = customerInfo.RepIDCard;
            bc.Entity.CustLicenseNo = customerInfo.CustLicenseNO;
            bc.Entity.Representative = customerInfo.Representative;
            bc.Entity.CustType = customerInfo.CustType;
            bc.Entity.IsExternal = Convert.ToBoolean(customerInfo.IsExternal);
            result = Save("update", bc);
        }
        catch (Exception ex)
        {
            result = ex.ToString();
        }
        return result;
    }

    private string Save(string type, BusinessCustomer bc)
    {
        string result = string.Empty;
        try
        {
            string sql = "";
            project.Entity.Base.EntityCustomer entity = bc.Entity;
            if (type == "insert")
                sql = "insert into Mstr_Customer(CustNo,CustName,CustShortName,CustType,Representative,BusinessScope,CustLicenseNo,RepIDCard,CustContact,CustTel," +
                        "CustContactMobile,CustEmail,CustBankTitle,CustBankAccount,CustBank,CustStatus,CustCreateDate,CustCreator,IsExternal)" +
                    "values('" + entity.CustNo + "'" + "," + "'" + entity.CustName + "'" + "," + "'" + entity.CustShortName + "'" + "," + "'" + entity.CustType + "'" + "," +
                    "'" + entity.Representative + "'" + "," + "'" + entity.BusinessScope + "'" + "," + "'" + entity.CustLicenseNo + "'" + "," +
                    "'" + entity.RepIDCard + "'" + "," + "'" + entity.CustContact + "'" + "," + "'" + entity.CustTel + "'" + "," +
                    "'" + entity.CustContactMobile + "'" + "," + "'" + entity.CustEmail + "'" + "," + "'" + entity.CustBankTitle + "'" + "," +
                    "'" + entity.CustBankAccount + "'" + "," + "'" + entity.CustBank + "'" + "," + "'3'" + "," +
                    "'" + entity.CustCreateDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + ",'" + entity.CustCreator + "','" + (entity.IsExternal ? "1" : "0") + "'" + ")";
            else
                sql = "update Mstr_Customer" +
                    " set CustName=" + "'" + entity.CustName + "'" + "," + "CustShortName=" + "'" + entity.CustShortName + "'" + "," +
                    "CustType=" + "'" + entity.CustType + "'" + "," + "Representative=" + "'" + entity.Representative + "'" + "," +
                    "BusinessScope=" + "'" + entity.BusinessScope + "'" + "," + "CustLicenseNo=" + "'" + entity.CustLicenseNo + "'" + "," +
                    "RepIDCard=" + "'" + entity.RepIDCard + "'" + "," + "CustContact=" + "'" + entity.CustContact + "'" + "," +
                    "CustTel=" + "'" + entity.CustTel + "'" + "," + "CustContactMobile=" + "'" + entity.CustContactMobile + "'" + "," +
                    "CustEmail=" + "'" + entity.CustEmail + "'" + "," + "CustBankTitle=" + "'" + entity.CustBankTitle + "'" + "," +
                    "CustBankAccount=" + "'" + entity.CustBankAccount + "'" + "," + "CustBank=" + "'" + entity.CustBank + "'" + "," +
                    "IsExternal=" + (entity.IsExternal ? "1" : "0") +
                    " where CustNo='" + entity.CustNo + "'";
            if (dataObj.ExecuteNonQueryEx(sql) < 1) result = "影响行数返回0，且没有报错！";
        }
        catch (Exception ex)
        {
            result = ex.ToString();
        }
        return result;
    }

}

