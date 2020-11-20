import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
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
    private SamplingPlanID: number;
    private DoOther: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebSamplingPlan(SamplingPlanID: number, DoOther: boolean) {
        this.SamplingPlanID = SamplingPlanID;
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebSamplingPlan?.SamplingPlanModel.SamplingPlan.SamplingPlanID == SamplingPlanID) {
            this.KeepWebSamplingPlan();
        }
        else {
            this.sub = this.GetWebSamplingPlan().subscribe();
        }
    }

    private GetWebSamplingPlan() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebSamplingPlan: {},
        });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingSamplingPlan[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebSamplingPlan/${this.SamplingPlanID}/1`;
        return this.httpClient.get<WebSamplingPlan>(url).pipe(
            map((x: any) => {
                this.UpdateWebSamplingPlan(x);
                console.debug(x);
                if (this.DoOther) {
                    // nothing more to add in the chain
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private KeepWebSamplingPlan() {
        this.UpdateWebSamplingPlan(this.appLoadedService.AppLoaded$?.getValue()?.WebSamplingPlan);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebSamplingPlan);
        if (this.DoOther) {
            // nothing more to add in the chain
        }
    }

    private UpdateWebSamplingPlan(x: WebSamplingPlan) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebSamplingPlan: x,
        });

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