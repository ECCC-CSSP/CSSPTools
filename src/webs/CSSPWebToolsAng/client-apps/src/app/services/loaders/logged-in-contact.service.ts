import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { Contact } from 'src/app/models/generated/Contact.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';

@Injectable({
    providedIn: 'root'
})
export class LoggedInContactService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }   

    GetLoggedInContact() {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ LoggedInContact: {}, Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}en-CA/LoggedInContact`;
        return this.httpClient.get<Contact>(url).pipe(
            map((x: any) => {
                this.UpdateLoggedInContact(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateLoggedInContact(x: Contact) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            LoggedInContact: x,
            Working: false
        });
    }
}
