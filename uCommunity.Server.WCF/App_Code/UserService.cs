using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uCommunity.Interface.ServiceContract;
using uCommunity.Server.Data;

namespace uCommunity.Server.WCF
{
    /// <summary>
    /// Summary description for UserService
    /// </summary>
    public class UserService : ServiceBase, IUser
    {
        public UserService()
        {
        }

        public int GetUserCount()
        {
            return base.Entities.Users.Count();
        }

        public User GetUser(string userId)
        {
            var retval = base.Entities.Users.FirstOrDefault(u => u.Id.Equals(new Guid(userId))) as User;
            return retval;
        }
    }
}