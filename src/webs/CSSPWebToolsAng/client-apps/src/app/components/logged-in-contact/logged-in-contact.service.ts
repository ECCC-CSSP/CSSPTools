import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { LoggedInContactVar } from './logged-in-contact.models';

@Injectable({
  providedIn: 'root'
})
export class LoggedInContactService {
  LoggedInContactVar$: BehaviorSubject<LoggedInContactVar> = new BehaviorSubject<LoggedInContactVar>(<LoggedInContactVar>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateLoggedInContactVar(<LoggedInContactVar>{});
  }

  UpdateLoggedInContactVar(loggedInContactVar: LoggedInContactVar) {
    this.LoggedInContactVar$.next(<LoggedInContactVar>{ ...this.LoggedInContactVar$.getValue(), ...loggedInContactVar });
  }

}
