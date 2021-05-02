import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebDrogueRuns} from 'src/app/models/generated/web/WebDrogueRuns.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebMWQMSamplesService } from './web-mwqm-samples.service';

@Injectable({
    providedIn: 'root'
})
export class WebDrogueRunsService {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webMWQMSamplesService: WebMWQMSamplesService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebDrogueRuns(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebDrogueRuns) {
            this.KeepWebDrogueRuns();
        }
        else {
            this.sub = this.GetWebDrogueRuns().subscribe();
        }
    }

    private GetWebDrogueRuns() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebDrogueRuns: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebDrogueRuns }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebDrogueRuns/${this.TVItemID}`;
        return this.httpClient.get<WebDrogueRuns>(url).pipe(
            map((x: any) => {
                this.UpdateWebDrogueRuns(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebMWQMSamples();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebMWQMSamples() {
        this.webMWQMSamplesService.DoWebMWQMSamples(this.TVItemID, true);
    }

    private KeepWebDrogueRuns() {
        this.UpdateWebDrogueRuns(this.appLoadedService.AppLoaded$?.getValue()?.WebDrogueRuns);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebDrogueRuns);
        if (this.DoOther) {
            this.DoWebMWQMSamples();
        }
    }

    private UpdateWebDrogueRuns(x: WebDrogueRuns) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebDrogueRuns: x });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebSubsector()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebDrogueRuns()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}