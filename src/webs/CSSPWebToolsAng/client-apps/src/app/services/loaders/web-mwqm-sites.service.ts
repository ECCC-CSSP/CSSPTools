import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebMWQMSites } from 'src/app/models/generated/web/WebMWQMSites.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { HistoryService } from 'src/app/services/helpers/history.service';
import { WebMWQMRunsService } from 'src/app/services/loaders/web-mwqm-runs.service';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMSitesService {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webMWQMRunsService: WebMWQMRunsService,
        private componentDataLoadedService: ComponentDataLoadedService,
        private historyService: HistoryService) {
    }

    DoWebMWQMSites(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSites) {
            this.KeepWebMWQMSites();
        }
        else {
            this.sub = this.GetWebMWQMSites().subscribe();
        }
    }

    private GetWebMWQMSites() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMWQMSites: {},
        });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebMWQMSites }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMWQMSites/${this.TVItemID}`;
        return this.httpClient.get<WebMWQMSites>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMSites(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebMWQMRuns();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: true, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebMWQMRuns() {
        this.webMWQMRunsService.DoWebMWQMRuns(this.TVItemID, this.DoOther);
    }

    private KeepWebMWQMSites() {
        this.UpdateWebMWQMSites(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSites);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSites);
        if (this.DoOther) {
            this.DoWebMWQMRuns();
        }
    }

    private UpdateWebMWQMSites(x: WebMWQMSites) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMWQMSites: x,
        });

        this.historyService.AddHistory(this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSites?.TVItemModel);

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebSubsector()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebMWQMSites()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}