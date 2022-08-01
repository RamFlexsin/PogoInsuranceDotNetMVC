using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace PogoApp_MVC.Utilities
{
    public class Utility
    {
        public bool WriteFile(string fileName, string content)
        {
            try
            {
                string path = @"D:\Pogo\PogoInsurance DotNetMVC\SavedData\" + System.DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyy_MM_dd_hh_mm_ss") + "_" + fileName + ".json";
                File.WriteAllText(path, content);
                return true;
            }
            catch (Exception ex) { return false; };
        }
        private string ReturnApiURL(string MethodName)
        {
            string url = string.Empty;
            string baseUrl = System.Configuration.ConfigurationManager.AppSettings["SoleProUrl"].ToString();
            string apiKey = System.Configuration.ConfigurationManager.AppSettings["SoleProKey"].ToString();
            url = baseUrl + MethodName + "?AppKey=" + apiKey;
            return url;
        }

        private HttpResponseMessage GetAPIResponse(HttpMethod method, string methodName, HttpContent content = null)
        {
            string url = ReturnApiURL(methodName);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = method == HttpMethod.Get ? client.GetAsync(client.BaseAddress).Result
                 : method == HttpMethod.Delete ? client.DeleteAsync(client.BaseAddress).Result
                 : method == HttpMethod.Post ? client.PostAsync(client.BaseAddress, content).Result
                 : client.PutAsync(client.BaseAddress, content).Result;
            ;
          
            return response;
        }
        public GetClassCodes GetGetClassCodes(string BusinessEntity, string ProductCode, string StateCode)
        {
            GetClassCodes getClassCodes = new GetClassCodes { Data = null, Status = false };
            try
            {
                RequestClassCodes requestClassCodes = new RequestClassCodes();
                requestClassCodes.BusinessEntity = BusinessEntity;
                requestClassCodes.StateCode = StateCode;
                requestClassCodes.ProductCode = ProductCode;
                string strjson = JsonConvert.SerializeObject(requestClassCodes);
                HttpContent content = new StringContent(strjson, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = GetAPIResponse(HttpMethod.Post, "GetClassCodes", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string response = httpResponse.Content.ReadAsStringAsync().Result;
                    getClassCodes = JsonConvert.DeserializeObject<GetClassCodes>(response.ToString());
                }
                return getClassCodes;
            }
            catch (Exception ex) { return getClassCodes = new GetClassCodes { Data = null, Status = false, Message = new List<string> { ex.Message } }; }
        }
        public GetQuestions GetGetQuestions(string ProductCode, string StateCode)
        {
            GetQuestions getQuestions = new GetQuestions { Data = null, Status = false };
            try
            {
                RequestQuestions requestQuestions = new RequestQuestions();
                requestQuestions.StateCode = StateCode;
                requestQuestions.ProductCode = ProductCode;
                string strjson = JsonConvert.SerializeObject(requestQuestions);
                HttpContent content = new StringContent(strjson, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = GetAPIResponse(HttpMethod.Post, "GetQuestions", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string response = httpResponse.Content.ReadAsStringAsync().Result;
                    getQuestions = JsonConvert.DeserializeObject<GetQuestions>(response.ToString());
                }
                return getQuestions;
            }
            catch (Exception ex) { return getQuestions = new GetQuestions { Data = null, Status = false, Message = new List<string> { ex.Message } }; }
        }
        public QuoteResponse PostQuote(SendQuoteRequest sendQuoteRequest)
        {
            QuoteResponse quoteResponse= new QuoteResponse ();
            try
            {
                string strjson = JsonConvert.SerializeObject(sendQuoteRequest);
                HttpContent content = new StringContent(strjson, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = GetAPIResponse(HttpMethod.Post, "Quote", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string response = httpResponse.Content.ReadAsStringAsync().Result;
                    quoteResponse = JsonConvert.DeserializeObject<QuoteResponse>(response.ToString());
                }
                return quoteResponse;
            }
            catch (Exception ex) { return quoteResponse; };
        }
    }
}