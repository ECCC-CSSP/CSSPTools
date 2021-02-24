using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBLocalServices_Tests
{
    public partial class Startup
    {
        private async Task<bool> GenerateSetupTestCode(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        private async Task<bool> Setup(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Configuration = new ConfigurationBuilder()");
            sb.AppendLine(@"               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)");
            sb.AppendLine(@"               .AddJsonFile(""appsettings_csspdbservicestests.json"")");
            sb.AppendLine(@"               .AddUserSecrets(""91a273aa-0169-4298-82eb-86ff2429a2f8"")");
            sb.AppendLine(@"               .Build();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services = new ServiceCollection();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<IConfiguration>(Configuration);");
            sb.AppendLine(@"");

            sb.AppendLine(@"            string CSSPDBConnString = Config.GetValue<string>(""TestDB"");");
            sb.AppendLine(@"            Assert.NotNull(CSSPDBConnString);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<CSSPDBContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                options.UseSqlServer(CSSPDBConnString);");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<ApplicationDbContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                options.UseSqlServer(CSSPDBConnString);");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddIdentityCore<ApplicationUser>()");
            sb.AppendLine(@"                .AddEntityFrameworkStores<ApplicationDbContext>();");


            sb.AppendLine(@"            /* ---------------------------------------------------------------------------------");
            sb.AppendLine(@"             * using CSSPDBLocalContext");
            sb.AppendLine(@"             * ---------------------------------------------------------------------------------      ");
            sb.AppendLine(@"             */");
            sb.AppendLine(@"            string CSSPDBLocal = Config.GetValue<string>(""CSSPDBLocal"");");
            sb.AppendLine(@"            Assert.NotNull(CSSPDBLocal);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<CSSPDBLocalContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                options.UseSqlite($""Data Source={{ fiCSSPDBLocal.FullName }}"");");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();");
            sb.AppendLine(@"            Services.AddSingleton<ILoggedInService, LoggedInService>();");
            sb.AppendLine(@"            Services.AddSingleton<IEnums, Enums>();");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"            Services.AddSingleton<ILoginModelService, LoginModelService>();");
                sb.AppendLine(@"            Services.AddSingleton<IRegisterModelService, RegisterModelService>();");
            }
            else
            {
            }
            sb.AppendLine($@"            Services.AddSingleton<I{ TypeName }DBService, { TypeName }DBService>();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Provider = Services.BuildServiceProvider();");
            sb.AppendLine(@"            Assert.NotNull(Provider);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            CSSPCultureService = Provider.GetService<ICSSPCultureService>();");
            sb.AppendLine(@"            Assert.NotNull(CSSPCultureService);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            CSSPCultureService.SetCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            LoggedInService = Provider.GetService<ILoggedInService>();");
            sb.AppendLine(@"            Assert.NotNull(LoggedInService);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Assert.True(await LoggedInService.SetLoggedInLocalContactInfo());");
            sb.AppendLine(@"");
            sb.AppendLine(@"            dbLocal = Provider.GetService<CSSPDBLocalContext>();");
            sb.AppendLine(@"            Assert.NotNull(dbLocal);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeName }DBService = Provider.GetService<I{ TypeName }DBService>();");
            sb.AppendLine($@"            Assert.NotNull({ TypeName }DBService);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return await Task.FromResult(true);");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
