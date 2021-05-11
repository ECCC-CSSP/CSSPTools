import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { Contact } from 'src/app/models/generated/db/Contact.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';

declare var window: any;

@Injectable({
    providedIn: 'root'
})
export class LoggedInContactService {
    private sub: Subscription;
    private GoogleJSLoaded;
    
    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService
    ) { }

    DoLoggedInContact(ForceReload: boolean = true) {
        if (ForceReload) {
            this.sub ? this.sub.unsubscribe() : null;
            this.sub = this.GetLoggedInContact().subscribe();
        }
        else {
            if (!this.appLoadedService.LoggedInContact) {
                this.sub ? this.sub.unsubscribe() : null;
                this.sub = this.GetLoggedInContact().subscribe();
            }
        }
    }

    private DoGoogleJS() {
        if (this.appStateService.GoogleJSLoaded) {
            // just keep the Google JS we already have in memory
        }
        else {
            this.LoadGoogleJS();
        }
    }

    private LoadGoogleJS() {
        let languageEnum = GetLanguageEnum();

        if (!this.GoogleJSLoaded) { // load once
            if (this.appLoadedService.LoggedInContact) {
                this.GoogleJSLoaded = new Promise((resolve) => {
                    window['__onGapiLoaded'] = (ev) => {
                        console.log('gapi loaded');
                        resolve(window.gapi);
                    }
                    console.log('loading..')
                    const node = document.createElement('script');
                    if (this.appLoadedService.LoggedInContact.HasInternetConnection) {
                        node.src = `https://maps.googleapis.com/maps/api/js?key=${this.appLoadedService.LoggedInContact.GoogleMapKeyHash}&callback=__onGapiLoaded`;
                    }
                    else {
                        node.src = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/DownloadOther/GoogleMap.js`;
                    }
                    node.type = 'text/javascript';
                    document.getElementsByTagName('head')[0].appendChild(node);
                    this.appStateService.GoogleJSLoaded = true;
                });
            }
        }

        return this.GoogleJSLoaded;
    }

    private GetLoggedInContact() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.LoggedInContact = <Contact>{};
        this.appStateService.Working = true;
        this.appStateService.Error = null;
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - LoggedInContact`;
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/LoggedInContact`;
        return this.httpClient.get<Contact>(url).pipe(
            map((x: any) => {
                this.UpdateLoggedInContact(x);
                console.debug(x);
                if (x.HasInternetConnection) {
                    this.DoGoogleJS();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.Working = false;
                this.appStateService.Error = <HttpErrorResponse>e;
                this.appStateService.Status = 'Error';
                console.debug(e);
            })))
        );
    }

    private UpdateLoggedInContact(x: Contact) {
        this.appLoadedService.LoggedInContact = x;
        this.appStateService.Working = false;
        this.appStateService.Error = null;
        this.appStateService.Status = '';
    }
}
