/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CSSPServices
{
    public interface ICSSPWebService
    {
        Task<ActionResult<bool>> CreateWebRootGzFile();
        Task<ActionResult<bool>> CreateWebCountryGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebProvinceGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebAreaGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebMunicipalitiesGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebSectorGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebSubsectorGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample1980_1989FromSubsectorGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample1990_1999FromSubsectorGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2000_2009FromSubsectorGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2010_2019FromSubsectorGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2020_2029FromSubsectorGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2030_2039FromSubsectorGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2040_2049FromSubsectorGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2050_2059FromSubsectorGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebSamplingPlanGzFile(int SamplingPlanID);
        Task<ActionResult<bool>> CreateWebMunicipalityGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebMWQMRunGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebMWQMSiteGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebContactGzFile();
        Task<ActionResult<bool>> CreateWebClimateSiteGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebHydrometricSiteGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebDrogueRunGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebMWQMLookupMPNGzFile();
        Task<ActionResult<bool>> CreateWebMikeScenarioGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebClimateDataValueGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebHydrometricDataValueGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebHelpDocGzFile();
        Task<ActionResult<bool>> CreateWebTideLocationGzFile();
        Task<ActionResult<bool>> CreateWebPolSourceSiteGzFile(int TVItemID);
        Task<ActionResult<bool>> CreateWebPolSourceGroupingGzFile();
        Task<ActionResult<bool>> CreateWebReportTypeGzFile();

        Task<bool> CreateAllGzFiles();
    }
    public partial class CSSPWebService : ControllerBase, ICSSPWebService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private bool StoreLocal { get; set; }
        private bool StoreInAzure { get; set; }
        private string AzureCSSPStorageConnectionString { get; set; }
        private string AzureCSSPStorageCustomerProvidedKey { get; set; }
        private string AzureCSSPStorageCSSPFiles { get; set; }
        private string AzureCSSPStorageCSSPJSON { get; set; }
        private string LocalJSONPath { get; set; }
        private string LocalFilesPath { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPWebService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;

            Setup();
        }
        #endregion Constructors

        #region Functions public

        public async Task<bool> CreateAllGzFiles()
        {
            return await Task.FromResult(false);
            //return await DoCreateAllGzFiles();
        }

        public async Task<ActionResult<bool>> CreateWebRootGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebRoot();
        }
        public async Task<ActionResult<bool>> CreateWebCountryGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebCountry(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebProvinceGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebProvince(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebMunicipalitiesGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMunicipalities(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebAreaGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebArea(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebSectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSector(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSubsector(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebMunicipalityGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMunicipality(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample1980_1989FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSample(TVItemID, 1980);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample1990_1999FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSample(TVItemID, 1990);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2000_2009FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSample(TVItemID, 2000);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2010_2019FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSample(TVItemID, 2010);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2020_2029FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSample(TVItemID, 2020);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2030_2039FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSample(TVItemID, 2030);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2040_2049FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSample(TVItemID, 2040);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2050_2059FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSample(TVItemID, 2050);
        }
        public async Task<ActionResult<bool>> CreateWebSamplingPlanGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSamplingPlan(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebMWQMRunGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMRun(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebMWQMSiteGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSite(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebContactGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebContact();
        }
        public async Task<ActionResult<bool>> CreateWebClimateSiteGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebClimateSite(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebHydrometricSiteGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebHydrometricSite(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebDrogueRunGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebDrogueRun(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebMWQMLookupMPNGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMLookupMPN();
        }
        public async Task<ActionResult<bool>> CreateWebMikeScenarioGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMikeScenario(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebClimateDataValueGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebClimateDataValue(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebHydrometricDataValueGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebHydrometricDataValue(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebHelpDocGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebHelpDoc();
        }
        public async Task<ActionResult<bool>> CreateWebTideLocationGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebTideLocation();
        }
        public async Task<ActionResult<bool>> CreateWebPolSourceSiteGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebPolSourceSite(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebPolSourceGroupingGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebPolSourceGrouping();
        }
        public async Task<ActionResult<bool>> CreateWebReportTypeGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebReportType();
        }
        #endregion Functions public
    }
}
