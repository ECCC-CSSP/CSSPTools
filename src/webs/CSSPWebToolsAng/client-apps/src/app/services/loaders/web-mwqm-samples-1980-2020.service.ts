import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebMWQMSamples } from 'src/app/models/generated/web/WebMWQMSamples.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebMWQMSamples2021_2060Service } from 'src/app/services/loaders/web-mwqm-samples-2021-2060.service';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMSamples1980_2020Service {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webMWQMSamples2021_2060Service: WebMWQMSamples2021_2060Service,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebMWQMSamples1980_2020(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSamples1980_2020) {
            this.KeepWebMWQMSamples1980_2020();
        }
        else {
            this.sub = this.GetWebMWQMSamples1980_2020().subscribe();
        }
    }

    private GetWebMWQMSamples1980_2020() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSamples1980_2020: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebMWQMSamples }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMWQMSamples1980_2020/${this.TVItemID}`;
        return this.httpClient.get<WebMWQMSamples>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMSamples1980_2020(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebMWQMSamples2021_2060();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebMWQMSamples2021_2060() {
        this.webMWQMSamples2021_2060Service.DoWebMWQMSamples2021_2060(this.TVItemID, true);
    }

    private KeepWebMWQMSamples1980_2020() {
        this.UpdateWebMWQMSamples1980_2020(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSamples1980_2020);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSamples1980_2020);
        if (this.DoOther) {
            this.DoWebMWQMSamples2021_2060();
        }
    }

    private UpdateWebMWQMSamples1980_2020(x: WebMWQMSamples) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSamples1980_2020: x });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebSubsector()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebMWQMSamples1980_2020()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}