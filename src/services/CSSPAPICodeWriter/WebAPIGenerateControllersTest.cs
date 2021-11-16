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

namespace CSSPWebAPIGenerateCodeHelper
{
    public partial class WebAPICodeWriter
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // constructor was done in the WebAPIGenerateCodeHelper.cs file
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        /// <summary>
        /// Generates:
        ///    C:\CSSPTools\src\tests\CSSPWebAPI.Tests\Controllers\Generated\[ModelClassName]ControllerTestGenerated.cs file
        ///
        /// Requires:
        ///     C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll
        /// </summary>
        public void ModelClassNameControllerTestGenerated()
        {
            StatusTempEvent(new StatusEventArgs(""));
            ClearPermanentEvent(new StatusEventArgs(""));

            FileInfo fiDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll");

            if (!fiDLL.Exists)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"{ fiDLL.FullName } does not exist"));
                return;
            }

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                bool ClassNotMapped = false;
                StringBuilder sb = new StringBuilder();
                string TypeName = type.Name;

                string TypeNameLower = "";

                if (type.Name.StartsWith("MWQM"))
                {
                    TypeNameLower = $"{ type.Name.Substring(0, 4).ToLower() }{ type.Name.Substring(4) }";
                }
                else if (type.Name.StartsWith("TV") || type.Name.StartsWith("VP"))
                {
                    TypeNameLower = $"{ type.Name.Substring(0, 2).ToLower() }{ type.Name.Substring(2) }";
                }
                else
                {
                    TypeNameLower = $"{ type.Name.Substring(0, 1).ToLower() }{ type.Name.Substring(1) }";
                }

                StatusTempEvent(new StatusEventArgs(TypeName));
                //Application.DoEvents();

                if (modelsGenerateCodeHelper.SkipType(type))
                {
                    continue;
                }

                //if (type.Name != "Address")
                //{
                //    continue;
                //}

                foreach (CustomAttributeData customAttributeData in type.CustomAttributes)
                {
                    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                    {
                        ClassNotMapped = true;
                        break;
                    }
                }

                if (!ClassNotMapped)
                {
                    sb.AppendLine(@"using CSSPEnums;");
                    sb.AppendLine(@"using CSSPModels;");
                    sb.AppendLine(@"using CSSPServices;");
                    sb.AppendLine(@"using Xunit;");
                    sb.AppendLine(@"using CSSPWebAPI.Controllers;");
                    sb.AppendLine(@"using System.Collections.Generic;");
                    sb.AppendLine(@"using System.Linq;");
                    sb.AppendLine(@"using Microsoft.AspNetCore.Mvc;");
                    sb.AppendLine(@"using System;");
                    sb.AppendLine(@"using CSSPWebAPI.Controllers.Resources;");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"namespace CSSPWebAPI.Tests.Controllers");
                    sb.AppendLine(@"{");
                    sb.AppendLine($@"    public partial class { TypeName }ControllerTest : BaseControllerTest");
                    sb.AppendLine(@"    {");
                    sb.AppendLine(@"        #region Variables");
                    sb.AppendLine(@"        #endregion Variables");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Properties");
                    sb.AppendLine(@"        #endregion Properties");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Constructors");
                    sb.AppendLine($@"        public { TypeName }ControllerTest() : base()");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"        }");
                    sb.AppendLine(@"        #endregion Constructors");
                    sb.AppendLine(@"");

                    GenerateControllersGetClassList(TypeName, TypeNameLower, sb);

                    GenerateControllersGetClassWithID(TypeName, TypeNameLower, sb);

                    GenerateControllersPostClass(TypeName, TypeNameLower, sb);

                    GenerateControllersPutClass(TypeName, TypeNameLower, sb);

                    GenerateControllersDeleteClass(TypeName, TypeNameLower, sb);

                    sb.AppendLine(@"    }");
                    sb.AppendLine(@"}");

                    FileInfo fiOutputGen = new FileInfo($@"C:\CSSPTools\src\tests\CSSPWebAPI.Tests\Controllers\Generated\{ TypeName }ControllerTestGenerated.cs");
                    using (StreamWriter sw2 = fiOutputGen.CreateText())
                    {
                        sw2.Write(sb.ToString());
                    }

                    StatusPermanentEvent(new StatusEventArgs($"Created [{ fiOutputGen.FullName }] ..."));
                }
            }

            StatusTempEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs(""));
            StatusPermanentEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs(""));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
