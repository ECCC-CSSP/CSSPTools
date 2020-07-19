/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { WebClimateDataValueTextModel } from './webclimatedatavalue.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesWebClimateDataValueText } from './webclimatedatavalue.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { WebClimateDataValue } from '../../../models/generated/WebClimateDataValue.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class WebClimateDataValueService {
  /* Variables */
  webclimatedatavalueTextModel$: BehaviorSubject<WebClimateDataValueTextModel> = new BehaviorSubject<WebClimateDataValueTextModel>(<WebClimateDataValueTextModel>{});
  webclimatedatavalueListModel$: BehaviorSubject<WebClimateDataValue[]> = new BehaviorSubject<WebClimateDataValue[]>(<WebClimateDataValue[]>{});
  webclimatedatavalueGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  webclimatedatavaluePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  webclimatedatavaluePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  webclimatedatavalueDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesWebClimateDataValueText(this.webclimatedatavalueTextModel$);
    this.webclimatedatavalueTextModel$.next(<WebClimateDataValueTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetWebClimateDataValueList() {
    this.httpClientService.BeforeHttpClient(this.webclimatedatavalueGetModel$);

    return this.httpClient.get<WebClimateDataValue[]>('/api/WebClimateDataValue').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebClimateDataValue>(this.webclimatedatavalueListModel$, this.webclimatedatavalueGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<WebClimateDataValue>(this.webclimatedatavalueListModel$, this.webclimatedatavalueGetModel$, e);
      })))
    );
  }

  PutWebClimateDataValue(webclimatedatavalue: WebClimateDataValue) {
    this.httpClientService.BeforeHttpClient(this.webclimatedatavaluePutModel$);

    return this.httpClient.put<WebClimateDataValue>('/api/WebClimateDataValue', webclimatedatavalue, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebClimateDataValue>(this.webclimatedatavalueListModel$, this.webclimatedatavaluePutModel$, x, HttpClientCommand.Put, webclimatedatavalue);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<WebClimateDataValue>(this.webclimatedatavalueListModel$, this.webclimatedatavaluePutModel$, e);
      })))
    );
  }

  PostWebClimateDataValue(webclimatedatavalue: WebClimateDataValue) {
    this.httpClientService.BeforeHttpClient(this.webclimatedatavaluePostModel$);

    return this.httpClient.post<WebClimateDataValue>('/api/WebClimateDataValue', webclimatedatavalue, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebClimateDataValue>(this.webclimatedatavalueListModel$, this.webclimatedatavaluePostModel$, x, HttpClientCommand.Post, webclimatedatavalue);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<WebClimateDataValue>(this.webclimatedatavalueListModel$, this.webclimatedatavaluePostModel$, e);
      })))
    );
  }

  DeleteWebClimateDataValue(webclimatedatavalue: WebClimateDataValue) {
    this.httpClientService.BeforeHttpClient(this.webclimatedatavalueDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/WebClimateDataValue/${ webclimatedatavalue.WebClimateDataValueID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebClimateDataValue>(this.webclimatedatavalueListModel$, this.webclimatedatavalueDeleteModel$, x, HttpClientCommand.Delete, webclimatedatavalue);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<WebClimateDataValue>(this.webclimatedatavalueListModel$, this.webclimatedatavalueDeleteModel$, e);
      })))
    );
  }
}
