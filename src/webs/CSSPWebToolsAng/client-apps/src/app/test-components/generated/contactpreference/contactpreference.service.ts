/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { ContactPreferenceTextModel } from './contactpreference.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesContactPreferenceText } from './contactpreference.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { ContactPreference } from '../../../models/generated/ContactPreference.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class ContactPreferenceService {
  /* Variables */
  contactpreferenceTextModel$: BehaviorSubject<ContactPreferenceTextModel> = new BehaviorSubject<ContactPreferenceTextModel>(<ContactPreferenceTextModel>{});
  contactpreferenceListModel$: BehaviorSubject<ContactPreference[]> = new BehaviorSubject<ContactPreference[]>(<ContactPreference[]>{});
  contactpreferenceGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  contactpreferencePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  contactpreferencePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  contactpreferenceDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesContactPreferenceText(this.contactpreferenceTextModel$);
    this.contactpreferenceTextModel$.next(<ContactPreferenceTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetContactPreferenceList() {
    this.httpClientService.BeforeHttpClient(this.contactpreferenceGetModel$);

    return this.httpClient.get<ContactPreference[]>('/api/ContactPreference').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ContactPreference>(this.contactpreferenceListModel$, this.contactpreferenceGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<ContactPreference>(this.contactpreferenceListModel$, this.contactpreferenceGetModel$, e);
      })))
    );
  }

  PutContactPreference(contactpreference: ContactPreference) {
    this.httpClientService.BeforeHttpClient(this.contactpreferencePutModel$);

    return this.httpClient.put<ContactPreference>('/api/ContactPreference', contactpreference, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ContactPreference>(this.contactpreferenceListModel$, this.contactpreferencePutModel$, x, HttpClientCommand.Put, contactpreference);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<ContactPreference>(this.contactpreferenceListModel$, this.contactpreferencePutModel$, e);
      })))
    );
  }

  PostContactPreference(contactpreference: ContactPreference) {
    this.httpClientService.BeforeHttpClient(this.contactpreferencePostModel$);

    return this.httpClient.post<ContactPreference>('/api/ContactPreference', contactpreference, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ContactPreference>(this.contactpreferenceListModel$, this.contactpreferencePostModel$, x, HttpClientCommand.Post, contactpreference);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<ContactPreference>(this.contactpreferenceListModel$, this.contactpreferencePostModel$, e);
      })))
    );
  }

  DeleteContactPreference(contactpreference: ContactPreference) {
    this.httpClientService.BeforeHttpClient(this.contactpreferenceDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/ContactPreference/${ contactpreference.ContactPreferenceID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ContactPreference>(this.contactpreferenceListModel$, this.contactpreferenceDeleteModel$, x, HttpClientCommand.Delete, contactpreference);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<ContactPreference>(this.contactpreferenceListModel$, this.contactpreferenceDeleteModel$, e);
      })))
    );
  }
}
