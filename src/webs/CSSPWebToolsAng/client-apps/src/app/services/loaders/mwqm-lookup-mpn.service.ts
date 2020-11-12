import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebMWQMLookupMPN } from 'src/app/models/generated/web/WebMWQMLookupMPN.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMLookupMPNService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetWebMWQMLookupMPN() {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebHelpDoc: {}, Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appStateService.AppState$.getValue().Language}-CA/Read/WebMWQMLookupMPN/0/1`;
        return this.httpClient.get<WebMWQMLookupMPN>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMLookupMPN(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebMWQMLookupMPN(x: WebMWQMLookupMPN) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMWQMLookupMPN: x,
            Working: false
        });
    }
}