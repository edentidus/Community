using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uCommunity.Utility;

namespace uCommunity.JPush.Api.Push
{
    public class CustomMessageParams : MessageParams
    {
        private CustomMessageContent customMsgContent = new CustomMessageContent();

        public CustomMessageContent CustomMsgContent
        {
            get { return customMsgContent; }
            set { customMsgContent = value; }
        }

        public class CustomMessageContent
        {
            public String content_type;

            public Dictionary<String, Object> extras = new Dictionary<string, object>();

            public String title = "";

            public String message = "";
        }

        public override string MsgContent
        {
            get
            {
                return JsonTool.ObjectToJson(customMsgContent);
            }
            set { }
        }
    }
}
