using System;
using System.Diagnostics;
using System.Net;
using uCommunity.Utility;

namespace uCommunity.JPush.Api.Common
{
    public class ResponseResult
    {
        private const int RESPONSE_CODE_NONE = -1;

        public HttpStatusCode responseCode = HttpStatusCode.OK;
        public String responseContent;
    
        public ErrorObject error;     // error for non-200 response, used by new API
    
        public int rateLimitQuota;
        public int rateLimitRemaining;
        public int rateLimitReset;
    
        public String exceptionString;

	    public ResponseResult() {
	    }
	
        public void SetRateLimit(String quota, String remaining, String reset) {
            if (null == quota) return;

            try
            {
                if (quota != "" && StringUtil.IsInt(quota))
                {
                    rateLimitQuota = int.Parse(quota);
                }  
                if (remaining!="" && StringUtil.IsInt(remaining))
                {
                    rateLimitRemaining = int.Parse(remaining);
                }
                if (reset!="" && StringUtil.IsInt(reset))
                {
                    rateLimitReset = int.Parse(reset);
                }
            }
            catch(Exception e)
            {
                Debug.Print(e.Message);
            }
        }

        public void SetErrorObject()
        {
            this.error = (ErrorObject)JsonTool.JsonToObject(responseContent, new ErrorObject());
        }


	    public class ErrorObject {
	        public int errcode;
            public String errmsg;
	    }
    }
}
