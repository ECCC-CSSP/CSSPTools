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
import { WebAllHelpDocsService } from 'src/app/services/loaders/web-all-help-docs.service';
import { WebAllEmails } from 'src/app/models/generated/web/WebAllEmails.model';

@Injectable({
    providedIn: 'root'
})
export class WebAllEmailsService {
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllHelpDocsServices: WebAllHelpDocsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllEmails(DoOther: boolean) {
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebAllEmails) {
          this.KeepWebAllEmails();
        }
        else {
          this.sub = this.GetWebAllEmails().subscribe();
        }
      }
    
    private GetWebAllEmails() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllEmails: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebAllEmails }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebAllEmails`;
        return this.httpClient.get<WebAllEmails>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllEmails(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebAllHelpDocs();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebAllHelpDocs() {
        this.webAllHelpDocsServices.DoWebAllHelpDocs(this.DoOther);
    }
    
    private KeepWebAllEmails() {
        this.UpdateWebAllEmails(this.appLoadedService.AppLoaded$?.getValue()?.WebAllEmails);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebAllHelpDocs);
        if (this.DoOther) {
            this.DoWebAllHelpDocs();
        }
    }

    private UpdateWebAllEmails(x: WebAllEmails) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllEmails: x, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllEmails()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}