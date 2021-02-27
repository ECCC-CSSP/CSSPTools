import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebAllPolSourceGroupings } from 'src/app/models/generated/web/WebAllPolSourceGroupings.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebAllPolSourceSiteEffectTermsService } from './web-all-pol-source-site-effect-terms.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllPolSourceGroupingsService {
    private DoOther: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllPolSourceSiteEffectTermsService: WebAllPolSourceSiteEffectTermsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllPolSourceGroupings(DoOther: boolean) {
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebAllPolSourceGroupings?.PolSourceGroupingList?.length > 0) {
            this.KeepWebAllPolSourceGroupings();
        }
        else {
            this.sub = this.GetWebAllPolSourceGroupings().subscribe();
        }
    }

    private GetWebAllPolSourceGroupings() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllPolSourceGroupings: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingPolSourceGrouping[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebAllPolSourceGroupings/0/1`;
        return this.httpClient.get<WebAllPolSourceGroupings>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllPolSourceGroupings(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebAllPolSourceSiteEffectTerms();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebAllPolSourceSiteEffectTerms() {
        this.webAllPolSourceSiteEffectTermsService.DoWebAllPolSourceSiteEffectTerms(this.DoOther);
    }

    private KeepWebAllPolSourceGroupings() {
        this.UpdateWebAllPolSourceGroupings(this.appLoadedService.AppLoaded$?.getValue()?.WebAllPolSourceGroupings);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebAllPolSourceGroupings);
        if (this.DoOther) {
            this.DoWebAllPolSourceSiteEffectTerms();
        }
    }

    private UpdateWebAllPolSourceGroupings(x: WebAllPolSourceGroupings) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllPolSourceGroupings: x });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedPolSourceGrouping()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}