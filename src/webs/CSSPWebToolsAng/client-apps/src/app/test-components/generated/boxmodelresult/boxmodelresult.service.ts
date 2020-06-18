/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { BoxModelResultTextModel } from './boxmodelresult.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesBoxModelResultText } from './boxmodelresult.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { BoxModelResult } from '../../../models/generated/BoxModelResult.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class BoxModelResultService {
  /* Variables */
  boxmodelresultTextModel$: BehaviorSubject<BoxModelResultTextModel> = new BehaviorSubject<BoxModelResultTextModel>(<BoxModelResultTextModel>{});
  boxmodelresultListModel$: BehaviorSubject<BoxModelResult[]> = new BehaviorSubject<BoxModelResult[]>(<BoxModelResult[]>{});
  boxmodelresultGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  boxmodelresultPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  boxmodelresultPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  boxmodelresultDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesBoxModelResultText(this);
    this.boxmodelresultTextModel$.next(<BoxModelResultTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetBoxModelResultList() {
    this.httpClientService.BeforeHttpClient(this.boxmodelresultGetModel$);

    return this.httpClient.get<BoxModelResult[]>('/api/BoxModelResult').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<BoxModelResult>(this.boxmodelresultListModel$, this.boxmodelresultGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<BoxModelResult>(this.boxmodelresultListModel$, this.boxmodelresultGetModel$, e);
      })))
    );
  }

  PutBoxModelResult(boxmodelresult: BoxModelResult) {
    this.httpClientService.BeforeHttpClient(this.boxmodelresultPutModel$);

    return this.httpClient.put<BoxModelResult>('/api/BoxModelResult', boxmodelresult, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<BoxModelResult>(this.boxmodelresultListModel$, this.boxmodelresultPutModel$, x, HttpClientCommand.Put, boxmodelresult);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<BoxModelResult>(this.boxmodelresultListModel$, this.boxmodelresultPutModel$, e);
      })))
    );
  }

  PostBoxModelResult(boxmodelresult: BoxModelResult) {
    this.httpClientService.BeforeHttpClient(this.boxmodelresultPostModel$);

    return this.httpClient.post<BoxModelResult>('/api/BoxModelResult', boxmodelresult, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<BoxModelResult>(this.boxmodelresultListModel$, this.boxmodelresultPostModel$, x, HttpClientCommand.Post, boxmodelresult);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<BoxModelResult>(this.boxmodelresultListModel$, this.boxmodelresultPostModel$, e);
      })))
    );
  }

  DeleteBoxModelResult(boxmodelresult: BoxModelResult) {
    this.httpClientService.BeforeHttpClient(this.boxmodelresultDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/BoxModelResult/${ boxmodelresult.BoxModelResultID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<BoxModelResult>(this.boxmodelresultListModel$, this.boxmodelresultDeleteModel$, x, HttpClientCommand.Delete, boxmodelresult);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<BoxModelResult>(this.boxmodelresultListModel$, this.boxmodelresultDeleteModel$, e);
      })))
    );
  }
}
