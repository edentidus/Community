using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using uCommunity.Utility;

namespace uCommunity.JPush.Api.Push
{
    public class NotificationParams:MessageParams
    {
        private NotificationContent notyfyMsgContent = new NotificationContent();

        public NotificationContent NotyfyMsgContent
        {
            get { return notyfyMsgContent; }
            set { notyfyMsgContent = value; }
        }
        
        public class NotificationContent
        {
            public Dictionary<String, Object> n_extras = new Dictionary<string, object>();

            public int n_builder_id = 0;

            public String n_title = "";

            public String n_content = "";        
        }

        public override string MsgContent
        {
            get
            {
                return JsonTool.ObjectToJson(notyfyMsgContent);
            }
            set { }
        }
    }
}
