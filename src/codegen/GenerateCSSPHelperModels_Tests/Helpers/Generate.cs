using GenerateCodeBaseHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPHelperModels_Tests
{
    public partial class Startup
    {
        public async Task<bool> Generate()
        {
            Console.WriteLine("Generate Starting ...");

            FileInfo fiDLL = new FileInfo(Configuration.GetValue<string>("CSSPHelperModels"));

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                StringBuilder sb = new StringBuilder();

                if (GenerateCodeBase.SkipType(type))
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
                sb.AppendLine(@"using CSSPHelperModels;");
                sb.AppendLine(@"using Microsoft.EntityFrameworkCore.Metadata;");
                sb.AppendLine(@"using System.Reflection;");
                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using CSSPDBModels;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPHelperModels.Tests");
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

                FileInfo fiOutputGen = new FileInfo(Configuration.GetValue<string>("TypeNameTest").Replace("{TypeName}", type.Name));
                if (!fiOutputGen.Exists)
                {
                    using (StreamWriter sw2 = fiOutputGen.CreateText())
                    {
                        sw2.Write(sb.ToString());
                    }
                    Console.WriteLine($"Create New { fiOutputGen.FullName }");
                }
                else
                {
                    Console.WriteLine($"Already Created { fiOutputGen.FullName }");
                }
            }

            Console.WriteLine("");
            Console.WriteLine($"Done ...");
            Console.WriteLine("");
            Console.WriteLine("Generate Finished ...");

            return await Task.FromResult(true);
        }
    }
}
