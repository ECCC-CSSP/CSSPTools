using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.IO;
using CSSPPolSourceGroupingExcelFileRead;

namespace PolSourceGroupingGenerateCodeHelper
{
    public partial class EnumsPolSourceCodeWriter
    {
        /// <summary>
        /// Generates:
        ///     C:\CSSPTools\src\dlls\CSSPEnums\Resources\Generated\PolSourceInfoEnumGeneratedRes.resx
        /// 
        /// Requires:
        ///     C:\CSSPTools\src\assets\PolSourceGrouping.xlsm
        /// </summary>
        private void Generate_PolSourceInfoEnumGeneratedRes_resx()
        {
            StringBuilder sb = new StringBuilder();

            string FileToGenerate = @"C:\CSSPTools\src\dlls\CSSPEnums\Resources\Generated\PolSourceInfoEnumGeneratedRes.resx";
            if (!CheckFileDirectoriesExist(FileToGenerate))
            {
                return;
            }

            FileInfo fi = new FileInfo(FileToGenerate);

            ResxTopPart(sb);

            sb.AppendLine(@"<data name=""___DoNotManuallyEditThisFile"" xml:space=""preserve"">");
            sb.AppendLine(@"  <value>Do not manually edit this file</value>");
            sb.AppendLine(@"</data>");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Group.Substring(c.Group.Length - 5) == "Start" && c.Choice == "").Distinct().ToList())
            {
                sb.AppendLine($@"<data name=""PolSourceInfoEnum{ groupChoiceChildLevel.Group }"" xml:space=""preserve"">");
                sb.AppendLine($@"  <value>{ groupChoiceChildLevel.EN.Replace("<", "&lt;").Replace(">", "&gt;") }</value>");
                sb.AppendLine(@"</data>");
                sb.AppendLine($@"<data name=""PolSourceInfoEnum{ groupChoiceChildLevel.Group }Desc"" xml:space=""preserve"">");
                sb.AppendLine($@"  <value>{ groupChoiceChildLevel.DescEN.Replace("<", "&lt;").Replace(">", "&gt;") }</value>");
                sb.AppendLine(@"</data>");
            }
            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList)
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
                StatusPermanentEvent(new StatusEventArgs($"CSSPError creating [{ fi.FullName }]\r\n"));
                string InnerException = (ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "");
                StatusPermanentEvent(new StatusEventArgs($"CSSPError: { ex.Message } { InnerException } \r\n"));
                return;
            }
            StatusPermanentEvent(new StatusEventArgs($"Created: { fi.FullName }"));
            StatusTempEvent(new StatusEventArgs($"Created: { FileToGenerate }"));
        }
    }
}
