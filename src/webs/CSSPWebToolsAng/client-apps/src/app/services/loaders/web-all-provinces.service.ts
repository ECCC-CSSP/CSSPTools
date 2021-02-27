import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebAllProvinces } from 'src/app/models/generated/web/WebAllProvinces.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebAllMunicipalitiesService } from './web-all-municipalities.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllProvincesService {
    private DoOther: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllMunicipalitiesService: WebAllMunicipalitiesService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllProvinces(DoOther: boolean) {
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebAllProvinces?.TVItemAllProvinceList?.length > 0) {
          this.KeepWebAllProvinces();
        }
        else {
          this.sub = this.GetWebAllProvinces().subscribe();
        }
      }
    
    private GetWebAllProvinces() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllProvinces: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingHelpDoc[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebAllProvinces/0/1`;
        return this.httpClient.get<WebAllProvinces>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllProvinces(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebAllMunicipalities();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebAllMunicipalities() {
        this.webAllMunicipalitiesService.DoWebAllMunicipalities(this.DoOther);
    }
    
    private KeepWebAllProvinces() {
        this.UpdateWebAllProvinces(this.appLoadedService.AppLoaded$?.getValue()?.WebAllProvinces);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebAllProvinces);
        if (this.DoOther) {
            this.DoWebAllMunicipalities();
        }
    }

    private UpdateWebAllProvinces(x: WebAllProvinces) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllProvinces: x, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedAllProvinces()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}