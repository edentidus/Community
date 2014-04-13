using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uCommunity.Interface.ServiceContract;

namespace uCommunity.Server.WCF
{
    /// <summary>
    /// Summary description for UserService
    /// </summary>
    public class UserService : IUser
    {
        public int GetUserCount()
        {
            return 1;
        }
    }
}