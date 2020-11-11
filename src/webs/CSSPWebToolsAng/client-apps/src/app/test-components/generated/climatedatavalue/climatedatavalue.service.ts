/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { ClimateDataValueTextModel } from './climatedatavalue.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesClimateDataValueText } from './climatedatavalue.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { ClimateDataValue } from '../../../models/generated/ClimateDataValue.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class ClimateDataValueService {
  /* Variables */
  climatedatavalueTextModel$: BehaviorSubject<ClimateDataValueTextModel> = new BehaviorSubject<ClimateDataValueTextModel>(<ClimateDataValueTextModel>{});
  climatedatavalueListModel$: BehaviorSubject<ClimateDataValue[]> = new BehaviorSubject<ClimateDataValue[]>(<ClimateDataValue[]>{});
  climatedatavalueGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  climatedatavaluePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  climatedatavaluePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  climatedatavalueDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesClimateDataValueText(this.climatedatavalueTextModel$);
    this.climatedatavalueTextModel$.next(<ClimateDataValueTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetClimateDataValueList() {
    this.httpClientService.BeforeHttpClient(this.climatedatavalueGetModel$);

    return this.httpClient.get<ClimateDataValue[]>('/api/ClimateDataValue').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ClimateDataValue>(this.climatedatavalueListModel$, this.climatedatavalueGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<ClimateDataValue>(this.climatedatavalueListModel$, this.climatedatavalueGetModel$, e);
      })))
    );
  }

  PutClimateDataValue(climatedatavalue: ClimateDataValue) {
    this.httpClientService.BeforeHttpClient(this.climatedatavaluePutModel$);

    return this.httpClient.put<ClimateDataValue>('/api/ClimateDataValue', climatedatavalue, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ClimateDataValue>(this.climatedatavalueListModel$, this.climatedatavaluePutModel$, x, HttpClientCommand.Put, climatedatavalue);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<ClimateDataValue>(this.climatedatavalueListModel$, this.climatedatavaluePutModel$, e);
      })))
    );
  }

  PostClimateDataValue(climatedatavalue: ClimateDataValue) {
    this.httpClientService.BeforeHttpClient(this.climatedatavaluePostModel$);

    return this.httpClient.post<ClimateDataValue>('/api/ClimateDataValue', climatedatavalue, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ClimateDataValue>(this.climatedatavalueListModel$, this.climatedatavaluePostModel$, x, HttpClientCommand.Post, climatedatavalue);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<ClimateDataValue>(this.climatedatavalueListModel$, this.climatedatavaluePostModel$, e);
      })))
    );
  }

  DeleteClimateDataValue(climatedatavalue: ClimateDataValue) {
    this.httpClientService.BeforeHttpClient(this.climatedatavalueDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/ClimateDataValue/${ climatedatavalue.ClimateDataValueID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ClimateDataValue>(this.climatedatavalueListModel$, this.climatedatavalueDeleteModel$, x, HttpClientCommand.Delete, climatedatavalue);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<ClimateDataValue>(this.climatedatavalueListModel$, this.climatedatavalueDeleteModel$, e);
      })))
    );
  }
}
