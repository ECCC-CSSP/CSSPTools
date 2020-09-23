/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { EmailTextModel } from './email.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesEmailText } from './email.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Email } from '../../../models/generated/Email.model';
import { HttpRequestModel } from '../../../models/HttpRequest.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class EmailService {
  /* Variables */
  emailTextModel$: BehaviorSubject<EmailTextModel> = new BehaviorSubject<EmailTextModel>(<EmailTextModel>{});
  emailListModel$: BehaviorSubject<Email[]> = new BehaviorSubject<Email[]>(<Email[]>{});
  emailGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  emailPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  emailPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  emailDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesEmailText(this.emailTextModel$);
    this.emailTextModel$.next(<EmailTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetEmailList() {
    this.httpClientService.BeforeHttpClient(this.emailGetModel$);

    return this.httpClient.get<Email[]>('/api/Email').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Email>(this.emailListModel$, this.emailGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<Email>(this.emailListModel$, this.emailGetModel$, e);
      })))
    );
  }

  PutEmail(email: Email) {
    this.httpClientService.BeforeHttpClient(this.emailPutModel$);

    return this.httpClient.put<Email>('/api/Email', email, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Email>(this.emailListModel$, this.emailPutModel$, x, HttpClientCommand.Put, email);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<Email>(this.emailListModel$, this.emailPutModel$, e);
      })))
    );
  }

  PostEmail(email: Email) {
    this.httpClientService.BeforeHttpClient(this.emailPostModel$);

    return this.httpClient.post<Email>('/api/Email', email, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Email>(this.emailListModel$, this.emailPostModel$, x, HttpClientCommand.Post, email);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<Email>(this.emailListModel$, this.emailPostModel$, e);
      })))
    );
  }

  DeleteEmail(email: Email) {
    this.httpClientService.BeforeHttpClient(this.emailDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/Email/${ email.EmailID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Email>(this.emailListModel$, this.emailDeleteModel$, x, HttpClientCommand.Delete, email);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<Email>(this.emailListModel$, this.emailDeleteModel$, e);
      })))
    );
  }
}
