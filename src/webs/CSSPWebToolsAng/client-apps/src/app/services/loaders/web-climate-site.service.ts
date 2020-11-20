import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebClimateSite } from 'src/app/models/generated/web/WebClimateSite.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebHydrometricSiteService } from './web-hydrometric-site.service';


@Injectable({
    providedIn: 'root'
})
export class WebClimateSiteService {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;
  
    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webHydrometricSiteService: WebHydrometricSiteService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebClimateSite(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebClimateSite?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
          this.KeepWebClimateSite();
        }
        else {
          this.sub = this.GetWebClimateSite().subscribe();
        }
      }
    
    private GetWebClimateSite() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebClimateSite: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingProvinceClimateSite[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebClimateSite/${this.TVItemID}/1`;
        return this.httpClient.get<WebClimateSite>(url).pipe(
            map((x: any) => {
                this.UpdateWebClimateSite(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebHydrometricSite();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebHydrometricSite() {
        this.webHydrometricSiteService.DoWebHydrometricSite(this.TVItemID, this.DoOther);
    }

    private KeepWebClimateSite() {
        this.UpdateWebClimateSite(this.appLoadedService.AppLoaded$?.getValue()?.WebClimateSite);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebClimateSite);
        if (this.DoOther) {
            this.DoWebHydrometricSite();
        }
    }

    private UpdateWebClimateSite(x: WebClimateSite) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebClimateSite: x, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedProvince()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedClimateSite()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}