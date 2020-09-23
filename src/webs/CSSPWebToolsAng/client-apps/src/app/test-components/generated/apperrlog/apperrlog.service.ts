/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { AppErrLogTextModel } from './apperrlog.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesAppErrLogText } from './apperrlog.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { AppErrLog } from '../../../models/generated/AppErrLog.model';
import { HttpRequestModel } from '../../../models/HttpRequest.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class AppErrLogService {
  /* Variables */
  apperrlogTextModel$: BehaviorSubject<AppErrLogTextModel> = new BehaviorSubject<AppErrLogTextModel>(<AppErrLogTextModel>{});
  apperrlogListModel$: BehaviorSubject<AppErrLog[]> = new BehaviorSubject<AppErrLog[]>(<AppErrLog[]>{});
  apperrlogGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  apperrlogPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  apperrlogPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  apperrlogDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesAppErrLogText(this.apperrlogTextModel$);
    this.apperrlogTextModel$.next(<AppErrLogTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetAppErrLogList() {
    this.httpClientService.BeforeHttpClient(this.apperrlogGetModel$);

    return this.httpClient.get<AppErrLog[]>('/api/AppErrLog').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AppErrLog>(this.apperrlogListModel$, this.apperrlogGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AppErrLog>(this.apperrlogListModel$, this.apperrlogGetModel$, e);
      })))
    );
  }

  PutAppErrLog(apperrlog: AppErrLog) {
    this.httpClientService.BeforeHttpClient(this.apperrlogPutModel$);

    return this.httpClient.put<AppErrLog>('/api/AppErrLog', apperrlog, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AppErrLog>(this.apperrlogListModel$, this.apperrlogPutModel$, x, HttpClientCommand.Put, apperrlog);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<AppErrLog>(this.apperrlogListModel$, this.apperrlogPutModel$, e);
      })))
    );
  }

  PostAppErrLog(apperrlog: AppErrLog) {
    this.httpClientService.BeforeHttpClient(this.apperrlogPostModel$);

    return this.httpClient.post<AppErrLog>('/api/AppErrLog', apperrlog, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AppErrLog>(this.apperrlogListModel$, this.apperrlogPostModel$, x, HttpClientCommand.Post, apperrlog);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AppErrLog>(this.apperrlogListModel$, this.apperrlogPostModel$, e);
      })))
    );
  }

  DeleteAppErrLog(apperrlog: AppErrLog) {
    this.httpClientService.BeforeHttpClient(this.apperrlogDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/AppErrLog/${ apperrlog.AppErrLogID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AppErrLog>(this.apperrlogListModel$, this.apperrlogDeleteModel$, x, HttpClientCommand.Delete, apperrlog);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AppErrLog>(this.apperrlogListModel$, this.apperrlogDeleteModel$, e);
      })))
    );
  }
}
