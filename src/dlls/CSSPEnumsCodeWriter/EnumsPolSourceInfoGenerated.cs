﻿using System;
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
        ///     C:\CSSPTools\src\dlls\CSSPEnums\EnumsPolSourceInfoGenerated.cs
        /// 
        /// Requires:
        ///     C:\CSSPTools\src\assets\PolSourceGrouping.xlsm
        /// </summary>
        private void EnumsPolSourceInfoGenerated()
        {
            StringBuilder sb = new StringBuilder();

            string FileToGenerate = @"C:\CSSPTools\src\dlls\CSSPEnums\EnumsPolSourceInfoGenerated.cs";
            if (!CheckFileDirectoriesExist(FileToGenerate))
            {
                return;
            }

            FileInfo fi = new FileInfo(FileToGenerate);

            List<string> groupList = (from c in polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                      select c.Group).Distinct().ToList();

            sb.AppendLine(@"/*");
            sb.AppendLine(@" * Auto generated from the CSSPCodeWriter.proj by clicking on the [Generate PolSource Enum code files] button");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */ ");
            sb.AppendLine(@"using CSSPEnums.Resources;");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPEnums");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    public partial class Enums");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"        #region Functions private");

            // Creating GetEnumText_PolSourceObsInfoEnum(PolSourceObsInfoEnum? polSourceInfo)
            sb.AppendLine(@"        private string GetEnumText_PolSourceObsInfoEnum(PolSourceObsInfoEnum? polSourceInfo)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (polSourceInfo == null)");
            sb.AppendLine(@"                 return CSSPEnumsRes.Empty;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            switch (polSourceInfo)");
            sb.AppendLine(@"            {");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Group.Substring(c.Group.Length - 5) == "Start" && c.Choice == "").Distinct().ToList())
            {
                sb.AppendLine($@"                case PolSourceObsInfoEnum.{ groupChoiceChildLevel.Group }:");
                sb.AppendLine($@"                    return PolSourceInfoEnumGeneratedRes.PolSourceInfoEnum{ groupChoiceChildLevel.Group };");
            }
            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList)
            {
                if (groupChoiceChildLevel.Choice.Length > 0)
                {
                    sb.AppendLine($@"                case PolSourceObsInfoEnum.{ groupChoiceChildLevel.Choice }:");
                    sb.AppendLine($@"                    return PolSourceInfoEnumGeneratedRes.PolSourceInfoEnum{ groupChoiceChildLevel.Choice };");
                }
            }

            sb.AppendLine(@"                default:");
            sb.AppendLine(@"                    return CSSPEnumsRes.CSSPError;");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            // Creating GetEnumText_PolSourceObsInfoDescEnum(PolSourceObsInfoEnum? polSourceInfo)
            sb.AppendLine(@"        private string GetEnumText_PolSourceObsInfoDescEnum(PolSourceObsInfoEnum? polSourceInfo)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (polSourceInfo == null)");
            sb.AppendLine(@"                return CSSPEnumsRes.Empty;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            switch (polSourceInfo)");
            sb.AppendLine(@"            {");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Group.Substring(c.Group.Length - 5) == "Start" && c.Choice == "").Distinct().ToList())
            {
                sb.AppendLine($@"                case PolSourceObsInfoEnum.{ groupChoiceChildLevel.Group }:");
                sb.AppendLine($@"                    return PolSourceInfoEnumGeneratedRes.PolSourceInfoEnum{ groupChoiceChildLevel.Group }Desc;");
            }

            sb.AppendLine(@"                default:");
            sb.AppendLine(@"                    return CSSPEnumsRes.CSSPError;");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            // Creating GetEnumText_PolSourceObsInfoReportEnum(PolSourceObsInfoEnum? polSourceInfo)
            sb.AppendLine(@"        private string GetEnumText_PolSourceObsInfoReportEnum(PolSourceObsInfoEnum? polSourceInfo)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (polSourceInfo == null)");
            sb.AppendLine(@"                return  CSSPEnumsRes.Empty;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            switch (polSourceInfo)");
            sb.AppendLine(@"            {");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Choice != "" && c.ReportEN != "").Distinct().ToList())
            {
                sb.AppendLine($@"                case PolSourceObsInfoEnum.{ groupChoiceChildLevel.Choice }:");
                sb.AppendLine($@"                    return PolSourceInfoEnumGeneratedRes.PolSourceInfoEnum{ groupChoiceChildLevel.Choice }Report;");
            }

            sb.AppendLine(@"                default:");
            sb.AppendLine(@"                    return """";");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            // Creating GetEnumText_PolSourceObsInfoTextEnum(PolSourceObsInfoEnum? polSourceInfo)
            sb.AppendLine(@"        private string GetEnumText_PolSourceObsInfoTextEnum(PolSourceObsInfoEnum? polSourceInfo)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (polSourceInfo == null)");
            sb.AppendLine(@"                return  CSSPEnumsRes.Empty;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            switch (polSourceInfo)");
            sb.AppendLine(@"            {");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Choice != "" && c.TextEN != "").Distinct().ToList())
            {
                sb.AppendLine($@"                case PolSourceObsInfoEnum.{ groupChoiceChildLevel.Choice }:");
                sb.AppendLine($@"                    return PolSourceInfoEnumGeneratedRes.PolSourceInfoEnum{ groupChoiceChildLevel.Choice }Text;");
            }

            sb.AppendLine(@"                default:");
            sb.AppendLine(@"                    return """";");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            // Creating GetEnumText_PolSourceObsInfoInitEnum(PolSourceObsInfoEnum? polSourceInfo)
            sb.AppendLine(@"        private string GetEnumText_PolSourceObsInfoInitEnum(PolSourceObsInfoEnum? polSourceInfo)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (polSourceInfo == null)");
            sb.AppendLine(@"                return  CSSPEnumsRes.Empty;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            switch (polSourceInfo)");
            sb.AppendLine(@"            {");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Choice != "" && c.InitEN != "").Distinct().ToList())
            {
                sb.AppendLine($@"                case PolSourceObsInfoEnum.{ groupChoiceChildLevel.Choice }:");
                sb.AppendLine($@"                    return PolSourceInfoEnumGeneratedRes.PolSourceInfoEnum{ groupChoiceChildLevel.Choice }Init;");
            }

            sb.AppendLine(@"                default:");
            sb.AppendLine(@"                    return """";");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            sb.AppendLine(@"        #endregion Functions private");

            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");

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
                StatusPermanentEvent(new StatusEventArgs($"CSSPError: { ex.Message } { InnerException }\r\n"));
                return;
            }
            StatusPermanentEvent(new StatusEventArgs($"Created: { fi.FullName }"));
            StatusTempEvent(new StatusEventArgs($"Created: { FileToGenerate }"));
        }
    }
}
