﻿using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> GenerateSetupTestCode(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        private async Task<bool> Setup(CultureInfo culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Config = new ConfigurationBuilder()");
            sb.AppendLine(@"               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)");
            sb.AppendLine(@"               .AddJsonFile(""appsettings.json"")");
            sb.AppendLine(@"               .Build();");
            sb.AppendLine(@"        ");
            sb.AppendLine(@"            Services = new ServiceCollection();");
            sb.AppendLine(@"        ");
            sb.AppendLine(@"            Services.AddSingleton<IConfiguration>(Config);");
            sb.AppendLine(@"        ");
            sb.AppendLine(@"            string TestDBConnString = Config.GetValue<string>(""TestDBConnectionString"");");
            sb.AppendLine(@"            Assert.NotNull(TestDBConnString);");
            sb.AppendLine(@"        ");
            sb.AppendLine(@"            Services.AddDbContext<CSSPDBContext>(options =>");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                options.UseSqlServer(TestDBConnString);");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"        ");
            sb.AppendLine(@"            Services.AddSingleton<IEnums, Enums>();");
            sb.AppendLine($@"            Services.AddSingleton<I{ TypeName }Service, { TypeName }Service>();");
            sb.AppendLine(@"        ");
            sb.AppendLine(@"            Provider = Services.BuildServiceProvider();");
            sb.AppendLine(@"            Assert.NotNull(Provider);");
            sb.AppendLine(@"        ");
            sb.AppendLine($@"            { TypeNameLower }Service = Provider.GetService<I{ TypeName }Service>();");
            sb.AppendLine($@"            Assert.NotNull({ TypeNameLower }Service);");
            sb.AppendLine(@"        ");
            sb.AppendLine($@"            await { TypeNameLower }Service.SetCulture(culture);");
            sb.AppendLine(@"        ");
            sb.AppendLine(@"            return await Task.FromResult(true);");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
