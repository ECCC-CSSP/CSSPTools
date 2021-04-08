using CSSPCultureServices.Resources;
using GenerateCodeBaseHelper;
using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBModelsDocs
{
    public partial class Startup
    {
        public async Task<bool> GenerateType_html(Type[] types, CultureInfo culture)
        {
            StringBuilder sbMissing = new StringBuilder();
            string language = culture.TwoLetterISOLanguageName;
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
                    sb.AppendLine(@"<a href=""table_fr.html"">Retour à la liste de tables</a>");
                }
                else
                {
                    sb.AppendLine(@"<a href=""table_en.html"">Return to table list</a>");
                }
                sb.AppendLine($@"<h1>Table&nbsp;---&nbsp;{type.Name}{plurial}</h1>");
                sb.AppendLine(@"<ul>");

                foreach (PropertyInfo prop in type.GetProperties().ToList())
                {
                    CSSPProp csspProp = new CSSPProp();
                    if (!GenerateCodeBase.FillCSSPProp(prop, csspProp, type))
                    {
                        return await Task.FromResult(false);
                    }

                    string propType = csspProp.PropType;

                    if (csspProp.IsKey)
                    {
                        propType += " (key)";
                    }
                    if (csspProp.Min != null)
                    {
                        propType += $" (min={csspProp.Min})";
                    }
                    if (csspProp.Max != null)
                    {
                        propType += $" (max={csspProp.Max})";
                    }
                    if (csspProp.HasCSSPEnumTypeAttribute)
                    {
                        propType += $" (int)";
                    }
                    if (language == "fr")
                    {
                        string DescFR = CSSPCultureModelsRes.ResourceManager.GetString($"{type.Name}_{prop.Name}_Description", new CultureInfo("fr-CA"));
                        if (string.IsNullOrWhiteSpace(DescFR))
                        {
                            sbMissing.AppendLine($"Type: {type.Name} -- Field: {prop.Name}");
                        }
                        sb.AppendLine(@"<li>");
                        sb.AppendLine($@"{prop.Name} -- {propType}");
                        sb.AppendLine(@"<br />");
                        sb.AppendLine($@"<span class=""desc"">&nbsp;&nbsp;&nbsp;&nbsp;{DescFR}</span>");
                        sb.AppendLine(@"</li>");
                    }
                    else
                    {
                        string DescEN = CSSPCultureModelsRes.ResourceManager.GetString($"{type.Name}_{prop.Name}_Description", new CultureInfo("en-CA"));
                        if (string.IsNullOrWhiteSpace(DescEN))
                        {
                            sbMissing.AppendLine($"Type: {type.Name} -- Field: {prop.Name}");
                        }
                        sb.AppendLine(@"<li>");
                        sb.AppendLine($@"{prop.Name} -- {propType}");
                        sb.AppendLine(@"<br />");
                        sb.AppendLine($@"<span class=""desc"">&nbsp;&nbsp;&nbsp;&nbsp;{DescEN}</span>");
                        sb.AppendLine(@"</li>");
                    }
                }

                sb.AppendLine(@"</ul>");
                if (language == "fr")
                {
                    sb.AppendLine(@"<a href=""table_fr.html"">Retour à la liste de tables</a>");
                }
                else
                {
                    sb.AppendLine(@"<a href=""table_en.html"">Return to table list</a>");
                }
                sb.AppendLine(@"</body>");
                sb.AppendLine(@"</html>");

                FileInfo fiOutputGen = new FileInfo($@"{ Configuration.GetValue<string>("DocPathHTML")}\{type.Name}{plurial}_{language}.html");
                using (StreamWriter sw = fiOutputGen.CreateText())
                {
                    sw.Write(sb.ToString());
                }
                Console.WriteLine($"Created { fiOutputGen.FullName }");
            }

            Console.WriteLine(sbMissing.ToString());

            return await Task.FromResult(true);
        }
    }
}
