using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Runtime.Serialization;
//using System.ServiceModel;
//using System.Runtime.Serialization.Json;

namespace CSHttpClientSample
{
    static class Program
    {
        private static string NewsSearch = "https://api.cognitive.microsoft.com/bing/v5.0/news/search";
        private static string Search = "https://api.cognitive.microsoft.com/bing/v5.0/search";
        //private static string Search = "https://api.cognitive.microsoft.com/bing/v5.0/web/search";
        //WebUtility.UrlEncode(query)
        static void Main()
        {
            string key = Console.ReadLine();
            //makenewsrequest(key);
            makewebrequest(key);
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
        }

        static async void makenewsrequest(string key2)
        {
            var client = new HttpClient();
            string query = "Soros";
            int count = 20;
            int offset = 0;
            string market = "en-US";
            string key = key2;

            //var queryString = HttpUtility.ParseQueryString(string.Empty);
            var queryString = WebUtility.UrlEncode(query);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

            // Request parameters
            //queryString["Category"] = "{Business}";
            //var uri = "https://api.cognitive.microsoft.com/bing/v5.0/news/?" + queryString;
            var uri = string.Format("{0}/?q={1}&count={2}&offset={3}&mkt={4}", NewsSearch, queryString, count, offset, market);
            var response = await client.GetAsync(uri);
            Console.Write(response);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            dynamic data = JObject.Parse(json);
            Console.WriteLine(data);
            if (data.value != null && data.value.Count > 0)
            {
                for (int i = 0; i < data.value.Count; i++)
                {

                    string Title = data.value[i].name;
                    string Url = data.value[i].url;
                    string Description = data.value[i].description;
                    string ThumbnailUrl = data.value[i].image?.thumbnail?.contentUrl;
                    string Provider = data.value[i].provider?[0].name;
                    Console.WriteLine(Description);
                }
            }
        }
        static async void makewebrequest(string key2)
        {
            var client = new HttpClient();
            string query = "Soros";
            int count = 20;
            int offset = 0;
            string market = "en-US";
            string responseFilter = "Webpages";
            string key = key2;

            //var queryString = HttpUtility.ParseQueryString(string.Empty);
            var queryString = WebUtility.UrlEncode(query);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

            // Request parameters
            //queryString["Category"] = "{Business}";
            //var uri = "https://api.cognitive.microsoft.com/bing/v5.0/news/?" + queryString;
            var uri = string.Format("{0}/?q={1}&count={2}&offset={3}&mkt={4}&responseFilter={5}", Search, queryString, count, offset, market, responseFilter);
            var response = await client.GetAsync(uri);
            Console.Write(response);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            dynamic data1 = JObject.Parse(json);
            if(data1.webPages != null)
            Console.WriteLine(data1);
            dynamic data = data1.webPages;
            if (data.value != null && data.value.Count > 0)
            {
                Console.WriteLine(data.value.Count);
                for (int i = 0; i < data.value.Count; i++)
                {
                    //Console.WriteLine(data.value.Count);
                    string Title = data.value[i].name;
                    string Url = data.value[i].url;
                    //string Description = data.value[i].about;
                    //string ThumbnailUrl = data.value[i].image?.thumbnail?.contentUrl;
                    //string Provider = data.value[i].provider?[0].name;
                    Console.WriteLine(Title);
                }
            }
            //System.IO.File.WriteAllLines(@"C:\Users\Admin\Downloads\testapi\WriteLines.txt", data1);
            //System.IO.File.WriteAllText(@"C:\Users\Admin\Downloads\testapi\WriteText.txt", data1);
            System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"C:\Users\Admin\Downloads\testapi\WriteLines2.txt");
            file1.WriteLine(data1);
            file1.Close();
            System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"C:\Users\Admin\Downloads\testapi\WriteLines2.txt", true);
            file2.WriteLine(data1);
        }
    }
}