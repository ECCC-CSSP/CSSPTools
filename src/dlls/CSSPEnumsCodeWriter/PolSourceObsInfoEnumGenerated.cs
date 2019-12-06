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
        ///     C:\CSSPTools\src\dlls\CSSPEnums\PolSourceObsInfoEnumGenerated.cs
        /// 
        /// Requires:
        ///     C:\CSSPTools\src\assets\PolSourceGrouping.xlsm
        /// </summary>
        private void PolSourceObsInfoEnumGenerated()
        {
            StringBuilder sb = new StringBuilder();

            string FileToGenerate = @"C:\CSSPTools\src\dlls\CSSPEnums\PolSourceObsInfoEnumGenerated.cs";
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
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPEnums");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    public enum PolSourceObsInfoEnum");
            sb.AppendLine(@"    {");

            foreach (PolSourceGroupingExcelFileRead.GroupChoiceChildLevel groupChoiceChildLevel in polSourceGroupingExcelFileRead.groupChoiceChildLevelList)
            {
                if (!string.IsNullOrWhiteSpace(groupChoiceChildLevel.Group))
                {
                    if (groupChoiceChildLevel.Group.Substring(groupChoiceChildLevel.Group.Length - 5) == "Start" && string.IsNullOrWhiteSpace(groupChoiceChildLevel.Choice))
                    {
                        sb.AppendLine("");
                        sb.AppendLine($"        { groupChoiceChildLevel.Group } = { groupChoiceChildLevel.CSSPID.ToString() },");
                    }
                    else
                    {
                        sb.AppendLine($"        { groupChoiceChildLevel.Choice } = { groupChoiceChildLevel.CSSPID.ToString() },");

                    }
                }
            }
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
                StatusPermanentEvent(new StatusEventArgs($"CSSPError: { ex.Message } { InnerException } \r\n"));
                return;
            }

            StatusPermanentEvent(new StatusEventArgs($"Created: { fi.FullName }"));
            StatusTempEvent(new StatusEventArgs($"Created: { FileToGenerate }"));
        }
    }
}
