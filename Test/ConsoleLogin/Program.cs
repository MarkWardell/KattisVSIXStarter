using RestSharp;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ConoleLogin
{
    class Program
    {
        public class ClientConfig
        {
            public string script { get; set; } = "true";
            public string user { get; set; } = "mark-wardell";
            public string token { get; set; } = "aa14d4dd381062429ac55d28c90b65b7715dfe30726ad37847557216cf6261df";
            

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
            var req = new RestRequest("/login", Method.POST);
            var config = new ClientConfig();//values to pass in request

            // Content type is not required when adding parameters this way
            // This will also automatically UrlEncode the values
            
            
            req.AddParameter("script", config.script, ParameterType.GetOrPost);
            req.AddParameter("token", config.token, ParameterType.GetOrPost);
            req.AddParameter("user", config.user, ParameterType.GetOrPost);
            RestResponse res = new RestResponse();
            Task.Run(async () =>
            {
                res = await GetResponseContentAsync(client, req) as RestResponse;
            }).Wait(new System.TimeSpan(0, 0, 30));
            //var res = client.Execute(req);
            
          

            var sreq = new RestRequest("/submit", Method.POST);
            
            sreq.AddParameter("language",   "c#",   ParameterType.GetOrPost);
            sreq.AddParameter("mainclass",   "",    ParameterType.GetOrPost);
            sreq.AddParameter("script",     "true", ParameterType.GetOrPost);
            sreq.AddParameter("submit",     "true", ParameterType.GetOrPost);
            sreq.AddParameter("submit_ctr", "2",    ParameterType.GetOrPost);
            sreq.AddParameter("problem",    "hello",ParameterType.GetOrPost);
            foreach (var rrCookie in res.Cookies)
                sreq.AddParameter(rrCookie.Name, rrCookie.Value, ParameterType.Cookie);

            sreq.AddFile("sub_file[]", File.ReadAllBytes(@"D:\Both\Code\Py\Hello.cs"),"hello.cs", "application/octet-stream");
            var tcs = new TaskCompletionSource<IRestResponse>();

            // res = client.Execute(sreq);

            Task.Run(async () =>
            {
                res = await GetResponseContentAsync(client, sreq) as RestResponse;
            }).Wait(new System.TimeSpan(0, 0, 30));



            return true;
        }
        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
