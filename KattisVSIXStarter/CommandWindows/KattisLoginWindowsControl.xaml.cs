namespace KattisVSIXStarter.CommandWindows
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for KattisLoginWindowsControl.
    /// </summary>
    public partial class KattisLoginWindowsControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KattisLoginWindowsControl"/> class.
        /// </summary>
        public KattisLoginWindowsControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "KattisLoginWindows");
        }
        const string strUrl =@"https://open.kattis.com/login/email";
        const string strArgs = @"{'script': 'true', 'token': aa14d4dd381062429ac55d28c90b65b7715dfe30726ad37847557216cf6261df', 'user': 'mark-wardell'}";

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var parms = new NameValueCollection()
            {
                { "username","mark.d.wardell@gmail.com"},
                //new KeyValuePair<string, string>("token",   "aa14d4dd381062429ac55d28c90b65b7715dfe30726ad37847557216cf6261df")
                { "password",   "Atlant1960!" }
            };
            using (var hclient = new HttpClient())
            {
                hclient.BaseAddress = new Uri(strUrl);
                HttpRequestMessage hr = new HttpRequestMessage(HttpMethod.Post, strUrl);
                hr.Headers.Add("User-Agent", "kattis-cli-submit");
                hr.Content = new StringContent("{ 'script': 'true', 'password': 'Atlanta1960!', 'user': 'mark-wardell'}");
                var response = await hclient.PostAsync(strUrl, new StringContent("{ 'script': 'true', 'password': 'Atlanta1960!', 'user': 'mark-wardell'}"));
                response.EnsureSuccessStatusCode();



            }
            /*
            var client = new CookieAwareWebClient();
            client.Login(strUrl, parms);
            */
        }
        public class CookieAwareWebClient : WebClient
        {
            public void Login(string loginPageAddress, NameValueCollection loginData)
            {
                CookieContainer container;

                var request = (HttpWebRequest)WebRequest.Create(loginPageAddress);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                var query = string.Join("&",
                  loginData.Cast<string>().Select(key => $"{key}={loginData[key]}"));

                var buffer = Encoding.ASCII.GetBytes(query);
                request.ContentLength = buffer.Length;
                var requestStream = request.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Close();

                container = request.CookieContainer = new CookieContainer();

                var response = request.GetResponse();
                response.Close();
                CookieContainer = container;
            }

            public CookieAwareWebClient(CookieContainer container)
            {
                CookieContainer = container;
            }

            public CookieAwareWebClient()
              : this(new CookieContainer())
            { }

            public CookieContainer CookieContainer { get; private set; }

            protected override WebRequest GetWebRequest(Uri address)
            {
                var request = (HttpWebRequest)base.GetWebRequest(address);
                request.CookieContainer = CookieContainer;
                return request;
            }
        }
    }
}