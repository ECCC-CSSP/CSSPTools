﻿using GenerateCodeBaseHelper;
using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices
{
    public partial class Startup
    {
        public async Task<bool> Generate()
        {
            Console.WriteLine("Generate Starting ...");

            #region Variables and loading DLL properties
            FileInfo fiCSSPDBModelsDLL = new FileInfo(Configuration.GetValue<string>("CSSPDBModels"));

            List<DLLTypeInfo> DLLTypeInfoCSSPDBLocalModelsList = new List<DLLTypeInfo>();
            if (GenerateCodeBase.FillDLLTypeInfoList(fiCSSPDBModelsDLL, DLLTypeInfoCSSPDBLocalModelsList))
            {
                Console.WriteLine($"Could not find file { fiCSSPDBModelsDLL.FullName }");
                return false;
            }
            #endregion Variables and loading DLL properties

            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPDBLocalModelsList)
            {
                bool NotMappedClass = false;
                StringBuilder sb = new StringBuilder();

                string TypeNameLower = "";

                TypeNameLower = $"{ dllTypeInfoModels.Type.Name.Substring(0, 1).ToLower() }{ dllTypeInfoModels.Type.Name.Substring(1) }";

                if (GenerateCodeBase.SkipType(dllTypeInfoModels.Type))
                {
                    continue;
                }

                if (dllTypeInfoModels.Type.Name != "TVItem")
                {
                    continue;
                }

                if (dllTypeInfoModels.HasNotMappedAttribute)
                {
                    NotMappedClass = true;
                }
                else
                {
                    NotMappedClass = false;
                }

                #region Top
                sb.AppendLine(@"/*");
                sb.AppendLine($@" * Auto generated from { AppDomain.CurrentDomain.BaseDirectory }{ AppDomain.CurrentDomain.FriendlyName}.exe");
                sb.AppendLine(@" *");
                sb.AppendLine(@" * Do not edit this file.");
                sb.AppendLine(@" *");
                sb.AppendLine(@" */");
                sb.AppendLine(@"");

                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using CSSPDBModels;");
                sb.AppendLine(@"using CSSPCultureServices.Resources;");
                sb.AppendLine(@"using CSSPCultureServices.Services;");
                sb.AppendLine(@"using Microsoft.AspNetCore.Mvc;");
                sb.AppendLine(@"using Microsoft.EntityFrameworkCore;");
                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using System.ComponentModel.DataAnnotations;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"using System.Text.RegularExpressions;");
                sb.AppendLine(@"using System.Threading.Tasks;");
                sb.AppendLine(@"using LoggedInServices;");
                sb.AppendLine(@"using Microsoft.Extensions.Configuration;");
                sb.AppendLine(@"using WebAppLoadedServices;");
                sb.AppendLine(@"");
                sb.AppendLine($@"namespace CSSPDBLocalServices");
                sb.AppendLine(@"{");
                #endregion Top

                if (!NotMappedClass)
                {

                    #region Interface
                    sb.AppendLine($@"    public partial interface I{ dllTypeInfoModels.Type.Name }DBService");
                    sb.AppendLine(@"    {");
                    sb.AppendLine($@"        Task<ActionResult<bool>> Delete(int { dllTypeInfoModels.Type.Name }ID);");
                    sb.AppendLine($@"        Task<ActionResult<List<{ dllTypeInfoModels.Type.Name }>>> Get{ dllTypeInfoModels.Type.Name }List(int skip = 0, int take = 100);");
                    sb.AppendLine($@"        Task<ActionResult<{ dllTypeInfoModels.Type.Name }>> Get{ dllTypeInfoModels.Type.Name }With{ dllTypeInfoModels.Type.Name.Replace("Local", "") }ID(int { dllTypeInfoModels.Type.Name.Replace("Local", "") }ID);");
                    sb.AppendLine($@"        Task<ActionResult<{ dllTypeInfoModels.Type.Name }>> Post({ dllTypeInfoModels.Type.Name } { dllTypeInfoModels.Type.Name.ToLower() });");
                    sb.AppendLine($@"        Task<ActionResult<{ dllTypeInfoModels.Type.Name }>> Put({ dllTypeInfoModels.Type.Name } { dllTypeInfoModels.Type.Name.ToLower() });");
                    sb.AppendLine(@"    }");
                    #endregion Interface

                    sb.AppendLine($@"    public partial class { dllTypeInfoModels.Type.Name }DBService : ControllerBase, I{ dllTypeInfoModels.Type.Name }DBService");
                    sb.AppendLine(@"    {");
                    sb.AppendLine(@"        #region Variables");
                    sb.AppendLine(@"        #endregion Variables");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Properties");
                    sb.AppendLine(@"        private CSSPDBLocalContext dbLocal { get; }");
                    sb.AppendLine(@"        private IConfiguration Configuration { get; }");
                    sb.AppendLine(@"        private ICSSPCultureService CSSPCultureService { get; }");
                    sb.AppendLine(@"        private ILoggedInService LoggedInService { get; }");
                    sb.AppendLine(@"        private IEnums enums { get; }");
                    sb.AppendLine(@"        private IEnumerable<ValidationResult> ValidationResults { get; set; }");
                    sb.AppendLine(@"        private IWebAppLoadedService WebAppLoadedService { get; }");
                    sb.AppendLine(@"        #endregion Properties");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Constructors");
                    sb.AppendLine($@"        public { dllTypeInfoModels.Type.Name }DBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ILoggedInService LoggedInService,");
                    sb.AppendLine($@"           CSSPDBLocalContext dbLocal, IWebAppLoadedService WebAppLoadedService)");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            this.Configuration = Configuration;");
                    sb.AppendLine(@"            this.CSSPCultureService = CSSPCultureService;");
                    sb.AppendLine(@"            this.LoggedInService = LoggedInService;");
                    sb.AppendLine(@"            this.enums = enums;");
                    sb.AppendLine(@"            this.dbLocal = dbLocal;");
                    sb.AppendLine(@"            this.WebAppLoadedService = WebAppLoadedService;");
                    sb.AppendLine(@"        }");
                    sb.AppendLine(@"        #endregion Constructors");
                    sb.AppendLine(@"");
                }
                else
                {
                    sb.AppendLine($@"    public interface I{ dllTypeInfoModels.Type.Name }Service");
                    sb.AppendLine($@"    {{");
                    sb.AppendLine($@"        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);");
                    sb.AppendLine($@"    }}");

                    sb.AppendLine($@"    public partial class { dllTypeInfoModels.Type.Name }Service : I{ dllTypeInfoModels.Type.Name }Service");
                    sb.AppendLine(@"    {");
                    sb.AppendLine(@"        #region Variables");
                    sb.AppendLine(@"        #endregion Variables");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Properties");
                    sb.AppendLine(@"        private ICSSPCultureService CSSPCultureService { get; }");
                    sb.AppendLine(@"        private IEnums enums { get; }");
                    sb.AppendLine(@"        #endregion Properties");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Constructors");
                    sb.AppendLine($@"        public { dllTypeInfoModels.Type.Name }Service(ICSSPCultureService CSSPCultureService, IEnums enums)");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            this.CSSPCultureService = CSSPCultureService;");
                    sb.AppendLine(@"            this.enums = enums;");
                    sb.AppendLine(@"        }");
                    sb.AppendLine(@"        #endregion Constructors");
                    sb.AppendLine(@"");
                }

                if (!NotMappedClass)
                {
                    sb.AppendLine(@"        #region Functions public ");
                    if (!await CreateClassServiceFunctionsPublicGenerateGet(dllTypeInfoModels, DLLTypeInfoCSSPDBLocalModelsList, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                    if (!await CreateClassServiceFunctionsPublicGenerateCRUD(dllTypeInfoModels, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                    sb.AppendLine(@"        #endregion Functions public");
                    sb.AppendLine(@"");

                    sb.AppendLine(@"        #region Functions private");
                    if (dllTypeInfoModels.Type.Name == "LocalContact")
                    {
                        if (!await CreateGetContactWithId(dllTypeInfoModels, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                    }
                    if (!await CreateClassServiceFunctionsPrivateGenerateValidate(dllTypeInfoModels, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                    sb.AppendLine(@"        #endregion Functions private");
                    sb.AppendLine(@"    }");
                    sb.AppendLine(@"");
                }
                else
                {
                    sb.AppendLine(@"        #region Functions public");
                    if (!await CreateClassServiceFunctionsPrivateGenerateValidateNotMapped(dllTypeInfoModels, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                    sb.AppendLine(@"        #endregion Functions public");
                    sb.AppendLine(@"    }");
                    sb.AppendLine(@"");
                }


                sb.AppendLine(@"}");

                string FileName = "";
                FileName = "ClassNameDBFile";

                FileInfo fiOutputGen = null;
                fiOutputGen = new FileInfo(Configuration.GetValue<string>(FileName).Replace("{TypeName}", dllTypeInfoModels.Type.Name));

                using (StreamWriter sw2 = fiOutputGen.CreateText())
                {
                    sw2.Write(sb.ToString());
                }

                Console.WriteLine($"Created { fiOutputGen.FullName }");

            }

            Console.WriteLine("");
            Console.WriteLine($"Done ...");
            Console.WriteLine("");
            Console.WriteLine("Generate Finished ...");

            return true;
        }
    }
}
