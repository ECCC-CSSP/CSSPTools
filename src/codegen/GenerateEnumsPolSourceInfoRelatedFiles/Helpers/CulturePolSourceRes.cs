using Microsoft.Extensions.Configuration;
using PolSourceGroupingExcelFileReadServices.Models;
using PolSourceGroupingExcelFileReadServices.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateEnumsPolSourceInfoRelatedFiles
{
    public partial class Startup
    {
        #region Variables
        #endregion Variables


        #region Constructors
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private async Task<bool> Generate_PolSourceInfoEnumGeneratedRes_resx()
        {
            StringBuilder sb = new StringBuilder();

            FileInfo fi = new FileInfo(Configuration.GetValue<string>("CSSPCulturePolSourcesRes_resx"));

            if (!await ResxTopPart(sb)) return await Task.FromResult(false);

            sb.AppendLine(@"<data name=""___DoNotManuallyEditThisFile"" xml:space=""preserve"">");
            sb.AppendLine(@"  <value>Do not manually edit this file</value>");
            sb.AppendLine(@"</data>");

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileReadService.GroupChoiceChildLevelList.Where(c => c.Group.Substring(c.Group.Length - 5) == "Start" && c.Choice == "").Distinct().ToList())
            {
                sb.AppendLine($@"<data name=""PolSourceInfoEnum{ groupChoiceChildLevel.Group }"" xml:space=""preserve"">");
                sb.AppendLine($@"  <value>{ groupChoiceChildLevel.EN.Replace("<", "&lt;").Replace(">", "&gt;") }</value>");
                sb.AppendLine(@"</data>");
                sb.AppendLine($@"<data name=""PolSourceInfoEnum{ groupChoiceChildLevel.Group }Desc"" xml:space=""preserve"">");
                sb.AppendLine($@"  <value>{ groupChoiceChildLevel.DescEN.Replace("<", "&lt;").Replace(">", "&gt;") }</value>");
                sb.AppendLine(@"</data>");
            }
            foreach (GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileReadService.GroupChoiceChildLevelList)
            {
                if (groupChoiceChildLevel.Choice.Length > 0)
                {
                    sb.AppendLine($@"<data name=""PolSourceInfoEnum{ groupChoiceChildLevel.Choice }"" xml:space=""preserve"">");
                    sb.AppendLine($@"  <value>{ groupChoiceChildLevel.EN.Replace("<", "&lt;").Replace(">", "&gt;") }</value>");
                    sb.AppendLine(@"</data>");
                    sb.AppendLine($@"<data name=""PolSourceInfoEnum{ groupChoiceChildLevel.Choice }Init"" xml:space=""preserve"">");
                    sb.AppendLine($@"  <value>{ groupChoiceChildLevel.InitEN.Replace("<", "&lt;").Replace(">", "&gt;") }</value>");
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
                    if (groupChoiceChildLevel.ReportEN.Length > 0)
                    {
                        sb.AppendLine($@"<data name=""PolSourceInfoEnum{ groupChoiceChildLevel.Choice }Report"" xml:space=""preserve"">");
                        sb.AppendLine($@"  <value>{ groupChoiceChildLevel.ReportEN.Replace("<", "&lt;").Replace(">", "&gt;") }</value>");
                        sb.AppendLine(@"</data>");
                    }
                    if (groupChoiceChildLevel.TextEN.Length > 0)
                    {
                        sb.AppendLine($@"<data name=""PolSourceInfoEnum{ groupChoiceChildLevel.Choice }Text"" xml:space=""preserve"">");
                        sb.AppendLine($@"  <value>{ groupChoiceChildLevel.TextEN.Replace("<", "&lt;").Replace(">", "&gt;") }</value>");
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
                Console.WriteLine($"Creating [{ fi.FullName }] ...");
                string InnerException = (ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "");
                Console.WriteLine($"Error : { ex.Message }{ InnerException  }");

                return await Task.FromResult(false);
            }

            Console.WriteLine($"Created: { fi.FullName }");

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}