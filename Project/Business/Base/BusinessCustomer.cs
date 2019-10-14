using System;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using Newtonsoft.Json;
using project.ButlerSrv;
using project.WOService;

namespace project.Business.Base
{
    /// <summary>
    /// 客户资料
    /// </summary>
    /// <author>tianz</author>
    /// <date>2017-06-22</date>
    public sealed class BusinessCustomer : project.Business.AbstractPmBusiness
    {
        private project.Entity.Base.EntityCustomer _entity = new project.Entity.Base.EntityCustomer();
        public string OrderField = "CustNo";
        Data objdata = new Data();

        /// <summary>
        /// 缺省构造函数
        /// </summary>
        public BusinessCustomer() { }

        /// <summary>
        /// 带参数的构函数
        /// </summary>
        /// <param name="entity">实体类</param>
        public BusinessCustomer(project.Entity.Base.EntityCustomer entity)
        {
            this._entity = entity;
        }

        /// <summary>
        /// 与实体类(EntityCustomer)关联
        /// </summary>
        public project.Entity.Base.EntityCustomer Entity
        {
            get { return _entity as project.Entity.Base.EntityCustomer; }
        }

        /// </summary>
        /// load方法
        /// </summary>
        public void load(string id)
        {
            DataRow dr = objdata.PopulateDataSet("select * from Mstr_Customer where CustNo='" + id + "'").Tables[0].Rows[0];
            _entity.CustNo = dr["CustNo"].ToString();
            _entity.CustName = dr["CustName"].ToString();
            _entity.CustShortName = dr["CustShortName"].ToString();
            _entity.CustType = dr["CustType"].ToString();
            _entity.Representative = dr["Representative"].ToString();
            _entity.BusinessScope = dr["BusinessScope"].ToString();
            _entity.CustLicenseNo = dr["CustLicenseNo"].ToString();
            _entity.RepIDCard = dr["RepIDCard"].ToString();
            _entity.CustContact = dr["CustContact"].ToString();
            _entity.CustTel = dr["CustTel"].ToString();
            _entity.CustContactMobile = dr["CustContactMobile"].ToString();
            _entity.CustEmail = dr["CustEmail"].ToString();
            _entity.CustBankTitle = dr["CustBankTitle"].ToString();
            _entity.CustBankAccount = dr["CustBankAccount"].ToString();
            _entity.CustBank = dr["CustBank"].ToString();
            _entity.CustStatus = dr["CustStatus"].ToString();
            _entity.CustCreateDate = ParseDateTimeForString(dr["CustCreateDate"].ToString());
            _entity.CustCreator = dr["CustCreator"].ToString();
            _entity.IsExternal = bool.Parse(dr["IsExternal"].ToString());
        }

        /// </summary>
        /// Save方法
        /// </summary>
        public int Save(string type)
        {
            string sqlstr = "";
            if (type == "insert")
                sqlstr = "insert into Mstr_Customer(CustNo,CustName,CustShortName,CustType,Representative,BusinessScope,CustLicenseNo,RepIDCard,CustContact,CustTel," +
                        "CustContactMobile,CustEmail,CustBankTitle,CustBankAccount,CustBank,CustStatus,CustCreateDate,CustCreator,IsExternal)" +
                    "values('" + Entity.CustNo + "'" + "," + "'" + Entity.CustName + "'" + "," + "'" + Entity.CustShortName + "'" + "," + "'" + Entity.CustType + "'" + "," +
                    "'" + Entity.Representative + "'" + "," + "'" + Entity.BusinessScope + "'" + "," + "'" + Entity.CustLicenseNo + "'" + "," +
                    "'" + Entity.RepIDCard + "'" + "," + "'" + Entity.CustContact + "'" + "," + "'" + Entity.CustTel + "'" + "," +
                    "'" + Entity.CustContactMobile + "'" + "," + "'" + Entity.CustEmail + "'" + "," + "'" + Entity.CustBankTitle + "'" + "," +
                    "'" + Entity.CustBankAccount + "'" + "," + "'" + Entity.CustBank + "'" + "," + "'3'" + "," +
                    "'" + Entity.CustCreateDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + ",'" + Entity.CustCreator + "','" + (Entity.IsExternal ? "1" : "0") + "'"+ ")";
            else
                sqlstr = "update Mstr_Customer" +
                    " set CustName=" + "'" + Entity.CustName + "'" + "," + "CustShortName=" + "'" + Entity.CustShortName + "'" + "," +
                    "CustType=" + "'" + Entity.CustType + "'" + "," + "Representative=" + "'" + Entity.Representative + "'" + "," +
                    "BusinessScope=" + "'" + Entity.BusinessScope + "'" + "," + "CustLicenseNo=" + "'" + Entity.CustLicenseNo + "'" + "," +
                    "RepIDCard=" + "'" + Entity.RepIDCard + "'" + "," + "CustContact=" + "'" + Entity.CustContact + "'" + "," +
                    "CustTel=" + "'" + Entity.CustTel + "'" + "," + "CustContactMobile=" + "'" + Entity.CustContactMobile + "'" + "," +
                    "CustEmail=" + "'" + Entity.CustEmail + "'" + "," + "CustBankTitle=" + "'" + Entity.CustBankTitle + "'" + "," +
                    "CustBankAccount=" + "'" + Entity.CustBankAccount + "'" + "," + "CustBank=" + "'" + Entity.CustBank + "'" + "," +
                    "IsExternal=" + (Entity.IsExternal ? "1" : "0") +
                    " where CustNo='" + Entity.CustNo + "'";
            return objdata.ExecuteNonQuery(sqlstr);
        }

        /// </summary>
        ///Delete方法 
        /// </summary>
        public int delete()
        {
            return objdata.ExecuteNonQuery("delete from Mstr_Customer where CustNo='" + Entity.CustNo + "'");
        }

        /// <summary>
        /// 按条件查询，支持分页
        /// </summary>
        /// <param name="CustNo">客户编号</param>
        /// <param name="CustName">客户名称</param>
        /// <param name="CustType">客户类型</param>
        /// <param name="CustStatus">客户状态</param>
        /// <returns></returns>
        public System.Collections.ICollection GetListQuery(string CustNo, string CustName, string CustType, string CustStatus, int startRow, int pageSize)
        {
            if (startRow < 0 || pageSize <= 0)
            {
                throw new Exception();
            }

            return GetListHelper(CustNo, CustName, CustType, CustStatus, startRow, pageSize);
        }

        /// <summary>
        /// 按条件查询，不支持分页
        /// </summary>
        /// <param name="CustNo">客户编号</param>
        /// <param name="CustName">客户名称</param>
        /// <param name="CustType">客户类型</param>
        /// <param name="CustStatus">客户状态</param>
        /// <returns></returns>
        public System.Collections.ICollection GetListQuery(string CustNo, string CustName, string CustType, string CustStatus)
        {
            return GetListHelper(CustNo, CustName, CustType, CustStatus, START_ROW_INIT, START_ROW_INIT);
        }

        /// <summary>
        /// 返回集合的大小
        /// </summary>
        /// <param name="CustNo">客户编号</param>
        /// <param name="CustName">客户名称</param>
        /// <param name="CustType">客户类型</param>
        /// <param name="CustStatus">客户状态</param>
        /// <returns></returns>
        public int GetListCount(string CustNo, string CustName, string CustType, string CustStatus)
        {
            string wherestr = "";
            if (CustNo != string.Empty)
            {
                wherestr = wherestr + " and CustNo like '%" + CustNo + "%'";
            }
            if (CustName != string.Empty)
            {
                wherestr = wherestr + " and CustName like '%" + CustName + "%'";
            }
            if (CustType != string.Empty)
            {
                wherestr = wherestr + " and CustType = '" + CustType + "'";
            }
            if (CustStatus != string.Empty)
            {
                wherestr = wherestr + " and CustStatus = '" + CustStatus + "'";
            }

            string count = objdata.PopulateDataSet("select count(*) as cnt from Mstr_Customer where 1=1 " + wherestr).Tables[0].Rows[0]["cnt"].ToString();
            return int.Parse(count);
        }

        /// <summary>
        /// 按条件查询，返回符合条件的集合
        /// </summary>
        /// <param name="CustNo">客户编号</param>
        /// <param name="CustName">客户名称</param>
        /// <param name="CustType">客户类型</param>
        /// <param name="CustStatus">客户状态</param>
        /// <returns></returns>
        private System.Collections.ICollection GetListHelper(string CustNo, string CustName, string CustType, string CustStatus, int startRow, int pageSize)
        {
            string wherestr = "";
            if (CustNo != string.Empty)
            {
                wherestr = wherestr + " and CustNo like '%" + CustNo + "%'";
            }
            if (CustName != string.Empty)
            {
                wherestr = wherestr + " and CustName like '%" + CustName + "%'";
            }
            if (CustType != string.Empty)
            {
                wherestr = wherestr + " and CustType = '" + CustType + "'";
            }
            if (CustStatus != string.Empty)
            {
                wherestr = wherestr + " and CustStatus = '" + CustStatus + "'";
            }

            System.Collections.IList entitys = null;
            if (startRow > START_ROW_INIT && pageSize > START_ROW_INIT)
            {
                entitys = Query(objdata.ExecSelect("Mstr_Customer", wherestr, startRow, pageSize, OrderField));
            }
            else
            {
                entitys = Query(objdata.ExecSelect("Mstr_Customer", wherestr, START_ROW_INIT, START_ROW_INIT, OrderField));
            }
            return entitys;
        }

        /// </summary>
        ///Query 方法 dt查询结果
        /// </summary>
        public System.Collections.IList Query(System.Data.DataTable dt)
        {
            System.Collections.IList result = new System.Collections.ArrayList();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                project.Entity.Base.EntityCustomer entity = new project.Entity.Base.EntityCustomer();
                entity.CustNo = dr["CustNo"].ToString();
                entity.CustName = dr["CustName"].ToString();
                entity.CustShortName = dr["CustShortName"].ToString();
                entity.CustType = dr["CustType"].ToString();
                entity.Representative = dr["Representative"].ToString();
                entity.BusinessScope = dr["BusinessScope"].ToString();
                entity.CustLicenseNo = dr["CustLicenseNo"].ToString();
                entity.RepIDCard = dr["RepIDCard"].ToString();
                entity.CustContact = dr["CustContact"].ToString();
                entity.CustTel = dr["CustTel"].ToString();
                entity.CustContactMobile = dr["CustContactMobile"].ToString();
                entity.CustEmail = dr["CustEmail"].ToString();
                entity.CustBankTitle = dr["CustBankTitle"].ToString();
                entity.CustBankAccount = dr["CustBankAccount"].ToString();
                entity.CustBank = dr["CustBank"].ToString();
                entity.CustStatus = dr["CustStatus"].ToString();
                entity.CustCreateDate = ParseDateTimeForString(dr["CustCreateDate"].ToString());
                entity.CustCreator = dr["CustCreator"].ToString();
                entity.IsExternal = bool.Parse(dr["IsExternal"].ToString());
                result.Add(entity);
            }
            return result;
        }

        #region 数据同步

        public bool DataOpration(string opration, string userName,out string msg)
        {
            bool success = true;
            msg = string.Empty;
            try
            {
                bool cssync = ConfigurationManager.AppSettings["IsPutKH"].ToString().Equals("Y");
                BusinessCustomer bc = null;
                if (opration.Equals("update"))
                {
                    bc = new BusinessCustomer();
                    bc.load(Entity.CustNo);
                }
                if (Save(opration) <= 0) throw new Exception("本地保存失败！");
                //是否同步到客户系统
                if (cssync)
                {
                    //同步到客户系统
                    msg = CustomerSystemSync(opration);
                    if (opration.Equals("insert"))
                    {
                        if (msg.Length > 3)
                        {
                            objdata.ExecuteNonQuery(string.Format(@"UPDATE Mstr_Customer 
                                    SET CustNo='{0}' WHERE CustNo='{1}'", msg, Entity.CustNo));
                        }
                        else
                        {
                            delete();
                            success = false;
                        }
                    }
                    else
                    {
                        if (int.Parse(msg) <= 0)
                        {
                            bc.Save(opration);
                            success = false;
                        }
                    }
                }
                else
                {
                    //不同步到客户系统
                    ButlerSync(opration, userName);
                    WOSync(opration, userName);
                }
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
                success = false;
            }
            return success;
        }

        /*
        * #################################    客户系统    #########################################
        */
        public string CustomerSystemSync(string opration)
        {
            string result = string.Empty;
            try
            {
                if (ConfigurationManager.AppSettings["IsPutKH"].ToString().Equals("Y"))
                {
                    CustSystem.CustomerSync service = new CustSystem.CustomerSync
                    {
                        Timeout = 5000,
                        Url = ConfigurationManager.AppSettings["CustUrl"].ToString()
                    };
                    //var customerInfo = JsonConvert.DeserializeObject<CustSystem.CustomerInfo>(JsonConvert.SerializeObject(this.Entity));         
                    var customerInfo = new CustSystem.CustomerInfo();
                    customerInfo.CustName = this.Entity.CustName;
                    customerInfo.CustShortName = this.Entity.CustShortName;
                    customerInfo.CustType = this.Entity.CustType;
                    customerInfo.Representative = this.Entity.Representative;
                    customerInfo.BusinessScope = this.Entity.BusinessScope;
                    customerInfo.CustLicenseNO = this.Entity.CustLicenseNo;
                    customerInfo.RepIDCard = this.Entity.RepIDCard;
                    customerInfo.CustContact = this.Entity.CustContact;
                    customerInfo.CustTel = this.Entity.CustTel;
                    customerInfo.CustContactMobile = this.Entity.CustContactMobile;
                    customerInfo.CustEmail = this.Entity.CustEmail;
                    customerInfo.CustBankTitle = this.Entity.CustBankTitle;
                    customerInfo.CustBankAccount = this.Entity.CustBankAccount;
                    customerInfo.CustBank = this.Entity.CustBank;
                    customerInfo.CustStatus = this.Entity.CustStatus;
                    customerInfo.CustCreateDate = this.Entity.CustCreateDate;
                    customerInfo.CustCreator = this.Entity.CustCreator;
                    customerInfo.IsExternal =Convert.ToInt16(this.Entity.IsExternal);
                    customerInfo.CustIdOnCenterServer = this.Entity.CustNo;
                    customerInfo.ParkNo = ConfigurationManager.AppSettings["ParkNo"].ToString();
                    customerInfo.SourceSystem_ShortName = ConfigurationManager.AppSettings["SourceSystem_ShortName"].ToString();
                    customerInfo.SoftwareInstance_ShortName = ConfigurationManager.AppSettings["SoftwareInstance_ShortName"].ToString();
                    if (opration.Equals("insert"))
                    {
                        result = service.CustomerInsert(customerInfo);
                    }
                    else
                    {
                        result = service.CustomerUpdate(customerInfo).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /*
         * #################################    艾众管家    #########################################
         */
        public void ButlerSync(string opration, string userName)
        {
            try
            {
                if (ConfigurationManager.AppSettings["IsPutGJ"].ToString().Equals("Y"))
                {
                    ButlerSrv.AppService service = new ButlerSrv.AppService
                    {
                        Timeout = 5000,
                        Url = ConfigurationManager.AppSettings["ButlerUrl"].ToString()
                    };
                    if (opration.Equals("insert"))
                    {
                        service.SetCustomer(Entity.CustNo, Entity.CustName, Entity.CustShortName, Entity.CustType, Entity.Representative,
                                        Entity.BusinessScope, Entity.CustLicenseNo, Entity.RepIDCard, Entity.CustContact, Entity.CustTel,
                                        Entity.CustContactMobile, Entity.CustEmail, Entity.CustBankTitle, Entity.CustBankAccount, Entity.CustBank,
                                        Entity.IsExternal, userName, "insert", "5218E3ED752A49D4");
                    }
                    else
                    {
                        service.SetCustomer(Entity.CustNo, Entity.CustName, Entity.CustShortName, Entity.CustType, Entity.Representative,
                                      Entity.BusinessScope, Entity.CustLicenseNo, Entity.RepIDCard, Entity.CustContact, Entity.CustTel,
                                      Entity.CustContactMobile, Entity.CustEmail, Entity.CustBankTitle, Entity.CustBankAccount, Entity.CustBank,
                                      Entity.IsExternal, userName, "update", "5218E3ED752A49D4");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /*
        * #################################    工单系统    #########################################
        */

        public void WOSync(string opration, string userName)
        {
            try
            {
                if (ConfigurationManager.AppSettings["IsPutGD"].ToString().Equals("Y"))
                {
                    WOService.WebService service = new WOService.WebService
                    {
                        Timeout = 5000,
                        Url = ConfigurationManager.AppSettings["WOUrl"].ToString()
                    };
                    if (opration.Equals("insert"))
                    {
                        service.SetCustomer(Entity.CustNo, Entity.CustName, Entity.CustShortName, Entity.CustType, Entity.Representative,
                                        Entity.BusinessScope, Entity.CustLicenseNo, Entity.RepIDCard, Entity.CustContact, Entity.CustTel,
                                        Entity.CustContactMobile, Entity.CustEmail, Entity.CustBankTitle, Entity.CustBankAccount, Entity.CustBank,
                                        Entity.IsExternal, userName, "insert", "5218E3ED752A49D4");
                    }
                    else
                    {
                        service.SetCustomer(Entity.CustNo, Entity.CustName, Entity.CustShortName, Entity.CustType, Entity.Representative,
                                      Entity.BusinessScope, Entity.CustLicenseNo, Entity.RepIDCard, Entity.CustContact, Entity.CustTel,
                                      Entity.CustContactMobile, Entity.CustEmail, Entity.CustBankTitle, Entity.CustBankAccount, Entity.CustBank,
                                      Entity.IsExternal, userName, "update", "5218E3ED752A49D4");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

    }
}
