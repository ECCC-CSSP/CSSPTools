using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices_Tests
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
            sb.AppendLine(@"               .AddUserSecrets(""a79b4a81-ba75-4dfc-8d95-46259f73f055"")");
            sb.AppendLine(@"               .Build();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services = new ServiceCollection();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<IConfiguration>(Configuration);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            string CSSPDBConnString = Configuration.GetValue<string>(""TestDB"");");
            sb.AppendLine(@"            Assert.NotNull(CSSPDBConnString);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<CSSPDBContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                options.UseSqlServer(CSSPDBConnString);");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();");
            sb.AppendLine(@"            Services.AddSingleton<IScrambleService, ScrambleService>();");
            sb.AppendLine(@"            Services.AddSingleton<ILoggedInService, LoggedInService>();");
            sb.AppendLine(@"            Services.AddSingleton<IEnums, Enums>();");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"            Services.AddSingleton<ILoginModelService, LoginModelService>();");
                sb.AppendLine(@"            Services.AddSingleton<IRegisterModelService, RegisterModelService>();");
                sb.AppendLine(@"            Services.AddSingleton<IScrambleService, ScrambleService>();");
            }
            else
            {
            }
            sb.AppendLine($@"            Services.AddSingleton<I{ TypeName }DBService, { TypeName }DBService>();");
            sb.AppendLine($@"");
            sb.AppendLine($@"            /* ---------------------------------------------------------------------------------");
            sb.AppendLine($@"             * using TestDB");
            sb.AppendLine($@"             * ---------------------------------------------------------------------------------      ");
            sb.AppendLine($@"             */");
            sb.AppendLine($@"            string TestDB = Configuration.GetValue<string>(""TestDB"");");
            sb.AppendLine($@"            Assert.NotNull(TestDB);");
            sb.AppendLine($@"");
            sb.AppendLine($@"            Services.AddDbContext<CSSPDBContext>(options =>");
            sb.AppendLine($@"            {{");
            sb.AppendLine($@"                options.UseSqlServer(TestDB);");
            sb.AppendLine($@"            }});");
            sb.AppendLine($@"");
            sb.AppendLine($@"            /* ---------------------------------------------------------------------------------");
            sb.AppendLine($@"             * CSSPDBManageContext");
            sb.AppendLine($@"             * ---------------------------------------------------------------------------------");
            sb.AppendLine($@"             */");
            sb.AppendLine($@"            string CSSPDBManage = Configuration.GetValue<string>(""CSSPDBManage""); ");
            sb.AppendLine($@"            Assert.NotNull(CSSPDBManage);");
            sb.AppendLine($@"");
            sb.AppendLine($@"            FileInfo fiCSSPDBManage = new FileInfo(CSSPDBManage);");
            sb.AppendLine($@"");
            sb.AppendLine($@"            Services.AddDbContext<CSSPDBManageContext>(options =>");
            sb.AppendLine($@"            {{");
            sb.AppendLine($@"                options.UseSqlite($""Data Source={{ fiCSSPDBManage.FullName }}"");");
            sb.AppendLine($@"            }});");
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
            sb.AppendLine(@"            string LoginEmail = Configuration.GetValue<string>(""LoginEmail"");");
            sb.AppendLine(@"            Assert.True(await LoggedInService.SetLoggedInContactInfo(LoginEmail));");
            sb.AppendLine(@"");
            sb.AppendLine(@"            db = Provider.GetService<CSSPDBContext>();");
            sb.AppendLine(@"            Assert.NotNull(db);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            dbIM = Provider.GetService<CSSPDBContext>();");
            sb.AppendLine(@"            Assert.NotNull(dbIM);");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"");
                sb.AppendLine($@"            ScrambleService = Provider.GetService<IScrambleService>();");
                sb.AppendLine($@"            Assert.NotNull(ScrambleService);");
            }
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
