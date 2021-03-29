/*
 * Manually edited
 *
 */

using CreateGzFileLocalServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using LoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReadGzFileServices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPDBLocalServices
{

    public partial interface IMapInfoService
    {
        Task<ActionResult<bool>> AddOrModify(PostMapInfoModel postMapInfoModel);
    }
    public partial class MapInfoService : ControllerBase, IMapInfoService
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
        public MapInfoService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ILoggedInService LoggedInService,
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
        public async Task<ActionResult<bool>> AddOrModify(PostMapInfoModel postMapInfoModel)
        {
            ActionDBTypeEnum actionDBType = ActionDBTypeEnum.Update;

            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            if (postMapInfoModel == null)
            {
                ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "postMapInfoModel"), new[] { "" }) };
            }

            if (postMapInfoModel.MapInfo.MapInfoID == 0)
            {
                actionDBType = ActionDBTypeEnum.Create;
            }

            ValidationResults = ValidateAndAddOrModify(new ValidationContext(postMapInfoModel), actionDBType);
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
