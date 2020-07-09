/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CultureServices.Resources;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPWebServices.Services
{
    public partial class WebService : ControllerBase, IWebService
    {
        #region Functions public 
        private void CheckAndCreateStorageDirectory(IConfiguration Configuration)
        {
            List<string> StoragePathList = new List<string>() { "LocalJSONPath", "LocalFilesPath" };
            foreach(string StoragePath in StoragePathList)
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                if (Configuration.GetValue<string>(StoragePath) == null)
                {
                    throw new Exception($"{ String.Format(CultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, StoragePath) }");
                }

                DirectoryInfo di = new DirectoryInfo(Configuration.GetValue<string>(StoragePath).Replace("{AppDataPath}", appDataPath));

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
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
