using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> GenerateSetupTestCode(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        private async Task<bool> Setup(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Config = new ConfigurationBuilder()");
            sb.AppendLine(@"               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)");
            sb.AppendLine(@"               .AddJsonFile(""appsettings_csspservices.json"")");
            sb.AppendLine(@"               .AddUserSecrets(""6f27cbbe-6ffb-4154-b49b-d739597c4f60"")");
            sb.AppendLine(@"               .Build();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services = new ServiceCollection();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<IConfiguration>(Config);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            string CSSPDBLocalFileName = Config.GetValue<string>(""CSSPDBLocal"");");
            sb.AppendLine(@"            Assert.NotNull(CSSPDBLocalFileName);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            string TestDBConnString = Config.GetValue<string>(""TestDB"");");
            sb.AppendLine(@"            Assert.NotNull(TestDBConnString);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<CSSPDBContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                options.UseSqlServer(TestDBConnString);");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<InMemoryDBContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                options.UseInMemoryDatabase(TestDBConnString);");
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
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"            Services.AddDbContext<ApplicationDbContext>(options =>");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                options.UseSqlServer(TestDBConnString);");
                sb.AppendLine(@"            });");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddIdentityCore<ApplicationUser>()");
                sb.AppendLine(@"                .AddEntityFrameworkStores<ApplicationDbContext>();");
                sb.AppendLine(@"");
            }
            else
            {
            }
            sb.AppendLine(@"            Services.AddSingleton<ICultureService, CultureService>();");
            sb.AppendLine(@"            Services.AddSingleton<ILoggedInService, LoggedInService>();");
            sb.AppendLine(@"            Services.AddSingleton<IEnums, Enums>();");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"            Services.AddSingleton<IAspNetUserService, AspNetUserService>();");
            }
            else
            {
            }
            sb.AppendLine($@"            Services.AddSingleton<I{ TypeName }Service, { TypeName }Service>();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Provider = Services.BuildServiceProvider();");
            sb.AppendLine(@"            Assert.NotNull(Provider);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            CultureService = Provider.GetService<ICultureService>();");
            sb.AppendLine(@"            Assert.NotNull(CultureService);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            CultureService.SetCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            LoggedInService = Provider.GetService<ILoggedInService>();");
            sb.AppendLine(@"            Assert.NotNull(LoggedInService);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            string Id = Config.GetValue<string>(""Id"");");
            sb.AppendLine(@"            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));");
            sb.AppendLine(@"");
            sb.AppendLine(@"            LoggedInService.DBLocation = DBLocationEnum.Local;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            dbIM = Provider.GetService<InMemoryDBContext>();");
            sb.AppendLine(@"            Assert.NotNull(dbIM);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            dbLocal = Provider.GetService<CSSPDBLocalContext>();");
            sb.AppendLine(@"            Assert.NotNull(dbLocal);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeName }Service = Provider.GetService<I{ TypeName }Service>();");
            sb.AppendLine($@"            Assert.NotNull({ TypeName }Service);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return await Task.FromResult(true);");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
