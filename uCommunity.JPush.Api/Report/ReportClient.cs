using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uCommunity.JPush.Api.Common;
using uCommunity.Utility;

namespace uCommunity.JPush.Api.Report
{
    class ReportClient:BaseHttpClient
    {
        private  const String REPORT_HOST_NAME = "https://report.jpush.cn";
        private  const String REPORT_RECEIVE_PATH = "/v2/received";
        private String appKey;

        private String masterSecret;

        public ReportClient(String appKey, String masterSecret) 
        {
            this.appKey = appKey;
            this.masterSecret = masterSecret;        
        }

        public ReceivedResult GetReceived(String msg_ids) 
        {

            String url = REPORT_HOST_NAME + REPORT_RECEIVE_PATH + "?msg_ids=" + msg_ids;
            String auth = Base64.GetBase64Encode(this.appKey+":"+this.masterSecret);
            ResponseResult rsp = this.SendGet(url, auth, null);
            ReceivedResult result = new ReceivedResult();
            List<ReceivedResult.Received> list = new List<ReceivedResult.Received>();

            if (rsp.responseCode == System.Net.HttpStatusCode.OK)
            {
                list = (List<ReceivedResult.Received>)JsonTool.JsonToObject(rsp.responseContent,list);
                String content = rsp.responseContent;
            }
            result.ResponseResult = rsp;
            result.ReceivedList = list;
            return result;
        
        }
    }
}
