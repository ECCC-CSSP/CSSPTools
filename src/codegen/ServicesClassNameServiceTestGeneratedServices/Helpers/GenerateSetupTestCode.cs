using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> GenerateSetupTestCode(string TypeName, string TypeNameLower, StringBuilder sb, string DBType)
        {
            sb.AppendLine(@"        private async Task<bool> Setup(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Config = new ConfigurationBuilder()");
            sb.AppendLine(@"               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)");
            if (DBType == "DB")
            {
                sb.AppendLine(@"               .AddJsonFile(""appsettings_csspdbservicestests.json"")");
                sb.AppendLine(@"               .AddUserSecrets(""70c662c1-a1a8-4b2c-b594-d7834bb5e6db"")");
            }
            if (DBType == "DBLocal")
            {
                sb.AppendLine(@"               .AddJsonFile(""appsettings_csspdblocalservicestests.json"")");
                sb.AppendLine(@"               .AddUserSecrets(""91a273aa-0169-4298-82eb-86ff2429a2f8"")");
            }
            if (DBType == "DBLocalIM")
            {
                sb.AppendLine(@"               .AddJsonFile(""appsettings_csspdblocalimservicestests.json"")");
                sb.AppendLine(@"               .AddUserSecrets(""64a6d1e4-0d0c-4e59-9c2e-640182417704"")");
            }
            sb.AppendLine(@"               .Build();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services = new ServiceCollection();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<IConfiguration>(Config);");
            sb.AppendLine(@"");
            if (DBType == "DB")
            {
                sb.AppendLine(@"            string CSSPDBConnString = Config.GetValue<string>(""TestDB"");");
                sb.AppendLine(@"            Assert.NotNull(CSSPDBConnString);");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddDbContext<CSSPDBContext>(options =>");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                options.UseSqlServer(CSSPDBConnString);");
                sb.AppendLine(@"            });");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddDbContext<CSSPDBInMemoryContext>(options =>");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                options.UseInMemoryDatabase(CSSPDBConnString);");
                sb.AppendLine(@"            });");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddDbContext<ApplicationDbContext>(options =>");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                options.UseSqlServer(CSSPDBConnString);");
                sb.AppendLine(@"            });");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddIdentityCore<ApplicationUser>()");
                sb.AppendLine(@"                .AddEntityFrameworkStores<ApplicationDbContext>();");
                sb.AppendLine(@"");
            }
            if (DBType == "DBLocal")
            {
                sb.AppendLine(@"            string CSSPDBLoginFileName = Config.GetValue<string>(""CSSPDBLogin"");");
                sb.AppendLine(@"            Assert.NotNull(CSSPDBLoginFileName);");
                sb.AppendLine(@"");
                sb.AppendLine(@"            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddDbContext<CSSPDBLoginContext>(options =>");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                options.UseSqlite($""Data Source={ fiCSSPDBLogin.FullName }"");");
                sb.AppendLine(@"            });");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                options.UseSqlite($""Data Source={ fiCSSPDBLogin.FullName }"");");
                sb.AppendLine(@"            });");
                sb.AppendLine(@"");
                sb.AppendLine(@"            string CSSPDBLocalFileName = Config.GetValue<string>(""CSSPDBLocal"");");
                sb.AppendLine(@"            Assert.NotNull(CSSPDBLocalFileName);");
                sb.AppendLine(@"");
                sb.AppendLine(@"            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddDbContext<CSSPDBLocalContext>(options =>");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                options.UseSqlite($""Data Source={ fiCSSPDBLocal.FullName }"");");
                sb.AppendLine(@"            });");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddDbContext<CSSPDBInMemoryContext>(options =>");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                options.UseInMemoryDatabase($""Data Source={ fiCSSPDBLocal.FullName }"");");
                sb.AppendLine(@"            });");
                sb.AppendLine(@"");
            }
            if (DBType == "DBLocalIM")
            {
                sb.AppendLine(@"            string CSSPDBLoginFileName = Config.GetValue<string>(""CSSPDBLogin"");");
                sb.AppendLine(@"            Assert.NotNull(CSSPDBLoginFileName);");
                sb.AppendLine(@"");
                sb.AppendLine(@"            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddDbContext<CSSPDBLoginContext>(options =>");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                options.UseSqlite($""Data Source={ fiCSSPDBLogin.FullName }"");");
                sb.AppendLine(@"            });");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                options.UseSqlite($""Data Source={ fiCSSPDBLogin.FullName }"");");
                sb.AppendLine(@"            });");
                sb.AppendLine(@"");
                sb.AppendLine(@"            string CSSPDBLocalFileName = Config.GetValue<string>(""CSSPDBLocal"");");
                sb.AppendLine(@"            Assert.NotNull(CSSPDBLocalFileName);");
                sb.AppendLine(@"");
                sb.AppendLine(@"            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);");
                sb.AppendLine(@"");
                sb.AppendLine(@"            Services.AddDbContext<CSSPDBInMemoryContext>(options =>");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                options.UseInMemoryDatabase($""Data Source={ fiCSSPDBLocal.FullName }"");");
                sb.AppendLine(@"            });");
                sb.AppendLine(@"");
            }
            sb.AppendLine(@"            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();");
            if (DBType == "DB")
            {
                sb.AppendLine(@"            Services.AddSingleton<ILoggedInService, LoggedInService>();");
            }
            if (DBType == "DBLocal")
            {
                sb.AppendLine(@"            Services.AddSingleton<ILocalService, LocalService>();");
            }
            if (DBType == "DBLocalIM")
            {
                sb.AppendLine(@"            Services.AddSingleton<ILocalService, LocalService>();");
            }
            sb.AppendLine(@"            Services.AddSingleton<IEnums, Enums>();");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"            Services.AddSingleton<ILoginModelService, LoginModelService>();");
                sb.AppendLine(@"            Services.AddSingleton<IRegisterModelService, RegisterModelService>();");
            }
            else
            {
            }
            sb.AppendLine($@"            Services.AddSingleton<I{ TypeName }{ DBType }Service, { TypeName }{ DBType }Service>();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Provider = Services.BuildServiceProvider();");
            sb.AppendLine(@"            Assert.NotNull(Provider);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            CSSPCultureService = Provider.GetService<ICSSPCultureService>();");
            sb.AppendLine(@"            Assert.NotNull(CSSPCultureService);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            CSSPCultureService.SetCulture(culture);");
            sb.AppendLine(@"");
            if (DBType == "DB")
            {
                sb.AppendLine(@"            LoggedInService = Provider.GetService<ILoggedInService>();");
                sb.AppendLine(@"            Assert.NotNull(LoggedInService);");
            }
            if (DBType == "DBLocal")
            {
                sb.AppendLine(@"            LocalService = Provider.GetService<ILocalService>();");
                sb.AppendLine(@"            Assert.NotNull(LocalService);");
            }
            if (DBType == "DBLocalIM")
            {
                sb.AppendLine(@"            LocalService = Provider.GetService<ILocalService>();");
                sb.AppendLine(@"            Assert.NotNull(LocalService);");
            }
            sb.AppendLine(@"");
            if (DBType == "DB")
            {
                sb.AppendLine(@"            string Id = Config.GetValue<string>(""Id"");");
                sb.AppendLine(@"            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));");
            }
            if (DBType == "DBLocal")
            {
                sb.AppendLine(@"            Assert.True(await LocalService.SetLoggedInContactInfo());");
            }
            if (DBType == "DBLocalIM")
            {
                sb.AppendLine(@"            Assert.True(await LocalService.SetLoggedInContactInfo());");
            }
            sb.AppendLine(@"");
            if (DBType == "DB")
            {
                sb.AppendLine(@"            db = Provider.GetService<CSSPDBContext>();");
                sb.AppendLine(@"            Assert.NotNull(db);");
            }
            if (DBType == "DBLocal")
            {
                sb.AppendLine(@"            dbLocal = Provider.GetService<CSSPDBLocalContext>();");
                sb.AppendLine(@"            Assert.NotNull(dbLocal);");
                sb.AppendLine(@"");
                sb.AppendLine(@"            dbLocalIM = Provider.GetService<CSSPDBInMemoryContext>();");
                sb.AppendLine(@"            Assert.NotNull(dbLocalIM);");
            }
            if (DBType == "DBLocalIM")
            {
                sb.AppendLine(@"            dbLocalIM = Provider.GetService<CSSPDBInMemoryContext>();");
                sb.AppendLine(@"            Assert.NotNull(dbLocalIM);");
            }
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeName }{ DBType }Service = Provider.GetService<I{ TypeName }{ DBType }Service>();");
            sb.AppendLine($@"            Assert.NotNull({ TypeName }{ DBType }Service);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return await Task.FromResult(true);");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
