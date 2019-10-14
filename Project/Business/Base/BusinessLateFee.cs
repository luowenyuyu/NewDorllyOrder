﻿using System;
using System.Data;
namespace project.Business.Base
{
    /// <summary>
    /// 违约金费用项目
    /// </summary>
    /// <author>tianz</author>
    /// <date>2017-06-22</date>
    public sealed class BusinessLateFee : project.Business.AbstractPmBusiness
    {
        private project.Entity.Base.EntityLateFee _entity = new project.Entity.Base.EntityLateFee();
        public string OrderField = "a.SPNo,a.CreateDate";
        Data objdata = new Data();

        /// <summary>
        /// 缺省构造函数
        /// </summary>
        public BusinessLateFee() { }

        /// <summary>
        /// 带参数的构函数
        /// </summary>
        /// <param name="entity">实体类</param>
        public BusinessLateFee(project.Entity.Base.EntityLateFee entity)
        {
            this._entity = entity;
        }

        /// <summary>
        /// 与实体类(EntityLateFee)关联
        /// </summary>
        public project.Entity.Base.EntityLateFee Entity
        {
            get { return _entity as project.Entity.Base.EntityLateFee; }
        }

        /// </summary>
        /// load方法
        /// </summary>
        public void load(string id)
        {
            DataRow dr = objdata.PopulateDataSet("select a.*,b.SRVName,c.SRVName as LateFeeSRVName,d.SPShortName from Mstr_LateFee a " +
                "left join Mstr_Service b on a.SRVNo=b.SRVNo " +
                "left join Mstr_Service c on a.LateFeeSRVNo=c.SRVNo " +
                "left join Mstr_ServiceProvider d on a.SPNo=d.SPNo " +
                "where RowPointer='" + id + "'").Tables[0].Rows[0];
            _entity.RowPointer = dr["RowPointer"].ToString();
            _entity.SPNo = dr["SPNo"].ToString();
            _entity.SPShortName = dr["SPShortName"].ToString();
            _entity.SRVNo = dr["SRVNo"].ToString();
            _entity.SRVName = dr["SRVName"].ToString();
            _entity.LateFeeSRVNo = dr["LateFeeSRVNo"].ToString();
            _entity.LateFeeSRVName = dr["LateFeeSRVName"].ToString();
            _entity.CreateUser = dr["CreateUser"].ToString();
            _entity.CreateDate = ParseDateTimeForString(dr["CreateDate"].ToString());
            _entity.UpdateUser = dr["UpdateUser"].ToString();
            _entity.UpdateDate = ParseDateTimeForString(dr["UpdateDate"].ToString());
        }

        /// </summary>
        /// Save方法
        /// </summary>
        public int Save()
        {
            string sqlstr = "";
            if (Entity.RowPointer == null)
                sqlstr = "insert into Mstr_LateFee(RowPointer,SPNo,SRVNo,LateFeeSRVNo,CreateUser,CreateDate,UpdateUser,UpdateDate)" +
                    "values(NEWID()," + "'" + Entity.SPNo + "'" + "," + "'" + Entity.SRVNo + "'" + "," +
                    "'" + Entity.LateFeeSRVNo + "'" + "," +
                    "'" + Entity.CreateUser + "'" + "," + "'" + Entity.CreateDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," +
                    "'" + Entity.UpdateUser + "'" + "," + "'" + Entity.UpdateDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + ")";
            else
                sqlstr = "update Mstr_LateFee" +
                    " set SRVNo=" + "'" + Entity.SRVNo + "'" + "," +
                    "SPNo='" + Entity.SPNo + "'" + "," +
                    "LateFeeSRVNo=" + "'" + Entity.LateFeeSRVNo + "'" + "," +
                    "UpdateUser=" + "'" + Entity.UpdateUser + "'" + "," +
                    "UpdateDate=" + "'" + Entity.UpdateDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" +
                    " where RowPointer='" + Entity.RowPointer + "'";
            return objdata.ExecuteNonQuery(sqlstr);
        }

        /// </summary>
        ///Delete方法 
        /// </summary>
        public int delete()
        {
            return objdata.ExecuteNonQuery("delete from Mstr_LateFee where RowPointer='" + Entity.RowPointer + "'");
        }

        /// <summary>
        /// 按条件查询，支持分页
        /// </summary>
        /// <param name="SRVNo">费用项目</param>
        /// <returns></returns>
        public System.Collections.ICollection GetListQuery(string SPNo, string SRVNo, string SRVName, string LateSRVName, int startRow, int pageSize)
        {
            if (startRow < 0 || pageSize <= 0)
            {
                throw new Exception();
            }

            return GetListHelper(SPNo, SRVNo, SRVName, LateSRVName, startRow, pageSize);
        }

        /// <summary>
        /// 按条件查询，不支持分页
        /// </summary>
        /// <param name="SRVNo">费用项目</param>
        /// <returns></returns>
        public System.Collections.ICollection GetListQuery(string SPNo, string SRVNo, string SRVName, string LateSRVName)
        {
            return GetListHelper(SPNo, SRVNo, SRVName, LateSRVName, START_ROW_INIT, START_ROW_INIT);
        }

        /// <summary>
        /// 返回集合的大小
        /// </summary>
        /// <param name="SRVNo">费用项目</param>
        /// <returns></returns>
        public int GetListCount(string SPNo, string SRVNo, string SRVName, string LateSRVName)
        {
            string wherestr = "";
            if (!string.IsNullOrEmpty(SPNo))
            {
                wherestr = wherestr + " and a.SPNo = '" + SPNo + "' ";
            }
            if (!string.IsNullOrEmpty(SRVNo))
            {
                wherestr = wherestr + " and a.SRVNo = '" + SRVNo + "' ";
            }
            if (!string.IsNullOrEmpty(SRVName))
            {
                wherestr = wherestr + " and b.SRVName like '%" + SRVName + "%' ";
            }
            if (!string.IsNullOrEmpty(LateSRVName))
            {
                wherestr = wherestr + " and c.SRVName  like '%" + LateSRVName + "%' ";
            }
            string sql = string.Format(@"select count(*) as cnt from Mstr_LateFee a left join Mstr_Service b on a.SRVNo=b.SRVNo  
            left join Mstr_Service c on a.LateFeeSRVNo=c.SRVNo left join Mstr_ServiceProvider d on a.SPNo=d.SPNo where 1=1 ");
            string count = objdata.PopulateDataSet(sql + wherestr).Tables[0].Rows[0]["cnt"].ToString();
            return int.Parse(count);
        }

        /// <summary>
        /// 按条件查询，返回符合条件的集合
        /// </summary>
        /// <param name="SRVNo">费用项目</param>
        /// <returns></returns>
        private System.Collections.ICollection GetListHelper(string SPNo, string SRVNo, string SRVName, string LateSRVName, int startRow, int pageSize)
        {
            string wherestr = "";
            if (!string.IsNullOrEmpty(SPNo))
            {
                wherestr = wherestr + " and a.SPNo = '" + SPNo + "' ";
            }
            if (!string.IsNullOrEmpty(SRVNo))
            {
                wherestr = wherestr + " and a.SRVNo = '" + SRVNo + "' ";
            }
            if (!string.IsNullOrEmpty(SRVName))
            {
                wherestr = wherestr + " and b.SRVName like '%" + SRVName + "%' ";
            }
            if (!string.IsNullOrEmpty(LateSRVName))
            {
                wherestr = wherestr + " and c.SRVName  like '%" + LateSRVName + "%' ";
            }


            System.Collections.IList entitys = null;
            if (startRow > START_ROW_INIT && pageSize > START_ROW_INIT)
            {
                entitys = Query(objdata.ExecSelect("Mstr_LateFee a left join Mstr_Service b on a.SRVNo=b.SRVNo " +
                    "left join Mstr_Service c on a.LateFeeSRVNo=c.SRVNo left join Mstr_ServiceProvider d on a.SPNo=d.SPNo",
                    "a.*,b.SRVName,c.SRVName as LateFeeSRVName,d.SPShortName", wherestr, startRow, pageSize, OrderField));
            }
            else
            {
                entitys = Query(objdata.ExecSelect("Mstr_LateFee a left join Mstr_Service b on a.SRVNo=b.SRVNo " +
                    "left join Mstr_Service c on a.LateFeeSRVNo=c.SRVNo left join Mstr_ServiceProvider d on a.SPNo=d.SPNo",
                    "a.*,b.SRVName,c.SRVName as LateFeeSRVName,d.SPShortName", wherestr, START_ROW_INIT, START_ROW_INIT, OrderField));
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
                project.Entity.Base.EntityLateFee entity = new project.Entity.Base.EntityLateFee();
                entity.RowPointer = dr["RowPointer"].ToString();
                entity.SPNo = dr["SPNo"].ToString();
                entity.SPShortName = dr["SPShortName"].ToString();
                entity.SRVNo = dr["SRVNo"].ToString();
                entity.SRVName = dr["SRVName"].ToString();
                entity.LateFeeSRVNo = dr["LateFeeSRVNo"].ToString();
                entity.LateFeeSRVName = dr["LateFeeSRVName"].ToString();
                entity.CreateUser = dr["CreateUser"].ToString();
                entity.CreateDate = ParseDateTimeForString(dr["CreateDate"].ToString());
                entity.UpdateUser = dr["UpdateUser"].ToString();
                entity.UpdateDate = ParseDateTimeForString(dr["UpdateDate"].ToString());
                result.Add(entity);
            }
            return result;
        }
    }
}
