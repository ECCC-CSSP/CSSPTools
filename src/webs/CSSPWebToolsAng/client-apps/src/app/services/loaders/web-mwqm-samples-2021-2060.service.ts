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

@Injectable({
    providedIn: 'root'
})
export class WebMWQMSamples2021_2060Service {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebMWQMSamples2021_2060(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSamples2021_2060) {
            this.KeepWebMWQMSamples2021_2060();
        }
        else {
            this.sub = this.GetWebMWQMSamples2021_2060().subscribe();
        }
    }

    private GetWebMWQMSamples2021_2060() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSamples2021_2060: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebMWQMSamples }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMWQMSamples2021_2060/${this.TVItemID}`;
        return this.httpClient.get<WebMWQMSamples>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMSamples2021_2060(x);
                console.debug(x);
                if (this.DoOther) {
                    //this.DoWebMWQMSamples2021_2060();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    // private DoWebMWQMSamples2021_2060() {
    //     this.webMWQMSamples2021_2060Service.DoWebMWQMSamples2021_2060(this.TVItemID);
    // }

    private KeepWebMWQMSamples2021_2060() {
        this.UpdateWebMWQMSamples2021_2060(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSamples2021_2060);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSamples2021_2060);
        if (this.DoOther) {
            //this.DoWebMWQMSamples2021_2060();
        }
    }

    private UpdateWebMWQMSamples2021_2060(x: WebMWQMSamples) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSamples2021_2060: x });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebSubsector()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebMWQMSamples2021_2060()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}