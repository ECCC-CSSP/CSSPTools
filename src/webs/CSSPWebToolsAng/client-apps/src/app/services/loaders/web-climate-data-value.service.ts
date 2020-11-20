import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebClimateDataValue } from 'src/app/models/generated/web/WebClimateDataValue.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';


@Injectable({
    providedIn: 'root'
})
export class WebClimateDataValueService {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebClimateDataValue(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebClimateDataValue?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
          this.KeepWebClimateDataValue();
        }
        else {
          this.sub = this.GetWebClimateDataValue().subscribe();
        }
      }
    
    private GetWebClimateDataValue() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebClimateDataValue: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingClimateData[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebClimateDataValue/${this.TVItemID}/1`;
        return this.httpClient.get<WebClimateDataValue>(url).pipe(
            map((x: any) => {
                this.UpdateWebClimateDataValue(x);
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

    private KeepWebClimateDataValue() {
        this.UpdateWebClimateDataValue(this.appLoadedService.AppLoaded$?.getValue()?.WebClimateDataValue);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebClimateDataValue);
        if (this.DoOther) {
            // nothing more to add in the chain
        }
    }

    private UpdateWebClimateDataValue(x: WebClimateDataValue) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebClimateDataValue: x, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedClimateData()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
        }
    }
}