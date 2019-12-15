using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    public class UserCLS : IComparable
    {
        #region members
        private string _UserName;
        public string UserName 
        {
            get
            { 
                return _UserName;
            }
            set 
            {
                _UserName = value;
            } 
        }

        private string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        private string _JWT = string.Empty;
        public string JWT
        {
            get
            {
                return _JWT;
            }
            set
            {
                _JWT = value;
            }
        }

        private DateTime _JWT_CreateTime;
        public DateTime JWT_CreateTime
        {
            get
            {
                return _JWT_CreateTime;
            }
            set
            {
                _JWT_CreateTime = value;
            }
        }
        #endregion

        #region ctor
        public UserCLS()
        {

        }
        #endregion

        #region methods
        public int CompareTo(object obj)
        {
            int res = 1;
            if (obj == null)
            {
                res = 1;
            }
            else
            {
                UserCLS otherUser = obj as UserCLS;
                if (otherUser != null)
                {
                    if (this._UserName == otherUser._UserName && this._UserName == otherUser._Password)
                    {
                        res = 0;
                    }
                }
            }
            return res;
        }
        #endregion

    }
}
