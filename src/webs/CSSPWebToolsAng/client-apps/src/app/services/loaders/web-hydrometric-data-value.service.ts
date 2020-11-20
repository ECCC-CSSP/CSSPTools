import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebHydrometricDataValue } from 'src/app/models/generated/web/WebHydrometricDataValue.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class WebHydrometricDataValueService {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;
  
    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebHydrometricDataValue(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricDataValue?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
          this.KeepWebHydrometricDataValue();
        }
        else {
          this.sub = this.GetWebHydrometricDataValue().subscribe();
        }
      }
    
    private GetWebHydrometricDataValue() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebHydrometricDataValue: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingHydrometricData[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebHydrometricDataValue/${this.TVItemID}/1`;
        return this.httpClient.get<WebHydrometricDataValue>(url).pipe(
            map((x: any) => {
                this.UpdateWebHydrometricDataValue(x);
                console.debug(x);
                if (this.DoOther)
                {
                    // nothing else to add to the chain
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private KeepWebHydrometricDataValue() {
        this.UpdateWebHydrometricDataValue(this.appLoadedService.AppLoaded$?.getValue()?.WebHydrometricDataValue);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebHydrometricDataValue);
        if (this.DoOther) {
            // nothing more to add in the chain
        }
    }

    private UpdateWebHydrometricDataValue(x: WebHydrometricDataValue) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebHydrometricDataValue: x });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedHydrometricData()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
        }
    }
}