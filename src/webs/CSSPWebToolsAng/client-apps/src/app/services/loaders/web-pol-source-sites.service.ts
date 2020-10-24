import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebPolSourceSite } from 'src/app/models/generated/WebPolSourceSite.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';

@Injectable({
    providedIn: 'root'
})
export class WebPolSourceSiteService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetWebPolSourceSite(TVItemID: number) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebPolSourceSite: {}, BreadCrumbWebBaseList: [], Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}en-CA/Read/WebPolSourceSite/${TVItemID}/1`;
        return this.httpClient.get<WebPolSourceSite>(url).pipe(
            map((x: any) => {
                this.UpdateWebPolSourceSite(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebPolSourceSite(x: WebPolSourceSite) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebPolSourceSite: x,
            BreadCrumbWebBaseList: x?.TVItemParentList,
            Working: false
        });
    }
}