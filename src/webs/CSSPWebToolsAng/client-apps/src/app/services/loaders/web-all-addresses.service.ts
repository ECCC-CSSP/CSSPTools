import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebAllAddresses } from 'src/app/models/generated/web/WebAllAddresses.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllContactsService } from 'src/app/services/loaders/web-all-contacts.service';


@Injectable({
    providedIn: 'root'
})
export class WebAllAddressesService {
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;
  
    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllContactsService: WebAllContactsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllAddresses(DoOther: boolean) {
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebAllAddresses) {
          this.KeepWebAllAddresses();
        }
        else {
          this.sub = this.GetWebAllAddresses().subscribe();
        }
      }
    
    private GetWebAllAddresses() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllAddresses: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebAllAddresses }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebAllAddresses`;
        return this.httpClient.get<WebAllAddresses>(url).pipe(
            map((x: WebAllAddresses) => {
                this.UpdateWebAllAddresses(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebAllContacts();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebAllContacts() {
        this.webAllContactsService.DoWebAllContacts(this.DoOther);
    }

    private KeepWebAllAddresses() {
        this.UpdateWebAllAddresses(this.appLoadedService.AppLoaded$?.getValue()?.WebAllAddresses);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebAllAddresses);
        if (this.DoOther) {
            this.DoWebAllContacts();
        }
    }

    private UpdateWebAllAddresses(x: WebAllAddresses) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebAllAddresses: x });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllAddresses()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }

        }
    }
}