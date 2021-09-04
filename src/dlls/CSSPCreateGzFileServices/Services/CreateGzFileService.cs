/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using LoggedInServices;
using System.ComponentModel.DataAnnotations;
using CSSPLogServices;
using System.Reflection;
using CSSPCreateGzFileServices.Models;

namespace CreateGzFileServices
{
    public interface ICreateGzFileService
    {
        Task<ActionResult<bool>> CreateAllGzFiles();
        Task<ActionResult<bool>> CreateGzFile(WebTypeEnum webType, int TVItemID = 0);
        Task<ActionResult<bool>> DeleteGzFile(WebTypeEnum webType, int TVItemID = 0);
        Task<bool> FillConfigModel(CSSPCreateGzFileServiceConfigModel config);
    }
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private ICSSPLogService CSSPLogService { get; set; }
        private CSSPCreateGzFileServiceConfigModel config { get; set; }
        #endregion Properties

        #region Constructors
        public CreateGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService,
            IEnums enums, ICSSPLogService CSSPLogService, CSSPDBContext db = null, CSSPDBLocalContext dbLocal = null)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.CSSPLogService = CSSPLogService;
            this.db = db;
            this.dbLocal = dbLocal;
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
