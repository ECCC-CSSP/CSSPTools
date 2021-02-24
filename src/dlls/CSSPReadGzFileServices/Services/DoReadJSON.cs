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
                        switch (typeof(T).Name)
                        {
                            case "WebAllCountries":
                                {
                                    WebAppLoadedService.webAppLoaded.WebAllCountries = JsonSerializer.Deserialize<WebAllCountries>(sr.ReadToEnd());
                                }
                                break;
                            case "WebAllMunicipalities":
                                {
                                    WebAppLoadedService.webAppLoaded.WebAllMunicipalities = JsonSerializer.Deserialize<WebAllMunicipalities>(sr.ReadToEnd());
                                }
                                break;
                            case "WebAllProvinces":
                                {
                                    WebAppLoadedService.webAppLoaded.WebAllProvinces = JsonSerializer.Deserialize<WebAllProvinces>(sr.ReadToEnd());
                                }
                                break;
                            case "WebArea":
                                {
                                    WebAppLoadedService.webAppLoaded.WebArea = JsonSerializer.Deserialize<WebArea>(sr.ReadToEnd());
                                }
                                break;
                            case "WebClimateDataValue":
                                {
                                    WebAppLoadedService.webAppLoaded.WebClimateDataValue = JsonSerializer.Deserialize<WebClimateDataValue>(sr.ReadToEnd());
                                }
                                break;
                            case "WebClimateSite":
                                {
                                    WebAppLoadedService.webAppLoaded.WebClimateSite = JsonSerializer.Deserialize<WebClimateSite>(sr.ReadToEnd());
                                }
                                break;
                            case "WebContact":
                                {
                                    WebAppLoadedService.webAppLoaded.WebContact = JsonSerializer.Deserialize<WebContact>(sr.ReadToEnd());
                                }
                                break;
                            case "WebCountry":
                                {
                                    WebAppLoadedService.webAppLoaded.WebCountry = JsonSerializer.Deserialize<WebCountry>(sr.ReadToEnd());
                                }
                                break;
                            case "WebDrogueRun":
                                {
                                    WebAppLoadedService.webAppLoaded.WebDrogueRun = JsonSerializer.Deserialize<WebDrogueRun>(sr.ReadToEnd());
                                }
                                break;
                            case "WebHelpDoc":
                                {
                                    WebAppLoadedService.webAppLoaded.WebHelpDoc = JsonSerializer.Deserialize<WebHelpDoc>(sr.ReadToEnd());
                                }
                                break;
                            case "WebHydrometricDataValue":
                                {
                                    WebAppLoadedService.webAppLoaded.WebHydrometricDataValue = JsonSerializer.Deserialize<WebHydrometricDataValue>(sr.ReadToEnd());
                                }
                                break;
                            case "WebHydrometricSite":
                                {
                                    WebAppLoadedService.webAppLoaded.WebHydrometricSite = JsonSerializer.Deserialize<WebHydrometricSite>(sr.ReadToEnd());
                                }
                                break;
                            case "WebMikeScenario":
                                {
                                    WebAppLoadedService.webAppLoaded.WebMikeScenario = JsonSerializer.Deserialize<WebMikeScenario>(sr.ReadToEnd());
                                }
                                break;
                            case "WebMunicipalities":
                                {
                                    WebAppLoadedService.webAppLoaded.WebMunicipalities = JsonSerializer.Deserialize<WebMunicipalities>(sr.ReadToEnd());
                                }
                                break;
                            case "WebMunicipality":
                                {
                                    WebAppLoadedService.webAppLoaded.WebMunicipality = JsonSerializer.Deserialize<WebMunicipality>(sr.ReadToEnd());
                                }
                                break;
                            case "WebMWQMLookupMPN":
                                {
                                    WebAppLoadedService.webAppLoaded.WebMWQMLookupMPN = JsonSerializer.Deserialize<WebMWQMLookupMPN>(sr.ReadToEnd());
                                }
                                break;
                            case "WebMWQMRun":
                                {
                                    WebAppLoadedService.webAppLoaded.WebMWQMRun = JsonSerializer.Deserialize<WebMWQMRun>(sr.ReadToEnd());
                                }
                                break;
                            case "WebMWQMSample":
                                {
                                    switch (webTypeYear)
                                    {
                                        case WebTypeYearEnum.Year1980:
                                            {
                                                WebAppLoadedService.webAppLoaded.WebMWQMSample1980_1989 = JsonSerializer.Deserialize<WebMWQMSample>(sr.ReadToEnd());
                                            }
                                            break;
                                        case WebTypeYearEnum.Year1990:
                                            {
                                                WebAppLoadedService.webAppLoaded.WebMWQMSample1990_1999 = JsonSerializer.Deserialize<WebMWQMSample>(sr.ReadToEnd());
                                            }
                                            break;
                                        case WebTypeYearEnum.Year2000:
                                            {
                                                WebAppLoadedService.webAppLoaded.WebMWQMSample2000_2009 = JsonSerializer.Deserialize<WebMWQMSample>(sr.ReadToEnd());
                                            }
                                            break;
                                        case WebTypeYearEnum.Year2010:
                                            {
                                                WebAppLoadedService.webAppLoaded.WebMWQMSample2010_2019 = JsonSerializer.Deserialize<WebMWQMSample>(sr.ReadToEnd());
                                            }
                                            break;
                                        case WebTypeYearEnum.Year2020:
                                            {
                                                WebAppLoadedService.webAppLoaded.WebMWQMSample2020_2029 = JsonSerializer.Deserialize<WebMWQMSample>(sr.ReadToEnd());
                                            }
                                            break;
                                        case WebTypeYearEnum.Year2030:
                                            {
                                                WebAppLoadedService.webAppLoaded.WebMWQMSample2030_2039 = JsonSerializer.Deserialize<WebMWQMSample>(sr.ReadToEnd());
                                            }
                                            break;
                                        case WebTypeYearEnum.Year2040:
                                            {
                                                WebAppLoadedService.webAppLoaded.WebMWQMSample2040_2049 = JsonSerializer.Deserialize<WebMWQMSample>(sr.ReadToEnd());
                                            }
                                            break;
                                        case WebTypeYearEnum.Year2050:
                                            {
                                                WebAppLoadedService.webAppLoaded.WebMWQMSample2050_2059 = JsonSerializer.Deserialize<WebMWQMSample>(sr.ReadToEnd());
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                break;
                            case "WebMWQMSite":
                                {
                                    WebAppLoadedService.webAppLoaded.WebMWQMSite = JsonSerializer.Deserialize<WebMWQMSite>(sr.ReadToEnd());
                                }
                                break;
                            case "WebPolSourceGrouping":
                                {
                                    WebAppLoadedService.webAppLoaded.WebPolSourceGrouping = JsonSerializer.Deserialize<WebPolSourceGrouping>(sr.ReadToEnd());
                                }
                                break;
                            case "WebPolSourceSite":
                                {
                                    WebAppLoadedService.webAppLoaded.WebPolSourceSite = JsonSerializer.Deserialize<WebPolSourceSite>(sr.ReadToEnd());
                                }
                                break;
                            case "WebPolSourceSiteEffectTerm":
                                {
                                    WebAppLoadedService.webAppLoaded.WebPolSourceSiteEffectTerm = JsonSerializer.Deserialize<WebPolSourceSiteEffectTerm>(sr.ReadToEnd());
                                }
                                break;
                            case "WebProvince":
                                {
                                    WebAppLoadedService.webAppLoaded.WebProvince = JsonSerializer.Deserialize<WebProvince>(sr.ReadToEnd());
                                }
                                break;
                            case "WebReportType":
                                {
                                    WebAppLoadedService.webAppLoaded.WebReportType = JsonSerializer.Deserialize<WebReportType>(sr.ReadToEnd());
                                }
                                break;
                            case "WebRoot":
                                {
                                    WebAppLoadedService.webAppLoaded.WebRoot = JsonSerializer.Deserialize<WebRoot>(sr.ReadToEnd());
                                }
                                break;
                            case "WebSamplingPlan":
                                {
                                    WebAppLoadedService.webAppLoaded.WebSamplingPlan = JsonSerializer.Deserialize<WebSamplingPlan>(sr.ReadToEnd());
                                }
                                break;
                            case "WebSector":
                                {
                                    WebAppLoadedService.webAppLoaded.WebSector = JsonSerializer.Deserialize<WebSector>(sr.ReadToEnd());
                                }
                                break;
                            case "WebSubsector":
                                {
                                    WebAppLoadedService.webAppLoaded.WebSubsector = JsonSerializer.Deserialize<WebSubsector>(sr.ReadToEnd());
                                }
                                break;
                            case "WebTideLocation":
                                {
                                    WebAppLoadedService.webAppLoaded.WebTideLocation = JsonSerializer.Deserialize<WebTideLocation>(sr.ReadToEnd());
                                }
                                break;
                            default:
                                break;
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
                        return await Task.FromResult(Ok(JsonSerializer.Deserialize<T>(sr.ReadToEnd())));
                    }
                }
            }
        }
    }
}
