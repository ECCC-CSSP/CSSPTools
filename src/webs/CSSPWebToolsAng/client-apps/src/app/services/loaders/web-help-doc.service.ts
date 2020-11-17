import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebHelpDoc } from 'src/app/models/generated/web/WebHelpDoc.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebMWQMLookupMPNService } from './web-mwqm-lookup-mpn.service';

@Injectable({
    providedIn: 'root'
})
export class WebHelpDocService {
    private DoOther: boolean;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webMWQMLookupMPNService: WebMWQMLookupMPNService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    GetWebHelpDoc(DoOther: boolean) {
        this.DoOther = DoOther;
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebHelpDoc: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingHelpDoc[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebHelpDoc/0/1`;
        return this.httpClient.get<WebHelpDoc>(url).pipe(
            map((x: any) => {
                this.UpdateWebHelpDoc(x);
                console.debug(x);
                if (DoOther) {
                    this.GetWebMWQMLookupMPN();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    GetWebMWQMLookupMPN() {
        this.webMWQMLookupMPNService.GetWebMWQMLookupMPN(this.DoOther).subscribe();
    }

    UpdateWebHelpDoc(x: WebHelpDoc) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebHelpDoc: x, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedHelpDoc()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}