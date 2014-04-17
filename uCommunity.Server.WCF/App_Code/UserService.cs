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
    public class UserService : ServiceBase, IUserService
    {
        public UserService()
        {
        }

        public ResultWrapper<int> GetUserCount()
        {
            return base.TryDo<int>((entities) => entities.Users.Count());
        }

        public ResultWrapper<User> GetUser(string userId)
        {
            return base.TryDo<User>((entities) => entities.Users.FirstOrDefault(u => u.Id.Equals(new Guid(userId))));
        }

        public ResultWrapper<User> CreateUser(User user)
        {
            return base.TryDo<User>((entities) =>
                {
                    user.Id = Guid.NewGuid();
                    // Login name should be unique
                    if (entities.Users.Any((u) => u.LoginName.Equals(user.LoginName)))
                        throw new ArgumentException("User already in system.");
                    entities.Users.Add(user);
                    if (entities.SaveChanges() != 1)
                        throw new InvalidOperationException();
                    return user;
                });
        }
    }
}