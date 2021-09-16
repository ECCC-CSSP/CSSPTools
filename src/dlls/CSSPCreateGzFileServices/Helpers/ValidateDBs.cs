/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> ValidateDBs(string FunctionName)
        {
            if (db == null && dbLocal == null)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "db || dbLocal"));
            }

            if (dbLocal != null)
            {
                if (string.IsNullOrWhiteSpace(config.CSSPJSONPathLocal))
                {
                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPJSONPathLocal"));
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(config.AzureStoreCSSPJSONPath))
                {
                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "AzureStoreCSSPJSONPath"));
                }

                if (string.IsNullOrWhiteSpace(config.AzureStore))
                {
                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "AzureStore"));
                }
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0)
            {
                CSSPLogService.EndFunctionLog(FunctionName);
                await CSSPLogService.Save();

                return await Task.FromResult(false);                
            }

            return await Task.FromResult(true);
        }
    }
}
