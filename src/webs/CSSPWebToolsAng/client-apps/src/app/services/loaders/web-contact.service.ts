import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { Contact } from 'src/app/models/generated/Contact.model';
import { WebContact } from 'src/app/models/generated/WebContact.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';


@Injectable({
    providedIn: 'root'
})
export class WebContactService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetWebContact() {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebContact: {}, AdminContactList: [], Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}en-CA/Read/WebContact/0/1`;
        return this.httpClient.get<WebContact>(url).pipe(
            map((x: WebContact) => {
                this.UpdateWebContact(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebContact(x: WebContact) {
        let adminList: Contact[] = x.ContactList.filter(contact => contact.IsAdmin == true);
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebContact: x,
            AdminContactList: adminList,
            Working: false
        });
    }

}