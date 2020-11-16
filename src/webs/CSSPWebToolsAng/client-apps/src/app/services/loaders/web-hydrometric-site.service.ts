import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebHydrometricSite } from 'src/app/models/generated/web/WebHydrometricSite.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';


@Injectable({
    providedIn: 'root'
})
export class WebHydrometricSiteService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    GetWebHydrometricSite(TVItemID: number) {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebHydrometricSite: {} });
        this.appStateService.UpdateAppState(<AppState>{ Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebHydrometricSite/${TVItemID}/1`;
        return this.httpClient.get<WebHydrometricSite>(url).pipe(
            map((x: any) => {
                this.UpdateWebHydrometricSite(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebHydrometricSite(x: WebHydrometricSite) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebHydrometricSite: x, });

        if (this.componentDataLoadedService.DataLoadedHydrometricSite()) {
            this.appStateService.UpdateAppState(<AppState>{ Working: false });
        }
    }
}