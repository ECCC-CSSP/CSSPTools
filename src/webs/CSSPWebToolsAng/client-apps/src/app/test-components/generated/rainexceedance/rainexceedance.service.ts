/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { RainExceedanceTextModel } from './rainexceedance.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesRainExceedanceText } from './rainexceedance.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { RainExceedance } from '../../../models/generated/RainExceedance.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class RainExceedanceService {
  /* Variables */
  rainexceedanceTextModel$: BehaviorSubject<RainExceedanceTextModel> = new BehaviorSubject<RainExceedanceTextModel>(<RainExceedanceTextModel>{});
  rainexceedanceListModel$: BehaviorSubject<RainExceedance[]> = new BehaviorSubject<RainExceedance[]>(<RainExceedance[]>{});
  rainexceedanceGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  rainexceedancePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  rainexceedancePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  rainexceedanceDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesRainExceedanceText(this.rainexceedanceTextModel$);
    this.rainexceedanceTextModel$.next(<RainExceedanceTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetRainExceedanceList() {
    this.httpClientService.BeforeHttpClient(this.rainexceedanceGetModel$);

    return this.httpClient.get<RainExceedance[]>('/api/RainExceedance').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<RainExceedance>(this.rainexceedanceListModel$, this.rainexceedanceGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<RainExceedance>(this.rainexceedanceListModel$, this.rainexceedanceGetModel$, e);
      })))
    );
  }

  PutRainExceedance(rainexceedance: RainExceedance) {
    this.httpClientService.BeforeHttpClient(this.rainexceedancePutModel$);

    return this.httpClient.put<RainExceedance>('/api/RainExceedance', rainexceedance, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<RainExceedance>(this.rainexceedanceListModel$, this.rainexceedancePutModel$, x, HttpClientCommand.Put, rainexceedance);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<RainExceedance>(this.rainexceedanceListModel$, this.rainexceedancePutModel$, e);
      })))
    );
  }

  PostRainExceedance(rainexceedance: RainExceedance) {
    this.httpClientService.BeforeHttpClient(this.rainexceedancePostModel$);

    return this.httpClient.post<RainExceedance>('/api/RainExceedance', rainexceedance, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<RainExceedance>(this.rainexceedanceListModel$, this.rainexceedancePostModel$, x, HttpClientCommand.Post, rainexceedance);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<RainExceedance>(this.rainexceedanceListModel$, this.rainexceedancePostModel$, e);
      })))
    );
  }

  DeleteRainExceedance(rainexceedance: RainExceedance) {
    this.httpClientService.BeforeHttpClient(this.rainexceedanceDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/RainExceedance/${ rainexceedance.RainExceedanceID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<RainExceedance>(this.rainexceedanceListModel$, this.rainexceedanceDeleteModel$, x, HttpClientCommand.Delete, rainexceedance);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<RainExceedance>(this.rainexceedanceListModel$, this.rainexceedanceDeleteModel$, e);
      })))
    );
  }
}
