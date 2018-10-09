using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace ConoleLogin
{
    class Program
    {
        public class ClientConfig
        {
            public string user { get; set; } = "mark-wardell";
            public string token { get; set; } = "aa14d4dd381062429ac55d28c90b65b7715dfe30726ad37847557216cf6261df";
            //"aa14d4dd381062429ac55d28c90b65b7715dfe30726ad37847557216cf6261df";
            //public string password { get; set; } = "Atlanta1960!";

        }
        static
            async Task<int> Main(string[] args)
        {
           var b = await Login("mark.d.wardell@gmail.com", "Atlanta1960!");
            return 0;
        }

        static async Task<bool> Login( string user, string pwd)
        {
            var client = new RestClient("https://open.kattis.com");
            var request = new RestRequest("/login", Method.POST);
            request.RequestFormat = DataFormat.Json;
            var config = new ClientConfig();
            request.AddParameter("user", config.user, ParameterType.RequestBody);
            request.AddParameter("token", config.token, ParameterType.RequestBody);
          
            IRestResponse response = client.Execute(request);

            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("Access Token cannot obtain, process terminate");
                
            }


            HttpClient hc = new HttpClient();

            var message = new HttpRequestMessage(HttpMethod.Post, "https://open.kattis.com");
            message.Content = new StringContent("user=mark.d.wardell@gmail.com&password=Atlanta1960!");
            message.RequestUri = new Uri("https://open.kattis.com/login");
            var resp=  hc.PostAsync("https//open.kattis.com/login", message.Content);
          

            HttpResponseMessage resultLogin = await hc.PostAsync("https://open.kattis.com/login", 
                                                                 new StringContent("user=mark.d.wardell@gmail.com&password=Atlanta190!"));
                                                                                    

            return true;
        }
    }
}
