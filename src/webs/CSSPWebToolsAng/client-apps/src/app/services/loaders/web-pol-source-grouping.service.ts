import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebPolSourceGrouping } from 'src/app/models/generated/web/WebPolSourceGrouping.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebPolSourceSiteEffectTermService } from './web-pol-source-site-effect-term.service';

@Injectable({
    providedIn: 'root'
})
export class WebPolSourceGroupingService {
    private DoOther: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webPolSourceSiteEffectTermService: WebPolSourceSiteEffectTermService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebPolSourceGrouping(DoOther: boolean) {
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceGrouping?.PolSourceGroupingList?.length > 0) {
            this.KeepWebPolSourceGrouping();
        }
        else {
            this.sub = this.GetWebPolSourceGrouping().subscribe();
        }
    }

    private GetWebPolSourceGrouping() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebPolSourceGrouping: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingPolSourceGrouping[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebPolSourceGrouping/0/1`;
        return this.httpClient.get<WebPolSourceGrouping>(url).pipe(
            map((x: any) => {
                this.UpdateWebPolSourceGrouping(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebPolSourceSiteEffectTerm();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebPolSourceSiteEffectTerm() {
        this.webPolSourceSiteEffectTermService.DoWebPolSourceSiteEffectTerm(this.DoOther);
    }

    private KeepWebPolSourceGrouping() {
        this.UpdateWebPolSourceGrouping(this.appLoadedService.AppLoaded$?.getValue()?.WebPolSourceGrouping);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebPolSourceGrouping);
        if (this.DoOther) {
            this.DoWebPolSourceSiteEffectTerm();
        }
    }

    private UpdateWebPolSourceGrouping(x: WebPolSourceGrouping) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebPolSourceGrouping: x });

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