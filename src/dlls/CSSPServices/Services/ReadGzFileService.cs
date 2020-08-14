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

            return await DoReadJSON<WebRoot>("WebRoot.gz");
        }
        public async Task<WebCountry> ReadWebCountryGzFile(int CountryTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebCountry());
            }

            return await DoReadJSON<WebCountry>($"WebCountry_{ CountryTVItemID }.gz");
        }
        public async Task<WebProvince> ReadWebProvinceGzFile(int ProvinceTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebProvince());
            }

            return await DoReadJSON<WebProvince>($"WebProvince_{ ProvinceTVItemID }.gz");
        }
        public async Task<WebArea> ReadWebAreaGzFile(int AreaTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebArea());
            }

            return await DoReadJSON<WebArea>($"WebArea_{ AreaTVItemID }.gz");
        }
        public async Task<WebMunicipalities> ReadWebMunicipalitiesGzFile(int ProvinceTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMunicipalities());
            }

            return await DoReadJSON<WebMunicipalities>($"WebMunicipalities_{ ProvinceTVItemID }.gz");
        }
        public async Task<WebSector> ReadWebSectorGzFile(int SectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebSector());
            }

            return await DoReadJSON<WebSector>($"WebSector_{ SectorTVItemID }.gz");
        }
        public async Task<WebSubsector> ReadWebSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebSubsector());
            }

            return await DoReadJSON<WebSubsector>($"WebSubsector_{ SubsectorTVItemID }.gz");
        }
        public async Task<WebMunicipality> ReadWebMunicipalityGzFile(int MunicipalityTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMunicipality());
            }

            return await DoReadJSON<WebMunicipality>($"WebMunicipality_{ MunicipalityTVItemID }.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample1980_1989FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoReadJSON<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_1980_1989.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample1990_1999FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoReadJSON<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_1990_1999.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample2000_2009FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoReadJSON<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_2000_2009.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample2010_2019FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoReadJSON<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_2010_2019.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample2020_2029FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoReadJSON<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_2020_2029.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample2030_2039FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoReadJSON<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_2030_2039.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample2040_2049FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoReadJSON<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_2040_2049.gz");
        }
        public async Task<WebMWQMSample> ReadWeb10YearOfSample2050_2059FromSubsectorGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            return await DoReadJSON<WebMWQMSample>($"WebMWQMSample_{ SubsectorTVItemID }_2050_2059.gz");
        }
        public async Task<WebSamplingPlan> ReadWebSamplingPlanGzFile(int SamplingPlanID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebSamplingPlan());
            }

            return await DoReadJSON<WebSamplingPlan>($"WebSamplingPlan_{ SamplingPlanID }.gz");
        }
        public async Task<WebMWQMRun> ReadWebMWQMRunGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMRun());
            }

            return await DoReadJSON<WebMWQMRun>($"WebMWQMRun_{ SubsectorTVItemID }.gz");
        }
        public async Task<WebMWQMSite> ReadWebMWQMSiteGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSite());
            }

            return await DoReadJSON<WebMWQMSite>($"WebMWQMSite_{ SubsectorTVItemID }.gz");
        }
        public async Task<WebContact> ReadWebContactGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebContact());
            }

            return await DoReadJSON<WebContact>($"WebContact.gz");
        }
        public async Task<WebClimateSite> ReadWebClimateSiteGzFile(int ProvinceTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebClimateSite());
            }

            return await DoReadJSON<WebClimateSite>($"WebClimateSite_{ ProvinceTVItemID }.gz");
        }
        public async Task<WebHydrometricSite> ReadWebHydrometricSiteGzFile(int ProvinceTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebHydrometricSite());
            }

            return await DoReadJSON<WebHydrometricSite>($"WebHydrometricSite_{ ProvinceTVItemID }.gz");
        }
        public async Task<WebDrogueRun> ReadWebDrogueRunGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebDrogueRun());
            }

            return await DoReadJSON<WebDrogueRun>($"WebDrogueRun_{ SubsectorTVItemID }.gz");
        }
        public async Task<WebMWQMLookupMPN> ReadWebMWQMLookupMPNGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMLookupMPN());
            }

            return await DoReadJSON<WebMWQMLookupMPN>($"WebMWQMLookupMPN.gz");
        }
        public async Task<WebMikeScenario> ReadWebMikeScenarioGzFile(int MikeScenarioTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebMikeScenario());
            }

            return await DoReadJSON<WebMikeScenario>($"WebMikeScenario_{ MikeScenarioTVItemID }.gz");
        }
        public async Task<WebClimateDataValue> ReadWebClimateDataValueGzFile(int ClimateSiteTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebClimateDataValue());
            }

            return await DoReadJSON<WebClimateDataValue>($"WebClimateDataValue_{ ClimateSiteTVItemID }.gz");
        }
        public async Task<WebHydrometricDataValue> ReadWebHydrometricDataValueGzFile(int HydrometricSiteTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebHydrometricDataValue());
            }

            return await DoReadJSON<WebHydrometricDataValue>($"WebHydrometricDataValue_{ HydrometricSiteTVItemID }.gz");
        }
        public async Task<WebHelpDoc> ReadWebHelpDocGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebHelpDoc());
            }

            return await DoReadJSON<WebHelpDoc>($"WebHelpDoc.gz");
        }
        public async Task<WebTideLocation> ReadWebTideLocationGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebTideLocation());
            }

            return await DoReadJSON<WebTideLocation>($"WebTideLocation.gz");
        }
        public async Task<WebPolSourceSite> ReadWebPolSourceSiteGzFile(int SubsectorTVItemID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebPolSourceSite());
            }

            return await DoReadJSON<WebPolSourceSite>($"WebPolSourceSite_{ SubsectorTVItemID }.gz");
        }
        public async Task<WebPolSourceGrouping> ReadWebPolSourceGroupingGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebPolSourceGrouping());
            }

            return await DoReadJSON<WebPolSourceGrouping>($"WebPolSourceGrouping.gz");
        }
        public async Task<WebReportType> ReadWebReportTypeGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(new WebReportType());
            }

            return await DoReadJSON<WebReportType>($"WebReportType.gz");
        }
        #endregion Functions public

        #region Functions private
        private async Task<T> DoReadJSON<T>(string fileName)
        {
            // if user has internet connection
            // should check if file already exist locally
            // should compare Azure Store ETag with the Etag in CSSPDBFilesManagement.db
            // download if not same ETag else no need to download
            // 
            // if file does not exist in Azure 
            // send CreateGzFile command to Azure CSSPWebAPIs
            // once created
            // get file properties (ETag) from Azure and store the info in CSSPDBFilesManagement.db
            // then download and store locally using DownloadGzFile
            // then read the file using ReadGzFile

            // if user has no internet connection
            // just read file if exist
            // send message if it does not exist
            // 
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
