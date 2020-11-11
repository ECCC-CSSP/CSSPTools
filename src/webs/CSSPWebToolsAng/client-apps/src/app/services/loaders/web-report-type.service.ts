import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebReportType } from 'src/app/models/generated/WebReportType.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';

@Injectable({
    providedIn: 'root'
})
export class WebReportTypeService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetWebReportType() {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebReportType: {}, Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appStateService.AppState$.getValue().Language}-CA/Read/WebReportType/0/1`;
        return this.httpClient.get<WebReportType>(url).pipe(
            map((x: any) => {
                this.UpdateWebReportType(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebReportType(x: WebReportType) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebReportType: x,
            Working: false
        });
    }
}