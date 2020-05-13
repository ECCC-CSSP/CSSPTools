using EnumsCompareWithOldEnumsServices.Resources;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnumsCompareWithOldEnumsServices.Services
{
    public partial class EnumsCompareWithOldEnumsService : IEnumsCompareWithOldEnumsService
    {
        private async Task<bool> CompareDLLs()
        {
            string NewEnumsDLL = "NewEnumsDLL";
            string OldEnumsDLL = "OldEnumsDLL";

            ActionResult<ActionCommand> actionActionCommand = await actionCommandDBService.GetOrCreate();

            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await actionCommandDBService.ConsoleWriteError("actionCommand == null");
                return false;
            }

            actionCommandDBService.ExecutionStatusText.AppendLine("CompareDLLs Starting...");
            actionCommandDBService.PercentCompleted = 0;
            await actionCommandDBService.Update();


            FileInfo fiDLL = new FileInfo(configuration.GetValue<string>(NewEnumsDLL));
            FileInfo fiOldDLL = new FileInfo(configuration.GetValue<string>(OldEnumsDLL));

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            List<Type> typeList = importAssembly.GetTypes().ToList();

            var importAssemblyOld = Assembly.LoadFile(fiOldDLL.FullName);
            List<Type> typeOldList = importAssemblyOld.GetTypes().ToList();

            foreach (Type type in typeOldList)
            {
                if (type.Name.EndsWith("Service") || type.Name.EndsWith("Res") || type.Name.EndsWith("TextOrdered") || type.Name.StartsWith("<>"))
                {
                    continue;
                }
                Type typeExist = (from c in typeList
                                  where c.Name == type.Name
                                  select c).FirstOrDefault();

                if (typeExist == null)
                {
                    await actionCommandDBService.ConsoleWriteError($"{ String.Format(EnumsCompareWithOldEnumsServicesRes.Type_NotFound, type.Name) }");
                    return false;
                }
                else
                {
                    List<string> EnumNameOldList = Enum.GetNames(type).ToList();
                    List<string> EnumNameList = Enum.GetNames(typeExist).ToList();

                    foreach (string EnumStr in EnumNameOldList)
                    {
                        if (EnumStr == "Error")
                        {
                            continue;
                        }

                        string EnumStrExist = (from c in EnumNameList
                                               where c == EnumStr
                                               select c).FirstOrDefault();

                        if (string.IsNullOrWhiteSpace(EnumStrExist))
                        {
                            await actionCommandDBService.ConsoleWriteError($"{ String.Format(EnumsCompareWithOldEnumsServicesRes.Type_Enum_NotFound, type.Name, EnumStr) }");
                            return false;
                        }
                        else
                        {
                            // nothing
                        }
                    }
                }
            }

            actionCommandDBService.ExecutionStatusText.AppendLine("CompareDLLs Finished...");

            return true;
        }
    }
}
