/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { SamplingPlanTextModel } from './samplingplan.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesSamplingPlanText } from './samplingplan.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { SamplingPlan } from '../../../models/generated/SamplingPlan.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class SamplingPlanService {
  /* Variables */
  samplingplanTextModel$: BehaviorSubject<SamplingPlanTextModel> = new BehaviorSubject<SamplingPlanTextModel>(<SamplingPlanTextModel>{});
  samplingplanListModel$: BehaviorSubject<SamplingPlan[]> = new BehaviorSubject<SamplingPlan[]>(<SamplingPlan[]>{});
  samplingplanGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplanPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplanPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplanDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesSamplingPlanText(this.samplingplanTextModel$);
    this.samplingplanTextModel$.next(<SamplingPlanTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetSamplingPlanList() {
    this.httpClientService.BeforeHttpClient(this.samplingplanGetModel$);

    return this.httpClient.get<SamplingPlan[]>('/api/SamplingPlan').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<SamplingPlan>(this.samplingplanListModel$, this.samplingplanGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<SamplingPlan>(this.samplingplanListModel$, this.samplingplanGetModel$, e);
      })))
    );
  }

  PutSamplingPlan(samplingplan: SamplingPlan) {
    this.httpClientService.BeforeHttpClient(this.samplingplanPutModel$);

    return this.httpClient.put<SamplingPlan>('/api/SamplingPlan', samplingplan, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<SamplingPlan>(this.samplingplanListModel$, this.samplingplanPutModel$, x, HttpClientCommand.Put, samplingplan);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<SamplingPlan>(this.samplingplanListModel$, this.samplingplanPutModel$, e);
      })))
    );
  }

  PostSamplingPlan(samplingplan: SamplingPlan) {
    this.httpClientService.BeforeHttpClient(this.samplingplanPostModel$);

    return this.httpClient.post<SamplingPlan>('/api/SamplingPlan', samplingplan, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<SamplingPlan>(this.samplingplanListModel$, this.samplingplanPostModel$, x, HttpClientCommand.Post, samplingplan);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<SamplingPlan>(this.samplingplanListModel$, this.samplingplanPostModel$, e);
      })))
    );
  }

  DeleteSamplingPlan(samplingplan: SamplingPlan) {
    this.httpClientService.BeforeHttpClient(this.samplingplanDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/SamplingPlan/${ samplingplan.SamplingPlanID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<SamplingPlan>(this.samplingplanListModel$, this.samplingplanDeleteModel$, x, HttpClientCommand.Delete, samplingplan);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<SamplingPlan>(this.samplingplanListModel$, this.samplingplanDeleteModel$, e);
      })))
    );
  }
}
