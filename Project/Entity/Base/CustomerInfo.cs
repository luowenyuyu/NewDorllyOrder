using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project.Entity.Base
{
    public class CustomerInfo
    {
        public CustomerInfo()
        {
            this.CustCreateDate = DateTime.Parse("1900-1-1");   // 创建时间 
            this.UpdateTime = DateTime.Parse("1900-1-1");   // 更新时间   
            this.RetireDate = DateTime.Parse("1900-1-1");   // 退租时间 
        }

        public int SN { get; set; }  // 主键，用不到此值。
        public string CustNo { get; set; }  // 客户编号★★★ 
        public string ParkNo { get; set; }  // 工业园编号，注意，不是自增涨序列号
        public string SourceSystem_ShortName { get; set; }  // 来源系统，最长八个UNICODE字符。这个只有综合客户管理系统的数据库中使用的字段
        public string SoftwareInstance_ShortName { get; set; }  // 实例名称的简称，最长八个UNICODE字符。
        public string CustName { get; set; }        // 客户名称
        public string CustShortName { get; set; }   // 客户简称
        public string CustType { get; set; }        // 客户类型 1, 企业 2. 法人
        public string Representative { get; set; }  // 法人工表，法人代表姓名
        public string BusinessScope { get; set; }   // 经营范围
        public string CustLicenseNO { get; set; }   // 营业执照编号，社会统一代码
        public string RepIDCard { get; set; }       // 法人身份证号
        public string CustContact { get; set; }     // 企业对接人姓名
        public string CustContactPersonJob { get; set; } // 联系人职位 ▲▲▲　这一项在其它的系统中没有，仅在综合客户管理系统中有
        public string CustTel { get; set; }     // 固定电话
        public string CustContactMobile { get; set; }   // 联系人手机号
        public string CustEmail { get; set; }       // 电子邮箱
        public string CustBankTitle { get; set; }   // 收款人
        public string CustBankAccount { get; set; } // 收款账号
        public string CustBank { get; set; }        // 开户行
        public string CustStatus { get; set; }      //  （在租,退租,未租）
        public Nullable<System.DateTime> CustCreateDate { get; set; }   // 创建时间 
        public Nullable<System.DateTime> UpdateTime { get; set; }       // 更新时间  
        public string CustCreator { get; set; }
        //public bool IsExternal { get; set; }	// 是否外部客户 ▲▲▲ 这一项在综合客户管理系统中没有
        public Nullable<System.DateTime> RetireDate { get; set; }  // 退租时间 

        //public Nullable<short> IsSynchronized { get; set; }	// 是否已经同步 ，此项不同步，各数据库自行保留使用 。综合客户管理系统中，要别建一表来记录与各数据库是否已经同步。
        //public short IsEnable { get; set; }			// 是否启用 目前综合客户管理系统中用它

        //public short IsDeleted { get; set; }		// 是否已经删除。综合客户管理系统的数据中设中此字段。其它系统是否设此字段各开发人员自行决定。

        // CustIdOnCenterServer这个是只在综合客户管理系统上使用的，其它系统提交同步请求后，如果是增加数据，综合客户管理系统会把CustIdOnCenterServer返回给发起同步的其它服务器。
        // 至于其它系统用不用，由各系统开发人员自行决定。
        // 如果更新和删除时的同步请求过来，如果包含此值得，则优先用此值进行更新和删除操作。
        public string CustIdOnCenterServer { get; set; }
    }
}
