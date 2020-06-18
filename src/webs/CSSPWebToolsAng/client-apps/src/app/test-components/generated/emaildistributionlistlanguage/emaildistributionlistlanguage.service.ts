/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { EmailDistributionListLanguageTextModel } from './emaildistributionlistlanguage.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesEmailDistributionListLanguageText } from './emaildistributionlistlanguage.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { EmailDistributionListLanguage } from '../../../models/generated/EmailDistributionListLanguage.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class EmailDistributionListLanguageService {
  /* Variables */
  emaildistributionlistlanguageTextModel$: BehaviorSubject<EmailDistributionListLanguageTextModel> = new BehaviorSubject<EmailDistributionListLanguageTextModel>(<EmailDistributionListLanguageTextModel>{});
  emaildistributionlistlanguageListModel$: BehaviorSubject<EmailDistributionListLanguage[]> = new BehaviorSubject<EmailDistributionListLanguage[]>(<EmailDistributionListLanguage[]>{});
  emaildistributionlistlanguageGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  emaildistributionlistlanguagePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  emaildistributionlistlanguagePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  emaildistributionlistlanguageDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesEmailDistributionListLanguageText(this);
    this.emaildistributionlistlanguageTextModel$.next(<EmailDistributionListLanguageTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetEmailDistributionListLanguageList() {
    this.httpClientService.BeforeHttpClient(this.emaildistributionlistlanguageGetModel$);

    return this.httpClient.get<EmailDistributionListLanguage[]>('/api/EmailDistributionListLanguage').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<EmailDistributionListLanguage>(this.emaildistributionlistlanguageListModel$, this.emaildistributionlistlanguageGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<EmailDistributionListLanguage>(this.emaildistributionlistlanguageListModel$, this.emaildistributionlistlanguageGetModel$, e);
      })))
    );
  }

  PutEmailDistributionListLanguage(emaildistributionlistlanguage: EmailDistributionListLanguage) {
    this.httpClientService.BeforeHttpClient(this.emaildistributionlistlanguagePutModel$);

    return this.httpClient.put<EmailDistributionListLanguage>('/api/EmailDistributionListLanguage', emaildistributionlistlanguage, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<EmailDistributionListLanguage>(this.emaildistributionlistlanguageListModel$, this.emaildistributionlistlanguagePutModel$, x, HttpClientCommand.Put, emaildistributionlistlanguage);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<EmailDistributionListLanguage>(this.emaildistributionlistlanguageListModel$, this.emaildistributionlistlanguagePutModel$, e);
      })))
    );
  }

  PostEmailDistributionListLanguage(emaildistributionlistlanguage: EmailDistributionListLanguage) {
    this.httpClientService.BeforeHttpClient(this.emaildistributionlistlanguagePostModel$);

    return this.httpClient.post<EmailDistributionListLanguage>('/api/EmailDistributionListLanguage', emaildistributionlistlanguage, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<EmailDistributionListLanguage>(this.emaildistributionlistlanguageListModel$, this.emaildistributionlistlanguagePostModel$, x, HttpClientCommand.Post, emaildistributionlistlanguage);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<EmailDistributionListLanguage>(this.emaildistributionlistlanguageListModel$, this.emaildistributionlistlanguagePostModel$, e);
      })))
    );
  }

  DeleteEmailDistributionListLanguage(emaildistributionlistlanguage: EmailDistributionListLanguage) {
    this.httpClientService.BeforeHttpClient(this.emaildistributionlistlanguageDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/EmailDistributionListLanguage/${ emaildistributionlistlanguage.EmailDistributionListLanguageID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<EmailDistributionListLanguage>(this.emaildistributionlistlanguageListModel$, this.emaildistributionlistlanguageDeleteModel$, x, HttpClientCommand.Delete, emaildistributionlistlanguage);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<EmailDistributionListLanguage>(this.emaildistributionlistlanguageListModel$, this.emaildistributionlistlanguageDeleteModel$, e);
      })))
    );
  }
}
