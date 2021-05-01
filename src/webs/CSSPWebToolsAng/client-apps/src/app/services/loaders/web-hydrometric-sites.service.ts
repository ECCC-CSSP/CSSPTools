import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebHydrometricSites } from 'src/app/models/generated/web/WebHydrometricSites.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';


@Injectable({
    providedIn: 'root'
})
export class WebHydrometricSitesService {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebHydrometricSites(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricSites) {
          this.KeepWebHydrometricSites();
        }
        else {
          this.sub = this.GetWebHydrometricSites().subscribe();
        }
      }
    
    private GetWebHydrometricSites() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebHydrometricSites: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebHydrometricSites }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebHydrometricSites/${this.TVItemID}`;
        return this.httpClient.get<WebHydrometricSites>(url).pipe(
            map((x: any) => {
                this.UpdateWebHydrometricSites(x);
                console.debug(x);
                if (this.DoOther) {
                    // nothing else to add to the chain
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private KeepWebHydrometricSites() {
        this.UpdateWebHydrometricSites(this.appLoadedService.AppLoaded$?.getValue()?.WebHydrometricSites);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebHydrometricSites);
        if (this.DoOther) {
            // nothing more to add in the chain
        }
    }

    private UpdateWebHydrometricSites(x: WebHydrometricSites) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebHydrometricSites: x, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebProvince()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebHydrometricSites()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}