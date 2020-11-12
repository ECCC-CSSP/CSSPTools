import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebSamplingPlan } from 'src/app/models/generated/web/WebSamplingPlan.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
    providedIn: 'root'
})
export class WebSamplingPlanService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetWebSamplingPlan(SamplingPlanID: number) {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebSamplingPlan: {},
            BreadCrumbWebBaseList: [],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebSamplingPlan/${SamplingPlanID}/1`;
        return this.httpClient.get<WebSamplingPlan>(url).pipe(
            map((x: any) => {
                this.UpdateWebSamplingPlan(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebSamplingPlan(x: WebSamplingPlan) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebSamplingPlan: x,
            BreadCrumbWebBaseList: x?.TVItemParentList,
            Working: false
        });
    }
}