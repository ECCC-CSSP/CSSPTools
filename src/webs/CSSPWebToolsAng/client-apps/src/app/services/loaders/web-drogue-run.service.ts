import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebDrogueRun } from 'src/app/models/generated/web/WebDrogueRun.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebMWQMSampleService } from './web-mwqm-samples.service';
import { WebTypeYearEnum } from 'src/app/enums/generated/WebTypeYearEnum';

@Injectable({
    providedIn: 'root'
})
export class WebDrogueRunService {
    private DoOther: boolean;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webMWQMSampleService: WebMWQMSampleService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    GetWebDrogueRun(TVItemID: number, DoOther: boolean) {
        this.DoOther = DoOther;
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebDrogueRun: {}, BreadCrumbWebBaseList: [] });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingSubsectorDrogueRun[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebDrogueRun/${TVItemID}/1`;
        return this.httpClient.get<WebDrogueRun>(url).pipe(
            map((x: any) => {
                this.UpdateWebDrogueRun(x);
                console.debug(x);
                if (DoOther) {
                    this.GetWebMWQMSample(TVItemID, WebTypeYearEnum.Year1980);
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    GetWebMWQMSample(TVItemID: number, WebTypeYear: WebTypeYearEnum) {
        this.webMWQMSampleService.GetWebMWQMSample(TVItemID, WebTypeYear, this.DoOther).subscribe();
    }

    UpdateWebDrogueRun(x: WebDrogueRun) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebDrogueRun: x, BreadCrumbWebBaseList: x?.TVItemParentList, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedSubsector()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedDrogueRun()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}