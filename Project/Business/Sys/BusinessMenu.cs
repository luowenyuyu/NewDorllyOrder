using System;
using System.Data;
namespace project.Business.Sys
{
    /// <summary>
    /// ϵͳ�˵���ҵ����
    /// </summary>
    /// <author>tianz</author>
    /// <date>2017-05-19</date>
    public sealed class BusinessMenu : project.Business.AbstractPmBusiness
    {
        private project.Entity.Sys.EntityMenu _entity = new project.Entity.Sys.EntityMenu() ;
        public string orderstr = "OrderNo";
        Data objdata = new Data();

        /// <summary>
        /// ȱʡ���캯��
        /// </summary>
        public BusinessMenu() {}

        /// <summary>
        /// �������Ĺ�����
        /// </summary>
        /// <param name="entity">ʵ����</param>
        public BusinessMenu(project.Entity.Sys.EntityMenu entity)
        {
            this._entity = entity;
        }

        /// <summary>
        /// ��ʵ����(EntityMenu)����
        /// </summary>
        public project.Entity.Sys.EntityMenu Entity
        {
            get { return _entity as project.Entity.Sys.EntityMenu; }
        }

        /// </summary>
        ///load ���� pid����
        /// </summary>
        public void load(string pid)
        {
            DataRow dr = objdata.PopulateDataSet("select * from Sys_Menu where MenuID='"+pid+"'").Tables[0].Rows[0];
            _entity.InnerEntityOID=dr["MenuID"].ToString();
            _entity.MenuName=dr["MenuName"].ToString();
            _entity.MenuType=dr["MenuType"].ToString();
            _entity.MenuPath=dr["MenuPath"].ToString();
            _entity.Flag=ParseIntForString(dr["Flag"].ToString());
            _entity.Parent=dr["Parent"].ToString();
            _entity.OrderNo=dr["OrderNo"].ToString();
        }

        /// </summary>
        ///Save����
        /// </summary>
        public int Save()
        {
            string sqlstr="";
            if(Entity.InnerEntityOID==null)
                sqlstr="insert into Sys_Menu(MenuID,MenuName,MenuType,MenuPath,Flag,Parent,OrderNo)"+
                    "values(newid()," + "'"+Entity.MenuName+"'" + "," + "'"+Entity.MenuType+"'" + "," + "'"+Entity.MenuPath+"'" + "," +
                    Entity.Flag + "," + "'" + Entity.Parent + "'" + "," + "'" + Entity.OrderNo + "')";
            else
                sqlstr="update Sys_Menu"+
                    " set MenuName="+"'"+Entity.MenuName+"'" + "," + "MenuType="+"'"+Entity.MenuType+"'" + "," + "MenuPath="+"'"+Entity.MenuPath+"'" + "," + "Flag="+Entity.Flag + "," + "Parent="+"'"+Entity.Parent+"'" + "," + "OrderNo="+"'"+Entity.OrderNo+"'"+" where MenuID='"+Entity.EntityOID.ToString()+"'";
            return objdata.ExecuteNonQuery(sqlstr);
        }

        /// </summary>
        ///Delete ���� 
        /// </summary>
        public int delete()
        {
            return objdata.ExecuteNonQuery("delete from Sys_Menu where MenuID='"+Entity.EntityOID.ToString()+"'");
        }

        /// <summary>
        /// ��������ѯ��֧�ַ�ҳ
        /// </summary>
        /// <param name="MenuTypeEquals">�˵�����</param>
        /// <param name="ParentEquals">���ڵ�</param>
        /// <returns></returns>
        public System.Collections.ICollection GetMenuListQuery(string MenuTypeEquals,string ParentEquals,int startRow, int pageSize)
        {
            if (startRow < 0 || pageSize <= 0)
            {
                throw new Exception();
            }

            return GetListHelper(MenuTypeEquals, ParentEquals, startRow, pageSize);
        }

        /// <summary>
        /// ��������ѯ����֧�ַ�ҳ
        /// </summary>
        /// <param name="MenuTypeEquals">�˵�����</param>
        /// <param name="ParentEquals">���ڵ�</param>
        /// <returns></returns>
        public System.Collections.ICollection GetMenuListQuery(string MenuTypeEquals, string ParentEquals)
        {
            return GetListHelper(MenuTypeEquals, ParentEquals, START_ROW_INIT, START_ROW_INIT);
        }

        /// <summary>
        /// ���ؼ��ϵĴ�С
        /// </summary>
        /// <param name="MenuTypeEquals">�˵�����</param>
        /// <param name="ParentEquals">���ڵ�</param>
        /// <returns></returns>
        public int GetMenuListCount(string MenuTypeEquals, string ParentEquals)
        {
            string wherestr="";
            if (MenuTypeEquals != string.Empty)
            {
                wherestr=wherestr+" and MenuType='"+MenuTypeEquals+"'";
            }
            if (ParentEquals != string.Empty)
            {
                if (ParentEquals == "null")
                    wherestr = wherestr + " and isnull(Parent,'')=''";
                else if (ParentEquals == "notnull")
                    wherestr = wherestr + " and isnull(Parent,'')<>''";
                else
                    wherestr = wherestr + " and Parent='" + ParentEquals + "'";
            }

            string count = objdata.PopulateDataSet("select count(*) as cnt from Sys_Menu where 1=1 " + wherestr).Tables[0].Rows[0]["cnt"].ToString();
            return int.Parse(count);
        }

        /// <summary>
        /// ��������ѯ�����ط��������ļ���
        /// </summary>
        /// <param name="MenuTypeEquals">�˵�����</param>
        /// <param name="ParentEquals">���ڵ�</param>
        /// <returns></returns>
        private System.Collections.ICollection GetListHelper(string MenuTypeEquals, string ParentEquals, int startRow, int pageSize)
        {
            string wherestr="";
            if (MenuTypeEquals != string.Empty)
            {
                wherestr=wherestr+" and MenuType='"+MenuTypeEquals+"'";
            }
            if (ParentEquals != string.Empty)
            {
                if (ParentEquals == "null")
                    wherestr = wherestr + " and isnull(Parent,'')=''";
                else if (ParentEquals == "notnull")
                    wherestr = wherestr + " and isnull(Parent,'')<>''";
                else
                    wherestr = wherestr + " and Parent='" + ParentEquals + "'";
            }

            System.Collections.IList entitys = null;
            if (startRow > START_ROW_INIT && pageSize > START_ROW_INIT)
            {
                entitys=Query(objdata.ExecSelect("Sys_Menu", wherestr ,startRow,pageSize, orderstr));
            }
            else
            {
                entitys=Query(objdata.ExecSelect("Sys_Menu", wherestr , START_ROW_INIT ,START_ROW_INIT, orderstr));
            }
            return entitys;
        }


        /// <summary>
        /// ��������ѯ�����ط��������ļ���
        /// </summary>
        /// <param name="ParentEquals">�ϼ�Ŀ¼</param>
        /// <param name="MenutypeEquals">����</param>
        /// <returns></returns>
        public System.Collections.ICollection GetRightMenuList(string ParentEquals, string MenutypeEquals, string UserType)
        {
            string wherestr = "";
            if (ParentEquals != string.Empty)
            {
                if (ParentEquals == "null")
                    wherestr = wherestr + " and isnull(Parent,'')=''";
                else if (ParentEquals == "notnull")
                    wherestr = wherestr + " and isnull(Parent,'')<>''";
                else
                    wherestr = wherestr + " and Parent='" + ParentEquals + "'";
            }
            if (MenutypeEquals != string.Empty)
            {
                wherestr = wherestr + " and (MenuType='" + MenutypeEquals + "' or MenuType='')";
            }

            string TabName = "Sys_Menu b";
            if (UserType.ToUpper() != "ADMIN")
            {
                TabName = "Sys_UserRight a left join Sys_Menu b on a.MenuID=b.MenuID";
                wherestr = wherestr + " and a.UserType='" + UserType + "'";
            }
            System.Collections.IList entitys = null;
            entitys = Query(objdata.ExecSelect(TabName, "b.*", wherestr, START_ROW_INIT, START_ROW_INIT, orderstr));

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
                project.Entity.Sys.EntityMenu entity=new project.Entity.Sys.EntityMenu();
              
                entity.InnerEntityOID=dr["MenuID"].ToString();
                entity.MenuName=dr["MenuName"].ToString();
                entity.MenuType=dr["MenuType"].ToString();
                entity.MenuPath=dr["MenuPath"].ToString();
                entity.Flag=ParseIntForString(dr["Flag"].ToString());
                entity.Parent=dr["Parent"].ToString();
                entity.OrderNo = dr["OrderNo"].ToString();
                result.Add(entity);
            }
            return result;
        }

    }
}
