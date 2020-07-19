/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { WebHelpDocTextModel } from './webhelpdoc.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesWebHelpDocText } from './webhelpdoc.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { WebHelpDoc } from '../../../models/generated/WebHelpDoc.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class WebHelpDocService {
  /* Variables */
  webhelpdocTextModel$: BehaviorSubject<WebHelpDocTextModel> = new BehaviorSubject<WebHelpDocTextModel>(<WebHelpDocTextModel>{});
  webhelpdocListModel$: BehaviorSubject<WebHelpDoc[]> = new BehaviorSubject<WebHelpDoc[]>(<WebHelpDoc[]>{});
  webhelpdocGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  webhelpdocPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  webhelpdocPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  webhelpdocDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesWebHelpDocText(this.webhelpdocTextModel$);
    this.webhelpdocTextModel$.next(<WebHelpDocTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetWebHelpDocList() {
    this.httpClientService.BeforeHttpClient(this.webhelpdocGetModel$);

    return this.httpClient.get<WebHelpDoc[]>('/api/WebHelpDoc').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebHelpDoc>(this.webhelpdocListModel$, this.webhelpdocGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<WebHelpDoc>(this.webhelpdocListModel$, this.webhelpdocGetModel$, e);
      })))
    );
  }

  PutWebHelpDoc(webhelpdoc: WebHelpDoc) {
    this.httpClientService.BeforeHttpClient(this.webhelpdocPutModel$);

    return this.httpClient.put<WebHelpDoc>('/api/WebHelpDoc', webhelpdoc, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebHelpDoc>(this.webhelpdocListModel$, this.webhelpdocPutModel$, x, HttpClientCommand.Put, webhelpdoc);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<WebHelpDoc>(this.webhelpdocListModel$, this.webhelpdocPutModel$, e);
      })))
    );
  }

  PostWebHelpDoc(webhelpdoc: WebHelpDoc) {
    this.httpClientService.BeforeHttpClient(this.webhelpdocPostModel$);

    return this.httpClient.post<WebHelpDoc>('/api/WebHelpDoc', webhelpdoc, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebHelpDoc>(this.webhelpdocListModel$, this.webhelpdocPostModel$, x, HttpClientCommand.Post, webhelpdoc);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<WebHelpDoc>(this.webhelpdocListModel$, this.webhelpdocPostModel$, e);
      })))
    );
  }

  DeleteWebHelpDoc(webhelpdoc: WebHelpDoc) {
    this.httpClientService.BeforeHttpClient(this.webhelpdocDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/WebHelpDoc/${ webhelpdoc.WebHelpDocID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebHelpDoc>(this.webhelpdocListModel$, this.webhelpdocDeleteModel$, x, HttpClientCommand.Delete, webhelpdoc);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<WebHelpDoc>(this.webhelpdocListModel$, this.webhelpdocDeleteModel$, e);
      })))
    );
  }
}
