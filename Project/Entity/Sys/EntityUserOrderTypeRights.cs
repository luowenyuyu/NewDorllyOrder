using System;
namespace project.Entity.Sys
{
    /// <summary>�û�Ȩ�޷���</summary>
    /// <author>tz</author>
    /// <date>2016-2-18</date>
    [System.Serializable]
    public class EntityUserOrderTypeRights
    {
        private string _entityOID;
        private string _orderType;
        private string _orderTypeName;
        private bool _right;

        /// <summary>ȱʡ���캯��</summary>
        public EntityUserOrderTypeRights() { }

        /// <summary>������ֻ������</summary>
        public System.Guid EntityOID
        {
            get { return new System.Guid(_entityOID); }
        }
        
        /// <summary>
        /// ������������������
        /// ���ȣ�100
        /// ����Ϊ�գ���
        /// </summary>
        public string OrderType
        {
            get { return _orderType; }
            set { _orderType = value; }
        }

        /// <summary>
        /// ����������������������
        /// ���ȣ�30
        /// ����Ϊ�գ���
        /// </summary>
        public string OrderTypeName
        {
            get { return _orderTypeName; }
            set { _orderTypeName = value; }
        }

        /// <summary>
        /// �����������Ƿ���Ȩ��
        /// </summary>
        public bool Right
        {
            get { return _right; }
            set { _right = value; }
        }
    }
}
