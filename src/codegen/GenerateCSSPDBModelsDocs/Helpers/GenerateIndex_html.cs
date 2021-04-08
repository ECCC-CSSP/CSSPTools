using CSSPCultureServices.Resources;
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
        public async Task<bool> GenerateIndex_html(Type[] types)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"<!DOCTYPE html>");
            sb.AppendLine(@"");
            sb.AppendLine(@"<html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"">");
            sb.AppendLine(@"<head>");
            sb.AppendLine(@"    <meta charset=""utf-8"" />");
            sb.AppendLine(@"    <title>CSSPDB Model Documentation</title>");
            sb.AppendLine(@"    <link href=""style.css"" rel=""stylesheet"" />");
            sb.AppendLine(@"</head>");
            sb.AppendLine(@"<body>");

            sb.AppendLine(@"<div>");
            sb.AppendLine($@"<h2><a href=""table_en.html"">English table list</a></h2>");
            sb.AppendLine(@"</div>");
            sb.AppendLine(@"<div>");
            sb.AppendLine($@"<h2><a href=""table_fr.html"">Liste des tables Français</a></h2>");
            sb.AppendLine(@"</div>");

            sb.AppendLine(@"</body>");
            sb.AppendLine(@"</html>");

            FileInfo fiOutputGen = new FileInfo($@"{ Configuration.GetValue<string>("DocPathHTML")}\index.html");
            using (StreamWriter sw = fiOutputGen.CreateText())
            {
                sw.Write(sb.ToString());
            }
            Console.WriteLine($"Created { fiOutputGen.FullName }");

            return await Task.FromResult(true);
        }
    }
}
