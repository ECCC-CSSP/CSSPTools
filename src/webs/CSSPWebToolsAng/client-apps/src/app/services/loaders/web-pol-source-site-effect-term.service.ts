import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebPolSourceSiteEffectTerm } from 'src/app/models/generated/web/WebPolSourceSiteEffectTerm.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebReportTypeService } from './web-report-type.service';

@Injectable({
    providedIn: 'root'
})
export class WebPolSourceSiteEffectTermService {
    private DoOther: boolean;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webReportTypeService: WebReportTypeService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    GetWebPolSourceSiteEffectTerm(DoOther: boolean) {
        this.DoOther = DoOther;
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebPolSourceSiteEffectTerm: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingPolSourceSiteEffectTerm[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebPolSourceSiteEffectTerm/0/1`;
        return this.httpClient.get<WebPolSourceSiteEffectTerm>(url).pipe(
            map((x: any) => {
                this.UpdateWebPolSourceSiteEffectTerm(x);
                console.debug(x);
                if (DoOther) {
                    this.GetWebReportType();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    GetWebReportType() {
        this.webReportTypeService.GetWebReportType(this.DoOther).subscribe();
    }

    UpdateWebPolSourceSiteEffectTerm(x: WebPolSourceSiteEffectTerm) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebPolSourceSiteEffectTerm: x });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedPolSourceSiteEffectTerm()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}