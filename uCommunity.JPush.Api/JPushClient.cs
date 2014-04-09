using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uCommunity.JPush.Api.Common;
using uCommunity.JPush.Api.Push;
using uCommunity.JPush.Api.Report;
using uCommunity.Utility;

namespace uCommunity.JPush.Api
{
    public class JPushClient
    {
        private PushClient _pushClient;

        private ReportClient _reportClient;

        public JPushClient(String app_key, String masterSecret)
        {
            HashSet<DeviceEnum> devices = new HashSet<DeviceEnum>();
            devices.Add(DeviceEnum.IOS);
            devices.Add(DeviceEnum.Android);
            _pushClient = new PushClient(masterSecret, app_key, MessageParams.NO_TIME_TO_LIVE, null, true);
            _reportClient = new ReportClient(app_key, masterSecret);
        }


        public JPushClient(String app_key, String masterSecret, int time_to_live, HashSet<DeviceEnum> devices, bool apnsProduction)
        {
            _pushClient = new PushClient(masterSecret, app_key, time_to_live, devices, apnsProduction);
            _reportClient = new ReportClient(app_key, masterSecret);
        }

        public MessageResult SendNotification(String notificationContent, NotificationParams notifyParams, Dictionary<String, Object> extras)
        {
            return _pushClient.SendNotification(notificationContent, notifyParams, extras);
        }

        public MessageResult SendCustomMessage(String msgTitle, String msgContent, CustomMessageParams customParams, Dictionary<String, Object> extras)
        {
            return _pushClient.SendCustomMessage(msgTitle, msgContent, customParams, extras);
        }

        public MessageResult SendNotificationAll(String notificationContent)
        {
            NotificationParams notifyParams = new NotificationParams();
            notifyParams.ReceiverType = ReceiverTypeEnum.APP_KEY;
            return _pushClient.SendNotification(notificationContent, notifyParams, null);
        }

	    public MessageResult SendCustomMessageAll(String msgTitle, String msgContent) {
            CustomMessageParams customParams = new CustomMessageParams();
            customParams.ReceiverType = ReceiverTypeEnum.APP_KEY;
	        return _pushClient.SendCustomMessage(msgTitle, msgContent, customParams, null);
	    }

        public ReceivedResult GetReceivedApi(String msg_ids)
        {
            return _reportClient.GetReceived(msg_ids);
        }
    }
}
