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
        enum SupportedLanguages
        {
            
    //'.c#':/t                'C#',
    //'.c++':/t                'C++',
    //'.cc':/t                'C++',
    //'.cpp':/t                'C++',
    //'.cs':/t                'C#',
    //'.cxx':/t                'C++',
    //'.go':/t                'Go',
    //'.h':/t                'C++',
    //'.hs':/t                'Haskell',
    //'.java':/t                'Java',
    //'.js':/t                'JavaScript',
    //'.m':/t                'Objective-C',
    //'.pas':/t                'Pascal',
    //'.php':/t                'PHP',
    //'.pl':/t                'Prolog',
    //'.py':/t                'Python',
    //'.rb':/t                'Ruby'

        }
 

        
        private static List <RestResponseCookie> cookies = new List<RestResponseCookie>();
        public  virtual async Task<bool> LoginAsync(string user, string pwd)
        {
            var client = new RestClient("https://open.kattis.com");
            var req = new RestRequest("/login", Method.POST);

            req.AddParameter("script", "true", ParameterType.GetOrPost);
            req.AddParameter("password", pwd, ParameterType.GetOrPost);
            req.AddParameter("user", user, ParameterType.GetOrPost);
            RestResponse res = new RestResponse();    
            res = await GetResponseContentAsync(client, req) as RestResponse;
            cookies.Clear();
            foreach (var c in res.Cookies)
            {
                cookies.Add(c);
            }

            return (res.StatusCode == System.Net.HttpStatusCode.OK);

          
        }
        public virtual async Task<bool> SubmitAsync(string file)
        {
            if (!File.Exists(file))
                return false;
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

            sreq.AddFile("sub_file[]", File.ReadAllBytes(file), file, "application/octet-stream");
            var tcs = new TaskCompletionSource<IRestResponse>();
            RestResponse res = new RestResponse();
            res = await GetResponseContentAsync(client, sreq) as RestResponse;
            return (res.StatusCode == System.Net.HttpStatusCode.OK);
        }

        private Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
