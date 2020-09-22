import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Contact } from '../../models/generated/Contact.model';
import { LoggedInContactModel, LoggedInContactTextModel } from './logged-in-contact.models';

@Injectable({
  providedIn: 'root'
})
export class LoggedInContactService {
  LoggedInContactTextModel$: BehaviorSubject<LoggedInContactTextModel> = new BehaviorSubject<LoggedInContactTextModel>(<LoggedInContactTextModel>{});
  LoggedInContactModel$: BehaviorSubject<LoggedInContactModel> = new BehaviorSubject<LoggedInContactModel>(<LoggedInContactModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateLoggedInContactText(<LoggedInContactTextModel>{});
    this.UpdateLoggedInContact(<LoggedInContactModel>{});
  }

  UpdateLoggedInContactText(loggedInContactTextModel: LoggedInContactTextModel) {
    this.LoggedInContactTextModel$.next(<LoggedInContactTextModel>{ ...this.LoggedInContactTextModel$.getValue(), ...loggedInContactTextModel });
  }

  UpdateLoggedInContact(loggedInContactModel: LoggedInContactModel) {
    this.LoggedInContactModel$.next(<LoggedInContactModel>{ ...this.LoggedInContactModel$.getValue(), ...loggedInContactModel });
  }

  GetLoggedInContact() {
    this.UpdateLoggedInContact(<LoggedInContactModel>{ Working: true });
    return this.httpClient.get<Contact>('/api/LoggedInContact').pipe(
      map((x: any) => {
        this.UpdateLoggedInContact(<LoggedInContactModel>{ Contact: x, Working: false });
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateLoggedInContact(<LoggedInContactModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

}
