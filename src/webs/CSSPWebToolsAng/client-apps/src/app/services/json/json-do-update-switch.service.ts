import { Injectable } from '@angular/core';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { JsonDoUpdateBreadCrumbOnlyService, JsonDoUpdateWebMapService } from '.';
import { AppLoadedService } from '../app/app-loaded.service';
import { HistoryService } from '../helpers/history.service';
import { StatService } from '../helpers/stat.service';
import { InfrastructureService } from '../infrastructure/infrastructure.service';

@Injectable({
    providedIn: 'root'
})
export class JsonDoUpdateSwitchService {

    constructor(private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private statService: StatService,
        private historyService: HistoryService,
        private jsonDoUpdateBreadCrumbOnlyService: JsonDoUpdateBreadCrumbOnlyService,
        private jsonDoUpdateWebMapService: JsonDoUpdateWebMapService,
        private infrastructureService: InfrastructureService) {
    }


    DoUpdateSwitch(WebType: WebTypeEnum, x: any) {
        switch (WebType) {
            case WebTypeEnum.WebAllAddresses:
                {
                    this.appLoadedService.WebAllAddresses = x;
                }
                break;
            case WebTypeEnum.WebAllContacts:
                {
                    this.appLoadedService.WebAllContacts = x;
                    this.appLoadedService.AdminContactModel = this.appLoadedService.WebAllContacts.ContactModelList.filter((c) => c.Contact != null && c.Contact.IsAdmin == true);
                }
                break;
            case WebTypeEnum.WebAllCountries:
                {
                    this.appLoadedService.WebAllCountries = x;
                }
                break;
            case WebTypeEnum.WebAllEmails:
                {
                    this.appLoadedService.WebAllEmails = x;
                }
                break;
            case WebTypeEnum.WebAllHelpDocs:
                {
                    this.appLoadedService.WebAllHelpDocs = x;
                }
                break;
            case WebTypeEnum.WebAllMunicipalities:
                {
                    this.appLoadedService.WebAllMunicipalities = x;
                }
                break;
            case WebTypeEnum.WebAllMWQMAnalysisReportParameters:
                {
                    this.appLoadedService.WebAllMWQMAnalysisReportParameters = x;
                }
                break;
            case WebTypeEnum.WebAllMWQMLookupMPNs:
                {
                    this.appLoadedService.WebAllMWQMLookupMPNs = x;
                }
                break;
            case WebTypeEnum.WebAllMWQMSubsectors:
                {
                    this.appLoadedService.WebAllMWQMSubsectors = x;
                }
                break;
            case WebTypeEnum.WebAllPolSourceGroupings:
                {
                    this.appLoadedService.WebAllPolSourceGroupings = x;
                }
                break;
            case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                {
                    this.appLoadedService.WebAllPolSourceSiteEffectTerms = x;
                }
                break;
            case WebTypeEnum.WebAllProvinces:
                {
                    this.appLoadedService.WebAllProvinces = x;
                }
                break;
            case WebTypeEnum.WebAllReportTypes:
                {
                    this.appLoadedService.WebAllReportTypes = x;
                }
                break;
            case WebTypeEnum.WebAllTels:
                {
                    this.appLoadedService.WebAllTels = x;
                }
                break;
            case WebTypeEnum.WebAllTideLocations:
                {
                    this.appLoadedService.WebAllTideLocations = x;
                }
                break;
            case WebTypeEnum.WebAllUseOfSites:
                {
                    this.appLoadedService.WebAllUseOfSites = x;
                }
                break;
            case WebTypeEnum.WebArea:
                {
                    this.appLoadedService.WebArea = x;
                    this.jsonDoUpdateBreadCrumbOnlyService.DoUpdateBreadCrumbOnly(WebType);

                    this.historyService.AddHistory(this.appLoadedService.WebArea?.TVItemModel);

                    this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsProvince?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentAreaTVItemID)[0];

                    if (this.appStateService.GoogleJSLoaded) {
                        this.jsonDoUpdateWebMapService.DoUpdateWebMap(WebType);
                    }


                }
                break;
            case WebTypeEnum.WebClimateSites:
                {
                    this.appLoadedService.WebClimateSites = x;
                }
                break;
            case WebTypeEnum.WebCountry:
                {
                    this.appLoadedService.WebCountry = x;
                    this.jsonDoUpdateBreadCrumbOnlyService.DoUpdateBreadCrumbOnly(WebType);

                    this.historyService.AddHistory(this.appLoadedService.WebCountry?.TVItemModel);

                    this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsCountry?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentCountryTVItemID)[0];

                    if (this.appStateService.GoogleJSLoaded) {
                        this.jsonDoUpdateWebMapService.DoUpdateWebMap(WebType);
                    }

                }
                break;
            case WebTypeEnum.WebDrogueRuns:
                {
                    this.appLoadedService.WebDrogueRuns = x;
                }
                break;
            case WebTypeEnum.WebHydrometricSites:
                {
                    this.appLoadedService.WebHydrometricSites = x;
                }
                break;
            case WebTypeEnum.WebLabSheets:
                {
                    this.appLoadedService.WebLabSheets = x;
                }
                break;
            case WebTypeEnum.WebMikeScenarios:
                {
                    this.appLoadedService.WebMikeScenarios = x;
                }
                break;
            case WebTypeEnum.WebMonitoringOtherStatsCountry:
                {
                    this.appLoadedService.WebMonitoringOtherStatsCountry = x;
                }
                break;
            case WebTypeEnum.WebMonitoringRoutineStatsCountry:
                {
                    this.appLoadedService.WebMonitoringRoutineStatsCountry = x;
                }
                break;
            case WebTypeEnum.WebMonitoringOtherStatsProvince:
                {
                    this.appLoadedService.WebMonitoringOtherStatsProvince = x;
                }
                break;
            case WebTypeEnum.WebMonitoringRoutineStatsProvince:
                {
                    this.appLoadedService.WebMonitoringRoutineStatsProvince = x;
                }
                break;
            case WebTypeEnum.WebMunicipality:
                {
                    this.appLoadedService.WebMunicipality = x;
                    this.appLoadedService.InfrastructureModelPathList = this.infrastructureService.GetInfrastructureModelPathList();

                    this.jsonDoUpdateBreadCrumbOnlyService.DoUpdateBreadCrumbOnly(WebType);

                    this.historyService.AddHistory(this.appLoadedService.WebMunicipality?.TVItemModel);

                    if (this.appStateService.GoogleJSLoaded) {
                        this.jsonDoUpdateWebMapService.DoUpdateWebMap(WebType);
                    }
                }
                break;
            case WebTypeEnum.WebMWQMRuns:
                {
                    this.appLoadedService.WebMWQMRuns = x;
                }
                break;
            case WebTypeEnum.WebMWQMSamples1980_2020:
                {
                    this.appLoadedService.WebMWQMSamples1980_2020 = x;
                }
                break;
            case WebTypeEnum.WebMWQMSamples2021_2060:
                {
                    this.appLoadedService.WebMWQMSamples2021_2060 = x;
                    this.appLoadedService.WebMWQMSamples1980_2020.MWQMSampleModelList.push(...x.MWQMSampleModelList);
                }
                break;
            case WebTypeEnum.WebMWQMSites:
                {
                    this.appLoadedService.WebMWQMSites = x;
                }
                break;
            case WebTypeEnum.WebPolSourceSites:
                {
                    this.appLoadedService.WebPolSourceSites = x;
                }
                break;
            case WebTypeEnum.WebProvince:
                {
                    this.appLoadedService.WebProvince = x;
                    this.jsonDoUpdateBreadCrumbOnlyService.DoUpdateBreadCrumbOnly(WebType);

                    this.historyService.AddHistory(this.appLoadedService.WebProvince?.TVItemModel);

                    this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsProvince?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentProvinceTVItemID)[0];

                    if (this.appStateService.GoogleJSLoaded) {
                        this.jsonDoUpdateWebMapService.DoUpdateWebMap(WebType);
                    }
                }
                break;
            case WebTypeEnum.WebRoot:
                {
                    this.appLoadedService.WebRoot = x;
                    this.jsonDoUpdateBreadCrumbOnlyService.DoUpdateBreadCrumbOnly(WebType);

                    this.historyService.AddHistory(this.appLoadedService.WebRoot?.TVItemModel);

                    if (this.appStateService.GoogleJSLoaded) {
                        this.jsonDoUpdateWebMapService.DoUpdateWebMap(WebType);
                    }
                }
                break;
            case WebTypeEnum.WebAllSearch:
                {
                    this.appLoadedService.WebAllSearch = x;
                }
                break;
            case WebTypeEnum.WebSector:
                {
                    this.appLoadedService.WebSector = x;
                    this.jsonDoUpdateBreadCrumbOnlyService.DoUpdateBreadCrumbOnly(WebType);

                    this.historyService.AddHistory(this.appLoadedService.WebSector?.TVItemModel);

                    if (this.appStateService.GoogleJSLoaded) {
                        this.jsonDoUpdateWebMapService.DoUpdateWebMap(WebType);
                    }
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    this.appLoadedService.WebSubsector = x;
                    this.jsonDoUpdateBreadCrumbOnlyService.DoUpdateBreadCrumbOnly(WebType);

                    this.historyService.AddHistory(this.appLoadedService.WebSubsector?.TVItemModel);

                    this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsProvince?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentSubsectorTVItemID)[0];

                    this.statService.FillStatMWQMRunList();

                    this.statService.FillStatMWQMSiteList();

                    if (this.appStateService.GoogleJSLoaded) {
                        this.jsonDoUpdateWebMapService.DoUpdateWebMap(WebType);
                    }
                }
                break;
            case WebTypeEnum.WebTideSites:
                {
                    this.appLoadedService.WebTideSites = x;
                }
                break;
            default:
                break;
        }
    }
}