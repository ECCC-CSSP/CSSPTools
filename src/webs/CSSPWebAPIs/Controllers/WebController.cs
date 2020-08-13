/*
 * Manually edited
 * 
 */
using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IWebController
    {
        Task<ActionResult<bool>> CreateWebRootGzFile();
        Task<ActionResult<bool>> CreateWebCountryGzFile(int CountryTVItemID);
        Task<ActionResult<bool>> CreateWebProvinceGzFile(int ProvinceTVItemID);
        Task<ActionResult<bool>> CreateWebAreaGzFile(int AreaTVItemID);
        Task<ActionResult<bool>> CreateWebSectorGzFile(int SectorTVItemID);
        Task<ActionResult<bool>> CreateWebSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample1980_1989FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample1990_1999FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2000_2009FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2010_2019FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2020_2029FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2030_2039FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2040_2049FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2050_2059FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWebSamplingPlanGzFile(int SamplingPlanID);
        Task<ActionResult<bool>> CreateWebMunicipalityGzFile(int MunicipalityTVItemID);
        Task<ActionResult<bool>> CreateWebMWQMRunGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWebMWQMSiteGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWebContactGzFile();
        Task<ActionResult<bool>> CreateWebClimateSiteGzFile(int ProvinceTVItemID);
        Task<ActionResult<bool>> CreateWebHydrometricSiteGzFile(int ProvinceTVItemID);
        Task<ActionResult<bool>> CreateWebDrogueRunGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWebMWQMLookupMPNGzFile();
        Task<ActionResult<bool>> CreateWebMikeScenarioGzFile(int MikeScenarioTVItemID);
        Task<ActionResult<bool>> CreateWebClimateDataValueGzFile(int ClimateSiteTVItemID); 
        Task<ActionResult<bool>> CreateWebHydrometricDataValueGzFile(int HydrometricSiteTVItemID);
        Task<ActionResult<bool>> CreateWebHelpDocGzFile();
        Task<ActionResult<bool>> CreateWebTideLocationGzFile();
        Task<ActionResult<bool>> CreateWebPolSourceSiteGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWebPolSourceGroupingGzFile();
        Task<ActionResult<bool>> CreateWebReportTypeGzFile();
        Task<ActionResult<bool>> CreateWebMunicipalitiesGzFile(int ProvinceTVItemID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class WebController : ControllerBase, IWebController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ICreateGzFileService CSSPWebService { get; }
        #endregion Properties

        #region Constructors
        public WebController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ICreateGzFileService CSSPWebService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.CSSPWebService = CSSPWebService;
        }
        #endregion Constructors

        #region Functions public
        [Route("CreateWebRootGzFile")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebRootGzFile()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebRootGzFile();
        }
        [Route("CreateWebCountryGzFile/{CountryTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebCountryGzFile(int CountryTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebCountryGzFile(CountryTVItemID);
        }
        [Route("CreateWebProvinceGzFile/{ProvinceTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebProvinceGzFile(int ProvinceTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebProvinceGzFile(ProvinceTVItemID);
        }
        [Route("CreateWebAreaGzFileGzFile/{AreaTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebAreaGzFile(int AreaTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebAreaGzFile(AreaTVItemID);
        }
        [Route("CreateWebSectorGzFile/{SectorTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebSectorGzFile(int SectorTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebSectorGzFile(SectorTVItemID);
        }
        [Route("CreateWebSubsectorGzFile/{SubsectorTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebSubsectorGzFile(int SubsectorTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebSubsectorGzFile(SubsectorTVItemID);
        }
        [Route("CreateWeb10YearOfSample1980_1989FromSubsectorGzFile/{SubsectorTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample1980_1989FromSubsectorGzFile(int SubsectorTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWeb10YearOfSample1980_1989FromSubsectorGzFile(SubsectorTVItemID);
        }
        [Route("CreateWeb10YearOfSample1990_1999FromSubsectorGzFile/{SubsectorTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample1990_1999FromSubsectorGzFile(int SubsectorTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWeb10YearOfSample1990_1999FromSubsectorGzFile(SubsectorTVItemID);
        }
        [Route("CreateWeb10YearOfSample2000_2009FromSubsectorGzFile/{SubsectorTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2000_2009FromSubsectorGzFile(int SubsectorTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWeb10YearOfSample2000_2009FromSubsectorGzFile(SubsectorTVItemID);
        }
        [Route("CreateWeb10YearOfSample2010_2019FromSubsectorGzFile/{SubsectorTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2010_2019FromSubsectorGzFile(int SubsectorTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWeb10YearOfSample2010_2019FromSubsectorGzFile(SubsectorTVItemID);
        }
        [Route("CreateWeb10YearOfSample2020_2029FromSubsectorGzFile/{SubsectorTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2020_2029FromSubsectorGzFile(int SubsectorTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWeb10YearOfSample2020_2029FromSubsectorGzFile(SubsectorTVItemID);
        }
        [Route("CreateWeb10YearOfSample2030_2039FromSubsectorGzFile/{SubsectorTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2030_2039FromSubsectorGzFile(int SubsectorTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWeb10YearOfSample2030_2039FromSubsectorGzFile(SubsectorTVItemID);
        }
        [Route("CreateWeb10YearOfSample2040_2049FromSubsectorGzFile/{SubsectorTVItemIDTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2040_2049FromSubsectorGzFile(int SubsectorTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWeb10YearOfSample2040_2049FromSubsectorGzFile(SubsectorTVItemID);
        }
        [Route("CreateWeb10YearOfSample2050_2059FromSubsectorGzFile/{SubsectorTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2050_2059FromSubsectorGzFile(int SubsectorTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWeb10YearOfSample2050_2059FromSubsectorGzFile(SubsectorTVItemID);
        }
        [Route("CreateWebSamplingPlanGzFile/{SamplingPlanID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebSamplingPlanGzFile(int SamplingPlanID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebSamplingPlanGzFile(SamplingPlanID);
        }
        [Route("CreateWebMunicipalityGzFile/{MunicipalityTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebMunicipalityGzFile(int MunicipalityTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebMunicipalityGzFile(MunicipalityTVItemID);
        }
        [Route("CreateWebMWQMRunGzFile/{SubsectorTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebMWQMRunGzFile(int SubsectorTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebMWQMRunGzFile(SubsectorTVItemID);
        }
        [Route("CreateWebMWQMSiteGzFile/{SubsectorTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebMWQMSiteGzFile(int SubsectorTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebMWQMSiteGzFile(SubsectorTVItemID);
        }
        [Route("CreateWebContactGzFile")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebContactGzFile()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebContactGzFile();
        }
        [Route("CreateWebClimateSiteGzFile/{ProvinceTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebClimateSiteGzFile(int ProvinceTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebClimateSiteGzFile(ProvinceTVItemID);
        }
        [Route("CreateWebHydrometricSiteGzFile/{ProvinceTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebHydrometricSiteGzFile(int ProvinceTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebHydrometricSiteGzFile(ProvinceTVItemID);
        }
        [Route("CreateWebDrogueRunGzFile/{SubsectorTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebDrogueRunGzFile(int SubsectorTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebDrogueRunGzFile(SubsectorTVItemID);
        }
        [Route("CreateWebMWQMLookupMPNGzFile")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebMWQMLookupMPNGzFile()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebMWQMLookupMPNGzFile();
        }
        [Route("CreateWebMikeScenarioGzFile/{MikeScenarioTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebMikeScenarioGzFile(int MikeScenarioTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebMikeScenarioGzFile(MikeScenarioTVItemID);
        }
        [Route("CreateWebClimateDataValueGzFile/{ClimateSiteTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebClimateDataValueGzFile(int ClimateSiteTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebClimateDataValueGzFile(ClimateSiteTVItemID);
        }
        [Route("CreateWebHydrometricDataValueGzFile/{HydrometricSiteTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebHydrometricDataValueGzFile(int HydrometricSiteTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebHydrometricDataValueGzFile(HydrometricSiteTVItemID);
        }
        [Route("CreateWebHelpDocGzFile")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebHelpDocGzFile()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebHelpDocGzFile();
        }
        [Route("CreateWebTideLocationGzFile")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebTideLocationGzFile()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebTideLocationGzFile();
        }
        [Route("CreateWebPolSourceSiteGzFile/{SubsectorTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebPolSourceSiteGzFile(int SubsectorTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebPolSourceSiteGzFile(SubsectorTVItemID);
        }
        [Route("CreateWebPolSourceGroupingGzFile")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebPolSourceGroupingGzFile()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebPolSourceGroupingGzFile();
        }
        [Route("CreateWebReportTypeGzFile")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebReportTypeGzFile()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebReportTypeGzFile();
        }
        [Route("CreateWebMunicipalitiesGzFile/{ProvinceTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateWebMunicipalitiesGzFile(int ProvinceTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateWebMunicipalitiesGzFile(ProvinceTVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
