using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

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
    }
}
