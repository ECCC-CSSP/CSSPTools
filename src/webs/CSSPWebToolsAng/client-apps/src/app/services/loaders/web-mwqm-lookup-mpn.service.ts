import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
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
    private sub: Subscription;
 
    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webPolSourceGroupingService: WebPolSourceGroupingService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebMWQMLookupMPN(DoOther: boolean) {
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMLookupMPN?.MWQMLookupMPNList?.length > 0) {
          this.KeepWebMWQMLookupMPN();
        }
        else {
          this.sub = this.GetWebMWQMLookupMPN().subscribe();
        }
      }
    
    private GetWebMWQMLookupMPN() {
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
                if (this.DoOther) {
                    this.DoWebPolSourceGrouping();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    DoWebPolSourceGrouping() {
        this.webPolSourceGroupingService.DoWebPolSourceGrouping(this.DoOther);
    }

    private KeepWebMWQMLookupMPN() {
        this.UpdateWebMWQMLookupMPN(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMLookupMPN);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMLookupMPN);
        if (this.DoOther) {
            this.DoWebPolSourceGrouping();
        }
    }

    private UpdateWebMWQMLookupMPN(x: WebMWQMLookupMPN) {
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