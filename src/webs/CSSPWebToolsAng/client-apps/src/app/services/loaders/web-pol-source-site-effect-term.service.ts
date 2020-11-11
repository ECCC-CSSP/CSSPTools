import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebPolSourceSiteEffectTerm } from 'src/app/models/generated/WebPolSourceSiteEffectTerm.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';

@Injectable({
    providedIn: 'root'
})
export class WebPolSourceSiteEffectTermService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetWebPolSourceSiteEffectTerm() {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebPolSourceSiteEffectTerm: {}, Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appStateService.AppState$.getValue().Language}-CA/Read/WebPolSourceSiteEffectTerm/0/1`;
        return this.httpClient.get<WebPolSourceSiteEffectTerm>(url).pipe(
            map((x: any) => {
                this.UpdateWebPolSourceSiteEffectTerm(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebPolSourceSiteEffectTerm(x: WebPolSourceSiteEffectTerm) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebPolSourceSiteEffectTerm: x,
            Working: false
        });
    }
}