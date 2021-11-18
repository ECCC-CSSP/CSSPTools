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

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> ValidateDBsAsync(string FunctionName)
        {
            if (db == null && dbLocal == null)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "db || dbLocal"));
            }

            if (Local)
            {
                if (string.IsNullOrWhiteSpace(Configuration["CSSPJSONPathLocal"]))
                {
                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPJSONPathLocal"));
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Configuration["AzureStoreCSSPJSONPath"]))
                {
                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "AzureStoreCSSPJSONPath"));
                }

                if (string.IsNullOrWhiteSpace(AzureStoreHash))
                {
                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "AzureStoreHash"));
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
