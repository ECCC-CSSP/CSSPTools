import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebMWQMSite } from 'src/app/models/generated/web/WebMWQMSite.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebMWQMRunService } from './web-mwqm-runs.service';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMSiteService {
    private DoOther: boolean;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webMWQMRunService: WebMWQMRunService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    GetWebMWQMSite(TVItemID: number, DoOther: boolean) {
        this.DoOther = DoOther;
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSite: {}, BreadCrumbWebBaseList: [] });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingMWQMSite[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMWQMSite/${TVItemID}/1`;
        return this.httpClient.get<WebMWQMSite>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMSite(x);
                console.debug(x);
                if (DoOther) {
                    this.GetWebMWQMRun(TVItemID);
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: true, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    GetWebMWQMRun(TVItemID: number) {
        this.webMWQMRunService.GetWebMWQMRun(TVItemID, this.DoOther).subscribe();
    }

    UpdateWebMWQMSite(x: WebMWQMSite) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSite: x, BreadCrumbWebBaseList: x?.TVItemParentList });

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