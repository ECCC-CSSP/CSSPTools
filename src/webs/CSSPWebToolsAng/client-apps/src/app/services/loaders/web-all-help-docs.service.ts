import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebAllHelpDocs } from 'src/app/models/generated/web/WebAllHelpDocs.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllMunicipalitiesService } from 'src/app/services/loaders/web-all-municipalities.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllHelpDocsService {
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllMunicipalitiesServices: WebAllMunicipalitiesService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllHelpDocs(DoOther: boolean) {
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebAllHelpDocs?.HelpDocList?.length > 0) {
          this.KeepWebAllHelpDocs();
        }
        else {
          this.sub = this.GetWebAllHelpDocs().subscribe();
        }
      }
    
    private GetWebAllHelpDocs() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllHelpDocs: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebAllHelpDocs }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebAllHelpDocs/0/1`;
        return this.httpClient.get<WebAllHelpDocs>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllHelpDocs(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebAllMunicipalities();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebAllMunicipalities() {
        this.webAllMunicipalitiesServices.DoWebAllMunicipalities(this.DoOther);
    }
    
    private KeepWebAllHelpDocs() {
        this.UpdateWebAllHelpDocs(this.appLoadedService.AppLoaded$?.getValue()?.WebAllHelpDocs);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebAllHelpDocs);
        if (this.DoOther) {
            this.DoWebAllMunicipalities();
        }
    }

    private UpdateWebAllHelpDocs(x: WebAllHelpDocs) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllHelpDocs: x, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllHelpDocs()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}