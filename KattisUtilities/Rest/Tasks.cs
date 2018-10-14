using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KattisUtilities.Rest
{
    public class Tasks
    {
        private static List <RestResponseCookie> cookies = new List<RestResponseCookie>();
        public static async Task<bool> Login(string user, string pwd)
        {
            var client = new RestClient("https://open.kattis.com");
            var req = new RestRequest("/login", Method.POST);
            

            // Content type is not required when adding parameters this way
            // This will also automatically UrlEncode the values


            req.AddParameter("script", "true", ParameterType.GetOrPost);
            req.AddParameter("password", pwd, ParameterType.GetOrPost);
            req.AddParameter("user", user, ParameterType.GetOrPost);
            RestResponse res = new RestResponse();
            //Task.Run(async () =>
            //{
                res = await Tasks.GetResponseContentAsync(client, req) as RestResponse;
            // }).Wait(new System.TimeSpan)(0, 0, 30));
            foreach (var c in res.Cookies)
            {
                cookies.Add(c);
            }

            return true;
        }
        public static async Task<bool> SubmitAsync(string file)
        {
            var client = new RestClient("https://open.kattis.com");
            var sreq = new RestRequest("/submit", Method.POST);

            sreq.AddParameter("language", "c#", ParameterType.GetOrPost);
            sreq.AddParameter("mainclass", "", ParameterType.GetOrPost);
            sreq.AddParameter("script", "true", ParameterType.GetOrPost);
            sreq.AddParameter("submit", "true", ParameterType.GetOrPost);
            sreq.AddParameter("submit_ctr", "2", ParameterType.GetOrPost);
            sreq.AddParameter("problem", "hello", ParameterType.GetOrPost);
            foreach (var rrCookie in cookies)
                sreq.AddParameter(rrCookie.Name, rrCookie.Value, ParameterType.Cookie);

            sreq.AddFile("sub_file[]", File.ReadAllBytes(file), "hello.cs", "application/octet-stream");
            var tcs = new TaskCompletionSource<IRestResponse>();
            var  res = await Tasks.GetResponseContentAsync(client, sreq) as RestResponse;  
            return true;
        }
        private static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
