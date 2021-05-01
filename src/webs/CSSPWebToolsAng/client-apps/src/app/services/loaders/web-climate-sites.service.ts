import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebClimateSites } from 'src/app/models/generated/web/WebClimateSites.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebHydrometricSitesService } from 'src/app/services/loaders/web-hydrometric-sites.service';


@Injectable({
    providedIn: 'root'
})
export class WebClimateSitesService {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webHydrometricSitesService: WebHydrometricSitesService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebClimateSites(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebClimateSites) {
          this.KeepWebClimateSites();
        }
        else {
          this.sub = this.GetWebClimateSites().subscribe();
        }
      }
    
    private GetWebClimateSites() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebClimateSites: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebClimateSites }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebClimateSites/${this.TVItemID}`;
        return this.httpClient.get<WebClimateSites>(url).pipe(
            map((x: any) => {
                this.UpdateWebClimateSites(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebHydrometricSites();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebHydrometricSites() {
        this.webHydrometricSitesService.DoWebHydrometricSites(this.TVItemID, this.DoOther);
    }

    private KeepWebClimateSites() {
        this.UpdateWebClimateSites(this.appLoadedService.AppLoaded$?.getValue()?.WebClimateSites);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebClimateSites);
        if (this.DoOther) {
            this.DoWebHydrometricSites();
        }
    }

    private UpdateWebClimateSites(x: WebClimateSites) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebClimateSites: x, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebProvince()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebClimateSites()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}