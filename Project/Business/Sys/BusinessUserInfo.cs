using System;
using System.Data;
namespace project.Business.Sys
{
    /// <summary>
    /// �û���Ϣ��ҵ����
    /// </summary>
    /// <author>tianz</author>
    /// <date>2017-05-19</date>
    public sealed class BusinessUserInfo : project.Business.AbstractPmBusiness
    {
        private project.Entity.Sys.EntityUserInfo _entity = new project.Entity.Sys.EntityUserInfo() ;
        public string orderstr = "UserNo";
        Data objdata = new Data();

        /// <summary>
        /// ȱʡ���캯��
        /// </summary>
        public BusinessUserInfo() {}

        /// <summary>
        /// �������Ĺ�����
        /// </summary>
        /// <param name="entity">ʵ����</param>
        public BusinessUserInfo(project.Entity.Sys.EntityUserInfo entity)
        {
            this._entity = entity;
        }

        /// <summary>
        /// ��ʵ����(EntityUserInfo)����
        /// </summary>
        public project.Entity.Sys.EntityUserInfo Entity
        {
            get { return _entity as project.Entity.Sys.EntityUserInfo; }
        }

        /// </summary>
        ///load ���� pid����
        /// </summary>
        public void load(string userId)
        {
            DataRow dr = objdata.PopulateDataSet("select * from Sys_UserInfo where UserID='" + userId + "'").Tables[0].Rows[0];
            _entity.InnerEntityOID=dr["UserID"].ToString();
            _entity.UserType=dr["UserType"].ToString();
            _entity.UserNo=dr["UserNo"].ToString();
            _entity.UserName=dr["UserName"].ToString();
            _entity.Password=dr["Password"].ToString();
            _entity.Tel=dr["Tel"].ToString();
            _entity.Email=dr["Email"].ToString();
            _entity.Addr=dr["Addr"].ToString();
            _entity.RegDate=ParseDateTimeForString(dr["RegDate"].ToString());
            _entity.Valid = bool.Parse(dr["Valid"].ToString());
        }

        /// </summary>
        ///load ���� pid����
        /// </summary>
        public void loadUserNo(string userNo)
        {
            DataRow dr = objdata.PopulateDataSet("select * from Sys_UserInfo where UserNo='" + userNo + "'").Tables[0].Rows[0];
            _entity.InnerEntityOID = dr["UserID"].ToString();
            _entity.UserType = dr["UserType"].ToString();
            _entity.UserNo = dr["UserNo"].ToString();
            _entity.UserName = dr["UserName"].ToString();
            _entity.Password = dr["Password"].ToString();
            _entity.Tel = dr["Tel"].ToString();
            _entity.Email = dr["Email"].ToString();
            _entity.Addr = dr["Addr"].ToString();
            _entity.RegDate = ParseDateTimeForString(dr["RegDate"].ToString());
            _entity.Valid = bool.Parse(dr["Valid"].ToString());
        }

        /// </summary>
        ///Save����
        /// </summary>
        public int Save()
        {
            string sqlstr="";
            if(Entity.InnerEntityOID==null)
                sqlstr = "insert into Sys_UserInfo(UserID,UserType,UserNo,UserName,Password,Tel,Email,Addr,RegDate,Valid)" +
                    "values(newid()," + "'" + Entity.UserType + "'" + "," + 
                    "'"+Entity.UserNo+"'" + "," + "'"+Entity.UserName+"'" + "," + "'"+Entity.Password+"'" + "," + 
                    "'"+Entity.Tel+"'" + "," +"'"+Entity.Email+"'" + "," + "'"+Entity.Addr+"'" + "," + 
                    "'"+Entity.RegDate.ToString("yyyy-MM-dd HH:mm:ss")+"'" + "," + (Entity.Valid== true ?1:0) +")";
            else
                sqlstr="update Sys_UserInfo"+
                    " set UserType="+"'"+Entity.UserType+"'" + "," + "UserName="+"'"+Entity.UserName+"'" + "," + 
                    "Tel="+"'"+Entity.Tel+"'" + "," + "Email="+"'"+Entity.Email+"'" + "," + "Addr="+"'"+Entity.Addr+"'" +
                    " where UserID='" + Entity.InnerEntityOID + "'";
            return objdata.ExecuteNonQuery(sqlstr);
        }

        /// </summary>
        ///Delete ���� 
        /// </summary>
        public int delete()
        {
            return objdata.ExecuteNonQuery("delete from Sys_UserInfo where UserID='" + Entity.InnerEntityOID + "'");
        }

        /// </summary>
        /// ����/ͣ�� 
        /// </summary>
        public int valid()
        {
            return objdata.ExecuteNonQuery("update Sys_UserInfo set Valid=" + (Entity.Valid == true ? 1 : 0) + " where UserID='" + Entity.InnerEntityOID + "'");
        }

        /// </summary>
        /// ����/ͣ�� 
        /// </summary>
        public int changepwd()
        {
            return objdata.ExecuteNonQuery("update Sys_UserInfo set Password='" + Entity.Password + "' where UserID='" + Entity.InnerEntityOID + "'");
        }
        
        /// <summary>
        /// ��������ѯ��֧�ַ�ҳ
        /// </summary>
        /// <param name="UserType">�û�����</param>
        /// <param name="UserName">�û�����</param>
        /// <returns></returns>
        public System.Collections.ICollection GetUserInfoListQuery(string UserType, string UserName, int startRow, int pageSize)
        {
            if (startRow < 0 || pageSize <= 0)
            {
                throw new Exception();
            }

            return GetListHelper(UserType, UserName, startRow, pageSize);
        }

        /// <summary>
        /// ��������ѯ����֧�ַ�ҳ
        /// </summary>
        /// <param name="UserType">�û�����</param>
        /// <param name="UserName">�û�����</param>
        /// <returns></returns>
        public System.Collections.ICollection GetUserInfoListQuery(string UserType, string UserName)
        {
            return GetListHelper(UserType, UserName, START_ROW_INIT, START_ROW_INIT);
        }

        /// <summary>
        /// ���ؼ��ϵĴ�С
        /// </summary>
        /// <param name="UserType">�û�����</param>
        /// <param name="UserName">�û�����</param>
        /// <returns></returns>
        public int GetUserInfoListCount(string UserType, string UserName)
        {
            string wherestr="";
            if (UserType != string.Empty)
            {
                wherestr=wherestr+" and UserType='"+UserType+"'";
            }
            if (UserName != string.Empty)
            {
                wherestr=wherestr+" and UserName like '%"+UserName+"%'";
            }

            string count = objdata.PopulateDataSet("select count(*) as cnt from Sys_UserInfo where 1=1 " + wherestr).Tables[0].Rows[0]["cnt"].ToString();
            return int.Parse(count);
        }

        /// <summary>
        /// ��������ѯ�����ط��������ļ���
        /// </summary>
        /// <param name="UserType">�û�����</param>
        /// <param name="UserName">�û�����</param>
        /// <returns></returns>
        private System.Collections.ICollection GetListHelper(string UserType, string UserName, int startRow, int pageSize)
        {
            string wherestr="";
            if (UserType != string.Empty)
            {
                wherestr=wherestr+" and UserType='"+UserType+"'";
            }
            if (UserName != string.Empty)
            {
                wherestr=wherestr+" and UserName like '%"+UserName+"%'";
            }

            System.Collections.IList entitys = null;
            if (startRow > START_ROW_INIT && pageSize > START_ROW_INIT)
            {
                entitys=Query(objdata.ExecSelect("Sys_UserInfo", wherestr ,startRow,pageSize, orderstr));
            }
            else
            {
                entitys=Query(objdata.ExecSelect("Sys_UserInfo", wherestr , START_ROW_INIT ,START_ROW_INIT, orderstr));
            }
            return entitys;
        }

        /// <summary>
        /// ��������ѯ�����ط��������ļ���
        /// </summary>
        /// <param name="UserNo">�û�����</param>
        /// <param name="Password">�û�����</param>
        /// <returns></returns>
        public System.Collections.ICollection Login(string UserNo, string Password)
        {
            string wherestr = "";
            wherestr = wherestr + " and UserNo='" + UserNo + "'";
            wherestr = wherestr + " and Password='" + Password + "'";
            wherestr = wherestr + " and Valid=1";
            System.Collections.IList entitys = null;

            entitys = Query(objdata.ExecSelect("Sys_UserInfo", wherestr, START_ROW_INIT, START_ROW_INIT, orderstr));
            return entitys;
        }

        /// </summary>
        ///Query ���� dt��ѯ���
        /// </summary>
        public System.Collections.IList Query(System.Data.DataTable dt)
        {
            System.Collections.IList result = new System.Collections.ArrayList();
            foreach(System.Data.DataRow dr in dt.Rows)
            {
                project.Entity.Sys.EntityUserInfo entity=new project.Entity.Sys.EntityUserInfo();
              
                entity.InnerEntityOID=dr["UserID"].ToString();
                entity.UserType=dr["UserType"].ToString();
                entity.UserNo=dr["UserNo"].ToString();
                entity.UserName=dr["UserName"].ToString();
                entity.Password=dr["Password"].ToString();
                entity.Tel=dr["Tel"].ToString();
                entity.Email=dr["Email"].ToString();
                entity.Addr=dr["Addr"].ToString();
                entity.RegDate=ParseDateTimeForString(dr["RegDate"].ToString());
                entity.Valid = bool.Parse(dr["Valid"].ToString());
                result.Add(entity);
            }
            return result;
        }

    }
}
