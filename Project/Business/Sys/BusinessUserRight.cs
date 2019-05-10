using System;
using System.Data;
namespace project.Business.Sys
{
    /// <summary>
    /// �û�Ȩ�޵�ҵ����
    /// </summary>
    /// <author>tianz</author>
    /// <date>2017-05-19</date>
    public sealed class BusinessUserRight : project.Business.AbstractPmBusiness
    {
        private project.Entity.Sys.EntityUserInfoRight _entity = new project.Entity.Sys.EntityUserInfoRight() ;
        public string orderstr = "MenuID";
        Data objdata = new Data();

        /// <summary>
        /// ȱʡ���캯��
        /// </summary>
        public BusinessUserRight() {}

        /// <summary>
        /// �������Ĺ�����
        /// </summary>
        /// <param name="entity">ʵ����</param>
        public BusinessUserRight(project.Entity.Sys.EntityUserInfoRight entity)
        {
            this._entity = entity;
        }

        /// <summary>
        /// ��ʵ����(EntityUserInfoRight)����
        /// </summary>
        public project.Entity.Sys.EntityUserInfoRight Entity
        {
            get { return _entity as project.Entity.Sys.EntityUserInfoRight; }
        }

        /// </summary>
        ///load ���� pid����
        /// </summary>
        public void load(string pid)
        {
            DataRow dr = objdata.PopulateDataSet("select * from Sys_UserRight where RightID='" + pid + "'").Tables[0].Rows[0];
            _entity.InnerEntityOID=dr["RightID"].ToString();
            _entity.MenuID=dr["MenuID"].ToString();
            _entity.UserType = dr["UserType"].ToString();
            _entity.RightCode = dr["RightCode"].ToString();
        }

        /// </summary>
        ///Save����
        /// </summary>
        public int Save()
        {
            string sqlstr="";
            if (Entity.InnerEntityOID == null)
                sqlstr = "insert into Sys_UserRight(RightID,MenuID,UserType,RightCode)" +
                    "values(newid()," + "'" + Entity.MenuID + "'" + "," + "'" + Entity.UserType + "'" + "," + "'" + Entity.RightCode + "'" + ")";
            else
                sqlstr = "update Sys_UserRight" +
                    " set MenuID=" + "'" + Entity.MenuID + "'" + "," + 
                    "UserType=" + "'" + Entity.UserType + "'" +"," +
                    "RightCode=" + "'" + Entity.RightCode + "'" +
                    " where RightID='" + Entity.EntityOID.ToString() + "'";
            return objdata.ExecuteNonQuery(sqlstr);
        }

        /// </summary>
        ///Delete ���� 
        /// </summary>
        public int delete()
        {
            return objdata.ExecuteNonQuery("delete from Sys_UserRight where RightID='"+Entity.EntityOID.ToString()+"'");
        }

        /// <summary>
        /// ��������ѯ��֧�ַ�ҳ
        /// </summary>
        /// <param name="UserTypeEquals">�û�����</param>
        /// <returns></returns>
        public System.Collections.ICollection GetUserRightListQuery(string UserTypeEquals, int startRow, int pageSize)
        {
            if (startRow < 0 || pageSize <= 0)
            {
                throw new Exception();
            }

            return GetListHelper(UserTypeEquals, startRow, pageSize);
        }

        /// <summary>
        /// ��������ѯ����֧�ַ�ҳ
        /// </summary>
        /// <param name="UserTypeEquals">�û�����</param>
        /// <param name="AccID">�˻�</param>
        /// <returns></returns>
        public System.Collections.ICollection GetUserRightListQuery(string UserTypeEquals)
        {
            return GetListHelper(UserTypeEquals, START_ROW_INIT, START_ROW_INIT);
        }

        /// <summary>
        /// ���ؼ��ϵĴ�С
        /// </summary>
        /// <param name="UserTypeEquals">�û�����</param>
        /// <param name="AccID">�˻�</param>
        /// <returns></returns>
        public int GetUserRightListCount(string UserTypeEquals, string AccID)
        {
            string wherestr="";
            if (UserTypeEquals != string.Empty)
            {
                wherestr=wherestr+" and UserType='"+UserTypeEquals+"'";
            }
            
            string count = objdata.PopulateDataSet("select count(*) as cnt from Sys_UserRight where 1=1 " + wherestr).Tables[0].Rows[0]["cnt"].ToString();
            return int.Parse(count);
        }

        /// <summary>
        /// ��������ѯ�����ط��������ļ���
        /// </summary>
        /// <param name="UserTypeEquals">�û�����</param>
        /// <returns></returns>
        private System.Collections.ICollection GetListHelper(string UserTypeEquals, int startRow, int pageSize)
        {
            string wherestr="";
            if (UserTypeEquals != string.Empty)
            {
                wherestr=wherestr+" and UserType='"+UserTypeEquals+"'";
            }

            System.Collections.IList entitys = null;
            if (startRow > START_ROW_INIT && pageSize > START_ROW_INIT)
            {
                entitys=Query(objdata.ExecSelect("Sys_UserRight", wherestr ,startRow,pageSize, orderstr));
            }
            else
            {
                entitys=Query(objdata.ExecSelect("Sys_UserRight", wherestr , START_ROW_INIT ,START_ROW_INIT, orderstr));
            }
            return entitys;
        }

        /// <summary>
        /// ��������ѯ�����ط��������ļ���
        /// </summary>
        /// <param name="UserType">�û�����</param>
        /// <param name="MenuType">�˵�����</param>
        /// <returns></returns>
        public System.Collections.ICollection GetUserRightInfo(string UserType, string MenuType)
        {
            System.Collections.IList result = new System.Collections.ArrayList();
            Data obj = new Data();
            DataTable dt = obj.PopulateDataSet("select a.*,b.RightId,b.RightCode as HaveRightCode from Sys_Menu a left join ( select * from Sys_UserRight where UserType='" + UserType +
                "')b on a.MenuId=b.MenuId where a.MenuType='" + MenuType + "' order by a.OrderNo").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                project.Entity.Sys.EntityUserInfoRights entity = new project.Entity.Sys.EntityUserInfoRights();

                entity.InnerEntityOID = dr["MenuID"].ToString();
                entity.MenuName = dr["MenuName"].ToString();
                entity.MenuType = dr["MenuType"].ToString();
                entity.MenuPath = dr["MenuPath"].ToString();
                entity.Flag = ParseIntForString(dr["Flag"].ToString());
                entity.Parent = dr["Parent"].ToString();
                entity.OrderNo = dr["OrderNo"].ToString();
                entity.RightCode = dr["RightCode"].ToString();
                entity.RightName = dr["RightName"].ToString();
                entity.HaveRightCode = dr["HaveRightCode"].ToString();
                if (dr["rightid"].ToString() == "")
                    entity.Right = false;
                else
                    entity.Right = true;
                result.Add(entity);
            }
            return result;
        }

        /// </summary>
        ///Query ���� dt��ѯ���
        /// </summary>
        public System.Collections.IList Query(System.Data.DataTable dt)
        {
            System.Collections.IList result = new System.Collections.ArrayList();
            foreach(System.Data.DataRow dr in dt.Rows)
            {
                project.Entity.Sys.EntityUserInfoRight entity=new project.Entity.Sys.EntityUserInfoRight();
              
                entity.InnerEntityOID=dr["RightID"].ToString();
                entity.MenuID=dr["MenuID"].ToString();
                entity.UserType = dr["UserType"].ToString();
                result.Add(entity);
            }
            return result;
        }

    }
}
