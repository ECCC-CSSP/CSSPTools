using CSSPCultureServices.Resources;
using GenerateCodeBaseHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBModelsDocs
{
    public partial class Startup
    {
        public async Task<bool> GenerateStyle_css()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"body");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    ");
            sb.AppendLine(@"}");
            sb.AppendLine(@"");
            sb.AppendLine(@"ul>li{");
            sb.AppendLine(@"    list-style: none;");
            sb.AppendLine(@"    font-weight: 600;");
            sb.AppendLine(@"    color: blue;");
            sb.AppendLine(@"}");
            sb.AppendLine(@"");
            sb.AppendLine(@".desc {");
            sb.AppendLine(@"    font-weight: 300;");
            sb.AppendLine(@"    color: green;");
            sb.AppendLine(@"}");

            FileInfo fiOutputGen = new FileInfo($@"{ Configuration.GetValue<string>("DocPathHTML")}\style.css");
            using (StreamWriter sw = fiOutputGen.CreateText())
            {
                sw.Write(sb.ToString());
            }
            Console.WriteLine($"Created { fiOutputGen.FullName }");

            return await Task.FromResult(true);
        }
    }
}
