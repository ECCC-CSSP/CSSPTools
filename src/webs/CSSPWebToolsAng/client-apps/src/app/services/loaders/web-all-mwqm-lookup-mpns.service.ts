import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebAllMWQMLookupMPNs } from 'src/app/models/generated/web/WebAllMWQMLookupMPNs.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebAllPolSourceGroupingsService } from './web-all-pol-source-groupings.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllMWQMLookupMPNsService {
    private DoOther: boolean;
    private sub: Subscription;
 
    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllPolSourceGroupingsService: WebAllPolSourceGroupingsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllMWQMLookupMPNs(DoOther: boolean) {
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebAllMWQMLookupMPNs?.MWQMLookupMPNList?.length > 0) {
          this.KeepWebAllMWQMLookupMPNs();
        }
        else {
          this.sub = this.GetWebAllMWQMLookupMPNs().subscribe();
        }
      }
    
    private GetWebAllMWQMLookupMPNs() {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllMWQMLookupMPNs: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingMWQMLookupMPN[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appStateService.AppState$.getValue().Language}-CA/Read/WebAllMWQMLookupMPNs/0/1`;
        return this.httpClient.get<WebAllMWQMLookupMPNs>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllMWQMLookupMPNs(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebAllPolSourceGroupings();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    DoWebAllPolSourceGroupings() {
        this.webAllPolSourceGroupingsService.DoWebAllPolSourceGroupings(this.DoOther);
    }

    private KeepWebAllMWQMLookupMPNs() {
        this.UpdateWebAllMWQMLookupMPNs(this.appLoadedService.AppLoaded$?.getValue()?.WebAllMWQMLookupMPNs);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebAllMWQMLookupMPNs);
        if (this.DoOther) {
            this.DoWebAllPolSourceGroupings();
        }
    }

    private UpdateWebAllMWQMLookupMPNs(x: WebAllMWQMLookupMPNs) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllMWQMLookupMPNs: x });

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