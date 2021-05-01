import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebLabSheets} from 'src/app/models/generated/web/WebLabSheets.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebMWQMSamples1980_2020Service } from 'src/app/services/loaders/web-mwqm-samples-1980-2020.service';

@Injectable({
    providedIn: 'root'
})
export class WebLabSheetsService {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webMWQMSamples1980_2020Service: WebMWQMSamples1980_2020Service,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebLabSheets(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebLabSheets) {
            this.KeepWebLabSheets();
        }
        else {
            this.sub = this.GetWebLabSheets().subscribe();
        }
    }

    private GetWebLabSheets() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebLabSheets: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebLabSheets }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebLabSheets/${this.TVItemID}`;
        return this.httpClient.get<WebLabSheets>(url).pipe(
            map((x: any) => {
                this.UpdateWebLabSheets(x);
                console.debug(x);
                if (this.DoOther) {
                    //this.DoWebMWQMSamples1980_2020();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    // private DoWebMWQMSamples1980_2020() {
    //     this.webMWQMSamples1980_2020Service.DoWebMWQMSamples1980_2020(this.TVItemID);
    // }

    private KeepWebLabSheets() {
        this.UpdateWebLabSheets(this.appLoadedService.AppLoaded$?.getValue()?.WebLabSheets);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebLabSheets);
        if (this.DoOther) {
            //this.DoWebMWQMSamples1980_2020();
        }
    }

    private UpdateWebLabSheets(x: WebLabSheets) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebLabSheets: x });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebSubsector()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebLabSheets()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}