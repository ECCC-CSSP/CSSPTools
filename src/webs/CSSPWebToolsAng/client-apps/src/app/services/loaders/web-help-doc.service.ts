import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebHelpDoc } from 'src/app/models/generated/WebHelpDoc.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';

@Injectable({
    providedIn: 'root'
})
export class WebHelpDocService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetWebHelpDoc() {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebHelpDoc: {}, Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}en-CA/Read/WebHelpDoc/0/1`;
        return this.httpClient.get<WebHelpDoc>(url).pipe(
            map((x: any) => {
                this.UpdateWebHelpDoc(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebHelpDoc(x: WebHelpDoc) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebHelpDoc: x,
            Working: false
        });
    }
}