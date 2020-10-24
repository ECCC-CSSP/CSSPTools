import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebClimateSite } from 'src/app/models/generated/WebClimateSite.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';


@Injectable({
    providedIn: 'root'
})
export class WebClimateSiteService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetWebClimateSite(TVItemID: number) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebClimateSite: {}, Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}en-CA/Read/WebClimateSite/${TVItemID}/1`;
        return this.httpClient.get<WebClimateSite>(url).pipe(
            map((x: any) => {
                this.UpdateWebClimateSite(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebClimateSite(x: WebClimateSite) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebClimateSite: x,
            Working: false
        });
    }
}