using GenerateCodeBaseServices.Models;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices
{
    public partial class Startup
    {
        private async Task<bool> CreateClassServiceFunctionsPrivateRegionTrySave(DLLTypeInfo dllTypeInfo, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Functions private Generated TryToSave");
            sb.AppendLine($@"        private bool TryToSave({ TypeName } { TypeNameLower })");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            try");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                db.SaveChanges();");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            catch (Exception ex)");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                { TypeNameLower }.ValidationResultList = new List<ValidationResult>() {{ new ValidationResult(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")) }}.AsEnumerable();");
            sb.AppendLine(@"                return false;");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Functions private Generated TryToSave");
            sb.AppendLine(@"");

            return await Task.FromResult(true);
        }
    }
}
