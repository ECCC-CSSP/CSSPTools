using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPWebAPIsLocal_TestsController
{
    public partial class Startup
    {
        private async Task<bool> GenerateControllerSetupPrivateTest(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        private async Task<bool> Setup(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Config = new ConfigurationBuilder()");
            sb.AppendLine(@"               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)");
            sb.AppendLine(@"               .AddJsonFile(""appsettings_csspwebapislocaltests.json"")");
            sb.AppendLine(@"               .AddUserSecrets(""61f396b6-8b79-4328-a2b7-a07921135f96"")");
            sb.AppendLine(@"               .Build();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services = new ServiceCollection();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<IConfiguration>(Config);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            CSSPAzureUrl = Config.GetValue<string>(""CSSPAzureUrl"");");
            sb.AppendLine(@"            Assert.NotNull(CSSPAzureUrl);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            LocalUrl = Config.GetValue<string>(""LocalUrl"");");
            sb.AppendLine(@"            Assert.NotNull(LocalUrl);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();");
            sb.AppendLine(@"            Services.AddSingleton<IEnums, Enums>();");
            sb.AppendLine(@"            Services.AddSingleton<ILocalService, LocalService>();");
            sb.AppendLine(@"            Services.AddSingleton<ILocalContactDBService, LocalContactDBService>();");
            sb.AppendLine($@"            Services.AddSingleton<I{ TypeName }DBService, { TypeName }DBService>();");
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
            sb.AppendLine($@"            { TypeName }DBService = Provider.GetService<I{ TypeName }DBService>();");
            sb.AppendLine($@"            Assert.NotNull({ TypeName }DBService);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeName }Controller = Provider.GetService<I{ TypeName }Controller>();");
            sb.AppendLine($@"            Assert.NotNull({ TypeName }Controller);");
            sb.AppendLine(@"");

            sb.AppendLine(@"            return await Task.FromResult(true);");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
