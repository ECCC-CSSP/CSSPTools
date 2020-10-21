/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { TideSiteTextModel } from './tidesite.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesTideSiteText } from './tidesite.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { TideSite } from '../../../models/generated/TideSite.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class TideSiteService {
  /* Variables */
  tidesiteTextModel$: BehaviorSubject<TideSiteTextModel> = new BehaviorSubject<TideSiteTextModel>(<TideSiteTextModel>{});
  tidesiteListModel$: BehaviorSubject<TideSite[]> = new BehaviorSubject<TideSite[]>(<TideSite[]>{});
  tidesiteGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tidesitePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tidesitePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tidesiteDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesTideSiteText(this.tidesiteTextModel$);
    this.tidesiteTextModel$.next(<TideSiteTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetTideSiteList() {
    this.httpClientService.BeforeHttpClient(this.tidesiteGetModel$);

    return this.httpClient.get<TideSite[]>('/api/TideSite').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<TideSite>(this.tidesiteListModel$, this.tidesiteGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<TideSite>(this.tidesiteListModel$, this.tidesiteGetModel$, e);
      })))
    );
  }

  PutTideSite(tidesite: TideSite) {
    this.httpClientService.BeforeHttpClient(this.tidesitePutModel$);

    return this.httpClient.put<TideSite>('/api/TideSite', tidesite, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<TideSite>(this.tidesiteListModel$, this.tidesitePutModel$, x, HttpClientCommand.Put, tidesite);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<TideSite>(this.tidesiteListModel$, this.tidesitePutModel$, e);
      })))
    );
  }

  PostTideSite(tidesite: TideSite) {
    this.httpClientService.BeforeHttpClient(this.tidesitePostModel$);

    return this.httpClient.post<TideSite>('/api/TideSite', tidesite, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<TideSite>(this.tidesiteListModel$, this.tidesitePostModel$, x, HttpClientCommand.Post, tidesite);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<TideSite>(this.tidesiteListModel$, this.tidesitePostModel$, e);
      })))
    );
  }

  DeleteTideSite(tidesite: TideSite) {
    this.httpClientService.BeforeHttpClient(this.tidesiteDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/TideSite/${ tidesite.TideSiteID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<TideSite>(this.tidesiteListModel$, this.tidesiteDeleteModel$, x, HttpClientCommand.Delete, tidesite);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<TideSite>(this.tidesiteListModel$, this.tidesiteDeleteModel$, e);
      })))
    );
  }
}
