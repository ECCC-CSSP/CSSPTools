import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebReportType } from 'src/app/models/generated/web/WebReportType.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebTideLocationService } from './web-tide-location.service';

@Injectable({
    providedIn: 'root'
})
export class WebReportTypeService {
    private DoOther: boolean;
    private sub: Subscription;
  
    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webTideLocationService: WebTideLocationService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebReportType(DoOther: boolean) {
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebReportType?.ReportTypeModelList?.length > 0) {
          this.KeepWebReportType();
        }
        else {
          this.sub = this.GetWebReportType().subscribe();
        }
      }
    
    private GetWebReportType() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebReportType: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingReportType[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebReportType/0/1`;
        return this.httpClient.get<WebReportType>(url).pipe(
            map((x: any) => {
                this.UpdateWebReportType(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebTideLocation();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebTideLocation() {
        this.webTideLocationService.DoWebTideLocation(this.DoOther);
    }

    private KeepWebReportType() {
        this.UpdateWebReportType(this.appLoadedService.AppLoaded$?.getValue()?.WebReportType);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebReportType);
        if (this.DoOther) {
            this.DoWebTideLocation();
        }
    }

    private UpdateWebReportType(x: WebReportType) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebReportType: x });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedReportType()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}