﻿using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPWebAPIsLocal_TestsController
{
    public partial class Startup
    {
        private async Task<bool> GenerateControllerSetupPrivateTest(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        private async Task<bool> Setup(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Configuration = new ConfigurationBuilder()");
            sb.AppendLine(@"               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)");
            sb.AppendLine(@"               .AddJsonFile(""appsettings_csspwebapislocaltests.json"")");
            sb.AppendLine(@"               .AddUserSecrets(""61f396b6-8b79-4328-a2b7-a07921135f96"")");
            sb.AppendLine(@"               .Build();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services = new ServiceCollection();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<IConfiguration>(Configuration);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            CSSPAzureUrl = Config.GetValue<string>(""CSSPAzureUrl"");");
            sb.AppendLine(@"            Assert.NotNull(CSSPAzureUrl);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            LocalUrl = Config.GetValue<string>(""LocalUrl"");");
            sb.AppendLine(@"            Assert.NotNull(LocalUrl);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            /* ---------------------------------------------------------------------------------");
            sb.AppendLine(@"             * using TestDB");
            sb.AppendLine(@"             * ---------------------------------------------------------------------------------");
            sb.AppendLine(@"             */");
            sb.AppendLine(@"            string TestDB = Config.GetValue<string>(""TestDB"");");
            sb.AppendLine(@"            Assert.NotNull(TestDB);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<CSSPDBContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                options.UseSqlServer(TestDB);");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            /* ---------------------------------------------------------------------------------");
            sb.AppendLine(@"             * using CSSPDBLocal ");
            sb.AppendLine(@"             * ---------------------------------------------------------------------------------      ");
            sb.AppendLine(@"             */");
            sb.AppendLine(@"            string CSSPDBLocalFileName = Config.GetValue<string>(""CSSPDBLocal"");");
            sb.AppendLine(@"");
            sb.AppendLine(@"            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<CSSPDBContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                options.UseSqlite($""Data Source={{ fiCSSPDBLocal.FullName }}"");");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            /* ---------------------------------------------------------------------------------");
            sb.AppendLine(@"             * using CSSPDBPreference");
            sb.AppendLine(@"             * ---------------------------------------------------------------------------------      ");
            sb.AppendLine(@"             */");
            sb.AppendLine(@"            string CSSPDBPreferenceFileName = Config.GetValue<string>(""CSSPDBPreference"");");
            sb.AppendLine(@"");
            sb.AppendLine(@"            FileInfo fiCSSPDBPreference = new FileInfo(CSSPDBPreferenceFileName);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<CSSPDBPreferenceContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                options.UseSqlite($""Data Source={{ fiCSSPDBPreference.FullName }}"");");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            /* ---------------------------------------------------------------------------------");
            sb.AppendLine(@"             * using CSSPDBFileManagement");
            sb.AppendLine(@"             * ---------------------------------------------------------------------------------      ");
            sb.AppendLine(@"             */");
            sb.AppendLine(@"            string CSSPDBFilesManagementFileName = Config.GetValue<string>(""CSSPDBFilesManagement"");");
            sb.AppendLine(@"");
            sb.AppendLine(@"            FileInfo fiCSSPDBFilesManagement = new FileInfo(CSSPDBFilesManagementFileName);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                options.UseSqlite($""Data Source={{ fiCSSPDBFilesManagement.FullName }}"");");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            /* ---------------------------------------------------------------------------------");
            sb.AppendLine(@"             * using CSSPDBCommandLog");
            sb.AppendLine(@"             * ---------------------------------------------------------------------------------      ");
            sb.AppendLine(@"             */");
            sb.AppendLine(@"            string CSSPDBCommandLogFileName = Config.GetValue<string>(""CSSPDBCommandLog"");");
            sb.AppendLine(@"");
            sb.AppendLine(@"            FileInfo fiCSSPDBCommandLog = new FileInfo(CSSPDBCommandLogFileName);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<CSSPDBCommandLogContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                options.UseSqlite($""Data Source={{ fiCSSPDBCommandLog.FullName }}"");");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            /* ---------------------------------------------------------------------------------");
            sb.AppendLine(@"             * using CSSPDBSearch");
            sb.AppendLine(@"             * ---------------------------------------------------------------------------------      ");
            sb.AppendLine(@"             */");
            sb.AppendLine(@"            string CSSPDBSearchFileName = Config.GetValue<string>(""CSSPDBSearch"");");
            sb.AppendLine(@"");
            sb.AppendLine(@"            FileInfo fiCSSPDBSearch = new FileInfo(CSSPDBSearchFileName);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddDbContext<CSSPDBSearchContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                options.UseSqlite($""Data Source={{ fiCSSPDBSearch.FullName }}"");");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();");
            sb.AppendLine(@"            Services.AddSingleton<IEnums, Enums>();");
            sb.AppendLine(@"            Services.AddSingleton<IScrambleService, ScrambleService>();");
            sb.AppendLine(@"            Services.AddSingleton<IPreferenceService, PreferenceService>();");
            sb.AppendLine(@"            Services.AddSingleton<ILoggedInService, LoggedInService>();");
            sb.AppendLine(@"            Services.AddSingleton<IContactDBService, ContactDBService>();");
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
            sb.AppendLine(@"            LoggedInService = Provider.GetService<ILoggedInService>();");
            sb.AppendLine(@"            Assert.NotNull(LoggedInService);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            string LoginEmail = Config.GetValue<string>(""LoginEmail"");");
            sb.AppendLine(@"            await LoggedInService.SetLoggedInContactInfo(LoginEmail);");
            sb.AppendLine(@"            Assert.NotNull(LoggedInService.LoggedInContactInfo);");
            sb.AppendLine(@"            Assert.NotNull(LoggedInService.LoggedInContactInfo.LoggedInContact);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeName }DBService = Provider.GetService<I{ TypeName }DBService>();");
            sb.AppendLine($@"            Assert.NotNull({ TypeName }DBService);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeName }Controller = Provider.GetService<I{ TypeName }Controller>();");
            sb.AppendLine($@"            Assert.NotNull({ TypeName }Controller);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            db = Provider.GetService<CSSPDBContext>();");
            sb.AppendLine(@"            Assert.NotNull(db);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return await Task.FromResult(true);");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
