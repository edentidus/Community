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
    public class UserService : IUser
    {
        uCommunityEntities entities;
        public UserService()
        {
            entities = new uCommunityEntities();
            
        }

        public int GetUserCount()
        {
            return 1;
        }

        public Data.User GetUser(Guid userId)
        {
            var retval = entities.Users.FirstOrDefault(u => u.Id.Equals(userId));
            return retval;
        }
    }
}