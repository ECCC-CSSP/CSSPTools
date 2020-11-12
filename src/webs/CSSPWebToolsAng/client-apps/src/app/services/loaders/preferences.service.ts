import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { Preference } from 'src/app/models/generated/helper/Preference.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';


@Injectable({
    providedIn: 'root'
})
export class PreferenceService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetPreference() {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ PreferenceList: [], Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}Preference`;
        return this.httpClient.get<Preference[]>(url).pipe(
            map((x: any) => {
                this.UpdatePreference(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdatePreference(x: Preference[]) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            PreferenceList: x,
            Working: false
        });
    }
}