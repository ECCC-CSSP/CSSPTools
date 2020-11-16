import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebDrogueRun } from 'src/app/models/generated/web/WebDrogueRun.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class WebDrogueRunService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    GetWebDrogueRun(TVItemID: number) {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebDrogueRun: {}, BreadCrumbWebBaseList: [] });
        this.appStateService.UpdateAppState(<AppState>{ Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebDrogueRun/${TVItemID}/1`;
        return this.httpClient.get<WebDrogueRun>(url).pipe(
            map((x: any) => {
                this.UpdateWebDrogueRun(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebDrogueRun(x: WebDrogueRun) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebDrogueRun: x, BreadCrumbWebBaseList: x?.TVItemParentList, });

        if (this.componentDataLoadedService.DataLoadedCountry()) {
            this.appStateService.UpdateAppState(<AppState>{ Working: false });
        }

    }
}