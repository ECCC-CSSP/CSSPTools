using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPHelperServices_Tests
{
    public partial class Startup
    {
        private async Task<bool> GenerateSetupTestCodeNotMapped(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        private async Task<bool> Setup(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Configuration = new ConfigurationBuilder()");
            sb.AppendLine(@"               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)");
            sb.AppendLine(@"               .AddJsonFile(""appsettings_cssphelperservicestests.json"")");
            sb.AppendLine(@"               .AddUserSecrets(""a79b4a81-ba75-4dfc-8d95-46259f73f055"")");
            sb.AppendLine(@"               .Build();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services = new ServiceCollection();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<IConfiguration>(Configuration);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();");
            sb.AppendLine(@"            Services.AddSingleton<IEnums, Enums>();");
            sb.AppendLine($@"            Services.AddSingleton<I{ TypeName }Service, { TypeName }Service>();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Provider = Services.BuildServiceProvider();");
            sb.AppendLine(@"            Assert.NotNull(Provider);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            CSSPCultureService = Provider.GetService<ICSSPCultureService>();");
            sb.AppendLine(@"            Assert.NotNull(CSSPCultureService);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            CSSPCultureService.SetCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            enums = Provider.GetService<IEnums>();");
            sb.AppendLine(@"            Assert.NotNull(enums);");
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
