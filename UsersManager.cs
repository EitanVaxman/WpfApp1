using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WpfApp1
{
    public class UsersManager
    {
        #region members
        private Dictionary<string, UserCLS> _Users = new Dictionary<string, UserCLS>();//the user name is the Key
        public int JWT_TimeExpiration { get; internal set; }
        private Timer _JWT_TimeExpirationTimer;
        private TimeSpan span;
        #endregion

        #region ctor
        public UsersManager()
        {

        }
        #endregion

        #region methods
        public int AddUser(UserCLS user)
        {
            if (_Users.Count == 0)
            {
                _JWT_TimeExpirationTimer = new Timer(new TimerCallback(CheckJWTAgeing),null,1000, 1000);
            }

            if (!_Users.ContainsKey(user.UserName))
            {
                _Users.Add(user.UserName, user);
            }
            return 200;
        }

        private void CheckJWTAgeing(object state)
        {
            if (_Users.Count > 0)
            {
                List<UserCLS> usersToRestsJWT = new List<UserCLS>();
                DateTime now = DateTime.Now;
                foreach (UserCLS user in _Users.Values)
                {
                    span = now.Subtract(user.JWT_CreateTime);
                    if (span.Minutes >= JWT_TimeExpiration)
                    {
                        usersToRestsJWT.Add(user);
                    }
                }

                //reset JWT
                foreach (UserCLS user in usersToRestsJWT)
                {
                    _Users[user.UserName].JWT = string.Empty;
                }
            }
        }
        #endregion
    }
}
