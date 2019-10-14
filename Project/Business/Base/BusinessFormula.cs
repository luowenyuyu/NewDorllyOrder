using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using project.Entity.Base;

namespace project.Business.Base
{
    public class BusinessFormula : project.Business.AbstractPmBusiness
    {
        private EntityFormula _entity = new EntityFormula();
        public string OrderField = "a.CreateDate desc";
        Data objdata = new Data();
        /// <summary>
        /// 缺省构造函数
        /// </summary>
        public BusinessFormula() { }

        /// <summary>
        /// 带参数的构函数
        /// </summary>
        /// <param name="entity">实体类</param>
        public BusinessFormula(EntityFormula entity)
        {
            this._entity = entity;
        }

        /// <summary>
        /// 与实体类(EntityCalcMethod)关联
        /// </summary>
        public project.Entity.Base.EntityFormula Entity
        {
            get { return _entity as EntityFormula; }
        }

        public void GetByID(string id)
        {
            DataRow dr = objdata.PopulateDataSet(string.Format("select * from mstr_formula where id='{0}'", id)).Tables[0].Rows[0];
            _entity.ID = dr["ID"].ToString();
            _entity.Name = dr["Name"].ToString();
            _entity.Explanation = dr["Explanation"].ToString();
            _entity.Remark = dr["Remark"].ToString();
        }

        public int Create()
        {
            string sql = string.Format("insert into mstr_formula(id,name,explanation,remark) values('{0}','{1}','{2}','{3}')",
                Entity.ID, Entity.Name, Entity.Explanation, Entity.Remark);
            return objdata.ExecuteNonQuery(sql);
        }
        public int Update()
        {
            string sql = string.Format("update mstr_formula set name='{0}',explanation='{1}',remark='{2}' where id='{3}'",
                Entity.Name, Entity.Explanation, Entity.Remark, Entity.ID);
            return objdata.ExecuteNonQuery(sql);
        }

        public int Delete()
        {
            string sql = string.Format("delete from mstr_formula where id='{0}'", Entity.ID);
            return objdata.ExecuteNonQuery(sql);
        }
        public List<EntityFormula> GetList(string id, string name, string explanation, int pageIndex, int pageSize)
        {
            StringBuilder whereSB = new StringBuilder();
            if (!string.IsNullOrEmpty(id)) whereSB.AppendFormat("and id like '%{0}%' ", id);
            if (!string.IsNullOrEmpty(name)) whereSB.AppendFormat("and name like '%{0}%' ", name);
            if (!string.IsNullOrEmpty(explanation)) whereSB.AppendFormat("and explanation like '%{0}'% ", explanation);
            int index = pageIndex > 0 ? pageIndex : 1;
            int size = pageSize > 0 ? pageSize : 20;
            DataTable dt = objdata.ExecSelect("mstr_formula", whereSB.ToString(), index, size, "id");
            return GetEntityList(dt);
        }
        public int GetCount(string id, string name, string explanation)
        {
            StringBuilder sb = new StringBuilder("select count(*) as cnt from mstr_formula where 1=1 ");
            if (!string.IsNullOrEmpty(id)) sb.AppendFormat("and id like '%{0}%' ", id);
            if (!string.IsNullOrEmpty(name)) sb.AppendFormat("and name like '%{0}%' ", name);
            if (!string.IsNullOrEmpty(explanation)) sb.AppendFormat("and explanation like '%{0}'% ", explanation);
            string count = objdata.PopulateDataSet(sb.ToString()).Tables[0].Rows[0]["cnt"].ToString();
            return int.Parse(count);

        }
        public List<EntityFormula> GetEntityList(DataTable dt)
        {
            List<EntityFormula> entityList = new List<EntityFormula>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EntityFormula entity = new EntityFormula();
                    entity.ID = dr["ID"].ToString();
                    entity.Name = dr["Name"].ToString();
                    entity.Explanation = dr["Explanation"].ToString();
                    entity.Remark = dr["Remark"].ToString();
                    entityList.Add(entity);
                }
            }
            return entityList;
        }
    }
}
