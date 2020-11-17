import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebSamplingPlan } from 'src/app/models/generated/web/WebSamplingPlan.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class WebSamplingPlanService {
    private DoOther: boolean;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    GetWebSamplingPlan(SamplingPlanID: number, DoOther: boolean) {
        this.DoOther = DoOther;
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebSamplingPlan: {}, BreadCrumbWebBaseList: [] });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingSamplingPlan[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebSamplingPlan/${SamplingPlanID}/1`;
        return this.httpClient.get<WebSamplingPlan>(url).pipe(
            map((x: any) => {
                this.UpdateWebSamplingPlan(x);
                console.debug(x);
                if (DoOther) {
                    // nothing more to add in the chain
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebSamplingPlan(x: WebSamplingPlan) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebSamplingPlan: x, BreadCrumbWebBaseList: x?.TVItemParentList });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedSamplingPlan()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
        }
    }
}