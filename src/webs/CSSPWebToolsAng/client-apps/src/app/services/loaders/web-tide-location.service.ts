import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebTideLocation } from 'src/app/models/generated/web/WebTideLocation.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class WebTideLocationService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    GetWebTideLocation() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebTideLocation: {} });
        this.appStateService.UpdateAppState(<AppState>{ Status: 'Loading Tide Location', Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebTideLocation/0/1`;
        return this.httpClient.get<WebTideLocation>(url).pipe(
            map((x: any) => {
                this.UpdateWebTideLocation(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebTideLocation(x: WebTideLocation) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebTideLocation: x });

        if (this.componentDataLoadedService.DataLoadedTideLocation()) {
            this.appStateService.UpdateAppState(<AppState>{ Working: false });
        }
    }
}