import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebTideLocation } from 'src/app/models/generated/web/WebTideLocation.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class WebTideLocationService {
    private DoOther: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebTideLocation(DoOther: boolean) {
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebTideLocation?.TideLocationList?.length > 0) {
            this.KeepWebTideLocation();
        }
        else {
            this.sub = this.GetWebTideLocation().subscribe();
        }
    }

    private GetWebTideLocation() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebTideLocation: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingTideLocation[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebTideLocation/0/1`;
        return this.httpClient.get<WebTideLocation>(url).pipe(
            map((x: any) => {
                this.UpdateWebTideLocation(x);
                console.debug(x);
                if (this.DoOther) {
                    // nothing more to add in the chain
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private KeepWebTideLocation() {
        this.UpdateWebTideLocation(this.appLoadedService.AppLoaded$?.getValue()?.WebTideLocation);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebTideLocation);
        if (this.DoOther) {
            // nothing more to add in the chain
        }
    }

    private UpdateWebTideLocation(x: WebTideLocation) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebTideLocation: x });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedTideLocation()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}