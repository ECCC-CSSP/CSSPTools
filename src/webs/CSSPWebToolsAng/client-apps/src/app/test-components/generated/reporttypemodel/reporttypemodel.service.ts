/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { ReportTypeModelTextModel } from './reporttypemodel.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesReportTypeModelText } from './reporttypemodel.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { ReportTypeModel } from '../../../models/generated/ReportTypeModel.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class ReportTypeModelService {
  /* Variables */
  reporttypemodelTextModel$: BehaviorSubject<ReportTypeModelTextModel> = new BehaviorSubject<ReportTypeModelTextModel>(<ReportTypeModelTextModel>{});
  reporttypemodelListModel$: BehaviorSubject<ReportTypeModel[]> = new BehaviorSubject<ReportTypeModel[]>(<ReportTypeModel[]>{});
  reporttypemodelGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  reporttypemodelPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  reporttypemodelPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  reporttypemodelDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesReportTypeModelText(this.reporttypemodelTextModel$);
    this.reporttypemodelTextModel$.next(<ReportTypeModelTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetReportTypeModelList() {
    this.httpClientService.BeforeHttpClient(this.reporttypemodelGetModel$);

    return this.httpClient.get<ReportTypeModel[]>('/api/ReportTypeModel').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ReportTypeModel>(this.reporttypemodelListModel$, this.reporttypemodelGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<ReportTypeModel>(this.reporttypemodelListModel$, this.reporttypemodelGetModel$, e);
      })))
    );
  }

  PutReportTypeModel(reporttypemodel: ReportTypeModel) {
    this.httpClientService.BeforeHttpClient(this.reporttypemodelPutModel$);

    return this.httpClient.put<ReportTypeModel>('/api/ReportTypeModel', reporttypemodel, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ReportTypeModel>(this.reporttypemodelListModel$, this.reporttypemodelPutModel$, x, HttpClientCommand.Put, reporttypemodel);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<ReportTypeModel>(this.reporttypemodelListModel$, this.reporttypemodelPutModel$, e);
      })))
    );
  }

  PostReportTypeModel(reporttypemodel: ReportTypeModel) {
    this.httpClientService.BeforeHttpClient(this.reporttypemodelPostModel$);

    return this.httpClient.post<ReportTypeModel>('/api/ReportTypeModel', reporttypemodel, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ReportTypeModel>(this.reporttypemodelListModel$, this.reporttypemodelPostModel$, x, HttpClientCommand.Post, reporttypemodel);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<ReportTypeModel>(this.reporttypemodelListModel$, this.reporttypemodelPostModel$, e);
      })))
    );
  }

  DeleteReportTypeModel(reporttypemodel: ReportTypeModel) {
    this.httpClientService.BeforeHttpClient(this.reporttypemodelDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/ReportTypeModel/${ reporttypemodel.ReportTypeModelID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ReportTypeModel>(this.reporttypemodelListModel$, this.reporttypemodelDeleteModel$, x, HttpClientCommand.Delete, reporttypemodel);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<ReportTypeModel>(this.reporttypemodelListModel$, this.reporttypemodelDeleteModel$, e);
      })))
    );
  }
}
