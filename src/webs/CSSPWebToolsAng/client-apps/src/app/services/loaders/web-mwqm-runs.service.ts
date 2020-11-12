import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebMWQMRun } from 'src/app/models/generated/web/WebMWQMRun.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMRunService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetWebMWQMRun(TVItemID: number) {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMRun: {}, BreadCrumbWebBaseList: [], Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMWQMRun/${TVItemID}/1`;
        return this.httpClient.get<WebMWQMRun>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMRun(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebMWQMRun(x: WebMWQMRun) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMWQMRun: x,
            BreadCrumbWebBaseList: x?.TVItemParentList,
            Working: false
        });
    }
}