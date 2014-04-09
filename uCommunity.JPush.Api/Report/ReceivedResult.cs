using System;
using System.Collections.Generic;
using System.Net;
using uCommunity.JPush.Api.Common;

namespace uCommunity.JPush.Api.Report
{
    public class ReceivedResult : BaseResult
    {

        private List<Received> receivedList = new List<Received>();

        public List<Received> ReceivedList
        {
            get { return receivedList; }
            set { receivedList = value; }
        }
	
	    public class Received {
	        public long msg_id;
	        public String android_received;
	        public String ios_apns_sent;
	    }

        public override bool HasError
        {
            get
            {
                if (Equals(ResponseResult, HttpStatusCode.OK))
                {
                    return true;
                }
                return false;
            }
        }

        

        public override int ErrorCode
        {
            get
            {
                if (null != ResponseResult)
                {
                    return ResponseResult.error.errcode;
                }
                return 0;
            }
        }

        public override string ErrorMessage
        {
            get
            {
                if (null != ResponseResult)
                {
                    return ResponseResult.error.errmsg;
                }
                return string.Empty;
            }
        }
    }
}
