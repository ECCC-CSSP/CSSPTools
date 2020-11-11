import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebTideLocation } from 'src/app/models/generated/WebTideLocation.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';

@Injectable({
    providedIn: 'root'
})
export class WebTideLocationService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetWebTideLocation() {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebTideLocation: {}, Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appStateService.AppState$.getValue().Language}-CA/Read/WebTideLocation/0/1`;
        return this.httpClient.get<WebTideLocation>(url).pipe(
            map((x: any) => {
                this.UpdateWebTideLocation(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebTideLocation(x: WebTideLocation) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebTideLocation: x,
            Working: false
        });
    }
}