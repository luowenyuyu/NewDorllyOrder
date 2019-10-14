using System;
namespace project.Entity.Base
{
    /// <summary>费用项目</summary>
    /// <author>tianz</author>
    /// <date>2017-06-22</date>
    [System.Serializable]
    public class EntityService
    {
        private string _SRVNo;
        private string _SRVName;
        private string _SRVTypeNo1;
        private string _SRVTypeNo1Name;
        private string _SRVTypeNo2;
        private string _SRVTypeNo2Name;
        private string _SRVSPNo;
        private string _SRVSPName;
        private string _SRVRoundType;
        private decimal _SRVTaxRate;
        private bool _SRVStatus;
        private string _SRVRemark;

        /// <summary>缺省构造函数</summary>
        public EntityService() { }

        /// <summary>收费项目编号【主键】</summary>
        public string SRVNo
        {
            get { return _SRVNo; }
            set { _SRVNo = value; }
        }

        /// <summary>
        /// 功能描述：收费项目
        /// 长度：80
        /// 不能为空：否
        /// </summary>
        public string SRVName
        {
            get { return _SRVName; }
            set { _SRVName = value; }
        }

        /// <summary>
        /// 功能描述：所属服务大类编号
        /// 长度：30
        /// 不能为空：否
        /// </summary>
        public string SRVTypeNo1
        {
            get { return _SRVTypeNo1; }
            set { _SRVTypeNo1 = value; }
        }

        /// <summary>
        /// 功能描述：所属服务大类名称【非维护字段】
        /// 不能为空：否
        /// </summary>
        public string SRVTypeNo1Name
        {
            get { return _SRVTypeNo1Name; }
            set { _SRVTypeNo1Name = value; }
        }

        /// <summary>
        /// 功能描述：所属服务小类编号
        /// 长度：30
        /// 不能为空：否
        /// </summary>
        public string SRVTypeNo2
        {
            get { return _SRVTypeNo2; }
            set { _SRVTypeNo2 = value; }
        }

        /// <summary>
        /// 功能描述：所属服务小类名称【非维护字段】
        /// 不能为空：否
        /// </summary>
        public string SRVTypeNo2Name
        {
            get { return _SRVTypeNo2Name; }
            set { _SRVTypeNo2Name = value; }
        }

        /// <summary>
        /// 功能描述：所属服务商编号
        /// 长度：30
        /// 不能为空：否
        /// </summary>
        public string SRVSPNo
        {
            get { return _SRVSPNo; }
            set { _SRVSPNo = value; }
        }

        /// <summary>
        /// 功能描述：所属服务商名称【非维护字段】
        /// 长度：50
        /// 不能为空：否
        /// </summary>
        public string SRVSPName
        {
            get { return _SRVSPName; }
            set { _SRVSPName = value; }
        }

        /// <summary>
        /// 功能描述：取整方式
        /// 长度：10
        /// 不能为空：否
        /// </summary>
        public string SRVRoundType
        {
            get { return _SRVRoundType; }
            set { _SRVRoundType = value; }
        }

        /// <summary>
        /// 功能描述：取整方式【非维护字段】
        /// 长度：50
        /// 不能为空：否
        /// </summary>
        public string SRVRoundTypeName
        {
            get
            {
                string _SRVRoundTypeName = "";
                switch (_SRVRoundType)
                {
                    case "round":
                        _SRVRoundTypeName = "四舍五入";
                        break;
                    case "ceiling":
                        _SRVRoundTypeName = "向上取位";
                        break;
                    case "floor":
                        _SRVRoundTypeName = "向下取位";
                        break;
                }
                return _SRVRoundTypeName;
            }
        }

        /// <summary>
        /// 功能描述：税率
        /// </summary>
        public decimal SRVTaxRate
        {
            get { return _SRVTaxRate; }
            set { _SRVTaxRate = value; }
        }

        /// <summary>
        /// 功能描述：状态
        /// 不能为空：否
        /// </summary>
        public bool SRVStatus
        {
            get { return _SRVStatus; }
            set { _SRVStatus = value; }
        }

        /// <summary>
        /// 功能描述：备注
        /// 长度：300
        /// 不能为空：否
        /// </summary>
        public string SRVRemark
        {
            get { return _SRVRemark; }
            set { _SRVRemark = value; }
        }
        /*
         * 新增字段
         */
         /// <summary>
         /// 费用计算公式
         /// </summary>
        public string SRVFormulaID { get; set; }
        /// <summary>
        /// 费用单价
        /// </summary>
        public decimal SRVPrice { get; set; }
        /// <summary>
        /// 费用单价取值方式：1,来源合同;2,来源配置
        /// </summary>
        public int SRVPriceType { get; set; }
        /// <summary>
        /// 财务费用科目编码
        /// </summary>
        public string SRVFinanceFeeCode { get; set; }
        /// <summary>
        /// 财务费用科目名称
        /// </summary>
        public string SRVFinanceFeeName { get; set; }
        /// <summary>
        /// 财务应收科目编码
        /// </summary>
        public string SRVFinanceReceivableCode { get; set; }
        /// <summary>
        /// 计算周期：0:不收费(未参与合同费用)；1:本月收费；2:下月收费
        /// </summary>
        public int SRVCalcCycle { get; set; }

    }
}
