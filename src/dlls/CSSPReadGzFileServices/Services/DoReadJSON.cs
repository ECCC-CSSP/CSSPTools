﻿/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPWebModels;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private async Task<ActionResult<T>> DoReadJSON<T>(WebTypeEnum webType, int TVItemID)
        {
            bool gzExistLocaly = false;
            bool gzLocalIsUpToDate = false;
            bool JustRead = false;

            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            string fileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            FileInfo fiGZ = new FileInfo(CSSPJSONPath + string.Format(fileName, TVItemID));

            if (fiGZ.Exists)
            {
                gzExistLocaly = true;
            }

            if (gzExistLocaly)
            {
                ManageFile manageFile = null;

                var actionCSSPFile = await ManageFileService.ManageFileGetWithAzureStorageAndAzureFileName(AzureStoreCSSPJSONPath, fiGZ.Name);
                if (((ObjectResult)actionCSSPFile.Result).StatusCode == 200)
                {
                    manageFile = (ManageFile)((OkObjectResult)actionCSSPFile.Result).Value;
                }

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
                                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoggedInService.LoggedInContactInfo.LoggedInContact.Token);
                                var response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/CreateGzFile/{ (int)webType }/{ TVItemID }");

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
                        ManageFile manageFile = null;

                        var actionCSSPFile = await ManageFileService.ManageFileGetWithAzureStorageAndAzureFileName(AzureStoreCSSPJSONPath, fiGZ.Name);
                        if (((ObjectResult)actionCSSPFile.Result).StatusCode == 200)
                        {
                            manageFile = (ManageFile)((OkObjectResult)actionCSSPFile.Result).Value;
                        }

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
                                    return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
                                }
                                else
                                {
                                    return await Task.FromResult((BadRequestObjectResult)actionCSSPFileAdded.Result);
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
                        FileInfo fiGZLocal = new FileInfo($"{ CSSPJSONPathLocal }{ fiGZ.Name }");

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
                                DoMergeJsonWebAllAddresses(FromAzureStore as WebAllAddresses, FromLocal as WebAllAddresses);
                                break;
                            case WebTypeEnum.WebAllContacts:
                                DoMergeJsonWebAllContacts(FromAzureStore as WebAllContacts, FromLocal as WebAllContacts);
                                break;
                            case WebTypeEnum.WebAllCountries:
                                DoMergeJsonWebAllCountries(FromAzureStore as WebAllCountries, FromLocal as WebAllCountries);
                                break;
                            case WebTypeEnum.WebAllEmails:
                                DoMergeJsonWebAllEmails(FromAzureStore as WebAllEmails, FromLocal as WebAllEmails);
                                break;
                            case WebTypeEnum.WebAllHelpDocs:
                                DoMergeJsonWebAllHelpDocs(FromAzureStore as WebAllHelpDocs, FromLocal as WebAllHelpDocs);
                                break;
                            case WebTypeEnum.WebAllMunicipalities:
                                DoMergeJsonWebAllMunicipalities(FromAzureStore as WebAllMunicipalities, FromLocal as WebAllMunicipalities);
                                break;
                            case WebTypeEnum.WebAllMWQMLookupMPNs:
                                DoMergeJsonWebAllMWQMLookupMPNs(FromAzureStore as WebAllMWQMLookupMPNs, FromLocal as WebAllMWQMLookupMPNs);
                                break;
                            case WebTypeEnum.WebAllPolSourceGroupings:
                                DoMergeJsonWebAllPolSourceGroupings(FromAzureStore as WebAllPolSourceGroupings, FromLocal as WebAllPolSourceGroupings);
                                break;
                            case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                                DoMergeJsonWebAllPolSourceSiteEffectTerms(FromAzureStore as WebAllPolSourceSiteEffectTerms, FromLocal as WebAllPolSourceSiteEffectTerms);
                                break;
                            case WebTypeEnum.WebAllProvinces:
                                DoMergeJsonWebAllProvinces(FromAzureStore as WebAllProvinces, FromLocal as WebAllProvinces);
                                break;
                            case WebTypeEnum.WebAllReportTypes:
                                DoMergeJsonWebAllReportTypes(FromAzureStore as WebAllReportTypes, FromLocal as WebAllReportTypes);
                                break;
                            case WebTypeEnum.WebAllTels:
                                DoMergeJsonWebAllTels(FromAzureStore as WebAllTels, FromLocal as WebAllTels); ;
                                break;
                            case WebTypeEnum.WebAllTideLocations:
                                DoMergeJsonWebAllTideLocations(FromAzureStore as WebAllTideLocations, FromLocal as WebAllTideLocations); ;
                                break;
                            case WebTypeEnum.WebArea:
                                DoMergeJsonWebArea(FromAzureStore as WebArea, FromLocal as WebArea);
                                break;
                            case WebTypeEnum.WebClimateSites:
                                DoMergeJsonWebClimateSites(FromAzureStore as WebClimateSites, FromLocal as WebClimateSites);
                                break;
                            case WebTypeEnum.WebCountry:
                                DoMergeJsonWebCountry(FromAzureStore as WebCountry, FromLocal as WebCountry);
                                break;
                            case WebTypeEnum.WebDrogueRuns:
                                DoMergeJsonWebDrogueRuns(FromAzureStore as WebDrogueRuns, FromLocal as WebDrogueRuns);
                                break;
                            case WebTypeEnum.WebHydrometricSites:
                                DoMergeJsonWebHydrometricSites(FromAzureStore as WebHydrometricSites, FromLocal as WebHydrometricSites);
                                break;
                            case WebTypeEnum.WebLabSheets:
                                DoMergeJsonWebLabSheets(FromAzureStore as WebLabSheets, FromLocal as WebLabSheets);
                                break;
                            case WebTypeEnum.WebMikeScenarios:
                                DoMergeJsonWebMikeScenarios(FromAzureStore as WebMikeScenarios, FromLocal as WebMikeScenarios);
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
                                DoMergeJsonWebMunicipality(FromAzureStore as WebMunicipality, FromLocal as WebMunicipality);
                                break;
                            case WebTypeEnum.WebMWQMRuns:
                                DoMergeJsonWebMWQMRuns(FromAzureStore as WebMWQMRuns, FromLocal as WebMWQMRuns);
                                break;
                            case WebTypeEnum.WebMWQMSamples1980_2020:
                                DoMergeJsonWebMWQMSamples1980_2020(FromAzureStore as WebMWQMSamples, FromLocal as WebMWQMSamples);
                                break;
                            case WebTypeEnum.WebMWQMSamples2021_2060:
                                DoMergeJsonWebMWQMSamples2021_2060(FromAzureStore as WebMWQMSamples, FromLocal as WebMWQMSamples);
                                break;
                            case WebTypeEnum.WebMWQMSites:
                                DoMergeJsonWebMWQMSites(FromAzureStore as WebMWQMSites, FromLocal as WebMWQMSites);
                                break;
                            case WebTypeEnum.WebPolSourceSites:
                                DoMergeJsonWebPolSourceSites(FromAzureStore as WebPolSourceSites, FromLocal as WebPolSourceSites);
                                break;
                            case WebTypeEnum.WebProvince:
                                DoMergeJsonWebProvince(FromAzureStore as WebProvince, FromLocal as WebProvince);
                                break;
                            case WebTypeEnum.WebRoot:
                                DoMergeJsonWebRoot(FromAzureStore as WebRoot, FromLocal as WebRoot);
                                break;
                            case WebTypeEnum.WebAllSearch:
                                DoMergeJsonWebAllSearch(FromAzureStore as WebAllSearch, FromLocal as WebAllSearch);
                                break;
                            case WebTypeEnum.WebSector:
                                DoMergeJsonWebSector(FromAzureStore as WebSector, FromLocal as WebSector);
                                break;
                            case WebTypeEnum.WebSubsector:
                                DoMergeJsonWebSubsector(FromAzureStore as WebSubsector, FromLocal as WebSubsector);
                                break;
                            case WebTypeEnum.WebTideSites:
                                DoMergeJsonWebTideSites(FromAzureStore as WebTideSites, FromLocal as WebTideSites);
                                break;
                            default:
                                break;
                        }

                        return await Task.FromResult(Ok(FromAzureStore));
                    }
                }
            }
        }
    }
}
