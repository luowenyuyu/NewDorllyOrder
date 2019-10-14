﻿using Newtonsoft.Json;
using project.Presentation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace project.Business.Op
{
    /// <summary>
    /// 合同管理
    /// </summary>
    /// <author>tianz</author>
    /// <date>2017-06-22</date>
    public sealed class BusinessContract : project.Business.AbstractPmBusiness
    {
        private project.Entity.Op.EntityContract _entity = new project.Entity.Op.EntityContract();
        public string OrderField = "c.CustName";//"ContractCreateDate desc";
        Data objdata = new Data();

        /// <summary>
        /// 缺省构造函数
        /// </summary>
        public BusinessContract() { }

        /// <summary>
        /// 带参数的构函数
        /// </summary>
        /// <param name="entity">实体类</param>
        public BusinessContract(project.Entity.Op.EntityContract entity)
        {
            this._entity = entity;
        }

        /// <summary>
        /// 与实体类(EntityContract)关联
        /// </summary>
        public project.Entity.Op.EntityContract Entity
        {
            get { return _entity as project.Entity.Op.EntityContract; }
        }

        /// </summary>
        /// load方法
        /// </summary>
        public void load(string id)
        {
            DataRow dr = objdata.PopulateDataSet("select a.*,b.ContractTypeName,c.CustName,d.SPName " +
                "from Op_Contract a " +
                "left join Mstr_ContractType b on b.ContractTypeNo=a.ContractType " +
                "left join Mstr_Customer c on c.CustNo=a.ContractCustNo " +
                "left join Mstr_ServiceProvider d on d.SPNo=a.ContractSPNo " +
                "where a.RowPointer='" + id + "'").Tables[0].Rows[0];
            _entity.RowPointer = dr["RowPointer"].ToString();
            _entity.ContractNo = dr["ContractNo"].ToString();
            _entity.ContractType = dr["ContractType"].ToString();
            _entity.ContractTypeName = dr["ContractTypeName"].ToString();
            _entity.ContractSPNo = dr["ContractSPNo"].ToString();
            _entity.ContractSPName = dr["SPName"].ToString();
            _entity.ContractCustNo = dr["ContractCustNo"].ToString();
            _entity.ContractCustName = dr["CustName"].ToString();
            _entity.ContractNoManual = dr["ContractNoManual"].ToString();
            _entity.ContractHandler = dr["ContractHandler"].ToString();
            _entity.ContractSignedDate = ParseDateTimeForString(dr["ContractSignedDate"].ToString());
            _entity.ContractStartDate = ParseDateTimeForString(dr["ContractStartDate"].ToString());
            _entity.ContractEndDate = ParseDateTimeForString(dr["ContractEndDate"].ToString());
            _entity.EntryDate = ParseDateTimeForString(dr["EntryDate"].ToString());
            _entity.FeeStartDate = ParseDateTimeForString(dr["FeeStartDate"].ToString());
            _entity.ReduceStartDate1 = ParseDateTimeForString(dr["ReduceStartDate1"].ToString());
            _entity.ReduceEndDate1 = ParseDateTimeForString(dr["ReduceEndDate1"].ToString());
            _entity.ReduceStartDate2 = ParseDateTimeForString(dr["ReduceStartDate2"].ToString());
            _entity.ReduceEndDate2 = ParseDateTimeForString(dr["ReduceEndDate2"].ToString());
            _entity.ReduceStartDate3 = ParseDateTimeForString(dr["ReduceStartDate3"].ToString());
            _entity.ReduceEndDate3 = ParseDateTimeForString(dr["ReduceEndDate3"].ToString());
            _entity.ReduceStartDate4 = ParseDateTimeForString(dr["ReduceStartDate4"].ToString());
            _entity.ReduceEndDate4 = ParseDateTimeForString(dr["ReduceEndDate4"].ToString());
            _entity.ContractLatefeeRate = ParseDecimalForString(dr["ContractLatefeeRate"].ToString());
            _entity.RMRentalDeposit = ParseDecimalForString(dr["RMRentalDeposit"].ToString());
            _entity.RMUtilityDeposit = ParseDecimalForString(dr["RMUtilityDeposit"].ToString());
            _entity.PropertyFeeStartDate = ParseDateTimeForString(dr["PropertyFeeStartDate"].ToString());
            _entity.PropertyFeeReduceStartDate = ParseDateTimeForString(dr["PropertyFeeReduceStartDate"].ToString());
            _entity.PropertyFeeReduceEndDate = ParseDateTimeForString(dr["PropertyFeeReduceEndDate"].ToString());
            _entity.WaterUnitPrice = ParseDecimalForString(dr["WaterUnitPrice"].ToString());
            _entity.ElecticityUintPrice = ParseDecimalForString(dr["ElecticityUintPrice"].ToString());
            _entity.AirconUnitPrice = ParseDecimalForString(dr["AirconUnitPrice"].ToString());
            _entity.PropertyUnitPrice = ParseDecimalForString(dr["PropertyUnitPrice"].ToString());
            _entity.SharedWaterFee = ParseDecimalForString(dr["SharedWaterFee"].ToString());
            _entity.SharedElectricyFee = ParseDecimalForString(dr["SharedElectricyFee"].ToString());
            _entity.WPRentalDeposit = ParseDecimalForString(dr["WPRentalDeposit"].ToString());
            _entity.WPUtilityDeposit = ParseDecimalForString(dr["WPUtilityDeposit"].ToString());
            _entity.WPQTY = ParseIntForString(dr["WPQTY"].ToString());
            _entity.WPElectricyLimit = ParseDecimalForString(dr["WPElectricyLimit"].ToString());
            _entity.WPOverElectricyPrice = ParseDecimalForString(dr["WPOverElectricyPrice"].ToString());
            _entity.BBQTY = ParseIntForString(dr["BBQTY"].ToString());
            _entity.BBAmount = ParseDecimalForString(dr["BBAmount"].ToString());
            _entity.IncreaseType = dr["IncreaseType"].ToString();
            _entity.IncreaseStartDate1 = ParseDateTimeForString(dr["IncreaseStartDate1"].ToString());
            _entity.IncreaseRate1 = ParseDecimalForString(dr["IncreaseRate1"].ToString());
            _entity.IncreaseStartDate2 = ParseDateTimeForString(dr["IncreaseStartDate2"].ToString());
            _entity.IncreaseRate2 = ParseDecimalForString(dr["IncreaseRate2"].ToString());
            _entity.IncreaseStartDate3 = ParseDateTimeForString(dr["IncreaseStartDate3"].ToString());
            _entity.IncreaseRate3 = ParseDecimalForString(dr["IncreaseRate3"].ToString());
            _entity.IncreaseStartDate4 = ParseDateTimeForString(dr["IncreaseStartDate4"].ToString());
            _entity.IncreaseRate4 = ParseDecimalForString(dr["IncreaseRate4"].ToString());
            _entity.OffLeaseStatus = dr["OffLeaseStatus"].ToString();
            _entity.Remark = dr["Remark"].ToString();
            _entity.OffLeaseApplyDate = ParseDateTimeForString(dr["OffLeaseApplyDate"].ToString());
            _entity.OffLeaseScheduleDate = ParseDateTimeForString(dr["OffLeaseScheduleDate"].ToString());
            _entity.OffLeaseActulDate = ParseDateTimeForString(dr["OffLeaseActulDate"].ToString());
            _entity.OffLeaseReason = dr["OffLeaseReason"].ToString();
            _entity.ContractCreator = dr["ContractCreator"].ToString();
            _entity.ContractCreateDate = ParseDateTimeForString(dr["ContractCreateDate"].ToString());
            _entity.ContractLastReviser = dr["ContractLastReviser"].ToString();
            _entity.ContractLastReviser = dr["ContractLastReviser"].ToString();
            _entity.ContractLastReviseDate = ParseDateTimeForString(dr["ContractLastReviseDate"].ToString());
            _entity.ContractAttachment = dr["ContractAttachment"].ToString();
            _entity.ContractStatus = dr["ContractStatus"].ToString();
            _entity.ContractAuditor = dr["ContractAuditor"].ToString();
            _entity.ContractAuditDate = ParseDateTimeForString(dr["ContractAuditDate"].ToString());
            _entity.ContractFinanceAuditor = dr["ContractFinanceAuditor"].ToString();
            _entity.ContractFinanceAuditDate = ParseDateTimeForString(dr["ContractFinanceAuditDate"].ToString());
        }

        /// </summary>
        /// Save方法
        /// </summary>
        public int Save(string type)
        {
            string sqlstr = "";
            if (type == "insert")
                sqlstr = "insert into Op_Contract(RowPointer,ContractNo,ContractType,ContractSPNo,ContractCustNo,ContractNoManual,ContractHandler," +
                        "ContractSignedDate,ContractStartDate,ContractEndDate,EntryDate,FeeStartDate," +
                        "ReduceStartDate1,ReduceEndDate1,ReduceStartDate2,ReduceEndDate2,ReduceStartDate3,ReduceEndDate3,ReduceStartDate4,ReduceEndDate4," +
                        "ContractLatefeeRate,RMRentalDeposit,RMUtilityDeposit,PropertyFeeStartDate,PropertyFeeReduceStartDate,PropertyFeeReduceEndDate," +
                        "WaterUnitPrice,ElecticityUintPrice,AirconUnitPrice,PropertyUnitPrice,SharedWaterFee,SharedElectricyFee,WPRentalDeposit," +
                        "WPUtilityDeposit,WPQTY,WPElectricyLimit,WPOverElectricyPrice,BBQTY,BBAmount,Remark,IncreaseType,IncreaseStartDate1,IncreaseRate1," +
                        "IncreaseStartDate2,IncreaseRate2,IncreaseStartDate3," +
                        "IncreaseRate3,IncreaseStartDate4,IncreaseRate4,OffLeaseStatus,OffLeaseApplyDate,OffLeaseScheduleDate,OffLeaseActulDate," +
                        "OffLeaseReason,ContractCreator,ContractCreateDate,ContractLastReviser,ContractLastReviseDate,ContractAttachment," +
                        "ContractStatus,ContractAuditor,ContractAuditDate,ContractFinanceAuditor,ContractFinanceAuditDate)" +
                    "values('" + Entity.RowPointer + "'," + "'" + Entity.ContractNo + "'" + "," + "'" + Entity.ContractType + "'" + "," + "'" + Entity.ContractSPNo + "'" + "," +
                    "'" + Entity.ContractCustNo + "'" + "," + "'" + Entity.ContractNoManual + "'" + "," + "'" + Entity.ContractHandler + "'" + "," +

                    "'" + Entity.ContractSignedDate.ToString("yyyy-MM-dd") + "'" + "," + "'" + Entity.ContractStartDate.ToString("yyyy-MM-dd") + "'" + "," +
                    "'" + Entity.ContractEndDate.ToString("yyyy-MM-dd") + "'" + "," + "'" + Entity.EntryDate.ToString("yyyy-MM-dd") + "'" + "," +
                    "'" + Entity.FeeStartDate.ToString("yyyy-MM-dd") + "'" + "," +
                    "'" + Entity.ReduceStartDate1.ToString("yyyy-MM-dd") + "'" + "," + "'" + Entity.ReduceEndDate1.ToString("yyyy-MM-dd") + "'" + "," +
                    "'" + Entity.ReduceStartDate2.ToString("yyyy-MM-dd") + "'" + "," + "'" + Entity.ReduceEndDate2.ToString("yyyy-MM-dd") + "'" + "," +
                    "'" + Entity.ReduceStartDate3.ToString("yyyy-MM-dd") + "'" + "," + "'" + Entity.ReduceEndDate3.ToString("yyyy-MM-dd") + "'" + "," +
                    "'" + Entity.ReduceStartDate4.ToString("yyyy-MM-dd") + "'" + "," + "'" + Entity.ReduceEndDate4.ToString("yyyy-MM-dd") + "'" + "," +

                    Entity.ContractLatefeeRate + "," +
                    Entity.RMRentalDeposit + "," + Entity.RMUtilityDeposit + "," + "'" + Entity.PropertyFeeStartDate.ToString("yyyy-MM-dd") + "'" + "," +
                    "'" + Entity.PropertyFeeReduceStartDate.ToString("yyyy-MM-dd") + "'" + "," + "'" + Entity.PropertyFeeReduceEndDate.ToString("yyyy-MM-dd") + "'" + "," +

                    Entity.WaterUnitPrice + "," + Entity.ElecticityUintPrice + "," + Entity.AirconUnitPrice + "," + Entity.PropertyUnitPrice + "," +
                    Entity.SharedWaterFee + "," + Entity.SharedElectricyFee + "," + Entity.WPRentalDeposit + "," +

                    Entity.WPUtilityDeposit + "," + Entity.WPQTY + "," + Entity.WPElectricyLimit + "," + Entity.WPOverElectricyPrice + "," + Entity.BBQTY + "," +
                    Entity.BBAmount + "," + "'" + Entity.Remark + "'" + "," + "'" + Entity.IncreaseType + "'" + "," +
                    "'" + Entity.IncreaseStartDate1.ToString("yyyy-MM-dd") + "'" + "," + Entity.IncreaseRate1 + "," +

                    "'" + Entity.IncreaseStartDate2.ToString("yyyy-MM-dd") + "'" + "," + Entity.IncreaseRate2 + "," +
                    "'" + Entity.IncreaseStartDate3.ToString("yyyy-MM-dd") + "'" + "," +

                    Entity.IncreaseRate3 + "," + "'" + Entity.IncreaseStartDate4.ToString("yyyy-MM-dd") + "'" + "," + Entity.IncreaseRate4 + "," +
                    "'1'" + ",null,null,null,''," +
                    "'" + Entity.ContractCreator + "'" + "," + "'" + Entity.ContractCreateDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," +
                    "'" + Entity.ContractLastReviser + "'" + "," + "'" + Entity.ContractLastReviseDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," +
                    "'" + Entity.ContractAttachment + "'" + "," +

                    "'1','',null,'',null)";
            else
                sqlstr = "update Op_Contract" +
                    " set ContractType=" + "'" + Entity.ContractType + "'" + "," + "ContractSPNo=" + "'" + Entity.ContractSPNo + "'" + "," +
                    "ContractCustNo=" + "'" + Entity.ContractCustNo + "'" + "," + "ContractNoManual=" + "'" + Entity.ContractNoManual + "'" + "," +
                    "ContractHandler=" + "'" + Entity.ContractHandler + "'" + "," + "ContractSignedDate=" + "'" + Entity.ContractSignedDate.ToString("yyyy-MM-dd") + "'" + "," +
                    "ContractStartDate=" + "'" + Entity.ContractStartDate.ToString("yyyy-MM-dd") + "'" + "," +
                    "ContractEndDate=" + "'" + Entity.ContractEndDate.ToString("yyyy-MM-dd") + "'" + "," +
                    "EntryDate=" + "'" + Entity.EntryDate.ToString("yyyy-MM-dd") + "'" + "," +
                    "FeeStartDate=" + "'" + Entity.FeeStartDate.ToString("yyyy-MM-dd") + "'" + "," +
                    "ReduceStartDate1=" + "'" + Entity.ReduceStartDate1.ToString("yyyy-MM-dd") + "'" + "," +
                    "ReduceEndDate1=" + "'" + Entity.ReduceEndDate1.ToString("yyyy-MM-dd") + "'" + "," +
                    "ReduceStartDate2=" + "'" + Entity.ReduceStartDate2.ToString("yyyy-MM-dd") + "'" + "," +
                    "ReduceEndDate2=" + "'" + Entity.ReduceEndDate2.ToString("yyyy-MM-dd") + "'" + "," +
                    "ReduceStartDate3=" + "'" + Entity.ReduceStartDate3.ToString("yyyy-MM-dd") + "'" + "," +
                    "ReduceEndDate3=" + "'" + Entity.ReduceEndDate3.ToString("yyyy-MM-dd") + "'" + "," +
                    "ReduceStartDate4=" + "'" + Entity.ReduceStartDate4.ToString("yyyy-MM-dd") + "'" + "," +
                    "ReduceEndDate4=" + "'" + Entity.ReduceEndDate4.ToString("yyyy-MM-dd") + "'" + "," +
                    "ContractLatefeeRate=" + Entity.ContractLatefeeRate + "," + "RMRentalDeposit=" + Entity.RMRentalDeposit + "," +
                    "RMUtilityDeposit=" + Entity.RMUtilityDeposit + "," +
                    "PropertyFeeStartDate=" + "'" + Entity.PropertyFeeStartDate.ToString("yyyy-MM-dd") + "'" + "," +
                    "PropertyFeeReduceStartDate=" + "'" + Entity.PropertyFeeReduceStartDate.ToString("yyyy-MM-dd") + "'" + "," +
                    "PropertyFeeReduceEndDate=" + "'" + Entity.PropertyFeeReduceEndDate.ToString("yyyy-MM-dd") + "'" + "," +
                    "WaterUnitPrice=" + Entity.WaterUnitPrice + "," + "ElecticityUintPrice=" + Entity.ElecticityUintPrice + "," +
                    "AirconUnitPrice=" + Entity.AirconUnitPrice + "," + "PropertyUnitPrice=" + Entity.PropertyUnitPrice + "," +
                    "SharedWaterFee=" + Entity.SharedWaterFee + "," +
                    "SharedElectricyFee=" + Entity.SharedElectricyFee + "," + "WPRentalDeposit=" + Entity.WPRentalDeposit + "," +
                    "WPUtilityDeposit=" + Entity.WPUtilityDeposit + "," + "WPQTY=" + Entity.WPQTY + "," + "WPElectricyLimit=" + Entity.WPElectricyLimit + "," +
                    "WPOverElectricyPrice=" + Entity.WPOverElectricyPrice + "," + "BBQTY=" + Entity.BBQTY + "," +
                    "BBAmount=" + Entity.BBAmount + "," + "Remark=" + "'" + Entity.Remark + "'" + "," + "IncreaseType=" + "'" + Entity.IncreaseType + "'" + "," +
                    "IncreaseStartDate1=" + "'" + Entity.IncreaseStartDate1.ToString("yyyy-MM-dd") + "'" + "," + "IncreaseRate1=" + Entity.IncreaseRate1 + "," +
                    "IncreaseStartDate2=" + "'" + Entity.IncreaseStartDate2.ToString("yyyy-MM-dd") + "'" + "," + "IncreaseRate2=" + Entity.IncreaseRate2 + "," +
                    "IncreaseStartDate3=" + "'" + Entity.IncreaseStartDate3.ToString("yyyy-MM-dd") + "'" + "," + "IncreaseRate3=" + Entity.IncreaseRate3 + "," +
                    "IncreaseStartDate4=" + "'" + Entity.IncreaseStartDate4.ToString("yyyy-MM-dd") + "'" + "," + "IncreaseRate4=" + Entity.IncreaseRate4 + "," +
                    "ContractLastReviser=" + "'" + Entity.ContractLastReviser + "'" + "," +
                    "ContractLastReviseDate=" + "'" + Entity.ContractLastReviseDate.ToString("yyy-MM-dd HH:mm:ss") + "'" + "," +
                    "ContractAttachment=" + "'" + Entity.ContractAttachment + "'" +
                    " where RowPointer='" + Entity.RowPointer + "'";
            return objdata.ExecuteNonQuery(sqlstr);
        }

        /// </summary>
        ///Delete方法 
        /// </summary>
        public int delete()
        {
            objdata.ExecuteNonQuery("delete from Op_ContractChangeRecord where RefRP='" + Entity.RowPointer + "'");
            objdata.ExecuteNonQuery("delete from Op_ContractRMRentalDetail where RefRP='" + Entity.RowPointer + "'");
            objdata.ExecuteNonQuery("delete from Op_ContractWPRentalDetail where RefRP='" + Entity.RowPointer + "'");
            objdata.ExecuteNonQuery("delete from Op_ContractBBRentalDetail where RefRP='" + Entity.RowPointer + "'");
            objdata.ExecuteNonQuery("delete from Op_ContractPropertyFee where RefRP='" + Entity.RowPointer + "'");
            objdata.ExecuteNonQuery("delete from Op_ContractRMRentList where RefRP='" + Entity.RowPointer + "'");

            return objdata.ExecuteNonQuery("delete from Op_Contract where RowPointer='" + Entity.RowPointer + "'");
        }

        /// <summary>
        /// 合同审核
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="contractID">合同主键</param>
        /// <param name="userName">用户名称</param>
        /// <returns>如果返回为空则成功，不为空则为失败</returns>
        public string ContractReview(string procedureName, string contractID, string userName)
        {

            string InfoMsg = "";
            SqlConnection con = null;
            SqlCommand command = null;
            try
            {
                con = Data.Conn();
                command = new SqlCommand(procedureName, con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ContractID", SqlDbType.NVarChar, 36).Value = contractID;
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 30).Value = userName;
                command.Parameters.Add("@Msg", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                con.Open();
                command.ExecuteNonQuery();
                InfoMsg = command.Parameters["@Msg"].Value.ToString();

            }
            catch (Exception ex)
            {
                InfoMsg = ex.ToString();
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (con != null)
                    con.Dispose();
            }
            return InfoMsg;
        }
        /// <summary>
        /// 合同退租
        /// </summary>
        /// <param name="contractID">合同主键</param>
        /// <param name="userName">用户名称</param>
        /// <param name="exitDate">退租时间,例:2019-09-01</param>
        /// <returns></returns>
        public string ContractExit(string contractID, string userName, string exitDate)
        {
            string InfoMsg = "";
            SqlConnection con = null;
            SqlCommand command = null;
            try
            {
                con = Data.Conn();
                command = new SqlCommand("Contract_Exit", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ContractID", SqlDbType.NVarChar, 36).Value = contractID;
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 30).Value = userName;
                command.Parameters.Add("@EndDate", SqlDbType.NVarChar, 10).Value = exitDate;
                command.Parameters.Add("@Msg", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                con.Open();
                command.ExecuteNonQuery();
                InfoMsg = command.Parameters["@Msg"].Value.ToString();

            }
            catch (Exception ex)
            {
                InfoMsg = ex.ToString();
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (con != null)
                    con.Dispose();
            }
            return InfoMsg;
        }

        /// <summary>
        /// 合同取消审核
        /// </summary>
        /// <param name="contractID">合同主键</param>
        /// <param name="userName">用户名称</param>
        /// <returns></returns>
        public string ContractCancel(string contractID, string userName)
        {
            string InfoMsg = "";
            SqlConnection con = null;
            SqlCommand command = null;
            try
            {
                con = Data.Conn();
                command = new SqlCommand("Contract_Cancel", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ContractID", SqlDbType.NVarChar, 36).Value = contractID;
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 30).Value = userName;
                command.Parameters.Add("@Msg", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                con.Open();
                command.ExecuteNonQuery();
                InfoMsg = command.Parameters["@Msg"].Value.ToString();

            }
            catch (Exception ex)
            {
                InfoMsg = ex.ToString();
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (con != null)
                    con.Dispose();
            }
            return InfoMsg;
        }

        #region 合同审核部分，目前已作废

        /// </summary>
        /// Audit方法（房屋租赁合同） 
        /// </summary>
        public string approve_RM(string UserName)
        {

            string InfoMsg = "";
            SqlConnection con = null;
            SqlCommand command = null;
            try
            {
                con = Data.Conn();
                command = new SqlCommand("ApproveContract_RM", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ContractID", SqlDbType.NVarChar, 36).Value = Entity.RowPointer;
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 30).Value = UserName;
                command.Parameters.Add("@InfoMsg", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                con.Open();
                command.ExecuteNonQuery();
                InfoMsg = command.Parameters["@InfoMsg"].Value.ToString();

            }
            catch (Exception ex)
            {
                InfoMsg = ex.ToString();
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (con != null)
                    con.Dispose();
            }
            return InfoMsg;
        }

        /// </summary>
        /// Audit方法（工位租赁合同） 
        /// </summary>
        public string approve_WP(string UserName)
        {

            string InfoMsg = "";
            SqlConnection con = null;
            SqlCommand command = null;
            try
            {
                con = Data.Conn();
                command = new SqlCommand("ApproveContract_WP", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ContractID", SqlDbType.NVarChar, 36).Value = Entity.RowPointer;
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 30).Value = UserName;
                command.Parameters.Add("@InfoMsg", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                con.Open();
                command.ExecuteNonQuery();
                InfoMsg = command.Parameters["@InfoMsg"].Value.ToString();

            }
            catch (Exception ex)
            {
                InfoMsg = ex.ToString();
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (con != null)
                    con.Dispose();
            }
            return InfoMsg;
        }

        /// </summary>
        /// Audit方法（物业合同） 
        /// </summary>
        public string approve_PT(string UserName)
        {

            string InfoMsg = "";
            SqlConnection con = null;
            SqlCommand command = null;
            try
            {
                con = Data.Conn();
                command = new SqlCommand("ApproveContract_PT", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ContractID", SqlDbType.NVarChar, 36).Value = Entity.RowPointer;
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 30).Value = UserName;
                command.Parameters.Add("@InfoMsg", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                con.Open();
                command.ExecuteNonQuery();
                InfoMsg = command.Parameters["@InfoMsg"].Value.ToString();

            }
            catch (Exception ex)
            {
                InfoMsg = ex.ToString();
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (con != null)
                    con.Dispose();
            }
            return InfoMsg;
        }

        /// </summary>
        /// Audit方法（物业合同） 
        /// </summary>
        public string approve_WPPT(string UserName)
        {

            string InfoMsg = "";
            SqlConnection con = null;
            SqlCommand command = null;
            try
            {
                con = Data.Conn();
                command = new SqlCommand("ApproveContract_WPPT", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ContractID", SqlDbType.NVarChar, 36).Value = Entity.RowPointer;
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 30).Value = UserName;
                command.Parameters.Add("@InfoMsg", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                con.Open();
                command.ExecuteNonQuery();
                InfoMsg = command.Parameters["@InfoMsg"].Value.ToString();

            }
            catch (Exception ex)
            {
                InfoMsg = ex.ToString();
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (con != null)
                    con.Dispose();
            }
            return InfoMsg;
        }

        /// </summary>
        /// Audit方法（广告位合同） 
        /// </summary>
        public string approve_BB(string UserName)
        {

            string InfoMsg = "";
            SqlConnection con = null;
            SqlCommand command = null;
            try
            {
                con = Data.Conn();
                command = new SqlCommand("ApproveContract_BB", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ContractID", SqlDbType.NVarChar, 36).Value = Entity.RowPointer;
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 30).Value = UserName;
                command.Parameters.Add("@InfoMsg", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                con.Open();
                command.ExecuteNonQuery();
                InfoMsg = command.Parameters["@InfoMsg"].Value.ToString();

            }
            catch (Exception ex)
            {
                InfoMsg = ex.ToString();
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (con != null)
                    con.Dispose();
            }
            return InfoMsg;
        }


        #endregion

        /// </summary>
        /// invalid方法 
        /// </summary>
        public int invalid()
        {
            return objdata.ExecuteNonQuery("update Op_Contract set ContractStatus = '" + Entity.ContractStatus + "'," +
                "ContractAuditor = '" + Entity.ContractAuditor + "',ContractAuditDate = '" + Entity.ContractAuditDate.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                "where RowPointer='" + Entity.RowPointer + "'");
        }



        /// </summary>
        /// refund方法 
        /// </summary>
        public int refund()
        {
            return objdata.ExecuteNonQuery("update Op_Contract " +
                "set OffLeaseStatus = '" + Entity.OffLeaseStatus + "'," +
                "OffLeaseApplyDate = '" + Entity.OffLeaseApplyDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," +
                "OffLeaseScheduleDate = '" + Entity.OffLeaseScheduleDate.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," +
                "OffLeaseReason = '" + Entity.OffLeaseReason + "'" +
                " where RowPointer='" + Entity.RowPointer + "'");
        }

        #region 资源同步

        /// <summary>
        /// 资源同步方法
        /// </summary>
        /// <param name="resType">要同步的资源类型：rm,房屋;wp,工位;ad,广告位</param>
        /// <param name="rentType">租赁类型：1，租赁；2，物业</param>
        /// <param name="model">操作类型：add,添加租赁合同；out,正常退租合同；del，异常删除合同</param>
        /// <param name="userName">操作的用户名称</param>
        /// <param name="endTime">实际退租时间，如果不是正常退租，即model不等于"out",该参数即为null</param>
        /// <returns></returns>
        public string SyncResource(string resType, int rentType, string model, string userName, DateTime? endTime)
        {
            string result = string.Empty;
            if (ConfigurationManager.AppSettings["IsPutZY"].ToString().Equals("Y"))
            {
                try
                {
                    ResourceService.ResourceService srv = new ResourceService.ResourceService
                    {
                        Timeout = 5000,
                        Url = ConfigurationManager.AppSettings["ResourceUrl"].ToString()
                    };
                    string items = string.Empty;
                    string sql = string.Empty;
                    DataTable dt = null;
                    Business.Base.BusinessCustomer cust = new Business.Base.BusinessCustomer();
                    cust.load(Entity.ContractCustNo);
                    if (resType.Equals("rm"))
                    {
                        //房屋
                        sql = string.Format(@"SELECT RMID AS ResourceID,RMArea AS Quantity FROM Op_ContractRMRentalDetail 
                                             WHERE RefRP='{0}' GROUP BY RMID,RMArea", Entity.RowPointer);
                    }
                    else if (resType.Equals("wp"))
                    {
                        //工位
                        sql = string.Format(@"SELECT WPNo AS ResourceID,0 AS Quantity FROM Op_ContractWPRentalDetail 
                                             WHERE RefRP='{0}' GROUP BY WPNo", Entity.RowPointer);
                    }
                    else
                    {
                        //广告位
                        sql = string.Format(@"SELECT BBNo AS ResourceID,0 AS Quantity  FROM Op_ContractBBRentalDetail 
                                             WHERE RefRP='{0}' GROUP BY BBNo", Entity.RowPointer);
                    }
                    dt = objdata.PopulateDataSet(sql).Tables[0];
                    var rsList = new List<SycnResourceStatus>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        SycnResourceStatus rs = new SycnResourceStatus();
                        rs.SysID = 1; //1.订单系统                           
                        rs.BusinessID = Entity.RowPointer;
                        rs.BusinessNo = Entity.ContractNo;
                        rs.RentBeginTime = Entity.FeeStartDate;
                        rs.CustLongName = cust.Entity.CustName;
                        rs.CustShortName = cust.Entity.CustShortName;
                        rs.CustTel = cust.Entity.CustTel;
                        rs.RentType = 1;
                        rs.UpdateTime = DateTime.Now;
                        rs.UpdateUser = userName;
                        //变化参数
                        rs.ResourceID = dr["ResourceID"].ToString();
                        rs.BusinessType = rentType;//1租赁，2物业
                        rs.RentEndTime = endTime == null ? Entity.ContractEndDate : endTime;
                        rs.RentArea = ParseDecimalForString(dr["Quantity"].ToString());
                        rs.Status = model.Equals("add") ? 1 : 2;
                        rsList.Add(rs);
                        //items += (items == "" ? "" : ",") + JsonConvert.SerializeObject(rs);
                    }
                    if (model.Equals("add"))
                        result = srv.LeaseIn(JsonConvert.SerializeObject(rsList));//租赁
                    else if (model.Equals("del"))
                        result = srv.LeaseDel(JsonConvert.SerializeObject(rsList));//取消租赁
                    else if (model.Equals("out"))
                        result = srv.LeaseOut(JsonConvert.SerializeObject(rsList));//退租

                }
                catch (Exception ex)
                {
                    result = ex.ToString();
                }
            }
            else result = "已配置不同步";
            return result;
        }

        #endregion

        #region 管家同步

        /// <summary>
        /// 同步到管家
        /// </summary>
        /// <returns></returns>
        public string SyncButlerForCustStatus()
        {
            string result = string.Empty;
            if (ConfigurationManager.AppSettings["IsPutGJ"].ToString().Equals("Y"))
            {
                try
                {
                    string status = string.Empty;
                    string date = string.Empty;
                    ButlerSrv.AppService appService = new ButlerSrv.AppService
                    {
                        Timeout = 5000,
                        Url = ConfigurationManager.AppSettings["ButlerUrl"].ToString()
                    };
                    if (objdata.PopulateDataSet(string.Format(@"SELECT 1 FROM Op_Contract WHERE ContractCustNo={0} 
                        AND ContractStatus>=2", Entity.ContractCustNo)).Tables[0].Rows.Count > 0)
                    {
                        //存在过合同
                        if (objdata.PopulateDataSet(string.Format(@"SELECT 1 FROM Op_Contract WHERE ContractCustNo={0} 
                        AND ContractStatus='2'", Entity.ContractCustNo)).Tables[0].Rows.Count > 0)
                        {
                            //存在履约合同
                            status = "1";
                        }
                        else
                        {
                            //不存在履约合同
                            status = "2";
                            date = objdata.PopulateDataSet(string.Format(@"SELECT CONVERT(CHAR(10),MAX(OffLeaseActulDate),121) AS EndDate 
                            FROM Op_Contract WHERE ContractCustNo={0} AND ContractStatus='3'", Entity.ContractCustNo)).Tables[0].Rows[0][0].ToString();
                        }

                    }
                    else
                    {
                        //不曾存在过合同
                        status = "3";
                    }
                    appService.UpdateCustomer(Entity.ContractCustNo, status, date);
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }
            else result = "已配置不同步";
            return result;
        }
        #endregion

        #region 合同数据查询模块

        /// <summary>
        /// 按条件查询，支持分页
        /// </summary>
        /// <param name="ContractNo">合同编号</param>
        /// <param name="ContractNoManual">手工合同编号</param>
        /// <param name="ContractType">合同类型</param>
        /// <param name="ContractSPNo">服务商</param>
        /// <param name="ContractCustName">客户名称</param>
        /// <param name="MinContractSignedDate">起始签订日期</param>
        /// <param name="MaxContractSignedDate">截止签订日期</param>
        /// <param name="MinContractEndDate">起始合同到期日期</param>
        /// <param name="MaxContractEndDate">截止合同到期日期</param>
        /// <param name="ContractStatus">合同状态</param>
        /// <param name="OffLeaseStatus">退租状态</param>
        /// <param name="MinOffLeaseActulDate">起始退租日期</param>
        /// <param name="MaxOffLeaseActulDate">截止退租日期</param>
        /// <param name="startRow">页码</param>
        /// <param name="pageSize">每页行数</param>
        /// <returns></returns>
        public System.Collections.ICollection GetListQuery(string ContractNo, string ContractNoManual, string ContractType, string ContractSPNo, string ContractCustName,
            DateTime MinContractSignedDate, DateTime MaxContractSignedDate, DateTime MinContractEndDate, DateTime MaxContractEndDate, string ContractStatus, string OffLeaseStatus,
            DateTime MinOffLeaseActulDate, DateTime MaxOffLeaseActulDate,
            int startRow, int pageSize)
        {
            if (startRow < 0 || pageSize <= 0)
            {
                throw new Exception();
            }

            return GetListHelper(ContractNo, ContractNoManual, ContractType, ContractSPNo, ContractCustName,
                                MinContractSignedDate, MaxContractSignedDate, MinContractEndDate, MaxContractEndDate, ContractStatus, OffLeaseStatus,
                                MinOffLeaseActulDate, MaxOffLeaseActulDate, startRow, pageSize);
        }

        /// <summary>
        /// 按条件查询，不支持分页
        /// </summary>
        /// <param name="ContractNo">合同编号</param>
        /// <param name="ContractNoManual">手工合同编号</param>
        /// <param name="ContractType">合同类型</param>
        /// <param name="ContractSPNo">服务商</param>
        /// <param name="ContractCustName">客户名称</param>
        /// <param name="MinContractSignedDate">起始签订日期</param>
        /// <param name="MaxContractSignedDate">截止签订日期</param>
        /// <param name="MinContractEndDate">起始合同到期日期</param>
        /// <param name="MaxContractEndDate">截止合同到期日期</param>
        /// <param name="ContractStatus">合同状态</param>
        /// <param name="OffLeaseStatus">退租状态</param>
        /// <param name="MinOffLeaseActulDate">起始退租日期</param>
        /// <param name="MaxOffLeaseActulDate">截止退租日期</param>
        /// <returns></returns>
        public System.Collections.ICollection GetListQuery(string ContractNo, string ContractNoManual, string ContractType, string ContractSPNo, string ContractCustName,
            DateTime MinContractSignedDate, DateTime MaxContractSignedDate, DateTime MinContractEndDate, DateTime MaxContractEndDate, string ContractStatus, string OffLeaseStatus,
            DateTime MinOffLeaseActulDate, DateTime MaxOffLeaseActulDate)
        {
            return GetListHelper(ContractNo, ContractNoManual, ContractType, ContractSPNo, ContractCustName,
                                MinContractSignedDate, MaxContractSignedDate, MinContractEndDate, MaxContractEndDate, ContractStatus, OffLeaseStatus,
                                MinOffLeaseActulDate, MaxOffLeaseActulDate, START_ROW_INIT, START_ROW_INIT);
        }

        /// <summary>
        /// 返回集合的大小
        /// </summary>
        /// <param name="ContractNo">合同编号</param>
        /// <param name="ContractNoManual">手工合同编号</param>
        /// <param name="ContractType">合同类型</param>
        /// <param name="ContractSPNo">服务商</param>
        /// <param name="ContractCustName">客户名称</param>
        /// <param name="MinContractSignedDate">起始签订日期</param>
        /// <param name="MaxContractSignedDate">截止签订日期</param>
        /// <param name="MinContractEndDate">起始合同到期日期</param>
        /// <param name="MaxContractEndDate">截止合同到期日期</param>
        /// <param name="ContractStatus">合同状态</param>
        /// <param name="OffLeaseStatus">退租状态</param>
        /// <param name="MinOffLeaseActulDate">起始退租日期</param>
        /// <param name="MaxOffLeaseActulDate">截止退租日期</param>
        /// <returns></returns>
        public int GetListCount(string ContractNo, string ContractNoManual, string ContractType, string ContractSPNo, string ContractCustName,
            DateTime MinContractSignedDate, DateTime MaxContractSignedDate, DateTime MinContractEndDate, DateTime MaxContractEndDate, string ContractStatus, string OffLeaseStatus,
            DateTime MinOffLeaseActulDate, DateTime MaxOffLeaseActulDate)
        {
            string wherestr = "";
            if (ContractNo != string.Empty)
            {
                wherestr = wherestr + " and a.ContractNo like '%" + ContractNo + "%'";
            }
            if (ContractNoManual != string.Empty)
            {
                wherestr = wherestr + " and a.ContractNoManual like '%" + ContractNoManual + "%'";
            }
            if (ContractType != string.Empty)
            {
                wherestr = wherestr + " and a.ContractType = '" + ContractType + "'";
            }
            if (ContractSPNo != string.Empty)
            {
                wherestr = wherestr + " and a.ContractSPNo = '" + ContractSPNo + "'";
            }
            if (ContractStatus != string.Empty)
            {
                wherestr = wherestr + " and a.ContractStatus = '" + ContractStatus + "'";
            }
            if (OffLeaseStatus != string.Empty)
            {
                wherestr = wherestr + " and a.OffLeaseStatus = '" + OffLeaseStatus + "'";
            }
            if (ContractCustName != string.Empty)
            {
                wherestr = wherestr + " and c.CustName like '%" + ContractCustName + "%'";
            }
            if (MinContractSignedDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractSignedDate,121) >= '" + MinContractSignedDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxContractSignedDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractSignedDate,121) <= '" + MaxContractSignedDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MinContractEndDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractEndDate,121) >= '" + MinContractEndDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxContractEndDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractEndDate,121) <= '" + MaxContractEndDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MinOffLeaseActulDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.OffLeaseActulDate,121) >= '" + MinOffLeaseActulDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxOffLeaseActulDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.OffLeaseActulDate,121) <= '" + MaxOffLeaseActulDate.ToString("yyyy-MM-dd") + "'";
            }

            string count = objdata.PopulateDataSet("select count(*) as cnt from Op_Contract a left join Mstr_ContractType b on b.ContractTypeNo=a.ContractType " +
                    "left join Mstr_Customer c on c.CustNo=a.ContractCustNo " +
                    "left join Mstr_ServiceProvider d on d.SPNo=a.ContractSPNo where 1=1 " + wherestr).Tables[0].Rows[0]["cnt"].ToString();
            return int.Parse(count);
        }

        /// <summary>
        /// 按条件查询，返回符合条件的集合
        /// </summary>
        /// <param name="ContractNo">合同编号</param>
        /// <param name="ContractNoManual">手工合同编号</param>
        /// <param name="ContractType">合同类型</param>
        /// <param name="ContractSPNo">服务商</param>
        /// <param name="ContractCustName">客户名称</param>
        /// <param name="MinContractSignedDate">起始签订日期</param>
        /// <param name="MaxContractSignedDate">截止签订日期</param>
        /// <param name="MinContractEndDate">起始合同到期日期</param>
        /// <param name="MaxContractEndDate">截止合同到期日期</param>
        /// <param name="ContractStatus">合同状态</param>
        /// <param name="OffLeaseStatus">退租状态</param>
        /// <param name="MinOffLeaseActulDate">起始退租日期</param>
        /// <param name="MaxOffLeaseActulDate">截止退租日期</param>
        /// <returns></returns>
        private System.Collections.ICollection GetListHelper(string ContractNo, string ContractNoManual, string ContractType, string ContractSPNo, string ContractCustName,
            DateTime MinContractSignedDate, DateTime MaxContractSignedDate, DateTime MinContractEndDate, DateTime MaxContractEndDate, string ContractStatus, string OffLeaseStatus,
            DateTime MinOffLeaseActulDate, DateTime MaxOffLeaseActulDate,
            int startRow, int pageSize)
        {
            string wherestr = "";
            if (ContractNo != string.Empty)
            {
                wherestr = wherestr + " and a.ContractNo like '%" + ContractNo + "%'";
            }
            if (ContractNoManual != string.Empty)
            {
                wherestr = wherestr + " and a.ContractNoManual like '%" + ContractNoManual + "%'";
            }
            if (ContractType != string.Empty)
            {
                wherestr = wherestr + " and a.ContractType = '" + ContractType + "'";
            }
            if (ContractSPNo != string.Empty)
            {
                wherestr = wherestr + " and a.ContractSPNo = '" + ContractSPNo + "'";
            }
            if (ContractStatus != string.Empty)
            {
                wherestr = wherestr + " and a.ContractStatus = '" + ContractStatus + "'";
            }
            if (OffLeaseStatus != string.Empty)
            {
                wherestr = wherestr + " and a.OffLeaseStatus = '" + OffLeaseStatus + "'";
            }
            if (ContractCustName != string.Empty)
            {
                wherestr = wherestr + " and c.CustName like '%" + ContractCustName + "%'";
            }
            if (MinContractSignedDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractSignedDate,121) >= '" + MinContractSignedDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxContractSignedDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractSignedDate,121) <= '" + MaxContractSignedDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MinContractEndDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractEndDate,121) >= '" + MinContractEndDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxContractEndDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractEndDate,121) <= '" + MaxContractEndDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MinOffLeaseActulDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.OffLeaseActulDate,121) >= '" + MinOffLeaseActulDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxOffLeaseActulDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.OffLeaseActulDate,121) <= '" + MaxOffLeaseActulDate.ToString("yyyy-MM-dd") + "'";
            }

            System.Collections.IList entitys = null;
            if (startRow > START_ROW_INIT && pageSize > START_ROW_INIT)
            {
                entitys = Query(objdata.ExecSelect("Op_Contract a left join Mstr_ContractType b on b.ContractTypeNo=a.ContractType " +
                    "left join Mstr_Customer c on c.CustNo=a.ContractCustNo " +
                    "left join Mstr_ServiceProvider d on d.SPNo=a.ContractSPNo",
                    "a.*,b.ContractTypeName,c.CustName,d.SPName", wherestr, startRow, pageSize, OrderField));
            }
            else
            {
                entitys = Query(objdata.ExecSelect("Op_Contract a left join Mstr_ContractType b on b.ContractTypeNo=a.ContractType " +
                    "left join Mstr_Customer c on c.CustNo=a.ContractCustNo " +
                    "left join Mstr_ServiceProvider d on d.SPNo=a.ContractSPNo",
                    "a.*,b.ContractTypeName,c.CustName,d.SPName", wherestr, START_ROW_INIT, START_ROW_INIT, OrderField));
            }
            return entitys;
        }



        /// <summary>
        /// 返回集合的大小 - 退租
        /// </summary>
        /// <param name="ContractNo">合同编号</param>
        /// <param name="ContractNoManual">手工合同编号</param>
        /// <param name="ContractType">合同类型</param>
        /// <param name="ContractSPNo">服务商</param>
        /// <param name="ContractCustName">客户名称</param>
        /// <param name="MinContractSignedDate">起始签订日期</param>
        /// <param name="MaxContractSignedDate">截止签订日期</param>
        /// <param name="MinContractEndDate">起始合同到期日期</param>
        /// <param name="MaxContractEndDate">截止合同到期日期</param>
        /// <param name="ContractStatus">合同状态</param>
        /// <param name="OffLeaseStatus">退租状态</param>
        /// <param name="MinOffLeaseActulDate">起始退租日期</param>
        /// <param name="MaxOffLeaseActulDate">截止退租日期</param>
        /// <returns></returns>
        public int GetRefundListCount(string ContractNo, string ContractNoManual, string ContractType, string ContractSPNo, string ContractCustName,
            DateTime MinContractSignedDate, DateTime MaxContractSignedDate, DateTime MinContractEndDate, DateTime MaxContractEndDate, string OffLeaseStatus,
            DateTime MinOffLeaseActulDate, DateTime MaxOffLeaseActulDate)
        {
            string wherestr = "";
            if (ContractNo != string.Empty)
            {
                wherestr = wherestr + " and a.ContractNo like '%" + ContractNo + "%'";
            }
            if (ContractNoManual != string.Empty)
            {
                wherestr = wherestr + " and a.ContractNoManual like '%" + ContractNoManual + "%'";
            }
            if (ContractType != string.Empty)
            {
                wherestr = wherestr + " and a.ContractType = '" + ContractType + "'";
            }
            if (ContractSPNo != string.Empty)
            {
                wherestr = wherestr + " and a.ContractSPNo = '" + ContractSPNo + "'";
            }
            if (OffLeaseStatus != string.Empty)
            {
                wherestr = wherestr + " and a.OffLeaseStatus = '" + OffLeaseStatus + "'";
            }
            if (ContractCustName != string.Empty)
            {
                wherestr = wherestr + " and c.CustName like '%" + ContractCustName + "%'";
            }
            if (MinContractSignedDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractSignedDate,121) >= '" + MinContractSignedDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxContractSignedDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractSignedDate,121) <= '" + MaxContractSignedDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MinContractEndDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractEndDate,121) >= '" + MinContractEndDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxContractEndDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractEndDate,121) <= '" + MaxContractEndDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MinOffLeaseActulDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.OffLeaseActulDate,121) >= '" + MinOffLeaseActulDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxOffLeaseActulDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.OffLeaseActulDate,121) <= '" + MaxOffLeaseActulDate.ToString("yyyy-MM-dd") + "'";
            }
            wherestr = wherestr + " and a.ContractStatus IN ('2','3')";
            wherestr = wherestr + " and a.ContractType IN ('01','02','04','12')";

            string count = objdata.PopulateDataSet("select count(*) as cnt from Op_Contract a left join Mstr_ContractType b on b.ContractTypeNo=a.ContractType " +
                    "left join Mstr_Customer c on c.CustNo=a.ContractCustNo " +
                    "left join Mstr_ServiceProvider d on d.SPNo=a.ContractSPNo where 1=1 " + wherestr).Tables[0].Rows[0]["cnt"].ToString();
            return int.Parse(count);
        }

        /// <summary>
        /// 按条件查询，返回符合条件的集合 - 退租
        /// </summary>
        /// <param name="ContractNo">合同编号</param>
        /// <param name="ContractNoManual">手工合同编号</param>
        /// <param name="ContractType">合同类型</param>
        /// <param name="ContractSPNo">服务商</param>
        /// <param name="ContractCustName">客户名称</param>
        /// <param name="MinContractSignedDate">起始签订日期</param>
        /// <param name="MaxContractSignedDate">截止签订日期</param>
        /// <param name="MinContractEndDate">起始合同到期日期</param>
        /// <param name="MaxContractEndDate">截止合同到期日期</param>
        /// <param name="ContractStatus">合同状态</param>
        /// <param name="OffLeaseStatus">退租状态</param>
        /// <param name="MinOffLeaseActulDate">起始退租日期</param>
        /// <param name="MaxOffLeaseActulDate">截止退租日期</param>
        /// <returns></returns>
        public System.Collections.ICollection GetRefundListQuery(string ContractNo, string ContractNoManual, string ContractType, string ContractSPNo, string ContractCustName,
            DateTime MinContractSignedDate, DateTime MaxContractSignedDate, DateTime MinContractEndDate, DateTime MaxContractEndDate, string OffLeaseStatus,
            DateTime MinOffLeaseActulDate, DateTime MaxOffLeaseActulDate,
            int startRow, int pageSize)
        {
            string wherestr = "";
            if (ContractNo != string.Empty)
            {
                wherestr = wherestr + " and a.ContractNo like '%" + ContractNo + "%'";
            }
            if (ContractNoManual != string.Empty)
            {
                wherestr = wherestr + " and a.ContractNoManual like '%" + ContractNoManual + "%'";
            }
            if (ContractType != string.Empty)
            {
                wherestr = wherestr + " and a.ContractType = '" + ContractType + "'";
            }
            if (ContractSPNo != string.Empty)
            {
                wherestr = wherestr + " and a.ContractSPNo = '" + ContractSPNo + "'";
            }
            if (OffLeaseStatus != string.Empty)
            {
                wherestr = wherestr + " and a.OffLeaseStatus = '" + OffLeaseStatus + "'";
            }
            if (ContractCustName != string.Empty)
            {
                wherestr = wherestr + " and c.CustName like '%" + ContractCustName + "%'";
            }
            if (MinContractSignedDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractSignedDate,121) >= '" + MinContractSignedDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxContractSignedDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractSignedDate,121) <= '" + MaxContractSignedDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MinContractEndDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractEndDate,121) >= '" + MinContractEndDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxContractEndDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractEndDate,121) <= '" + MaxContractEndDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MinOffLeaseActulDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.OffLeaseActulDate,121) >= '" + MinOffLeaseActulDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxOffLeaseActulDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.OffLeaseActulDate,121) <= '" + MaxOffLeaseActulDate.ToString("yyyy-MM-dd") + "'";
            }
            wherestr = wherestr + " and a.ContractStatus IN ('2','3')";
            wherestr = wherestr + " and a.ContractType IN ('01','02','04','12')";

            System.Collections.IList entitys = null;
            if (startRow > START_ROW_INIT && pageSize > START_ROW_INIT)
            {
                entitys = Query(objdata.ExecSelect("Op_Contract a left join Mstr_ContractType b on b.ContractTypeNo=a.ContractType " +
                    "left join Mstr_Customer c on c.CustNo=a.ContractCustNo " +
                    "left join Mstr_ServiceProvider d on d.SPNo=a.ContractSPNo",
                    "a.*,b.ContractTypeName,c.CustName,d.SPName", wherestr, startRow, pageSize, OrderField));
            }
            else
            {
                entitys = Query(objdata.ExecSelect("Op_Contract a left join Mstr_ContractType b on b.ContractTypeNo=a.ContractType " +
                    "left join Mstr_Customer c on c.CustNo=a.ContractCustNo " +
                    "left join Mstr_ServiceProvider d on d.SPNo=a.ContractSPNo",
                    "a.*,b.ContractTypeName,c.CustName,d.SPName", wherestr, START_ROW_INIT, START_ROW_INIT, OrderField));
            }
            return entitys;
        }


        /// <summary>
        /// 返回集合的大小 - 变更
        /// </summary>
        /// <param name="ContractNo">合同编号</param>
        /// <param name="ContractNoManual">手工合同编号</param>
        /// <param name="ContractType">合同类型</param>
        /// <param name="ContractSPNo">服务商</param>
        /// <param name="ContractCustName">客户名称</param>
        /// <param name="MinContractSignedDate">起始签订日期</param>
        /// <param name="MaxContractSignedDate">截止签订日期</param>
        /// <param name="MinContractEndDate">起始合同到期日期</param>
        /// <param name="MaxContractEndDate">截止合同到期日期</param>
        /// <param name="ContractStatus">合同状态</param>
        /// <param name="OffLeaseStatus">退租状态</param>
        /// <returns></returns>
        public int GetChangeRecordListCount(string ContractNo, string ContractNoManual, string ContractType, string ContractSPNo, string ContractCustName,
            DateTime MinContractSignedDate, DateTime MaxContractSignedDate, DateTime MinContractEndDate, DateTime MaxContractEndDate, string OffLeaseStatus)
        {
            string wherestr = "";
            if (ContractNo != string.Empty)
            {
                wherestr = wherestr + " and a.ContractNo like '%" + ContractNo + "%'";
            }
            if (ContractNoManual != string.Empty)
            {
                wherestr = wherestr + " and a.ContractNoManual like '%" + ContractNoManual + "%'";
            }
            if (ContractType != string.Empty)
            {
                wherestr = wherestr + " and a.ContractType = '" + ContractType + "'";
            }
            if (ContractSPNo != string.Empty)
            {
                wherestr = wherestr + " and a.ContractSPNo = '" + ContractSPNo + "'";
            }
            if (OffLeaseStatus != string.Empty)
            {
                wherestr = wherestr + " and a.OffLeaseStatus = '" + OffLeaseStatus + "'";
            }
            if (ContractCustName != string.Empty)
            {
                wherestr = wherestr + " and c.CustName like '%" + ContractCustName + "%'";
            }
            if (MinContractSignedDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractSignedDate,121) >= '" + MinContractSignedDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxContractSignedDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractSignedDate,121) <= '" + MaxContractSignedDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MinContractEndDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractEndDate,121) >= '" + MinContractEndDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxContractEndDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractEndDate,121) <= '" + MaxContractEndDate.ToString("yyyy-MM-dd") + "'";
            }
            wherestr = wherestr + " and a.ContractStatus IN ('2')";
            wherestr = wherestr + " and a.ContractType IN ('04')";

            string count = objdata.PopulateDataSet("select count(*) as cnt from Op_Contract a left join Mstr_ContractType b on b.ContractTypeNo=a.ContractType " +
                    "left join Mstr_Customer c on c.CustNo=a.ContractCustNo " +
                    "left join Mstr_ServiceProvider d on d.SPNo=a.ContractSPNo where 1=1 " + wherestr).Tables[0].Rows[0]["cnt"].ToString();
            return int.Parse(count);
        }

        /// <summary>
        /// 按条件查询，返回符合条件的集合 - 变更
        /// </summary>
        /// <param name="ContractNo">合同编号</param>
        /// <param name="ContractNoManual">手工合同编号</param>
        /// <param name="ContractType">合同类型</param>
        /// <param name="ContractSPNo">服务商</param>
        /// <param name="ContractCustName">客户名称</param>
        /// <param name="MinContractSignedDate">起始签订日期</param>
        /// <param name="MaxContractSignedDate">截止签订日期</param>
        /// <param name="MinContractEndDate">起始合同到期日期</param>
        /// <param name="MaxContractEndDate">截止合同到期日期</param>
        /// <param name="ContractStatus">合同状态</param>
        /// <param name="OffLeaseStatus">退租状态</param>
        /// <returns></returns>
        public System.Collections.ICollection GetChangeRecordListQuery(string ContractNo, string ContractNoManual, string ContractType, string ContractSPNo, string ContractCustName,
            DateTime MinContractSignedDate, DateTime MaxContractSignedDate, DateTime MinContractEndDate, DateTime MaxContractEndDate, string OffLeaseStatus,
            int startRow, int pageSize)
        {
            string wherestr = "";
            if (ContractNo != string.Empty)
            {
                wherestr = wherestr + " and a.ContractNo like '%" + ContractNo + "%'";
            }
            if (ContractNoManual != string.Empty)
            {
                wherestr = wherestr + " and a.ContractNoManual like '%" + ContractNoManual + "%'";
            }
            if (ContractType != string.Empty)
            {
                wherestr = wherestr + " and a.ContractType = '" + ContractType + "'";
            }
            if (ContractSPNo != string.Empty)
            {
                wherestr = wherestr + " and a.ContractSPNo = '" + ContractSPNo + "'";
            }
            if (OffLeaseStatus != string.Empty)
            {
                wherestr = wherestr + " and a.OffLeaseStatus = '" + OffLeaseStatus + "'";
            }
            if (ContractCustName != string.Empty)
            {
                wherestr = wherestr + " and c.CustName like '%" + ContractCustName + "%'";
            }
            if (MinContractSignedDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractSignedDate,121) >= '" + MinContractSignedDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxContractSignedDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractSignedDate,121) <= '" + MaxContractSignedDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MinContractEndDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractEndDate,121) >= '" + MinContractEndDate.ToString("yyyy-MM-dd") + "'";
            }
            if (MaxContractEndDate != default(DateTime))
            {
                wherestr = wherestr + " and convert(nvarchar(10),a.ContractEndDate,121) <= '" + MaxContractEndDate.ToString("yyyy-MM-dd") + "'";
            }
            wherestr = wherestr + " and a.ContractStatus = '2'";
            wherestr = wherestr + " and a.ContractType = '04'";

            System.Collections.IList entitys = null;
            if (startRow > START_ROW_INIT && pageSize > START_ROW_INIT)
            {
                entitys = Query(objdata.ExecSelect("Op_Contract a left join Mstr_ContractType b on b.ContractTypeNo=a.ContractType " +
                    "left join Mstr_Customer c on c.CustNo=a.ContractCustNo " +
                    "left join Mstr_ServiceProvider d on d.SPNo=a.ContractSPNo",
                    "a.*,b.ContractTypeName,c.CustName,d.SPName", wherestr, startRow, pageSize, OrderField));
            }
            else
            {
                entitys = Query(objdata.ExecSelect("Op_Contract a left join Mstr_ContractType b on b.ContractTypeNo=a.ContractType " +
                    "left join Mstr_Customer c on c.CustNo=a.ContractCustNo " +
                    "left join Mstr_ServiceProvider d on d.SPNo=a.ContractSPNo",
                    "a.*,b.ContractTypeName,c.CustName,d.SPName", wherestr, START_ROW_INIT, START_ROW_INIT, OrderField));
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
                project.Entity.Op.EntityContract entity = new project.Entity.Op.EntityContract();
                entity.RowPointer = dr["RowPointer"].ToString();
                entity.ContractNo = dr["ContractNo"].ToString();
                entity.ContractType = dr["ContractType"].ToString();
                entity.ContractTypeName = dr["ContractTypeName"].ToString();
                entity.ContractSPNo = dr["ContractSPNo"].ToString();
                entity.ContractSPName = dr["SPName"].ToString();
                entity.ContractCustNo = dr["ContractCustNo"].ToString();
                entity.ContractCustName = dr["CustName"].ToString();
                entity.ContractNoManual = dr["ContractNoManual"].ToString();
                entity.ContractHandler = dr["ContractHandler"].ToString();
                entity.ContractSignedDate = ParseDateTimeForString(dr["ContractSignedDate"].ToString());
                entity.ContractStartDate = ParseDateTimeForString(dr["ContractStartDate"].ToString());
                entity.ContractEndDate = ParseDateTimeForString(dr["ContractEndDate"].ToString());
                entity.EntryDate = ParseDateTimeForString(dr["EntryDate"].ToString());
                entity.FeeStartDate = ParseDateTimeForString(dr["FeeStartDate"].ToString());
                entity.ReduceStartDate1 = ParseDateTimeForString(dr["ReduceStartDate1"].ToString());
                entity.ReduceEndDate1 = ParseDateTimeForString(dr["ReduceEndDate1"].ToString());
                entity.ReduceStartDate2 = ParseDateTimeForString(dr["ReduceStartDate2"].ToString());
                entity.ReduceEndDate2 = ParseDateTimeForString(dr["ReduceEndDate2"].ToString());
                entity.ReduceStartDate3 = ParseDateTimeForString(dr["ReduceStartDate3"].ToString());
                entity.ReduceEndDate3 = ParseDateTimeForString(dr["ReduceEndDate3"].ToString());
                entity.ReduceStartDate4 = ParseDateTimeForString(dr["ReduceStartDate4"].ToString());
                entity.ReduceEndDate4 = ParseDateTimeForString(dr["ReduceEndDate4"].ToString());
                entity.ContractLatefeeRate = ParseDecimalForString(dr["ContractLatefeeRate"].ToString());
                entity.RMRentalDeposit = ParseDecimalForString(dr["RMRentalDeposit"].ToString());
                entity.RMUtilityDeposit = ParseDecimalForString(dr["RMUtilityDeposit"].ToString());
                entity.PropertyFeeStartDate = ParseDateTimeForString(dr["PropertyFeeStartDate"].ToString());
                entity.PropertyFeeReduceStartDate = ParseDateTimeForString(dr["PropertyFeeReduceStartDate"].ToString());
                entity.PropertyFeeReduceEndDate = ParseDateTimeForString(dr["PropertyFeeReduceEndDate"].ToString());
                entity.WaterUnitPrice = ParseDecimalForString(dr["WaterUnitPrice"].ToString());
                entity.ElecticityUintPrice = ParseDecimalForString(dr["ElecticityUintPrice"].ToString());
                entity.AirconUnitPrice = ParseDecimalForString(dr["AirconUnitPrice"].ToString());
                entity.PropertyUnitPrice = ParseDecimalForString(dr["PropertyUnitPrice"].ToString());
                entity.SharedWaterFee = ParseDecimalForString(dr["SharedWaterFee"].ToString());
                entity.SharedElectricyFee = ParseDecimalForString(dr["SharedElectricyFee"].ToString());
                entity.WPRentalDeposit = ParseDecimalForString(dr["WPRentalDeposit"].ToString());
                entity.WPUtilityDeposit = ParseDecimalForString(dr["WPUtilityDeposit"].ToString());
                entity.WPQTY = ParseIntForString(dr["WPQTY"].ToString());
                entity.WPElectricyLimit = ParseDecimalForString(dr["WPElectricyLimit"].ToString());
                entity.WPOverElectricyPrice = ParseDecimalForString(dr["WPOverElectricyPrice"].ToString());
                entity.BBQTY = ParseIntForString(dr["BBQTY"].ToString());
                entity.BBAmount = ParseDecimalForString(dr["BBAmount"].ToString());
                entity.IncreaseType = dr["IncreaseType"].ToString();
                entity.IncreaseStartDate1 = ParseDateTimeForString(dr["IncreaseStartDate1"].ToString());
                entity.IncreaseRate1 = ParseDecimalForString(dr["IncreaseRate1"].ToString());
                entity.IncreaseStartDate2 = ParseDateTimeForString(dr["IncreaseStartDate2"].ToString());
                entity.IncreaseRate2 = ParseDecimalForString(dr["IncreaseRate2"].ToString());
                entity.IncreaseStartDate3 = ParseDateTimeForString(dr["IncreaseStartDate3"].ToString());
                entity.IncreaseRate3 = ParseDecimalForString(dr["IncreaseRate3"].ToString());
                entity.IncreaseStartDate4 = ParseDateTimeForString(dr["IncreaseStartDate4"].ToString());
                entity.IncreaseRate4 = ParseDecimalForString(dr["IncreaseRate4"].ToString());
                entity.OffLeaseStatus = dr["OffLeaseStatus"].ToString();
                entity.Remark = dr["Remark"].ToString();
                entity.OffLeaseApplyDate = ParseDateTimeForString(dr["OffLeaseApplyDate"].ToString());
                entity.OffLeaseScheduleDate = ParseDateTimeForString(dr["OffLeaseScheduleDate"].ToString());
                entity.OffLeaseActulDate = ParseDateTimeForString(dr["OffLeaseActulDate"].ToString());
                entity.OffLeaseReason = dr["OffLeaseReason"].ToString();
                entity.ContractCreator = dr["ContractCreator"].ToString();
                entity.ContractCreateDate = ParseDateTimeForString(dr["ContractCreateDate"].ToString());
                entity.ContractLastReviser = dr["ContractLastReviser"].ToString();
                entity.ContractLastReviser = dr["ContractLastReviser"].ToString();
                entity.ContractLastReviseDate = ParseDateTimeForString(dr["ContractLastReviseDate"].ToString());
                entity.ContractAttachment = dr["ContractAttachment"].ToString();
                entity.ContractStatus = dr["ContractStatus"].ToString();
                entity.ContractAuditor = dr["ContractAuditor"].ToString();
                entity.ContractAuditDate = ParseDateTimeForString(dr["ContractAuditDate"].ToString());
                entity.ContractFinanceAuditor = dr["ContractFinanceAuditor"].ToString();
                entity.ContractFinanceAuditDate = ParseDateTimeForString(dr["ContractFinanceAuditDate"].ToString());
                result.Add(entity);
            }
            return result;
        }

        #endregion
    }
}
