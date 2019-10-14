using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project.Entity.Base
{
    /// <summary>
    /// 公式实体类
    /// </summary>
    public class EntityFormula
    {
        /// <summary>
        /// 字段：公式编号 
        /// 长度：30
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 字段：公式名称 
        /// 长度：80
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 字段：公式描述 
        /// 长度：200
        /// </summary>
        public string Explanation { get; set; }
        /// <summary>
        /// 字段：备注   
        /// 长度：200
        /// </summary>
        public string Remark { get; set; }
    }
}
