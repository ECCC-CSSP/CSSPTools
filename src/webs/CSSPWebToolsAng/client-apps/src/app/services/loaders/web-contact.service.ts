import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { Contact } from 'src/app/models/generated/db/Contact.model';
import { WebContact } from 'src/app/models/generated/web/WebContact.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebHelpDocService } from './web-help-doc.service';


@Injectable({
    providedIn: 'root'
})
export class WebContactService {
    private DoOther: boolean;
    private sub: Subscription;
  
    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webHelpDocService: WebHelpDocService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebContact(DoOther: boolean) {
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebContact?.ContactList?.length > 0) {
          this.KeepWebContact();
        }
        else {
          this.sub = this.GetWebContact().subscribe();
        }
      }
    
    private GetWebContact() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebContact: {}, AdminContactList: [] });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingContact[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebContact/0/1`;
        return this.httpClient.get<WebContact>(url).pipe(
            map((x: WebContact) => {
                this.UpdateWebContact(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebHelpDoc();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebHelpDoc() {
        this.webHelpDocService.DoWebHelpDoc(this.DoOther);
    }

    private KeepWebContact() {
        this.UpdateWebContact(this.appLoadedService.AppLoaded$?.getValue()?.WebContact);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebContact);
        if (this.DoOther) {
            this.DoWebHelpDoc();
        }
    }

    private UpdateWebContact(x: WebContact) {
        let adminList: Contact[] = x.ContactList.filter(contact => contact.IsAdmin == true);
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebContact: x, AdminContactList: adminList, });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedContact()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }

        }
    }
}