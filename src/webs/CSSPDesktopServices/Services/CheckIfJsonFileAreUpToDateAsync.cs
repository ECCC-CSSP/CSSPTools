﻿using CSSPCultureServices.Services;
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
using Azure;
using Azure.Storage.Files.Shares.Models;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> CheckIfJsonFileAreUpToDateAsync()
        {
            foreach (string jsonFileName in await GetJsonFileNameListAsync())
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

                FileInfo fi = new FileInfo($"{ Configuration["CSSPDesktopPath"] }{ jsonFileName }");

                ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(contact.AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
                ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
                ShareFileClient file = directory.GetFileClient(jsonFileName);
                ShareFileProperties shareFileProperties = null;

                try
                {
                    shareFileProperties = file.GetProperties();
                }
                catch (RequestFailedException ex)
                {
                    if (ex.Status == 404)
                    {
                        string error = string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, Configuration["AzureStoreCSSPJsonPath"], jsonFileName);
                        AppendStatus(new AppendEventArgs(error));
                        CSSPLogService.AppendError(error);
                        return await Task.FromResult(true);
                    }
                }

                if (shareFileProperties == null)
                {
                    string error = string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, "csspjson", jsonFileName);
                    AppendStatus(new AppendEventArgs(error));
                    CSSPLogService.AppendError(error);
                    return await Task.FromResult(true);
                }

                ManageFile manageFile = (from c in dbManage.ManageFiles
                                         where c.AzureStorage == "csspjson"
                                         && c.AzureFileName == jsonFileName
                                         select c).FirstOrDefault();

                if (manageFile == null || shareFileProperties.ETag.ToString().Replace("\"", "") != manageFile.AzureETag)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.AzureFile_Changed, jsonFileName)));
                    UpdateIsNeeded = true;
                }
                else
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.AzureFile_DidNotChanged, jsonFileName)));
                }
            }

            return await Task.FromResult(false);
        }
    }
}
