//using CSSPEnums;
//using CSSPDBModels;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GenerateRepopulateTestDB
//{
//    public partial class Startup
//    {
//        private async Task<bool> MakingSureEveryTableHasEnoughItemsInTestDB()
//        {
//            int count = 0;

//            Console.WriteLine("doing ... Adding up to 10 items in Addresses");

//            #region Addresses
//            count = (from c in dbTestDB.Addresses.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    Address address = (from c in dbTestDB.Addresses.AsNoTracking() select c).OrderByDescending(c => c.AddressID).FirstOrDefault();
//                    try
//                    {
//                        address.AddressID = 0;
//                        address.StreetName = $"{ address.StreetName }a";
//                        if (!await AddObject("Address", address)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion Addresses

//            Console.WriteLine("doing ... Adding up to 10 items in AppErrLogs");

//            #region AppErrLogs
//            count = (from c in dbTestDB.AppErrLogs.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    AppErrLog AppErrLog = (from c in dbTestDB.AppErrLogs.AsNoTracking() select c).OrderByDescending(c => c.AppErrLogID).FirstOrDefault();
//                    try
//                    {
//                        AppErrLog.AppErrLogID = 0;
//                        AppErrLog.Source = $"{ AppErrLog.Source }a";
//                        if (!await AddObject("AppErrLog", AppErrLog)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion AppErrLogs

//            Console.WriteLine("doing ... Adding up to 10 items in AppTasks");

//            #region AppTasks
//            count = (from c in dbTestDB.AppTasks.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    AppTask AppTask = (from c in dbTestDB.AppTasks select c).OrderByDescending(c => c.AppTaskID).FirstOrDefault();
//                    AppTaskLanguage AppTaskLanguageEN = (from c in dbTestDB.AppTaskLanguages.AsNoTracking() where c.AppTaskID == AppTask.AppTaskID && c.Language == LanguageEnum.en select c).FirstOrDefault();
//                    AppTaskLanguage AppTaskLanguageFR = (from c in dbTestDB.AppTaskLanguages.AsNoTracking() where c.AppTaskID == AppTask.AppTaskID && c.Language == LanguageEnum.fr select c).FirstOrDefault();
//                    try
//                    {
//                        AppTask.AppTaskID = 0;
//                        AppTask.Parameters = $"{ AppTask.Parameters }a";
//                        if (!await AddObject("AppTask", AppTask)) return await Task.FromResult(false);

//                        AppTaskLanguageEN.AppTaskLanguageID = 0;
//                        AppTaskLanguageEN.AppTaskID = AppTask.AppTaskID;
//                        AppTaskLanguageEN.StatusText = $"{ AppTaskLanguageEN.StatusText }a";
//                        if (!await AddObject("AppTaskLanguage", AppTaskLanguageEN)) return await Task.FromResult(false);

//                        AppTaskLanguageFR.AppTaskLanguageID = 0;
//                        AppTaskLanguageFR.AppTaskID = AppTask.AppTaskID;
//                        AppTaskLanguageFR.StatusText = $"{ AppTaskLanguageFR.StatusText }a";
//                        if (!await AddObject("AppTaskLanguage", AppTaskLanguageFR)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion AppTasks

//            Console.WriteLine("doing ... Adding up to 10 items in BoxModels");

//            #region BoxModels
//            count = (from c in dbTestDB.BoxModels.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    BoxModel BoxModel = (from c in dbTestDB.BoxModels.AsNoTracking() select c).OrderByDescending(c => c.BoxModelID).FirstOrDefault();
//                    BoxModelLanguage BoxModelLanguageEN = (from c in dbTestDB.BoxModelLanguages where c.BoxModelID == BoxModel.BoxModelID && c.Language == LanguageEnum.en select c).FirstOrDefault();
//                    BoxModelLanguage BoxModelLanguageFR = (from c in dbTestDB.BoxModelLanguages where c.BoxModelID == BoxModel.BoxModelID && c.Language == LanguageEnum.fr select c).FirstOrDefault();
//                    List<BoxModelResult> BoxModelResultList = (from c in dbTestDB.BoxModelResults where c.BoxModelID == BoxModel.BoxModelID select c).ToList();
//                    try
//                    {
//                        BoxModel.BoxModelID = 0;
//                        BoxModel.DecayRate_per_day = BoxModel.DecayRate_per_day + 0.1f;
//                        if (!await AddObject("BoxModel", BoxModel)) return await Task.FromResult(false);

//                        BoxModelLanguageEN.BoxModelLanguageID = 0;
//                        BoxModelLanguageEN.BoxModelID = BoxModel.BoxModelID;
//                        BoxModelLanguageEN.ScenarioName = $"{ BoxModelLanguageEN.ScenarioName }a";
//                        if (!await AddObject("BoxModelLanguage", BoxModelLanguageEN)) return await Task.FromResult(false);

//                        BoxModelLanguageFR.BoxModelLanguageID = 0;
//                        BoxModelLanguageFR.BoxModelID = BoxModel.BoxModelID;
//                        BoxModelLanguageFR.ScenarioName = $"{ BoxModelLanguageFR.ScenarioName }a";
//                        if (!await AddObject("BoxModelLanguage", BoxModelLanguageFR)) return await Task.FromResult(false);

//                        foreach (BoxModelResult boxModelResult in BoxModelResultList)
//                        {
//                            boxModelResult.BoxModelResultID = 0;
//                            boxModelResult.BoxModelID = BoxModel.BoxModelID;
//                            boxModelResult.Radius_m = boxModelResult.Radius_m + 1.0f;
//                            if (!await AddObject("BoxModelResult", boxModelResult)) return await Task.FromResult(false);
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion BoxModels

//            Console.WriteLine("doing ... Adding up to 10 items in ClimateSites");

//            #region ClimateSites
//            count = (from c in dbTestDB.ClimateSites.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    ClimateSite ClimateSite = (from c in dbTestDB.ClimateSites.AsNoTracking() select c).OrderByDescending(c => c.ClimateSiteID).FirstOrDefault();
//                    List<ClimateDataValue> ClimateDataValueList = (from c in dbTestDB.ClimateDataValues where c.ClimateSiteID == ClimateSite.ClimateSiteID select c).ToList();
//                    try
//                    {
//                        ClimateSite.ClimateSiteID = 0;
//                        ClimateSite.ClimateSiteName = $"{ ClimateSite.ClimateSiteName }a";
//                        if (!await AddObject("ClimateSite", ClimateSite)) return await Task.FromResult(false);

//                        foreach (ClimateDataValue climateDataValue in ClimateDataValueList)
//                        {
//                            climateDataValue.ClimateDataValueID = 0;
//                            climateDataValue.ClimateSiteID = ClimateSite.ClimateSiteID;
//                            climateDataValue.TotalPrecip_mm_cm = climateDataValue.TotalPrecip_mm_cm + 1.0f;
//                            if (!await AddObject("ClimateDataValue", climateDataValue)) return await Task.FromResult(false);
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion ClimateSites

//            Console.WriteLine("doing ... Adding up to 10 items in ContactPreferences");

//            #region ContactPreferences
//            count = (from c in dbTestDB.ContactPreferences.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    ContactPreference ContactPreference = (from c in dbTestDB.ContactPreferences.AsNoTracking() select c).OrderByDescending(c => c.ContactPreferenceID).FirstOrDefault();
//                    try
//                    {
//                        ContactPreference.ContactPreferenceID = 0;
//                        ContactPreference.MarkerSize = ContactPreference.MarkerSize + 1;
//                        if (!await AddObject("ContactPreference", ContactPreference)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion ContactPreferences

//            Console.WriteLine("doing ... Adding up to 10 items in Contacts");

//            #region Contacts
//            count = (from c in dbTestDB.Contacts.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    Contact Contact = (from c in dbTestDB.Contacts.AsNoTracking() select c).OrderByDescending(c => c.ContactID).FirstOrDefault();
//                    try
//                    {
//                        Contact.ContactID = 0;
//                        Contact.FirstName = $"{ Contact.FirstName }a";
//                        if (!await AddObject("Contact", Contact)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion Contacts

//            Console.WriteLine("doing ... Adding up to 10 items in ContactShortcuts");

//            #region ContactShortcuts
//            count = (from c in dbTestDB.ContactShortcuts.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    ContactShortcut ContactShortcut = (from c in dbTestDB.ContactShortcuts.AsNoTracking() select c).OrderByDescending(c => c.ContactShortcutID).FirstOrDefault();
//                    try
//                    {
//                        ContactShortcut.ContactShortcutID = 0;
//                        ContactShortcut.ShortCutText = $"{ ContactShortcut.ShortCutText }a";
//                        if (!await AddObject("ContactShortcut", ContactShortcut)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion ContactShortcuts

//            Console.WriteLine("doing ... Adding up to 10 items in DocTemplates");

//            #region DocTemplates
//            count = (from c in dbTestDB.DocTemplates.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    DocTemplate DocTemplate = (from c in dbTestDB.DocTemplates.AsNoTracking() select c).OrderByDescending(c => c.DocTemplateID).FirstOrDefault();
//                    try
//                    {
//                        DocTemplate.DocTemplateID = 0;
//                        DocTemplate.FileName = $"{ DocTemplate.FileName }a";
//                        if (!await AddObject("DocTemplate", DocTemplate)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion DocTemplates

//            Console.WriteLine("doing ... Adding up to 10 items in DrogueRuns");

//            #region DrogueRuns
//            count = (from c in dbTestDB.DrogueRuns.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    DrogueRun drogueRun = (from c in dbTestDB.DrogueRuns.AsNoTracking() select c).OrderByDescending(c => c.DrogueRunID).FirstOrDefault();
//                    List<DrogueRunPosition> drogueRunPositionList = (from c in dbTestDB.DrogueRunPositions.AsNoTracking() select c).OrderByDescending(c => c.DrogueRunID).Take(3).ToList();
//                    try
//                    {
//                        drogueRun.DrogueRunID = 0;
//                        drogueRun.DrogueNumber = drogueRun.DrogueNumber + 1;
//                        if (!await AddObject("DrogueRun", drogueRun)) return await Task.FromResult(false);

//                        foreach (DrogueRunPosition drogueRunPosition in drogueRunPositionList)
//                        {
//                            drogueRunPosition.DrogueRunPositionID = 0;
//                            drogueRunPosition.DrogueRunID = drogueRun.DrogueRunID;
//                            if (!await AddObject("DrogueRunPosition", drogueRunPosition)) return await Task.FromResult(false);
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion DrogueRuns

//            Console.WriteLine("doing ... Adding up to 10 items in EmailDistributionListContactLanguages");

//            #region EmailDistributionListContactLanguages
//            count = (from c in dbTestDB.EmailDistributionLists.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    EmailDistributionList EmailDistributionList = (from c in dbTestDB.EmailDistributionLists.AsNoTracking() select c).OrderByDescending(c => c.EmailDistributionListID).FirstOrDefault();
//                    List<EmailDistributionListLanguage> EmailDistributionListLanguageList = (from c in dbTestDB.EmailDistributionListLanguages where c.EmailDistributionListID == EmailDistributionList.EmailDistributionListID select c).ToList();
//                    List<EmailDistributionListContact> EmailDistributionListContactList = (from c in dbTestDB.EmailDistributionListContacts where c.EmailDistributionListID == EmailDistributionList.EmailDistributionListID select c).ToList();
//                    try
//                    {
//                        EmailDistributionList.EmailDistributionListID = 0;
//                        //EmailDistributionList.Agency = $"{ EmailDistributionList.Agency }a";
//                        if (!await AddObject("EmailDistributionList", EmailDistributionList)) return await Task.FromResult(false);

//                        foreach (EmailDistributionListLanguage emailDistributionListLanguage in EmailDistributionListLanguageList)
//                        {
//                            emailDistributionListLanguage.EmailDistributionListLanguageID = 0;
//                            emailDistributionListLanguage.EmailDistributionListID = EmailDistributionList.EmailDistributionListID;
//                            //emailDistributionListLanguage.RegionName = $"{ emailDistributionListLanguage.RegionName }a";
//                            if (!await AddObject("EmailDistributionListLanguage", emailDistributionListLanguage)) return await Task.FromResult(false);
//                        }

//                        foreach (EmailDistributionListContact emailDistributionListContact in EmailDistributionListContactList)
//                        {
//                            emailDistributionListContact.EmailDistributionListContactID = 0;
//                            emailDistributionListContact.EmailDistributionListID = EmailDistributionList.EmailDistributionListID;
//                            emailDistributionListContact.Name = $"{ emailDistributionListContact.Name }a";
//                            if (!await AddObject("EmailDistributionListContact", emailDistributionListContact)) return await Task.FromResult(false);

//                            List<EmailDistributionListContactLanguage> EmailDistributionListContactLanguageList = (from c in dbTestDB.EmailDistributionListContactLanguages.AsNoTracking() select c).OrderByDescending(c => c.EmailDistributionListContactLanguageID).Take(2).ToList();

//                            foreach (EmailDistributionListContactLanguage emailDistributionListContactLanguage in EmailDistributionListContactLanguageList)
//                            {
//                                emailDistributionListContactLanguage.EmailDistributionListContactLanguageID = 0;
//                                emailDistributionListContactLanguage.EmailDistributionListContactID = emailDistributionListContact.EmailDistributionListContactID;
//                                emailDistributionListContactLanguage.Agency = $"{ emailDistributionListContactLanguage.Agency }a";
//                                if (!await AddObject("EmailDistributionListContactLanguage", emailDistributionListContactLanguage)) return await Task.FromResult(false);
//                            }
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion EmailDistributionLists

//            Console.WriteLine("doing ... Adding up to 10 items in Emails");

//            #region Emails
//            count = (from c in dbTestDB.Emails.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    Email Email = (from c in dbTestDB.Emails.AsNoTracking() select c).OrderByDescending(c => c.EmailID).FirstOrDefault();
//                    try
//                    {
//                        Email.EmailID = 0;
//                        Email.EmailAddress = $"a{ Email.EmailAddress}";
//                        if (!await AddObject("Email", Email)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion Emails

//            Console.WriteLine("doing ... Adding up to 10 items in HelpDoc");

//            #region HelpDocs
//            count = (from c in dbTestDB.HelpDocs.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    HelpDoc HelpDoc = (from c in dbTestDB.HelpDocs.AsNoTracking() select c).OrderByDescending(c => c.HelpDocID).FirstOrDefault();
//                    try
//                    {
//                        HelpDoc.HelpDocID = 0;
//                        if (!await AddObject("HelpDoc", HelpDoc)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion HelpDocs

//            Console.WriteLine("doing ... Adding up to 10 items in HydrometricSites");

//            #region HydrometricSites
//            count = (from c in dbTestDB.HydrometricSites.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    HydrometricSite HydrometricSite = (from c in dbTestDB.HydrometricSites.AsNoTracking() select c).OrderByDescending(c => c.HydrometricSiteID).FirstOrDefault();
//                    List<HydrometricDataValue> HydrometricDataValueList = (from c in dbTestDB.HydrometricDataValues where c.HydrometricSiteID == HydrometricSite.HydrometricSiteID select c).ToList();
//                    try
//                    {
//                        HydrometricSite.HydrometricSiteID = 0;
//                        HydrometricSite.HydrometricSiteName = $"{ HydrometricSite.HydrometricSiteName }a";
//                        if (!await AddObject("HydrometricSite", HydrometricSite)) return await Task.FromResult(false);

//                        foreach (HydrometricDataValue hydrometricDataValue in HydrometricDataValueList)
//                        {
//                            hydrometricDataValue.HydrometricDataValueID = 0;
//                            hydrometricDataValue.HydrometricSiteID = HydrometricSite.HydrometricSiteID;
//                            hydrometricDataValue.HourlyValues = $"{ hydrometricDataValue.HourlyValues }a";
//                            if (!await AddObject("HydrometricDataValue", hydrometricDataValue)) return await Task.FromResult(false);
//                        }

//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion HydrometricSites

//            Console.WriteLine("doing ... Adding up to 10 items in Infrastructures");

//            #region Infrastructures
//            count = (from c in dbTestDB.Infrastructures.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    Infrastructure Infrastructure = (from c in dbTestDB.Infrastructures.AsNoTracking() select c).OrderByDescending(c => c.InfrastructureID).FirstOrDefault();
//                    InfrastructureLanguage InfrastructureLanguageEN = (from c in dbTestDB.InfrastructureLanguages where c.InfrastructureID == Infrastructure.InfrastructureID && c.Language == LanguageEnum.en select c).FirstOrDefault();
//                    InfrastructureLanguage InfrastructureLanguageFR = (from c in dbTestDB.InfrastructureLanguages where c.InfrastructureID == Infrastructure.InfrastructureID && c.Language == LanguageEnum.fr select c).FirstOrDefault();
//                    try
//                    {
//                        Infrastructure.InfrastructureID = 0;
//                        Infrastructure.PortElevation_m = Infrastructure.PortElevation_m + 0.1f;
//                        if (!await AddObject("Infrastructure", Infrastructure)) return await Task.FromResult(false);

//                        InfrastructureLanguageEN.InfrastructureLanguageID = 0;
//                        InfrastructureLanguageEN.InfrastructureID = Infrastructure.InfrastructureID;
//                        InfrastructureLanguageEN.Comment = $"{ InfrastructureLanguageEN.Comment }a";
//                        if (!await AddObject("InfrastructureLanguage", InfrastructureLanguageEN)) return await Task.FromResult(false);

//                        InfrastructureLanguageFR.InfrastructureLanguageID = 0;
//                        InfrastructureLanguageFR.InfrastructureID = Infrastructure.InfrastructureID;
//                        InfrastructureLanguageFR.Comment = $"{ InfrastructureLanguageFR.Comment }a";
//                        if (!await AddObject("InfrastructureLanguage", InfrastructureLanguageFR)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion Infrastructures

//            Console.WriteLine("doing ... Adding up to 10 items in LabSheets");

//            #region LabSheets
//            count = (from c in dbTestDB.LabSheets.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    LabSheet LabSheet = (from c in dbTestDB.LabSheets.AsNoTracking() select c).OrderByDescending(c => c.LabSheetID).FirstOrDefault();
//                    LabSheetDetail LabSheetDetail = (from c in dbTestDB.LabSheetDetails.AsNoTracking() select c).OrderByDescending(c => c.LabSheetDetailID).FirstOrDefault();
//                    try
//                    {
//                        LabSheet.LabSheetID = 0;
//                        LabSheet.SamplingPlanName = $"{ LabSheet.SamplingPlanName }a";
//                        if (!await AddObject("LabSheet", LabSheet)) return await Task.FromResult(false);

//                        LabSheetDetail.LabSheetDetailID = 0;
//                        LabSheetDetail.RunComment = $"{ LabSheetDetail.RunComment }a";
//                        if (!await AddObject("LabSheetDetail", LabSheetDetail)) return await Task.FromResult(false);

//                        LabSheetTubeMPNDetail LabSheetTubeMPNDetail = (from c in dbTestDB.LabSheetTubeMPNDetails.AsNoTracking() select c).OrderByDescending(c => c.LabSheetTubeMPNDetailID).FirstOrDefault();

//                        LabSheetTubeMPNDetail.LabSheetTubeMPNDetailID = 0;
//                        LabSheetTubeMPNDetail.LabSheetDetailID = LabSheetDetail.LabSheetDetailID;
//                        LabSheetTubeMPNDetail.SiteComment = $"{ LabSheetTubeMPNDetail.SiteComment }a";
//                        if (!await AddObject("LabSheetTubeMPNDetail", LabSheetTubeMPNDetail)) return await Task.FromResult(false);

//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion LabSheets

//            Console.WriteLine("doing ... Adding up to 10 items in Logs");

//            #region Logs
//            count = (from c in dbTestDB.Logs.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    Log Log = (from c in dbTestDB.Logs.AsNoTracking() select c).OrderByDescending(c => c.LogID).FirstOrDefault();
//                    try
//                    {
//                        Log.LogID = 0;
//                        Log.Information = $"{ Log.Information }a";
//                        if (!await AddObject("Log", Log)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion Logs

//            Console.WriteLine("doing ... Adding up to 10 items in MikeBoundaryConditions");

//            #region MikeBoundaryConditions
//            count = (from c in dbTestDB.MikeBoundaryConditions.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    MikeBoundaryCondition MikeBoundaryCondition = (from c in dbTestDB.MikeBoundaryConditions.AsNoTracking() select c).OrderByDescending(c => c.MikeBoundaryConditionID).FirstOrDefault();
//                    try
//                    {
//                        MikeBoundaryCondition.MikeBoundaryConditionID = 0;
//                        MikeBoundaryCondition.MikeBoundaryConditionCode = $"{ MikeBoundaryCondition.MikeBoundaryConditionCode }a";
//                        if (!await AddObject("MikeBoundaryCondition", MikeBoundaryCondition)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion MikeBoundaryConditions

//            Console.WriteLine("doing ... Adding up to 10 items in MikeScenarios");

//            #region MikeScenarios
//            count = (from c in dbTestDB.MikeScenarios.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    MikeScenario MikeScenario = (from c in dbTestDB.MikeScenarios.AsNoTracking() select c).OrderByDescending(c => c.MikeScenarioID).FirstOrDefault();
//                    try
//                    {
//                        MikeScenario.MikeScenarioID = 0;
//                        MikeScenario.ManningNumber = MikeScenario.ManningNumber + 0.1f;
//                        if (!await AddObject("MikeScenario", MikeScenario)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion MikeScenarios

//            Console.WriteLine("doing ... Adding up to 10 items in MikeScenarioResults");

//            #region MikeScenarioResults
//            count = (from c in dbTestDB.MikeScenarioResults.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    MikeScenarioResult MikeScenarioResult = (from c in dbTestDB.MikeScenarioResults.AsNoTracking() select c).OrderByDescending(c => c.MikeScenarioResultID).FirstOrDefault();
//                    try
//                    {
//                        MikeScenarioResult.MikeScenarioResultID = 0;
//                        if (!await AddObject("MikeScenarioResult", MikeScenarioResult)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion MikeScenarioResults

//            Console.WriteLine("doing ... Adding up to 10 items in MikeSources");

//            #region MikeSources
//            count = (from c in dbTestDB.MikeSources.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    MikeSource MikeSource = (from c in dbTestDB.MikeSources.AsNoTracking() select c).OrderByDescending(c => c.MikeSourceID).FirstOrDefault();
//                    MikeSourceStartEnd MikeSourceStartEnd = (from c in dbTestDB.MikeSourceStartEnds.AsNoTracking() select c).OrderByDescending(c => c.MikeSourceStartEndID).FirstOrDefault();
//                    try
//                    {
//                        MikeSource.MikeSourceID = 0;
//                        MikeSource.SourceNumberString = $"{ MikeSource.SourceNumberString }a";
//                        if (!await AddObject("MikeSource", MikeSource)) return await Task.FromResult(false);

//                        MikeSourceStartEnd.MikeSourceStartEndID = 0;
//                        MikeSourceStartEnd.SourcePollutionStart_MPN_100ml = MikeSourceStartEnd.SourcePollutionStart_MPN_100ml + 1;
//                        MikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = MikeSourceStartEnd.SourcePollutionEnd_MPN_100ml + 1;
//                        if (!await AddObject("MikeSourceStartEnd", MikeSourceStartEnd)) return await Task.FromResult(false);

//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion MikeSources

//            Console.WriteLine("doing ... Adding up to 10 items in MWQMAnalysisReportParameters");

//            #region MWQMAnalysisReportParameters
//            count = (from c in dbTestDB.MWQMAnalysisReportParameters.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    MWQMAnalysisReportParameter MWQMAnalysisReportParameter = (from c in dbTestDB.MWQMAnalysisReportParameters.AsNoTracking() select c).OrderByDescending(c => c.MWQMAnalysisReportParameterID).FirstOrDefault();
//                    try
//                    {
//                        MWQMAnalysisReportParameter.MWQMAnalysisReportParameterID = 0;
//                        MWQMAnalysisReportParameter.AnalysisName = $"{ MWQMAnalysisReportParameter.AnalysisName }a";
//                        if (!await AddObject("MWQMAnalysisReportParameter", MWQMAnalysisReportParameter)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion MWQMAnalysisReportParameters            

//            Console.WriteLine("doing ... Adding up to 10 items in MWQMRuns");

//            #region MWQMRuns
//            count = (from c in dbTestDB.MWQMRuns.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    MWQMRun MWQMRun = (from c in dbTestDB.MWQMRuns.AsNoTracking() select c).OrderByDescending(c => c.MWQMRunID).FirstOrDefault();
//                    List<MWQMRunLanguage> MWQMRunLanguageList = (from c in dbTestDB.MWQMRunLanguages.AsNoTracking() select c).OrderByDescending(c => c.MWQMRunLanguageID).Take(2).ToList();
//                    try
//                    {
//                        MWQMRun.MWQMRunID = 0;
//                        MWQMRun.TemperatureControl1_C = MWQMRun.TemperatureControl1_C + 1.1f;
//                        if (!await AddObject("MWQMRun", MWQMRun)) return await Task.FromResult(false);

//                        foreach (MWQMRunLanguage MWQMRunLanguage in MWQMRunLanguageList)
//                        {
//                            MWQMRunLanguage.MWQMRunLanguageID = 0;
//                            MWQMRunLanguage.RunComment = $"{ MWQMRunLanguage.RunComment }a";
//                            if (!await AddObject("MWQMRunLanguage", MWQMRunLanguage)) return await Task.FromResult(false);
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion MWQMRuns

//            Console.WriteLine("doing ... Adding up to 10 items in MWQMSamples");

//            #region MWQMSamples
//            count = (from c in dbTestDB.MWQMSamples.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    MWQMSample MWQMSample = (from c in dbTestDB.MWQMSamples.AsNoTracking() select c).OrderByDescending(c => c.MWQMSampleID).FirstOrDefault();
//                    List<MWQMSampleLanguage> MWQMSampleLanguageList = (from c in dbTestDB.MWQMSampleLanguages.AsNoTracking() select c).OrderByDescending(c => c.MWQMSampleLanguageID).Take(2).ToList();
//                    try
//                    {
//                        MWQMSample.MWQMSampleID = 0;
//                        MWQMSample.PH = MWQMSample.PH + 1.1f;
//                        if (!await AddObject("MWQMSample", MWQMSample)) return await Task.FromResult(false);

//                        foreach (MWQMSampleLanguage MWQMSampleLanguage in MWQMSampleLanguageList)
//                        {
//                            MWQMSampleLanguage.MWQMSampleLanguageID = 0;
//                            MWQMSampleLanguage.MWQMSampleNote = $"{ MWQMSampleLanguage.MWQMSampleNote }a";
//                            if (!await AddObject("MWQMSampleLanguage", MWQMSampleLanguage)) return await Task.FromResult(false);
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion MWQMSamples

//            Console.WriteLine("doing ... Adding up to 10 items in MWQMSites");

//            #region MWQMSites
//            count = (from c in dbTestDB.MWQMSites.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    MWQMSite MWQMSite = (from c in dbTestDB.MWQMSites.AsNoTracking() select c).OrderByDescending(c => c.MWQMSiteID).FirstOrDefault();
//                    MWQMSiteStartEndDate MWQMSiteStartEndDate = (from c in dbTestDB.MWQMSiteStartEndDates.AsNoTracking() select c).OrderByDescending(c => c.MWQMSiteStartEndDateID).FirstOrDefault();
//                    try
//                    {
//                        MWQMSite.MWQMSiteID = 0;
//                        MWQMSite.MWQMSiteDescription = $"{ MWQMSite.MWQMSiteDescription }a";
//                        if (!await AddObject("MWQMSite", MWQMSite)) return await Task.FromResult(false);

//                        MWQMSiteStartEndDate.MWQMSiteStartEndDateID = 0;
//                        MWQMSiteStartEndDate.StartDate = MWQMSiteStartEndDate.StartDate.AddHours(1);
//                        MWQMSiteStartEndDate.EndDate = MWQMSiteStartEndDate.EndDate.Value.AddHours(1);
//                        if (!await AddObject("MWQMSiteStartEndDate", MWQMSiteStartEndDate)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion MWQMSites

//            Console.WriteLine("doing ... Adding up to 10 items in MWQMSubsectors");

//            #region MWQMSubsectors
//            count = (from c in dbTestDB.MWQMSubsectors.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    MWQMSubsector MWQMSubsector = (from c in dbTestDB.MWQMSubsectors.AsNoTracking() select c).OrderByDescending(c => c.MWQMSubsectorID).FirstOrDefault();
//                    List<MWQMSubsectorLanguage> MWQMSubsectorLanguageList = (from c in dbTestDB.MWQMSubsectorLanguages.AsNoTracking() select c).OrderByDescending(c => c.MWQMSubsectorLanguageID).Take(2).ToList();
//                    try
//                    {
//                        MWQMSubsector.MWQMSubsectorID = 0;
//                        MWQMSubsector.SubsectorHistoricKey = (MWQMSubsector.SubsectorHistoricKey.Length > 19 ? "bbb" : $"{ MWQMSubsector.SubsectorHistoricKey }a");
//                        if (!await AddObject("MWQMSubsector", MWQMSubsector)) return await Task.FromResult(false);

//                        foreach (MWQMSubsectorLanguage MWQMSubsectorLanguage in MWQMSubsectorLanguageList)
//                        {
//                            MWQMSubsectorLanguage.MWQMSubsectorLanguageID = 0;
//                            MWQMSubsectorLanguage.SubsectorDesc = $"{ MWQMSubsectorLanguage.SubsectorDesc }a";
//                            if (!await AddObject("MWQMSubsectorLanguage", MWQMSubsectorLanguage)) return await Task.FromResult(false);
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion MWQMSubsectors

//            Console.WriteLine("doing ... Adding up to 10 items in PolSourceSites");

//            #region PolSourceSites
//            count = (from c in dbTestDB.PolSourceSites.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    PolSourceSite PolSourceSite = (from c in dbTestDB.PolSourceSites.AsNoTracking() select c).OrderByDescending(c => c.PolSourceSiteID).FirstOrDefault();
//                    PolSourceObservation PolSourceObservation = (from c in dbTestDB.PolSourceObservations.AsNoTracking() select c).OrderByDescending(c => c.PolSourceObservationID).FirstOrDefault();
//                    PolSourceObservationIssue PolSourceObservationIssue = (from c in dbTestDB.PolSourceObservationIssues.AsNoTracking() select c).OrderByDescending(c => c.PolSourceObservationIssueID).FirstOrDefault();
//                    try
//                    {
//                        PolSourceSite.PolSourceSiteID = 0;
//                        PolSourceSite.Temp_Locator_CanDelete = $"{ PolSourceSite.Temp_Locator_CanDelete }a";
//                        if (!await AddObject("PolSourceSite", PolSourceSite)) return await Task.FromResult(false);

//                        PolSourceObservation.PolSourceObservationID = 0;
//                        PolSourceObservation.PolSourceSiteID = PolSourceSite.PolSourceSiteID;
//                        PolSourceObservation.Observation_ToBeDeleted = $"{ PolSourceObservation.Observation_ToBeDeleted }a";
//                        if (!await AddObject("PolSourceObservation", PolSourceObservation)) return await Task.FromResult(false);

//                        PolSourceObservationIssue.PolSourceObservationIssueID = 0;
//                        PolSourceObservationIssue.PolSourceObservationID = PolSourceObservation.PolSourceObservationID;
//                        PolSourceObservationIssue.ExtraComment = $"{ PolSourceObservationIssue.ExtraComment }a";
//                        if (!await AddObject("PolSourceObservationIssue", PolSourceObservationIssue)) return await Task.FromResult(false);

//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion PolSourceSites

//            Console.WriteLine("doing ... Adding up to 10 items in RainExceedances");

//            #region RainExceedances
//            count = (from c in dbTestDB.RainExceedances.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    RainExceedance RainExceedance = (from c in dbTestDB.RainExceedances.AsNoTracking() select c).OrderByDescending(c => c.RainExceedanceID).FirstOrDefault();
//                    try
//                    {
//                        RainExceedance.RainExceedanceID = 0;
//                        RainExceedance.RainMaximum_mm = RainExceedance.RainMaximum_mm + 1;
//                        if (!await AddObject("RainExceedance", RainExceedance)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion RainExceedances

//            Console.WriteLine("doing ... Adding up to 10 items in RainExceedanceClimateSites");

//            #region RainExceedanceClimateSites
//            List<int> ClimateSiteTVItemIDList = (from c in dbTestDB.ClimateSites.AsNoTracking() where c.Province == "NB" select c.ClimateSiteTVItemID).Take(30).ToList();

//            count = (from c in dbTestDB.RainExceedanceClimateSites.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    RainExceedanceClimateSite RainExceedanceClimateSite = (from c in dbTestDB.RainExceedanceClimateSites.AsNoTracking() select c).OrderByDescending(c => c.RainExceedanceClimateSiteID).FirstOrDefault();
//                    try
//                    {
//                        RainExceedanceClimateSite.RainExceedanceClimateSiteID = 0;
//                        RainExceedanceClimateSite.ClimateSiteTVItemID = ClimateSiteTVItemIDList[i];
//                        if (!await AddObject("RainExceedanceClimateSite", RainExceedanceClimateSite)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion RainExceedanceClimateSites

//            Console.WriteLine("doing ... Adding up to 10 items in RetingCurves");

//            #region RatingCurves
//            count = (from c in dbTestDB.RatingCurves.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    RatingCurve RatingCurve = (from c in dbTestDB.RatingCurves.AsNoTracking() select c).OrderByDescending(c => c.RatingCurveID).FirstOrDefault();
//                    RatingCurveValue RatingCurveValue = (from c in dbTestDB.RatingCurveValues.AsNoTracking() select c).OrderByDescending(c => c.RatingCurveValueID).FirstOrDefault();
//                    try
//                    {
//                        RatingCurve.RatingCurveID = 0;
//                        RatingCurve.RatingCurveNumber = RatingCurve.RatingCurveNumber + 1;
//                        if (!await AddObject("RatingCurve", RatingCurve)) return await Task.FromResult(false);

//                        RatingCurveValue.RatingCurveValueID = 0;
//                        RatingCurveValue.RatingCurveID = RatingCurve.RatingCurveID;
//                        RatingCurveValue.StageValue_m = RatingCurveValue.StageValue_m + 1;
//                        if (!await AddObject("RatingCurveValue", RatingCurveValue)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion RatingCurves

//            Console.WriteLine("doing ... Adding up to 10 items in ReportSections");

//            #region ReportSections
//            count = (from c in dbTestDB.ReportSections.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    ReportSection ReportSection = (from c in dbTestDB.ReportSections.AsNoTracking() select c).OrderByDescending(c => c.ReportSectionID).FirstOrDefault();
//                    //List<ReportSectionLanguage> ReportSectionLanguageList = (from c in dbTestDB.ReportSectionLanguages.AsNoTracking() select c).OrderByDescending(c => c.ReportSectionLanguageID).Take(2).ToList();
//                    try
//                    {
//                        ReportSection.ReportSectionID = 0;
//                        ReportSection.Year = ReportSection.Year + 1;
//                        if (!await AddObject("ReportSection", ReportSection)) return await Task.FromResult(false);

//                        //foreach (ReportSectionLanguage ReportSectionLanguage in ReportSectionLanguageList)
//                        //{
//                        //    ReportSectionLanguage.ReportSectionLanguageID = 0;
//                        //    ReportSectionLanguage.ReportSectionID = ReportSection.ReportSectionID;
//                        //    ReportSectionLanguage.ReportSectionName = $"{ ReportSectionLanguage.ReportSectionName }a";
//                        //    if (!await AddObject("ReportSectionLanguage", ReportSectionLanguage)) return await Task.FromResult(false);
//                        //}
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion ReportSections

//            Console.WriteLine("doing ... Adding up to 10 items in ReportTypes");

//            #region ReportTypes
//            count = (from c in dbTestDB.ReportTypes.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    ReportType ReportType = (from c in dbTestDB.ReportTypes.AsNoTracking() select c).OrderByDescending(c => c.ReportTypeID).FirstOrDefault();
//                    //List<ReportTypeLanguage> ReportTypeLanguageList = (from c in dbTestDB.ReportTypeLanguages.AsNoTracking() select c).OrderByDescending(c => c.ReportTypeLanguageID).Take(2).ToList();
//                    try
//                    {
//                        ReportType.ReportTypeID = 0;
//                        ReportType.UniqueCode = $"{ ReportType.UniqueCode }a";
//                        if (!await AddObject("ReportType", ReportType)) return await Task.FromResult(false);

//                        //foreach (ReportTypeLanguage ReportTypeLanguage in ReportTypeLanguageList)
//                        //{
//                        //    ReportTypeLanguage.ReportTypeLanguageID = 0;
//                        //    ReportTypeLanguage.ReportTypeID = ReportType.ReportTypeID;
//                        //    ReportTypeLanguage.Name = $"{ ReportTypeLanguage.Name }a";
//                        //    if (!await AddObject("ReportTypeLanguage", ReportTypeLanguage)) return await Task.FromResult(false);
//                        //}
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion ReportTypes

//            Console.WriteLine("doing ... Adding up to 10 items in ResetPasswords");

//            #region ResetPasswords
//            count = (from c in dbTestDB.ResetPasswords.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    ResetPassword ResetPassword = (from c in dbTestDB.ResetPasswords.AsNoTracking() select c).OrderByDescending(c => c.ResetPasswordID).FirstOrDefault();
//                    try
//                    {
//                        ResetPassword.ResetPasswordID = 0;
//                        ResetPassword.Email = $"{ ResetPassword.Email }a";
//                        if (!await AddObject("ResetPassword", ResetPassword)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion ResetPasswords

//            Console.WriteLine("doing ... Adding up to 10 items in SamplingPlans");

//            #region SamplingPlans
//            count = (from c in dbTestDB.SamplingPlans.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    SamplingPlan SamplingPlan = (from c in dbTestDB.SamplingPlans.AsNoTracking() select c).OrderByDescending(c => c.SamplingPlanID).FirstOrDefault();
//                    SamplingPlanEmail SamplingPlanEmail = (from c in dbTestDB.SamplingPlanEmails.AsNoTracking() select c).OrderByDescending(c => c.SamplingPlanEmailID).FirstOrDefault();
//                    SamplingPlanSubsector SamplingPlanSubsector = (from c in dbTestDB.SamplingPlanSubsectors.AsNoTracking() select c).OrderByDescending(c => c.SamplingPlanSubsectorID).FirstOrDefault();
//                    SamplingPlanSubsectorSite SamplingPlanSubsectorSite = (from c in dbTestDB.SamplingPlanSubsectorSites.AsNoTracking() select c).OrderByDescending(c => c.SamplingPlanSubsectorSiteID).FirstOrDefault();
//                    try
//                    {
//                        SamplingPlan.SamplingPlanID = 0;
//                        SamplingPlan.ForGroupName = $"{ SamplingPlan.ForGroupName }a";
//                        SamplingPlan.SamplingPlanName = $"{ SamplingPlan.SamplingPlanName }a";
//                        if (!await AddObject("SamplingPlan", SamplingPlan)) return await Task.FromResult(false);

//                        SamplingPlanEmail.SamplingPlanEmailID = 0;
//                        SamplingPlanEmail.Email = $"a{ SamplingPlanEmail.Email }";
//                        if (!await AddObject("SamplingPlanEmail", SamplingPlanEmail)) return await Task.FromResult(false);

//                        SamplingPlanSubsector.SamplingPlanSubsectorID = 0;
//                        SamplingPlanSubsector.SamplingPlanID = SamplingPlan.SamplingPlanID;
//                        if (!await AddObject("SamplingPlanSubsector", SamplingPlanSubsector)) return await Task.FromResult(false);

//                        SamplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = 0;
//                        SamplingPlanSubsectorSite.SamplingPlanSubsectorID = SamplingPlanSubsectorSite.SamplingPlanSubsectorID;
//                        if (!await AddObject("SamplingPlanSubsectorSite", SamplingPlanSubsectorSite)) return await Task.FromResult(false);

//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion SamplingPlans

//            Console.WriteLine("doing ... Adding up to 10 items in Spills");

//            #region Spills
//            count = (from c in dbTestDB.Spills.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    Spill Spill = (from c in dbTestDB.Spills.AsNoTracking() select c).OrderByDescending(c => c.SpillID).FirstOrDefault();
//                    List<SpillLanguage> SpillLanguageList = (from c in dbTestDB.SpillLanguages.AsNoTracking() select c).OrderByDescending(c => c.SpillLanguageID).Take(2).ToList();
//                    try
//                    {
//                        Spill.SpillID = 0;
//                        Spill.AverageFlow_m3_day = Spill.AverageFlow_m3_day + 1;
//                        if (!await AddObject("Spill", Spill)) return await Task.FromResult(false);

//                        foreach (SpillLanguage SpillLanguage in SpillLanguageList)
//                        {
//                            SpillLanguage.SpillLanguageID = 0;
//                            SpillLanguage.SpillComment = $"{ SpillLanguage.SpillComment }a";
//                            if (!await AddObject("SpillLanguage", SpillLanguage)) return await Task.FromResult(false);
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion Spills

//            Console.WriteLine("doing ... Adding up to 10 items in Tels");

//            #region Tels
//            count = (from c in dbTestDB.Tels.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    Tel Tel = (from c in dbTestDB.Tels.AsNoTracking() select c).OrderByDescending(c => c.TelID).FirstOrDefault();
//                    try
//                    {
//                        Tel.TelID = 0;
//                        Tel.TelNumber = Tel.TelNumber.Substring(Tel.TelNumber.Length - 2) + count * 2;
//                        if (!await AddObject("Tel", Tel)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion Tels

//            Console.WriteLine("doing ... Adding up to 10 items in TideDataValues");

//            #region TideDataValues
//            count = (from c in dbTestDB.TideDataValues.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    TideDataValue TideDataValue = (from c in dbTestDB.TideDataValues.AsNoTracking() select c).OrderByDescending(c => c.TideDataValueID).FirstOrDefault();
//                    try
//                    {
//                        TideDataValue.TideDataValueID = 0;
//                        TideDataValue.Depth_m = TideDataValue.Depth_m + 1;
//                        if (!await AddObject("TideDataValue", TideDataValue)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion TideDataValues

//            Console.WriteLine("doing ... Adding up to 10 items in TideLocations");

//            #region TideLocations
//            count = (from c in dbTestDB.TideLocations.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    TideLocation TideLocation = (from c in dbTestDB.TideLocations.AsNoTracking() select c).OrderByDescending(c => c.TideLocationID).FirstOrDefault();
//                    try
//                    {
//                        TideLocation.TideLocationID = 0;
//                        TideLocation.Name = $"{ TideLocation.Name }a";
//                        if (!await AddObject("TideLocation", TideLocation)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion TideLocations

//            Console.WriteLine("doing ... Adding up to 10 items in TideSites");

//            #region TideSites
//            count = (from c in dbTestDB.TideSites.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    TideSite TideSite = (from c in dbTestDB.TideSites.AsNoTracking() select c).OrderByDescending(c => c.TideSiteID).FirstOrDefault();
//                    try
//                    {
//                        TideSite.TideSiteID = 0;
//                        TideSite.TideSiteName = $"{ TideSite.TideSiteName }a";
//                        if (!await AddObject("TideSite", TideSite)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion TideSites

//            Console.WriteLine("doing ... Adding up to 10 items in TVFiles");

//            #region TVFiles
//            count = (from c in dbTestDB.TVFiles.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    TVFile TVFile = (from c in dbTestDB.TVFiles.AsNoTracking() select c).OrderByDescending(c => c.TVFileID).FirstOrDefault();
//                    List<TVFileLanguage> TVFileLanguageList = (from c in dbTestDB.TVFileLanguages.AsNoTracking() select c).OrderByDescending(c => c.TVFileLanguageID).Take(2).ToList();
//                    try
//                    {
//                        TVFile.TVFileID = 0;
//                        TVFile.Parameters = $"{ TVFile.Parameters }a";
//                        if (!await AddObject("TVFile", TVFile)) return await Task.FromResult(false);

//                        foreach (TVFileLanguage TVFileLanguage in TVFileLanguageList)
//                        {
//                            TVFileLanguage.TVFileLanguageID = 0;
//                            TVFileLanguage.FileDescription = $"{ TVFileLanguage.FileDescription }a";
//                            if (!await AddObject("TVFileLanguage", TVFileLanguage)) return await Task.FromResult(false);
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion TVFiles

//            Console.WriteLine("doing ... Adding up to 10 items in TVItemLinks");

//            #region TVItemLinks
//            count = (from c in dbTestDB.TVItemLinks.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    TVItemLink TVItemLink = (from c in dbTestDB.TVItemLinks.AsNoTracking() select c).OrderByDescending(c => c.TVItemLinkID).FirstOrDefault();
//                    try
//                    {
//                        TVItemLink.TVItemLinkID = 0;
//                        //TVItemLink.Email = $"{ TVItemLink.Email }a";
//                        if (!await AddObject("TVItemLink", TVItemLink)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion TVItemLinks

//            Console.WriteLine("doing ... Adding up to 10 items in TVItemStats");

//            #region TVItemStats
//            count = (from c in dbTestDB.TVItemStats.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    TVItemStat TVItemStat = (from c in dbTestDB.TVItemStats.AsNoTracking() select c).OrderByDescending(c => c.TVItemStatID).FirstOrDefault();
//                    try
//                    {
//                        TVItemStat.TVItemStatID = 0;
//                        TVItemStat.ChildCount = TVItemStat.ChildCount + 1;
//                        if (!await AddObject("TVItemStat", TVItemStat)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion TVItemStats

//            Console.WriteLine("doing ... Adding up to 10 items in TVItemUserAuthorizations");

//            #region TVItemUserAuthorizations
//            count = (from c in dbTestDB.TVItemUserAuthorizations.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    TVItemUserAuthorization TVItemUserAuthorization = (from c in dbTestDB.TVItemUserAuthorizations.AsNoTracking() select c).OrderByDescending(c => c.TVItemUserAuthorizationID).FirstOrDefault();
//                    try
//                    {
//                        TVItemUserAuthorization.TVItemUserAuthorizationID = 0;
//                        if (!await AddObject("TVItemUserAuthorization", TVItemUserAuthorization)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion TVItemUserAuthorizations

//            Console.WriteLine("doing ... Adding up to 10 items in TVTypeUserAuthorizations");

//            #region TVTypeUserAuthorizations
//            count = (from c in dbTestDB.TVTypeUserAuthorizations.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    TVTypeUserAuthorization TVTypeUserAuthorization = (from c in dbTestDB.TVTypeUserAuthorizations.AsNoTracking() select c).OrderByDescending(c => c.TVTypeUserAuthorizationID).FirstOrDefault();
//                    try
//                    {
//                        TVTypeUserAuthorization.TVTypeUserAuthorizationID = 0;
//                        if (!await AddObject("TVTypeUserAuthorization", TVTypeUserAuthorization)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion TVTypeUserAuthorizations

//            Console.WriteLine("doing ... Adding up to 10 items in UseOfSites");

//            #region UseOfSites
//            count = (from c in dbTestDB.UseOfSites.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    UseOfSite UseOfSite = (from c in dbTestDB.UseOfSites.AsNoTracking() select c).OrderByDescending(c => c.UseOfSiteID).FirstOrDefault();
//                    try
//                    {
//                        UseOfSite.UseOfSiteID = 0;
//                        UseOfSite.Weight_perc = UseOfSite.Weight_perc + 1;
//                        if (!await AddObject("UseOfSite", UseOfSite)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion UseOfSites

//            Console.WriteLine("doing ... Adding up to 10 items in VPScenarios");

//            #region VPScenarios
//            count = (from c in dbTestDB.VPScenarios.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    VPScenario VPScenario = (from c in dbTestDB.VPScenarios.AsNoTracking() select c).OrderByDescending(c => c.VPScenarioID).FirstOrDefault();
//                    VPResult VPResult = (from c in dbTestDB.VPResults.AsNoTracking() select c).OrderByDescending(c => c.VPResultID).FirstOrDefault();
//                    VPAmbient VPAmbient = (from c in dbTestDB.VPAmbients.AsNoTracking() select c).OrderByDescending(c => c.VPAmbientID).FirstOrDefault();
//                    List<VPScenarioLanguage> VPScenarioLanguageList = (from c in dbTestDB.VPScenarioLanguages.AsNoTracking() select c).OrderByDescending(c => c.VPScenarioLanguageID).Take(2).ToList();
//                    try
//                    {
//                        VPScenario.VPScenarioID = 0;
//                        VPScenario.PortDiameter_m = VPScenario.PortDiameter_m + 0.1f;
//                        if (!await AddObject("VPScenario", VPScenario)) return await Task.FromResult(false);

//                        VPResult.VPResultID = 0;
//                        VPResult.VPScenarioID = VPScenario.VPScenarioID;
//                        VPResult.TravelTime_hour = VPResult.TravelTime_hour + 1;
//                        if (!await AddObject("VPResult", VPResult)) return await Task.FromResult(false);

//                        VPAmbient.VPAmbientID = 0;
//                        VPAmbient.VPScenarioID = VPAmbient.VPScenarioID;
//                        VPAmbient.MeasurementDepth_m = VPAmbient.MeasurementDepth_m + 0.02f;
//                        if (!await AddObject("VPAmbient", VPAmbient)) return await Task.FromResult(false);

//                        foreach (VPScenarioLanguage VPScenarioLanguage in VPScenarioLanguageList)
//                        {
//                            VPScenarioLanguage.VPScenarioLanguageID = 0;
//                            VPScenarioLanguage.VPScenarioID = VPScenario.VPScenarioID;
//                            VPScenarioLanguage.VPScenarioName = $"{ VPScenarioLanguage.VPScenarioName }a";
//                            if (!await AddObject("VPScenarioLanguage", VPScenarioLanguage)) return await Task.FromResult(false);
//                        }

//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion VPScenarios

//            Console.WriteLine("doing ... Adding up to 10 items in PolSourceSiteEffects");

//            #region PolSourceSiteEffects
//            count = (from c in dbTestDB.PolSourceSiteEffects.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    PolSourceSiteEffect polSourceSiteEffect = (from c in dbTestDB.PolSourceSiteEffects.AsNoTracking() select c).OrderByDescending(c => c.PolSourceSiteEffectID).FirstOrDefault();
//                    try
//                    {
//                        polSourceSiteEffect.PolSourceSiteEffectID = 0;
//                        polSourceSiteEffect.Comments = polSourceSiteEffect.Comments + "a";
//                        if (!await AddObject("PolSourceSiteEffect", polSourceSiteEffect)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion PolSourceSiteEffects

//            Console.WriteLine("doing ... Adding up to 10 items in PolSourceSiteEffectTerms");

//            #region PolSourceSiteEffectTerms
//            count = (from c in dbTestDB.PolSourceSiteEffectTerms.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    PolSourceSiteEffectTerm polSourceSiteEffectTerm = (from c in dbTestDB.PolSourceSiteEffectTerms.AsNoTracking() select c).OrderByDescending(c => c.PolSourceSiteEffectTermID).FirstOrDefault();
//                    try
//                    {
//                        polSourceSiteEffectTerm.PolSourceSiteEffectTermID = 0;
//                        polSourceSiteEffectTerm.EffectTermEN = polSourceSiteEffectTerm.EffectTermEN + "a";
//                        polSourceSiteEffectTerm.EffectTermFR = polSourceSiteEffectTerm.EffectTermFR + "a";
//                        if (!await AddObject("PolSourceSiteEffectTerm", polSourceSiteEffectTerm)) return await Task.FromResult(false);
//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion PolSourceSiteEffects

//            Console.WriteLine("doing ... Adding up to 10 items in PolSourceGroupings and PolSourceGroupingLanguages");

//            #region PolSourceGrouping and PolSourceGroupingLanguage
//            count = (from c in dbTestDB.PolSourceGroupings.AsNoTracking() select c).Count();
//            if (count < 10)
//            {
//                for (int i = count; i < 10; i++)
//                {
//                    PolSourceGrouping polSourceGrouping = (from c in dbTestDB.PolSourceGroupings.AsNoTracking() select c).OrderByDescending(c => c.PolSourceGroupingID).FirstOrDefault();
//                    PolSourceGroupingLanguage polSourceGroupingLanguage = (from c in dbTestDB.PolSourceGroupingLanguages.AsNoTracking() where c.PolSourceGroupingID == polSourceGrouping.PolSourceGroupingID && c.Language == LanguageEnum.en select c).OrderByDescending(c => c.PolSourceGroupingID).FirstOrDefault();
//                    PolSourceGroupingLanguage polSourceGroupingLanguageFR = (from c in dbTestDB.PolSourceGroupingLanguages.AsNoTracking() where c.PolSourceGroupingID == polSourceGrouping.PolSourceGroupingID && c.Language == LanguageEnum.fr select c).OrderByDescending(c => c.PolSourceGroupingID).FirstOrDefault();
//                    try
//                    {
//                        polSourceGrouping.PolSourceGroupingID = 0;
//                        polSourceGrouping.CSSPID = polSourceGrouping.CSSPID + 1;
//                        polSourceGrouping.GroupName = polSourceGrouping.GroupName + "a";
//                        polSourceGrouping.Child = polSourceGrouping.Child + "a";
//                        polSourceGrouping.Hide = polSourceGrouping.Hide + "a";
//                        if (!await AddObject("PolSourceGrouping", polSourceGrouping)) return await Task.FromResult(false);

//                        polSourceGroupingLanguage.PolSourceGroupingLanguageID = 0;
//                        polSourceGroupingLanguage.PolSourceGroupingID = polSourceGrouping.PolSourceGroupingID;
//                        polSourceGroupingLanguage.Language = LanguageEnum.en;
//                        polSourceGroupingLanguage.SourceName = polSourceGroupingLanguage.SourceName + "a";
//                        polSourceGroupingLanguage.SourceNameOrder = polSourceGroupingLanguage.SourceNameOrder + 1;
//                        polSourceGroupingLanguage.TranslationStatusSourceName = TranslationStatusEnum.Translated;
//                        polSourceGroupingLanguage.SourceName = polSourceGroupingLanguage.SourceName + "a";
//                        polSourceGroupingLanguage.TranslationStatusSourceName = TranslationStatusEnum.Translated;
//                        polSourceGroupingLanguage.Init = polSourceGroupingLanguage.Init + "a";
//                        polSourceGroupingLanguage.TranslationStatusInit = TranslationStatusEnum.Translated;
//                        polSourceGroupingLanguage.Description = polSourceGroupingLanguage.Description + "a";
//                        polSourceGroupingLanguage.TranslationStatusDescription = TranslationStatusEnum.Translated;
//                        polSourceGroupingLanguage.Report = polSourceGroupingLanguage.Report + "a";
//                        polSourceGroupingLanguage.TranslationStatusReport = TranslationStatusEnum.Translated;
//                        polSourceGroupingLanguage.Text = polSourceGroupingLanguage.Text + "a";
//                        polSourceGroupingLanguage.TranslationStatusText = TranslationStatusEnum.Translated;
//                        if (!await AddObject("PolSourceGroupingLanguage", polSourceGroupingLanguage)) return await Task.FromResult(false);

//                        polSourceGroupingLanguageFR.PolSourceGroupingLanguageID = 0;
//                        polSourceGroupingLanguageFR.PolSourceGroupingID = polSourceGrouping.PolSourceGroupingID;
//                        polSourceGroupingLanguageFR.Language = LanguageEnum.fr;
//                        polSourceGroupingLanguageFR.SourceName = polSourceGroupingLanguageFR.SourceName + "a";
//                        polSourceGroupingLanguageFR.SourceNameOrder = polSourceGroupingLanguageFR.SourceNameOrder + 1;
//                        polSourceGroupingLanguageFR.TranslationStatusSourceName = TranslationStatusEnum.Translated;
//                        polSourceGroupingLanguageFR.SourceName = polSourceGroupingLanguageFR.SourceName + "a";
//                        polSourceGroupingLanguageFR.TranslationStatusSourceName = TranslationStatusEnum.Translated;
//                        polSourceGroupingLanguageFR.Init = polSourceGroupingLanguageFR.Init + "a";
//                        polSourceGroupingLanguageFR.TranslationStatusInit = TranslationStatusEnum.Translated;
//                        polSourceGroupingLanguageFR.Description = polSourceGroupingLanguageFR.Description + "a";
//                        polSourceGroupingLanguageFR.TranslationStatusDescription = TranslationStatusEnum.Translated;
//                        polSourceGroupingLanguageFR.Report = polSourceGroupingLanguageFR.Report + "a";
//                        polSourceGroupingLanguageFR.TranslationStatusReport = TranslationStatusEnum.Translated;
//                        polSourceGroupingLanguageFR.Text = polSourceGroupingLanguageFR.Text + "a";
//                        polSourceGroupingLanguageFR.TranslationStatusText = TranslationStatusEnum.Translated;
//                        if (!await AddObject("PolSourceGroupingLanguage", polSourceGroupingLanguageFR)) return await Task.FromResult(false);

//                    }
//                    catch (Exception ex)
//                    {
//                        string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                        Console.WriteLine($"{ ex.Message }{ InnerException }");
//                        return await Task.FromResult(false);
//                    }
//                }
//            }
//            #endregion PolSourceGrouping and PolSourceGroupingLanguage

//            return await Task.FromResult(true);
//        }
//    }
//}
