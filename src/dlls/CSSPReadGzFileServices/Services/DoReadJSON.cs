/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
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
using CSSPDBPreferenceModels;
using CSSPDBFilesManagementModels;
using LoggedInServices;
using CSSPWebModels;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<ActionResult<T>> DoReadJSON<T>(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            bool gzExistLocaly = false;
            bool gzLocalIsUpToDate = false;

            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            string fileName = await BaseGzFileService.GetFileName(webType, TVItemID, webTypeYear);

            FileInfo fiGZ = new FileInfo(CSSPJSONPath + string.Format(fileName, TVItemID));

            if (fiGZ.Exists)
            {
                gzExistLocaly = true;
            }

            bool HasInternetConnection = false;

            HasInternetConnection = (from c in dbPreference.Contacts
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
                    FilesManagement filesManagement = null;

                    var actionCSSPFile = await FilesManagementService.GetWithAzureStorageAndAzureFileName(AzureStoreCSSPJSONPath, fiGZ.Name);
                    if (((ObjectResult)actionCSSPFile.Result).StatusCode == 200)
                    {
                        filesManagement = (FilesManagement)((OkObjectResult)actionCSSPFile.Result).Value;
                    }

                    if (filesManagement == null || blobProperties.ETag.ToString().Replace("\"", "") == filesManagement.AzureETag)
                    {
                        gzLocalIsUpToDate = true;
                    }
                }

                if (!gzLocalIsUpToDate)
                {
                    var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);

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
                                case WebTypeEnum.WebAllTVItemLanguages:
                                    DoMergeJsonWebAllTVItemLanguages(FromAzureStore as WebAllTVItemLanguages, FromLocal as WebAllTVItemLanguages); ;
                                    break;
                                case WebTypeEnum.WebAllTVItems:
                                    DoMergeJsonWebAllTVItems(FromAzureStore as WebAllTVItems, FromLocal as WebAllTVItems); ;
                                    break;
                                case WebTypeEnum.WebArea:
                                    DoMergeJsonWebArea(FromAzureStore as WebArea, FromLocal as WebArea);
                                    break;
                                case WebTypeEnum.WebClimateDataValue:
                                    DoMergeJsonWebClimateDataValue(FromAzureStore as WebClimateDataValue, FromLocal as WebClimateDataValue);
                                    break;
                                case WebTypeEnum.WebClimateSite:
                                    DoMergeJsonWebClimateSite(FromAzureStore as WebClimateSite, FromLocal as WebClimateSite);
                                    break;
                                case WebTypeEnum.WebCountry:
                                    DoMergeJsonWebCountry(FromAzureStore as WebCountry, FromLocal as WebCountry);
                                    break;
                                case WebTypeEnum.WebDrogueRun:
                                    DoMergeJsonWebDrogueRun(FromAzureStore as WebDrogueRun, FromLocal as WebDrogueRun);
                                    break;
                                case WebTypeEnum.WebHydrometricDataValue:
                                    DoMergeJsonWebHydrometricDataValue(FromAzureStore as WebHydrometricDataValue, FromLocal as WebHydrometricDataValue);
                                    break;
                                case WebTypeEnum.WebHydrometricSite:
                                    DoMergeJsonWebHydrometricSite(FromAzureStore as WebHydrometricSite, FromLocal as WebHydrometricSite);
                                    break;
                                case WebTypeEnum.WebMikeScenario:
                                    DoMergeJsonWebMikeScenario(FromAzureStore as WebMikeScenario, FromLocal as WebMikeScenario);
                                    break;
                                case WebTypeEnum.WebMunicipalities:
                                    DoMergeJsonWebMunicipalities(FromAzureStore as WebMunicipalities, FromLocal as WebMunicipalities);
                                    break;
                                case WebTypeEnum.WebMunicipality:
                                    DoMergeJsonWebMunicipality(FromAzureStore as WebMunicipality, FromLocal as WebMunicipality);
                                    break;
                                case WebTypeEnum.WebMWQMRun:
                                    DoMergeJsonWebMWQMRun(FromAzureStore as WebMWQMRun, FromLocal as WebMWQMRun);
                                    break;
                                case WebTypeEnum.WebMWQMSample:
                                    DoMergeJsonWebMWQMSample(FromAzureStore as WebMWQMSample, FromLocal as WebMWQMSample);
                                    break;
                                case WebTypeEnum.WebMWQMSite:
                                    DoMergeJsonWebMWQMSite(FromAzureStore as WebMWQMSite, FromLocal as WebMWQMSite);
                                    break;
                                case WebTypeEnum.WebPolSourceSite:
                                    DoMergeJsonWebPolSourceSite(FromAzureStore as WebPolSourceSite, FromLocal as WebPolSourceSite);
                                    break;
                                case WebTypeEnum.WebProvince:
                                    DoMergeJsonWebProvince(FromAzureStore as WebProvince, FromLocal as WebProvince);
                                    break;
                                case WebTypeEnum.WebRoot:
                                    DoMergeJsonWebRoot(FromAzureStore as WebRoot, FromLocal as WebRoot);
                                    break;
                                case WebTypeEnum.WebSamplingPlan:
                                    DoMergeJsonWebSamplingPlan(FromAzureStore as WebSamplingPlan, FromLocal as WebSamplingPlan);
                                    break;
                                case WebTypeEnum.WebSector:
                                    DoMergeJsonWebSector(FromAzureStore as WebSector, FromLocal as WebSector);
                                    break;
                                case WebTypeEnum.WebSubsector:
                                    DoMergeJsonWebSubsector(FromAzureStore as WebSubsector, FromLocal as WebSubsector);
                                    break;
                                case WebTypeEnum.WebTideDataValue:
                                    DoMergeJsonWebTideDataValue(FromAzureStore as WebTideDataValue, FromLocal as WebTideDataValue);
                                    break;
                                case WebTypeEnum.WebTideSite:
                                    DoMergeJsonWebTideSite(FromAzureStore as WebTideSite, FromLocal as WebTideSite);
                                    break;
                                default:
                                    break;
                            }
                        }

                        return await Task.FromResult(Ok(FromAzureStore));
                    }
                }
            }
        }

    }
}
