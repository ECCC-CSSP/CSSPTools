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
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Linq;

namespace CSSPServices
{
    public interface IReadGzFileService
    {
        Task<ActionResult<T>> ReadJSON<T>(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear);
    }
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBFilesManagementContext dbFM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private ICreateGzFileService CreateGzFileService { get; }
        private IDownloadGzFileService DownloadGzFileService { get; }
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
        public ReadGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService,
            IEnums enums, ICreateGzFileService CreateGzFileService, IDownloadGzFileService DownloadGzFileService, CSSPDBContext db, CSSPDBFilesManagementContext dbFM)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.CreateGzFileService = CreateGzFileService;
            this.DownloadGzFileService = DownloadGzFileService;
            this.db = db;
            this.dbFM = dbFM;

            Setup();
        }
        #endregion Constructors

        #region Functions public
        public async Task<ActionResult<T>> ReadJSON<T>(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            string fileName = "";
            int Year = 0;
            switch (webTypeYear)
            {
                case WebTypeYearEnum.Year1980:
                    Year = 1980;
                    break;
                case WebTypeYearEnum.Year1990:
                    Year = 1990;
                    break;
                case WebTypeYearEnum.Year2000:
                    Year = 2000;
                    break;
                case WebTypeYearEnum.Year2010:
                    Year = 2010;
                    break;
                case WebTypeYearEnum.Year2020:
                    Year = 2020;
                    break;
                case WebTypeYearEnum.Year2030:
                    Year = 2030;
                    break;
                case WebTypeYearEnum.Year2040:
                    Year = 2040;
                    break;
                case WebTypeYearEnum.Year2050:
                    Year = 2050;
                    break;
                default:
                    Year = 0;
                    break;
            }

            switch (webType)
            {
                case WebTypeEnum.WebRoot:
                    fileName = "WebRoot.gz";
                    break;
                case WebTypeEnum.WebCountry:
                    fileName = $"WebCountry_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebProvince:
                    fileName = $"WebProvince_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebArea:
                    fileName = $"WebArea_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMunicipalities:
                    fileName = $"WebMunicipalities_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebSector:
                    fileName = $"WebSector_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebSubsector:
                    fileName = $"WebSubsector_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMunicipality:
                    fileName = $"WebMunicipality_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMWQMSample:
                    fileName = $"WebMWQMSample_{ TVItemID }_{ Year }_{ Year + 9 }.gz";
                    break;
                case WebTypeEnum.WebSamplingPlan:
                    fileName = $"WebSamplingPlan_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMWQMRun:
                    fileName = $"WebMWQMRun_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMWQMSite:
                    fileName = $"WebMWQMSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebContact:
                    fileName = $"WebContact.gz";
                    break;
                case WebTypeEnum.WebClimateSite:
                    fileName = $"WebClimateSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebHydrometricSite:
                    fileName = $"WebHydrometricSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebDrogueRun:
                    fileName = $"WebDrogueRun_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMWQMLookupMPN:
                    fileName = $"WebMWQMLookupMPN.gz";
                    break;
                case WebTypeEnum.WebMikeScenario:
                    fileName = $"WebMikeScenario_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebClimateDataValue:
                    fileName = $"WebClimateDataValue_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebHydrometricDataValue:
                    fileName = $"WebHydrometricDataValue_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebHelpDoc:
                    fileName = $"WebHelpDoc.gz";
                    break;
                case WebTypeEnum.WebTideLocation:
                    fileName = $"WebTideLocation.gz";
                    break;
                case WebTypeEnum.WebPolSourceSite:
                    fileName = $"WebPolSourceSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebPolSourceGrouping:
                    fileName = $"WebPolSourceGrouping.gz";
                    break;
                case WebTypeEnum.WebReportType:
                    fileName = $"WebReportType.gz";
                    break;
                default:
                    return await Task.FromResult(BadRequest($"{ webType } not implemented yet"));
            }

            return await DoReadJSON<T>(webType, fileName, 0, webTypeYear);
        }
        #endregion Functions public

        #region Functions private
        private async Task<ActionResult<T>> DoReadJSON<T>(WebTypeEnum webType, string fileName, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            bool gzExistLocaly = false;
            bool gzExist = false;
            bool gzLocalIsUpToDate = false;

            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            FileInfo fiGZ = new FileInfo(LocalJSONPath + string.Format(fileName, TVItemID));

            if (fiGZ.Exists)
            {
                gzExistLocaly = true;
            }

            if (LoggedInService.HasInternetConnection)
            {
                BlobClient blobClient = new BlobClient(AzureCSSPStorageConnectionString, AzureCSSPStorageCSSPJSON, fileName);

                BlobProperties blobProperties = blobClient.GetProperties();
                if (blobProperties == null) // does not exist on Azure - need to create it
                {
                    ActionResult<bool> actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);

                    if (((ObjectResult)actionRes.Result).StatusCode != 200)
                    {
                        return await Task.FromResult(BadRequest($"Could not create file { fiGZ.Name } on Azure"));
                    }

                    if ((bool)((OkObjectResult)actionRes.Result).Value)
                    {
                        gzExist = true;
                    }
                }

                if (gzExistLocaly)
                {
                    CSSPFile csspFile = (from c in dbFM.CSSPFiles
                                         where c.AzureStorage == AzureCSSPStorageCSSPJSON
                                         && c.AzureFileName == fiGZ.Name
                                         select c).FirstOrDefault();

                    if (csspFile == null)
                    {
                        return await Task.FromResult(BadRequest($"Could not find CSSPFile from CSSPDBFileManagement.db " +
                            $"where AzureStoreage = [{ AzureCSSPStorageCSSPJSON }] and AzureFileName = [{ fiGZ.Name }]"));
                    }

                    if (blobProperties.ETag.Equals(csspFile.AzureETag))
                    {
                        gzLocalIsUpToDate = true;
                    }
                }

                if (!gzLocalIsUpToDate)
                {
                    ActionResult<bool> actionRes = await DownloadGzFileService.DownloadGzFile(fiGZ.Name);

                    if (((ObjectResult)actionRes.Result).StatusCode != 200)
                    {
                        return await Task.FromResult(actionRes.Result);
                    }
                }
            }

            using (FileStream gzipFileStream = fiGZ.OpenRead())
            {
                using (GZipStream gzStream = new GZipStream(gzipFileStream, CompressionMode.Decompress))
                {
                    using (StreamReader sr = new StreamReader(gzStream))
                    {
                        return await Task.FromResult(Ok(JsonSerializer.Deserialize<T>(sr.ReadToEnd())));
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
