using System;
namespace project.Entity.Sys
{
    /// <summary>�û���������Ȩ��</summary>
    /// <author>tianz</author>
    /// <date>2017-05-19</date>
    [System.Serializable]
    public class EntityUserOrderTypeRight
    {
        private string _entityOID;
        private string _orderType;
        private string _userType;

        /// <summary>ȱʡ���캯��</summary>
        public EntityUserOrderTypeRight() { }

        /// <summary>������ֻ������</summary>
        public System.Guid EntityOID
        {
            get { return new System.Guid(_entityOID); }
        }

        /// <summary>�ڲ�ӳ������</summary>
        public string InnerEntityOID
        {
            get { return _entityOID; }
            set { _entityOID = value; }
        }

        /// <summary>
        /// ������������������
        /// ���ȣ�50
        /// ����Ϊ�գ���
        /// </summary>
        public string OrderType
        {
            get { return _orderType; }
            set { _orderType = value; }
        }

        /// <summary>
        /// �����������û�����
        /// ���ȣ�30
        /// ����Ϊ�գ���
        /// </summary>
        public string UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }
    }
}
