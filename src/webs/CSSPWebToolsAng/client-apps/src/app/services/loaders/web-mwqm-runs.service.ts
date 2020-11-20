import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebMWQMRun } from 'src/app/models/generated/web/WebMWQMRun.model';
import { WebPolSourceSite } from 'src/app/models/generated/web/WebPolSourceSite.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebPolSourceSiteService } from './web-pol-source-sites.service';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMRunService {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webPolSourceSiteService: WebPolSourceSiteService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebMWQMRun(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMRun?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
            this.KeepWebMWQMRun();
        }
        else {
            this.sub = this.GetWebMWQMRun().subscribe();
        }
    }

    private GetWebMWQMRun() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMWQMRun: {},
            BreadCrumbMWQMRunWebBaseList: [],
            BreadCrumbWebBaseList: []
        });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingMWQMRun[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMWQMRun/${this.TVItemID}/1`;
        return this.httpClient.get<WebMWQMRun>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMRun(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebPolSourceSite();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebPolSourceSite() {
        this.webPolSourceSiteService.DoWebPolSourceSite(this.TVItemID, this.DoOther);
    }

    private KeepWebMWQMRun() {
        this.UpdateWebMWQMRun(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMRun);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMRun);
        if (this.DoOther) {
            this.DoWebPolSourceSite();
        }
    }

    private UpdateWebMWQMRun(x: WebMWQMRun) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMWQMRun: x,
            BreadCrumbMWQMRunWebBaseList: x?.TVItemParentList,
            BreadCrumbWebBaseList: x?.TVItemParentList
        });

        this.appStateService.AppState$.getValue().History.push(this.appLoadedService.AppLoaded$.getValue()?.WebMWQMRun?.TVItemModel);

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedSubsector()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedMWQMRun()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}