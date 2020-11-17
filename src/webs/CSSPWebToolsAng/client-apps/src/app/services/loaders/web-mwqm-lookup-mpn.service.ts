import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebMWQMLookupMPN } from 'src/app/models/generated/web/WebMWQMLookupMPN.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebPolSourceGroupingService } from './web-pol-source-grouping.service';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMLookupMPNService {
    private DoOther: boolean;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webPolSourceGroupingService: WebPolSourceGroupingService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    GetWebMWQMLookupMPN(DoOther: boolean) {
        this.DoOther = DoOther;
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMLookupMPN: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingMWQMLookupMPN[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appStateService.AppState$.getValue().Language}-CA/Read/WebMWQMLookupMPN/0/1`;
        return this.httpClient.get<WebMWQMLookupMPN>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMLookupMPN(x);
                console.debug(x);
                if (DoOther) {
                    this.GetWebPolSourceGrouping();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    GetWebPolSourceGrouping() {
        this.webPolSourceGroupingService.GetWebPolSourceGrouping(this.DoOther).subscribe();
    }

    UpdateWebMWQMLookupMPN(x: WebMWQMLookupMPN) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMLookupMPN: x });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedMWQMLookupMPN()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}