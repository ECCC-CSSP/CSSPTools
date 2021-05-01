import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllTels } from 'src/app/models/generated/web/WebAllTels.model';
import { WebAllTideLocationsService } from 'src/app/services/loaders/web-all-tide-locations.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllTelsService {
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllTideLocationsServices: WebAllTideLocationsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllTels(DoOther: boolean) {
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebAllTels) {
          this.KeepWebAllTels();
        }
        else {
          this.sub = this.GetWebAllTels().subscribe();
        }
      }
    
    private GetWebAllTels() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllTels: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebAllTels }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebAllTels`;
        return this.httpClient.get<WebAllTels>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllTels(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebAllTideLocations();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebAllTideLocations() {
        this.webAllTideLocationsServices.DoWebAllTideLocations(this.DoOther);
    }
    
    private KeepWebAllTels() {
        this.UpdateWebAllTels(this.appLoadedService.AppLoaded$?.getValue()?.WebAllTels);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebAllHelpDocs);
        if (this.DoOther) {
            this.DoWebAllTideLocations();
        }
    }

    private UpdateWebAllTels(x: WebAllTels) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllTels: x, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllTels()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}