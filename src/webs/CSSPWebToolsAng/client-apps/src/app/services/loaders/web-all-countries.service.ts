import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebAllCountries } from 'src/app/models/generated/web/WebAllCountries.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllEmailsService } from 'src/app/services/loaders/web-all-emails.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllCountriesService {
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllEmailsService: WebAllEmailsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllCountries(DoOther: boolean) {
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebAllCountries) {
          this.KeepWebAllCountries();
        }
        else {
          this.sub = this.GetWebAllCountries().subscribe();
        }
      }
    
    private GetWebAllCountries() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllCountries: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebAllCountries }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebAllCountries`;
        return this.httpClient.get<WebAllCountries>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllCountries(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebAllEmails();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebAllEmails() {
        this.webAllEmailsService.DoWebAllEmails(this.DoOther);
    }
    
    private KeepWebAllCountries() {
        this.UpdateWebAllCountries(this.appLoadedService.AppLoaded$?.getValue()?.WebAllCountries);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebAllCountries);
        if (this.DoOther) {
            this.DoWebAllEmails();
        }
    }

    private UpdateWebAllCountries(x: WebAllCountries) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllCountries: x, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllCountries()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}