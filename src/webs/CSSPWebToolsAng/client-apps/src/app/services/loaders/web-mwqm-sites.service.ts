import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebMWQMSite } from 'src/app/models/generated/WebMWQMSite.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMSiteService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetWebMWQMSite(TVItemID: number) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSite: {}, BreadCrumbWebBaseList: [], Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}en-CA/Read/WebMWQMSite/${TVItemID}/1`;
        return this.httpClient.get<WebMWQMSite>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMSite(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebMWQMSite(x: WebMWQMSite) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMWQMSite: x,
            BreadCrumbWebBaseList: x?.TVItemParentList,
            Working: false
        });
    }
}