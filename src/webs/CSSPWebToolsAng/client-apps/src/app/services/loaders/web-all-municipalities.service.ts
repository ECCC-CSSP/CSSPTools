import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebAllMunicipalities } from 'src/app/models/generated/web/WebAllMunicipalities.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllMWQMLookupMPNsService } from 'src/app/services/loaders/web-all-mwqm-lookup-mpns.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllMunicipalitiesService {
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllMWQMLookupMPNsService: WebAllMWQMLookupMPNsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllMunicipalities(DoOther: boolean) {
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebAllMunicipalities) {
          this.KeepWebAllMunicipalities();
        }
        else {
          this.sub = this.GetWebAllMunicipalities().subscribe();
        }
      }
    
    private GetWebAllMunicipalities() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllMunicipalities: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebAllMunicipalities }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebAllMunicipalities`;
        return this.httpClient.get<WebAllMunicipalities>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllMunicipalities(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebAllMWQMLookupMPNs();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebAllMWQMLookupMPNs() {
        this.webAllMWQMLookupMPNsService.DoWebAllMWQMLookupMPNs(this.DoOther);
    }
    
    private KeepWebAllMunicipalities() {
        this.UpdateWebAllMunicipalities(this.appLoadedService.AppLoaded$?.getValue()?.WebAllMunicipalities);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebAllMunicipalities);
        if (this.DoOther) {
            this.DoWebAllMWQMLookupMPNs();
        }
    }

    private UpdateWebAllMunicipalities(x: WebAllMunicipalities) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllMunicipalities: x, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllMunicipalities()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}