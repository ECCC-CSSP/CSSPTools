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
        public async Task<ActionResult<bool>> CreateWebCountryGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebCountryGzFile(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebProvinceGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebProvinceGzFile(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebMunicipalitiesGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMunicipalitiesGzFile(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebAreaGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebAreaGzFile(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebSectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSectorGzFile(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSubsectorGzFile(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebMunicipalityGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMunicipalityGzFile(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample1980_1989FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(TVItemID, 1980);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample1990_1999FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(TVItemID, 1990);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2000_2009FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(TVItemID, 2000);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2010_2019FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(TVItemID, 2010);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2020_2029FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(TVItemID, 2020);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2030_2039FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(TVItemID, 2030);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2040_2049FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(TVItemID, 2040);
        }
        public async Task<ActionResult<bool>> CreateWeb10YearOfSample2050_2059FromSubsectorGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSampleGzFile(TVItemID, 2050);
        }
        public async Task<ActionResult<bool>> CreateWebSamplingPlanGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebSamplingPlanGzFile(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebMWQMRunGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMRunGzFile(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebMWQMSiteGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMSiteGzFile(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebContactGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebContactGzFile();
        }
        public async Task<ActionResult<bool>> CreateWebClimateSiteGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebClimateSiteGzFile(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebHydrometricSiteGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebHydrometricSiteGzFile(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebDrogueRunGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebDrogueRunGzFile(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebMWQMLookupMPNGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMWQMLookupMPNGzFile();
        }
        public async Task<ActionResult<bool>> CreateWebMikeScenarioGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebMikeScenarioGzFile(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebClimateDataValueGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebClimateDataValueGzFile(TVItemID);
        }
        public async Task<ActionResult<bool>> CreateWebHydrometricDataValueGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebHydrometricDataValueGzFile(TVItemID);
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
        public async Task<ActionResult<bool>> CreateWebPolSourceSiteGzFile(int TVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            return await DoCreateWebPolSourceSiteGzFile(TVItemID);
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
