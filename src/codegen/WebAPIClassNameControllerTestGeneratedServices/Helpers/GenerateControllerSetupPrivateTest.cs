﻿using System.Text;
using System.Threading.Tasks;

namespace WebAPIClassNameControllerTestGeneratedServices.Services
{
    public partial class WebAPIClassNameControllerTestGeneratedService : IWebAPIClassNameControllerTestGeneratedService
    {
        private async Task<bool> GenerateControllerSetupPrivateTest(string TypeName, string TypeNameLower, StringBuilder sb, string WebApiType)
        {
            sb.AppendLine(@"        private async Task<bool> Setup(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Config = new ConfigurationBuilder()");
            sb.AppendLine(@"               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)");
            if (WebApiType == "")
            {
                sb.AppendLine(@"               .AddJsonFile(""appsettings_csspwebapistests.json"")");
                sb.AppendLine(@"               .AddUserSecrets(""e43608c0-3ec4-4b6c-b995-a4be7848ec8b"")");
            }
            if (WebApiType == "Local")
            {
                sb.AppendLine(@"               .AddJsonFile(""appsettings_csspwebapislocaltests.json"")");
                sb.AppendLine(@"               .AddUserSecrets(""61f396b6-8b79-4328-a2b7-a07921135f96"")");
            }
            sb.AppendLine(@"               .Build();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services = new ServiceCollection();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<IConfiguration>(Config);");
            sb.AppendLine(@"");
            if (WebApiType == "")
            {
                sb.AppendLine(@"            CSSPAzureUrl = Config.GetValue<string>(""CSSPAzureUrl"");");
                sb.AppendLine(@"            Assert.NotNull(CSSPAzureUrl);");
            }
            if (WebApiType == "Local")
            {
                sb.AppendLine(@"            CSSPAzureUrl = Config.GetValue<string>(""CSSPAzureUrl"");");
                sb.AppendLine(@"            Assert.NotNull(CSSPAzureUrl);");
                sb.AppendLine(@"");
                sb.AppendLine(@"            LocalUrl = Config.GetValue<string>(""LocalUrl"");");
                sb.AppendLine(@"            Assert.NotNull(LocalUrl);");
            }
            sb.AppendLine(@"");
            if (WebApiType == "")
            {
                sb.AppendLine(@"            string TestDB = Config.GetValue<string>(""TestDB"");");
                sb.AppendLine(@"            Assert.NotNull(TestDB);");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddDbContext<CSSPDBContext>(options =>");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                options.UseSqlServer(TestDB);");
                sb.AppendLine(@"            });");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddDbContext<CSSPDBInMemoryContext>(options =>");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                options.UseInMemoryDatabase(TestDB);");
                sb.AppendLine(@"            });");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddDbContext<ApplicationDbContext>(options =>");
                sb.AppendLine(@"                options.UseSqlServer(TestDB));");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddIdentityCore<ApplicationUser>()");
                sb.AppendLine(@"                .AddEntityFrameworkStores<ApplicationDbContext>();");
                sb.AppendLine(@"");
            }
            if (WebApiType == "Local")
            {
            }
            sb.AppendLine(@"            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();");
            sb.AppendLine(@"            Services.AddSingleton<IEnums, Enums>();");
            if (WebApiType == "")
            {
                sb.AppendLine(@"            Services.AddSingleton<ILoginModelService, LoginModelService>();");
                sb.AppendLine(@"            Services.AddSingleton<IRegisterModelService, RegisterModelService>();");
                sb.AppendLine(@"            Services.AddSingleton<ILoggedInService, LoggedInService>();");
                sb.AppendLine(@"            Services.AddSingleton<IContactDBService, ContactDBService>();");
                sb.AppendLine($@"            Services.AddSingleton<I{ TypeName }DBService, { TypeName }DBService>();");
            }
            if (WebApiType == "Local")
            {
                sb.AppendLine(@"            Services.AddSingleton<ILocalService, LocalService>();");
                sb.AppendLine(@"            Services.AddSingleton<IContactDBLocalService, ContactDBLocalService>();");
                sb.AppendLine($@"            Services.AddSingleton<I{ TypeName }DBLocalService, { TypeName }DBLocalService>();");
            }
            sb.AppendLine($@"            Services.AddSingleton<I{ TypeName }Controller, { TypeName }Controller>();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Provider = Services.BuildServiceProvider();");
            sb.AppendLine(@"            Assert.NotNull(Provider);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            CSSPCultureService = Provider.GetService<ICSSPCultureService>();");
            sb.AppendLine(@"            Assert.NotNull(CSSPCultureService);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            CSSPCultureService.SetCulture(culture);");
            sb.AppendLine(@"");
            if (WebApiType == "")
            {
                sb.AppendLine(@"            string LoginEmail = Config.GetValue<string>(""LoginEmail"");");
                sb.AppendLine(@"            Assert.NotNull(LoginEmail);");
                sb.AppendLine(@"");
                sb.AppendLine(@"            string Password = Password = Config.GetValue<string>(""Password"");");
                sb.AppendLine(@"            Assert.NotNull(Password);");
                sb.AppendLine(@"");
                sb.AppendLine(@"            LoginModel loginModel = new LoginModel()");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                LoginEmail = LoginEmail,");
                sb.AppendLine(@"                Password = Password");
                sb.AppendLine(@"            };");
                sb.AppendLine(@"");
                sb.AppendLine(@"            using (HttpClient httpClient = new HttpClient())");
                sb.AppendLine(@"            {");
                sb.AppendLine($@"                string url = $""{{ CSSPAzureUrl }}api/{{ culture}}/Auth/Token"";");
                sb.AppendLine(@"");
                sb.AppendLine(@"                string content = JsonSerializer.Serialize<LoginModel>(loginModel);");
                sb.AppendLine(@"                HttpContent httpContent = new StringContent(content);");
                sb.AppendLine(@"                httpContent.Headers.ContentType = new MediaTypeHeaderValue(""application/json"");");
                sb.AppendLine(@"");
                sb.AppendLine(@"                var response = await httpClient.PostAsync(url, httpContent);");
                sb.AppendLine(@"");
                sb.AppendLine(@"                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);");
                sb.AppendLine(@"                string responseContent = await response.Content.ReadAsStringAsync();");
                sb.AppendLine(@"                Assert.NotEmpty(responseContent);");
                if (TypeName == "Contact")
                {
                    sb.AppendLine(@"                contact2 = JsonSerializer.Deserialize<Contact>(responseContent);");
                    sb.AppendLine(@"                Assert.NotNull(contact2);");
                    sb.AppendLine(@"                Assert.NotEmpty(contact2.Token);");
                }
                else
                {
                    sb.AppendLine(@"                contact = JsonSerializer.Deserialize<Contact>(responseContent);");
                    sb.AppendLine(@"                Assert.NotNull(contact);");
                    sb.AppendLine(@"                Assert.NotEmpty(contact.Token);");
                }
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
                sb.AppendLine(@"            LoggedInService = Provider.GetService<ILoggedInService>();");
                sb.AppendLine(@"            Assert.NotNull(LoggedInService);");
                sb.AppendLine(@"");
                if (TypeName == "Contact")
                {
                    sb.AppendLine(@"            await LoggedInService.SetLoggedInContactInfo(contact2.Id);");
                }
                else
                {
                    sb.AppendLine(@"            await LoggedInService.SetLoggedInContactInfo(contact.Id);");
                }
                sb.AppendLine(@"            Assert.NotNull(LoggedInService.LoggedInContactInfo);");
                sb.AppendLine(@"");
                sb.AppendLine($@"            { TypeName }DBService = Provider.GetService<I{ TypeName }DBService>();");
                sb.AppendLine($@"            Assert.NotNull({ TypeName }DBService);");
                sb.AppendLine(@"");
                sb.AppendLine($@"            { TypeName }Controller = Provider.GetService<I{ TypeName }Controller>();");
                sb.AppendLine($@"            Assert.NotNull({ TypeName }Controller);");
                sb.AppendLine(@"");
            }
            if (WebApiType == "Local")
            {
                sb.AppendLine(@"            LocalService = Provider.GetService<ILocalService>();");
                sb.AppendLine(@"            Assert.NotNull(LocalService);");
                sb.AppendLine(@"");
                if (TypeName == "Contact")
                {
                    sb.AppendLine(@"            await LocalService.SetLoggedInContactInfo();");
                }
                else
                {
                    sb.AppendLine(@"            await LocalService.SetLoggedInContactInfo();");
                }
                sb.AppendLine(@"            Assert.NotNull(LocalService.LoggedInContactInfo);");
                sb.AppendLine(@"");
                sb.AppendLine($@"            { TypeName }DBLocalService = Provider.GetService<I{ TypeName }DBLocalService>();");
                sb.AppendLine($@"            Assert.NotNull({ TypeName }DBLocalService);");
                sb.AppendLine(@"");
                sb.AppendLine($@"            { TypeName }Controller = Provider.GetService<I{ TypeName }Controller>();");
                sb.AppendLine($@"            Assert.NotNull({ TypeName }Controller);");
                sb.AppendLine(@"");
            }

            sb.AppendLine(@"            return await Task.FromResult(true);");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
