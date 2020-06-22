/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { PolSourceGroupingTextModel } from './polsourcegrouping.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesPolSourceGroupingText } from './polsourcegrouping.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { PolSourceGrouping } from '../../../models/generated/PolSourceGrouping.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class PolSourceGroupingService {
  /* Variables */
  polsourcegroupingTextModel$: BehaviorSubject<PolSourceGroupingTextModel> = new BehaviorSubject<PolSourceGroupingTextModel>(<PolSourceGroupingTextModel>{});
  polsourcegroupingListModel$: BehaviorSubject<PolSourceGrouping[]> = new BehaviorSubject<PolSourceGrouping[]>(<PolSourceGrouping[]>{});
  polsourcegroupingGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  polsourcegroupingPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  polsourcegroupingPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  polsourcegroupingDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesPolSourceGroupingText(this.polsourcegroupingTextModel$);
    this.polsourcegroupingTextModel$.next(<PolSourceGroupingTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetPolSourceGroupingList() {
    this.httpClientService.BeforeHttpClient(this.polsourcegroupingGetModel$);

    return this.httpClient.get<PolSourceGrouping[]>('/api/PolSourceGrouping').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PolSourceGrouping>(this.polsourcegroupingListModel$, this.polsourcegroupingGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<PolSourceGrouping>(this.polsourcegroupingListModel$, this.polsourcegroupingGetModel$, e);
      })))
    );
  }

  PutPolSourceGrouping(polsourcegrouping: PolSourceGrouping) {
    this.httpClientService.BeforeHttpClient(this.polsourcegroupingPutModel$);

    return this.httpClient.put<PolSourceGrouping>('/api/PolSourceGrouping', polsourcegrouping, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PolSourceGrouping>(this.polsourcegroupingListModel$, this.polsourcegroupingPutModel$, x, HttpClientCommand.Put, polsourcegrouping);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<PolSourceGrouping>(this.polsourcegroupingListModel$, this.polsourcegroupingPutModel$, e);
      })))
    );
  }

  PostPolSourceGrouping(polsourcegrouping: PolSourceGrouping) {
    this.httpClientService.BeforeHttpClient(this.polsourcegroupingPostModel$);

    return this.httpClient.post<PolSourceGrouping>('/api/PolSourceGrouping', polsourcegrouping, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PolSourceGrouping>(this.polsourcegroupingListModel$, this.polsourcegroupingPostModel$, x, HttpClientCommand.Post, polsourcegrouping);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<PolSourceGrouping>(this.polsourcegroupingListModel$, this.polsourcegroupingPostModel$, e);
      })))
    );
  }

  DeletePolSourceGrouping(polsourcegrouping: PolSourceGrouping) {
    this.httpClientService.BeforeHttpClient(this.polsourcegroupingDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/PolSourceGrouping/${ polsourcegrouping.PolSourceGroupingID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PolSourceGrouping>(this.polsourcegroupingListModel$, this.polsourcegroupingDeleteModel$, x, HttpClientCommand.Delete, polsourcegrouping);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<PolSourceGrouping>(this.polsourcegroupingListModel$, this.polsourcegroupingDeleteModel$, e);
      })))
    );
  }
}
