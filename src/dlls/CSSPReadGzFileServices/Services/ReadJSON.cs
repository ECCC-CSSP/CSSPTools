/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPEnums;
using CSSPWebModels;
using CSSPFileServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.IO.Compression;
using System.Text.Json;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        public async Task<ActionResult<T>> ReadJSON<T>(WebTypeEnum webType, int TVItemID = 0)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebTypeEnum: { webType }, TVItemID: { TVItemID })";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            bool gzExistLocaly = false;
            bool gzLocalIsUpToDate = false;
            bool JustRead = false;

            string fileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            FileInfo fiGZ = new FileInfo(Configuration["CSSPJSONPath"] + string.Format(fileName, TVItemID));

            if (TVItemID > 0)
            {
                if (fiGZ.Exists)
                {
                    gzExistLocaly = true;
                }

                if (gzExistLocaly)
                {
                    ManageFile manageFile = null;

                    var actionCSSPFile = await ManageFileService.ManageFileGetWithAzureStorageAndAzureFileName(Configuration["AzureStoreCSSPJSONPath"], fiGZ.Name);
                    manageFile = (ManageFile)((OkObjectResult)actionCSSPFile.Result).Value;

                    if (manageFile != null && manageFile.LoadedOnce)
                    {
                        JustRead = true;
                    }
                }

                if (!JustRead)
                {
                    bool HasInternetConnection = false;

                    HasInternetConnection = (from c in dbManage.Contacts
                                             select c.HasInternetConnection).FirstOrDefault() ?? false;

                    if (HasInternetConnection)
                    {
                        BlobClient blobClient = new BlobClient(CSSPScrambleService.Descramble(Configuration["AzureStore"]), Configuration["AzureStoreCSSPJSONPath"], fileName);
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
                                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.Token);
                                    var response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/CreateGzFile/{ (int)webType }/{ TVItemID }");

                                    if ((int)response.Result.StatusCode != 200)
                                    {
                                        if ((int)response.Result.StatusCode == 401)
                                        {
                                            return await CSSPLogService.EndFunctionReturnUnauthorized(FunctionName, CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                                        }
                                        else if ((int)response.Result.StatusCode == 500)
                                        {
                                            return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, CSSPCultureServicesRes.ServerNotRespondingDoYouHaveInternetConnection);
                                        }
                                    }

                                    // gz File should now exist on Azure
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";

                            return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, $"{ ex.Message } { inner }");
                        }

                        if (blobProperties == null)
                        {
                            try
                            {
                                blobProperties = blobClient.GetProperties();
                            }
                            catch (Exception ex)
                            {
                                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";

                                return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, $"{ ex.Message } { inner }");
                            }
                        }

                        if (gzExistLocaly)
                        {
                            ManageFile manageFile = null;

                            var actionCSSPFile = await ManageFileService.ManageFileGetWithAzureStorageAndAzureFileName(Configuration["AzureStoreCSSPJSONPath"], fiGZ.Name);
                            manageFile = (ManageFile)((OkObjectResult)actionCSSPFile.Result).Value;

                            if (manageFile == null)
                            {
                                gzLocalIsUpToDate = false;
                            }
                            else
                            {
                                if (!manageFile.LoadedOnce)
                                {
                                    manageFile.LoadedOnce = true;

                                    var actionCSSPFileAdded = await ManageFileService.ManageFileAddOrModify(manageFile);
                                    if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 200)
                                    {
                                        manageFile = (ManageFile)((OkObjectResult)actionCSSPFileAdded.Result).Value;
                                    }
                                    else if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 401)
                                    {
                                        return await CSSPLogService.EndFunctionReturnUnauthorized(FunctionName, CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                                    }
                                    else
                                    {
                                        return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, ((BadRequestObjectResult)actionCSSPFileAdded.Result).Value.ToString());
                                    }

                                }

                                if (blobProperties.ETag.ToString().Replace("\"", "") == manageFile.AzureETag)
                                {
                                    gzLocalIsUpToDate = true;
                                }
                            }
                        }

                        if (!gzLocalIsUpToDate)
                        {
                            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);

                            if (((ObjectResult)actionRes.Result).StatusCode != 200)
                            {
                                CSSPLogService.EndFunctionLog(FunctionName);

                                return await Task.FromResult(actionRes.Result);
                            }
                        }
                    }
                }

                using (FileStream gzipFileStream = fiGZ.OpenRead())
                {
                    using (GZipStream gzStream = new GZipStream(gzipFileStream, CompressionMode.Decompress))
                    {
                        using (StreamReader sr = new StreamReader(gzStream))
                        {
                            FileInfo fiGZLocal = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ fiGZ.Name }");

                            T FromAzureStore = JsonSerializer.Deserialize<T>(sr.ReadToEnd());
                            T FromLocal = JsonSerializer.Deserialize<T>("{}");

                            if (fiGZLocal.Exists)
                            {
                                using (FileStream gzipFileStreamLocal = fiGZLocal.OpenRead())
                                {
                                    using (GZipStream gzStreamLocal = new GZipStream(gzipFileStreamLocal, CompressionMode.Decompress))
                                    {
                                        using (StreamReader srLocal = new StreamReader(gzStreamLocal))
                                        {
                                            FromLocal = JsonSerializer.Deserialize<T>(srLocal.ReadToEnd());
                                        }
                                    }
                                }
                            }

                            switch (webType)
                            {
                                case WebTypeEnum.WebAllAddresses:
                                    await DoMergeJsonWebAllAddresses(FromAzureStore as WebAllAddresses, FromLocal as WebAllAddresses);
                                    break;
                                case WebTypeEnum.WebAllContacts:
                                    await DoMergeJsonWebAllContacts(FromAzureStore as WebAllContacts, FromLocal as WebAllContacts);
                                    break;
                                case WebTypeEnum.WebAllCountries:
                                    await DoMergeJsonWebAllCountries(FromAzureStore as WebAllCountries, FromLocal as WebAllCountries);
                                    break;
                                case WebTypeEnum.WebAllEmails:
                                    await DoMergeJsonWebAllEmails(FromAzureStore as WebAllEmails, FromLocal as WebAllEmails);
                                    break;
                                case WebTypeEnum.WebAllHelpDocs:
                                    await DoMergeJsonWebAllHelpDocs(FromAzureStore as WebAllHelpDocs, FromLocal as WebAllHelpDocs);
                                    break;
                                case WebTypeEnum.WebAllMunicipalities:
                                    await DoMergeJsonWebAllMunicipalities(FromAzureStore as WebAllMunicipalities, FromLocal as WebAllMunicipalities);
                                    break;
                                case WebTypeEnum.WebAllMWQMLookupMPNs:
                                    await DoMergeJsonWebAllMWQMLookupMPNs(FromAzureStore as WebAllMWQMLookupMPNs, FromLocal as WebAllMWQMLookupMPNs);
                                    break;
                                case WebTypeEnum.WebAllPolSourceGroupings:
                                    await DoMergeJsonWebAllPolSourceGroupings(FromAzureStore as WebAllPolSourceGroupings, FromLocal as WebAllPolSourceGroupings);
                                    break;
                                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                                    await DoMergeJsonWebAllPolSourceSiteEffectTerms(FromAzureStore as WebAllPolSourceSiteEffectTerms, FromLocal as WebAllPolSourceSiteEffectTerms);
                                    break;
                                case WebTypeEnum.WebAllProvinces:
                                    await DoMergeJsonWebAllProvinces(FromAzureStore as WebAllProvinces, FromLocal as WebAllProvinces);
                                    break;
                                case WebTypeEnum.WebAllReportTypes:
                                    await DoMergeJsonWebAllReportTypes(FromAzureStore as WebAllReportTypes, FromLocal as WebAllReportTypes);
                                    break;
                                case WebTypeEnum.WebAllTels:
                                    await DoMergeJsonWebAllTels(FromAzureStore as WebAllTels, FromLocal as WebAllTels); ;
                                    break;
                                case WebTypeEnum.WebAllTideLocations:
                                    await DoMergeJsonWebAllTideLocations(FromAzureStore as WebAllTideLocations, FromLocal as WebAllTideLocations); ;
                                    break;
                                case WebTypeEnum.WebArea:
                                    await DoMergeJsonWebArea(FromAzureStore as WebArea, FromLocal as WebArea);
                                    break;
                                case WebTypeEnum.WebClimateSites:
                                    await DoMergeJsonWebClimateSites(FromAzureStore as WebClimateSites, FromLocal as WebClimateSites);
                                    break;
                                case WebTypeEnum.WebCountry:
                                    await DoMergeJsonWebCountry(FromAzureStore as WebCountry, FromLocal as WebCountry);
                                    break;
                                case WebTypeEnum.WebDrogueRuns:
                                    await DoMergeJsonWebDrogueRuns(FromAzureStore as WebDrogueRuns, FromLocal as WebDrogueRuns);
                                    break;
                                case WebTypeEnum.WebHydrometricSites:
                                    await DoMergeJsonWebHydrometricSites(FromAzureStore as WebHydrometricSites, FromLocal as WebHydrometricSites);
                                    break;
                                case WebTypeEnum.WebLabSheets:
                                    await DoMergeJsonWebLabSheets(FromAzureStore as WebLabSheets, FromLocal as WebLabSheets);
                                    break;
                                case WebTypeEnum.WebMikeScenarios:
                                    await DoMergeJsonWebMikeScenarios(FromAzureStore as WebMikeScenarios, FromLocal as WebMikeScenarios);
                                    break;
                                case WebTypeEnum.WebMonitoringOtherStatsCountry:
                                    // No merging needed
                                    break;
                                case WebTypeEnum.WebMonitoringRoutineStatsCountry:
                                    // No merging needed
                                    break;
                                case WebTypeEnum.WebMonitoringOtherStatsProvince:
                                    // No merging needed
                                    break;
                                case WebTypeEnum.WebMonitoringRoutineStatsProvince:
                                    // No merging needed
                                    break;
                                case WebTypeEnum.WebMunicipality:
                                    await DoMergeJsonWebMunicipality(FromAzureStore as WebMunicipality, FromLocal as WebMunicipality);
                                    break;
                                case WebTypeEnum.WebMWQMRuns:
                                    await DoMergeJsonWebMWQMRuns(FromAzureStore as WebMWQMRuns, FromLocal as WebMWQMRuns);
                                    break;
                                case WebTypeEnum.WebMWQMSamples1980_2020:
                                    await DoMergeJsonWebMWQMSamples1980_2020(FromAzureStore as WebMWQMSamples, FromLocal as WebMWQMSamples);
                                    break;
                                case WebTypeEnum.WebMWQMSamples2021_2060:
                                    await DoMergeJsonWebMWQMSamples2021_2060(FromAzureStore as WebMWQMSamples, FromLocal as WebMWQMSamples);
                                    break;
                                case WebTypeEnum.WebMWQMSites:
                                    await DoMergeJsonWebMWQMSites(FromAzureStore as WebMWQMSites, FromLocal as WebMWQMSites);
                                    break;
                                case WebTypeEnum.WebPolSourceSites:
                                    await DoMergeJsonWebPolSourceSites(FromAzureStore as WebPolSourceSites, FromLocal as WebPolSourceSites);
                                    break;
                                case WebTypeEnum.WebProvince:
                                    await DoMergeJsonWebProvince(FromAzureStore as WebProvince, FromLocal as WebProvince);
                                    break;
                                case WebTypeEnum.WebRoot:
                                    await DoMergeJsonWebRoot(FromAzureStore as WebRoot, FromLocal as WebRoot);
                                    break;
                                case WebTypeEnum.WebAllSearch:
                                    await DoMergeJsonWebAllSearch(FromAzureStore as WebAllSearch, FromLocal as WebAllSearch);
                                    break;
                                case WebTypeEnum.WebSector:
                                    await DoMergeJsonWebSector(FromAzureStore as WebSector, FromLocal as WebSector);
                                    break;
                                case WebTypeEnum.WebSubsector:
                                    await DoMergeJsonWebSubsector(FromAzureStore as WebSubsector, FromLocal as WebSubsector);
                                    break;
                                case WebTypeEnum.WebTideSites:
                                    await DoMergeJsonWebTideSites(FromAzureStore as WebTideSites, FromLocal as WebTideSites);
                                    break;
                                default:
                                    break;
                            }

                            CSSPLogService.EndFunctionLog(FunctionName);

                            if (CSSPLogService.ErrRes.ErrList.Count > 0)
                            {
                                return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
                            }

                            return await Task.FromResult(Ok(FromAzureStore));
                        }
                    }
                }
            }
            else
            {
                FileInfo fiGZLocal = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ fiGZ.Name }");

                T FromLocal = JsonSerializer.Deserialize<T>("{}");

                if (fiGZLocal.Exists)
                {
                    using (FileStream gzipFileStreamLocal = fiGZLocal.OpenRead())
                    {
                        using (GZipStream gzStreamLocal = new GZipStream(gzipFileStreamLocal, CompressionMode.Decompress))
                        {
                            using (StreamReader srLocal = new StreamReader(gzStreamLocal))
                            {
                                FromLocal = JsonSerializer.Deserialize<T>(srLocal.ReadToEnd());
                            }
                        }
                    }
                }

                CSSPLogService.EndFunctionLog(FunctionName);

                if (CSSPLogService.ErrRes.ErrList.Count > 0)
                {
                    return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
                }

                return await Task.FromResult(Ok(FromLocal));

            }
        }
    }
}
