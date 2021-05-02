import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebMikeScenarios } from 'src/app/models/generated/web/WebMikeScenarios.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class WebMikeScenariosService {
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

    DoWebMikeScenarios(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebMikeScenarios) {
          this.KeepWebMikeScenarios();
        }
        else {
          this.sub = this.GetWebMikeScenarios().subscribe();
        }
      }
    
    private GetWebMikeScenarios() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMikeScenario: {},
        });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebMikeScenarios }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMikeScenarios/${this.TVItemID}`;
        return this.httpClient.get<WebMikeScenarios>(url).pipe(
            map((x: any) => {
                this.UpdateWebMikeScenarios(x);
                console.debug(x);
                if (this.DoOther) {
                    // nothing else to add in the chain
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private KeepWebMikeScenarios() {
        this.UpdateWebMikeScenarios(this.appLoadedService.AppLoaded$?.getValue()?.WebMikeScenarios);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMikeScenarios);
        if (this.DoOther) {
            // nothing else to add in the chain
        }
    }

    private UpdateWebMikeScenarios(x: WebMikeScenarios) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMikeScenario: x,
        });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebMikeScenarios()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
        }
    }
}