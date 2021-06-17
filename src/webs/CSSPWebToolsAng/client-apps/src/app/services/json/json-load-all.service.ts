import { Injectable } from '@angular/core';
import { WebAllAddresses } from 'src/app/models/generated/web/WebAllAddresses.model';
import { AppStateService } from 'src/app/services/app/app-state.service';
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
import { WebMonitoringOtherStatsCountry } from 'src/app/models/generated/web/WebMonitoringOtherStatsCountry.model';
import { WebMonitoringRoutineStatsCountry } from 'src/app/models/generated/web/WebMonitoringRoutineStatsCountry.model';
import { WebMonitoringOtherStatsProvince } from 'src/app/models/generated/web/WebMonitoringOtherStatsProvince.model';
import { WebMonitoringRoutineStatsProvince } from 'src/app/models/generated/web/WebMonitoringRoutineStatsProvince.model';
import {
    JsonDoLoadSwitchService, JsonDoUpdateSwitchService, JsonDataIsLoadedService,
    JsonDoUpdateBreadCrumbOnlyService, JsonLoadListService, JsonDoUpdateWebMapService,
    JsonDoLoadLocalFileInfoSwitchService, JsonDoUpdateLocalFileInfoSwitchService
} from '.';
import { of, Subscription } from 'rxjs';
import { AppLoadedService } from '../app/app-loaded.service';
import { AppLanguageService } from '../app/app-language.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { LocalFileInfo } from 'src/app/models/generated/web/LocalFileInfo.model';


@Injectable({
    providedIn: 'root'
})
export class JsonLoadAllService {
    private WebType: WebTypeEnum;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private jsonLoadListService: JsonLoadListService,
        private jsonDataIsLoadedService: JsonDataIsLoadedService,
        private jsonDoUpdateBreadCrumbOnlyService: JsonDoUpdateBreadCrumbOnlyService,
        private jsonDoUpdateWebMapService: JsonDoUpdateWebMapService,
        private jsonDoUpdateSwitchService: JsonDoUpdateSwitchService,
        private jsonDoLoadSwitchService: JsonDoLoadSwitchService,
        private jsonDoLoadLocalFileInfoSwitchService: JsonDoLoadLocalFileInfoSwitchService,
        private jsonDoUpdateLocalFileInfoSwitchService: JsonDoUpdateLocalFileInfoSwitchService) {
    }

    LoadAll() {
        this.appStateService.ShowMonitoringStats = false;

        if (this.jsonLoadListService.JsonToLoadList != undefined && this.jsonLoadListService.JsonToLoadList?.length > 0) {
            this.WebType = this.jsonLoadListService.JsonToLoadList[0].WebType;
            this.ForceReload = this.jsonLoadListService.JsonToLoadList[0].ForceReload;

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

    private Load<T>(webType: WebTypeEnum, ForceReload: boolean) {

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.DoLoad<T>().subscribe();
        }
        else {
            if (!this.jsonDataIsLoadedService.DataIsLoaded(webType)) {
                this.sub = this.DoLoad<T>().subscribe();
            }
            else {
                this.jsonDoUpdateBreadCrumbOnlyService.DoUpdateBreadCrumbOnly(this.WebType);
                this.jsonDoUpdateWebMapService.DoUpdateWebMap(this.WebType);
                if (this.jsonLoadListService.JsonToLoadList?.length > 1) {
                    this.jsonLoadListService.JsonToLoadList.shift();
                    this.LoadAll();
                }
            }
        }
    }

    private DoUpdate(x: any) {
        this.jsonDoUpdateSwitchService.DoUpdateSwitch(this.WebType, x);

        if (this.jsonDoLoadLocalFileInfoSwitchService.DoLoadLocalFileInfoSwitch(this.WebType) != '') {
            this.sub = this.DoLoadLocalFileInfo().subscribe();
        }
        else {
            this.appStateService.Status = '';
            this.appStateService.Working = false;
            console.debug(x);

            if (this.jsonLoadListService.JsonToLoadList?.length > 1) {
                this.jsonLoadListService.JsonToLoadList.shift();
                this.LoadAll();
            }
        }

    }

    private DoUpdateLocalFileInfo(LocalFileInfoList: LocalFileInfo[]) {
        this.jsonDoUpdateLocalFileInfoSwitchService.DoUpdateLocalFileInfoSwitch(this.WebType, LocalFileInfoList);

        this.appStateService.Status = '';
        this.appStateService.Working = false;
        console.debug(LocalFileInfoList);

        if (this.jsonLoadListService.JsonToLoadList?.length > 1) {
            this.jsonLoadListService.JsonToLoadList.shift();
            this.LoadAll();
        }
    }

    private DoLoad<T>() {
        let languageEnum = GetLanguageEnum();
        let objText: string = `${WebTypeEnum[this.WebType]}`;

        let TVItemIDText: string = this.jsonDoLoadSwitchService.DoLoadSwitch(this.WebType);

        let ForceReloadText = this.ForceReload ? ` - ${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - ${objText}${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/${objText}${TVItemIDText}`;

        return this.httpClient.get<T>(url).pipe(map((x: T) => { this.DoUpdate(x); }), catchError(e => of(e).pipe(map(e => { this.DoError(e); }))));
    }

    private DoLoadLocalFileInfo() {
        let languageEnum = GetLanguageEnum();

        let TVItemIDText: string = this.jsonDoLoadLocalFileInfoSwitchService.DoLoadLocalFileInfoSwitch(this.WebType);

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/LocalFile/GetLocalFileInfoList${TVItemIDText}`;

        return this.httpClient.get<any>(url).pipe(map((x: LocalFileInfo[]) => { this.DoUpdateLocalFileInfo(x); }), catchError(e => of(e).pipe(map(e => { this.DoError(e); }))));
    }

    private DoError(e: any) {
        this.appStateService.Status = ''
        this.appStateService.Working = false
        this.appStateService.Error = <HttpErrorResponse>e;
        console.debug(e);
    }
}