using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using System.Web.UI.WebControls.WebParts;

namespace project.Business
{
    /// <summary>
    /// ����ҳ��Ļ��࣬������BasePage
    /// </summary>
    /// <author>��׳</author>
    /// <date>2011-03-22</date>
    public class AbstractPmBusiness : System.Web.UI.Page
    {
        protected static readonly int START_ROW_INIT = -1; 


        /// <summary>
        /// ҳ���ʼ������
        /// </summary>
        /// <param name="sender">Դ����</param>
        /// <param name="e">����</param>
        protected virtual void Page_Load(object sender, EventArgs e)
        {
        }
        protected string[] ParsestringForUploadXml(System.Xml.XmlDocument doc)
        {
            if (doc == null)
                return new string[] { "", "" };

            return new string[] { doc.SelectSingleNode("/file/label").InnerText, doc.SelectSingleNode("/file/value").InnerText };
        }
        protected System.Xml.XmlDocument ParseUploadXmlForstrings(string label, string value)
        {
            System.Xml.XmlDocument result = new System.Xml.XmlDocument();
            result.LoadXml("<file><value>" + value + "</value><label>" + label + "</label></file>");

            return result;
        }
        protected System.DateTime ParseDateTimeForString(string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return DateTime.MinValue.AddYears(1900);
            }

            return DateTime.Parse(val);
        }
        protected System.DateTime ParseSearchDateForString(string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return default(DateTime);
            }

            return DateTime.Parse(val);
        }
        protected string ParseStringForDate(System.DateTime? date)
        {
            if (null == date)
                return "";
            if (DateTime.MinValue.AddYears(1900).Equals(date))
                return "";

            return ((System.DateTime)date).ToString("yyyy-MM-dd", null);
        }
        protected string ParseStringForDateTime(System.DateTime? date)
        {
            if (null == date)
                return "";
            if (DateTime.MinValue.AddYears(1900).Equals(date))
                return "";


            return ((System.DateTime)date).ToString("yyyy-MM-dd HH:mm:ss", null);
        }
        protected decimal ParseDecimalForString(string val)
        {
            if (string.IsNullOrEmpty(val))
                return 0;

            return decimal.Parse(val);
        }
        protected int ParseIntForString(string val)
        {
            if (string.IsNullOrEmpty(val))
                return 0;

            return Int32.Parse(val);
        }  
    }

}
