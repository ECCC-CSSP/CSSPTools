using ActionCommandDBServices.Models;
using CSSPCultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelsModelClassNameTestServices.Services
{
    public partial class ModelsModelClassNameTestService : IModelsModelClassNameTestService
    {
        private async Task<bool> Generate()
        {
            ActionResult<ActionCommand> actionActionCommand = await ActionCommandDBService.Get();

            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await ActionCommandDBService.ConsoleWriteError("actionCommand == null");
                return await Task.FromResult(false);
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Starting ...");
            ActionCommandDBService.PercentCompleted = 10;
            await ActionCommandDBService.Update();

            FileInfo fiDLL = new FileInfo(Config.GetValue<string>("CSSPModels"));

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                StringBuilder sb = new StringBuilder();

                if (GenerateCodeBaseService.SkipType(type))
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

                FileInfo fiOutputGen = new FileInfo(Config.GetValue<string>("TypeNameTest").Replace("{TypeName}", type.Name));
                if (!fiOutputGen.Exists)
                {
                    using (StreamWriter sw2 = fiOutputGen.CreateText())
                    {
                        sw2.Write(sb.ToString());
                    }
                    ActionCommandDBService.ExecutionStatusText.AppendLine($"{ string.Format(CSSPCultureServicesRes.CreatedNew_, fiOutputGen.FullName) }");
                }
                else
                {
                    ActionCommandDBService.ExecutionStatusText.AppendLine($"{ string.Format(CSSPCultureServicesRes.AlreadyCreated_, fiOutputGen.FullName) }");
                }

                fiOutputGen = new FileInfo(Config.GetValue<string>("TypeNameTest").Replace("{TypeName}", type.Name));
                if (fiOutputGen.Exists)
                {
                    string fileLine = "Last Write Time [" + fiOutputGen.LastWriteTime.ToString("yyyy MMMM dd HH:mm:ss") + "] " + fiOutputGen.FullName;
                    ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
                }
                else
                {
                    string fileLine = "Not Created" + fiOutputGen.FullName;
                    ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
                }

            }

            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CSSPCultureServicesRes.Done } ...");
            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            ActionCommandDBService.PercentCompleted = 100;
            await ActionCommandDBService.Update();


            return await Task.FromResult(true);
        }
    }
}
