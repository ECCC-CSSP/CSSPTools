/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { EmailDistributionListContactTextModel } from './emaildistributionlistcontact.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesEmailDistributionListContactText } from './emaildistributionlistcontact.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { EmailDistributionListContact } from '../../../models/generated/EmailDistributionListContact.model';
import { HttpRequestModel } from '../../../models/HttpRequest.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class EmailDistributionListContactService {
  /* Variables */
  emaildistributionlistcontactTextModel$: BehaviorSubject<EmailDistributionListContactTextModel> = new BehaviorSubject<EmailDistributionListContactTextModel>(<EmailDistributionListContactTextModel>{});
  emaildistributionlistcontactListModel$: BehaviorSubject<EmailDistributionListContact[]> = new BehaviorSubject<EmailDistributionListContact[]>(<EmailDistributionListContact[]>{});
  emaildistributionlistcontactGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  emaildistributionlistcontactPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  emaildistributionlistcontactPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  emaildistributionlistcontactDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesEmailDistributionListContactText(this.emaildistributionlistcontactTextModel$);
    this.emaildistributionlistcontactTextModel$.next(<EmailDistributionListContactTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetEmailDistributionListContactList() {
    this.httpClientService.BeforeHttpClient(this.emaildistributionlistcontactGetModel$);

    return this.httpClient.get<EmailDistributionListContact[]>('/api/EmailDistributionListContact').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<EmailDistributionListContact>(this.emaildistributionlistcontactListModel$, this.emaildistributionlistcontactGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<EmailDistributionListContact>(this.emaildistributionlistcontactListModel$, this.emaildistributionlistcontactGetModel$, e);
      })))
    );
  }

  PutEmailDistributionListContact(emaildistributionlistcontact: EmailDistributionListContact) {
    this.httpClientService.BeforeHttpClient(this.emaildistributionlistcontactPutModel$);

    return this.httpClient.put<EmailDistributionListContact>('/api/EmailDistributionListContact', emaildistributionlistcontact, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<EmailDistributionListContact>(this.emaildistributionlistcontactListModel$, this.emaildistributionlistcontactPutModel$, x, HttpClientCommand.Put, emaildistributionlistcontact);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<EmailDistributionListContact>(this.emaildistributionlistcontactListModel$, this.emaildistributionlistcontactPutModel$, e);
      })))
    );
  }

  PostEmailDistributionListContact(emaildistributionlistcontact: EmailDistributionListContact) {
    this.httpClientService.BeforeHttpClient(this.emaildistributionlistcontactPostModel$);

    return this.httpClient.post<EmailDistributionListContact>('/api/EmailDistributionListContact', emaildistributionlistcontact, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<EmailDistributionListContact>(this.emaildistributionlistcontactListModel$, this.emaildistributionlistcontactPostModel$, x, HttpClientCommand.Post, emaildistributionlistcontact);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<EmailDistributionListContact>(this.emaildistributionlistcontactListModel$, this.emaildistributionlistcontactPostModel$, e);
      })))
    );
  }

  DeleteEmailDistributionListContact(emaildistributionlistcontact: EmailDistributionListContact) {
    this.httpClientService.BeforeHttpClient(this.emaildistributionlistcontactDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/EmailDistributionListContact/${ emaildistributionlistcontact.EmailDistributionListContactID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<EmailDistributionListContact>(this.emaildistributionlistcontactListModel$, this.emaildistributionlistcontactDeleteModel$, x, HttpClientCommand.Delete, emaildistributionlistcontact);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<EmailDistributionListContact>(this.emaildistributionlistcontactListModel$, this.emaildistributionlistcontactDeleteModel$, e);
      })))
    );
  }
}
