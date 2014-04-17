using System.ServiceModel;
using System.ServiceModel.Web;
using uCommunity.Server.Data;

namespace uCommunity.Interface.ServiceContract
{
    [ServiceContract(Namespace = "http://unisys.com/")]
    public interface IUserService
    {
        /// <summary>
        /// Return the number of all users in system
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        ResultWrapper<int> GetUserCount();

        /// <summary>
        /// Return specific user by user id
        /// </summary>
        /// <param name="userId">Guid for user</param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "GetUser/{userId}", ResponseFormat = WebMessageFormat.Json)]
        ResultWrapper<User> GetUser(string userId);

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">User</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method="POST", RequestFormat=WebMessageFormat.Json, ResponseFormat=WebMessageFormat.Json)]
        ResultWrapper<User> CreateUser(User user);
    }
}
