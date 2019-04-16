using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
namespace Common.Lib.RestAPI
{
    public class RESTHelper
    {
        public static T Get<T>(string url, string token = "")
        {
            using (HttpClient client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token.Trim()))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage responseMessage = client.GetAsync(url).Result;
                return ResultHandler<T>(responseMessage);
            }
        }

        public static T Post<T>(string url, object param, string token = "")
        {
            using (HttpClient client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token.Trim()))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string postBody = JsonConvert.SerializeObject(param);
                HttpResponseMessage responseMessage = client.PostAsync(url, new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                return ResultHandler<T>(responseMessage);
            }
        }

        public static T PostNotJson<T>(string url, string param, string token = "")
        {
            using (HttpClient client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token.Trim()))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string postBody = param;
                HttpResponseMessage responseMessage = client.PostAsync(url, new StringContent(postBody, Encoding.UTF8, "application/x-www-form-urlencoded")).Result;
                return ResultHandler<T>(responseMessage);
            }
        }

        public static T ResultHandler<T>(HttpResponseMessage responseMessage)
        {
            string responseString = responseMessage.Content.ReadAsStringAsync().Result;
            if (JSONHelper.IsValidJsonString(responseString))
            {
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            else
            {
                return default(T);
            }
        }
    }
}
