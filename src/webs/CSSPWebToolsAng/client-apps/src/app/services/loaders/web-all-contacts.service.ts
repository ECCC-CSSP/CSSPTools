import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebAllContacts } from 'src/app/models/generated/web/WebAllContacts.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllCountriesService } from 'src/app/services/loaders/web-all-countries.service';


@Injectable({
    providedIn: 'root'
})
export class WebAllContactsService {
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;
  
    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllCountriesService: WebAllCountriesService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllContacts(DoOther: boolean) {
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebAllContacts) {
          this.KeepWebAllContacts();
        }
        else {
          this.sub = this.GetWebAllContacts().subscribe();
        }
      }
    
    private GetWebAllContacts() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllContacts: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebAllContacts }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebAllContacts`;
        return this.httpClient.get<WebAllContacts>(url).pipe(
            map((x: WebAllContacts) => {
                this.UpdateWebAllContacts(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebAllCountries();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebAllCountries() {
        this.webAllCountriesService.DoWebAllCountries(this.DoOther);
    }

    private KeepWebAllContacts() {
        this.UpdateWebAllContacts(this.appLoadedService.AppLoaded$?.getValue()?.WebAllContacts);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebAllContacts);
        if (this.DoOther) {
            this.DoWebAllCountries();
        }
    }

    private UpdateWebAllContacts(x: WebAllContacts) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllContacts: x });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllContacts()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }

        }
    }
}