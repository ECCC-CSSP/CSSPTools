/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { SamplingPlanSubsectorTextModel } from './samplingplansubsector.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesSamplingPlanSubsectorText } from './samplingplansubsector.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { SamplingPlanSubsector } from '../../../models/generated/SamplingPlanSubsector.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class SamplingPlanSubsectorService {
  /* Variables */
  samplingplansubsectorTextModel$: BehaviorSubject<SamplingPlanSubsectorTextModel> = new BehaviorSubject<SamplingPlanSubsectorTextModel>(<SamplingPlanSubsectorTextModel>{});
  samplingplansubsectorListModel$: BehaviorSubject<SamplingPlanSubsector[]> = new BehaviorSubject<SamplingPlanSubsector[]>(<SamplingPlanSubsector[]>{});
  samplingplansubsectorGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplansubsectorPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplansubsectorPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplansubsectorDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesSamplingPlanSubsectorText(this.samplingplansubsectorTextModel$);
    this.samplingplansubsectorTextModel$.next(<SamplingPlanSubsectorTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetSamplingPlanSubsectorList() {
    this.httpClientService.BeforeHttpClient(this.samplingplansubsectorGetModel$);

    return this.httpClient.get<SamplingPlanSubsector[]>('/api/SamplingPlanSubsector').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<SamplingPlanSubsector>(this.samplingplansubsectorListModel$, this.samplingplansubsectorGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<SamplingPlanSubsector>(this.samplingplansubsectorListModel$, this.samplingplansubsectorGetModel$, e);
      })))
    );
  }

  PutSamplingPlanSubsector(samplingplansubsector: SamplingPlanSubsector) {
    this.httpClientService.BeforeHttpClient(this.samplingplansubsectorPutModel$);

    return this.httpClient.put<SamplingPlanSubsector>('/api/SamplingPlanSubsector', samplingplansubsector, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<SamplingPlanSubsector>(this.samplingplansubsectorListModel$, this.samplingplansubsectorPutModel$, x, HttpClientCommand.Put, samplingplansubsector);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<SamplingPlanSubsector>(this.samplingplansubsectorListModel$, this.samplingplansubsectorPutModel$, e);
      })))
    );
  }

  PostSamplingPlanSubsector(samplingplansubsector: SamplingPlanSubsector) {
    this.httpClientService.BeforeHttpClient(this.samplingplansubsectorPostModel$);

    return this.httpClient.post<SamplingPlanSubsector>('/api/SamplingPlanSubsector', samplingplansubsector, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<SamplingPlanSubsector>(this.samplingplansubsectorListModel$, this.samplingplansubsectorPostModel$, x, HttpClientCommand.Post, samplingplansubsector);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<SamplingPlanSubsector>(this.samplingplansubsectorListModel$, this.samplingplansubsectorPostModel$, e);
      })))
    );
  }

  DeleteSamplingPlanSubsector(samplingplansubsector: SamplingPlanSubsector) {
    this.httpClientService.BeforeHttpClient(this.samplingplansubsectorDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/SamplingPlanSubsector/${ samplingplansubsector.SamplingPlanSubsectorID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<SamplingPlanSubsector>(this.samplingplansubsectorListModel$, this.samplingplansubsectorDeleteModel$, x, HttpClientCommand.Delete, samplingplansubsector);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<SamplingPlanSubsector>(this.samplingplansubsectorListModel$, this.samplingplansubsectorDeleteModel$, e);
      })))
    );
  }
}
