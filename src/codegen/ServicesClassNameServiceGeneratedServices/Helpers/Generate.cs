﻿using ActionCommandDBServices.Models;
using CSSPCultureServices.Resources;
using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public partial class ServicesClassNameServiceGeneratedService : IServicesClassNameServiceGeneratedService
    {
        private async Task<bool> Generate()
        {
            ActionResult<ActionCommand> actionActionCommand = await ActionCommandDBService.Get();

            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await ActionCommandDBService.ConsoleWriteError("actionCommand == null");
                return false;
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Starting ...");
            ActionCommandDBService.PercentCompleted = 10;
            await ActionCommandDBService.Update();

            string CSSPDB2 = Config.GetValue<string>("CSSPDB2");
            string TestDB = Config.GetValue<string>("TestDB");

            #region Variables and loading DLL properties
            FileInfo fiCSSPModelsDLL = new FileInfo(Config.GetValue<string>("CSSPModels"));

            List<DLLTypeInfo> DLLTypeInfoCSSPModelsList = new List<DLLTypeInfo>();
            if (GenerateCodeBaseService.FillDLLTypeInfoList(fiCSSPModelsDLL, DLLTypeInfoCSSPModelsList))
            {
                ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(CSSPCultureServicesRes.CouldNotFindFile_, fiCSSPModelsDLL.FullName) }");
                return false;
            }
            #endregion Variables and loading DLL properties

            DLLTypeInfo dllTypeInfoLastUpdate = new DLLTypeInfo();
            DLLTypeInfo dllTypeInfoCSSPError = new DLLTypeInfo();

            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPModelsList)
            {
                if (dllTypeInfoModels.Name == "LastUpdate")
                {
                    dllTypeInfoLastUpdate = dllTypeInfoModels;
                }

                if (dllTypeInfoModels.Name == "CSSPError")
                {
                    dllTypeInfoCSSPError = dllTypeInfoModels;
                }
            }

            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPModelsList)
            {
                bool NotMappedClass = false;
                StringBuilder sb = new StringBuilder();

                string TypeNameLower = "";

                if (dllTypeInfoModels.Type.Name.StartsWith("MWQM"))
                {
                    TypeNameLower = $"{ dllTypeInfoModels.Type.Name.Substring(0, 4).ToLower() }{ dllTypeInfoModels.Type.Name.Substring(4) }";
                }
                else if (dllTypeInfoModels.Type.Name.StartsWith("TV") || dllTypeInfoModels.Type.Name.StartsWith("VP"))
                {
                    TypeNameLower = $"{ dllTypeInfoModels.Type.Name.Substring(0, 2).ToLower() }{ dllTypeInfoModels.Type.Name.Substring(2) }";
                }
                else
                {
                    TypeNameLower = $"{ dllTypeInfoModels.Type.Name.Substring(0, 1).ToLower() }{ dllTypeInfoModels.Type.Name.Substring(1) }";
                }

                if (GenerateCodeBaseService.SkipType(dllTypeInfoModels.Type))
                {
                    continue;
                }

                //if (dllTypeInfoModels.Type.Name != "Address")
                //{
                //    continue;
                //}

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
                sb.AppendLine(@" */ ");
                sb.AppendLine(@"");

                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using CSSPModels;");
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
                if (dllTypeInfoModels.Type.Name == "Contact")
                {
                    sb.AppendLine(@"using Microsoft.AspNetCore.Identity;");
                    sb.AppendLine(@"using Microsoft.Extensions.Configuration;");
                    sb.AppendLine(@"using Microsoft.IdentityModel.Tokens;");
                    sb.AppendLine(@"using System.IdentityModel.Tokens.Jwt;");
                    sb.AppendLine(@"using System.Security.Claims;");
                    sb.AppendLine(@"using System.Text;");
                }
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPServices");
                sb.AppendLine(@"{");
                #endregion Top

                if (!NotMappedClass)
                {

                    #region Interface
                    sb.AppendLine($@"   public partial interface I{ dllTypeInfoModels.Type.Name }Service");
                    sb.AppendLine(@"    {");
                    if (dllTypeInfoModels.Type.Name == "AspNetUser")
                    {
                        sb.AppendLine($@"       Task<ActionResult<bool>> Delete(string Id);");
                    }
                    else
                    {
                        sb.AppendLine($@"       Task<ActionResult<bool>> Delete(int { dllTypeInfoModels.Type.Name }ID);");
                    }
                    sb.AppendLine($@"       Task<ActionResult<List<{ dllTypeInfoModels.Type.Name }>>> Get{ dllTypeInfoModels.Type.Name }List(int skip = 0, int take = 100);");
                    if (dllTypeInfoModels.Type.Name == "AspNetUser")
                    {
                        sb.AppendLine($@"       Task<ActionResult<{ dllTypeInfoModels.Type.Name }>> Get{ dllTypeInfoModels.Type.Name }WithId(string Id);");
                    }
                    else
                    {
                        sb.AppendLine($@"       Task<ActionResult<{ dllTypeInfoModels.Type.Name }>> Get{ dllTypeInfoModels.Type.Name }With{ dllTypeInfoModels.Type.Name }ID(int { dllTypeInfoModels.Type.Name }ID);");
                    }
                    if (dllTypeInfoModels.Type.Name == "Contact")
                    {
                        sb.AppendLine($@"       Task<ActionResult<{ dllTypeInfoModels.Type.Name }>> Post({ dllTypeInfoModels.Type.Name } { dllTypeInfoModels.Type.Name.ToLower() }, AddContactTypeEnum addContactType);");
                    }
                    else
                    {
                        sb.AppendLine($@"       Task<ActionResult<{ dllTypeInfoModels.Type.Name }>> Post({ dllTypeInfoModels.Type.Name } { dllTypeInfoModels.Type.Name.ToLower() });");
                    }
                    sb.AppendLine($@"       Task<ActionResult<{ dllTypeInfoModels.Type.Name }>> Put({ dllTypeInfoModels.Type.Name } { dllTypeInfoModels.Type.Name.ToLower() });");
                    if (dllTypeInfoModels.Type.Name == "Contact")
                    {
                        sb.AppendLine($@"       Task<ActionResult<{ dllTypeInfoModels.Type.Name }>> Login(LoginModel loginModel);");
                        sb.AppendLine($@"       Task<ActionResult<{ dllTypeInfoModels.Type.Name }>> Register(RegisterModel registerModel);");
                    }
                    sb.AppendLine(@"    }");
                    #endregion Interface

                    sb.AppendLine($@"    public partial class { dllTypeInfoModels.Type.Name }Service : ControllerBase, I{ dllTypeInfoModels.Type.Name }Service");
                    sb.AppendLine(@"    {");
                    sb.AppendLine(@"        #region Variables");
                    sb.AppendLine(@"        #endregion Variables");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Properties");
                    sb.AppendLine(@"        private CSSPDBContext db { get; }");
                    sb.AppendLine(@"        private CSSPDBLocalContext dbLocal { get; }");
                    sb.AppendLine(@"        private InMemoryDBContext dbIM { get; }");
                    if (dllTypeInfoModels.Type.Name == "Contact")
                    {
                        sb.AppendLine(@"        private IConfiguration Configuration { get; }");
                        sb.AppendLine(@"        private UserManager<ApplicationUser> UserManager { get; }");
                        sb.AppendLine(@"        private IAspNetUserService AspNetUserService { get; }");
                        sb.AppendLine(@"        private ILoginModelService LoginModelService { get; }");
                        sb.AppendLine(@"        private IRegisterModelService RegisterModelService { get; }");

                    }
                    sb.AppendLine(@"        private ICSSPCultureService CSSPCultureService { get; }");
                    sb.AppendLine(@"        private ILoggedInService LoggedInService { get; }");
                    sb.AppendLine(@"        private IEnums enums { get; }");
                    sb.AppendLine(@"        private IEnumerable<ValidationResult> ValidationResults { get; set; }");
                    sb.AppendLine(@"        #endregion Properties");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Constructors");
                    if (dllTypeInfoModels.Type.Name == "Contact")
                    {
                        sb.AppendLine($@"        public { dllTypeInfoModels.Type.Name }Service(IConfiguration Configuration, UserManager<ApplicationUser> UserManager, ICSSPCultureService CSSPCultureService, ");
                        sb.AppendLine($@"           ILoggedInService LoggedInService, IEnums enums, IAspNetUserService AspNetUserService, ILoginModelService LoginModelService, ");
                        sb.AppendLine($@"           IRegisterModelService RegisterModelService, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)");
                    }
                    else
                    {
                        sb.AppendLine($@"        public { dllTypeInfoModels.Type.Name }Service(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)");
                    }
                    sb.AppendLine(@"        {");
                    if (dllTypeInfoModels.Type.Name == "Contact")
                    {
                        sb.AppendLine(@"            this.Configuration = Configuration;");
                        sb.AppendLine(@"            this.UserManager = UserManager;");
                        sb.AppendLine(@"            this.AspNetUserService = AspNetUserService;");
                        sb.AppendLine(@"            this.LoginModelService = LoginModelService;");
                        sb.AppendLine(@"            this.RegisterModelService = RegisterModelService;");
                    }
                    sb.AppendLine(@"            this.CSSPCultureService = CSSPCultureService;");
                    sb.AppendLine(@"            this.LoggedInService = LoggedInService;");
                    sb.AppendLine(@"            this.enums = enums;");
                    sb.AppendLine(@"            this.db = db;");
                    sb.AppendLine(@"            this.dbLocal = dbLocal;");
                    sb.AppendLine(@"            this.dbIM = dbIM;");
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
                    if (!await CreateClassServiceFunctionsPublicGenerateGet(dllTypeInfoModels, DLLTypeInfoCSSPModelsList, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                    if (!await CreateClassServiceFunctionsPublicGenerateCRUD(dllTypeInfoModels, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                    if (dllTypeInfoModels.Type.Name == "Contact")
                    {
                        if (!await CreateLogin(dllTypeInfoModels, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                    }
                    sb.AppendLine(@"        #endregion Functions public");
                    sb.AppendLine(@"");

                    sb.AppendLine(@"        #region Functions private");
                    if (dllTypeInfoModels.Type.Name == "Contact")
                    {
                        if (!await CreateGetContactWithId(dllTypeInfoModels, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                    }
                    if (!await CreateClassServiceFunctionsPrivateGenerateValidate(dllTypeInfoModels, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                    sb.AppendLine(@"        #endregion Functions private");
                    sb.AppendLine(@"");
                }
                else
                {
                    sb.AppendLine(@"        #region Functions public");
                    if (!await CreateClassServiceFunctionsPrivateGenerateValidateNotMapped(dllTypeInfoModels, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                    sb.AppendLine(@"        #endregion Functions public");
                    sb.AppendLine(@"");
                }


                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                FileInfo fiOutputGen = null;
                fiOutputGen = new FileInfo(Config.GetValue<string>("ClassNameFile").Replace("{TypeName}", dllTypeInfoModels.Type.Name));

                using (StreamWriter sw2 = fiOutputGen.CreateText())
                {
                    sw2.Write(sb.ToString());
                }

                fiOutputGen = new FileInfo(Config.GetValue<string>("ClassNameFile").Replace("{TypeName}", dllTypeInfoModels.Type.Name));
                if (fiOutputGen.Exists)
                {
                    string fileLine = "Last Write Time [" + fiOutputGen.LastWriteTime.ToString("yyyy MMMM dd HH:mm:ss") + "] " + fiOutputGen.FullName;
                    ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
                }
                else
                {
                    string fileLine = "Not Created" + fiOutputGen.FullName;
                    ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
                }

                ActionCommandDBService.ExecutionStatusText.AppendLine($"{ string.Format(CSSPCultureServicesRes.Created_, fiOutputGen.FullName) }");

            }
            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine($"{ CSSPCultureServicesRes.Done } ...");
            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            ActionCommandDBService.PercentCompleted = 100;
            await ActionCommandDBService.Update();


            return true;
        }
    }
}
