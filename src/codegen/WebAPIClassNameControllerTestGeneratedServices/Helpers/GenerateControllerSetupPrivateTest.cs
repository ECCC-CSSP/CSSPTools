using System.Text;
using System.Threading.Tasks;

namespace WebAPIClassNameControllerTestGeneratedServices.Services
{
    public partial class WebAPIClassNameControllerTestGeneratedService : IWebAPIClassNameControllerTestGeneratedService
    {
        private async Task<bool> GenerateControllerSetupPrivateTest(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        private async Task<bool> Setup(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Config = new ConfigurationBuilder()");
            sb.AppendLine(@"               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)");
            sb.AppendLine(@"               .AddJsonFile(""appsettings_csspwebapistests.json"")");
            sb.AppendLine(@"               .AddUserSecrets(""9d65c001-b7bc-4922-a0fc-1558b9ef927e"")");
            sb.AppendLine(@"               .Build();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services = new ServiceCollection();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            string CSSPDBLocalFileName = Config.GetValue<string>(""CSSPDBLocal"");");
            sb.AppendLine(@"            Assert.NotNull(CSSPDBLocalFileName);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            string TestDB = Config.GetValue<string>(""TestDB"");");
            sb.AppendLine(@"            Assert.NotNull(TestDB);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<IConfiguration>(Config);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<CSSPDBContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                options.UseSqlServer(TestDB);");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<InMemoryDBContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                options.UseInMemoryDatabase(TestDB);");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace(""{AppDataPath}"", appDataPath));");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<CSSPDBLocalContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                options.UseSqlite($""Data Source={ fiAppDataPath.FullName }"");");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<ApplicationDbContext>(options =>");
            sb.AppendLine(@"                options.UseSqlServer(TestDB));");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddIdentityCore<ApplicationUser>()");
            sb.AppendLine(@"                .AddEntityFrameworkStores<ApplicationDbContext>();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();");
            sb.AppendLine(@"            Services.AddSingleton<IEnums, Enums>();");
            sb.AppendLine(@"            Services.AddSingleton<ILoggedInService, LoggedInService>();");
            sb.AppendLine(@"            Services.AddSingleton<IAspNetUserService, AspNetUserService>();");
            sb.AppendLine(@"            Services.AddSingleton<IContactService, ContactService>();");
            sb.AppendLine($@"            Services.AddSingleton<I{ TypeName }Service, { TypeName }Service>();");
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
            sb.AppendLine(@"            ContactService = Provider.GetService<IContactService>();");
            sb.AppendLine(@"            Assert.NotNull(ContactService);");
            sb.AppendLine(@"");
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
            sb.AppendLine(@"            var actionContact = await ContactService.Login(loginModel);");
            sb.AppendLine(@"            Assert.NotNull(actionContact.Value);");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"            contact2 = actionContact.Value;");
            }
            else
            {
                sb.AppendLine(@"            contact = actionContact.Value;");
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"            loggedInService = Provider.GetService<ILoggedInService>();");
            sb.AppendLine(@"            Assert.NotNull(loggedInService);");
            sb.AppendLine(@"");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"            await loggedInService.SetLoggedInContactInfo(contact2.Id);");
            }
            else
            {
                sb.AppendLine(@"            await loggedInService.SetLoggedInContactInfo(contact.Id);");
            }
            sb.AppendLine(@"            Assert.NotNull(loggedInService.GetLoggedInContactInfo());");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeNameLower }Service = Provider.GetService<I{ TypeName }Service>();");
            sb.AppendLine($@"            Assert.NotNull({ TypeNameLower }Service);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeNameLower }Controller = Provider.GetService<I{ TypeName }Controller>();");
            sb.AppendLine($@"            Assert.NotNull({ TypeNameLower }Controller);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return await Task.FromResult(true);");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
