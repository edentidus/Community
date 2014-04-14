using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using uCommunity.Server.Data;

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
        int GetUserCount();

        [OperationContract]
        [WebGet(UriTemplate = "GetUser/{userId}", ResponseFormat = WebMessageFormat.Json)]
        User GetUser(Guid userId);
    }
}
