import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebPolSourceSite } from 'src/app/models/generated/web/WebPolSourceSite.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class WebPolSourceSiteService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    GetWebPolSourceSite(TVItemID: number) {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebPolSourceSite: {}, BreadCrumbWebBaseList: [] });
        this.appStateService.UpdateAppState(<AppState>{ Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebPolSourceSite/${TVItemID}/1`;
        return this.httpClient.get<WebPolSourceSite>(url).pipe(
            map((x: any) => {
                this.UpdateWebPolSourceSite(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebPolSourceSite(x: WebPolSourceSite) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebPolSourceSite: x, BreadCrumbWebBaseList: x?.TVItemParentList });

        if (this.componentDataLoadedService.DataLoadedPolSourceSite()) {
            this.appStateService.UpdateAppState(<AppState>{ Working: false });
        }
    }
}