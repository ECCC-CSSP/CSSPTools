using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.Extensions.Configuration;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using CSSPHelperModels;
using ManageServices;
using CSSPLocalLoggedInServices;
using CSSPCultureServices.Resources;
using CSSPScrambleServices;
using CSSPLogServices;
using System.Linq;
using System.IO;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DownloadJsonFilesFromAzure(string jsonFileName)
        {
            string enumTypeName = jsonFileName.Substring(0, jsonFileName.IndexOf("."));

            WebTypeEnum webType;

            foreach (int enumVal in Enum.GetValues(typeof(WebTypeEnum)))
            {

                if (((WebTypeEnum)enumVal).ToString() == enumTypeName)
                {
                    webType = (WebTypeEnum)enumVal;
                    break;
                }
            }

            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.DownloadingFileFromAzure_, jsonFileName)));

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPath"] }{ jsonFileName }");


            ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(contact.AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
            ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
            ShareFileClient shareFileClient = directory.GetFileClient(jsonFileName);
            ShareFileProperties shareFileProperties = null;

            try
            {
                shareFileProperties = shareFileClient.GetProperties();
            }
            catch (RequestFailedException)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, "csspjson", jsonFileName)));
                return await Task.FromResult(false);
            }

            ManageFile manageFile = (from c in dbManage.ManageFiles
                                     where c.AzureStorage == "csspjson"
                                     && c.AzureFileName == jsonFileName
                                     select c).FirstOrDefault();

            if (manageFile == null || shareFileProperties.ETag.ToString().Replace("\"", "") != manageFile.AzureETag)
            {
                ShareFileDownloadInfo download = shareFileClient.Download();
                using (FileStream stream = File.OpenWrite(fi.FullName))
                {
                    download.Content.CopyTo(stream);
                }

                if (manageFile == null)
                {
                    int LastID = (from c in dbManage.ManageFiles
                                  orderby c.ManageFileID descending
                                  select c.ManageFileID).FirstOrDefault();

                    manageFile = new ManageFile()
                    {
                        ManageFileID = LastID + 1,
                        AzureStorage = Configuration["AzureStoreCSSPJSONPath"],
                        AzureFileName = jsonFileName,
                        AzureETag = shareFileProperties.ETag.ToString(),
                        AzureCreationTimeUTC = DateTime.Parse(shareFileProperties.LastModified.ToString()),
                        LoadedOnce = true,
                    };

                    dbManage.ManageFiles.Add(manageFile);
                }
                else
                {
                    manageFile.AzureETag = shareFileProperties.ETag.ToString();
                    manageFile.LoadedOnce = true;
                }

                try
                {
                    dbManage.SaveChanges();
                }
                catch (Exception)
                {
                    return await Task.FromResult(false);
                }
            }

            return await Task.FromResult(true);
        }
    }
}
