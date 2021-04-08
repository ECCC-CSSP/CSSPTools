using GenerateCodeBaseHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBModelsDocs
{
    public partial class Startup
    {
        public async Task<bool> Generate()
        {
            Console.WriteLine("Generate Starting ...");

            FileInfo fiDLL = new FileInfo(Configuration.GetValue<string>("CSSPDBModels"));

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();

            if (!await GenerateIndex_html(types)) return await Task.FromResult(false);
            if (!await GenerateTable_html(types, new CultureInfo("en-CA"))) return await Task.FromResult(false);
            if (!await GenerateTable_html(types, new CultureInfo("fr-CA"))) return await Task.FromResult(false);
            if (!await GenerateType_html(types, new CultureInfo("en-CA"))) return await Task.FromResult(false);
            if (!await GenerateType_html(types, new CultureInfo("fr-CA"))) return await Task.FromResult(false);
            if (!await GenerateStyle_css()) return await Task.FromResult(false);

            if (!await GenerateType_csv(types, new CultureInfo("en-CA"))) return await Task.FromResult(false);
            if (!await GenerateType_csv(types, new CultureInfo("fr-CA"))) return await Task.FromResult(false);

            Console.WriteLine("");
            Console.WriteLine($"Done ...");
            Console.WriteLine("");
            Console.WriteLine("Generate Finished ...");

            return await Task.FromResult(true);
        }
    }
}
