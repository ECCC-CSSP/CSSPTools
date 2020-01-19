using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
//using System.Windows.Forms;
using CSSPModels;
using CSSPEnums;
using CSSPModelsGenerateCodeHelper;
using System.Data.SqlClient;
using System.Data;
using CSSPGenerateCodeBase;
using System.IO;

namespace CSSPWebToolsAngGenerateCodeHelper
{
    public partial class AngularCodeWriter
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // constructor was done in the AngularGenerateCodeHelper.cs file
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        public void AngularInterfacesGenerate()
        {
            StatusTempEvent(new StatusEventArgs(""));
            ClearPermanentEvent(new StatusEventArgs("Starting ..."));
            StatusPermanentEvent(new StatusEventArgs(""));

            DirectoryInfo diOutputGen = new DirectoryInfo(@"C:\CSSPTools\src\web\CSSPWebToolsAng\src\app\interfaces\generated\");
            if (!diOutputGen.Exists)
            {
                try
                {
                    diOutputGen.Create();
                }
                catch (Exception)
                {
                    StatusPermanent2Event(new StatusEventArgs($"Could not create directory [{ diOutputGen.FullName }]"));
                }
            }

            FileInfo fiCSSPEnumsDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPEnums\bin\Debug\netcoreapp3.1\CSSPEnums.dll");
            FileInfo fiCSSPModelsDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll");


            if (!fiCSSPEnumsDLL.Exists)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"File does not exist [{ fiCSSPEnumsDLL.FullName }]"));
                return;
            }

            StatusPermanentEvent(new StatusEventArgs($"Reading [{ fiCSSPEnumsDLL.FullName }] ..."));
            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();
            if (FillDLLTypeInfoList(fiCSSPEnumsDLL, DLLTypeInfoCSSPEnumsList))
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"Could not read the file [{ fiCSSPEnumsDLL.FullName }]"));
                return;
            }
            StatusPermanentEvent(new StatusEventArgs($"Loaded [{ fiCSSPEnumsDLL.FullName }] ..."));

            if (!fiCSSPModelsDLL.Exists)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"File does not exist [{ fiCSSPModelsDLL.FullName }]"));
                return;
            }

            StatusPermanentEvent(new StatusEventArgs($"Reading [{ fiCSSPModelsDLL.FullName }] ..."));
            List<DLLTypeInfo> DLLTypeInfoCSSPModelsList = new List<DLLTypeInfo>();
            if (FillDLLTypeInfoList(fiCSSPModelsDLL, DLLTypeInfoCSSPModelsList))
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"Could not read the file [{ fiCSSPModelsDLL.FullName }]"));
                return;
            }
            StatusPermanentEvent(new StatusEventArgs($"Loaded [{ fiCSSPModelsDLL.FullName }] ..."));

            CreateValidationResultTypeFile();

            List<string> removeClass = new List<string>()
            {
                "CSSPAfterAttribute", "CSSPAllowNullAttribute", "CSSPBiggerAttribute", "CSSPDBContext", "CSSPDescriptionENAttribute",
                "CSSPDescriptionFRAttribute", "CSSPDisplayENAttribute", "CSSPDisplayFRAttribute", "CSSPEnumTypeAttribute",
                "CSSPEnumTypeTextAttribute", "CSSPExistAttribute", "CSSPFillAttribute", "CSSPModelsRes", "Query"
            };
            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPModelsList)
            {
                //if (!(dllTypeInfoModels.Name == "Address" || dllTypeInfoModels.Name == "LastUpdate" || dllTypeInfoModels.Name == "CSSPError"))
                //{
                //    continue;
                //}

                if (!removeClass.Contains(dllTypeInfoModels.Name))
                {
                    CreateTypeFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
                }
            }
        }


        #endregion Functions public

        #region Functions private
        private void CreateTypeFile(DLLTypeInfo dllTypeInfoModels, List<DLLTypeInfo> DLLTypeInfoCSSPModelsList)
        {
            StringBuilder sb = new StringBuilder();
            List<string> fileNameUsedList = new List<string>();
            List<string> removeTypeList = new List<string>()
            {
                "Int32", "Int16", "Int64", "Single", "Float", "Double", "String", "DateTime", "Boolean"
            };
            bool IsExtra = false; ;
            string LastLetter = "";
            string BaseClass = "";
            string ParentClass = "";
            List<string> PropToSkip = new List<string>();

            if (dllTypeInfoModels.Name == "AppTaskParameter")
            {
                int seilfj = 34;
            }

            sb.AppendLine(@"/*");
            sb.AppendLine(@" * Auto generated from the CSSPWebToolsAngCodeWriter.proj by clicking on the [AngularInterfacesGenerate.cs] button");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */");
            sb.AppendLine(@"");

            if (dllTypeInfoModels.Name == "CSSPError")
            {
                sb.AppendLine($"import {{ ValidationResult }} from './validationresult.interface';");
            }
            else if (dllTypeInfoModels.Name == "LastUpdate")
            {
                sb.AppendLine($"import {{ CSSPError }} from './cssperror.interface';");
            }
            else
            {
                if (!dllTypeInfoModels.HasNotMappedAttribute)
                {
                    sb.AppendLine($"import {{ LastUpdate }} from './lastupdate.interface';");
                }
                else
                {
                    if (dllTypeInfoModels.Name.Length > 5)
                    {
                        IsExtra = dllTypeInfoModels.Name.Substring(dllTypeInfoModels.Name.Length - 6).StartsWith("Extra");

                        if (!IsExtra)
                        {
                            sb.AppendLine($"import {{ CSSPError }} from './cssperror.interface';");
                        }
                    }
                    else
                    {
                        sb.AppendLine($"import {{ CSSPError }} from './cssperror.interface';");
                    }
                }
            }

            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList.OrderBy(c => c.CSSPProp.PropName))
            {
                string fileName = dllPropertyInfo.CSSPProp.PropType.ToLower();
                if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute)
                {
                    fileName = fileName.Replace("enum", ".enum");
                    if (!fileNameUsedList.Contains(fileName))
                    {
                        fileNameUsedList.Add(fileName);
                        if (PropToSkip.Contains(dllPropertyInfo.CSSPProp.PropName))
                        {
                            continue;
                        }
                        sb.AppendLine($"import {{ { dllPropertyInfo.CSSPProp.PropType } }} from '../../enums/generated/{ fileName }';");
                    }
                }

                if (!fileNameUsedList.Contains(fileName))
                {
                    if (!(dllPropertyInfo.CSSPProp.PropName == "ValidationResults" || dllPropertyInfo.CSSPProp.PropName == "HasErrors"))
                    {
                        if (!removeTypeList.Contains(dllPropertyInfo.CSSPProp.PropType))
                        {
                            fileNameUsedList.Add(fileName);
                            if (PropToSkip.Contains(dllPropertyInfo.CSSPProp.PropName))
                            {
                                continue;
                            }
                            if (dllPropertyInfo.CSSPProp.IsList)
                            {
                                sb.AppendLine($"import {{ { dllPropertyInfo.CSSPProp.PropType } }} from './{ fileName }.interface';");
                            }
                            else
                            {
                                sb.AppendLine($"import {{ { dllPropertyInfo.CSSPProp.PropType } }} from './{ fileName }.interface';");
                            }
                        }
                    }
                }
            }
            sb.AppendLine(@"");

            string MappedText = "";
            if (dllTypeInfoModels.HasNotMappedAttribute)
            {
                if (IsExtra)
                {
                    MappedText = $" extends { ParentClass }";
                }
                else
                {
                    MappedText = " extends CSSPError";
                }
            }
            else
            {
                if (dllTypeInfoModels.Type.Name == "LastUpdate")
                {
                    MappedText = " extends CSSPError";
                }
                else if (dllTypeInfoModels.Type.Name == "CSSPError")
                {
                    MappedText = "";
                }
                else
                {
                    if (IsExtra)
                    {
                        MappedText = $" extends { ParentClass }";
                    }
                    else
                    {
                        MappedText = " extends LastUpdate";
                    }
                }
            }
            sb.AppendLine($@"export interface { dllTypeInfoModels.Name }{ MappedText } {{");

            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList.OrderBy(c => c.CSSPProp.PropName))
            {
                if (PropToSkip.Contains(dllPropertyInfo.CSSPProp.PropName))
                {
                    continue;
                }

                if (dllTypeInfoModels.Name != "CSSPError")
                {
                    if (dllPropertyInfo.CSSPProp.PropName == "HasErrors" || dllPropertyInfo.CSSPProp.PropName == "ValidationResults")
                    {
                        continue;
                    }
                }

                string IsNull = "";
                if (dllPropertyInfo.CSSPProp.IsNullable)
                {
                    IsNull = "?";
                }

                string typeText = "";
                switch (dllPropertyInfo.CSSPProp.PropType)
                {
                    case "Int32":
                    case "Int16":
                    case "Int64":
                    case "Single":
                    case "Float":
                    case "Double":
                        {
                            typeText = "number";
                        }
                        break;
                    case "String":
                        {
                            typeText = "string";
                            IsNull = "";
                        }
                        break;
                    case "DateTime":
                        {
                            typeText = "Date";
                        }
                        break;
                    case "Boolean":
                        {
                            typeText = "boolean";
                        }
                        break;
                    default:
                        {
                            if (dllPropertyInfo.CSSPProp.PropName == "ValidationResults")
                            {
                                typeText = "ValidationResult";
                            }
                            else
                            {
                                typeText = dllPropertyInfo.CSSPProp.PropType;
                            }
                        }
                        break;
                }
                if (dllPropertyInfo.CSSPProp.IsList)
                {
                    sb.AppendLine($@"    { dllPropertyInfo.CSSPProp.PropName }{ IsNull }: { typeText }[];");
                }
                else
                {
                    sb.AppendLine($@"    { dllPropertyInfo.CSSPProp.PropName }{ IsNull }: { typeText };");
                }
            }

            sb.AppendLine(@"}");

            FileInfo fiOutputGen = new FileInfo($@"C:\CSSPTools\src\web\CSSPWebToolsAng\src\app\interfaces\generated\{ dllTypeInfoModels.Name.ToLower() }.interface.ts");
            using (StreamWriter sw2 = fiOutputGen.CreateText())
            {
                sw2.Write(sb.ToString());
                StatusPermanentEvent(new StatusEventArgs($"Created [{ dllTypeInfoModels.Name.ToLower() }.interface.ts]"));
            }
        }
        private void CreateValidationResultTypeFile()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"/*");
            sb.AppendLine(@" * Auto generated from the CSSPWebToolsAngCodeWriter.proj by clicking on the [AngularEnumsGenerate.cs] button");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */");
            sb.AppendLine(@"");
            sb.AppendLine($@"export interface ValidationResult {{");
            sb.AppendLine($@"    MemberNames: string[];");
            sb.AppendLine($@"    ErrorMessage: string;");
            sb.AppendLine(@"}");

            FileInfo fiOutputGen = new FileInfo($@"C:\CSSPTools\src\web\CSSPWebToolsAng\src\app\interfaces\generated\validationresult.interface.ts");
            using (StreamWriter sw2 = fiOutputGen.CreateText())
            {
                sw2.Write(sb.ToString());
                StatusPermanentEvent(new StatusEventArgs($"Created [validationresult.interface.ts]"));
            }
        }
        #endregion Functions private
    }
}
