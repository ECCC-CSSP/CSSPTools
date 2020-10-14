/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<ActionResult<T>> DoReadJSON<T>(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            bool gzExistLocaly = false;
            bool gzLocalIsUpToDate = false;

            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            string fileName = await BaseGzFileService.GetFileName(webType, TVItemID, webTypeYear);

            FileInfo fiGZ = new FileInfo(CSSPJSONPath + string.Format(fileName, TVItemID));

            if (fiGZ.Exists)
            {
                gzExistLocaly = true;
            }

            bool HasInternetConnection = false;

            var actionPreferenceHasInternetConnection = await PreferenceService.GetPreferenceWithVariableName("HasInternetConnection");
            if (((ObjectResult)actionPreferenceHasInternetConnection.Result).StatusCode == 200)
            {
                Preference preference = (Preference)((OkObjectResult)actionPreferenceHasInternetConnection.Result).Value;
                HasInternetConnection = bool.Parse(preference.VariableValue);
            }

            if (HasInternetConnection)
            {
                string AzureStore = "";

                var actionPreferenceAzureStore = await PreferenceService.GetPreferenceWithVariableName("AzureStore");
                if (((ObjectResult)actionPreferenceAzureStore.Result).StatusCode == 200)
                {
                    Preference preference = (Preference)((OkObjectResult)actionPreferenceAzureStore.Result).Value;
                    AzureStore = preference.VariableValue;
                }

                BlobClient blobClient = new BlobClient(AzureStore, AzureStoreCSSPJSONPath, fileName);
                BlobProperties blobProperties = null;

                try
                {
                    blobProperties = blobClient.GetProperties();

                }
                catch (RequestFailedException ex)
                {
                    if (ex.Status == 404)
                    {
                        using (HttpClient httpClient = new HttpClient())
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalService.LoggedInContactInfo.LoggedInContact.Token);
                            var response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/CreateGzFile/{ (int)webType }/{ TVItemID }/{ (int)webTypeYear }");

                            if ((int)response.Result.StatusCode != 200)
                            {
                                if ((int)response.Result.StatusCode == 401)
                                {
                                    return await Task.FromResult(BadRequest(CSSPCultureServicesRes.NeedToBeLoggedIn));
                                }
                                else if ((int)response.Result.StatusCode == 500)
                                {
                                    return await Task.FromResult(BadRequest(CSSPCultureServicesRes.ServerNotRespondingDoYouHaveInternetConnection));
                                }
                            }

                            // gz File should now exist on Azure
                        }
                    }
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.UnmanagedServerError_, ex.Message)));
                }

                if (blobProperties == null)
                {
                    try
                    {
                        blobProperties = blobClient.GetProperties();
                    }
                    catch (Exception ex)
                    {
                        return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.UnmanagedServerError_, ex.Message)));
                    }
                }

                if (gzExistLocaly)
                {
                    CSSPFile csspFile = null;

                    var actionCSSPFile = await CSSPDBFilesManagementService.GetWithAzureStorageAndAzureFileName(AzureStoreCSSPJSONPath, fiGZ.Name);
                    if (((ObjectResult)actionCSSPFile.Result).StatusCode == 200)
                    {
                        csspFile = (CSSPFile)((OkObjectResult)actionCSSPFile.Result).Value;
                    }

                    if (csspFile == null || blobProperties.ETag.ToString().Replace("\"", "") == csspFile.AzureETag)
                    {
                        gzLocalIsUpToDate = true;
                    }
                }

                if (!gzLocalIsUpToDate)
                {
                    var actionRes = await DownloadGzFileService.DownloadGzFile(webType, TVItemID, webTypeYear);

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
    }
}
