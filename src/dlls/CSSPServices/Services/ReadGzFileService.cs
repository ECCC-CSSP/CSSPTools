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
using System.Text.Json;
using System.IO.Compression;
using System.Net.Http.Headers;

namespace CSSPServices
{
    public interface IReadGzFileService
    {
        Task<WebRoot> ReadWebRootGzFile();
        Task<WebCountry> ReadWebCountryGzFile(int CountryTVItemID);
        Task<WebProvince> ReadWebProvinceGzFile(int ProvinceTVItemID);
        Task<WebArea> ReadWebAreaGzFile(int AreaTVItemID);
        Task<WebMunicipalities> ReadWebMunicipalitiesGzFile(int ProvinceTVItemID);
        Task<WebSector> ReadWebSectorGzFile(int SectorTVItemID);
        Task<WebSubsector> ReadWebSubsectorGzFile(int SubsectorTVItemID);
        Task<WebMunicipality> ReadWebMunicipalityGzFile(int MunicipalityTVItemID);
        Task<WebMWQMSample> ReadWeb10YearOfSample1980_1989FromSubsectorGzFile(int SubsectorTVItemID);
        Task<WebMWQMSample> ReadWeb10YearOfSample1990_1999FromSubsectorGzFile(int SubsectorTVItemID);
        Task<WebMWQMSample> ReadWeb10YearOfSample2000_2009FromSubsectorGzFile(int SubsectorTVItemID);
        Task<WebMWQMSample> ReadWeb10YearOfSample2010_2019FromSubsectorGzFile(int SubsectorTVItemID);
        Task<WebMWQMSample> ReadWeb10YearOfSample2020_2029FromSubsectorGzFile(int SubsectorTVItemID);
        Task<WebMWQMSample> ReadWeb10YearOfSample2030_2039FromSubsectorGzFile(int SubsectorTVItemID);
        Task<WebMWQMSample> ReadWeb10YearOfSample2040_2049FromSubsectorGzFile(int SubsectorTVItemID);
        Task<WebMWQMSample> ReadWeb10YearOfSample2050_2059FromSubsectorGzFile(int SubsectorTVItemID);
        Task<WebSamplingPlan> ReadWebSamplingPlanGzFile(int SamplingPlanID);
        Task<WebMWQMRun> ReadWebMWQMRunGzFile(int SubsectorTVItemID);
        Task<WebMWQMSite> ReadWebMWQMSiteGzFile(int SubsectorTVItemID);
        Task<WebContact> ReadWebContactGzFile();
        Task<WebClimateSite> ReadWebClimateSiteGzFile(int ProvinceTVItemID);
        Task<WebHydrometricSite> ReadWebHydrometricSiteGzFile(int ProvinceTVItemID);
        Task<WebDrogueRun> ReadWebDrogueRunGzFile(int SubsectorTVItemID);
        Task<WebMWQMLookupMPN> ReadWebMWQMLookupMPNGzFile();
        Task<WebMikeScenario> ReadWebMikeScenarioGzFile(int MikeScenarioTVItemID);
        Task<WebClimateDataValue> ReadWebClimateDataValueGzFile(int ClimateSiteTVItemID);
        Task<WebHydrometricDataValue> ReadWebHydrometricDataValueGzFile(int HydrometricSiteTVItemID);
        Task<WebHelpDoc> ReadWebHelpDocGzFile();
        Task<WebTideLocation> ReadWebTideLocationGzFile();
        Task<WebPolSourceSite> ReadWebPolSourceSiteGzFile(int SubsectorTVItemID);
        Task<WebPolSourceGrouping> ReadWebPolSourceGroupingGzFile();
        Task<WebReportType> ReadWebReportTypeGzFile();
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
        public async Task<WebRoot> ReadWebRootGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebRoot());
            }

            return await DoRead<WebRoot>("WebRoot.gz");
        }
        public async Task<WebCountry> ReadWebCountryGzFile(int CountryTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebCountry());
            }

            return await DoRead<WebCountry>($"WebCountry_{ CountryTVItemID }.gz");
        }
        public async Task<WebProvince> ReadWebProvinceGzFile(int ProvinceTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebProvince());
            }

            return await DoRead<WebProvince>($"WebProvince_{ ProvinceTVItemID }.gz");
        }
        public async Task<WebArea> ReadWebAreaGzFile(int AreaTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebArea());
            }

            return await DoRead<WebArea>($"WebArea_{ AreaTVItemID }.gz");
        }
        public async Task<WebMunicipalities> ReadWebMunicipalitiesGzFile(int ProvinceTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMunicipalities());
            }

            return await DoRead<WebMunicipalities>($"WebMunicipalities_{ ProvinceTVItemID }.gz");
        }
        public async Task<WebSector> ReadWebSectorGzFile(int SectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebSector());
            }

            return await DoRead<WebSector>($"WebSector_{ SectorTVItemID }.gz");
        }
        public async Task<WebSubsector> ReadWebSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebSubsector());
            }

            return await DoRead<WebSubsector>($"WebSubsector_{ SubsectorTVItemID }.gz");
        }
        public async Task<WebMunicipality> ReadWebMunicipalityGzFile(int MunicipalityTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMunicipality());
            }

            return await DoRead<WebMunicipality>($"WebMunicipality_{ MunicipalityTVItemID }.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample1980_1989FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoRead<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_1980_1989.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample1990_1999FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoRead<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_1990_1999.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample2000_2009FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoRead<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_2000_2009.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample2010_2019FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoRead<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_2010_2019.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample2020_2029FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoRead<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_2020_2029.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample2030_2039FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoRead<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_2030_2039.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample2040_2049FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoRead<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_2040_2049.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample2050_2059FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoRead<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_2050_2059.gz");
        }
        public async Task<WebSamplingPlan> ReadWebSamplingPlanGzFile(int SamplingPlanID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebSamplingPlan());
            }

            return await DoRead<WebSamplingPlan>($"WebSamplingPlan_{ SamplingPlanID }.gz");
        }
        public async Task<WebMWQMRun> ReadWebMWQMRunGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMRun());
            }

            return await DoRead<WebMWQMRun>($"WebMWQMRun_{ SubsectorTVItemID }.gz");
        }
        public async Task<WebMWQMSite> ReadWebMWQMSiteGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSite());
            }

            return await DoRead<WebMWQMSite>($"WebMWQMSite_{ SubsectorTVItemID }.gz");
        }
        public async Task<WebContact> ReadWebContactGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebContact());
            }

            return await DoRead<WebContact>($"WebContact.gz");
        }
        public async Task<WebClimateSite> ReadWebClimateSiteGzFile(int ProvinceTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebClimateSite());
            }

            return await DoRead<WebClimateSite>($"WebClimateSite_{ ProvinceTVItemID }.gz");
        }
        public async Task<WebHydrometricSite> ReadWebHydrometricSiteGzFile(int ProvinceTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebHydrometricSite());
            }

            return await DoRead<WebHydrometricSite>($"WebHydrometricSite_{ ProvinceTVItemID }.gz");
        }
        public async Task<WebDrogueRun> ReadWebDrogueRunGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebDrogueRun());
            }

            return await DoRead<WebDrogueRun>($"WebDrogueRun_{ SubsectorTVItemID }.gz");
        }
        public async Task<WebMWQMLookupMPN> ReadWebMWQMLookupMPNGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMLookupMPN());
            }

            return await DoRead<WebMWQMLookupMPN>($"WebMWQMLookupMPN.gz");
        }
        public async Task<WebMikeScenario> ReadWebMikeScenarioGzFile(int MikeScenarioTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMikeScenario());
            }

            return await DoRead<WebMikeScenario>($"WebMikeScenario_{ MikeScenarioTVItemID }.gz");
        }
        public async Task<WebClimateDataValue> ReadWebClimateDataValueGzFile(int ClimateSiteTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebClimateDataValue());
            }

            return await DoRead<WebClimateDataValue>($"WebClimateDataValue_{ ClimateSiteTVItemID }.gz");
        }
        public async Task<WebHydrometricDataValue> ReadWebHydrometricDataValueGzFile(int HydrometricSiteTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebHydrometricDataValue());
            }

            return await DoRead<WebHydrometricDataValue>($"WebHydrometricDataValue_{ HydrometricSiteTVItemID }.gz");
        }
        public async Task<WebHelpDoc> ReadWebHelpDocGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebHelpDoc());
            }

            return await DoRead<WebHelpDoc>($"WebHelpDoc.gz");
        }
        public async Task<WebTideLocation> ReadWebTideLocationGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebTideLocation());
            }

            return await DoRead<WebTideLocation>($"WebTideLocation.gz");
        }
        public async Task<WebPolSourceSite> ReadWebPolSourceSiteGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebPolSourceSite());
            }

            return await DoRead<WebPolSourceSite>($"WebPolSourceSite_{ SubsectorTVItemID }.gz");
        }
        public async Task<WebPolSourceGrouping> ReadWebPolSourceGroupingGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebPolSourceGrouping());
            }

            return await DoRead<WebPolSourceGrouping>($"WebPolSourceGrouping.gz");
        }
        public async Task<WebReportType> ReadWebReportTypeGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebReportType());
            }

            return await DoRead<WebReportType>($"WebReportType.gz");
        }
        #endregion Functions public

        #region Functions private
        private async Task<T> DoRead<T>(string fileName)
        {
            FileInfo fiGZ = new FileInfo(LocalJSONPath + fileName);

            if (!fiGZ.Exists)
            {
                return await Task.FromResult(JsonSerializer.Deserialize<T>(""));
            }

            using (FileStream gzipFileStream = fiGZ.OpenRead())
            {
                using (GZipStream gzStream = new GZipStream(gzipFileStream, CompressionMode.Decompress))
                {
                    using (StreamReader sr = new StreamReader(gzStream))
                    {
                        return await Task.FromResult(JsonSerializer.Deserialize<T>(sr.ReadToEnd()));
                    }
                }
            }
        }
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
