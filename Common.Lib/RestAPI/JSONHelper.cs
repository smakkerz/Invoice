using Newtonsoft.Json.Linq;
using System;

namespace Common.Lib.RestAPI
{
    public class JSONHelper
    {
        public static bool IsValidJsonString(string jsonString)
        {
            try
            {
                JToken token = JObject.Parse(jsonString);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
