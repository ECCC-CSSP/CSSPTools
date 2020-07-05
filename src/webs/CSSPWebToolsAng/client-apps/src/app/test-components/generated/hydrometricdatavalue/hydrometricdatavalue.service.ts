/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { HydrometricDataValueTextModel } from './hydrometricdatavalue.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesHydrometricDataValueText } from './hydrometricdatavalue.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { HydrometricDataValue } from '../../../models/generated/HydrometricDataValue.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class HydrometricDataValueService {
  /* Variables */
  hydrometricdatavalueTextModel$: BehaviorSubject<HydrometricDataValueTextModel> = new BehaviorSubject<HydrometricDataValueTextModel>(<HydrometricDataValueTextModel>{});
  hydrometricdatavalueListModel$: BehaviorSubject<HydrometricDataValue[]> = new BehaviorSubject<HydrometricDataValue[]>(<HydrometricDataValue[]>{});
  hydrometricdatavalueGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  hydrometricdatavaluePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  hydrometricdatavaluePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  hydrometricdatavalueDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesHydrometricDataValueText(this.hydrometricdatavalueTextModel$);
    this.hydrometricdatavalueTextModel$.next(<HydrometricDataValueTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetHydrometricDataValueList() {
    this.httpClientService.BeforeHttpClient(this.hydrometricdatavalueGetModel$);

    return this.httpClient.get<HydrometricDataValue[]>('/api/HydrometricDataValue').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<HydrometricDataValue>(this.hydrometricdatavalueListModel$, this.hydrometricdatavalueGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<HydrometricDataValue>(this.hydrometricdatavalueListModel$, this.hydrometricdatavalueGetModel$, e);
      })))
    );
  }

  PutHydrometricDataValue(hydrometricdatavalue: HydrometricDataValue) {
    this.httpClientService.BeforeHttpClient(this.hydrometricdatavaluePutModel$);

    return this.httpClient.put<HydrometricDataValue>('/api/HydrometricDataValue', hydrometricdatavalue, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<HydrometricDataValue>(this.hydrometricdatavalueListModel$, this.hydrometricdatavaluePutModel$, x, HttpClientCommand.Put, hydrometricdatavalue);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<HydrometricDataValue>(this.hydrometricdatavalueListModel$, this.hydrometricdatavaluePutModel$, e);
      })))
    );
  }

  PostHydrometricDataValue(hydrometricdatavalue: HydrometricDataValue) {
    this.httpClientService.BeforeHttpClient(this.hydrometricdatavaluePostModel$);

    return this.httpClient.post<HydrometricDataValue>('/api/HydrometricDataValue', hydrometricdatavalue, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<HydrometricDataValue>(this.hydrometricdatavalueListModel$, this.hydrometricdatavaluePostModel$, x, HttpClientCommand.Post, hydrometricdatavalue);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<HydrometricDataValue>(this.hydrometricdatavalueListModel$, this.hydrometricdatavaluePostModel$, e);
      })))
    );
  }

  DeleteHydrometricDataValue(hydrometricdatavalue: HydrometricDataValue) {
    this.httpClientService.BeforeHttpClient(this.hydrometricdatavalueDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/HydrometricDataValue/${ hydrometricdatavalue.HydrometricDataValueID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<HydrometricDataValue>(this.hydrometricdatavalueListModel$, this.hydrometricdatavalueDeleteModel$, x, HttpClientCommand.Delete, hydrometricdatavalue);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<HydrometricDataValue>(this.hydrometricdatavalueListModel$, this.hydrometricdatavalueDeleteModel$, e);
      })))
    );
  }
}
