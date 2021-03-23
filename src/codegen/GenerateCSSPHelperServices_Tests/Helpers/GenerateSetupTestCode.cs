//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace GenerateCSSPHelperServices_Tests
//{
//    public partial class Startup
//    {
//        private async Task<bool> GenerateSetupTestCode(string TypeName, string TypeNameLower, StringBuilder sb)
//        {
//            sb.AppendLine(@"        private async Task<bool> Setup(string culture)");
//            sb.AppendLine(@"        {");
//            sb.AppendLine(@"            Configuration = new ConfigurationBuilder()");
//            sb.AppendLine(@"               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)");
//            sb.AppendLine(@"               .AddJsonFile(""appsettings_csspdbservicestests.json"")");
//            sb.AppendLine(@"               .AddUserSecrets(""70c662c1-a1a8-4b2c-b594-d7834bb5e6db"")");
//            sb.AppendLine(@"               .Build();");
//            sb.AppendLine(@"");
//            sb.AppendLine(@"            Services = new ServiceCollection();");
//            sb.AppendLine(@"");
//            sb.AppendLine(@"            Services.AddSingleton<IConfiguration>(Configuration);");
//            sb.AppendLine(@"");
//            sb.AppendLine(@"            string CSSPDBConnString = Config.GetValue<string>(""TestDB"");");
//            sb.AppendLine(@"            Assert.NotNull(CSSPDBConnString);");
//            sb.AppendLine(@"");
//            sb.AppendLine(@"            Services.AddDbContext<CSSPDBContext>(options =>");
//            sb.AppendLine(@"            {");
//            sb.AppendLine(@"                options.UseSqlServer(CSSPDBConnString);");
//            sb.AppendLine(@"            });");
//            sb.AppendLine(@"");
//            sb.AppendLine(@"            Services.AddDbContext<ApplicationDbContext>(options =>");
//            sb.AppendLine(@"            {");
//            sb.AppendLine(@"                options.UseSqlServer(CSSPDBConnString);");
//            sb.AppendLine(@"            });");
//            sb.AppendLine(@"");
//            sb.AppendLine(@"            Services.AddIdentityCore<ApplicationUser>()");
//            sb.AppendLine(@"                .AddEntityFrameworkStores<ApplicationDbContext>();");
//            sb.AppendLine(@"");
//            sb.AppendLine(@"            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();");
//            sb.AppendLine(@"            Services.AddSingleton<ILoggedInService, LoggedInService>();");
//            sb.AppendLine(@"            Services.AddSingleton<IEnums, Enums>();");
//            if (TypeName == "Contact")
//            {
//                sb.AppendLine(@"            Services.AddSingleton<ILoginModelService, LoginModelService>();");
//                sb.AppendLine(@"            Services.AddSingleton<IRegisterModelService, RegisterModelService>();");
//            }
//            else
//            {
//            }
//            sb.AppendLine($@"            Services.AddSingleton<I{ TypeName }DBService, { TypeName }DBService>();");
//            sb.AppendLine(@"");
//            sb.AppendLine(@"            Provider = Services.BuildServiceProvider();");
//            sb.AppendLine(@"            Assert.NotNull(Provider);");
//            sb.AppendLine(@"");
//            sb.AppendLine(@"            CSSPCultureService = Provider.GetService<ICSSPCultureService>();");
//            sb.AppendLine(@"            Assert.NotNull(CSSPCultureService);");
//            sb.AppendLine(@"");
//            sb.AppendLine(@"            CSSPCultureService.SetCulture(culture);");
//            sb.AppendLine(@"");
//            sb.AppendLine(@"            LoggedInService = Provider.GetService<ILoggedInService>();");
//            sb.AppendLine(@"            Assert.NotNull(LoggedInService);");
//            sb.AppendLine(@"");
//            sb.AppendLine(@"            string Id = Config.GetValue<string>(""Id"");");
//            sb.AppendLine(@"            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));");
//            sb.AppendLine(@"");
//            sb.AppendLine(@"            db = Provider.GetService<CSSPDBContext>();");
//            sb.AppendLine(@"            Assert.NotNull(db);");
//            sb.AppendLine(@"");
//            sb.AppendLine($@"            { TypeName }DBService = Provider.GetService<I{ TypeName }DBService>();");
//            sb.AppendLine($@"            Assert.NotNull({ TypeName }DBService);");
//            sb.AppendLine(@"");
//            sb.AppendLine(@"            return await Task.FromResult(true);");
//            sb.AppendLine(@"        }");

//            return await Task.FromResult(true);
//        }
//    }
//}
