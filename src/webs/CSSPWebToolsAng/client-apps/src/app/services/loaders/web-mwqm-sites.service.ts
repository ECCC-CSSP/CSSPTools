import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { MWQMSite } from 'src/app/models/generated/db/MWQMSite.model';
import { WebMWQMSite } from 'src/app/models/generated/web/WebMWQMSite.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { HistoryService } from '../helpers/history.service';
import { WebMWQMRunService } from './web-mwqm-runs.service';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMSiteService {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webMWQMRunService: WebMWQMRunService,
        private componentDataLoadedService: ComponentDataLoadedService,
        private historyService: HistoryService) {
    }

    DoWebMWQMSite(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSite?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
            this.KeepWebMWQMSite();
        }
        else {
            this.sub = this.GetWebMWQMSite().subscribe();
        }
    }

    private GetWebMWQMSite() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMWQMSite: {},
            BreadCrumbMWQMSiteWebBaseList: [],
            BreadCrumbWebBaseList: []
        });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingMWQMSite[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMWQMSite/${this.TVItemID}/1`;
        return this.httpClient.get<WebMWQMSite>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMSite(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebMWQMRun();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: true, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebMWQMRun() {
        this.webMWQMRunService.DoWebMWQMRun(this.TVItemID, this.DoOther);
    }

    private KeepWebMWQMSite() {
        this.UpdateWebMWQMSite(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSite);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSite);
        if (this.DoOther) {
            this.DoWebMWQMRun();
        }
    }

    private UpdateWebMWQMSite(x: WebMWQMSite) {
        let mwqmSiteList: MWQMSite[] = [];
        let count: number = x.MWQMSiteModelList.length;
        for (let i = 0; i < count; i++) {
                mwqmSiteList.push(x.MWQMSiteModelList[i].MWQMSite);
        }

        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMWQMSite: x,
            MWQMSiteList: mwqmSiteList,
            BreadCrumbMWQMSiteWebBaseList: x?.TVItemParentList,
            BreadCrumbWebBaseList: x?.TVItemParentList
        });

        this.historyService.AddHistory(this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSite?.TVItemModel);

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedSubsector()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedMWQMSite()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}