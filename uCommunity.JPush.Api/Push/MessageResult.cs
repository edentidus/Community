using uCommunity.JPush.Api.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;


namespace uCommunity.JPush.Api.Push
{
    public class MessageResult : BaseResult
    {
        public int msg_id;
        public int sendno;
        public int errcode = ERROR_CODE_NONE;
        public String errmsg;
    
        public long MessageId
        {
            get { return this.msg_id; }
        }
    
        public int SendNo
        {
            get { return this.sendno; }
        }
    
        public override int ErrorCode
        {
            get { return this.errcode; }
        }
    
        public override String ErrorMessage
        {
            get { return this.errmsg; }
        }

        public override bool HasError
        {
            get
            {
                if (Equals(ResponseResult, HttpStatusCode.OK) && this.errcode == ERROR_CODE_OK)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
