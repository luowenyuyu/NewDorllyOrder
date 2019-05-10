using System;
namespace project.Entity.Sys
{
    /// <summary>用户权限</summary>
    /// <author>tianz</author>
    /// <date>2017-05-19</date>
    [System.Serializable]
    public class EntityUserInfoRight
    {
        private string _entityOID;
        private string _menuID;
        private string _userType;
        private string _rightCode;

        /// <summary>缺省构造函数</summary>
        public EntityUserInfoRight() {}

        /// <summary>主键，只读属性</summary>
        public System.Guid EntityOID
        {
            get { return new System.Guid(_entityOID); }
        }

        /// <summary>内部映射主键</summary>
        public string InnerEntityOID
        {
            get { return _entityOID; }
            set { _entityOID = value; }
        }

        /// <summary>
        /// 功能描述：菜单ID
        /// 长度：50
        /// 不能为空：否
        /// </summary>
        public string MenuID
        {
            get { return _menuID; }
            set { _menuID = value; }
        }

        /// <summary>
        /// 功能描述：用户类型
        /// 长度：30
        /// 不能为空：否
        /// </summary>
        public string UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        /// <summary>
        /// 功能描述：用户权限编码
        /// 长度：300
        /// 不能为空：否
        /// </summary>
        public string RightCode
        {
            get { return _rightCode; }
            set { _rightCode = value; }
        }
    }
}
