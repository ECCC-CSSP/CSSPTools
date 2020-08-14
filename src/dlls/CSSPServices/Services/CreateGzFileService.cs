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
using System.Collections.Generic;

namespace CSSPServices
{
    public interface ICreateGzFileService
    {
        Task<ActionResult<bool>> CreateWebRootGzFile();
        Task<ActionResult<bool>> CreateWebCountryGzFile(int CountryTVItemID);
        Task<ActionResult<bool>> CreateWebProvinceGzFile(int ProvinceTVItemID);
        Task<ActionResult<bool>> CreateWebAreaGzFile(int AreaTVItemID);
        Task<ActionResult<bool>> CreateWebMunicipalitiesGzFile(int ProvinceTVItemID);
        Task<ActionResult<bool>> CreateWebSectorGzFile(int SectorTVItemID);
        Task<ActionResult<bool>> CreateWebSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWebMunicipalityGzFile(int MunicipalityTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample1980_1989FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample1990_1999FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2000_2009FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2010_2019FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2020_2029FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2030_2039FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2040_2049FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWeb10YearOfSample2050_2059FromSubsectorGzFile(int SubsectorTVItemID);
        Task<ActionResult<bool>> CreateWebSamplingPlanGzFile(int SamplingPlanID);
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

        Task<bool> CreateAllGzFiles();
    }
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
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
        public CreateGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db)
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

            return await DoCreateWebRootGzFile();
        }
        public async Task<ActionResult<bool>> CreateWebCountryGzFile(int CountryTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebCountryGzFile(CountryTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebProvinceGzFile(int ProvinceTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebProvinceGzFile(ProvinceTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebAreaGzFile(int AreaTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebAreaGzFile(AreaTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebMunicipalitiesGzFile(int ProvinceTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMunicipalitiesGzFile(ProvinceTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebSectorGzFile(int SectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSectorGzFile(SectorTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSubsectorGzFile(SubsectorTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebMunicipalityGzFile(int MunicipalityTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMunicipalityGzFile(MunicipalityTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample1980_1989FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(SubsectorTVItemID, 1980);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample1990_1999FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(SubsectorTVItemID, 1990);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2000_2009FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(SubsectorTVItemID, 2000);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2010_2019FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(SubsectorTVItemID, 2010);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2020_2029FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(SubsectorTVItemID, 2020);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2030_2039FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(SubsectorTVItemID, 2030);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2040_2049FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(SubsectorTVItemID, 2040);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2050_2059FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(SubsectorTVItemID, 2050);
        }
        public async Task<ActionResult<bool>> CreateWebSamplingPlanGzFile(int SamplingPlanID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSamplingPlanGzFile(SamplingPlanID);
        }
        public async Task<ActionResult<bool>> CreateWebMWQMRunGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMRunGzFile(SubsectorTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebMWQMSiteGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSiteGzFile(SubsectorTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebContactGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebContactGzFile();
        }
        public async Task<ActionResult<bool>> CreateWebClimateSiteGzFile(int ProvinceTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebClimateSiteGzFile(ProvinceTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebHydrometricSiteGzFile(int ProvinceTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebHydrometricSiteGzFile(ProvinceTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebDrogueRunGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebDrogueRunGzFile(SubsectorTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebMWQMLookupMPNGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMLookupMPNGzFile();
        }
        public async Task<ActionResult<bool>> CreateWebMikeScenarioGzFile(int MikeScenarioTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMikeScenarioGzFile(MikeScenarioTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebClimateDataValueGzFile(int ClimateSiteTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebClimateDataValueGzFile(ClimateSiteTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebHydrometricDataValueGzFile(int HydrometricSiteTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebHydrometricDataValueGzFile(HydrometricSiteTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebHelpDocGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebHelpDocGzFile();
        }
        public async Task<ActionResult<bool>> CreateWebTideLocationGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebTideLocationGzFile();
        }
        public async Task<ActionResult<bool>> CreateWebPolSourceSiteGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebPolSourceSiteGzFile(SubsectorTVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebPolSourceGroupingGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebPolSourceGroupingGzFile();
        }
        public async Task<ActionResult<bool>> CreateWebReportTypeGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebReportTypeGzFile();
        }
        #endregion Functions public

        #region Functions private
        private void Setup()
        {
            StoreLocal = bool.Parse(Configuration.GetValue<string>("StoreLocal"));
            StoreInAzure = bool.Parse(Configuration.GetValue<string>("StoreInAzure"));
            AzureCSSPStorageConnectionString = Configuration.GetValue<string>("AzureCSSPStorageConnectionString");
            AzureCSSPStorageCustomerProvidedKey = Configuration.GetValue<string>("AzureCSSPStorageCustomerProvidedKey");
            AzureCSSPStorageCSSPFiles = Configuration.GetValue<string>("AzureCSSPStorageCSSPFiles");
            AzureCSSPStorageCSSPJSON = Configuration.GetValue<string>("AzureCSSPStorageCSSPJSON");

            if (StoreLocal)
            {
                List<string> StoragePathList = new List<string>() { "LocalJSONPath", "LocalFilesPath" };
                foreach (string StoragePath in StoragePathList)
                {
                    if (Configuration.GetValue<string>(StoragePath) == null)
                    {
                        throw new Exception($"{ String.Format(CSSPCultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, StoragePath) }");
                    }

                    DirectoryInfo di = new DirectoryInfo(Configuration.GetValue<string>(StoragePath));

                    if (!di.Exists)
                    {
                        try
                        {
                            di.Create();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }

                    if (StoragePath == "LocalJSONPath")
                    {
                        LocalJSONPath = di.FullName;
                    }

                    if (StoragePath == "LocalFilesPath")
                    {
                        LocalFilesPath = di.FullName;
                    }
                }
            }
        }
        #endregion Functions private
    }
}
