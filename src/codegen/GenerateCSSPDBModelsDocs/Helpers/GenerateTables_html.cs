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
        public async Task<bool> GenerateTable_html(Type[] types, CultureInfo culture)
        {
            string language = culture.TwoLetterISOLanguageName;
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

            if (language == "fr")
            {
                sb.AppendLine($@"<h2><a href=""index.html"">Change Language</a></h2>");
                sb.AppendLine($@"<h2>&nbsp;</h2>");
                sb.AppendLine($@"<a href=""tables_and_fields_fr.csv"">Télécharger CSV</a>");
                sb.AppendLine($@"<h2>&nbsp;</h2>");
                sb.AppendLine($@"<h2>Liste des tables</h2>");
            }
            else
            {
                sb.AppendLine($@"<h2><a href=""index.html"">Changer de langage</a></h2>");
                sb.AppendLine($@"<h2>&nbsp;</h2>");
                sb.AppendLine($@"<a href=""tables_and_fields_en.csv"">Download CSV</a>");
                sb.AppendLine($@"<h2>&nbsp;</h2>");
                sb.AppendLine($@"<h2>Table List</h2>");
            }
            sb.AppendLine(@"<ul>");

            foreach (Type type in types)
            {
                string plurial = "s";
                if (type.Name == "Address")
                {
                    plurial = "es";
                }

                if (GenerateCodeBase.SkipType(type))
                {
                    continue;
                }

                sb.AppendLine(@"<li>");

                sb.AppendLine($@"<a href=""{type.Name}{plurial}_{language}.html"">{type.Name}{plurial}</a>");
                if (language == "fr")
                {
                    string DescFR = CSSPCultureModelsRes.ResourceManager.GetString($"{type.Name}{plurial}_Table_Description", new CultureInfo("fr-CA"));
                    sb.AppendLine(@"<br />");
                    sb.AppendLine($@"<span class=""desc"">&nbsp;&nbsp;&nbsp;&nbsp;{DescFR} </span>");
                }
                else
                {
                    string DescEN = CSSPCultureModelsRes.ResourceManager.GetString($"{type.Name}{plurial}_Table_Description", new CultureInfo("en-CA"));
                    sb.AppendLine(@"<br />");
                    sb.AppendLine($@"<span class=""desc"">&nbsp;&nbsp;&nbsp;&nbsp;{DescEN} </span>");
                }

                sb.AppendLine(@"</li>");
            }

            sb.AppendLine(@"</ul>");
            sb.AppendLine(@"</body>");
            sb.AppendLine(@"</html>");

            FileInfo fiOutputGen = new FileInfo($@"{ Configuration.GetValue<string>("DocPathHTML")}\table_{language}.html");
            using (StreamWriter sw = fiOutputGen.CreateText())
            {
                sw.Write(sb.ToString());
            }
            Console.WriteLine($"Created { fiOutputGen.FullName }");

            return await Task.FromResult(true);
        }
    }
}
