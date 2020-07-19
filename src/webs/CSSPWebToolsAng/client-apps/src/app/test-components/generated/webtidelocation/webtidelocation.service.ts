/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { WebTideLocationTextModel } from './webtidelocation.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesWebTideLocationText } from './webtidelocation.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { WebTideLocation } from '../../../models/generated/WebTideLocation.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class WebTideLocationService {
  /* Variables */
  webtidelocationTextModel$: BehaviorSubject<WebTideLocationTextModel> = new BehaviorSubject<WebTideLocationTextModel>(<WebTideLocationTextModel>{});
  webtidelocationListModel$: BehaviorSubject<WebTideLocation[]> = new BehaviorSubject<WebTideLocation[]>(<WebTideLocation[]>{});
  webtidelocationGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  webtidelocationPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  webtidelocationPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  webtidelocationDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesWebTideLocationText(this.webtidelocationTextModel$);
    this.webtidelocationTextModel$.next(<WebTideLocationTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetWebTideLocationList() {
    this.httpClientService.BeforeHttpClient(this.webtidelocationGetModel$);

    return this.httpClient.get<WebTideLocation[]>('/api/WebTideLocation').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebTideLocation>(this.webtidelocationListModel$, this.webtidelocationGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<WebTideLocation>(this.webtidelocationListModel$, this.webtidelocationGetModel$, e);
      })))
    );
  }

  PutWebTideLocation(webtidelocation: WebTideLocation) {
    this.httpClientService.BeforeHttpClient(this.webtidelocationPutModel$);

    return this.httpClient.put<WebTideLocation>('/api/WebTideLocation', webtidelocation, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebTideLocation>(this.webtidelocationListModel$, this.webtidelocationPutModel$, x, HttpClientCommand.Put, webtidelocation);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<WebTideLocation>(this.webtidelocationListModel$, this.webtidelocationPutModel$, e);
      })))
    );
  }

  PostWebTideLocation(webtidelocation: WebTideLocation) {
    this.httpClientService.BeforeHttpClient(this.webtidelocationPostModel$);

    return this.httpClient.post<WebTideLocation>('/api/WebTideLocation', webtidelocation, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebTideLocation>(this.webtidelocationListModel$, this.webtidelocationPostModel$, x, HttpClientCommand.Post, webtidelocation);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<WebTideLocation>(this.webtidelocationListModel$, this.webtidelocationPostModel$, e);
      })))
    );
  }

  DeleteWebTideLocation(webtidelocation: WebTideLocation) {
    this.httpClientService.BeforeHttpClient(this.webtidelocationDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/WebTideLocation/${ webtidelocation.WebTideLocationID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebTideLocation>(this.webtidelocationListModel$, this.webtidelocationDeleteModel$, x, HttpClientCommand.Delete, webtidelocation);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<WebTideLocation>(this.webtidelocationListModel$, this.webtidelocationDeleteModel$, e);
      })))
    );
  }
}
