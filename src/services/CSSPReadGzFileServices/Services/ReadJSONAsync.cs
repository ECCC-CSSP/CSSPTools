namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ControllerBase, ICSSPReadGzFileService
{
    public async Task<ActionResult<T>> ReadJSONAsync<T>(WebTypeEnum webType, int TVItemID = 0)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebTypeEnum: { webType }, TVItemID: { TVItemID })";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        bool gzExistLocaly = false;
        bool gzLocalIsUpToDate = false;
        bool JustRead = false;

        string fileName = await BaseGzFileService.GetFileName(webType, TVItemID);

        FileInfo fiGZ = new FileInfo(Configuration["CSSPJSONPath"] + string.Format(fileName, TVItemID));

        if (TVItemID > -1)
        {
            if (fiGZ.Exists)
            {
                gzExistLocaly = true;
            }

            if (gzExistLocaly)
            {
                ManageFile manageFile = null;

                var actionCSSPFile = await ManageFileService.GetWithAzureStorageAndAzureFileNameAsync(Configuration["AzureStoreCSSPJSONPath"], fiGZ.Name);
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
                    ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
                    ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
                    ShareFileClient shareFileClient = directory.GetFileClient(fileName);

                    Response<bool> response = await shareFileClient.ExistsAsync();
                    if (!response.Value)
                    {
                        CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.CouldNotFind_, $"{ Configuration["AzureStoreCSSPJsonPath"] }{ fiGZ.Name }"));
                        return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
                    }

                    ShareFileProperties shareFileProperties = null;

                    try
                    {
                        shareFileProperties = shareFileClient.GetProperties();
                    }
                    catch (RequestFailedException)
                    {
                        CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, Configuration["AzureStoreCSSPJsonPath"], fiGZ.Name));
                        return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
                    }

                    if (gzExistLocaly)
                    {
                        ManageFile manageFile = null;

                        var actionCSSPFile = await ManageFileService.GetWithAzureStorageAndAzureFileNameAsync(Configuration["AzureStoreCSSPJSONPath"], fiGZ.Name);
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

                                var actionCSSPFileAdded = await ManageFileService.AddAsync(manageFile);
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

                            if (shareFileProperties.ETag.ToString().Replace("\"", "") == manageFile.AzureETag)
                            {
                                gzLocalIsUpToDate = true;
                            }
                        }
                    }

                    if (!gzLocalIsUpToDate)
                    {
                        var actionRes = await CSSPFileService.LocalizeAzureJSONFileAsync(fileName);

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
                                await MergeJsonWebAllAddresses(FromAzureStore as WebAllAddresses, FromLocal as WebAllAddresses);
                                break;
                            case WebTypeEnum.WebAllContacts:
                                await MergeJsonWebAllContacts(FromAzureStore as WebAllContacts, FromLocal as WebAllContacts);
                                break;
                            case WebTypeEnum.WebAllCountries:
                                await MergeJsonWebAllCountries(FromAzureStore as WebAllCountries, FromLocal as WebAllCountries);
                                break;
                            case WebTypeEnum.WebAllEmails:
                                await MergeJsonWebAllEmails(FromAzureStore as WebAllEmails, FromLocal as WebAllEmails);
                                break;
                            case WebTypeEnum.WebAllHelpDocs:
                                await MergeJsonWebAllHelpDocs(FromAzureStore as WebAllHelpDocs, FromLocal as WebAllHelpDocs);
                                break;
                            case WebTypeEnum.WebAllMunicipalities:
                                await MergeJsonWebAllMunicipalities(FromAzureStore as WebAllMunicipalities, FromLocal as WebAllMunicipalities);
                                break;
                            case WebTypeEnum.WebAllMWQMAnalysisReportParameters:
                                await MergeJsonWebAllMWQMAnalysisReportParameters(FromAzureStore as WebAllMWQMAnalysisReportParameters, FromLocal as WebAllMWQMAnalysisReportParameters);
                                break;
                            case WebTypeEnum.WebAllMWQMLookupMPNs:
                                await MergeJsonWebAllMWQMLookupMPNs(FromAzureStore as WebAllMWQMLookupMPNs, FromLocal as WebAllMWQMLookupMPNs);
                                break;
                            case WebTypeEnum.WebAllMWQMSubsectors:
                                await MergeJsonWebAllMWQMSubsectors(FromAzureStore as WebAllMWQMSubsectors, FromLocal as WebAllMWQMSubsectors);
                                break;
                            case WebTypeEnum.WebAllPolSourceGroupings:
                                await MergeJsonWebAllPolSourceGroupings(FromAzureStore as WebAllPolSourceGroupings, FromLocal as WebAllPolSourceGroupings);
                                break;
                            case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                                await MergeJsonWebAllPolSourceSiteEffectTerms(FromAzureStore as WebAllPolSourceSiteEffectTerms, FromLocal as WebAllPolSourceSiteEffectTerms);
                                break;
                            case WebTypeEnum.WebAllProvinces:
                                await MergeJsonWebAllProvinces(FromAzureStore as WebAllProvinces, FromLocal as WebAllProvinces);
                                break;
                            case WebTypeEnum.WebAllReportTypes:
                                await MergeJsonWebAllReportTypes(FromAzureStore as WebAllReportTypes, FromLocal as WebAllReportTypes);
                                break;
                            case WebTypeEnum.WebAllSearch:
                                await MergeJsonWebAllSearch(FromAzureStore as WebAllSearch, FromLocal as WebAllSearch);
                                break;
                            case WebTypeEnum.WebAllTels:
                                await MergeJsonWebAllTels(FromAzureStore as WebAllTels, FromLocal as WebAllTels); ;
                                break;
                            case WebTypeEnum.WebAllTideLocations:
                                await MergeJsonWebAllTideLocations(FromAzureStore as WebAllTideLocations, FromLocal as WebAllTideLocations); ;
                                break;
                            case WebTypeEnum.WebAllUseOfSites:
                                await MergeJsonWebAllUseOfSites(FromAzureStore as WebAllUseOfSites, FromLocal as WebAllUseOfSites);
                                break;
                            case WebTypeEnum.WebArea:
                                await MergeJsonWebArea(FromAzureStore as WebArea, FromLocal as WebArea);
                                break;
                            case WebTypeEnum.WebClimateSites:
                                await MergeJsonWebClimateSites(FromAzureStore as WebClimateSites, FromLocal as WebClimateSites);
                                break;
                            case WebTypeEnum.WebCountry:
                                await MergeJsonWebCountry(FromAzureStore as WebCountry, FromLocal as WebCountry);
                                break;
                            case WebTypeEnum.WebDrogueRuns:
                                await MergeJsonWebDrogueRuns(FromAzureStore as WebDrogueRuns, FromLocal as WebDrogueRuns);
                                break;
                            case WebTypeEnum.WebHydrometricSites:
                                await MergeJsonWebHydrometricSites(FromAzureStore as WebHydrometricSites, FromLocal as WebHydrometricSites);
                                break;
                            case WebTypeEnum.WebLabSheets:
                                await MergeJsonWebLabSheets(FromAzureStore as WebLabSheets, FromLocal as WebLabSheets);
                                break;
                            case WebTypeEnum.WebMikeScenarios:
                                await MergeJsonWebMikeScenarios(FromAzureStore as WebMikeScenarios, FromLocal as WebMikeScenarios);
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
                                await MergeJsonWebMunicipality(FromAzureStore as WebMunicipality, FromLocal as WebMunicipality);
                                break;
                            case WebTypeEnum.WebMWQMRuns:
                                await MergeJsonWebMWQMRuns(FromAzureStore as WebMWQMRuns, FromLocal as WebMWQMRuns);
                                break;
                            case WebTypeEnum.WebMWQMSamples1980_2020:
                                await MergeJsonWebMWQMSamples1980_2020(FromAzureStore as WebMWQMSamples, FromLocal as WebMWQMSamples);
                                break;
                            case WebTypeEnum.WebMWQMSamples2021_2060:
                                await MergeJsonWebMWQMSamples2021_2060(FromAzureStore as WebMWQMSamples, FromLocal as WebMWQMSamples);
                                break;
                            case WebTypeEnum.WebMWQMSites:
                                await MergeJsonWebMWQMSites(FromAzureStore as WebMWQMSites, FromLocal as WebMWQMSites);
                                break;
                            case WebTypeEnum.WebPolSourceSites:
                                await MergeJsonWebPolSourceSites(FromAzureStore as WebPolSourceSites, FromLocal as WebPolSourceSites);
                                break;
                            case WebTypeEnum.WebProvince:
                                await MergeJsonWebProvince(FromAzureStore as WebProvince, FromLocal as WebProvince);
                                break;
                            case WebTypeEnum.WebRoot:
                                await MergeJsonWebRoot(FromAzureStore as WebRoot, FromLocal as WebRoot);
                                break;
                            case WebTypeEnum.WebSector:
                                await MergeJsonWebSector(FromAzureStore as WebSector, FromLocal as WebSector);
                                break;
                            case WebTypeEnum.WebSubsector:
                                await MergeJsonWebSubsector(FromAzureStore as WebSubsector, FromLocal as WebSubsector);
                                break;
                            case WebTypeEnum.WebTideSites:
                                await MergeJsonWebTideSites(FromAzureStore as WebTideSites, FromLocal as WebTideSites);
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

