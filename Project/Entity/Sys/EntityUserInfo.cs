using System;
namespace project.Entity.Sys
{
    /// <summary>�û���Ϣ</summary>
    /// <author>tianz</author>
    /// <date>2017-05-19</date>
    [System.Serializable]
    public class EntityUserInfo
    {
        private string _entityOID;
        private string _userType;
        private string _userNo;
        private string _userName;
        private string _password;
        private string _tel;
        private string _email;
        private string _addr;
        private System.DateTime _regDate;
        private bool _valid;

        /// <summary>ȱʡ���캯��</summary>
        public EntityUserInfo() {}
        
        /// <summary>�ڲ�ӳ������</summary>
        public string InnerEntityOID
        {
            get { return _entityOID; }
            set { _entityOID = value; }
        }

        /// <summary>
        /// �����������û�����
        /// ���ȣ�20
        /// ����Ϊ�գ���
        /// </summary>
        public string UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        /// <summary>
        /// �����������û��������
        /// ���ȣ�100
        /// ����Ϊ�գ���
        /// </summary>
        public string UserTypeName
        {
            get
            {
                if (_userType != "" && _userType != null)
                {
                    try
                    {
                        Business.Sys.BusinessUserType usertype = new Business.Sys.BusinessUserType();
                        usertype.load(_userType);
                        return usertype.Entity.UserTypeName;
                    }
                    catch { return ""; }
                }
                return "";
            }
        }

        /// <summary>
        /// �����������û����
        /// ���ȣ�30
        /// ����Ϊ�գ���
        /// </summary>
        public string UserNo
        {
            get { return _userNo; }
            set { _userNo = value; }
        }

        /// <summary>
        /// �����������û�����
        /// ���ȣ�50
        /// ����Ϊ�գ���
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// ��������������
        /// ���ȣ�50
        /// ����Ϊ�գ���
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// �����������绰
        /// ���ȣ�50
        /// ����Ϊ�գ���
        /// </summary>
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        /// <summary>
        /// ��������������
        /// ���ȣ�50
        /// ����Ϊ�գ���
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// ������������ַ
        /// ���ȣ�200
        /// ����Ϊ�գ���
        /// </summary>
        public string Addr
        {
            get { return _addr; }
            set { _addr = value; }
        }

        /// <summary>
        /// ����������ע������
        /// ����Ϊ�գ���
        /// </summary>
        public System.DateTime RegDate
        {
            get { return _regDate; }
            set { _regDate = value; }
        }

        /// <summary>
        /// �����������Ƿ���Ч
        /// ����Ϊ�գ���
        /// </summary>
        public bool Valid
        {
            get { return _valid; }
            set { _valid = value; }
        }

    }
}