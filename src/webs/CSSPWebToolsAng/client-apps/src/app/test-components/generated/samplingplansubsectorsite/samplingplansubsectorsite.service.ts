/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { SamplingPlanSubsectorSiteTextModel } from './samplingplansubsectorsite.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesSamplingPlanSubsectorSiteText } from './samplingplansubsectorsite.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { SamplingPlanSubsectorSite } from '../../../models/generated/SamplingPlanSubsectorSite.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class SamplingPlanSubsectorSiteService {
  /* Variables */
  samplingplansubsectorsiteTextModel$: BehaviorSubject<SamplingPlanSubsectorSiteTextModel> = new BehaviorSubject<SamplingPlanSubsectorSiteTextModel>(<SamplingPlanSubsectorSiteTextModel>{});
  samplingplansubsectorsiteListModel$: BehaviorSubject<SamplingPlanSubsectorSite[]> = new BehaviorSubject<SamplingPlanSubsectorSite[]>(<SamplingPlanSubsectorSite[]>{});
  samplingplansubsectorsiteGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplansubsectorsitePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplansubsectorsitePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplansubsectorsiteDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesSamplingPlanSubsectorSiteText(this.samplingplansubsectorsiteTextModel$);
    this.samplingplansubsectorsiteTextModel$.next(<SamplingPlanSubsectorSiteTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetSamplingPlanSubsectorSiteList() {
    this.httpClientService.BeforeHttpClient(this.samplingplansubsectorsiteGetModel$);

    return this.httpClient.get<SamplingPlanSubsectorSite[]>('/api/SamplingPlanSubsectorSite').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<SamplingPlanSubsectorSite>(this.samplingplansubsectorsiteListModel$, this.samplingplansubsectorsiteGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<SamplingPlanSubsectorSite>(this.samplingplansubsectorsiteListModel$, this.samplingplansubsectorsiteGetModel$, e);
      })))
    );
  }

  PutSamplingPlanSubsectorSite(samplingplansubsectorsite: SamplingPlanSubsectorSite) {
    this.httpClientService.BeforeHttpClient(this.samplingplansubsectorsitePutModel$);

    return this.httpClient.put<SamplingPlanSubsectorSite>('/api/SamplingPlanSubsectorSite', samplingplansubsectorsite, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<SamplingPlanSubsectorSite>(this.samplingplansubsectorsiteListModel$, this.samplingplansubsectorsitePutModel$, x, HttpClientCommand.Put, samplingplansubsectorsite);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<SamplingPlanSubsectorSite>(this.samplingplansubsectorsiteListModel$, this.samplingplansubsectorsitePutModel$, e);
      })))
    );
  }

  PostSamplingPlanSubsectorSite(samplingplansubsectorsite: SamplingPlanSubsectorSite) {
    this.httpClientService.BeforeHttpClient(this.samplingplansubsectorsitePostModel$);

    return this.httpClient.post<SamplingPlanSubsectorSite>('/api/SamplingPlanSubsectorSite', samplingplansubsectorsite, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<SamplingPlanSubsectorSite>(this.samplingplansubsectorsiteListModel$, this.samplingplansubsectorsitePostModel$, x, HttpClientCommand.Post, samplingplansubsectorsite);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<SamplingPlanSubsectorSite>(this.samplingplansubsectorsiteListModel$, this.samplingplansubsectorsitePostModel$, e);
      })))
    );
  }

  DeleteSamplingPlanSubsectorSite(samplingplansubsectorsite: SamplingPlanSubsectorSite) {
    this.httpClientService.BeforeHttpClient(this.samplingplansubsectorsiteDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/SamplingPlanSubsectorSite/${ samplingplansubsectorsite.SamplingPlanSubsectorSiteID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<SamplingPlanSubsectorSite>(this.samplingplansubsectorsiteListModel$, this.samplingplansubsectorsiteDeleteModel$, x, HttpClientCommand.Delete, samplingplansubsectorsite);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<SamplingPlanSubsectorSite>(this.samplingplansubsectorsiteListModel$, this.samplingplansubsectorsiteDeleteModel$, e);
      })))
    );
  }
}
