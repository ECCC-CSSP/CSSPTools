import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
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
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webReportTypeService: WebReportTypeService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebPolSourceSiteEffectTerm(DoOther: boolean) {
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSiteEffectTerm?.PolSourceSiteEffectTermList?.length > 0) {
            this.KeepWebPolSourceSiteEffectTerm();
        }
        else {
            this.sub = this.GetWebPolSourceSiteEffectTerm().subscribe();
        }
    }

    private GetWebPolSourceSiteEffectTerm() {
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
                if (this.DoOther) {
                    this.DoWebReportType();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebReportType() {
        this.webReportTypeService.DoWebReportType(this.DoOther);
    }

    private KeepWebPolSourceSiteEffectTerm() {
        this.UpdateWebPolSourceSiteEffectTerm(this.appLoadedService.AppLoaded$?.getValue()?.WebPolSourceSiteEffectTerm);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebPolSourceSiteEffectTerm);
        if (this.DoOther) {
            this.DoWebReportType();
        }
    }

    private UpdateWebPolSourceSiteEffectTerm(x: WebPolSourceSiteEffectTerm) {
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