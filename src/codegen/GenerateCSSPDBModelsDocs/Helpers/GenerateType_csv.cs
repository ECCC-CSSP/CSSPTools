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
        public async Task<bool> GenerateType_csv(Type[] types, CultureInfo culture)
        {
            StringBuilder sb = new StringBuilder();
            string desc = "";
            string language = culture.TwoLetterISOLanguageName;

            sb.AppendLine(@"Table,Field,Type,Description");

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

                if (language == "fr")
                {
                    desc = CSSPCultureModelsRes.ResourceManager.GetString($"{type.Name}{plurial}_Table_Description", new CultureInfo("fr-CA"));
                }
                else
                {
                    desc = CSSPCultureModelsRes.ResourceManager.GetString($"{type.Name}{plurial}_Table_Description", new CultureInfo("en-CA"));
                }

                sb.AppendLine($"{type.Name}{plurial},,,{desc}");

                foreach (PropertyInfo prop in type.GetProperties().ToList())
                {
                    CSSPProp csspProp = new CSSPProp();
                    if (!GenerateCodeBase.FillCSSPProp(prop, csspProp, type))
                    {
                        return await Task.FromResult(false);
                    }

                    if (language == "fr")
                    {
                        desc = CSSPCultureModelsRes.ResourceManager.GetString($"{type.Name}_{prop.Name}_Description", new CultureInfo("fr-CA"));
                    }
                    else
                    {
                        desc = CSSPCultureModelsRes.ResourceManager.GetString($"{type.Name}_{prop.Name}_Description", new CultureInfo("en-CA"));
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

                    sb.AppendLine($"{type.Name}{plurial},{prop.Name},{propType},{desc}");
                }
            }
            
            FileInfo fiOutputGen = new FileInfo($@"{ Configuration.GetValue<string>("DocPathHTML")}\tables_and_fields_{language}.csv");
            using (StreamWriter sw = new StreamWriter(fiOutputGen.FullName, false, Encoding.UTF8))
            {
                sw.Write(sb.ToString());
            }
            Console.WriteLine($"Created { fiOutputGen.FullName }");


            return await Task.FromResult(true);
        }
    }
}
