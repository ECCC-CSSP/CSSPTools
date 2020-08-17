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
using Azure.Storage.Blobs;
using System.Linq;
using Azure;

namespace CSSPServices
{
    public interface IDownloadGzFileService
    {
        Task<ActionResult<bool>> DownloadGzFile(string FileName);
    }
    public partial class DownloadGzFileService : ControllerBase, IDownloadGzFileService
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
        private bool StoreLocal { get; set; }
        private bool StoreInAzure { get; set; }
        private string AzureCSSPStorageConnectionString { get; set; }
        private string AzureCSSPStorageCustomerProvidedKey { get; set; }
        private string AzureCSSPStorageCSSPFiles { get; set; }
        private string AzureCSSPStorageCSSPJSON { get; set; }
        private string LocalJSONPath { get; set; }
        #endregion Properties

        #region Constructors
        public DownloadGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, 
            IEnums enums, CSSPDBContext db, CSSPDBFilesManagementContext dbFM)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbFM = dbFM;

            Setup();
        }
        #endregion Constructors

        #region Functions public

        public async Task<ActionResult<bool>> DownloadGzFile(string FileName)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            try
            {
                BlobClient blobClient = new BlobClient(AzureCSSPStorageConnectionString, AzureCSSPStorageCSSPJSON, FileName);

                Response response = await blobClient.DownloadToAsync($"{ LocalJSONPath }{ FileName }");
                if (response.Status == 206)
                {
                    CSSPFile csspFile = (from c in dbFM.CSSPFiles
                                         where c.AzureStorage == AzureCSSPStorageCSSPJSON
                                         && c.AzureFileName == FileName
                                         select c).FirstOrDefault();

                    if (csspFile == null)
                    {
                        int LastIndex = (from c in dbFM.CSSPFiles
                                             orderby c.CSSPFileID descending
                                             select c.CSSPFileID).FirstOrDefault();

                        csspFile = new CSSPFile()
                        {
                            CSSPFileID = LastIndex + 1,
                            AzureStorage = AzureCSSPStorageCSSPJSON,
                            AzureFileName = FileName,
                            AzureETag = response.Headers.ETag.ToString(),
                            AzureCreationTime = DateTime.Now,
                        };

                        try
                        {
                            dbFM.CSSPFiles.Add(csspFile);
                            await dbFM.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            return await Task.FromResult(BadRequest($"Could not add CSSPFile to CSSPDBFileManagement.db with AzureStorage = [{ AzureCSSPStorageCSSPJSON}] and AzureFileName = [{ FileName }]. Exception: [{ ex.Message }]"));
                        }
                    }

                    return await Task.FromResult(Ok(true));
                }
                else
                {
                    return await Task.FromResult(BadRequest($"Error while trying to download [{ FileName }] from Azure"));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest($"Error while trying to download [{ FileName }] from Azure. Exection: [{ ex.Message }]"));
            }
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
            LocalJSONPath = Configuration.GetValue<string>("LocalJSONPath");

            DirectoryInfo di = new DirectoryInfo(LocalJSONPath);

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
        }
        #endregion Functions private
    }
}
