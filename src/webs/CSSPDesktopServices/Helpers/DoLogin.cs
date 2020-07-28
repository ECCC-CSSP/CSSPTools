using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService
    {
        public enum ContactTitleEnum
        {
            DirectorGeneral = 1,
            DirectorPublicWorks = 2,
            Superintendent = 3,
            Engineer = 4,
            Foreman = 5,
            Operator = 6,
            FacilitiesManager = 7,
            Supervisor = 8,
            Technician = 9,
        }

        public class LoginModel
        {
            public string LoginEmail { get; set; }
            public string Password { get; set; }
        }

        public partial class Contact
        {
            public int ContactID { get; set; }
            public string Id { get; set; }
            public int ContactTVItemID { get; set; }
            public string LoginEmail { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Initial { get; set; }
            public string WebName { get; set; }
            public ContactTitleEnum? ContactTitle { get; set; }
            public bool IsAdmin { get; set; }
            public bool EmailValidated { get; set; }
            public bool Disabled { get; set; }
            public bool IsNew { get; set; }
            public string SamplingPlanner_ProvincesTVItemID { get; set; }
            public string Token { get; set; }
            public DateTime LastUpdateDate_UTC { get; set; }
            public int LastUpdateContactTVItemID { get; set; }
        }

            private async Task<bool> DoLogin(string LoginEmail, string Password)
        {
            if (string.IsNullOrWhiteSpace(LoginEmail))
            {
                AppendTempStatus(new AppendTempEventArgs("LoginEmail is required"));
                return await Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                AppendTempStatus(new AppendTempEventArgs("Password is required"));
                return await Task.FromResult(false);
            }

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                LoginModel loginModel = new LoginModel()
                {
                    LoginEmail = LoginEmail,
                    Password = Password
                };

                string stringData = JsonSerializer.Serialize(loginModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync(ServerLoginUrl, contentData).Result;
                Contact contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);
                AppendStatus(new AppendEventArgs(contact.Token));
            }

            return await Task.FromResult(true);
        }
    }
}
