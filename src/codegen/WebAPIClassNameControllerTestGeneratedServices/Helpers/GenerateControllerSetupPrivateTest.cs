using System.Text;
using System.Threading.Tasks;

namespace WebAPIClassNameControllerTestGeneratedServices.Services
{
    public partial class WebAPIClassNameControllerTestGeneratedService : IWebAPIClassNameControllerTestGeneratedService
    {
        private async Task<bool> GenerateControllerSetupPrivateTest(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        private async Task<bool> Setup(CultureInfo culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Config = new ConfigurationBuilder()");
            sb.AppendLine(@"               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)");
            sb.AppendLine(@"               .AddJsonFile(""appsettings.json"")");
            sb.AppendLine(@"               .Build();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services = new ServiceCollection();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            IConfigurationSection connectionStringsSection = Config.GetSection(""ConnectionStrings"");");
            sb.AppendLine(@"            Services.Configure<ConnectionStringsModel>(connectionStringsSection);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            ConnectionStringsModel connectionStrings = connectionStringsSection.Get<ConnectionStringsModel>();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<IConfiguration>(Config);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<CSSPDBContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                options.UseSqlServer(connectionStrings.TestDB);");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<ApplicationDbContext>(options =>");
            sb.AppendLine(@"                options.UseSqlServer(connectionStrings.TestDB));");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddIdentityCore<ApplicationUser>()");
            sb.AppendLine(@"                .AddEntityFrameworkStores<ApplicationDbContext>();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<IEnums, Enums>();");
            sb.AppendLine(@"            Services.AddSingleton<ILoggedInService, LoggedInService>();");
            sb.AppendLine($@"            Services.AddSingleton<I{ TypeName }Service, { TypeName }Service>();");
            sb.AppendLine($@"            Services.AddSingleton<I{ TypeName }Controller, { TypeName }Controller>();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Provider = Services.BuildServiceProvider();");
            sb.AppendLine(@"            Assert.NotNull(Provider);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            loggedInService = Provider.GetService<ILoggedInService>();");
            sb.AppendLine(@"            Assert.NotNull(loggedInService);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeNameLower }Service = Provider.GetService<I{ TypeName }Service>();");
            sb.AppendLine($@"            Assert.NotNull({ TypeNameLower }Service);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            await { TypeNameLower }Service.SetCulture(culture);");
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
