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
    #region Functions public
    public partial class ModelsCodeWriter
    {
        /// <summary>
        /// Generates:
        ///     C:\CSSPTools\src\tests\CSSPModels.Tests\tests\[ModelClassName]Test.cs file
        ///     
        ///     But only if it does not already exist
        /// 
        /// Requires:
        ///     C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll
        /// </summary>
        public void ModelClassName_Test()
        {
            StatusTempEvent(new StatusEventArgs(""));
            ClearPermanentEvent(new StatusEventArgs(""));

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
                StringBuilder sb = new StringBuilder();

                StatusTempEvent(new StatusEventArgs(type.Name));
                //Application.DoEvents();

                if (SkipType(type))
                {
                    continue;
                }

                //if (type.Name == "AppTaskParameter")
                //{
                //    continue;
                //}

                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using Xunit;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using CSSPModels;");
                sb.AppendLine(@"using Microsoft.EntityFrameworkCore.Metadata;");
                sb.AppendLine(@"using System.Reflection;");
                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPModels.Tests");
                sb.AppendLine(@"{");
                sb.AppendLine($@"    public partial class { type.Name }Test");
                sb.AppendLine(@"    {");
                sb.AppendLine($@"        // most of the tests are auto generated and are located under { type.Name }TestGenerated.cs");
                sb.AppendLine(@"        // use this section to add other manual test");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Tests");
                sb.AppendLine(@"        [Fact]");
                sb.AppendLine($@"        public void { type.Name }_Example_Manual_Test()");
                sb.AppendLine(@"        {");
                sb.AppendLine(@"            int i = 5;");
                sb.AppendLine(@"            Assert.Equal(5, i);");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Tests");
                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                FileInfo fiOutputGen = new FileInfo($@"C:\CSSPTools\src\tests\CSSPModels.Tests\tests\{ type.Name }Test.cs");
                if (!fiOutputGen.Exists)
                {
                    using (StreamWriter sw2 = fiOutputGen.CreateText())
                    {
                        sw2.Write(sb.ToString());
                    }
                    StatusPermanentEvent(new StatusEventArgs($"Created New [{ fiOutputGen.FullName }] ..."));
                }
                else
                {
                    StatusPermanentEvent(new StatusEventArgs($"Already created [{ fiOutputGen.FullName }] ..."));
                }
            }

            StatusTempEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs(""));
            StatusPermanentEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs(""));
        }

    }
    #endregion Functions public
}
