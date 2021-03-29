/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LoggedInServices;
using Microsoft.Extensions.Configuration;
using ReadGzFileServices;
using CSSPWebModels;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using CreateGzFileLocalServices;

namespace CSSPDBLocalServices
{

    public partial interface ITVItemService
    {
        Task<ActionResult<bool>> Delete(DeleteTVItemModel deleteTVItemModel);
        Task<ActionResult<bool>> AddOrModify(PostTVItemModel postTVItemModel);
    }
    public partial class TVItemService : ControllerBase, ITVItemService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext dbLocal { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IReadGzFileService ReadGzFileService { get; }
        private ICreateGzFileLocalService CreateGzFileLocalService { get; }
        private List<ToRecreate> ToRecreateList { get; set; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ILoggedInService LoggedInService,
           CSSPDBLocalContext dbLocal, IReadGzFileService ReadGzFileService, ICreateGzFileLocalService CreateGzFileLocalService)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.dbLocal = dbLocal;
            this.ReadGzFileService = ReadGzFileService;
            this.CreateGzFileLocalService = CreateGzFileLocalService;

            ToRecreateList = new List<ToRecreate>();
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<bool>> AddOrModify(PostTVItemModel postTVItemModel)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            ValidationResults = DoAddOrModify(new ValidationContext(postTVItemModel));
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<bool>> Delete(DeleteTVItemModel deleteTVItemModel)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            ValidationResults = DoDelete(new ValidationContext(deleteTVItemModel));
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            return await Task.FromResult(Ok(true));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}