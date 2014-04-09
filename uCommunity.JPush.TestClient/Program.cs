using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uCommunity.JPush.Api;
using uCommunity.JPush.Api.Common;
using uCommunity.JPush.Api.Push;
using uCommunity.JPush.Api.Report;
using uCommunity.Utility;

namespace uCommunity.JPush.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************");
            Console.WriteLine("*****开始发送******");

            //String result;
            String master_secret = "2b38ce69b1de2a7fa95706ea";
            String app_key = "dd1066407b044738b6479275";
            int sendno = 9;
            JPushClient client = new JPushClient(app_key, master_secret);
            MessageResult result = null;


            //send notify message
            Console.WriteLine("*****发送通知******");
            result = client.SendNotificationAll("notify content");
            Console.WriteLine("sendNotificationAll:**返回状态：" + result.ErrorCode.ToString() +
                          "  **返回信息:" + result.ErrorMessage +
                          "  **Send No.:" + result.SendNo +
                          "  msg_id:" + result.MessageId +
                          "  频率次数：" + result.GetRateLimitQuota() +
                          "  可用频率：" + result.GetRateLimitRemaining() +
                          "  重置时间：" + result.GetRateLimitReset());

            Console.WriteLine("*****发送消息******");
            result = client.SendCustomMessageAll("custom all","notify content");
            Console.WriteLine("SendCustomMessageAll:**返回状态：" + result.ErrorCode.ToString() +
                          "  **返回信息:" + result.ErrorMessage +
                          "  **Send No.:" + result.SendNo +
                          "  msg_id:" + result.MessageId +
                          "  频率次数：" + result.GetRateLimitQuota() +
                          "  可用频率：" + result.GetRateLimitRemaining() +
                          "  重置时间：" + result.GetRateLimitReset());


            NotificationParams notifyParams = new NotificationParams();
            CustomMessageParams customParams = new CustomMessageParams();

            //notifyParams.
            Dictionary<String, Object> extras = null;


            Console.WriteLine("*****发送带tag通知******");

            notifyParams.AddPlatform(DeviceEnum.Android);
            notifyParams.ReceiverType = ReceiverTypeEnum.TAG;
            notifyParams.ReceiverValue = "tag_api";
            notifyParams.SendNo = 256;
            //notifyParams.OverrideMsgId = "1";

            result = client.SendNotification("tag notify content", notifyParams, extras);
            Console.WriteLine("SendNotificationAll:**返回状态：" + result.ErrorCode.ToString() +
                          "  **返回信息:" + result.ErrorMessage +
                          "  **Send No.:" + result.SendNo +
                          "  msg_id:" + result.MessageId +
                          "  频率次数：" + result.GetRateLimitQuota() +
                          "  可用频率：" + result.GetRateLimitRemaining() +
                          "  重置时间：" + result.GetRateLimitReset());



            Console.WriteLine("*****发送带tag消息******");
            customParams.AddPlatform(DeviceEnum.Android);
            customParams.ReceiverType = ReceiverTypeEnum.TAG;
            customParams.ReceiverValue = "tag_api";
            customParams.SendNo = 256;
            result = client.SendCustomMessage("Send custom mess", "tag notify content", customParams, extras);
            Console.WriteLine("SendCustomMessage:**返回状态：" + result.ErrorCode.ToString() +
                          "  **返回信息:" + result.ErrorMessage +
                          "  **Send No.:" + result.SendNo +
                          "  msg_id:" + result.MessageId +
                          "  频率次数：" + result.GetRateLimitQuota() +
                          "  可用频率：" + result.GetRateLimitRemaining() +
                          "  重置时间：" + result.GetRateLimitReset());


            extras = new Dictionary<String, Object>();

            Console.WriteLine("*****发送带alias通知******");

            notifyParams.AddPlatform(DeviceEnum.Android);
            notifyParams.ReceiverType = ReceiverTypeEnum.ALIAS;
            notifyParams.ReceiverValue = "alias_api";
            notifyParams.SendNo = 257;
            //notifyParams.OverrideMsgId = "2";

            result = client.SendNotification("alias notify content", notifyParams, extras);
            Console.WriteLine("sendNotificationAll:**返回状态：" + result.ErrorCode.ToString() +
                          "  **返回信息:" + result.ErrorMessage +
                          "  **Send No.:" + result.SendNo +
                          "  msg_id:" + result.MessageId +
                          "  频率次数：" + result.GetRateLimitQuota() +
                          "  可用频率：" + result.GetRateLimitRemaining() +
                          "  重置时间：" + result.GetRateLimitReset());


            Console.WriteLine("*****发送带tag消息******");
            customParams.AddPlatform(DeviceEnum.Android);
            customParams.ReceiverType = ReceiverTypeEnum.ALIAS;
            customParams.ReceiverValue = "alias_api";
            customParams.SendNo = 256;
            result = client.SendCustomMessage("send custom mess", "alias notify content", customParams, extras);
            Console.WriteLine("sendCustomMessage:**返回状态：" + result.ErrorCode.ToString() +
                          "  **返回信息:" + result.ErrorMessage +
                          "  **Send No.:" + result.SendNo +
                          "  msg_id:" + result.MessageId +
                          "  频率次数：" + result.GetRateLimitQuota() +
                          "  可用频率：" + result.GetRateLimitRemaining() +
                          "  重置时间：" + result.GetRateLimitReset());

            Console.WriteLine();

            String msg_ids = "1613113584,1229760629,1174658841,1174658641";
              ReceivedResult receivedResult = client.GetReceivedApi(msg_ids);

              Console.WriteLine("Report Result:");
            foreach(ReceivedResult.Received re in receivedResult.ReceivedList)
            {
                Console.WriteLine("GetReceivedApi************msgid=" + re.msg_id+ "  ***andriod received="+re.android_received+" ***ios received="+re.ios_apns_sent);            
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    
        public class IOSExtras
        {
            public int badge = 888;
            public String sound = "happy";
        }
    }
}
