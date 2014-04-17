using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace uCommunity.Server.Data
{
    [DataContract]
    public class ResultWrapper<T>
    {
        [DataMember]
        public bool HasError { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public T Result { get; set; }
    }
}
