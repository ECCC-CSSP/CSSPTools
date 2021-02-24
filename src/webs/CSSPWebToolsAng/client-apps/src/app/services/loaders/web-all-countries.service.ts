import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebAllCountries } from 'src/app/models/generated/web/WebAllCountries.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebAllProvincesService } from './web-all-provinces.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllCountriesService {
    private DoOther: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllProvincesService: WebAllProvincesService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllCountries(DoOther: boolean) {
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebAllCountries?.TVItemAllCountryList?.length > 0) {
          this.KeepWebAllCountries();
        }
        else {
          this.sub = this.GetWebAllCountries().subscribe();
        }
      }
    
    private GetWebAllCountries() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllCountries: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingHelpDoc[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebAllCountries/0/1`;
        return this.httpClient.get<WebAllCountries>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllCountries(x);
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
    
    private KeepWebAllCountries() {
        this.UpdateWebAllCountries(this.appLoadedService.AppLoaded$?.getValue()?.WebAllCountries);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebAllCountries);
        if (this.DoOther) {
            this.DoWebAllProvinces();
        }
    }

    private UpdateWebAllCountries(x: WebAllCountries) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllCountries: x, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedAllCountries()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}