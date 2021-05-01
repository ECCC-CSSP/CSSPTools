import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebAllTideLocations } from 'src/app/models/generated/web/WebAllTideLocations.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllTideLocationsService {
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllTideLocations(DoOther: boolean) {
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebAllTideLocations?.TideLocationList?.length > 0) {
            this.KeepWebAllTideLocations();
        }
        else {
            this.sub = this.GetWebAllTideLocations().subscribe();
        }
    }

    private GetWebAllTideLocations() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllTideLocations: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebAllTideLocations }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebAllTideLocations`;
        return this.httpClient.get<WebAllTideLocations>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllTideLocations(x);
                console.debug(x);
                if (this.DoOther) {
                    // nothing more to add in the chain
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private KeepWebAllTideLocations() {
        this.UpdateWebAllTideLocations(this.appLoadedService.AppLoaded$?.getValue()?.WebAllTideLocations);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebAllTideLocations);
        if (this.DoOther) {
            // nothing more to add in the chain
        }
    }

    private UpdateWebAllTideLocations(x: WebAllTideLocations) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllTideLocations: x });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllTideLocations()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}