import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { Preference } from 'src/app/models/generated/helper/Preference.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { WebAllContactsService } from './web-all-contacts.service';

declare var window: any;

@Injectable({
    providedIn: 'root'
})
export class PreferenceService {
    sub: Subscription;
    private CSSLoaded;
    private IconLoaded;
    private GoogleJSLoaded;

    languageEnum = GetLanguageEnum();

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService) {
    }

    DoPreference() {

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.PreferenceList?.length > 0) {
            // just keep the PreferenceList we already have in memory
        }
        else {
            this.sub = this.LoadPreference().subscribe();
        }
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

            let GoogleMapKeyList: Preference[] = this.appLoadedService.AppLoaded$?.getValue()?.PreferenceList?.filter(c => c.VariableName == 'GoogleMapKey');

            if (GoogleMapKeyList != undefined) {
                this.GoogleJSLoaded = new Promise((resolve) => {
                    window['__onGapiLoaded'] = (ev) => {
                        console.log('gapi loaded');
                        resolve(window.gapi);
                    }
                    console.log('loading..')
                    const node = document.createElement('script');
                    if (this.appStateService.AppState$?.getValue()?.HasInternetConnection) {
                        node.src = `https://maps.googleapis.com/maps/api/js?key=${GoogleMapKeyList[0].VariableValue}&callback=__onGapiLoaded`;
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

    private LoadPreference() {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ PreferenceList: [] });
        this.appStateService.UpdateAppState(<AppState>{ Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}${this.languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Preference`;
        return this.httpClient.get<Preference[]>(url).pipe(
            map((x: any) => {
                this.UpdatePreference(x);
                console.debug(x);
                if (this.appStateService.AppState$?.getValue()?.HasInternetConnection) {
                    this.DoGoogleJS();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdatePreference(x: Preference[]) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ PreferenceList: x, });
        this.appStateService.UpdateAppState(<AppState>{ Working: false, HasInternetConnection: this.GetHasInternetConnection(), GoogleMapKey: this.GetGoogleMapKey() });
    }

    private GetHasInternetConnection(): boolean {
        let PreferenceList: Preference[] = this.appLoadedService.AppLoaded$?.getValue()?.PreferenceList?.filter(c => c.VariableName == 'HasInternetConnection');
        return (PreferenceList !== undefined && PreferenceList.length > 0) ? ('true' == PreferenceList[0].VariableValue.toLowerCase()) : null;
    }

    private GetGoogleMapKey(): string {
        let PreferenceList: Preference[] = this.appLoadedService.AppLoaded$?.getValue()?.PreferenceList?.filter(c => c.VariableName == 'GoogleMapKey');
        return (PreferenceList !== undefined && PreferenceList.length > 0) ? PreferenceList[0].VariableValue : null;
    }

}