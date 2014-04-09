using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uCommunity.JPush.Api.Common
{
    public abstract class BaseResult
    {
        public const  int ERROR_CODE_NONE = -1;
        public const int ERROR_CODE_OK = 0;
        public const String ERROR_MESSAGE_NONE = "None error message.";
        
        public const int RESPONSE_OK = 200;

        private ResponseResult responseResult;

        public ResponseResult ResponseResult
        {
            get { return responseResult; }
            set { responseResult = value; }
        }


        public abstract bool HasError { get; }

        public abstract int ErrorCode { get; }

        public abstract String ErrorMessage { get; }
    
        public int GetRateLimitQuota() {
            if (null != responseResult) {
                return responseResult.rateLimitQuota;
            }
            return 0;
        }
    
        public int GetRateLimitRemaining() {
            if (null != responseResult) {
                return responseResult.rateLimitRemaining;
            }
            return 0;
        }
    
        public int GetRateLimitReset() {
            if (null != responseResult) {
                return responseResult.rateLimitReset;
            }
            return 0;
        }
    }
}
