﻿using System;
using System.Data;
namespace project.Business.Op
{
    /// <summary>
    /// 合同电表记录
    /// </summary>
    /// <author>tianz</author>
    /// <date>2017-07-21</date>
    public sealed class BusinessContractChangeRecord : project.Business.AbstractPmBusiness
    {
        private project.Entity.Op.EntityContractChangeRecord _entity = new project.Entity.Op.EntityContractChangeRecord();
        public string OrderField = "CreateDate desc";
        Data objdata = new Data();

        /// <summary>
        /// 缺省构造函数
        /// </summary>
        public BusinessContractChangeRecord() { }

        /// <summary>
        /// 带参数的构函数
        /// </summary>
        /// <param name="entity">实体类</param>
        public BusinessContractChangeRecord(project.Entity.Op.EntityContractChangeRecord entity)
        {
            this._entity = entity;
        }

        /// <summary>
        /// 与实体类(EntityContractChangeRecord)关联
        /// </summary>
        public project.Entity.Op.EntityContractChangeRecord Entity
        {
            get { return _entity as project.Entity.Op.EntityContractChangeRecord; }
        }

        /// </summary>
        /// load方法
        /// </summary>
        public void load(string id)
        {
            DataRow dr = objdata.PopulateDataSet("select * from Op_ContractChangeRecord where RowPointer='" + id + "'").Tables[0].Rows[0];
            _entity.RowPointer = dr["RowPointer"].ToString();
            _entity.RefRP = dr["RefRP"].ToString();
            _entity.ChangeItem = dr["ChangeItem"].ToString();
            _entity.BeforeChangeContent = dr["BeforeChangeContent"].ToString();
            _entity.AfterChangeContent = dr["AfterChangeContent"].ToString();
            _entity.ChangeUser = dr["ChangeUser"].ToString();
            _entity.ChangeDate = ParseDateTimeForString(dr["ChangeDate"].ToString());
            _entity.ChangeReason = dr["ChangeReason"].ToString();
            _entity.Remark = dr["Remark"].ToString();
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
                sqlstr = "insert into Op_ContractChangeRecord(RowPointer,RefRP,ChangeItem,BeforeChangeContent,ChangeUser,ChangeDate,ChangeReason,Remark," +
                        "CreateDate,Creator,LastReviseDate,LastReviser)" +
                    "values(NEWID()," + "'" + Entity.RefRP + "'" + "," + "'" + Entity.ChangeItem + "'" + "," + "'" + Entity.BeforeChangeContent + "'" + "," +
                    "'" + Entity.ChangeUser + "'" + "," + "'" + Entity.ChangeDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," +
                   "'" + Entity.ChangeReason + "'" + "," + "'" + Entity.Remark + "'" + "," +
                    "'" + Entity.CreateDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," + "'" + Entity.Creator + "'" + "," +
                    "'" + Entity.LastReviseDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," + "'" + Entity.LastReviser + "')";
            else
                sqlstr = "update Op_ContractChangeRecord" +
                    " set ChangeItem=" + "'" + Entity.ChangeItem + "'" + "," + "BeforeChangeContent=" + "'" + Entity.BeforeChangeContent + "'" + "," +
                    "ChangeUser=" + "'" + Entity.ChangeUser + "'" + "," + "ChangeDate=" + "'" + Entity.ChangeDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," +
                    "ChangeReason=" + "'" + Entity.ChangeReason + "'" + "," + "Remark=" + "'" + Entity.Remark + "'" + "," +
                    "LastReviseDate=" + "'" + Entity.LastReviseDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," + "LastReviser=" + "'" + Entity.LastReviser + "'" +
                    " where RowPointer='" + Entity.RowPointer + "'";
            return objdata.ExecuteNonQuery(sqlstr);
        }

        /// </summary>
        ///Delete方法 
        /// </summary>
        public int delete()
        {
            return objdata.ExecuteNonQuery("delete from Op_ContractChangeRecord where RowPointer='" + Entity.RowPointer + "'");
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
                wherestr = wherestr + " and RefRP = '" + RefRP + "'";
            }

            string count = objdata.PopulateDataSet("select count(*) as cnt from Op_ContractChangeRecord where 1=1 " + wherestr).Tables[0].Rows[0]["cnt"].ToString();
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
                wherestr = wherestr + " and RefRP = '" + RefRP + "'";
            }

            System.Collections.IList entitys = null;
            if (startRow > START_ROW_INIT && pageSize > START_ROW_INIT)
            {
                entitys = Query(objdata.ExecSelect("Op_ContractChangeRecord", wherestr, startRow, pageSize, OrderField));
            }
            else
            {
                entitys = Query(objdata.ExecSelect("Op_ContractChangeRecord", wherestr, START_ROW_INIT, START_ROW_INIT, OrderField));
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
                project.Entity.Op.EntityContractChangeRecord entity = new project.Entity.Op.EntityContractChangeRecord();
                entity.RowPointer = dr["RowPointer"].ToString();
                entity.RefRP = dr["RefRP"].ToString();
                entity.ChangeItem = dr["ChangeItem"].ToString();
                entity.BeforeChangeContent = dr["BeforeChangeContent"].ToString();
                entity.AfterChangeContent = dr["AfterChangeContent"].ToString();
                entity.ChangeUser = dr["ChangeUser"].ToString();
                entity.ChangeDate = ParseDateTimeForString(dr["ChangeDate"].ToString());
                entity.ChangeReason = dr["ChangeReason"].ToString();
                entity.Remark = dr["Remark"].ToString();
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
