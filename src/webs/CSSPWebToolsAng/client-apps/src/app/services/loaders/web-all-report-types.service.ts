import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebAllReportTypes } from 'src/app/models/generated/web/WebAllReportTypes.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllTelsService } from 'src/app/services/loaders/web-all-tels.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllReportTypesService {
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllTelsService: WebAllTelsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllReportTypes(DoOther: boolean) {
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebAllReportTypes?.ReportTypeModelList?.length > 0) {
          this.KeepWebAllReportTypes();
        }
        else {
          this.sub = this.GetWebAllReportTypes().subscribe();
        }
      }
    
    private GetWebAllReportTypes() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllReportTypes: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebAllReportTypes }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebAllReportTypes`;
        return this.httpClient.get<WebAllReportTypes>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllReportTypes(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebAllTels();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebAllTels() {
        this.webAllTelsService.DoWebAllTels(this.DoOther);
    }

    private KeepWebAllReportTypes() {
        this.UpdateWebAllReportTypes(this.appLoadedService.AppLoaded$?.getValue()?.WebAllReportTypes);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebAllReportTypes);
        if (this.DoOther) {
            this.DoWebAllTels();
        }
    }

    private UpdateWebAllReportTypes(x: WebAllReportTypes) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllReportTypes: x });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllReportTypes()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}