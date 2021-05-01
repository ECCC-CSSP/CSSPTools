import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebAllPolSourceSiteEffectTerms } from 'src/app/models/generated/web/WebAllPolSourceSiteEffectTerms.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllProvincesService } from 'src/app/services/loaders/web-all-provinces.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllPolSourceSiteEffectTermsService {
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllProvincesService: WebAllProvincesService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllPolSourceSiteEffectTerms(DoOther: boolean) {
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebAllPolSourceSiteEffectTerms?.PolSourceSiteEffectTermList?.length > 0) {
            this.KeepWebAllPolSourceSiteEffectTerms();
        }
        else {
            this.sub = this.GetWebAllPolSourceSiteEffectTerms().subscribe();
        }
    }

    private GetWebAllPolSourceSiteEffectTerms() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllPolSourceSiteEffectTerms: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebAllPolSourceSiteEffectTerms }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebAllPolSourceSiteEffectTerms`;
        return this.httpClient.get<WebAllPolSourceSiteEffectTerms>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllPolSourceSiteEffectTerms(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebAllProvinces();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebAllProvinces() {
        this.webAllProvincesService.DoWebAllProvinces(this.DoOther);
    }

    private KeepWebAllPolSourceSiteEffectTerms() {
        this.UpdateWebAllPolSourceSiteEffectTerms(this.appLoadedService.AppLoaded$?.getValue()?.WebAllPolSourceSiteEffectTerms);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebAllPolSourceSiteEffectTerms);
        if (this.DoOther) {
            this.DoWebAllProvinces();
        }
    }

    private UpdateWebAllPolSourceSiteEffectTerms(x: WebAllPolSourceSiteEffectTerms) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllPolSourceSiteEffectTerms: x });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebPolSourceSiteEffectTerms()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}