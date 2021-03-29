import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { Contact } from 'src/app/models/generated/db/Contact.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';

declare var window: any;

@Injectable({
    providedIn: 'root'
})
export class LoggedInContactService {
    private sub: Subscription;
    private GoogleJSLoaded;

    languageEnum = GetLanguageEnum();

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService) {
    }

    DoLoggedInContact() {
        this.sub ? this.sub.unsubscribe() : null;   
        this.sub = this.GetLoggedInContact().subscribe();
    }
    
    DoGoogleJS() {
        if (this.appStateService.AppState$.getValue()?.GoogleJSLoaded) {
            // just keep the Google JS we already have in memory
        }
        else {
            this.LoadGoogleJS();
        }
    }

    private LoadGoogleJS() {
        if (!this.GoogleJSLoaded) { // load once

            if (this.appLoadedService.AppLoaded$?.getValue()?.LoggedInContact) {
                this.GoogleJSLoaded = new Promise((resolve) => {
                    window['__onGapiLoaded'] = (ev) => {
                        console.log('gapi loaded');
                        resolve(window.gapi);
                    }
                    console.log('loading..')
                    const node = document.createElement('script');
                    if (this.appLoadedService.AppLoaded$?.getValue()?.LoggedInContact?.HasInternetConnection) {
                        node.src = `https://maps.googleapis.com/maps/api/js?key=${this.appLoadedService.AppLoaded$?.getValue()?.LoggedInContact?.GoogleMapKeyHash}&callback=__onGapiLoaded`;
                    }
                    else {
                        node.src = `${this.appLoadedService.BaseApiUrl}${this.languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/DownloadOther/GoogleMap.js`;
                    }
                    node.type = 'text/javascript';
                    document.getElementsByTagName('head')[0].appendChild(node);
                    this.appStateService.UpdateAppState(<AppState>{ GoogleJSLoaded: true });
                });
            }
        }

        return this.GoogleJSLoaded;
    }

    private GetLoggedInContact() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ LoggedInContact: {} });
        this.appStateService.UpdateAppState(<AppState>{ Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/LoggedInContact`;
        return this.httpClient.get<Contact>(url).pipe(
            map((x: any) => {
                this.UpdateLoggedInContact(x);
                console.debug(x);
                if (this.appLoadedService.AppLoaded$?.getValue()?.LoggedInContact?.HasInternetConnection) {
                    this.DoGoogleJS();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private UpdateLoggedInContact(x: Contact) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ LoggedInContact: x, });
        this.appStateService.UpdateAppState(<AppState>{ Working: false });
    }
}
