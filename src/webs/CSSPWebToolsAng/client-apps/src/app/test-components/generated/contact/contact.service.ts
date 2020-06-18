/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { ContactTextModel } from './contact.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesContactText } from './contact.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Contact } from '../../../models/generated/Contact.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  /* Variables */
  contactTextModel$: BehaviorSubject<ContactTextModel> = new BehaviorSubject<ContactTextModel>(<ContactTextModel>{});
  contactListModel$: BehaviorSubject<Contact[]> = new BehaviorSubject<Contact[]>(<Contact[]>{});
  contactGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  contactPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  contactPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  contactDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesContactText(this);
    this.contactTextModel$.next(<ContactTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetContactList() {
    this.httpClientService.BeforeHttpClient(this.contactGetModel$);

    return this.httpClient.get<Contact[]>('/api/Contact').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Contact>(this.contactListModel$, this.contactGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<Contact>(this.contactListModel$, this.contactGetModel$, e);
      })))
    );
  }

  PutContact(contact: Contact) {
    this.httpClientService.BeforeHttpClient(this.contactPutModel$);

    return this.httpClient.put<Contact>('/api/Contact', contact, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Contact>(this.contactListModel$, this.contactPutModel$, x, HttpClientCommand.Put, contact);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<Contact>(this.contactListModel$, this.contactPutModel$, e);
      })))
    );
  }

  PostContact(contact: Contact) {
    this.httpClientService.BeforeHttpClient(this.contactPostModel$);

    return this.httpClient.post<Contact>('/api/Contact', contact, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Contact>(this.contactListModel$, this.contactPostModel$, x, HttpClientCommand.Post, contact);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<Contact>(this.contactListModel$, this.contactPostModel$, e);
      })))
    );
  }

  DeleteContact(contact: Contact) {
    this.httpClientService.BeforeHttpClient(this.contactDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/Contact/${ contact.ContactID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Contact>(this.contactListModel$, this.contactDeleteModel$, x, HttpClientCommand.Delete, contact);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<Contact>(this.contactListModel$, this.contactDeleteModel$, e);
      })))
    );
  }
}
