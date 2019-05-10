using System;
namespace project.Entity.Sys
{
    /// <summary>�û�Ȩ�޷���</summary>
    /// <author>tz</author>
    /// <date>2016-2-18</date>
    [System.Serializable]
    public class EntityUserInfoRights
    {
        private string _entityOID;
        private string _menuName;
        private string _menuType;
        private string _menuPath;
        private int _flag;
        private string _parent;
        private string _orderNo;
        private bool _right;
        private string _rightCode;
        private string _rightName;
        private string _haveRightName;

        /// <summary>ȱʡ���캯��</summary>
        public EntityUserInfoRights() { }

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
        /// �����������˵�����
        /// ���ȣ�100
        /// ����Ϊ�գ���
        /// </summary>
        public string MenuName
        {
            get { return _menuName; }
            set { _menuName = value; }
        }

        /// <summary>
        /// �����������˵�����
        /// ���ȣ�30
        /// ����Ϊ�գ���
        /// </summary>
        public string MenuType
        {
            get { return _menuType; }
            set { _menuType = value; }
        }

        /// <summary>
        /// �����������˵�·��
        /// ���ȣ�200
        /// ����Ϊ�գ���
        /// </summary>
        public string MenuPath
        {
            get { return _menuPath; }
            set { _menuPath = value; }
        }

        /// <summary>
        /// �����������㼶
        /// ����Ϊ�գ���
        /// </summary>
        public int Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        /// <summary>
        /// �������������ڵ�
        /// ���ȣ�50
        /// ����Ϊ�գ���
        /// </summary>
        public string Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        /// <summary>
        /// ���������������ֶ�
        /// ���ȣ�30
        /// ����Ϊ�գ���
        /// </summary>
        public string OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        /// <summary>
        /// ��������������Ȩ�ޱ���
        /// </summary>
        public string RightCode
        {
            get { return _rightCode; }
            set { _rightCode = value; }
        }

        /// <summary>
        /// ��������������Ȩ������
        /// </summary>
        public string RightName
        {
            get { return _rightName; }
            set { _rightName = value; }
        }

        /// <summary>
        /// ����������ӵ�в���Ȩ������
        /// </summary>
        public string HaveRightCode
        {
            get { return _haveRightName; }
            set { _haveRightName = value; }
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
