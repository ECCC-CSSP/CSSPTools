/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { MWQMSiteStartEndDateTextModel } from './mwqmsitestartenddate.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesMWQMSiteStartEndDateText } from './mwqmsitestartenddate.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { MWQMSiteStartEndDate } from '../../../models/generated/MWQMSiteStartEndDate.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class MWQMSiteStartEndDateService {
  /* Variables */
  mwqmsitestartenddateTextModel$: BehaviorSubject<MWQMSiteStartEndDateTextModel> = new BehaviorSubject<MWQMSiteStartEndDateTextModel>(<MWQMSiteStartEndDateTextModel>{});
  mwqmsitestartenddateListModel$: BehaviorSubject<MWQMSiteStartEndDate[]> = new BehaviorSubject<MWQMSiteStartEndDate[]>(<MWQMSiteStartEndDate[]>{});
  mwqmsitestartenddateGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  mwqmsitestartenddatePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  mwqmsitestartenddatePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  mwqmsitestartenddateDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesMWQMSiteStartEndDateText(this);
    this.mwqmsitestartenddateTextModel$.next(<MWQMSiteStartEndDateTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetMWQMSiteStartEndDateList() {
    this.httpClientService.BeforeHttpClient(this.mwqmsitestartenddateGetModel$);

    return this.httpClient.get<MWQMSiteStartEndDate[]>('/api/MWQMSiteStartEndDate').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<MWQMSiteStartEndDate>(this.mwqmsitestartenddateListModel$, this.mwqmsitestartenddateGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<MWQMSiteStartEndDate>(this.mwqmsitestartenddateListModel$, this.mwqmsitestartenddateGetModel$, e);
      })))
    );
  }

  PutMWQMSiteStartEndDate(mwqmsitestartenddate: MWQMSiteStartEndDate) {
    this.httpClientService.BeforeHttpClient(this.mwqmsitestartenddatePutModel$);

    return this.httpClient.put<MWQMSiteStartEndDate>('/api/MWQMSiteStartEndDate', mwqmsitestartenddate, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<MWQMSiteStartEndDate>(this.mwqmsitestartenddateListModel$, this.mwqmsitestartenddatePutModel$, x, HttpClientCommand.Put, mwqmsitestartenddate);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<MWQMSiteStartEndDate>(this.mwqmsitestartenddateListModel$, this.mwqmsitestartenddatePutModel$, e);
      })))
    );
  }

  PostMWQMSiteStartEndDate(mwqmsitestartenddate: MWQMSiteStartEndDate) {
    this.httpClientService.BeforeHttpClient(this.mwqmsitestartenddatePostModel$);

    return this.httpClient.post<MWQMSiteStartEndDate>('/api/MWQMSiteStartEndDate', mwqmsitestartenddate, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<MWQMSiteStartEndDate>(this.mwqmsitestartenddateListModel$, this.mwqmsitestartenddatePostModel$, x, HttpClientCommand.Post, mwqmsitestartenddate);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<MWQMSiteStartEndDate>(this.mwqmsitestartenddateListModel$, this.mwqmsitestartenddatePostModel$, e);
      })))
    );
  }

  DeleteMWQMSiteStartEndDate(mwqmsitestartenddate: MWQMSiteStartEndDate) {
    this.httpClientService.BeforeHttpClient(this.mwqmsitestartenddateDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/MWQMSiteStartEndDate/${ mwqmsitestartenddate.MWQMSiteStartEndDateID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<MWQMSiteStartEndDate>(this.mwqmsitestartenddateListModel$, this.mwqmsitestartenddateDeleteModel$, x, HttpClientCommand.Delete, mwqmsitestartenddate);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<MWQMSiteStartEndDate>(this.mwqmsitestartenddateListModel$, this.mwqmsitestartenddateDeleteModel$, e);
      })))
    );
  }
}
