import { Injectable } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebArea } from 'src/app/models/generated/models/WebArea.model';
import { WebClimateSites } from 'src/app/models/generated/models/WebClimateSites.model';
import { WebHydrometricSites } from 'src/app/models/generated/models/WebHydrometricSites.model';
import { WebDrogueRuns } from 'src/app/models/generated/models/WebDrogueRuns.model';
import { WebCountry } from 'src/app/models/generated/models/WebCountry.model';
import { WebLabSheets } from 'src/app/models/generated/models/WebLabSheets.model';
import { WebMikeScenarios } from 'src/app/models/generated/models/WebMikeScenarios.model';
import { WebMunicipality } from 'src/app/models/generated/models/WebMunicipality.model';
import { WebMWQMRuns } from 'src/app/models/generated/models/WebMWQMRuns.model';
import { WebMWQMSites } from 'src/app/models/generated/models/WebMWQMSites.model';
import { WebPolSourceSites } from 'src/app/models/generated/models/WebPolSourceSites.model';
import { WebProvince } from 'src/app/models/generated/models/WebProvince.model';
import { WebSector } from 'src/app/models/generated/models/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/models/WebSubsector.model';
import { WebTideSites } from 'src/app/models/generated/models/WebTideSites.model';
import { WebMWQMSamples1980_2020 } from 'src/app/models/generated/models/WebMWQMSamples1980_2020.model';
import { WebMWQMSamples2021_2060 } from 'src/app/models/generated/models/WebMWQMSamples2021_2060.model';
import { WebMonitoringOtherStatsCountry } from 'src/app/models/generated/models/WebMonitoringOtherStatsCountry.model';
import { WebMonitoringRoutineStatsCountry } from 'src/app/models/generated/models/WebMonitoringRoutineStatsCountry.model';
import { WebMonitoringOtherStatsProvince } from 'src/app/models/generated/models/WebMonitoringOtherStatsProvince.model';
import { WebMonitoringRoutineStatsProvince } from 'src/app/models/generated/models/WebMonitoringRoutineStatsProvince.model';


@Injectable({
    providedIn: 'root'
})
export class JsonDataIsLoadedService {
    
    constructor(private appStateService: AppStateService,
        private appLoadedService: AppLoadedService) {
    }

    DataIsLoaded(webType: WebTypeEnum) {
        let obj: any;
        switch (webType) {
            case WebTypeEnum.WebAllAddresses:
                {
                    obj = this.appLoadedService.WebAllAddresses;
                    return (obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllContacts:
                {
                    obj = this.appLoadedService.WebAllContacts;
                    return (obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllCountries:
                {
                    obj = this.appLoadedService.WebAllCountries;
                    return (obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllEmails:
                {
                    obj = this.appLoadedService.WebAllEmails;
                    return (obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllHelpDocs:
                {
                    obj = this.appLoadedService.WebAllHelpDocs;
                    return (obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllMunicipalities:
                {
                    obj = this.appLoadedService.WebAllMunicipalities;
                    return (obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllMWQMLookupMPNs:
                {
                    obj = this.appLoadedService.WebAllMWQMLookupMPNs;
                    return (obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllPolSourceGroupings:
                {
                    obj = this.appLoadedService.WebAllPolSourceGroupings;
                    return (obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                {
                    obj = this.appLoadedService.WebAllPolSourceSiteEffectTerms;
                    return (obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllProvinces:
                {
                    obj = this.appLoadedService.WebAllProvinces;
                    return (obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllReportTypes:
                {
                    obj = this.appLoadedService.WebAllReportTypes;
                    return (obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllTels:
                {
                    obj = this.appLoadedService.WebAllTels;
                    return (obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllTideLocations:
                {
                    obj = this.appLoadedService.WebAllTideLocations;
                    return (obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebArea:
                {
                    obj = this.appLoadedService.WebArea;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentAreaTVItemID == this.appLoadedService.WebArea.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebArea = <WebArea>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebClimateSites:
                {
                    obj = this.appLoadedService.WebClimateSites;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentProvinceTVItemID == this.appLoadedService.WebClimateSites.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebClimateSites = <WebClimateSites>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebCountry:
                {
                    obj = this.appLoadedService.WebCountry;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentCountryTVItemID == this.appLoadedService.WebCountry.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebCountry = <WebCountry>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebDrogueRuns:
                {
                    obj = this.appLoadedService.WebDrogueRuns;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentProvinceTVItemID == this.appLoadedService.WebDrogueRuns.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebDrogueRuns = <WebDrogueRuns>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebHydrometricSites:
                {
                    obj = this.appLoadedService.WebHydrometricSites;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentProvinceTVItemID == this.appLoadedService.WebHydrometricSites.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebHydrometricSites = <WebHydrometricSites>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebLabSheets:
                {
                    obj = this.appLoadedService.WebLabSheets;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentSubsectorTVItemID == this.appLoadedService.WebLabSheets.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebLabSheets = <WebLabSheets>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebMikeScenarios:
                {
                    obj = this.appLoadedService.WebMikeScenarios;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentMunicipalityTVItemID == this.appLoadedService.WebMikeScenarios.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebMikeScenarios = <WebMikeScenarios>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebMonitoringOtherStatsCountry:
                {
                    obj = this.appLoadedService.WebMonitoringOtherStatsCountry;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentCountryTVItemID == this.appLoadedService.WebCountry?.TVItemModel?.TVItem?.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebMonitoringOtherStatsCountry = <WebMonitoringOtherStatsCountry>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebMonitoringRoutineStatsCountry:
                {
                    obj = this.appLoadedService.WebMonitoringRoutineStatsCountry;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentCountryTVItemID == this.appLoadedService.WebCountry?.TVItemModel?.TVItem?.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebMonitoringRoutineStatsCountry = <WebMonitoringRoutineStatsCountry>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebMonitoringOtherStatsProvince:
                {
                    obj = this.appLoadedService.WebMonitoringOtherStatsProvince;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentProvinceTVItemID == this.appLoadedService.WebProvince?.TVItemModel?.TVItem?.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebMonitoringOtherStatsProvince = <WebMonitoringOtherStatsProvince>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebMonitoringRoutineStatsProvince:
                {
                    obj = this.appLoadedService.WebMonitoringRoutineStatsProvince;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentProvinceTVItemID == this.appLoadedService.WebProvince?.TVItemModel?.TVItem?.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebMonitoringRoutineStatsProvince = <WebMonitoringRoutineStatsProvince>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebMunicipality:
                {
                    obj = this.appLoadedService.WebMunicipality;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentMunicipalityTVItemID == this.appLoadedService.WebMunicipality.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebMunicipality = <WebMunicipality>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebMWQMRuns:
                {
                    obj = this.appLoadedService.WebMWQMRuns;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentSubsectorTVItemID == this.appLoadedService.WebMWQMRuns.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebMWQMRuns = <WebMWQMRuns>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebMWQMSamples1980_2020:
                {
                    obj = this.appLoadedService.WebMWQMSamples1980_2020;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentSubsectorTVItemID == this.appLoadedService.WebMWQMSamples1980_2020.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebMWQMSamples1980_2020 = <WebMWQMSamples1980_2020>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebMWQMSamples2021_2060:
                {
                    obj = this.appLoadedService.WebMWQMSamples2021_2060;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentSubsectorTVItemID == this.appLoadedService.WebMWQMSamples2021_2060.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebMWQMSamples2021_2060 = <WebMWQMSamples2021_2060>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebMWQMSites:
                {
                    obj = this.appLoadedService.WebMWQMSites;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentSubsectorTVItemID == this.appLoadedService.WebMWQMSites.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebMWQMSites = <WebMWQMSites>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebPolSourceSites:
                {
                    obj = this.appLoadedService.WebPolSourceSites;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentSubsectorTVItemID == this.appLoadedService.WebPolSourceSites.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebPolSourceSites = <WebPolSourceSites>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebProvince:
                {
                    obj = this.appLoadedService.WebProvince;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentProvinceTVItemID == this.appLoadedService.WebProvince.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebProvince = <WebProvince>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebRoot:
                {
                    obj = this.appLoadedService.WebRoot;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    return true;
                }
                break;
            case WebTypeEnum.WebAllSearch:
                {
                    obj = this.appLoadedService.WebAllSearch;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    return true;
                }
                break;
            case WebTypeEnum.WebSector:
                {
                    obj = this.appLoadedService.WebSector;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentSectorTVItemID == this.appLoadedService.WebSector.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebSector = <WebSector>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    obj = this.appLoadedService.WebSubsector;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentSubsectorTVItemID == this.appLoadedService.WebSubsector.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebSubsector = <WebSubsector>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebTideSites:
                {
                    obj = this.appLoadedService.WebTideSites;
                    if ((obj === undefined || (Object.keys(obj)?.length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentProvinceTVItemID == this.appLoadedService.WebTideSites.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebTideSites = <WebTideSites>{};
                    }

                    return IsSame;
                }
                break;
            default:
                break;
        }
    }
}