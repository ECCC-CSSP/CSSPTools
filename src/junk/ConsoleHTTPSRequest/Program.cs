using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;

namespace ConsoleHTTPSRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ReadCSSPWebAPIAppErrLogs();
        }

        public class CookieAwareWebClient : WebClient
        {
            private CookieContainer cookie = new CookieContainer();

            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);
                if (request is HttpWebRequest)
                {
                    (request as HttpWebRequest).CookieContainer = cookie;
                }
                return request;
            }
        }

        static void ReadCSSPWebAPIAppErrLogs()
        {
            var client = new CookieAwareWebClient();
            string loginStr = client.DownloadString(@"https://localhost:44353/Identity/Account/Login");
            int pos = loginStr.IndexOf("__RequestVerificationToken");
            int pos2 = loginStr.IndexOf("value=\"", pos) + "value=\"".Length;
            int pos3 = loginStr.IndexOf("\"", pos2);
            string RequestVerificationToken = loginStr.Substring(pos2, pos3 - pos2);
            NameValueCollection loginData = new NameValueCollection();
            loginData.Add("email", "Charles.LeBlanc2@canada.ca");
            loginData.Add("password", "Charles2!");
            loginData.Add("__RequestVerificationToken", RequestVerificationToken);
            byte[] res = client.UploadValues("https://localhost:44353/Identity/Account/Login", "POST", loginData);
            string resStr = System.Text.Encoding.UTF8.GetString(res);
            Console.WriteLine(resStr);

            //Now you are logged in and can request pages    
            string htmlSource = client.DownloadString("https://localhost:44353/api/apperrlogs");

            Console.WriteLine();
            Console.WriteLine(htmlSource);
        }

    }
}
