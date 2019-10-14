using System;
using System.Data;
using System.Text;

namespace project.Business.Base
{
    /// <summary>
    /// 服务商资料
    /// </summary>
    /// <author>tianz</author>
    /// <date>2017-06-22</date>
    public sealed class BusinessService : project.Business.AbstractPmBusiness
    {
        private project.Entity.Base.EntityService _entity = new project.Entity.Base.EntityService();
        public string OrderField = "b.SPNo,a.SRVNo";
        Data objdata = new Data();

        /// <summary>
        /// 缺省构造函数
        /// </summary>
        public BusinessService() { }

        /// <summary>
        /// 带参数的构函数
        /// </summary>
        /// <param name="entity">实体类</param>
        public BusinessService(project.Entity.Base.EntityService entity)
        {
            this._entity = entity;
        }

        /// <summary>
        /// 与实体类(EntityService)关联
        /// </summary>
        public project.Entity.Base.EntityService Entity
        {
            get { return _entity as project.Entity.Base.EntityService; }
        }

        /// </summary>
        /// load方法
        /// </summary>
        public void load(string id)
        {
            DataRow dr = objdata.PopulateDataSet(@"select a.*,
                b.SPShortName as SRVSPName,c.SRVTypeName as SRVTypeNo1Name,
                d.SRVTypeName as SRVTypeNo2Name " +
                "from Mstr_Service a " +
                "left join Mstr_ServiceProvider b on a.SRVSPNo=b.SPNo " +
                "left join Mstr_ServiceType c on a.SRVTypeNo1=c.SRVTypeNo " +
                "left join Mstr_ServiceType d on a.SRVTypeNo2=d.SRVTypeNo " +
                "left join Mstr_Formula f on a.SRVFormulaID=f.ID " +
                "where a.SRVNo='" + id + "'").Tables[0].Rows[0];
            _entity.SRVNo = dr["SRVNo"].ToString();
            _entity.SRVName = dr["SRVName"].ToString();
            _entity.SRVTypeNo1 = dr["SRVTypeNo1"].ToString();
            _entity.SRVTypeNo1Name = dr["SRVTypeNo1Name"].ToString();
            _entity.SRVTypeNo2 = dr["SRVTypeNo2"].ToString();
            _entity.SRVTypeNo2Name = dr["SRVTypeNo2Name"].ToString();
            _entity.SRVSPNo = dr["SRVSPNo"].ToString();
            _entity.SRVSPName = dr["SRVSPName"].ToString();
            _entity.SRVRoundType = dr["SRVRoundType"].ToString();
            _entity.SRVTaxRate = ParseDecimalForString(dr["SRVTaxRate"].ToString());
            _entity.SRVStatus = bool.Parse(dr["SRVStatus"].ToString());
            _entity.SRVRemark = dr["SRVRemark"].ToString();
            _entity.SRVFormulaID = dr["SRVFormulaID"].ToString();
            _entity.SRVPrice = ParseDecimalForString(dr["SRVPrice"].ToString());
            _entity.SRVPriceType = ParseIntForString(dr["SRVPriceType"].ToString());
            _entity.SRVCalcCycle = ParseIntForString(dr["SRVCalcCycle"].ToString());
            _entity.SRVFinanceFeeCode = dr["SRVFinanceFeeCode"].ToString();
            _entity.SRVFinanceFeeName = dr["SRVFinanceFeeName"].ToString();
            _entity.SRVFinanceReceivableCode = dr["SRVFinanceReceivableCode"].ToString();

        }

        /// </summary>
        /// Save方法
        /// </summary>
        public int Save(string type)
        {
            StringBuilder sqlstr = new StringBuilder();
            if (type == "insert")
            {
                sqlstr.Append(@"insert into Mstr_Service(SRVNo,SRVName,SRVTypeNo1,SRVTypeNo2,SRVSPNo,
                                SRVFormulaID,SRVRoundType,SRVTaxRate,SRVPrice,SRVPriceType,SRVCalcCycle,
                                SRVFinanceFeeCode,SRVFinanceFeeName,SRVFinanceReceivableCode,
                                SRVRemark,SRVStatus) values(");
                sqlstr.AppendFormat("'{0}',", Entity.SRVNo);
                sqlstr.AppendFormat("'{0}',", Entity.SRVName);
                sqlstr.AppendFormat("'{0}',", Entity.SRVTypeNo1);
                sqlstr.AppendFormat("'{0}',", Entity.SRVTypeNo2);
                sqlstr.AppendFormat("'{0}',", Entity.SRVSPNo);
                sqlstr.AppendFormat("'{0}',", Entity.SRVFormulaID);
                sqlstr.AppendFormat("'{0}',", Entity.SRVRoundType);
                sqlstr.AppendFormat("'{0}',", Entity.SRVTaxRate);
                sqlstr.AppendFormat("'{0}',", Entity.SRVPrice);
                sqlstr.AppendFormat("'{0}',", Entity.SRVPriceType);
                sqlstr.AppendFormat("'{0}',", Entity.SRVCalcCycle);
                sqlstr.AppendFormat("'{0}',", Entity.SRVFinanceFeeCode);
                sqlstr.AppendFormat("'{0}',", Entity.SRVFinanceFeeName);
                sqlstr.AppendFormat("'{0}',", Entity.SRVFinanceReceivableCode);
                sqlstr.AppendFormat("'{0}',", Entity.SRVRemark);
                sqlstr.AppendFormat("'{0}')", "1");
            }
            else
            {
                sqlstr.Append("update Mstr_Service Set ");
                sqlstr.AppendFormat("SRVName='{0}',", Entity.SRVName);
                sqlstr.AppendFormat("SRVTypeNo1='{0}',", Entity.SRVTypeNo1);
                sqlstr.AppendFormat("SRVTypeNo2='{0}',", Entity.SRVTypeNo2);
                sqlstr.AppendFormat("SRVSPNo='{0}',", Entity.SRVSPNo);
                sqlstr.AppendFormat("SRVFormulaID='{0}',", Entity.SRVFormulaID);
                sqlstr.AppendFormat("SRVRoundType='{0}',", Entity.SRVRoundType);
                sqlstr.AppendFormat("SRVTaxRate='{0}',", Entity.SRVTaxRate);
                sqlstr.AppendFormat("SRVPrice='{0}',", Entity.SRVPrice);
                sqlstr.AppendFormat("SRVPriceType='{0}',", Entity.SRVPriceType);
                sqlstr.AppendFormat("SRVCalcCycle='{0}',", Entity.SRVCalcCycle);
                sqlstr.AppendFormat("SRVFinanceFeeCode='{0}',", Entity.SRVFinanceFeeCode);
                sqlstr.AppendFormat("SRVFinanceFeeName='{0}',", Entity.SRVFinanceFeeName);
                sqlstr.AppendFormat("SRVFinanceReceivableCode='{0}',", Entity.SRVFinanceReceivableCode);
                sqlstr.AppendFormat("SRVRemark='{0}' ", Entity.SRVRemark);
                sqlstr.AppendFormat("where SRVNo='{0}'", Entity.SRVNo);
            }
            return objdata.ExecuteNonQuery(sqlstr.ToString());
        }

        /// </summary>
        ///Delete方法 
        /// </summary>
        public int delete()
        {
            return objdata.ExecuteNonQuery("delete from Mstr_Service where SRVNo='" + Entity.SRVNo + "'");
        }

        /// </summary>
        /// valid方法 
        /// </summary>
        public int valid()
        {
            return objdata.ExecuteNonQuery("update Mstr_Service set SRVStatus=" + (Entity.SRVStatus == true ? "1" : "0") + " where SRVNo='" + Entity.SRVNo + "'");
        }

        /// <summary>
        /// 按条件查询，支持分页
        /// </summary>
        /// <param name="SRVNo">收费项目编号</param>
        /// <param name="SRVName">收费项目名称</param>
        /// <param name="SRVTypeNo1">所属服务大类</param>
        /// <param name="SRVTypeNo2">所属服务小类</param>
        /// <param name="SRVSPNo">服务商</param>
        /// <param name="CANo">收费科目</param>
        /// <param name="SRVCalType">收费方式</param>
        /// <returns></returns>
        public System.Collections.ICollection GetListQuery(string SRVNo, string SRVName, string SRVTypeNo1, string SRVTypeNo2, string SRVSPNo, int startRow, int pageSize)
        {
            if (startRow < 0 || pageSize <= 0)
            {
                throw new Exception();
            }

            return GetListHelper(SRVNo, SRVName, SRVTypeNo1, SRVTypeNo2, SRVSPNo, startRow, pageSize);
        }

        /// <summary>
        /// 按条件查询，不支持分页
        /// </summary>
        /// <param name="SRVNo">收费项目编号</param>
        /// <param name="SRVName">收费项目名称</param>
        /// <param name="SRVTypeNo1">所属服务大类</param>
        /// <param name="SRVTypeNo2">所属服务小类</param>
        /// <param name="SRVSPNo">服务商</param>
        /// <param name="CANo">收费科目</param>
        /// <param name="SRVCalType">收费方式</param>
        /// <returns></returns>
        public System.Collections.ICollection GetListQuery(string SRVNo, string SRVName, string SRVTypeNo1, string SRVTypeNo2, string SRVSPNo)
        {
            return GetListHelper(SRVNo, SRVName, SRVTypeNo1, SRVTypeNo2, SRVSPNo, START_ROW_INIT, START_ROW_INIT);
        }

        /// <summary>
        /// 返回集合的大小
        /// </summary>
        /// <param name="SRVNo">收费项目编号</param>
        /// <param name="SRVName">收费项目名称</param>
        /// <param name="SRVTypeNo1">所属服务大类</param>
        /// <param name="SRVTypeNo2">所属服务小类</param>
        /// <param name="SRVSPNo">服务商</param>
        /// <param name="CANo">收费科目</param>
        /// <param name="SRVCalType">收费方式</param>
        /// <returns></returns>
        public int GetListCount(string SRVNo, string SRVName, string SRVTypeNo1, string SRVTypeNo2, string SRVSPNo)
        {
            string wherestr = "";
            if (SRVNo != string.Empty)
            {
                wherestr = wherestr + " and SRVNo like '%" + SRVNo + "%'";
            }
            if (SRVName != string.Empty)
            {
                wherestr = wherestr + " and SRVName like '%" + SRVName + "%'";
            }
            if (SRVTypeNo1 != string.Empty)
            {
                wherestr = wherestr + " and SRVTypeNo1 = '" + SRVTypeNo1 + "'";
            }
            if (SRVTypeNo2 != string.Empty)
            {
                wherestr = wherestr + " and SRVTypeNo2 = '" + SRVTypeNo2 + "'";
            }
            if (SRVSPNo != string.Empty)
            {
                wherestr = wherestr + " and SRVSPNo = '" + SRVSPNo + "'";
            }

            string count = objdata.PopulateDataSet("select count(*) as cnt from Mstr_Service where 1=1 " + wherestr).Tables[0].Rows[0]["cnt"].ToString();
            return int.Parse(count);
        }

        /// <summary>
        /// 按条件查询，返回符合条件的集合
        /// </summary>
        /// <param name="SRVNo">收费项目编号</param>
        /// <param name="SRVName">收费项目名称</param>
        /// <param name="SRVTypeNo1">所属服务大类</param>
        /// <param name="SRVTypeNo2">所属服务小类</param>
        /// <param name="SRVSPNo">服务商</param>
        /// <param name="CANo">收费科目</param>
        /// <param name="SRVCalType">收费方式</param>
        /// <returns></returns>
        private System.Collections.ICollection GetListHelper(string SRVNo, string SRVName, string SRVTypeNo1, string SRVTypeNo2, string SRVSPNo, int startRow, int pageSize)
        {
            string wherestr = "";
            if (SRVNo != string.Empty)
            {
                wherestr = wherestr + " and a.SRVNo like '%" + SRVNo + "%'";
            }
            if (SRVName != string.Empty)
            {
                wherestr = wherestr + " and a.SRVName like '%" + SRVName + "%'";
            }
            if (SRVTypeNo1 != string.Empty)
            {
                wherestr = wherestr + " and a.SRVTypeNo1 = '" + SRVTypeNo1 + "'";
            }
            if (SRVTypeNo2 != string.Empty)
            {
                wherestr = wherestr + " and a.SRVTypeNo2 = '" + SRVTypeNo2 + "'";
            }
            if (SRVSPNo != string.Empty)
            {
                wherestr = wherestr + " and a.SRVSPNo = '" + SRVSPNo + "'";
            }
            System.Collections.IList entitys = null;
            if (startRow > START_ROW_INIT && pageSize > START_ROW_INIT)
            {
                //entitys = Query(objdata.ExecSelect("Mstr_Service a left join Mstr_ServiceProvider b on a.SRVSPNo=b.SPNo left join Mstr_ServiceType c on a.SRVTypeNo1=c.SRVTypeNo " +
                //    "left join Mstr_ServiceType d on a.SRVTypeNo2=d.SRVTypeNo left join Mstr_ChargeAccount e on a.CANo=e.CANo and a.SRVSPNo=e.CASPNo ",
                //    "a.*,b.SPShortName as SRVSPName,c.SRVTypeName as SRVTypeNo1Name,d.SRVTypeName as SRVTypeNo2Name,e.CAName", wherestr, startRow, pageSize, OrderField));
                entitys = Query(objdata.ExecSelect(@"Mstr_Service a 
                                                    left join Mstr_ServiceProvider b on a.SRVSPNo=b.SPNo 
                                                    left join Mstr_ServiceType c on a.SRVTypeNo1=c.SRVTypeNo 
                                                    left join Mstr_ServiceType d on a.SRVTypeNo2=d.SRVTypeNo",
                                                    "a.*,b.SPShortName as SRVSPName,c.SRVTypeName as SRVTypeNo1Name,d.SRVTypeName as SRVTypeNo2Name",
                                                    wherestr, startRow, pageSize, OrderField));
            }
            else
            {
                //entitys = Query(objdata.ExecSelect("Mstr_Service a left join Mstr_ServiceProvider b on a.SRVSPNo=b.SPNo left join Mstr_ServiceType c on a.SRVTypeNo1=c.SRVTypeNo " +
                //    "left join Mstr_ServiceType d on a.SRVTypeNo2=d.SRVTypeNo left join Mstr_ChargeAccount e on a.CANo=e.CANo and a.SRVSPNo=e.CASPNo ",
                //    "a.*,b.SPShortName as SRVSPName,c.SRVTypeName as SRVTypeNo1Name,d.SRVTypeName as SRVTypeNo2Name,e.CAName", wherestr, START_ROW_INIT, START_ROW_INIT, OrderField));
                entitys = Query(objdata.ExecSelect(@"Mstr_Service a 
                                                    left join Mstr_ServiceProvider b on a.SRVSPNo=b.SPNo 
                                                    left join Mstr_ServiceType c on a.SRVTypeNo1=c.SRVTypeNo 
                                                    left join Mstr_ServiceType d on a.SRVTypeNo2=d.SRVTypeNo",
                                                    "a.*,b.SPShortName as SRVSPName,c.SRVTypeName as SRVTypeNo1Name,d.SRVTypeName as SRVTypeNo2Name",
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
                project.Entity.Base.EntityService entity = new project.Entity.Base.EntityService();
                entity.SRVNo = dr["SRVNo"].ToString();
                entity.SRVName = dr["SRVName"].ToString();
                entity.SRVTypeNo1 = dr["SRVTypeNo1"].ToString();
                entity.SRVTypeNo1Name = dr["SRVTypeNo1Name"].ToString();
                entity.SRVTypeNo2 = dr["SRVTypeNo2"].ToString();
                entity.SRVTypeNo2Name = dr["SRVTypeNo2Name"].ToString();
                entity.SRVSPNo = dr["SRVSPNo"].ToString();
                entity.SRVSPName = dr["SRVSPName"].ToString();
                entity.SRVRoundType = dr["SRVRoundType"].ToString();
                entity.SRVTaxRate = ParseDecimalForString(dr["SRVTaxRate"].ToString());
                entity.SRVStatus = bool.Parse(dr["SRVStatus"].ToString());
                entity.SRVRemark = dr["SRVRemark"].ToString();
                entity.SRVFormulaID = dr["SRVFormulaID"].ToString();
                entity.SRVPrice = ParseDecimalForString(dr["SRVPrice"].ToString());
                entity.SRVPriceType = ParseIntForString(dr["SRVPriceType"].ToString());
                entity.SRVCalcCycle = ParseIntForString(dr["SRVCalcCycle"].ToString());
                entity.SRVFinanceFeeCode = dr["SRVFinanceFeeCode"].ToString();
                entity.SRVFinanceFeeName = dr["SRVFinanceFeeName"].ToString();
                entity.SRVFinanceReceivableCode = dr["SRVFinanceReceivableCode"].ToString();

                result.Add(entity);
            }
            return result;
        }
    }
}
