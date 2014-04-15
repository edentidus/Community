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
            return entities.Users.Count();
        }

        public User GetUser(string userId)
        {
            var retval = entities.Users.FirstOrDefault(u => u.Id.Equals(new Guid(userId))) as User;
            return retval;
        }
    }
}