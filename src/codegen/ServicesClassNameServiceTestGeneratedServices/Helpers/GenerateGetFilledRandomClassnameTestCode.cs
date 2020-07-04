using CSSPModels;
using GenerateCodeBaseServices.Models;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> GenerateGetFilledRandomClassnameTestCode(Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            StringBuilder sbInMemory = new StringBuilder();

            string plurial = "s";
            if (TypeName == "Address")
            {
                plurial = "es";
            }

            sb.AppendLine($@"        private { TypeName } GetFilledRandom{ TypeName }(string OmitPropName)");
            sb.AppendLine(@"        {");
            sb.AppendLine($@"            List<{ TypeName }> { TypeNameLower }ListToDelete = (from c in dbLocal.{ TypeName }{ plurial }");
            sb.AppendLine($@"                                                               select c).ToList(); ");
            sb.AppendLine($@"            ");
            sb.AppendLine($@"            dbLocal.{ TypeName }{ plurial }.RemoveRange({ TypeNameLower }ListToDelete);");
            sb.AppendLine($@"            try");
            sb.AppendLine($@"            {{");
            sb.AppendLine($@"                dbLocal.SaveChanges();");
            sb.AppendLine($@"            }}");
            sb.AppendLine($@"            catch (Exception ex)");
            sb.AppendLine($@"            {{");
            sb.AppendLine($@"                Assert.True(false, ex.Message);");
            sb.AppendLine($@"            }}");
            sb.AppendLine($@"            ");

            sb.AppendLine($@"            dbIM.Database.EnsureDeleted();");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeName } { TypeNameLower } = new { TypeName }();");
            sb.AppendLine(@"");

            foreach (PropertyInfo prop in type.GetProperties())
            {
                CSSPProp csspProp = new CSSPProp();
                if (!GenerateCodeBaseService.FillCSSPProp(prop, csspProp, type))
                {
                    return await Task.FromResult(false);
                }

                if (csspProp.IsKey || prop.GetGetMethod().IsVirtual || prop.Name == "ValidationResults")
                {
                    continue;
                }

                if (!await CreateGetFilledRandomClass(prop, csspProp, TypeName, TypeNameLower, sb, sbInMemory)) return await Task.FromResult(false);
            }

            sb.AppendLine(@"");
            sb.AppendLine($@"            if (LoggedInService.IsLocal)");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                if (OmitPropName != ""{ TypeName }ID"") { TypeNameLower }.{ TypeName }ID = 10000000;");
            sb.AppendLine(@"");
            sb.Append(sbInMemory.ToString());
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine($@"            return { TypeNameLower };");
            sb.AppendLine(@"        }");
            return await Task.FromResult(true);
        }
    }
}
