import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebAllAddresses } from 'src/app/models/generated/web/WebAllAddresses.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MapService } from '../map/map.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebAllContacts } from 'src/app/models/generated/web/WebAllContacts.model';
import { WebAllTideLocations } from 'src/app/models/generated/web/WebAllTideLocations.model';
import { WebAllTels } from 'src/app/models/generated/web/WebAllTels.model';
import { WebAllReportTypes } from 'src/app/models/generated/web/WebAllReportTypes.model';
import { WebAllProvinces } from 'src/app/models/generated/web/WebAllProvinces.model';
import { WebAllPolSourceSiteEffectTerms } from 'src/app/models/generated/web/WebAllPolSourceSiteEffectTerms.model';
import { WebAllPolSourceGroupings } from 'src/app/models/generated/web/WebAllPolSourceGroupings.model';
import { WebAllMWQMLookupMPNs } from 'src/app/models/generated/web/WebAllMWQMLookupMPNs.model';
import { WebAllMunicipalities } from 'src/app/models/generated/web/WebAllMunicipalities.model';
import { WebAllHelpDocs } from 'src/app/models/generated/web/WebAllHelpDocs.model';
import { WebAllEmails } from 'src/app/models/generated/web/WebAllEmails.model';
import { WebAllCountries } from 'src/app/models/generated/web/WebAllCountries.model';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { WebClimateSites } from 'src/app/models/generated/web/WebClimateSites.model';
import { WebHydrometricSites } from 'src/app/models/generated/web/WebHydrometricSites.model';
import { WebDrogueRuns } from 'src/app/models/generated/web/WebDrogueRuns.model';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { WebLabSheets } from 'src/app/models/generated/web/WebLabSheets.model';
import { WebMikeScenarios } from 'src/app/models/generated/web/WebMikeScenarios.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { WebMWQMRuns } from 'src/app/models/generated/web/WebMWQMRuns.model';
import { WebMWQMSites } from 'src/app/models/generated/web/WebMWQMSites.model';
import { WebPolSourceSites } from 'src/app/models/generated/web/WebPolSourceSites.model';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { WebAllSearch } from 'src/app/models/generated/web/WebAllSearch.model';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';
import { WebTideSites } from 'src/app/models/generated/web/WebTideSites.model';
import { WebMWQMSamples1980_2020 } from 'src/app/models/generated/web/WebMWQMSamples1980_2020.model';
import { WebMWQMSamples2021_2060 } from 'src/app/models/generated/web/WebMWQMSamples2021_2060.model';
import { HistoryService } from '../helpers/history.service';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { WebMWQMSamples } from 'src/app/models/generated/web/WebMWQMSamples.model';
import { SortTVItemListService } from '../helpers/sort-tvitem-list.service';
import { FilterService } from '../helpers/filter.service';
import { SortTVItemMunicipalityListService } from '../helpers/sort-tvitem-municipality-list.service';
import { StatService } from '../helpers/stat.service';
import { LoadListService } from '../helpers/loading-list.service';
import { WebMonitoringOtherStatsCountry } from 'src/app/models/generated/web/WebMonitoringOtherStatsCountry.model';
import { WebMonitoringRoutineStatsCountry } from 'src/app/models/generated/web/WebMonitoringRoutineStatsCountry.model';
import { WebMonitoringOtherStatsProvince } from 'src/app/models/generated/web/WebMonitoringOtherStatsProvince.model';
import { WebMonitoringRoutineStatsProvince } from 'src/app/models/generated/web/WebMonitoringRoutineStatsProvince.model';
import { MonitoringStatsModel } from 'src/app/models/generated/web/MonitoringStatsModel.model';


@Injectable({
    providedIn: 'root'
})
export class LoaderService {
    private WebType: WebTypeEnum;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private loadListService: LoadListService,
        private statService: StatService,
        private mapService: MapService,
        private historyService: HistoryService,
        private sortTVItemListService: SortTVItemListService,
        private sortTVItemMunicipalityListService: SortTVItemMunicipalityListService,
        private filterService: FilterService) {
    }

    LoadAll() {
        this.appStateService.ShowMonitoringStatsChartByYear = false;
        this.appStateService.ShowMonitoringStatsChartByMonth = false;
        this.appStateService.ShowMonitoringStatsChartBySeason = false;
        this.appStateService.ShowMonitoringStatsTableByYear = false;
        this.appStateService.ShowMonitoringStatsTableByMonth = false;
        this.appStateService.ShowMonitoringStatsTableBySeason = false;

        if (this.loadListService.ToLoadList != undefined && this.loadListService.ToLoadList?.length > 0) {
            this.WebType = this.loadListService.ToLoadList[0].WebType;
            this.ForceReload = this.loadListService.ToLoadList[0].ForceReload;

            switch (this.WebType) {
                case WebTypeEnum.WebAllAddresses: this.Load<WebAllAddresses>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebAllContacts: this.Load<WebAllContacts>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebAllCountries: this.Load<WebAllCountries>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebAllEmails: this.Load<WebAllEmails>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebAllHelpDocs: this.Load<WebAllHelpDocs>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebAllMunicipalities: this.Load<WebAllMunicipalities>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebAllMWQMLookupMPNs: this.Load<WebAllMWQMLookupMPNs>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebAllPolSourceGroupings: this.Load<WebAllPolSourceGroupings>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms: this.Load<WebAllPolSourceSiteEffectTerms>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebAllProvinces: this.Load<WebAllProvinces>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebAllReportTypes: this.Load<WebAllReportTypes>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebAllTels: this.Load<WebAllTels>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebAllTideLocations: this.Load<WebAllTideLocations>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebArea: this.Load<WebArea>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebClimateSites: this.Load<WebClimateSites>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebCountry: this.Load<WebCountry>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebDrogueRuns: this.Load<WebDrogueRuns>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebHydrometricSites: this.Load<WebHydrometricSites>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebLabSheets: this.Load<WebLabSheets>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebMikeScenarios: this.Load<WebMikeScenarios>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebMonitoringOtherStatsCountry: this.Load<WebMonitoringOtherStatsCountry>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebMonitoringRoutineStatsCountry: this.Load<WebMonitoringRoutineStatsCountry>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebMonitoringOtherStatsProvince: this.Load<WebMonitoringOtherStatsProvince>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebMonitoringRoutineStatsProvince: this.Load<WebMonitoringRoutineStatsProvince>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebMunicipality: this.Load<WebMunicipality>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebMWQMRuns: this.Load<WebMWQMRuns>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebMWQMSamples1980_2020: this.Load<WebMWQMSamples1980_2020>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebMWQMSamples2021_2060: this.Load<WebMWQMSamples2021_2060>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebMWQMSites: this.Load<WebMWQMSites>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebPolSourceSites: this.Load<WebPolSourceSites>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebProvince: this.Load<WebProvince>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebRoot: this.Load<WebRoot>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebAllSearch: this.Load<WebAllSearch>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebSector: this.Load<WebSector>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebSubsector: this.Load<WebSubsector>(this.WebType, this.ForceReload); break;
                case WebTypeEnum.WebTideSites: this.Load<WebTideSites>(this.WebType, this.ForceReload); break;
                default:
                    break;
            }

        }
    }

    Load<T>(webType: WebTypeEnum, ForceReload: boolean) {

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.DoLoad<T>().subscribe();
        }
        else {
            if (!this.DataIsLoaded(webType)) {
                this.sub = this.DoLoad<T>().subscribe();
            }
            else {
                this.DoUpdateBreadCrumbOnly();
                this.DoUpdateWebMap();
                if (this.loadListService.ToLoadList?.length > 1) {
                    this.loadListService.ToLoadList.shift();
                    this.LoadAll();
                }
            }
        }
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

    private DoLoad<T>() {
        let languageEnum = GetLanguageEnum();
        let objText: string = `${WebTypeEnum[this.WebType]}`;
        let TVItemIDText = '';

        switch (this.WebType) {
            case WebTypeEnum.WebAllAddresses:
                {
                    this.appLoadedService.WebAllAddresses = <WebAllAddresses>{};
                }
                break;
            case WebTypeEnum.WebAllContacts:
                {
                    this.appLoadedService.WebAllContacts = <WebAllContacts>{};
                }
                break;
            case WebTypeEnum.WebAllCountries:
                {
                    this.appLoadedService.WebAllCountries = <WebAllCountries>{};
                }
                break;
            case WebTypeEnum.WebAllEmails:
                {
                    this.appLoadedService.WebAllEmails = <WebAllEmails>{};
                }
                break;
            case WebTypeEnum.WebAllHelpDocs:
                {
                    this.appLoadedService.WebAllHelpDocs = <WebAllHelpDocs>{};
                }
                break;
            case WebTypeEnum.WebAllMunicipalities:
                {
                    this.appLoadedService.WebAllMunicipalities = <WebAllMunicipalities>{};
                }
                break;
            case WebTypeEnum.WebAllMWQMLookupMPNs:
                {
                    this.appLoadedService.WebAllMWQMLookupMPNs = <WebAllMWQMLookupMPNs>{};
                }
                break;
            case WebTypeEnum.WebAllPolSourceGroupings:
                {
                    this.appLoadedService.WebAllPolSourceGroupings = <WebAllPolSourceGroupings>{};
                }
                break;
            case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                {
                    this.appLoadedService.WebAllPolSourceSiteEffectTerms = <WebAllPolSourceSiteEffectTerms>{};
                }
                break;
            case WebTypeEnum.WebAllProvinces:
                {
                    this.appLoadedService.WebAllProvinces = <WebAllProvinces>{};
                }
                break;
            case WebTypeEnum.WebAllReportTypes:
                {
                    this.appLoadedService.WebAllReportTypes = <WebAllReportTypes>{};
                }
                break;
            case WebTypeEnum.WebAllTels:
                {
                    this.appLoadedService.WebAllTels = <WebAllTels>{};
                }
                break;
            case WebTypeEnum.WebAllTideLocations:
                {
                    this.appLoadedService.WebAllTideLocations = <WebAllTideLocations>{};
                }
                break;
            case WebTypeEnum.WebArea:
                {
                    this.appLoadedService.WebArea = <WebArea>{};
                    this.appLoadedService.MonitoringStatsModel = <MonitoringStatsModel>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentAreaTVItemID}`;
                }
                break;
            case WebTypeEnum.WebClimateSites:
                {
                    this.appLoadedService.WebClimateSites = <WebClimateSites>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentProvinceTVItemID}`;
                }
                break;
            case WebTypeEnum.WebCountry:
                {
                    this.appLoadedService.WebCountry = <WebCountry>{};
                    this.appLoadedService.MonitoringStatsModel = <MonitoringStatsModel>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentCountryTVItemID}`;
                }
                break;
            case WebTypeEnum.WebDrogueRuns:
                {
                    this.appLoadedService.WebDrogueRuns = <WebDrogueRuns>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentProvinceTVItemID}`;
                }
                break;
            case WebTypeEnum.WebHydrometricSites:
                {
                    this.appLoadedService.WebHydrometricSites = <WebHydrometricSites>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentProvinceTVItemID}`;
                }
                break;
            case WebTypeEnum.WebLabSheets:
                {
                    this.appLoadedService.WebLabSheets = <WebLabSheets>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSubsectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMikeScenarios:
                {
                    this.appLoadedService.WebMikeScenarios = <WebMikeScenarios>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentMunicipalityTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMonitoringOtherStatsCountry:
                {
                    this.appLoadedService.WebMonitoringOtherStatsCountry = <WebMonitoringOtherStatsCountry>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentCountryTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMonitoringRoutineStatsCountry:
                {
                    this.appLoadedService.WebMonitoringRoutineStatsCountry = <WebMonitoringRoutineStatsCountry>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentCountryTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMonitoringOtherStatsProvince:
                {
                    this.appLoadedService.WebMonitoringOtherStatsProvince = <WebMonitoringOtherStatsProvince>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentProvinceTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMonitoringRoutineStatsProvince:
                {
                    this.appLoadedService.WebMonitoringRoutineStatsProvince = <WebMonitoringRoutineStatsProvince>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentProvinceTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMunicipality:
                {
                    this.appLoadedService.WebMunicipality = <WebMunicipality>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentMunicipalityTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMWQMRuns:
                {
                    this.appLoadedService.WebMWQMRuns = <WebMWQMRuns>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSubsectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMWQMSamples1980_2020:
                {
                    this.appLoadedService.WebMWQMSamples1980_2020 = <WebMWQMSamples1980_2020>{};
                    this.appLoadedService.WebMWQMSamples = <WebMWQMSamples>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSubsectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMWQMSamples2021_2060:
                {
                    this.appLoadedService.WebMWQMSamples2021_2060 = <WebMWQMSamples2021_2060>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSubsectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMWQMSites:
                {
                    this.appLoadedService.WebMWQMSites = <WebMWQMSites>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSubsectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebPolSourceSites:
                {
                    this.appLoadedService.WebPolSourceSites = <WebPolSourceSites>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSubsectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebProvince:
                {
                    this.appLoadedService.WebProvince = <WebProvince>{};
                    this.appLoadedService.MonitoringStatsModel = <MonitoringStatsModel>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentProvinceTVItemID}`;
                }
                break;
            case WebTypeEnum.WebRoot:
                {
                    this.appLoadedService.WebRoot = <WebRoot>{};
                }
                break;
            case WebTypeEnum.WebAllSearch:
                {
                    this.appLoadedService.WebAllSearch = <WebAllSearch>{};
                }
                break;
            case WebTypeEnum.WebSector:
                {
                    this.appLoadedService.WebSector = <WebSector>{};
                    this.appLoadedService.MonitoringStatsModel = <MonitoringStatsModel>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    this.appLoadedService.WebSubsector = <WebSubsector>{};
                    this.appLoadedService.MonitoringStatsModel = <MonitoringStatsModel>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSubsectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebTideSites:
                {
                    this.appLoadedService.WebTideSites = <WebTideSites>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentProvinceTVItemID}`;
                }
                break;
            default:
                break;
        }

        let ForceReloadText = this.ForceReload ? ` - ${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - ${objText}${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/${objText}${TVItemIDText}`;

        return this.httpClient.get<T>(url).pipe(map((x: T) => { this.DoUpdate(x); }), catchError(e => of(e).pipe(map(e => { this.DoError(e); }))));
    }

    private DoUpdateBreadCrumbOnly() {
        switch (this.WebType) {
            case WebTypeEnum.WebArea: 
            {
                this.appLoadedService.BreadCrumbTVItemModelList = this.appLoadedService.WebArea.TVItemModelParentList; 
                this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsProvince?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentAreaTVItemID)[0];
            }
            break;
            case WebTypeEnum.WebCountry: 
            {
                this.appLoadedService.BreadCrumbTVItemModelList = this.appLoadedService.WebCountry.TVItemModelParentList; 
                this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsCountry?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentCountryTVItemID)[0];
            }
            break;
            case WebTypeEnum.WebMunicipality: 
            {
                this.appLoadedService.BreadCrumbTVItemModelList = this.appLoadedService.WebMunicipality.TVItemModelParentList; 
                this.appLoadedService.MonitoringStatsModel = <MonitoringStatsModel>{};
            }
            break;
            case WebTypeEnum.WebProvince: 
            {
                this.appLoadedService.BreadCrumbTVItemModelList = this.appLoadedService.WebProvince.TVItemModelParentList; 
                this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsProvince?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentProvinceTVItemID)[0];
            }
            break;
            case WebTypeEnum.WebRoot: {
                this.appLoadedService.BreadCrumbTVItemModelList = this.appLoadedService.WebRoot.TVItemModelParentList; 
                this.appLoadedService.MonitoringStatsModel = <MonitoringStatsModel>{};
            }
            break;
            case WebTypeEnum.WebSector: 
            {
                this.appLoadedService.BreadCrumbTVItemModelList = this.appLoadedService.WebSector.TVItemModelParentList; 
                this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsProvince?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentSectorTVItemID)[0];
            }
            break;
            case WebTypeEnum.WebSubsector: 
            {
                this.appLoadedService.BreadCrumbTVItemModelList = this.appLoadedService.WebSubsector.TVItemModelParentList; 
                this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsProvince?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentSubsectorTVItemID)[0];
            }
            break;
            default:
                break;
        }
    }

    private DoUpdate(x: any) {
        switch (this.WebType) {
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
            case WebTypeEnum.WebAllMWQMLookupMPNs:
                {
                    this.appLoadedService.WebAllMWQMLookupMPNs = x;
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
            case WebTypeEnum.WebArea:
                {
                    this.appLoadedService.WebArea = x;
                    this.DoUpdateBreadCrumbOnly();

                    this.historyService.AddHistory(this.appLoadedService.WebArea?.TVItemModel);

                    this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsProvince?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentAreaTVItemID)[0];

                    if (this.appStateService.GoogleJSLoaded) {
                        this.DoUpdateWebAreaMap();
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
                    this.DoUpdateBreadCrumbOnly();

                    this.historyService.AddHistory(this.appLoadedService.WebCountry?.TVItemModel);

                    this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsCountry?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentCountryTVItemID)[0];

                    if (this.appStateService.GoogleJSLoaded) {
                        this.DoUpdateWebCountryMap();
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
                    this.DoUpdateBreadCrumbOnly();

                    this.historyService.AddHistory(this.appLoadedService.WebMunicipality?.TVItemModel);

                    if (this.appStateService.GoogleJSLoaded) {
                        this.DoUpdateWebMunicipalityMap();
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
                    this.appLoadedService.WebMWQMSamples = x;
                }
                break;
            case WebTypeEnum.WebMWQMSamples2021_2060:
                {
                    this.appLoadedService.WebMWQMSamples2021_2060 = x;
                    this.appLoadedService.WebMWQMSamples.MWQMSampleModelList.concat(x.MWQMSampleModelList);
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
                    this.DoUpdateBreadCrumbOnly();

                    this.historyService.AddHistory(this.appLoadedService.WebProvince?.TVItemModel);

                    this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsProvince?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentProvinceTVItemID)[0];

                    if (this.appStateService.GoogleJSLoaded) {
                        this.DoUpdateWebProvinceMap();
                    }
                }
                break;
            case WebTypeEnum.WebRoot:
                {
                    this.appLoadedService.WebRoot = x;
                    this.DoUpdateBreadCrumbOnly();

                    this.historyService.AddHistory(this.appLoadedService.WebRoot?.TVItemModel);

                    if (this.appStateService.GoogleJSLoaded) {
                        this.DoUpdateWebRootMap();
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
                    this.DoUpdateBreadCrumbOnly();

                    this.historyService.AddHistory(this.appLoadedService.WebSector?.TVItemModel);

                    if (this.appStateService.GoogleJSLoaded) {
                        this.DoUpdateWebSectorMap();
                    }
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    this.appLoadedService.WebSubsector = x;
                    this.DoUpdateBreadCrumbOnly();

                    this.historyService.AddHistory(this.appLoadedService.WebSubsector?.TVItemModel);

                    this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsProvince?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentSubsectorTVItemID)[0];

                    this.statService.FillStatMWQMRunList();

                    this.statService.FillStatMWQMSiteList();

                    if (this.appStateService.GoogleJSLoaded) {
                        this.DoUpdateWebSubsectorMap();
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
        this.appStateService.Status = '';
        this.appStateService.Working = false;
        console.debug(x);
        if (this.loadListService.ToLoadList?.length > 1) {
            this.loadListService.ToLoadList.shift();
            this.LoadAll();
        }
    }

    DoUpdateWebMap() {
        switch (this.WebType) {
            case WebTypeEnum.WebArea: this.DoUpdateWebAreaMap(); break;
            case WebTypeEnum.WebCountry: this.DoUpdateWebCountryMap(); break;
            case WebTypeEnum.WebMunicipality: this.DoUpdateWebMunicipalityMap(); break;
            case WebTypeEnum.WebProvince: this.DoUpdateWebProvinceMap(); break;
            case WebTypeEnum.WebRoot: this.DoUpdateWebRootMap(); break;
            case WebTypeEnum.WebSector: this.DoUpdateWebSectorMap(); break;
            case WebTypeEnum.WebSubsector: this.DoUpdateWebSubsectorMap(); break;
            default: break;
        }
    }

    private DoUpdateWebAreaMap() {
        this.mapService.ClearMap();
        if (this.appStateService.UserPreference.AreaSubComponent == AreaSubComponentEnum.Sectors) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebArea?.TVItemModelSectorList)),
                ...[this.appLoadedService.WebArea?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.AreaSubComponent == AreaSubComponentEnum.Files) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebArea?.TVItemModelSectorList)),
                ...[this.appLoadedService.WebArea?.TVItemModel]
            ]);
        }
    }

    private DoUpdateWebCountryMap() {
        this.mapService.ClearMap();
        if (this.appStateService.UserPreference.CountrySubComponent == CountrySubComponentEnum.Provinces) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebCountry?.TVItemModelProvinceList)),
                ...[this.appLoadedService.WebCountry?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.CountrySubComponent == CountrySubComponentEnum.Files) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebCountry?.TVItemModelProvinceList)),
                ...[this.appLoadedService.WebCountry?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.CountrySubComponent == CountrySubComponentEnum.OpenDataNational) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebCountry?.TVItemModelProvinceList)),
                ...[this.appLoadedService.WebCountry?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.CountrySubComponent == CountrySubComponentEnum.EmailDistributionList) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebCountry?.TVItemModelProvinceList)),
                ...[this.appLoadedService.WebCountry?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.CountrySubComponent == CountrySubComponentEnum.RainExceedance) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebCountry?.TVItemModelProvinceList)),
                ...[this.appLoadedService.WebCountry?.TVItemModel]
            ]);
        }
    }

    private DoUpdateWebMunicipalityMap() {
        this.mapService.ClearMap();
        if (this.appStateService.UserPreference.MunicipalitySubComponent == MunicipalitySubComponentEnum.Infrastructures) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebMunicipality?.TVItemModelInfrastructureList)),
                ...[this.appLoadedService.WebMunicipality?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.MunicipalitySubComponent == MunicipalitySubComponentEnum.Contacts) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebMunicipality?.TVItemModelInfrastructureList)),
                ...[this.appLoadedService.WebMunicipality?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.MunicipalitySubComponent == MunicipalitySubComponentEnum.MIKEScenarios) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebMunicipality?.TVItemModelInfrastructureList)),
                ...[this.appLoadedService.WebMunicipality?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.MunicipalitySubComponent == MunicipalitySubComponentEnum.Files) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebMunicipality?.TVItemModelInfrastructureList)),
                ...[this.appLoadedService.WebMunicipality?.TVItemModel]
            ]);
        }
    }

    private DoUpdateWebProvinceMap() {
        this.mapService.ClearMap();
        if (this.appStateService.UserPreference.ProvinceSubComponent == ProvinceSubComponentEnum.Areas) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebProvince?.TVItemModelAreaList)),
                ...[this.appLoadedService.WebProvince?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.ProvinceSubComponent == ProvinceSubComponentEnum.Municipalities) {
            this.mapService.DrawObjects([
                ...(this.sortTVItemMunicipalityListService.SortTVItemMunicipalityList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebProvince?.TVItemModelMunicipalityList)).TVItemModeWithInfrastructurelList),
                ...[this.appLoadedService.WebProvince?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.ProvinceSubComponent == ProvinceSubComponentEnum.Files) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebProvince?.TVItemModelAreaList)),
                ...[this.appLoadedService.WebProvince?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.ProvinceSubComponent == ProvinceSubComponentEnum.OpenData) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebProvince?.TVItemModelAreaList)),
                ...[this.appLoadedService.WebProvince?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.ProvinceSubComponent == ProvinceSubComponentEnum.SamplingPlan) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebProvince?.TVItemModelAreaList)),
                ...[this.appLoadedService.WebProvince?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.ProvinceSubComponent == ProvinceSubComponentEnum.ProvinceTools) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebProvince?.TVItemModelAreaList)),
                ...[this.appLoadedService.WebProvince?.TVItemModel]
            ]);
        }
    }

    private DoUpdateWebRootMap() {
        this.mapService.ClearMap();
        if (this.appStateService.UserPreference.RootSubComponent == RootSubComponentEnum.Countries) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebRoot?.TVItemModelCountryList)),
                ...[this.appLoadedService.WebRoot?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.RootSubComponent == RootSubComponentEnum.Files) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebRoot?.TVItemModelCountryList)),
                ...[this.appLoadedService.WebRoot?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.RootSubComponent == RootSubComponentEnum.ExportArcGIS) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebRoot?.TVItemModelCountryList)),
                ...[this.appLoadedService.WebRoot?.TVItemModel]
            ]);
        }
    }

    private DoUpdateWebSectorMap() {
        this.mapService.ClearMap();
        if (this.appStateService.UserPreference.SectorSubComponent == SectorSubComponentEnum.Subsectors) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSector?.TVItemModelSubsectorList)),
                ...[this.appLoadedService.WebSector?.TVItemModel]
            ]);
        }
    }

    private DoUpdateWebSubsectorMap() {
        this.mapService.ClearMap();
        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSubsector?.TVItemModelMWQMSiteList)),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.Analysis) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSubsector?.TVItemModelMWQMSiteList)),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMRuns) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSubsector?.TVItemModelMWQMRunList)),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.PollutionSourceSites) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSubsector?.TVItemModelPolSourceSiteList)),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.Files) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSubsector?.TVItemModelMWQMSiteList)),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.SubsectorTools) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSubsector?.TVItemModelMWQMSiteList)),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.LogBook) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSubsector?.TVItemModelMWQMSiteList)),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
            ]);
        }
    }

    private DoError(e: any) {
        this.appStateService.Status = ''
        this.appStateService.Working = false
        this.appStateService.Error = <HttpErrorResponse>e;
        console.debug(e);
    }
}