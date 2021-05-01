import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebAllProvinces } from 'src/app/models/generated/web/WebAllProvinces.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllReportTypesService } from 'src/app/services/loaders/web-all-report-types.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllProvincesService {
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllReportTypesService: WebAllReportTypesService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllProvinces(DoOther: boolean) {
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebAllProvinces) {
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
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebAllProvinces }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebAllProvinces`;
        return this.httpClient.get<WebAllProvinces>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllProvinces(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebAllReportTypes();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebAllReportTypes() {
        this.webAllReportTypesService.DoWebAllReportTypes(this.DoOther);
    }
    
    private KeepWebAllProvinces() {
        this.UpdateWebAllProvinces(this.appLoadedService.AppLoaded$?.getValue()?.WebAllProvinces);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebAllProvinces);
        if (this.DoOther) {
            this.DoWebAllReportTypes();
        }
    }

    private UpdateWebAllProvinces(x: WebAllProvinces) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllProvinces: x, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllProvinces()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}