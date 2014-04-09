using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

namespace uCommunity.Utility
{
    public class JsonTool
    {   
        public static string ObjectToJson(object obj)        
        {
            if (obj == null) return string.Empty;

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());           
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, obj);
                byte[] dataBytes = new byte[stream.Length];
                stream.Position = 0;
                stream.Read(dataBytes, 0, (int)stream.Length);
                return Encoding.UTF8.GetString(dataBytes).Replace("\\", "");
            }
        }
    
        public static object JsonToObject(string jsonString, object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                return serializer.ReadObject(mStream);
            }
        }

        public static string DictionaryToJson(Dictionary<String, Object> dict)
        {
            StringBuilder json = new StringBuilder();
            
            foreach (KeyValuePair<String, Object> pair in dict) 
            {
                json.Append(pair.Key).Append(":").Append(pair.Value).Append(",");            
            }
            
            if (json.Length > 0) 
            {
                json.Remove(json.Length -1, 1);            
            }
            json.Append("}");
            json.Insert(0, "{");
            
            return json.ToString();
        }
    }
}
