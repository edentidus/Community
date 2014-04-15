using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using uCommunity.Server.Data;
using System.Runtime.Serialization;

namespace uCommunity.Interface.ServiceContract
{
    [ServiceContract]
    public interface IUser
    {
        /// <summary>
        /// Return the number of all users in system
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        int GetUserCount();

        [OperationContract]
        [WebGet(UriTemplate = "GetUser/{userId}", ResponseFormat = WebMessageFormat.Json)]
        User GetUser(string userId);
    }
}
