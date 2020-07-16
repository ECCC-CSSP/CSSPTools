using ActionCommandDBServices.Services;
using CultureServices.Services;
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
        private ICultureService CultureService { get; }
        private IActionCommandDBService ActionCommandDBService { get; }
        #endregion Properties

        #region Constructors
        public GenerateCodeBaseService(IConfiguration configuration, ICultureService cultureService, IActionCommandDBService actionCommandDBService)
        {
            Configuration = configuration;
            CultureService = cultureService;
            ActionCommandDBService = actionCommandDBService;
        }
        #endregion Constructors

        #region Functions public
        // see Helpers folder for more public functions
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
