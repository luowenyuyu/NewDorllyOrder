using System;
namespace project.Entity.Sys
{
    /// <summary>ϵͳ�˵�</summary>
    /// <author>tianz</author>
    /// <date>2017-05-19</date>
    [System.Serializable]
    public class EntityMenu
    {
        private string _entityOID;
        private string _menuName;
        private string _menuType;
        private string _menuPath;
        private int _flag;
        private string _parent;
        private string _orderNo;

        /// <summary>ȱʡ���캯��</summary>
        public EntityMenu() {}

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
    }
}
