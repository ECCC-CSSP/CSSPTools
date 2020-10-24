import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebHydrometricDataValue } from 'src/app/models/generated/WebHydrometricDataValue.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';

@Injectable({
    providedIn: 'root'
})
export class WebHydrometricDataValueService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetWebHydrometricDataValue(TVItemID: number) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebHydrometricDataValue: {}, Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}en-CA/Read/WebHydrometricDataValue/${TVItemID}/1`;
        return this.httpClient.get<WebHydrometricDataValue>(url).pipe(
            map((x: any) => {
                this.UpdateWebHydrometricDataValue(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebHydrometricDataValue(x: WebHydrometricDataValue) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebHydrometricDataValue: x,
            Working: false
        });
    }
}