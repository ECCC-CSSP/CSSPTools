using CultureServices.Resources;
using Microsoft.Extensions.Configuration;
using PolSourceGroupingExcelFileReadServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumsPolSourceInfoRelatedFilesServices.Services
{
    public partial class EnumsPolSourceInfoRelatedFilesService : IEnumsPolSourceInfoRelatedFilesService
    {
        #region Variables
        #endregion Variables

        #region Constructors
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private async Task<bool> Generate_PolSourceInfoEnumGeneratedResFR_resx()
        {
            StringBuilder sb = new StringBuilder();

            FileInfo fi = new FileInfo(Config.GetValue<string>("PolSourceInfoEnumGeneratedResFR_resx"));

            if (!await ResxTopPart(sb)) return await Task.FromResult(false);

            sb.AppendLine(@"<data name=""___DoNotManuallyEditThisFile"" xml:space=""preserve"">");
            sb.AppendLine(@"  <value>SVP ne pas éditer ce document manuellement</value>");
            sb.AppendLine(@"</data>");

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in PolSourceGroupingExcelFileReadService.groupChoiceChildLevelList.Where(c => c.Group.Substring(c.Group.Length - 5) == "Start" && c.Choice == "").Distinct().ToList())
            {
                sb.AppendLine($@"<data name=""PolSourceInfoEnum{ groupChoiceChildLevel.Group }"" xml:space=""preserve"">");
                sb.AppendLine($@"  <value>{ groupChoiceChildLevel.FR.Replace("<", "&lt;").Replace(">", "&gt;") }</value>");
                sb.AppendLine(@"</data>");
                sb.AppendLine($@"<data name=""PolSourceInfoEnum{ groupChoiceChildLevel.Group }Desc"" xml:space=""preserve"">");
                sb.AppendLine($@"  <value>{ groupChoiceChildLevel.DescFR.Replace("<", "&lt;").Replace(">", "&gt;") }</value>");
                sb.AppendLine(@"</data>");
            }
            foreach (GroupChoiceChildLevel groupChoiceChildLevel in PolSourceGroupingExcelFileReadService.groupChoiceChildLevelList)
            {
                if (groupChoiceChildLevel.Choice.Length > 0)
                {
                    sb.AppendLine($@"<data name=""PolSourceInfoEnum{ groupChoiceChildLevel.Choice }"" xml:space=""preserve"">");
                    sb.AppendLine($@"  <value>{ groupChoiceChildLevel.FR.Replace("<", "&lt;").Replace(">", "&gt;") }</value>");
                    sb.AppendLine(@"</data>");
                    sb.AppendLine($@"<data name=""PolSourceInfoEnum{ groupChoiceChildLevel.Choice }Init"" xml:space=""preserve"">");
                    sb.AppendLine($@"  <value>{ groupChoiceChildLevel.InitFR.Replace("<", "&lt;").Replace(">", "&gt;") }</value>");
                    sb.AppendLine(@"</data>");

                    List<string> HideList = new List<string>();
                    List<string> HideTextList = groupChoiceChildLevel.Hide.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                    foreach (string hide in HideTextList)
                    {
                        int fromCSSPID = -1;
                        int toCSSPID = -1;
                        if (hide.Contains("-"))
                        {
                            List<string> stringList = hide.Split("-".ToCharArray(), StringSplitOptions.None).ToList();

                            fromCSSPID = int.Parse(hide.Substring(0, hide.IndexOf("-")));
                            int endPos = hide.IndexOf("-") + 1;
                            toCSSPID = int.Parse(hide.Substring(endPos));

                            for (int id = fromCSSPID; id <= toCSSPID; id++)
                            {
                                HideList.Add(id.ToString());
                            }
                        }
                        else
                        {
                            HideList.Add(hide);
                        }
                    }

                    sb.AppendLine($@"<data name=""PolSourceInfoEnum{ groupChoiceChildLevel.Choice }Hide"" xml:space=""preserve"">");
                    sb.AppendLine($@"  <value>{ (string.Join(",", HideList) + " ").Trim() }</value>");
                    sb.AppendLine(@"</data>");
                    if (groupChoiceChildLevel.ReportFR.Length > 0)
                    {
                        sb.AppendLine($@"<data name=""PolSourceInfoEnum{ groupChoiceChildLevel.Choice }Report"" xml:space=""preserve"">");
                        sb.AppendLine($@"  <value>{ groupChoiceChildLevel.ReportFR.Replace("<", "&lt;").Replace(">", "&gt;") }</value>");
                        sb.AppendLine(@"</data>");
                    }
                    if (groupChoiceChildLevel.TextFR.Length > 0)
                    {
                        sb.AppendLine($@"<data name=""PolSourceInfoEnum{ groupChoiceChildLevel.Choice }Text"" xml:space=""preserve"">");
                        sb.AppendLine($@"  <value>{ groupChoiceChildLevel.TextFR.Replace("<", "&lt;").Replace(">", "&gt;") }</value>");
                        sb.AppendLine(@"</data>");
                    }
                }
            }

            sb.AppendLine(@"</root>");

            try
            {
                StreamWriter sw = fi.CreateText();
                sw.Write(sb.ToString());
                sw.Close();
            }
            catch (Exception ex)
            {
                ActionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Creating } [{ fi.FullName }] ...");
                string InnerException = (ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "");
                ActionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Error }: { ex.Message }{ InnerException  }");

                return await Task.FromResult(false);
            }

            fi = new FileInfo(Config.GetValue<string>("PolSourceInfoEnumGeneratedResFR_resx"));
            if (fi.Exists)
            {
                string fileLine = "Last Write Time [" + fi.LastWriteTime.ToString("yyyy MMMM dd HH:mm:ss") + "] " + fi.FullName;
                ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
            }
            else
            {
                string fileLine = "Not Created" + fi.FullName;
                ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CultureServicesRes.Created }: { fi.FullName }");

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}