using uCommunity.JPush.Api.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uCommunity.JPush.Api.Push
{
    public abstract class MessageParams
    {
        
        public const int DEFAULT_TIME_TO_LIVE = 86400;   //s
        public const int NO_TIME_TO_LIVE = -1;
        public const int DEFAULT_ANDROID_BUILDER_ID = 0;

        private int sendNo = 1;

        /// <summary>
        /// Send number, should be maintained by developer
        /// </summary>
        public int SendNo
        {
            get { return sendNo; }
            set { sendNo = value; }
        }

        private String overrideMsgId;

        public String OverrideMsgId
        {
            get { return overrideMsgId; }
            set { overrideMsgId = value; }
        }

        private String appKey = "";

        /// <summary>
        /// App key, required
        /// </summary>
        public String AppKey
        {
            get { return appKey; }
            set { appKey = value; }
        }

        private ReceiverTypeEnum receiverType;

        public ReceiverTypeEnum ReceiverType
        {
            get { return receiverType; }
            set { receiverType = value; }
        }

        private String receiverValue = "";

        /// <summary>
        /// Receiver value, related with ReceiverType
        /// If receiverType equals 4, do not need to set 
        /// </summary>
        public String ReceiverValue
        {
            get { return receiverValue; }
            set { receiverValue = value; }
        }

        private long timeToLive = -1;

        /// <summary>
        /// Time to make the message living when client is offline. Max is 10 days (864000 sec)
        /// 0 = don't keep living. eg. online user will recive messeage, offline will not recive it any more
        /// default is 1 day
        /// </summary>
        public long TimeToLive
        {
            get { return timeToLive; }
            set { timeToLive = value; }
        } 

        private String masterSecret;

        public String MasterSecret
        {
            get { return masterSecret; }
            set { masterSecret = value; }
        }

        private HashSet<DeviceEnum> platform = new HashSet<DeviceEnum>();


        public String GetPlatform()
        {
            String keys = "";
            if (this.receiverType == ReceiverTypeEnum.APP_KEY)
            {
                foreach (String device in Enum.GetNames(typeof(DeviceEnum)))
                {
                    keys += device.ToLower();
                    keys += ",";
                }
            }
            else
            {
                foreach (DeviceEnum key in this.platform)
                {
                    keys += (key.ToString().ToLower() + ",");
                }
            }
            Debug.Print(keys);

            return keys.Length > 0 ? keys.Substring(0, keys.Length - 1) : "";
        }

        public void AddPlatform(DeviceEnum platform)
        {
            this.platform.Add(platform);
        }
	
        // 0: development env  1: production env
        private int apnsProduction;

        public int ApnsProduction
        {
            get { return apnsProduction; }
            set { apnsProduction = value; }
        }

        private String msgContent = "";

        public virtual String MsgContent
        {
            get { return msgContent; }
            set { msgContent = value; }
        }
    }

    public enum ReceiverTypeEnum
    {
        IMEI = 1,

        TAG = 2,

        ALIAS = 3,

        APP_KEY = 4,

        REGISTRATION_ID = 5
    
    }
}
