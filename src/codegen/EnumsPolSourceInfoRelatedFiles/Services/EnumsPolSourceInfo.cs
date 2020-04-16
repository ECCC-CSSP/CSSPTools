﻿using CSSPPolSourceGroupingExcelFileRead.Models;
using CSSPPolSourceGroupingExcelFileRead.Services;
using EnumsPolSourceInfoRelatedFiles.Resources;
using Microsoft.Extensions.Configuration;
using StatusAndResultsDBService.Models;
using StatusAndResultsDBService.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumsPolSourceInfoRelatedFiles.Services
{
    public partial class GenerateService : IGenerateService
    {
        #region Variables
        #endregion Variables

        #region Constructors
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private async Task Generate_EnumsPolSourceInfo()
        {
            StringBuilder sb = new StringBuilder();

            FileInfo fi = new FileInfo(_configuration.GetValue<string>("EnumsPolSourceInfoGenerated_cs"));

            List<string> groupList = (from c in _polSourceGroupingExcelFileRead.groupChoiceChildLevelList
                                      select c.Group).Distinct().ToList();

            sb.AppendLine(@"/*");
            sb.AppendLine(@" * Auto generated from the CSSPCodeWriter.proj by clicking on the [Generate PolSource Enum code files] button");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */ ");
            sb.AppendLine(@"using CSSPEnums.Resources;");
            sb.AppendLine(@"using CSSPEnums.Resources.Generated;");
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

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in _polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Group.Substring(c.Group.Length - 5) == "Start" && c.Choice == "").Distinct().ToList())
            {
                sb.AppendLine($@"                case PolSourceObsInfoEnum.{ groupChoiceChildLevel.Group }:");
                sb.AppendLine($@"                    return PolSourceInfoEnumGeneratedRes.PolSourceInfoEnum{ groupChoiceChildLevel.Group };");
            }
            foreach (GroupChoiceChildLevel groupChoiceChildLevel in _polSourceGroupingExcelFileRead.groupChoiceChildLevelList)
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

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in _polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Group.Substring(c.Group.Length - 5) == "Start" && c.Choice == "").Distinct().ToList())
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

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in _polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Choice != "" && c.ReportEN != "").Distinct().ToList())
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

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in _polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Choice != "" && c.TextEN != "").Distinct().ToList())
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

            foreach (GroupChoiceChildLevel groupChoiceChildLevel in _polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Where(c => c.Choice != "" && c.InitEN != "").Distinct().ToList())
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
                sbError.AppendLine($"{ AppRes.Creating } [{ fi.FullName }] ...");
                string InnerException = (ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "");
                sbError.AppendLine($"{ AppRes.Error }: { ex.Message }{ InnerException  }");
                //await _statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                return;
            }

            sbStatus.AppendLine($"{ AppRes.Created }: { fi.FullName }");
            //await _statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);
        }
        #endregion Functions private
    }
}