using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using PolSourceGroupingExcelFileReadServices.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActionCommandDBServices.Services;
using ValidateAppSettingsServices.Services;
using CultureServices.Resources;

namespace PolSourceGroupingExcelFileReadServices.Services
{
    public partial class PolSourceGroupingExcelFileReadService : IPolSourceGroupingExcelFileReadService
    {
        private async Task<bool> GetRecursiveForShowAllPaths(string s, List<string> textList, int Level, bool RaiseEvents, StringBuilder sb)
        {
            textList.RemoveRange(Level, (textList.Count - Level));

            if (textList.Contains(s))
            {
                ActionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.RecursiveFound } ...");
                ActionCommandDBService.ErrorText.AppendLine("");
                ActionCommandDBService.PercentCompleted = 0;
                await ActionCommandDBService.Update();

                foreach (string sp in textList)
                {
                    ActionCommandDBService.ErrorText.AppendLine($"{ sp }");
                    ActionCommandDBService.PercentCompleted = 0;
                    await ActionCommandDBService.Update();

                }
                ActionCommandDBService.ErrorText.AppendLine($"{ s }");
                ActionCommandDBService.PercentCompleted = 0;
                await ActionCommandDBService.Update();


                return false;
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Doing } ... { s }");
            //await actionCommandDBService.Update( 0);

            if (RaiseEvents)
            {
                StringBuilder sb2 = new StringBuilder();
                foreach (string text in textList)
                {
                    sb2.Append($"{ text }\t");
                }

                sb.AppendLine(sb2.ToString());
            }

            Level = Level + 1;
            textList.Add(s);

            List<GroupChoiceChildLevel> groupChoiceChildLevelChildList = GroupChoiceChildLevelList.Where(c => c.Group == s && c.Choice != "").ToList();
            if (groupChoiceChildLevelChildList.Count > 0)
            {
                foreach (string child in groupChoiceChildLevelChildList.Select(c => c.Child).Distinct())
                {
                    if (!await GetRecursiveForShowAllPaths(child, textList, Level, RaiseEvents, sb))
                        return false;
                }
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine($"");
            //await actionCommandDBService.Update( 0);

            return true;
        }
    }
}
