import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebHydrometricSite } from 'src/app/models/generated/web/WebHydrometricSite.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';


@Injectable({
    providedIn: 'root'
})
export class WebHydrometricSiteService {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebHydrometricSite(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricSite?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
          this.KeepWebHydrometricSite();
        }
        else {
          this.sub = this.GetWebHydrometricSite().subscribe();
        }
      }
    
    private GetWebHydrometricSite() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebHydrometricSite: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingProvinceHydrometricSite[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebHydrometricSite/${this.TVItemID}/1`;
        return this.httpClient.get<WebHydrometricSite>(url).pipe(
            map((x: any) => {
                this.UpdateWebHydrometricSite(x);
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

    private KeepWebHydrometricSite() {
        this.UpdateWebHydrometricSite(this.appLoadedService.AppLoaded$?.getValue()?.WebHydrometricSite);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebHydrometricSite);
        if (this.DoOther) {
            // nothing more to add in the chain
        }
    }

    private UpdateWebHydrometricSite(x: WebHydrometricSite) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebHydrometricSite: x, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedProvince()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedHydrometricSite()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}