using ActionCommandDBServices.Services;
using CSSPCultureServices.Services;
using GenerateCodeBaseServices.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace GenerateCodeBaseServices.Services
{
    public interface IGenerateCodeBaseService
    {
        bool FillCSSPProp(PropertyInfo propInfo, CSSPProp csspProp, Type type);
        bool FillDLLTypeInfoList(FileInfo fiDLL, List<DLLTypeInfo> DLLTypeInfoList);
        bool SkipType(Type type);
    }
    public partial class GenerateCodeBaseService : IGenerateCodeBaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IActionCommandDBService ActionCommandDBService { get; }
        #endregion Properties

        #region Constructors
        public GenerateCodeBaseService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IActionCommandDBService actionCommandDBService)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.ActionCommandDBService = ActionCommandDBService;
        }
        #endregion Constructors

        #region Functions public
        // see Helpers folder for more public functions
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
