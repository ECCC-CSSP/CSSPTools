/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { LabSheetTubeMPNDetailTextModel } from './labsheettubempndetail.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesLabSheetTubeMPNDetailText } from './labsheettubempndetail.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { LabSheetTubeMPNDetail } from '../../../models/generated/LabSheetTubeMPNDetail.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class LabSheetTubeMPNDetailService {
  /* Variables */
  labsheettubempndetailTextModel$: BehaviorSubject<LabSheetTubeMPNDetailTextModel> = new BehaviorSubject<LabSheetTubeMPNDetailTextModel>(<LabSheetTubeMPNDetailTextModel>{});
  labsheettubempndetailListModel$: BehaviorSubject<LabSheetTubeMPNDetail[]> = new BehaviorSubject<LabSheetTubeMPNDetail[]>(<LabSheetTubeMPNDetail[]>{});
  labsheettubempndetailGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  labsheettubempndetailPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  labsheettubempndetailPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  labsheettubempndetailDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesLabSheetTubeMPNDetailText(this.labsheettubempndetailTextModel$);
    this.labsheettubempndetailTextModel$.next(<LabSheetTubeMPNDetailTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetLabSheetTubeMPNDetailList() {
    this.httpClientService.BeforeHttpClient(this.labsheettubempndetailGetModel$);

    return this.httpClient.get<LabSheetTubeMPNDetail[]>('/api/LabSheetTubeMPNDetail').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<LabSheetTubeMPNDetail>(this.labsheettubempndetailListModel$, this.labsheettubempndetailGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<LabSheetTubeMPNDetail>(this.labsheettubempndetailListModel$, this.labsheettubempndetailGetModel$, e);
      })))
    );
  }

  PutLabSheetTubeMPNDetail(labsheettubempndetail: LabSheetTubeMPNDetail) {
    this.httpClientService.BeforeHttpClient(this.labsheettubempndetailPutModel$);

    return this.httpClient.put<LabSheetTubeMPNDetail>('/api/LabSheetTubeMPNDetail', labsheettubempndetail, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<LabSheetTubeMPNDetail>(this.labsheettubempndetailListModel$, this.labsheettubempndetailPutModel$, x, HttpClientCommand.Put, labsheettubempndetail);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<LabSheetTubeMPNDetail>(this.labsheettubempndetailListModel$, this.labsheettubempndetailPutModel$, e);
      })))
    );
  }

  PostLabSheetTubeMPNDetail(labsheettubempndetail: LabSheetTubeMPNDetail) {
    this.httpClientService.BeforeHttpClient(this.labsheettubempndetailPostModel$);

    return this.httpClient.post<LabSheetTubeMPNDetail>('/api/LabSheetTubeMPNDetail', labsheettubempndetail, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<LabSheetTubeMPNDetail>(this.labsheettubempndetailListModel$, this.labsheettubempndetailPostModel$, x, HttpClientCommand.Post, labsheettubempndetail);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<LabSheetTubeMPNDetail>(this.labsheettubempndetailListModel$, this.labsheettubempndetailPostModel$, e);
      })))
    );
  }

  DeleteLabSheetTubeMPNDetail(labsheettubempndetail: LabSheetTubeMPNDetail) {
    this.httpClientService.BeforeHttpClient(this.labsheettubempndetailDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/LabSheetTubeMPNDetail/${ labsheettubempndetail.LabSheetTubeMPNDetailID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<LabSheetTubeMPNDetail>(this.labsheettubempndetailListModel$, this.labsheettubempndetailDeleteModel$, x, HttpClientCommand.Delete, labsheettubempndetail);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<LabSheetTubeMPNDetail>(this.labsheettubempndetailListModel$, this.labsheettubempndetailDeleteModel$, e);
      })))
    );
  }
}
