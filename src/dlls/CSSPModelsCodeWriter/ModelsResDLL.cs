using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace CSSPModelsGenerateCodeHelper
{
    public partial class ModelsCodeWriter
    {
        #region Functions private
        private void ResxDLL(StringBuilder sb)
        {
            FileInfo fiDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll");

            if (!fiDLL.Exists)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"{fiDLL.FullName } does not exist"));
                return;
            }

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                StatusTempEvent(new StatusEventArgs(type.Name));
                //Application.DoEvents();

                if (SkipType(type))
                {
                    if (!(type.Name.EndsWith("Web") || type.Name.EndsWith("Report")))
                    {
                        continue;
                    }
                }

                sb.AppendLine($@"<data name=""{ type.Name }"" xml:space=""preserve"">");
                sb.AppendLine($@"  <value>{ type.Name }</value>");
                sb.AppendLine(@"</data>");

                foreach (PropertyInfo prop in type.GetProperties().ToList())
                {
                    if (!prop.Name.Contains("ValidationResults"))
                    {
                        sb.AppendLine($@"<data name=""{ type.Name }{ prop.Name }"" xml:space=""preserve"">");
                        sb.AppendLine($@"  <value>{ type.Name }{ prop.Name }</value>");
                        sb.AppendLine(@"</data>");
                    }
                }
            }
        }
        #endregion Functions private

    }
}
