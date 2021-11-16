//using CSSPDBModels;
//using System;
//using System.Threading.Tasks;

//namespace GenerateRepopulateTestDB
//{
//    public partial class Startup
//    {
//        private async Task<bool> AddObject(string TypeName, object objTarget)
//        {
//            switch (TypeName)
//            {
//                case "Address":
//                    {
//                        ((Address)objTarget).AddressID = 0;
//                        ((Address)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.Addresses.Add((Address)objTarget);
//                    }
//                    break;
//                case "AppErrLog":
//                    {
//                        ((AppErrLog)objTarget).AppErrLogID = 0;
//                        ((AppErrLog)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.AppErrLogs.Add((AppErrLog)objTarget);
//                    }
//                    break;
//                case "AppTask":
//                    {
//                        ((AppTask)objTarget).AppTaskID = 0;
//                        ((AppTask)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.AppTasks.Add((AppTask)objTarget);
//                    }
//                    break;
//                case "AppTaskLanguage":
//                    {
//                        ((AppTaskLanguage)objTarget).AppTaskLanguageID = 0;
//                        ((AppTaskLanguage)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.AppTaskLanguages.Add((AppTaskLanguage)objTarget);
//                    }
//                    break;
//                case "AspNetUser":
//                    {
//                        dbTestDB.AspNetUsers.Add((AspNetUser)objTarget);
//                    }
//                    break;
//                case "BoxModel":
//                    {
//                        ((BoxModel)objTarget).BoxModelID = 0;
//                        ((BoxModel)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.BoxModels.Add((BoxModel)objTarget);
//                    }
//                    break;
//                case "BoxModelLanguage":
//                    {
//                        ((BoxModelLanguage)objTarget).BoxModelLanguageID = 0;
//                        ((BoxModelLanguage)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.BoxModelLanguages.Add((BoxModelLanguage)objTarget);
//                    }
//                    break;
//                case "BoxModelResult":
//                    {
//                        ((BoxModelResult)objTarget).BoxModelResultID = 0;
//                        ((BoxModelResult)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.BoxModelResults.Add((BoxModelResult)objTarget);
//                    }
//                    break;
//                case "Classification":
//                    {
//                        ((Classification)objTarget).ClassificationID = 0;
//                        ((Classification)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.Classifications.Add((Classification)objTarget);
//                    }
//                    break;
//                case "ClimateDataValue":
//                    {
//                        ((ClimateDataValue)objTarget).ClimateDataValueID = 0;
//                        ((ClimateDataValue)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.ClimateDataValues.Add((ClimateDataValue)objTarget);
//                    }
//                    break;
//                case "ClimateSite":
//                    {
//                        ((ClimateSite)objTarget).ClimateSiteID = 0;
//                        ((ClimateSite)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.ClimateSites.Add((ClimateSite)objTarget);
//                    }
//                    break;
//                case "CoCoRaHSSite":
//                    {
//                        ((CoCoRaHSSite)objTarget).CoCoRaHSSiteID = 0;
//                        ((CoCoRaHSSite)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.CoCoRaHSSites.Add((CoCoRaHSSite)objTarget);
//                    }
//                    break;
//                case "CoCoRaHSValue":
//                    {
//                        ((CoCoRaHSValue)objTarget).CoCoRaHSValueID = 0;
//                        ((CoCoRaHSValue)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.CoCoRaHSValues.Add((CoCoRaHSValue)objTarget);
//                    }
//                    break;
//                case "Contact":
//                    {
//                        ((Contact)objTarget).ContactID = 0;
//                        ((Contact)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.Contacts.Add((Contact)objTarget);
//                    }
//                    break;
//                case "ContactPreference":
//                    {
//                        ((ContactPreference)objTarget).ContactPreferenceID = 0;
//                        ((ContactPreference)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.ContactPreferences.Add((ContactPreference)objTarget);
//                    }
//                    break;
//                case "ContactShortcut":
//                    {
//                        ((ContactShortcut)objTarget).ContactShortcutID = 0;
//                        ((ContactShortcut)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.ContactShortcuts.Add((ContactShortcut)objTarget);
//                    }
//                    break;
//                case "DocTemplate":
//                    {
//                        ((DocTemplate)objTarget).DocTemplateID = 0;
//                        ((DocTemplate)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.DocTemplates.Add((DocTemplate)objTarget);
//                    }
//                    break;
//                case "DrogueRun":
//                    {
//                        ((DrogueRun)objTarget).DrogueRunID = 0;
//                        ((DrogueRun)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.DrogueRuns.Add((DrogueRun)objTarget);
//                    }
//                    break;
//                case "DrogueRunPosition":
//                    {
//                        ((DrogueRunPosition)objTarget).DrogueRunPositionID = 0;
//                        ((DrogueRunPosition)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.DrogueRunPositions.Add((DrogueRunPosition)objTarget);
//                    }
//                    break;
//                case "Email":
//                    {
//                        ((Email)objTarget).EmailID = 0;
//                        ((Email)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.Emails.Add((Email)objTarget);
//                    }
//                    break;
//                case "EmailDistributionList":
//                    {
//                        ((EmailDistributionList)objTarget).EmailDistributionListID = 0;
//                        ((EmailDistributionList)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.EmailDistributionLists.Add((EmailDistributionList)objTarget);
//                    }
//                    break;
//                case "EmailDistributionListContact":
//                    {
//                        ((EmailDistributionListContact)objTarget).EmailDistributionListContactID = 0;
//                        ((EmailDistributionListContact)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.EmailDistributionListContacts.Add((EmailDistributionListContact)objTarget);
//                    }
//                    break;
//                case "EmailDistributionListContactLanguage":
//                    {
//                        ((EmailDistributionListContactLanguage)objTarget).EmailDistributionListContactLanguageID = 0;
//                        ((EmailDistributionListContactLanguage)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.EmailDistributionListContactLanguages.Add((EmailDistributionListContactLanguage)objTarget);
//                    }
//                    break;
//                case "EmailDistributionListLanguage":
//                    {
//                        ((EmailDistributionListLanguage)objTarget).EmailDistributionListLanguageID = 0;
//                        ((EmailDistributionListLanguage)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.EmailDistributionListLanguages.Add((EmailDistributionListLanguage)objTarget);
//                    }
//                    break;
//                case "HelpDoc":
//                    {
//                        ((HelpDoc)objTarget).HelpDocID = 0;
//                        ((HelpDoc)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.HelpDocs.Add((HelpDoc)objTarget);
//                    }
//                    break;
//                case "HydrometricDataValue":
//                    {
//                        ((HydrometricDataValue)objTarget).HydrometricDataValueID = 0;
//                        ((HydrometricDataValue)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.HydrometricDataValues.Add((HydrometricDataValue)objTarget);
//                    }
//                    break;
//                case "HydrometricSite":
//                    {
//                        ((HydrometricSite)objTarget).HydrometricSiteID = 0;
//                        ((HydrometricSite)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.HydrometricSites.Add((HydrometricSite)objTarget);
//                    }
//                    break;
//                case "Infrastructure":
//                    {
//                        ((Infrastructure)objTarget).InfrastructureID = 0;
//                        ((Infrastructure)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.Infrastructures.Add((Infrastructure)objTarget);
//                    }
//                    break;
//                case "InfrastructureLanguage":
//                    {
//                        ((InfrastructureLanguage)objTarget).InfrastructureLanguageID = 0;
//                        ((InfrastructureLanguage)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.InfrastructureLanguages.Add((InfrastructureLanguage)objTarget);
//                    }
//                    break;
//                case "LabSheet":
//                    {
//                        ((LabSheet)objTarget).LabSheetID = 0;
//                        ((LabSheet)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.LabSheets.Add((LabSheet)objTarget);
//                    }
//                    break;
//                case "LabSheetDetail":
//                    {
//                        ((LabSheetDetail)objTarget).LabSheetDetailID = 0;
//                        ((LabSheetDetail)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.LabSheetDetails.Add((LabSheetDetail)objTarget);
//                    }
//                    break;
//                case "LabSheetTubeMPNDetail":
//                    {
//                        ((LabSheetTubeMPNDetail)objTarget).LabSheetTubeMPNDetailID = 0;
//                        ((LabSheetTubeMPNDetail)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.LabSheetTubeMPNDetails.Add((LabSheetTubeMPNDetail)objTarget);
//                    }
//                    break;
//                case "Log":
//                    {
//                        ((Log)objTarget).LogID = 0;
//                        ((Log)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.Logs.Add((Log)objTarget);
//                    }
//                    break;
//                case "MikeBoundaryCondition":
//                    {
//                        ((MikeBoundaryCondition)objTarget).MikeBoundaryConditionID = 0;
//                        ((MikeBoundaryCondition)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.MikeBoundaryConditions.Add((MikeBoundaryCondition)objTarget);
//                    }
//                    break;
//                case "MikeScenario":
//                    {
//                        ((MikeScenario)objTarget).MikeScenarioID = 0;
//                        ((MikeScenario)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.MikeScenarios.Add((MikeScenario)objTarget);
//                    }
//                    break;
//                case "MikeScenarioResult":
//                    {
//                        ((MikeScenarioResult)objTarget).MikeScenarioResultID = 0;
//                        ((MikeScenarioResult)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.MikeScenarioResults.Add((MikeScenarioResult)objTarget);
//                    }
//                    break;
//                case "MikeSource":
//                    {
//                        ((MikeSource)objTarget).MikeSourceID = 0;
//                        ((MikeSource)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.MikeSources.Add((MikeSource)objTarget);
//                    }
//                    break;
//                case "MikeSourceStartEnd":
//                    {
//                        ((MikeSourceStartEnd)objTarget).MikeSourceStartEndID = 0;
//                        ((MikeSourceStartEnd)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.MikeSourceStartEnds.Add((MikeSourceStartEnd)objTarget);
//                    }
//                    break;
//                case "MWQMAnalysisReportParameter":
//                    {
//                        ((MWQMAnalysisReportParameter)objTarget).MWQMAnalysisReportParameterID = 0;
//                        ((MWQMAnalysisReportParameter)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.MWQMAnalysisReportParameters.Add((MWQMAnalysisReportParameter)objTarget);
//                    }
//                    break;
//                case "MWQMLookupMPN":
//                    {
//                        ((MWQMLookupMPN)objTarget).MWQMLookupMPNID = 0;
//                        ((MWQMLookupMPN)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.MWQMLookupMPNs.Add((MWQMLookupMPN)objTarget);
//                    }
//                    break;
//                case "MWQMRun":
//                    {
//                        ((MWQMRun)objTarget).MWQMRunID = 0;
//                        ((MWQMRun)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.MWQMRuns.Add((MWQMRun)objTarget);
//                    }
//                    break;
//                case "MWQMRunLanguage":
//                    {
//                        ((MWQMRunLanguage)objTarget).MWQMRunLanguageID = 0;
//                        ((MWQMRunLanguage)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.MWQMRunLanguages.Add((MWQMRunLanguage)objTarget);
//                    }
//                    break;
//                case "MWQMSample":
//                    {
//                        ((MWQMSample)objTarget).MWQMSampleID = 0;
//                        ((MWQMSample)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.MWQMSamples.Add((MWQMSample)objTarget);
//                    }
//                    break;
//                case "MWQMSampleLanguage":
//                    {
//                        ((MWQMSampleLanguage)objTarget).MWQMSampleLanguageID = 0;
//                        ((MWQMSampleLanguage)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.MWQMSampleLanguages.Add((MWQMSampleLanguage)objTarget);
//                    }
//                    break;
//                case "MWQMSite":
//                    {
//                        ((MWQMSite)objTarget).MWQMSiteID = 0;
//                        ((MWQMSite)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.MWQMSites.Add((MWQMSite)objTarget);
//                    }
//                    break;
//                case "MWQMSiteStartEndDate":
//                    {
//                        ((MWQMSiteStartEndDate)objTarget).MWQMSiteStartEndDateID = 0;
//                        ((MWQMSiteStartEndDate)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.MWQMSiteStartEndDates.Add((MWQMSiteStartEndDate)objTarget);
//                    }
//                    break;
//                case "MWQMSubsector":
//                    {
//                        ((MWQMSubsector)objTarget).MWQMSubsectorID = 0;
//                        ((MWQMSubsector)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.MWQMSubsectors.Add((MWQMSubsector)objTarget);
//                    }
//                    break;
//                case "MWQMSubsectorLanguage":
//                    {
//                        ((MWQMSubsectorLanguage)objTarget).MWQMSubsectorLanguageID = 0;
//                        ((MWQMSubsectorLanguage)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.MWQMSubsectorLanguages.Add((MWQMSubsectorLanguage)objTarget);
//                    }
//                    break;
//                case "PolSourceGrouping":
//                    {
//                        ((PolSourceGrouping)objTarget).PolSourceGroupingID = 0;
//                        ((PolSourceGrouping)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.PolSourceGroupings.Add((PolSourceGrouping)objTarget);
//                    }
//                    break;
//                case "PolSourceGroupingLanguage":
//                    {
//                        ((PolSourceGroupingLanguage)objTarget).PolSourceGroupingLanguageID = 0;
//                        ((PolSourceGroupingLanguage)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.PolSourceGroupingLanguages.Add((PolSourceGroupingLanguage)objTarget);
//                    }
//                    break;
//                case "PolSourceSite":
//                    {
//                        ((PolSourceSite)objTarget).PolSourceSiteID = 0;
//                        ((PolSourceSite)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.PolSourceSites.Add((PolSourceSite)objTarget);
//                    }
//                    break;
//                case "PolSourceObservation":
//                    {
//                        ((PolSourceObservation)objTarget).PolSourceObservationID = 0;
//                        ((PolSourceObservation)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.PolSourceObservations.Add((PolSourceObservation)objTarget);
//                    }
//                    break;
//                case "PolSourceObservationIssue":
//                    {
//                        ((PolSourceObservationIssue)objTarget).PolSourceObservationIssueID = 0;
//                        ((PolSourceObservationIssue)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.PolSourceObservationIssues.Add((PolSourceObservationIssue)objTarget);
//                    }
//                    break;
//                case "PolSourceSiteEffect":
//                    {
//                        ((PolSourceSiteEffect)objTarget).PolSourceSiteEffectID = 0;
//                        ((PolSourceSiteEffect)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.PolSourceSiteEffects.Add((PolSourceSiteEffect)objTarget);
//                    }
//                    break;
//                case "PolSourceSiteEffectTerm":
//                    {
//                        ((PolSourceSiteEffectTerm)objTarget).PolSourceSiteEffectTermID = 0;
//                        ((PolSourceSiteEffectTerm)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.PolSourceSiteEffectTerms.Add((PolSourceSiteEffectTerm)objTarget);
//                    }
//                    break;
//                case "RainExceedance":
//                    {
//                        ((RainExceedance)objTarget).RainExceedanceID = 0;
//                        ((RainExceedance)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.RainExceedances.Add((RainExceedance)objTarget);
//                    }
//                    break;
//                case "RainExceedanceClimateSite":
//                    {
//                        ((RainExceedanceClimateSite)objTarget).RainExceedanceClimateSiteID = 0;
//                        ((RainExceedanceClimateSite)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.RainExceedanceClimateSites.Add((RainExceedanceClimateSite)objTarget);
//                    }
//                    break;
//                case "RatingCurveValue":
//                    {
//                        ((RatingCurveValue)objTarget).RatingCurveValueID = 0;
//                        ((RatingCurveValue)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.RatingCurveValues.Add((RatingCurveValue)objTarget);
//                    }
//                    break;
//                case "RatingCurve":
//                    {
//                        ((RatingCurve)objTarget).RatingCurveID = 0;
//                        ((RatingCurve)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.RatingCurves.Add((RatingCurve)objTarget);
//                    }
//                    break;
//                case "ReportSection":
//                    {
//                        ((ReportSection)objTarget).ReportSectionID = 0;
//                        ((ReportSection)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.ReportSections.Add((ReportSection)objTarget);
//                    }
//                    break;
//                case "ReportType":
//                    {
//                        ((ReportType)objTarget).ReportTypeID = 0;
//                        ((ReportType)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.ReportTypes.Add((ReportType)objTarget);
//                    }
//                    break;
//                case "ResetPassword":
//                    {
//                        ((ResetPassword)objTarget).ResetPasswordID = 0;
//                        ((ResetPassword)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.ResetPasswords.Add((ResetPassword)objTarget);
//                    }
//                    break;
//                case "SamplingPlan":
//                    {
//                        ((SamplingPlan)objTarget).SamplingPlanID = 0;
//                        ((SamplingPlan)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.SamplingPlans.Add((SamplingPlan)objTarget);
//                    }
//                    break;
//                case "SamplingPlanEmail":
//                    {
//                        ((SamplingPlanEmail)objTarget).SamplingPlanEmailID = 0;
//                        ((SamplingPlanEmail)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.SamplingPlanEmails.Add((SamplingPlanEmail)objTarget);
//                    }
//                    break;
//                case "SamplingPlanSubsector":
//                    {
//                        ((SamplingPlanSubsector)objTarget).SamplingPlanSubsectorID = 0;
//                        ((SamplingPlanSubsector)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.SamplingPlanSubsectors.Add((SamplingPlanSubsector)objTarget);
//                    }
//                    break;
//                case "SamplingPlanSubsectorSite":
//                    {
//                        ((SamplingPlanSubsectorSite)objTarget).SamplingPlanSubsectorSiteID = 0;
//                        ((SamplingPlanSubsectorSite)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.SamplingPlanSubsectorSites.Add((SamplingPlanSubsectorSite)objTarget);
//                    }
//                    break;
//                case "Spill":
//                    {
//                        ((Spill)objTarget).SpillID = 0;
//                        ((Spill)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.Spills.Add((Spill)objTarget);
//                    }
//                    break;
//                case "SpillLanguage":
//                    {
//                        ((SpillLanguage)objTarget).SpillLanguageID = 0;
//                        ((SpillLanguage)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.SpillLanguages.Add((SpillLanguage)objTarget);
//                    }
//                    break;
//                case "Tel":
//                    {
//                        ((Tel)objTarget).TelID = 0;
//                        ((Tel)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.Tels.Add((Tel)objTarget);
//                    }
//                    break;
//                case "TideSite":
//                    {
//                        ((TideSite)objTarget).TideSiteID = 0;
//                        ((TideSite)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.TideSites.Add((TideSite)objTarget);
//                    }
//                    break;
//                case "TideDataValue":
//                    {
//                        ((TideDataValue)objTarget).TideDataValueID = 0;
//                        ((TideDataValue)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.TideDataValues.Add((TideDataValue)objTarget);
//                    }
//                    break;
//                case "TideLocation":
//                    {
//                        ((TideLocation)objTarget).TideLocationID = 0;
//                        //((TideLocation)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.TideLocations.Add((TideLocation)objTarget);
//                    }
//                    break;
//                case "TVFile":
//                    {
//                        ((TVFile)objTarget).TVFileID = 0;
//                        ((TVFile)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.TVFiles.Add((TVFile)objTarget);
//                    }
//                    break;
//                case "TVFileLanguage":
//                    {
//                        ((TVFileLanguage)objTarget).TVFileLanguageID = 0;
//                        ((TVFileLanguage)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.TVFileLanguages.Add((TVFileLanguage)objTarget);
//                    }
//                    break;
//                case "TVItem":
//                    {
//                        ((TVItem)objTarget).TVItemID = 0;
//                        ((TVItem)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.TVItems.Add((TVItem)objTarget);
//                    }
//                    break;
//                case "TVItemLanguage":
//                    {
//                        ((TVItemLanguage)objTarget).TVItemLanguageID = 0;
//                        ((TVItemLanguage)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.TVItemLanguages.Add((TVItemLanguage)objTarget);
//                    }
//                    break;
//                case "TVItemLink":
//                    {
//                        ((TVItemLink)objTarget).TVItemLinkID = 0;
//                        ((TVItemLink)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.TVItemLinks.Add((TVItemLink)objTarget);
//                    }
//                    break;
//                case "TVItemStat":
//                    {
//                        ((TVItemStat)objTarget).TVItemStatID = 0;
//                        ((TVItemStat)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.TVItemStats.Add((TVItemStat)objTarget);
//                    }
//                    break;
//                case "TVItemUserAuthorization":
//                    {
//                        ((TVItemUserAuthorization)objTarget).TVItemUserAuthorizationID = 0;
//                        ((TVItemUserAuthorization)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.TVItemUserAuthorizations.Add((TVItemUserAuthorization)objTarget);
//                    }
//                    break;
//                case "TVTypeUserAuthorization":
//                    {
//                        ((TVTypeUserAuthorization)objTarget).TVTypeUserAuthorizationID = 0;
//                        ((TVTypeUserAuthorization)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.TVTypeUserAuthorizations.Add((TVTypeUserAuthorization)objTarget);
//                    }
//                    break;
//                case "UseOfSite":
//                    {
//                        ((UseOfSite)objTarget).UseOfSiteID = 0;
//                        ((UseOfSite)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.UseOfSites.Add((UseOfSite)objTarget);
//                    }
//                    break;
//                case "VPAmbient":
//                    {
//                        ((VPAmbient)objTarget).VPAmbientID = 0;
//                        ((VPAmbient)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.VPAmbients.Add((VPAmbient)objTarget);
//                    }
//                    break;
//                case "VPResult":
//                    {
//                        ((VPResult)objTarget).VPResultID = 0;
//                        ((VPResult)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.VPResults.Add((VPResult)objTarget);
//                    }
//                    break;
//                case "VPScenario":
//                    {
//                        ((VPScenario)objTarget).VPScenarioID = 0;
//                        ((VPScenario)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.VPScenarios.Add((VPScenario)objTarget);
//                    }
//                    break;
//                case "VPScenarioLanguage":
//                    {
//                        ((VPScenarioLanguage)objTarget).VPScenarioLanguageID = 0;
//                        ((VPScenarioLanguage)objTarget).LastUpdateContactTVItemID = 2;
//                        dbTestDB.VPScenarioLanguages.Add((VPScenarioLanguage)objTarget);
//                    }
//                    break;
//                default:
//                    {
//                        Console.WriteLine($"Type [{ TypeName }] not implemented");
//                        return await Task.FromResult(false);
//                    }
//            }

//            try
//            {
//                dbTestDB.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                Console.WriteLine($"{ ex.Message }{ InnerException }");
//                return await Task.FromResult(false);
//            }

//            return await Task.FromResult(true);
//        }
//    }
//}
