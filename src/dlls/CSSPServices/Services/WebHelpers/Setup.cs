/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace CSSPServices
{
    public partial class CSSPWebService : ControllerBase, ICSSPWebService
    {
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
    }
}
