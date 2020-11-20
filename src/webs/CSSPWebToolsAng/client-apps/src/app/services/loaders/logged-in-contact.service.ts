import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { Contact } from 'src/app/models/generated/db/Contact.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
    providedIn: 'root'
})
export class LoggedInContactService {
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService) {
    }

    DoLoggedInContact() {
        this.sub ? this.sub.unsubscribe() : null;
    
        this.sub = this.GetLoggedInContact().subscribe();
    }
    
    
    private GetLoggedInContact() {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ LoggedInContact: {} });
        this.appStateService.UpdateAppState(<AppState>{ Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appStateService.AppState$.getValue().Language}-CA/LoggedInContact`;
        return this.httpClient.get<Contact>(url).pipe(
            map((x: any) => {
                this.UpdateLoggedInContact(x);
                console.debug(x);
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
