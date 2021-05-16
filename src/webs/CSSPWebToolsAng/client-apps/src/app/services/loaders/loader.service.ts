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
import { ColorAndLetter } from 'src/app/models/generated/web/ColorAndLetter.model';
import { StatMWQMSiteSample } from 'src/app/models/generated/web/StatMWQMSiteSample.model';
import { MWQMSiteModel } from 'src/app/models/generated/web/MWQMSiteModel.model';
import { StatMWQMRun } from 'src/app/models/generated/web/StatMWQMRun.model';
import { SampleTypeEnum } from 'src/app/enums/generated/SampleTypeEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { MWQMSampleModel } from 'src/app/models/generated/web/MWQMSampleModel.model';
import { AnalysisCalculationTypeEnum } from 'src/app/enums/generated/AnalysisCalculationTypeEnum';
import { MWQMRunModel } from 'src/app/models/generated/web/MWQMRunModel.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { SortMWQMSiteModelListService } from '../helpers/sort-mwqm-site-model-list.service';
import { SortMWQMRunListService } from '../helpers/sort-mwqm-run-list-desc.service';
import { SortMWQMSiteSampleModelListService } from '../helpers/sort-mwqm-site-sample-list.service';
import { WebMWQMSamples } from 'src/app/models/generated/web/WebMWQMSamples.model';
import { SortTVItemListService } from '../helpers/sort-tvitem-list.service';
import { FilterService } from '../helpers/filter.service';
import { MWQMSiteModelAndSampleModel } from 'src/app/models/generated/web/MWQMSiteModelAndSampleModel.model';
import { MWQMRunModelSiteAndSampleModel } from 'src/app/models/generated/web/MWQMRunModelSiteAndSampleModel.model';
import { SortTVItemMunicipalityListService } from '../helpers/sort-tvitem-municipality-list.service';


@Injectable({
    providedIn: 'root'
})
export class LoaderService {
    private webType: WebTypeEnum;
    private webTypeNext: WebTypeEnum;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private mapService: MapService,
        private historyService: HistoryService,
        private sortMWQMSiteModelListService: SortMWQMSiteModelListService,
        private sortMWQMRunListService: SortMWQMRunListService,
        private sortMWQMSiteSampleModelListService: SortMWQMSiteSampleModelListService,
        private sortTVItemListService: SortTVItemListService,
        private sortTVItemMunicipalityListService: SortTVItemMunicipalityListService,
        private filterService: FilterService) {
    }

    Load<T>(webType: WebTypeEnum, webTypeNext: WebTypeEnum = null, ForceReload: boolean = true) {
        this.webType = webType;
        this.webTypeNext = webTypeNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.DoLoad<T>().subscribe();
        }
        else {
            if (this.DataIsLoaded(webType)) {
                this.Keep();
            }
            else {
                this.sub = this.DoLoad<T>().subscribe();
            }
        }
    }

    DataIsLoaded(webType: WebTypeEnum) {
        let obj: any;
        switch (webType) {
            case WebTypeEnum.WebAllAddresses:
                {
                    obj = this.appLoadedService.WebAllAddresses;
                    return (obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllContacts:
                {
                    obj = this.appLoadedService.WebAllContacts;
                    return (obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllCountries:
                {
                    obj = this.appLoadedService.WebAllCountries;
                    return (obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllEmails:
                {
                    obj = this.appLoadedService.WebAllEmails;
                    return (obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllHelpDocs:
                {
                    obj = this.appLoadedService.WebAllHelpDocs;
                    return (obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllMunicipalities:
                {
                    obj = this.appLoadedService.WebAllMunicipalities;
                    return (obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllMWQMLookupMPNs:
                {
                    obj = this.appLoadedService.WebAllMWQMLookupMPNs;
                    return (obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllPolSourceGroupings:
                {
                    obj = this.appLoadedService.WebAllPolSourceGroupings;
                    return (obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                {
                    obj = this.appLoadedService.WebAllPolSourceSiteEffectTerms;
                    return (obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllProvinces:
                {
                    obj = this.appLoadedService.WebAllProvinces;
                    return (obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllReportTypes:
                {
                    obj = this.appLoadedService.WebAllReportTypes;
                    return (obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllTels:
                {
                    obj = this.appLoadedService.WebAllTels;
                    return (obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebAllTideLocations:
                {
                    obj = this.appLoadedService.WebAllTideLocations;
                    return (obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object)) ? false : true;
                }
            case WebTypeEnum.WebArea:
                {
                    obj = this.appLoadedService.WebArea;
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    let IsSame = this.appStateService.UserPreference.CurrentMunicipalityTVItemID == this.appLoadedService.WebMikeScenarios.TVItemModel.TVItem.TVItemID ? true : false;

                    if (!IsSame) {
                        this.appLoadedService.WebMikeScenarios = <WebMikeScenarios>{};
                    }

                    return IsSame;
                }
                break;
            case WebTypeEnum.WebMunicipality:
                {
                    obj = this.appLoadedService.WebMunicipality;
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    return true;
                }
                break;
            case WebTypeEnum.WebAllSearch:
                {
                    obj = this.appLoadedService.WebAllSearch;
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
                        return false;
                    }

                    return true;
                }
                break;
            case WebTypeEnum.WebSector:
                {
                    obj = this.appLoadedService.WebSector;
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
                    if ((obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object))) {
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
        let objText: string = `${WebTypeEnum[this.webType]}`;
        let nextObjText: string = `${this.webTypeNext != null ? WebTypeEnum[this.webTypeNext] : ''}`;
        let TVItemIDText = '';

        switch (this.webType) {
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
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    this.appLoadedService.WebSubsector = <WebSubsector>{};
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

        let NextText = this.webTypeNext != null ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - ${nextObjText}` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - ${objText} - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/${objText}${TVItemIDText}`;

        return this.httpClient.get<T>(url).pipe(map((x: T) => { this.DoUpdate(x); }), catchError(e => of(e).pipe(map(e => { this.DoError(e); }))));
    }

    private DoUpdate(x: any) {
        switch (this.webType) {
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
                    this.appLoadedService.BreadCrumbTVItemModelList = x.TVItemModelParentList;
                    this.appLoadedService.WebArea = x;

                    this.historyService.AddHistory(this.appLoadedService.WebArea?.TVItemModel);

                    if (this.appStateService.GoogleJSLoaded) {
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
                }
                break;
            case WebTypeEnum.WebClimateSites:
                {
                    this.appLoadedService.WebClimateSites = x;
                }
                break;
            case WebTypeEnum.WebCountry:
                {
                    this.appLoadedService.BreadCrumbTVItemModelList = x.TVItemModelParentList;
                    this.appLoadedService.WebCountry = x;

                    this.historyService.AddHistory(this.appLoadedService.WebCountry?.TVItemModel);

                    if (this.appStateService.GoogleJSLoaded) {
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
            case WebTypeEnum.WebMunicipality:
                {
                    this.appLoadedService.BreadCrumbTVItemModelList = x.TVItemModelParentList;
                    this.appLoadedService.WebMunicipality = x;

                    this.historyService.AddHistory(this.appLoadedService.WebMunicipality?.TVItemModel);

                    if (this.appStateService.GoogleJSLoaded) {
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
                    this.appLoadedService.BreadCrumbTVItemModelList = x.TVItemModelParentList;
                    this.appLoadedService.WebProvince = x;

                    this.historyService.AddHistory(this.appLoadedService.WebProvince?.TVItemModel);

                    if (this.appStateService.GoogleJSLoaded) {
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
                }
                break;
            case WebTypeEnum.WebRoot:
                {
                    this.appLoadedService.BreadCrumbTVItemModelList = x.TVItemModelParentList;
                    this.appLoadedService.WebRoot = x;

                    this.historyService.AddHistory(this.appLoadedService.WebRoot?.TVItemModel);

                    if (this.appStateService.GoogleJSLoaded) {
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
                }
                break;
            case WebTypeEnum.WebAllSearch:
                {
                    this.appLoadedService.WebAllSearch = x;
                }
                break;
            case WebTypeEnum.WebSector:
                {
                    this.appLoadedService.BreadCrumbTVItemModelList = x.TVItemModelParentList;
                    this.appLoadedService.WebSector = x;

                    this.historyService.AddHistory(this.appLoadedService.WebSector?.TVItemModel);
                    if (this.appStateService.GoogleJSLoaded) {
                        this.mapService.ClearMap();
                        if (this.appStateService.UserPreference.SectorSubComponent == SectorSubComponentEnum.Subsectors) {
                            this.mapService.DrawObjects([
                                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSector?.TVItemModelSubsectorList)),
                                ...[this.appLoadedService.WebSector?.TVItemModel]
                            ]);
                        }
                    }
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    this.appLoadedService.BreadCrumbTVItemModelList = x.TVItemModelParentList;
                    this.appLoadedService.WebSubsector = x;

                    this.historyService.AddHistory(this.appLoadedService.WebSubsector?.TVItemModel);

                    this.FillStatMWQMRunList();

                    this.FillStatMWQMSiteList();

                    if (this.appStateService.GoogleJSLoaded) {
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
        if (this.webTypeNext != null) {
            this.DoNext();
        }
    }

    private DoError(e: any) {
        this.appStateService.Status = ''
        this.appStateService.Working = false
        this.appStateService.Error = <HttpErrorResponse>e;
        console.debug(e);
    }

    private DoNext() {
        switch (this.webTypeNext) {
            case WebTypeEnum.WebAllAddresses:
                {
                    this.Load<WebAllAddresses>(this.webTypeNext, WebTypeEnum.WebAllContacts, false);
                }
                break;
            case WebTypeEnum.WebAllContacts:
                {
                    this.Load<WebAllContacts>(this.webTypeNext, WebTypeEnum.WebAllCountries, false);
                }
                break;
            case WebTypeEnum.WebAllCountries:
                {
                    this.Load<WebAllCountries>(this.webTypeNext, WebTypeEnum.WebAllEmails, false);
                }
                break;
            case WebTypeEnum.WebAllEmails:
                {
                    this.Load<WebAllEmails>(this.webTypeNext, WebTypeEnum.WebAllHelpDocs, false);
                }
                break;
            case WebTypeEnum.WebAllHelpDocs:
                {
                    this.Load<WebAllHelpDocs>(this.webTypeNext, WebTypeEnum.WebAllMunicipalities, false);
                }
                break;
            case WebTypeEnum.WebAllMunicipalities:
                {
                    this.Load<WebAllMunicipalities>(this.webTypeNext, WebTypeEnum.WebAllMWQMLookupMPNs, false);
                }
                break;
            case WebTypeEnum.WebAllMWQMLookupMPNs:
                {
                    this.Load<WebAllMWQMLookupMPNs>(this.webTypeNext, WebTypeEnum.WebAllPolSourceGroupings, false);
                }
                break;
            case WebTypeEnum.WebAllPolSourceGroupings:
                {
                    this.Load<WebAllPolSourceGroupings>(this.webTypeNext, WebTypeEnum.WebAllPolSourceSiteEffectTerms, false);
                }
                break;
            case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                {
                    this.Load<WebAllPolSourceSiteEffectTerms>(this.webTypeNext, WebTypeEnum.WebAllProvinces, false);
                }
                break;
            case WebTypeEnum.WebAllProvinces:
                {
                    this.Load<WebAllProvinces>(this.webTypeNext, WebTypeEnum.WebAllReportTypes, false);
                }
                break;
            case WebTypeEnum.WebAllReportTypes:
                {
                    this.Load<WebAllReportTypes>(this.webTypeNext, WebTypeEnum.WebAllTels, false);
                }
                break;
            case WebTypeEnum.WebAllTels:
                {
                    this.Load<WebAllTels>(this.webTypeNext, WebTypeEnum.WebAllTideLocations, false);
                }
                break;
            case WebTypeEnum.WebAllTideLocations:
                {
                    this.Load<WebAllTideLocations>(this.webTypeNext, WebTypeEnum.WebAllSearch, false);
                }
                break;
            case WebTypeEnum.WebArea:
                {
                    this.Load<WebArea>(this.webTypeNext, null, false);
                }
                break;
            case WebTypeEnum.WebClimateSites:
                {
                    this.Load<WebClimateSites>(this.webTypeNext, WebTypeEnum.WebHydrometricSites, false);
                }
                break;
            case WebTypeEnum.WebCountry:
                {
                    this.Load<WebCountry>(this.webTypeNext, null, false);
                }
                break;
            case WebTypeEnum.WebDrogueRuns:
                {
                    this.Load<WebDrogueRuns>(this.webTypeNext, WebTypeEnum.WebProvince, false);
                }
                break;
            case WebTypeEnum.WebHydrometricSites:
                {
                    this.Load<WebHydrometricSites>(this.webTypeNext, WebTypeEnum.WebTideSites, false);
                }
                break;
            case WebTypeEnum.WebLabSheets:
                {
                    this.Load<WebLabSheets>(this.webTypeNext, WebTypeEnum.WebMWQMSamples1980_2020, false);
                }
                break;
            case WebTypeEnum.WebMikeScenarios:
                {
                    this.Load<WebMikeScenarios>(this.webTypeNext, null, false);
                }
                break;
            case WebTypeEnum.WebMunicipality:
                {
                    this.Load<WebMunicipality>(this.webTypeNext, WebTypeEnum.WebMikeScenarios, false);
                }
                break;
            case WebTypeEnum.WebMWQMRuns:
                {
                    this.Load<WebMWQMRuns>(this.webTypeNext, WebTypeEnum.WebPolSourceSites, false);
                }
                break;
            case WebTypeEnum.WebMWQMSamples1980_2020:
                {
                    this.Load<WebMWQMSamples1980_2020>(this.webTypeNext, WebTypeEnum.WebMWQMSamples2021_2060, false);
                }
                break;
            case WebTypeEnum.WebMWQMSamples2021_2060:
                {
                    this.Load<WebMWQMSamples2021_2060>(this.webTypeNext, WebTypeEnum.WebSubsector, false);
                }
                break;
            case WebTypeEnum.WebMWQMSites:
                {
                    this.Load<WebMWQMSites>(this.webTypeNext, WebTypeEnum.WebMWQMRuns, false);
                }
                break;
            case WebTypeEnum.WebPolSourceSites:
                {
                    this.Load<WebPolSourceSites>(this.webTypeNext, WebTypeEnum.WebLabSheets, false);
                }
                break;
            case WebTypeEnum.WebProvince:
                {
                    this.Load<WebProvince>(this.webTypeNext, null, false);
                }
                break;
            case WebTypeEnum.WebRoot:
                {
                    this.Load<WebRoot>(this.webTypeNext, null, false);
                }
                break;
            case WebTypeEnum.WebAllSearch:
                {
                    this.Load<WebAllSearch>(this.webTypeNext, null, false);
                }
                break;
            case WebTypeEnum.WebSector:
                {
                    this.Load<WebSector>(this.webTypeNext, null, false);
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    this.Load<WebSubsector>(this.webTypeNext, null, false);
                }
                break;
            case WebTypeEnum.WebTideSites:
                {
                    this.Load<WebTideSites>(this.webTypeNext, WebTypeEnum.WebDrogueRuns, false);
                }
                break;
            default:
                break;
        }
    }

    private Keep() {
        switch (this.webType) {
            case WebTypeEnum.WebAllAddresses:
                {
                    this.DoUpdate(this.appLoadedService.WebAllAddresses);
                }
                break;
            case WebTypeEnum.WebAllContacts:
                {
                    this.DoUpdate(this.appLoadedService.WebAllContacts);
                }
                break;
            case WebTypeEnum.WebAllCountries:
                {
                    this.DoUpdate(this.appLoadedService.WebAllCountries);
                }
                break;
            case WebTypeEnum.WebAllEmails:
                {
                    this.DoUpdate(this.appLoadedService.WebAllEmails);
                }
                break;
            case WebTypeEnum.WebAllHelpDocs:
                {
                    this.DoUpdate(this.appLoadedService.WebAllHelpDocs);
                }
                break;
            case WebTypeEnum.WebAllMunicipalities:
                {
                    this.DoUpdate(this.appLoadedService.WebAllMunicipalities);
                }
                break;
            case WebTypeEnum.WebAllMWQMLookupMPNs:
                {
                    this.DoUpdate(this.appLoadedService.WebAllMWQMLookupMPNs);
                }
                break;
            case WebTypeEnum.WebAllPolSourceGroupings:
                {
                    this.DoUpdate(this.appLoadedService.WebAllPolSourceGroupings);
                }
                break;
            case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                {
                    this.DoUpdate(this.appLoadedService.WebAllPolSourceSiteEffectTerms);
                }
                break;
            case WebTypeEnum.WebAllProvinces:
                {
                    this.DoUpdate(this.appLoadedService.WebAllProvinces);
                }
                break;
            case WebTypeEnum.WebAllReportTypes:
                {
                    this.DoUpdate(this.appLoadedService.WebAllReportTypes);
                }
                break;
            case WebTypeEnum.WebAllTels:
                {
                    this.DoUpdate(this.appLoadedService.WebAllTels);
                }
                break;
            case WebTypeEnum.WebAllTideLocations:
                {
                    this.DoUpdate(this.appLoadedService.WebAllTideLocations);
                }
                break;
            case WebTypeEnum.WebArea:
                {
                    this.DoUpdate(this.appLoadedService.WebArea);
                }
                break;
            case WebTypeEnum.WebClimateSites:
                {
                    this.DoUpdate(this.appLoadedService.WebClimateSites);
                }
                break;
            case WebTypeEnum.WebCountry:
                {
                    this.DoUpdate(this.appLoadedService.WebCountry);
                }
                break;
            case WebTypeEnum.WebDrogueRuns:
                {
                    this.DoUpdate(this.appLoadedService.WebDrogueRuns);
                }
                break;
            case WebTypeEnum.WebHydrometricSites:
                {
                    this.DoUpdate(this.appLoadedService.WebHydrometricSites);
                }
                break;
            case WebTypeEnum.WebLabSheets:
                {
                    this.DoUpdate(this.appLoadedService.WebLabSheets);
                }
                break;
            case WebTypeEnum.WebMikeScenarios:
                {
                    this.DoUpdate(this.appLoadedService.WebMikeScenarios);
                }
                break;
            case WebTypeEnum.WebMunicipality:
                {
                    this.DoUpdate(this.appLoadedService.WebMunicipality);
                }
                break;
            case WebTypeEnum.WebMWQMRuns:
                {
                    this.DoUpdate(this.appLoadedService.WebMWQMRuns);
                }
                break;
            case WebTypeEnum.WebMWQMSamples1980_2020:
                {
                    this.DoUpdate(this.appLoadedService.WebMWQMSamples1980_2020);
                }
                break;
            case WebTypeEnum.WebMWQMSamples2021_2060:
                {
                    this.DoUpdate(this.appLoadedService.WebMWQMSamples2021_2060);
                }
                break;
            case WebTypeEnum.WebMWQMSites:
                {
                    this.DoUpdate(this.appLoadedService.WebMWQMSites);
                }
                break;
            case WebTypeEnum.WebPolSourceSites:
                {
                    this.DoUpdate(this.appLoadedService.WebPolSourceSites);
                }
                break;
            case WebTypeEnum.WebProvince:
                {
                    this.DoUpdate(this.appLoadedService.WebProvince);
                }
                break;
            case WebTypeEnum.WebRoot:
                {
                    this.DoUpdate(this.appLoadedService.WebRoot);
                }
                break;
            case WebTypeEnum.WebAllSearch:
                {
                    this.DoUpdate(this.appLoadedService.WebAllSearch);
                }
                break;
            case WebTypeEnum.WebSector:
                {
                    this.DoUpdate(this.appLoadedService.WebSector);
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    this.DoUpdate(this.appLoadedService.WebSubsector);
                }
                break;
            case WebTypeEnum.WebTideSites:
                {
                    this.DoUpdate(this.appLoadedService.WebTideSites);
                }
                break;
            default:
                break;
        }
    }

    FillStatMWQMSiteList() {
        let StatMWQMRunList: StatMWQMRun[] = this.appLoadedService.StatMWQMRunList;

        if (StatMWQMRunList == undefined || StatMWQMRunList.length == 0) {
            return;
        }

        let countR: number = StatMWQMRunList.length;
        for (let r = 0; r < countR; r++) {
            StatMWQMRunList[r].UseInStat = false;
        }

        let StatMWQMSiteList: StatMWQMSite[] = [];
        let MWQMSiteModelActiveList: MWQMSiteModel[] = this.sortMWQMSiteModelListService.SortMWQMSiteModelListByTVTextAsc(this.appLoadedService.WebMWQMSites.MWQMSiteModelList.filter(c => c.TVItemModel.TVItem.IsActive == true));
        let MWQMSiteModelInactiveList: MWQMSiteModel[] = this.sortMWQMSiteModelListService.SortMWQMSiteModelListByTVTextAsc(this.appLoadedService.WebMWQMSites.MWQMSiteModelList.filter(c => c.TVItemModel.TVItem.IsActive == false));
        let countSite: number = MWQMSiteModelActiveList.length;
        for (let i = 0; i < countSite; i++) {
            let MWQMSiteModelList: MWQMSiteModel[] = this.appLoadedService.WebMWQMSites.MWQMSiteModelList.filter(c => c.MWQMSite.MWQMSiteTVItemID == MWQMSiteModelActiveList[i].TVItemModel.TVItem.TVItemID);

            let StatMWQMSiteSampleList: StatMWQMSiteSample[] = [];
            if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites) {
                StatMWQMSiteSampleList = this.FillMWQMSiteSampleStatForMWQMSites(MWQMSiteModelActiveList[i].TVItemModel);
            }

            if (this.appStateService.UserPreference.TopComponent == TopComponentEnum.Home || this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.Analysis) {
                StatMWQMSiteSampleList = this.FillMWQMSiteSampleStatForAnalysis(MWQMSiteModelActiveList[i].TVItemModel);
            }

            StatMWQMSiteList.push(<StatMWQMSite>{ SalinityAverage: this.GetSalinityAverage(StatMWQMSiteSampleList), MWQMSiteModel: MWQMSiteModelList[0], StatMWQMSiteSampleList: StatMWQMSiteSampleList, TVItemModel: MWQMSiteModelActiveList[i].TVItemModel });
        }

        if (this.appStateService.UserPreference.InactVisible) {
            countSite = MWQMSiteModelInactiveList.length;
            for (let i = 0; i < countSite; i++) {
                let MWQMSiteModelList: MWQMSiteModel[] = this.appLoadedService.WebMWQMSites.MWQMSiteModelList.filter(c => c.MWQMSite.MWQMSiteTVItemID == MWQMSiteModelInactiveList[i].TVItemModel.TVItem.TVItemID);

                let StatMWQMSiteSampleList: StatMWQMSiteSample[] = [];
                if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites) {
                    StatMWQMSiteSampleList = this.FillMWQMSiteSampleStatForMWQMSites(MWQMSiteModelActiveList[i].TVItemModel);
                }

                if (this.appStateService.UserPreference.TopComponent == TopComponentEnum.Home || this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.Analysis) {
                    StatMWQMSiteSampleList = this.FillMWQMSiteSampleStatForAnalysis(MWQMSiteModelActiveList[i].TVItemModel);
                }

                StatMWQMSiteList.push(<StatMWQMSite>{ SalinityAverage: this.GetSalinityAverage(StatMWQMSiteSampleList), MWQMSiteModel: MWQMSiteModelList[0], StatMWQMSiteSampleList: StatMWQMSiteSampleList, TVItemModel: MWQMSiteModelInactiveList[i].TVItemModel });
            }
        }

        this.appLoadedService.StatMWQMSiteList = StatMWQMSiteList;

        if (this.appLoadedService.StatMWQMRunList?.length > 0) {
            if (this.appStateService.AnalysisStartRun == null) {
                this.appStateService.AnalysisStartRun = this.appLoadedService.StatMWQMRunList[0];
                this.appStateService.AnalysisEndRun = this.appLoadedService.StatMWQMRunList[this.appLoadedService.StatMWQMRunList.length - 1];
            }
        }

    }

    private GetSalinityAverage(statMWQMSiteSampleList: StatMWQMSiteSample[]): number {
        let SalinityAverage: number = null;
        if (statMWQMSiteSampleList != undefined && statMWQMSiteSampleList.length > 0) {
            let count: number = statMWQMSiteSampleList.length;
            let total: number = 0;
            let valCount: number = 0
            for (let i = 0; i < count; i++) {
                if (statMWQMSiteSampleList[i].Sal != null) {
                    valCount += 1;
                    total += statMWQMSiteSampleList[i].Sal;
                }
            }

            if (valCount > 0) {
                SalinityAverage = total / valCount;
            }
        }

        return SalinityAverage;
    }

    GetMWQMRunModelSiteAndSampleDetail(tvItemModel: TVItemModel): MWQMRunModelSiteAndSampleModel {
        let mwqmRunModelSiteAndSampleModel: MWQMRunModelSiteAndSampleModel = new MWQMRunModelSiteAndSampleModel();
        let mwqmSiteModelAndSampleModelList: MWQMSiteModelAndSampleModel[] = [];

        let mwqmRunModelList: MWQMRunModel[] = this.appLoadedService.WebMWQMRuns.MWQMRunModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);

        if (mwqmRunModelList !== undefined && mwqmRunModelList.length > 0) {
            mwqmRunModelSiteAndSampleModel.MWQMRunModel = mwqmRunModelList[0];

            let mwqmSampleModelList: MWQMSampleModel[] = this.appLoadedService.WebMWQMSamples.MWQMSampleModelList?.filter(c => c.MWQMSample.MWQMSiteTVItemID == tvItemModel.TVItem.TVItemID);

            let MWQMSiteModelActiveList: MWQMSiteModel[] = this.sortMWQMSiteModelListService.SortMWQMSiteModelListByTVTextAsc(this.appLoadedService.WebMWQMSites.MWQMSiteModelList.filter(c => c.TVItemModel.TVItem.IsActive == true));

            let count: number = MWQMSiteModelActiveList.length;
            for (let i = 0; i < count; i++) {
                let mwqmSampleModelTempList: MWQMSampleModel[] = mwqmSampleModelList.filter(c => c.MWQMSample.MWQMSiteTVItemID == MWQMSiteModelActiveList[i].TVItemModel.TVItem.TVItemID);
                if (mwqmSampleModelTempList !== undefined && mwqmSampleModelTempList.length > 0) {
                    mwqmSiteModelAndSampleModelList.push(<MWQMSiteModelAndSampleModel>{ MWQMSiteModel: MWQMSiteModelActiveList[i], MWQMSampleModel: mwqmSampleModelTempList[0] });
                }
            }

            let MWQMSiteModelInactiveList: MWQMSiteModel[] = this.sortMWQMSiteModelListService.SortMWQMSiteModelListByTVTextAsc(this.appLoadedService.WebMWQMSites.MWQMSiteModelList.filter(c => c.TVItemModel.TVItem.IsActive == false));

            count = MWQMSiteModelInactiveList.length;
            for (let i = 0; i < count; i++) {
                let mwqmSampleModelTempList: MWQMSampleModel[] = mwqmSampleModelList.filter(c => c.MWQMSample.MWQMSiteTVItemID == MWQMSiteModelInactiveList[i].TVItemModel.TVItem.TVItemID);
                if (mwqmSampleModelTempList !== undefined && mwqmSampleModelTempList.length > 0) {
                    mwqmSiteModelAndSampleModelList.push(<MWQMSiteModelAndSampleModel>{ MWQMSiteModel: MWQMSiteModelInactiveList[i], MWQMSampleModel: mwqmSampleModelTempList[0] });
                }
            }

            mwqmRunModelSiteAndSampleModel.MWQMSiteModelAndSampleModelList = mwqmSiteModelAndSampleModelList;
        }

        return mwqmRunModelSiteAndSampleModel;
    }

    GetMWQMSiteDetail(tvItemModel: TVItemModel): StatMWQMSite {
        let statMWQMSiteList: StatMWQMSite[] = this.appLoadedService.StatMWQMSiteList?.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);
        return statMWQMSiteList === undefined ? null : statMWQMSiteList[0];
    }

    GetMWQMSiteList(tvItemModel: TVItemModel): StatMWQMSite[] {
        let statMWQMSiteList: StatMWQMSite[] = this.appLoadedService.StatMWQMSiteList?.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);
        return statMWQMSiteList === undefined ? null : statMWQMSiteList;
    }

    private FillStatMWQMRunList() {
        let StatMWQMRunList: StatMWQMRun[] = [];

        let MWQMRunRoutineDescList: MWQMRunModel[] = this.sortMWQMRunListService.SortMWQMRunListDescByDate(this.appLoadedService.WebMWQMRuns.MWQMRunModelList);

        let countRun: number = MWQMRunRoutineDescList.length;
        for (let i = 0; i < countRun; i++) {
            let DateText: string = MWQMRunRoutineDescList[i].MWQMRun.DateTime_Local.toString();
            let Year: number = parseInt(DateText.substring(0, 4));
            let Month: number = parseInt(DateText.substring(5, 7));
            let Day: number = parseInt(DateText.substring(8, 10));

            let statMWQMRun: StatMWQMRun = <StatMWQMRun>{
                IsOKRun: true,
                MWQMRunTVItemID: MWQMRunRoutineDescList[i].MWQMRun.MWQMRunTVItemID,
                RainDay0: MWQMRunRoutineDescList[i].MWQMRun.RainDay0_mm,
                RainDay1: MWQMRunRoutineDescList[i].MWQMRun.RainDay1_mm,
                RainDay2: MWQMRunRoutineDescList[i].MWQMRun.RainDay2_mm,
                RainDay3: MWQMRunRoutineDescList[i].MWQMRun.RainDay3_mm,
                RainDay4: MWQMRunRoutineDescList[i].MWQMRun.RainDay4_mm,
                RainDay5: MWQMRunRoutineDescList[i].MWQMRun.RainDay5_mm,
                RainDay6: MWQMRunRoutineDescList[i].MWQMRun.RainDay6_mm,
                RainDay7: MWQMRunRoutineDescList[i].MWQMRun.RainDay7_mm,
                RainDay8: MWQMRunRoutineDescList[i].MWQMRun.RainDay8_mm,
                RainDay9: MWQMRunRoutineDescList[i].MWQMRun.RainDay9_mm,
                RainDay10: MWQMRunRoutineDescList[i].MWQMRun.RainDay10_mm,
                RemoveFromStat: false,
                RunDate: MWQMRunRoutineDescList[i].MWQMRun.DateTime_Local,
                RunIndex: i,
                RunYear: Year,
                RunMonth: Month,
                RunDay: Day,
                StartTide: MWQMRunRoutineDescList[i].MWQMRun.Tide_Start,
                EndTide: MWQMRunRoutineDescList[i].MWQMRun.Tide_End,
                UseInStat: true,
            };

            StatMWQMRunList.push(statMWQMRun);
        }

        this.appLoadedService.StatMWQMRunList = StatMWQMRunList;

        if (StatMWQMRunList.length > 0) {
            this.appStateService.AnalysisStartRun = StatMWQMRunList[0];
            this.appStateService.AnalysisEndRun = StatMWQMRunList[StatMWQMRunList.length - 1];
        }
    }

    private FillMWQMSiteSampleStatForAnalysis(tvItemModel: TVItemModel): StatMWQMSiteSample[] {
        let SampleTypeText: string = `${SampleTypeEnum.Routine},`;
        let StatMWQMSiteSampleList: StatMWQMSiteSample[] = [];
        let StatMWQMRunList: StatMWQMRun[] = this.appLoadedService.StatMWQMRunList;

        let StatRuns = this.appStateService.UserPreference.AnalysisRuns;

        let MWQMSiteModelList: MWQMSiteModel[] = this.appLoadedService.WebMWQMSites?.MWQMSiteModelList?.filter(
            c => c.MWQMSite.MWQMSiteTVItemID == tvItemModel.TVItem.TVItemID);

        if (MWQMSiteModelList && MWQMSiteModelList.length > 0) {
            let MWQMSiteSampleModelSortedList: MWQMSampleModel[] = this.sortMWQMSiteSampleModelListService.SortMWQMSiteSampleModelListDescByDate(
                this.appLoadedService.WebMWQMSamples?.MWQMSampleModelList.filter(c => c.MWQMSample.MWQMSiteTVItemID == tvItemModel.TVItem.TVItemID)
            );

            if (MWQMSiteSampleModelSortedList && MWQMSiteSampleModelSortedList.length > 0) {
                let EndYear = parseInt(MWQMSiteSampleModelSortedList[MWQMSiteSampleModelSortedList.length - 1].MWQMSample.SampleDateTime_Local.toString());
                let StartYear = parseInt(MWQMSiteSampleModelSortedList[0].MWQMSample.SampleDateTime_Local.toString());

                if (MWQMSiteSampleModelSortedList.length > 0) {

                    let SampleCount: number = 0;
                    let countRun: number = StatMWQMRunList.length;
                    let countSample: number = MWQMSiteSampleModelSortedList.length;
                    let sUsed: number = 0;
                    let useCount: number = 0;

                    for (let r = 0; r < countRun; r++) // at this point all run should be of SampleTypeEnum.Routine
                    {
                        let RunDateText: string = StatMWQMRunList[r].RunDate.toString();
                        let RunYear: number = parseInt(RunDateText.substring(0, 4));
                        let RunMonth: number = parseInt(RunDateText.substring(5, 7));
                        let RunDate: number = parseInt(RunDateText.substring(8, 10));

                        let found: boolean = false;
                        for (let s = sUsed; s < countSample; s++) {
                            let SampleDateText: string = MWQMSiteSampleModelSortedList[s].MWQMSample.SampleDateTime_Local.toString();
                            let SampleYear: number = parseInt(SampleDateText.substring(0, 4));
                            let SampleMonth: number = parseInt(SampleDateText.substring(5, 7));
                            let SampleDay: number = parseInt(SampleDateText.substring(8, 10));
                            let IsRouting: boolean = MWQMSiteSampleModelSortedList.filter(c => c.MWQMSample.SampleTypesText.indexOf(SampleTypeText) > -1) ? true : false;
                            if (RunYear == SampleYear && RunMonth == SampleMonth && RunDate == SampleDay && IsRouting) {
                                SampleCount += 1;
                                StatMWQMSiteSampleList.push(<StatMWQMSiteSample>{
                                    Depth: MWQMSiteSampleModelSortedList[s].MWQMSample.Depth_m,
                                    FC: MWQMSiteSampleModelSortedList[s].MWQMSample.FecCol_MPN_100ml,
                                    IsActive: tvItemModel.TVItem.IsActive,
                                    MWQMRunTVItemID: StatMWQMRunList[r].MWQMRunTVItemID,
                                    MWQMSiteTVItemID: tvItemModel.TVItem.TVItemID,
                                    PH: MWQMSiteSampleModelSortedList[s].MWQMSample.PH,
                                    RunIndex: r,
                                    Sal: MWQMSiteSampleModelSortedList[s].MWQMSample.Salinity_PPT,
                                    SampleDate: MWQMSiteSampleModelSortedList[s].MWQMSample.SampleDateTime_Local,
                                    Temp: MWQMSiteSampleModelSortedList[s].MWQMSample.WaterTemp_C,
                                    UseInStat: StatMWQMRunList[r].UseInStat,
                                    Samples: countSample,
                                    SampleYear: SampleYear,
                                    SampleMonth: SampleMonth,
                                    SampleDay: SampleDay,
                                });
                                //StatMWQMRunList[r].UseInStat = true;
                                sUsed = s + 1;
                                found = true;

                                StatMWQMSiteSampleList[StatMWQMSiteSampleList.length - 1].UseInStat = false;

                                let skipVal: boolean = false;

                                // let SampleDate: Date = new Date(SampleYear, SampleMonth, SampleDay);
                                // let AnalysisStartDate: Date = this.appStateService.AnalysisStartRun.RunDate;

                                // Check Start Run Date
                                if (MWQMSiteSampleModelSortedList[s].MWQMSample.SampleDateTime_Local.toString().substring(0, 10) > this.appStateService.AnalysisStartRun.RunDate.toString().substring(0, 10)) {
                                    skipVal = true;
                                }

                                // Check End Run Date
                                if (MWQMSiteSampleModelSortedList[s].MWQMSample.SampleDateTime_Local.toString().substring(0, 10) < this.appStateService.AnalysisEndRun.RunDate.toString().substring(0, 10)) {
                                    skipVal = true;
                                }

                                // Check Runs
                                if (useCount >= this.appStateService.UserPreference.AnalysisRuns) {
                                    skipVal = true;
                                }

                                if (this.appStateService.UserPreference.AnalysisCalculationType == AnalysisCalculationTypeEnum.All) {
                                    // everything is ok, nothing to do
                                }

                                if (this.appStateService.UserPreference.AnalysisCalculationType == AnalysisCalculationTypeEnum.Dry) {
                                    if (StatMWQMRunList[r].RainDay1 >= this.appStateService.UserPreference.AnalysisDry24h
                                        && (StatMWQMRunList[r].RainDay1 + StatMWQMRunList[r].RainDay2) >= this.appStateService.UserPreference.AnalysisDry48h
                                        && (StatMWQMRunList[r].RainDay1 + StatMWQMRunList[r].RainDay2 + StatMWQMRunList[r].RainDay3) >= this.appStateService.UserPreference.AnalysisDry72h
                                        && (StatMWQMRunList[r].RainDay1 + StatMWQMRunList[r].RainDay2 + StatMWQMRunList[r].RainDay3 + StatMWQMRunList[r].RainDay4) >= this.appStateService.UserPreference.AnalysisDry96h) {
                                        skipVal = true;
                                    }
                                }

                                if (this.appStateService.UserPreference.AnalysisCalculationType == AnalysisCalculationTypeEnum.Wet) {
                                    if (StatMWQMRunList[r].RainDay1 <= this.appStateService.UserPreference.AnalysisWet24h
                                        && (StatMWQMRunList[r].RainDay1 + StatMWQMRunList[r].RainDay2) <= this.appStateService.UserPreference.AnalysisWet48h
                                        && (StatMWQMRunList[r].RainDay1 + StatMWQMRunList[r].RainDay2 + StatMWQMRunList[r].RainDay3) <= this.appStateService.UserPreference.AnalysisWet72h
                                        && (StatMWQMRunList[r].RainDay1 + StatMWQMRunList[r].RainDay2 + StatMWQMRunList[r].RainDay3 + StatMWQMRunList[r].RainDay4) <= this.appStateService.UserPreference.AnalysisWet96h) {
                                        skipVal = true;
                                    }
                                }

                                if (StatMWQMRunList[r].RemoveFromStat) {
                                    skipVal = true;
                                }

                                if (!skipVal) {
                                    useCount += 1;
                                    StatMWQMRunList[r].UseInStat = true;
                                    StatMWQMSiteSampleList[StatMWQMSiteSampleList.length - 1].UseInStat = true;
                                }

                                break;
                            }
                        }

                        if (!found) {
                            StatMWQMSiteSampleList.push(<StatMWQMSiteSample>{
                                SampleDate: StatMWQMRunList[r].RunDate,
                                RunIndex: r,
                                UseInStat: false,
                            });
                        }
                    }

                    let FCList: number[] = [];
                    let YearList: number[] = [];

                    let countRuns: number = StatMWQMSiteSampleList.length;
                    let LastSampleDate: Date;
                    for (let r = countRuns - 1; r >= 0; r--) {
                        if (StatMWQMSiteSampleList[r].FC && StatMWQMSiteSampleList[r].UseInStat) {
                            LastSampleDate = StatMWQMSiteSampleList[r].SampleDate;
                            let SampleDateText: string = StatMWQMSiteSampleList[r].SampleDate.toString();
                            let SampleYear: number = parseInt(SampleDateText.substring(0, 4));

                            // for analysis, more condition will be required
                            FCList.push(StatMWQMSiteSampleList[r].FC);
                            YearList.push(SampleYear);
                        }

                        if (FCList.length > StatRuns) {
                            FCList.shift();
                            YearList.shift();
                        }

                        if (FCList.length > 3) {
                            StatMWQMSiteSampleList[r].DataText = FCList.join('|');
                            StatMWQMSiteSampleList[r].LastSampleDate = LastSampleDate;
                            StatMWQMSiteSampleList[r].SampCount = FCList.length;
                            StatMWQMSiteSampleList[r].PercOver43 = this.PercOver43(FCList);
                            StatMWQMSiteSampleList[r].PercOver260 = this.PercOver260(FCList);
                            StatMWQMSiteSampleList[r].MinFC = this.MinFC(FCList);
                            StatMWQMSiteSampleList[r].MaxFC = this.MaxFC(FCList);
                            StatMWQMSiteSampleList[r].Median = this.GetMedian(FCList);
                            StatMWQMSiteSampleList[r].P90 = this.GetP90(FCList);
                            StatMWQMSiteSampleList[r].GeoMean = this.GetGeometricMean(FCList);
                            StatMWQMSiteSampleList[r].ColorAndLetter = this.GetColorAndLetter(
                                StatMWQMSiteSampleList[r].P90,
                                StatMWQMSiteSampleList[r].GeoMean,
                                StatMWQMSiteSampleList[r].Median,
                                StatMWQMSiteSampleList[r].PercOver43,
                                StatMWQMSiteSampleList[r].PercOver260);
                            StatMWQMSiteSampleList[r].StatEndYear = this.MinYear(YearList);
                            StatMWQMSiteSampleList[r].StatStartYear = this.MaxYear(YearList);
                            StatMWQMSiteSampleList[r].EndYear = EndYear;
                            StatMWQMSiteSampleList[r].StartYear = StartYear;
                        }
                    }

                    let countStat: number = StatMWQMSiteSampleList.length;
                    for (let i = 0; i < countStat; i++) {
                        StatMWQMSiteSampleList[i].Samples = SampleCount;
                    }
                }
            }

            return StatMWQMSiteSampleList;
        }
    }

    private FillMWQMSiteSampleStatForMWQMSites(tvItemModel: TVItemModel): StatMWQMSiteSample[] {
        let SampleTypeText: string = `${SampleTypeEnum.Routine},`;
        let StatMWQMSiteSampleList: StatMWQMSiteSample[] = [];
        let StatMWQMRunList: StatMWQMRun[] = this.appLoadedService.StatMWQMRunList;

        let StatRuns: number = this.appStateService.UserPreference.StatRunsForDetail;

        let MWQMSiteModelList: MWQMSiteModel[] = this.appLoadedService.WebMWQMSites?.MWQMSiteModelList?.filter(
            c => c.MWQMSite.MWQMSiteTVItemID == tvItemModel.TVItem.TVItemID);

        if (MWQMSiteModelList && MWQMSiteModelList.length > 0) {
            let MWQMSiteSampleModelSortedList: MWQMSampleModel[] = this.sortMWQMSiteSampleModelListService.SortMWQMSiteSampleModelListDescByDate(
                this.appLoadedService.WebMWQMSamples?.MWQMSampleModelList.filter(c => c.MWQMSample.MWQMSiteTVItemID == tvItemModel.TVItem.TVItemID)
            );

            if (MWQMSiteSampleModelSortedList && MWQMSiteSampleModelSortedList.length > 0) {
                let EndYear = parseInt(MWQMSiteSampleModelSortedList[MWQMSiteSampleModelSortedList.length - 1].MWQMSample.SampleDateTime_Local.toString());
                let StartYear = parseInt(MWQMSiteSampleModelSortedList[0].MWQMSample.SampleDateTime_Local.toString());

                if (MWQMSiteSampleModelSortedList.length > 0) {

                    let SampleCount: number = 0;
                    let countRun: number = StatMWQMRunList.length;
                    let countSample: number = MWQMSiteSampleModelSortedList.length;
                    let sUsed: number = 0;

                    for (let r = 0; r < countRun; r++) // at this point all run should be of SampleTypeEnum.Routine
                    {
                        let RunDateText: string = StatMWQMRunList[r].RunDate.toString();
                        let RunYear: number = parseInt(RunDateText.substring(0, 4));
                        let RunMonth: number = parseInt(RunDateText.substring(5, 7));
                        let RunDate: number = parseInt(RunDateText.substring(8, 10));

                        let found: boolean = false;
                        for (let s = sUsed; s < countSample; s++) {
                            let SampleDateText: string = MWQMSiteSampleModelSortedList[s].MWQMSample.SampleDateTime_Local.toString();
                            let SampleYear: number = parseInt(SampleDateText.substring(0, 4));
                            let SampleMonth: number = parseInt(SampleDateText.substring(5, 7));
                            let SampleDate: number = parseInt(SampleDateText.substring(8, 10));
                            let IsRouting: boolean = MWQMSiteSampleModelSortedList.filter(c => c.MWQMSample.SampleTypesText.indexOf(SampleTypeText) > -1) ? true : false;
                            if (RunYear == SampleYear && RunMonth == SampleMonth && RunDate == SampleDate && IsRouting) {
                                SampleCount += 1;
                                StatMWQMSiteSampleList.push(<StatMWQMSiteSample>{
                                    Depth: MWQMSiteSampleModelSortedList[s].MWQMSample.Depth_m,
                                    FC: MWQMSiteSampleModelSortedList[s].MWQMSample.FecCol_MPN_100ml,
                                    IsActive: tvItemModel.TVItem.IsActive,
                                    MWQMRunTVItemID: StatMWQMRunList[r].MWQMRunTVItemID,
                                    MWQMSiteTVItemID: tvItemModel.TVItem.TVItemID,
                                    PH: MWQMSiteSampleModelSortedList[s].MWQMSample.PH,
                                    RunIndex: r,
                                    Sal: MWQMSiteSampleModelSortedList[s].MWQMSample.Salinity_PPT,
                                    SampleDate: MWQMSiteSampleModelSortedList[s].MWQMSample.SampleDateTime_Local,
                                    Temp: MWQMSiteSampleModelSortedList[s].MWQMSample.WaterTemp_C,
                                    UseInStat: StatMWQMRunList[r].UseInStat,
                                    Samples: countSample,
                                    SampleYear: SampleYear,
                                    SampleMonth: SampleMonth,
                                    SampleDay: SampleDate,
                                });
                                //StatMWQMRunList[r].UseInStat = true;
                                sUsed = s + 1;
                                found = true;
                                break;
                            }
                        }

                        if (!found) {
                            StatMWQMSiteSampleList.push(<StatMWQMSiteSample>{
                                SampleDate: StatMWQMRunList[r].RunDate,
                                RunIndex: r,
                                UseInStat: false,
                            });
                        }
                    }

                    let FCList: number[] = [];
                    let YearList: number[] = [];

                    let countRuns: number = StatMWQMSiteSampleList.length;
                    let LastSampleDate: Date;
                    for (let r = countRuns - 1; r >= 0; r--) {
                        if (StatMWQMSiteSampleList[r].FC) {
                            LastSampleDate = StatMWQMSiteSampleList[r].SampleDate;
                            let SampleDateText: string = StatMWQMSiteSampleList[r].SampleDate.toString();
                            let SampleYear: number = parseInt(SampleDateText.substring(0, 4));

                            // for analysis, more condition will be required
                            FCList.push(StatMWQMSiteSampleList[r].FC);
                            YearList.push(SampleYear);
                        }

                        if (FCList.length > StatRuns) {
                            FCList.shift();
                            YearList.shift();
                        }

                        if (FCList.length > 3) {
                            StatMWQMSiteSampleList[r].DataText = FCList.join('|');
                            StatMWQMSiteSampleList[r].LastSampleDate = LastSampleDate;
                            StatMWQMSiteSampleList[r].SampCount = FCList.length;
                            StatMWQMSiteSampleList[r].PercOver43 = this.PercOver43(FCList);
                            StatMWQMSiteSampleList[r].PercOver260 = this.PercOver260(FCList);
                            StatMWQMSiteSampleList[r].MinFC = this.MinFC(FCList);
                            StatMWQMSiteSampleList[r].MaxFC = this.MaxFC(FCList);
                            StatMWQMSiteSampleList[r].Median = this.GetMedian(FCList);
                            StatMWQMSiteSampleList[r].P90 = this.GetP90(FCList);
                            StatMWQMSiteSampleList[r].GeoMean = this.GetGeometricMean(FCList);
                            StatMWQMSiteSampleList[r].ColorAndLetter = this.GetColorAndLetter(
                                StatMWQMSiteSampleList[r].P90,
                                StatMWQMSiteSampleList[r].GeoMean,
                                StatMWQMSiteSampleList[r].Median,
                                StatMWQMSiteSampleList[r].PercOver43,
                                StatMWQMSiteSampleList[r].PercOver260);
                            StatMWQMSiteSampleList[r].StatEndYear = this.MinYear(YearList);
                            StatMWQMSiteSampleList[r].StatStartYear = this.MaxYear(YearList);
                            StatMWQMSiteSampleList[r].EndYear = EndYear;
                            StatMWQMSiteSampleList[r].StartYear = StartYear;
                        }
                    }

                    let countStat: number = StatMWQMSiteSampleList.length;
                    for (let i = 0; i < countStat; i++) {
                        StatMWQMSiteSampleList[i].Samples = SampleCount;
                    }
                }
            }

            return StatMWQMSiteSampleList;
        }
    }

    private PercOver43(FCList: number[]): number {
        let dataOver43: number[] = [];
        for (let FC of FCList) {
            if (FC > 43) {
                dataOver43.push(FC);
            }
        }

        return (dataOver43.length / FCList.length) * 100;
    }

    private PercOver260(FCList: number[]): number {
        let dataOver260: number[] = [];
        for (let FC of FCList) {
            if (FC > 260) {
                dataOver260.push(FC);
            }
        }

        return (dataOver260.length / FCList.length) * 100;
    }
    private MinYear(YearList: number[]): number {
        let MinYear: number = 10000;

        for (let Year of YearList) {
            if (MinYear > Year) {
                MinYear = Year;
            }
        }

        return MinYear;
    }
    private MaxYear(YearList: number[]): number {
        let MaxYear: number = 0;

        for (let Year of YearList) {
            if (MaxYear < Year) {
                MaxYear = Year;
            }
        }

        return MaxYear;
    }
    private MaxFC(FCList: number[]): number {
        let MaxFC: number = 0;

        for (let FC of FCList) {
            if (MaxFC < FC) {
                MaxFC = FC;
            }
        }

        return MaxFC;
    }
    private MinFC(FCList: number[]): number {
        let MinFC: number = 10000000;

        for (let FC of FCList) {
            if (MinFC > FC) {
                MinFC = FC;
            }
        }

        return MinFC;
    }
    private GetGeometricMean(FCList: number[]): number {
        let prod: number = 0;

        prod = 1.0;

        for (let FC of FCList) {
            prod *= FC;
        }

        return Math.pow(prod, (1.0 / FCList.length));
    }
    private GetColorAndLetter(P90: number, GeoMean: number, Median: number, PercOver43: number, PercOver260: number): ColorAndLetter {
        let colorAndLetter: ColorAndLetter = <ColorAndLetter>{ color: '', letter: '' };
        if (!Median) {
            return colorAndLetter;
        }
        if ((GeoMean > 88) || (Median > 88) || (P90 > 260) || (PercOver260 > 10)) {
            if ((GeoMean > 181) || (Median > 181) || (P90 > 460) || (PercOver260 > 18)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#8888ff', color: 'bgbluef', letter: 'F' };
            }
            else if ((GeoMean > 163) || (Median > 163) || (P90 > 420) || (PercOver260 > 17)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#9999ff', color: 'bgbluee', letter: 'E' };
            }
            else if ((GeoMean > 144) || (Median > 144) || (P90 > 380) || (PercOver260 > 15)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#aaaaff', color: 'bgblued', letter: 'D' };
            }
            else if ((GeoMean > 125) || (Median > 125) || (P90 > 340) || (PercOver260 > 13)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#bbbbff', color: 'bgbluec', letter: 'C' };
            }
            else if ((GeoMean > 107) || (Median > 107) || (P90 > 300) || (PercOver260 > 12)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#ccccff', color: 'bgblueb', letter: 'B' };
            }
            else {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#ddddff', color: 'bgbluea', letter: 'A' };
            }
        }
        else if ((GeoMean > 14) || (Median > 14) || (P90 > 43) || (PercOver43 > 10)) {
            if ((GeoMean > 76) || (Median > 76) || (P90 > 224) || (PercOver43 > 27)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#aa0000', color: 'bgredf', letter: 'F' };
            }
            else if ((GeoMean > 63) || (Median > 63) || (P90 > 188) || (PercOver43 > 23)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#cc0000', color: 'bgrede', letter: 'E' };
            }
            else if ((GeoMean > 51) || (Median > 51) || (P90 > 152) || (PercOver43 > 20)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#ff1111', color: 'bgredd', letter: 'D' };
            }
            else if ((GeoMean > 39) || (Median > 39) || (P90 > 115) || (PercOver43 > 17)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#ff4444', color: 'bgredc', letter: 'C' };
            }
            else if ((GeoMean > 26) || (Median > 26) || (P90 > 79) || (PercOver43 > 13)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#ff9999', color: 'bgredb', letter: 'B' };
            }
            else {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#ffcccc', color: 'bgreda', letter: 'A' };
            }
        }
        else {
            if ((GeoMean > 12) || (Median > 12) || (P90 > 36) || (PercOver43 > 8)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#ccffcc', color: 'bggreenf', letter: 'F' };
            }
            else if ((GeoMean > 9) || (Median > 9) || (P90 > 29) || (PercOver43 > 7)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#99ff99', color: 'bggreene', letter: 'E' };
            }
            else if ((GeoMean > 7) || (Median > 7) || (P90 > 22) || (PercOver43 > 5)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#44ff44', color: 'bggreend', letter: 'D' };
            }
            else if ((GeoMean > 5) || (Median > 5) || (P90 > 14) || (PercOver43 > 3)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#11ff11', color: 'bggreenc', letter: 'C' };
            }
            else if ((GeoMean > 2) || (Median > 2) || (P90 > 7) || (PercOver43 > 2)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#00bb00', color: 'bggreenb', letter: 'B' };
            }
            else {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#009900', color: 'bggreena', letter: 'A' };
            }
        }

        return colorAndLetter;
    }
    private GetMedian(FCList: number[]): number {
        let sortedData: number[] = [];

        let countFC: number = FCList.length;
        for (let i = 0; i < countFC; i++) {
            sortedData.push(FCList[i]);
        }

        sortedData.sort((n1, n2) => n1 - n2);
        let size: number = sortedData.length;
        let mid = parseInt((size / 2).toString());
        return (size % 2 != 0) ? sortedData[mid] : (sortedData[mid] + sortedData[mid - 1]) / 2;

    }
    private GetP90(FCList: number[]): number {
        let fcLogList: number[] = [];
        for (let FC of FCList) {
            fcLogList.push(Math.log(FC) / Math.LN10);
        }

        let Average = 0.0;
        let Sum = 0.0;
        for (let d of fcLogList) {
            Sum += d
        }
        Average = Sum / FCList.length;
        let SD: number = this.GetStandardDeviation(fcLogList);
        let P90Log = (SD * 1.28) + Average;
        return Math.pow(10, P90Log);
    }
    private GetStandardDeviation(FCList: number[]): number {
        let avg: number = 0;
        let total: number = 0;
        for (let FC of FCList) {
            total = total + FC;
        }
        avg = total / FCList.length;

        let sum: number = 0;
        for (let FC of FCList) {
            sum += (FC - avg) * (FC - avg);
        }

        return Math.sqrt((sum) / (FCList.length - 1));
    }
}