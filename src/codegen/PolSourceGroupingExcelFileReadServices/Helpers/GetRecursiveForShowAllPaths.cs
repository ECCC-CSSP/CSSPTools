using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using PolSourceGroupingExcelFileReadServices.Models;
using PolSourceGroupingExcelFileReadServices.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActionCommandDBServices.Services;
using ValidateAppSettingsServices.Services;

namespace PolSourceGroupingExcelFileReadServices.Services
{
    public partial class PolSourceGroupingExcelFileReadService : IPolSourceGroupingExcelFileReadService
    {
        private async Task<bool> GetRecursiveForShowAllPaths(string s, List<string> textList, int Level, bool RaiseEvents, StringBuilder sb)
        {
            textList.RemoveRange(Level, (textList.Count - Level));

            if (textList.Contains(s))
            {
                actionCommandDBService.ErrorText.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.RecursiveFound } ...");
                actionCommandDBService.ErrorText.AppendLine("");
                actionCommandDBService.PercentCompleted = 0;
                await actionCommandDBService.Update();

                foreach (string sp in textList)
                {
                    actionCommandDBService.ErrorText.AppendLine($"{ sp }");
                    actionCommandDBService.PercentCompleted = 0;
                    await actionCommandDBService.Update();

                }
                actionCommandDBService.ErrorText.AppendLine($"{ s }");
                actionCommandDBService.PercentCompleted = 0;
                await actionCommandDBService.Update();


                return false;
            }

            actionCommandDBService.ExecutionStatusText.AppendLine($"{ PolSourceGroupingExcelFileReadServicesRes.Doing } ... { s }");
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

            List<GroupChoiceChildLevel> groupChoiceChildLevelChildList = groupChoiceChildLevelList.Where(c => c.Group == s && c.Choice != "").ToList();
            if (groupChoiceChildLevelChildList.Count > 0)
            {
                foreach (string child in groupChoiceChildLevelChildList.Select(c => c.Child).Distinct())
                {
                    if (!await GetRecursiveForShowAllPaths(child, textList, Level, RaiseEvents, sb))
                        return false;
                }
            }

            actionCommandDBService.ExecutionStatusText.AppendLine($"");
            //await actionCommandDBService.Update( 0);

            return true;
        }
    }
}
