﻿using System;
using System.Data;
namespace project.Business.Op
{
    /// <summary>
    /// 合同管理费明细
    /// </summary>
    /// <author>tianz</author>
    /// <date>2017-07-26</date>
    public sealed class BusinessContractPropertyFee : project.Business.AbstractPmBusiness
    {
        private project.Entity.Op.EntityContractPropertyFee _entity = new project.Entity.Op.EntityContractPropertyFee();
        public string OrderField = "a.CreateDate desc";
        Data objdata = new Data();

        /// <summary>
        /// 缺省构造函数
        /// </summary>
        public BusinessContractPropertyFee() { }

        /// <summary>
        /// 带参数的构函数
        /// </summary>
        /// <param name="entity">实体类</param>
        public BusinessContractPropertyFee(project.Entity.Op.EntityContractPropertyFee entity)
        {
            this._entity = entity;
        }

        /// <summary>
        /// 与实体类(EntityContractPropertyFee)关联
        /// </summary>
        public project.Entity.Op.EntityContractPropertyFee Entity
        {
            get { return _entity as project.Entity.Op.EntityContractPropertyFee; }
        }

        /// </summary>
        /// load方法
        /// </summary>
        public void load(string id)
        {
            DataRow dr = objdata.PopulateDataSet("select a.*,b.SRVName from Op_ContractPropertyFee a left join Mstr_Service b on a.SRVNo=b.SRVNo where a.RowPointer='" + id + "'").Tables[0].Rows[0];
            _entity.RowPointer = dr["RowPointer"].ToString();
            _entity.RefRP = dr["RefRP"].ToString();
            _entity.RMID = dr["RMID"].ToString();
            _entity.WPNo = dr["WPNo"].ToString();
            _entity.RMArea = ParseDecimalForString(dr["RMArea"].ToString());
            _entity.UnitPrice = ParseDecimalForString(dr["UnitPrice"].ToString());
            _entity.Remark = dr["Remark"].ToString();
            _entity.SRVNo = dr["SRVNo"].ToString();
            _entity.SRVName = dr["SRVName"].ToString();
            _entity.Creator = dr["Creator"].ToString();
            _entity.CreateDate = ParseDateTimeForString(dr["CreateDate"].ToString());
            _entity.LastReviser = dr["LastReviser"].ToString();
            _entity.LastReviseDate = ParseDateTimeForString(dr["LastReviseDate"].ToString());
        }

        /// </summary>
        /// Save方法
        /// </summary>
        public int Save()
        {
            string sqlstr = "";
            if (Entity.RowPointer == null)
                sqlstr = "insert into Op_ContractPropertyFee(RowPointer,RefRP,RMID,WPNo,RMArea,UnitPrice,Remark,SRVNo," +
                        "CreateDate,Creator,LastReviseDate,LastReviser)" +
                    "values(NEWID()," + "'" + Entity.RefRP + "'" + "," + "'" + Entity.RMID + "'" + "," + "'" + Entity.WPNo+ "'" + "," + Entity.RMArea + "," + Entity.UnitPrice + "," +
                    "'" + Entity.Remark + "'" + "," + "'" + Entity.SRVNo + "'" + "," +
                    "'" + Entity.CreateDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," + "'" + Entity.Creator + "'" + "," +
                    "'" + Entity.LastReviseDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," + "'" + Entity.LastReviser + "')";
            else
                sqlstr = "update Op_ContractPropertyFee" +
                    " set RMID=" + "'" + Entity.RMID + "'" + "," + "WPNo=" + "'" + Entity.WPNo + "'" +  "," + "RMArea=" + Entity.RMArea + "," + "UnitPrice=" + Entity.UnitPrice + "," + 
                    "Remark=" + "'" + Entity.Remark + "'" + "," + "SRVNo=" + "'" + Entity.SRVNo + "'" + "," +
                    "LastReviseDate=" + "'" + Entity.LastReviseDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," +
                    "LastReviser=" + "'" + Entity.LastReviser + "'" +
                    " where RowPointer='" + Entity.RowPointer + "'";
            return objdata.ExecuteNonQuery(sqlstr);
        }

        /// </summary>
        ///Delete方法 
        /// </summary>
        public int delete()
        {
            return objdata.ExecuteNonQuery("delete from Op_ContractPropertyFee where RowPointer='" + Entity.RowPointer + "'");
        }

        /// <summary>
        /// 按条件查询，支持分页
        /// </summary>
        /// <param name="RefRP">合同外键</param>
        /// <returns></returns>
        public System.Collections.ICollection GetListQuery(string RefRP, int startRow, int pageSize)
        {
            if (startRow < 0 || pageSize <= 0)
            {
                throw new Exception();
            }

            return GetListHelper(RefRP, startRow, pageSize);
        }

        /// <summary>
        /// 按条件查询，不支持分页
        /// </summary>
        /// <param name="RefRP">合同外键</param>
        /// <returns></returns>
        public System.Collections.ICollection GetListQuery(string RefRP)
        {
            return GetListHelper(RefRP, START_ROW_INIT, START_ROW_INIT);
        }

        /// <summary>
        /// 返回集合的大小
        /// </summary>
        /// <param name="RefRP">合同外键</param>
        /// <returns></returns>
        public int GetListCount(string RefRP)
        {
            string wherestr = "";
            if (RefRP != string.Empty)
            {
                wherestr = wherestr + " and a.RefRP = '" + RefRP + "'";
            }

            string count = objdata.PopulateDataSet("select count(*) as cnt from Op_ContractPropertyFee a where 1=1 " + wherestr).Tables[0].Rows[0]["cnt"].ToString();
            return int.Parse(count);
        }

        /// <summary>
        /// 按条件查询，返回符合条件的集合
        /// </summary>
        /// <param name="RefRP">合同外键</param>
        /// <returns></returns>
        private System.Collections.ICollection GetListHelper(string RefRP, int startRow, int pageSize)
        {
            string wherestr = "";
            if (RefRP != string.Empty)
            {
                wherestr = wherestr + " and a.RefRP = '" + RefRP + "'";
            }

            System.Collections.IList entitys = null;
            if (startRow > START_ROW_INIT && pageSize > START_ROW_INIT)
            {
                entitys = Query(objdata.ExecSelect("Op_ContractPropertyFee a left join Mstr_Service b on a.SRVNo=b.SRVNo", "a.*,b.SRVName",
                    wherestr, startRow, pageSize, OrderField));
            }
            else
            {
                entitys = Query(objdata.ExecSelect("Op_ContractPropertyFee a left join Mstr_Service b on a.SRVNo=b.SRVNo", "a.*,b.SRVName",
                    wherestr, START_ROW_INIT, START_ROW_INIT, OrderField));
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
                project.Entity.Op.EntityContractPropertyFee entity = new project.Entity.Op.EntityContractPropertyFee();
                entity.RowPointer = dr["RowPointer"].ToString();
                entity.RefRP = dr["RefRP"].ToString();
                entity.RMID = dr["RMID"].ToString();
                entity.WPNo= dr["WPNo"].ToString();
                entity.RMArea = ParseDecimalForString(dr["RMArea"].ToString());
                entity.UnitPrice = ParseDecimalForString(dr["UnitPrice"].ToString());
                entity.Remark = dr["Remark"].ToString();
                entity.SRVNo = dr["SRVNo"].ToString();
                entity.SRVName = dr["SRVName"].ToString();
                entity.Creator = dr["Creator"].ToString();
                entity.CreateDate = ParseDateTimeForString(dr["CreateDate"].ToString());
                entity.LastReviser = dr["LastReviser"].ToString();
                entity.LastReviseDate = ParseDateTimeForString(dr["LastReviseDate"].ToString());
                result.Add(entity);
            }
            return result;
        }
    }
}