import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebPolSourceGrouping } from 'src/app/models/generated/web/WebPolSourceGrouping.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
    providedIn: 'root'
})
export class WebPolSourceGroupingService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetWebPolSourceGrouping() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebPolSourceGrouping: {}, Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebPolSourceGrouping/0/1`;
        return this.httpClient.get<WebPolSourceGrouping>(url).pipe(
            map((x: any) => {
                this.UpdateWebPolSourceGrouping(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebPolSourceGrouping(x: WebPolSourceGrouping) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebPolSourceGrouping: x,
            Working: false
        });
    }
}