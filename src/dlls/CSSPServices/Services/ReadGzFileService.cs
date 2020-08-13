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
    public interface IReadGzFileService
    {
        Task<WebRoot> ReadWebRootGzFile();
        //Task<ActionResult<bool>> ReadWebCountryGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebProvinceGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebAreaGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebMunicipalitiesGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebSectorGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebSubsectorGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWeb10YearOfSample1980_1989FromSubsectorGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWeb10YearOfSample1990_1999FromSubsectorGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWeb10YearOfSample2000_2009FromSubsectorGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWeb10YearOfSample2010_2019FromSubsectorGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWeb10YearOfSample2020_2029FromSubsectorGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWeb10YearOfSample2030_2039FromSubsectorGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWeb10YearOfSample2040_2049FromSubsectorGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWeb10YearOfSample2050_2059FromSubsectorGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebSamplingPlanGzFile(int SamplingPlanID);
        //Task<ActionResult<bool>> ReadWebMunicipalityGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebMWQMRunGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebMWQMSiteGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebContactGzFile();
        //Task<ActionResult<bool>> ReadWebClimateSiteGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebHydrometricSiteGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebDrogueRunGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebMWQMLookupMPNGzFile();
        //Task<ActionResult<bool>> ReadWebMikeScenarioGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebClimateDataValueGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebHydrometricDataValueGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebHelpDocGzFile();
        //Task<ActionResult<bool>> ReadWebTideLocationGzFile();
        //Task<ActionResult<bool>> ReadWebPolSourceSiteGzFile(int TVItemID);
        //Task<ActionResult<bool>> ReadWebPolSourceGroupingGzFile();
        //Task<ActionResult<bool>> ReadWebReportTypeGzFile();
    }
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
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
        public ReadGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db)
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

        public async Task<bool> ReadAllGzFiles()
        {
            return await Task.FromResult(false);
            //return await DoReadAllGzFiles();
        }

        public async Task<WebRoot> ReadWebRootGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebRoot());
            }

            return await DoReadWebRootGzFile();
        }
        //public async Task<ActionResult<bool>> ReadWebCountryGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebCountryGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebProvinceGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebProvinceGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebMunicipalitiesGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebMunicipalitiesGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebAreaGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebAreaGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebSectorGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebSectorGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebSubsectorGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebSubsectorGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebMunicipalityGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebMunicipalityGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWeb10YearOfSample1980_1989FromSubsectorGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebMWQMSampleGzFile(TVItemID, 1980);
        //}
        //public async Task<ActionResult<bool>> ReadWeb10YearOfSample1990_1999FromSubsectorGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebMWQMSampleGzFile(TVItemID, 1990);
        //}
        //public async Task<ActionResult<bool>> ReadWeb10YearOfSample2000_2009FromSubsectorGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebMWQMSampleGzFile(TVItemID, 2000);
        //}
        //public async Task<ActionResult<bool>> ReadWeb10YearOfSample2010_2019FromSubsectorGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebMWQMSampleGzFile(TVItemID, 2010);
        //}
        //public async Task<ActionResult<bool>> ReadWeb10YearOfSample2020_2029FromSubsectorGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebMWQMSampleGzFile(TVItemID, 2020);
        //}
        //public async Task<ActionResult<bool>> ReadWeb10YearOfSample2030_2039FromSubsectorGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebMWQMSampleGzFile(TVItemID, 2030);
        //}
        //public async Task<ActionResult<bool>> ReadWeb10YearOfSample2040_2049FromSubsectorGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebMWQMSampleGzFile(TVItemID, 2040);
        //}
        //public async Task<ActionResult<bool>> ReadWeb10YearOfSample2050_2059FromSubsectorGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebMWQMSampleGzFile(TVItemID, 2050);
        //}
        //public async Task<ActionResult<bool>> ReadWebSamplingPlanGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebSamplingPlanGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebMWQMRunGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebMWQMRunGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebMWQMSiteGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebMWQMSiteGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebContactGzFile()
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebContactGzFile();
        //}
        //public async Task<ActionResult<bool>> ReadWebClimateSiteGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebClimateSiteGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebHydrometricSiteGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebHydrometricSiteGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebDrogueRunGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebDrogueRunGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebMWQMLookupMPNGzFile()
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebMWQMLookupMPNGzFile();
        //}
        //public async Task<ActionResult<bool>> ReadWebMikeScenarioGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebMikeScenarioGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebClimateDataValueGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebClimateDataValueGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebHydrometricDataValueGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebHydrometricDataValueGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebHelpDocGzFile()
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebHelpDocGzFile();
        //}
        //public async Task<ActionResult<bool>> ReadWebTideLocationGzFile()
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebTideLocationGzFile();
        //}
        //public async Task<ActionResult<bool>> ReadWebPolSourceSiteGzFile(int TVItemID)
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebPolSourceSiteGzFile(TVItemID);
        //}
        //public async Task<ActionResult<bool>> ReadWebPolSourceGroupingGzFile()
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebPolSourceGroupingGzFile();
        //}
        //public async Task<ActionResult<bool>> ReadWebReportTypeGzFile()
        //{
        //    if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
        //    {
        //        return await Task.FromResult(Unauthorized());
        //    }

        //    return await DoReadWebReportTypeGzFile();
        //}
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
