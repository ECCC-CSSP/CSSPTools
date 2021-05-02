import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebPolSourceSites } from 'src/app/models/generated/web/WebPolSourceSites.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { HistoryService } from 'src/app/services/helpers/history.service';
import { WebDrogueRunsService } from 'src/app/services/loaders/web-drogue-runs.service';

@Injectable({
    providedIn: 'root'
})
export class WebPolSourceSitesService {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;
  
    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webDrogueRunsService: WebDrogueRunsService,
        private componentDataLoadedService: ComponentDataLoadedService,
        private historyService: HistoryService) {
    }

    DoWebPolSourceSites(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSites) {
          this.KeepWebPolSourceSites();
        }
        else {
          this.sub = this.GetWebPolSourceSites().subscribe();
        }
      }
    
    private GetWebPolSourceSites() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebPolSourceSites: {},
        });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebPolSourceSites }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebPolSourceSites/${this.TVItemID}`;
        return this.httpClient.get<WebPolSourceSites>(url).pipe(
            map((x: any) => {
                this.UpdateWebPolSourceSites(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebDrogueRuns();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebDrogueRuns() {
        this.webDrogueRunsService.DoWebDrogueRuns(this.TVItemID, this.DoOther);
    }

    private KeepWebPolSourceSites() {
        this.UpdateWebPolSourceSites(this.appLoadedService.AppLoaded$?.getValue()?.WebPolSourceSites);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebPolSourceSites);
        if (this.DoOther) {
            this.DoWebDrogueRuns();
        }
    }

    private UpdateWebPolSourceSites(x: WebPolSourceSites) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebPolSourceSites: x,
        });

        this.historyService.AddHistory(this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSites?.TVItemModel);

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebSubsector()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebPolSourceSites()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}