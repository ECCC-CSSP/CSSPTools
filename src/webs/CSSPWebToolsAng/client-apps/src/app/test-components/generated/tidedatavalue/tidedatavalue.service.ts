/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { TideDataValueTextModel } from './tidedatavalue.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesTideDataValueText } from './tidedatavalue.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { TideDataValue } from '../../../models/generated/TideDataValue.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class TideDataValueService {
  /* Variables */
  tidedatavalueTextModel$: BehaviorSubject<TideDataValueTextModel> = new BehaviorSubject<TideDataValueTextModel>(<TideDataValueTextModel>{});
  tidedatavalueListModel$: BehaviorSubject<TideDataValue[]> = new BehaviorSubject<TideDataValue[]>(<TideDataValue[]>{});
  tidedatavalueGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tidedatavaluePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tidedatavaluePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tidedatavalueDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesTideDataValueText(this.tidedatavalueTextModel$);
    this.tidedatavalueTextModel$.next(<TideDataValueTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetTideDataValueList() {
    this.httpClientService.BeforeHttpClient(this.tidedatavalueGetModel$);

    return this.httpClient.get<TideDataValue[]>('/api/TideDataValue').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<TideDataValue>(this.tidedatavalueListModel$, this.tidedatavalueGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<TideDataValue>(this.tidedatavalueListModel$, this.tidedatavalueGetModel$, e);
      })))
    );
  }

  PutTideDataValue(tidedatavalue: TideDataValue) {
    this.httpClientService.BeforeHttpClient(this.tidedatavaluePutModel$);

    return this.httpClient.put<TideDataValue>('/api/TideDataValue', tidedatavalue, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<TideDataValue>(this.tidedatavalueListModel$, this.tidedatavaluePutModel$, x, HttpClientCommand.Put, tidedatavalue);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<TideDataValue>(this.tidedatavalueListModel$, this.tidedatavaluePutModel$, e);
      })))
    );
  }

  PostTideDataValue(tidedatavalue: TideDataValue) {
    this.httpClientService.BeforeHttpClient(this.tidedatavaluePostModel$);

    return this.httpClient.post<TideDataValue>('/api/TideDataValue', tidedatavalue, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<TideDataValue>(this.tidedatavalueListModel$, this.tidedatavaluePostModel$, x, HttpClientCommand.Post, tidedatavalue);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<TideDataValue>(this.tidedatavalueListModel$, this.tidedatavaluePostModel$, e);
      })))
    );
  }

  DeleteTideDataValue(tidedatavalue: TideDataValue) {
    this.httpClientService.BeforeHttpClient(this.tidedatavalueDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/TideDataValue/${ tidedatavalue.TideDataValueID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<TideDataValue>(this.tidedatavalueListModel$, this.tidedatavalueDeleteModel$, x, HttpClientCommand.Delete, tidedatavalue);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<TideDataValue>(this.tidedatavalueListModel$, this.tidedatavalueDeleteModel$, e);
      })))
    );
  }
}
