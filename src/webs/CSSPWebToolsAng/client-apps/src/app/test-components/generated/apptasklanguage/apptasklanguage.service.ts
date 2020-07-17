/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { AppTaskLanguageTextModel } from './apptasklanguage.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesAppTaskLanguageText } from './apptasklanguage.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { AppTaskLanguage } from '../../../models/generated/AppTaskLanguage.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class AppTaskLanguageService {
  /* Variables */
  apptasklanguageTextModel$: BehaviorSubject<AppTaskLanguageTextModel> = new BehaviorSubject<AppTaskLanguageTextModel>(<AppTaskLanguageTextModel>{});
  apptasklanguageListModel$: BehaviorSubject<AppTaskLanguage[]> = new BehaviorSubject<AppTaskLanguage[]>(<AppTaskLanguage[]>{});
  apptasklanguageGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  apptasklanguagePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  apptasklanguagePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  apptasklanguageDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesAppTaskLanguageText(this.apptasklanguageTextModel$);
    this.apptasklanguageTextModel$.next(<AppTaskLanguageTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetAppTaskLanguageList() {
    this.httpClientService.BeforeHttpClient(this.apptasklanguageGetModel$);

    return this.httpClient.get<AppTaskLanguage[]>('/api/AppTaskLanguage').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AppTaskLanguage>(this.apptasklanguageListModel$, this.apptasklanguageGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AppTaskLanguage>(this.apptasklanguageListModel$, this.apptasklanguageGetModel$, e);
      })))
    );
  }

  PutAppTaskLanguage(apptasklanguage: AppTaskLanguage) {
    this.httpClientService.BeforeHttpClient(this.apptasklanguagePutModel$);

    return this.httpClient.put<AppTaskLanguage>('/api/AppTaskLanguage', apptasklanguage, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AppTaskLanguage>(this.apptasklanguageListModel$, this.apptasklanguagePutModel$, x, HttpClientCommand.Put, apptasklanguage);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<AppTaskLanguage>(this.apptasklanguageListModel$, this.apptasklanguagePutModel$, e);
      })))
    );
  }

  PostAppTaskLanguage(apptasklanguage: AppTaskLanguage) {
    this.httpClientService.BeforeHttpClient(this.apptasklanguagePostModel$);

    return this.httpClient.post<AppTaskLanguage>('/api/AppTaskLanguage', apptasklanguage, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AppTaskLanguage>(this.apptasklanguageListModel$, this.apptasklanguagePostModel$, x, HttpClientCommand.Post, apptasklanguage);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AppTaskLanguage>(this.apptasklanguageListModel$, this.apptasklanguagePostModel$, e);
      })))
    );
  }

  DeleteAppTaskLanguage(apptasklanguage: AppTaskLanguage) {
    this.httpClientService.BeforeHttpClient(this.apptasklanguageDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/AppTaskLanguage/${ apptasklanguage.AppTaskLanguageID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AppTaskLanguage>(this.apptasklanguageListModel$, this.apptasklanguageDeleteModel$, x, HttpClientCommand.Delete, apptasklanguage);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AppTaskLanguage>(this.apptasklanguageListModel$, this.apptasklanguageDeleteModel$, e);
      })))
    );
  }
}
