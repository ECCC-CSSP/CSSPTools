using System.Text;

namespace ModelsCSSPModelsResServices.Services
{
    public partial class ModelsCSSPModelsResService : IModelsCSSPModelsResService
    {
        private void ResxManual(StringBuilder sb, string lang)
        {
            sb.AppendLine(@"<data name=""___DoNotWriteInThisDocument"" xml:space=""preserve"">");
            if (lang == "fr")
            {
                sb.AppendLine(@"  <value>Do not write in this document. Use the ResxManual in the ModelsResManual.cs files</value>");
            }
            else
            {
                sb.AppendLine(@"  <value>SVP ne pas écrire dans ce document. SVP utiliser ResxManual dans le document ModelResManual.cs</value>");
            }
            sb.AppendLine(@"</data>");

            sb.AppendLine(@"<data name=""_IsRequired"" xml:space=""preserve"">");
            if (lang == "fr")
            {
                sb.AppendLine(@"  <value>{0} est requis</value>");
            }
            else
            {
                sb.AppendLine(@"  <value>{0} is required</value>");
            }
            sb.AppendLine(@"</data>");

            sb.AppendLine(@"<data name=""AspNetUser"" xml:space=""preserve"">");
            if (lang == "fr")
            {
                sb.AppendLine(@"  <value>AspNetUser</value>");
            }
            else
            {
                sb.AppendLine(@"  <value>AspNetUser</value>");
            }
            sb.AppendLine(@"</data>");
        }
    }
}
