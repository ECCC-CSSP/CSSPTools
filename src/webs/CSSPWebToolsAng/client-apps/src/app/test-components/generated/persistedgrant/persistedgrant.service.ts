/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { PersistedGrantTextModel } from './persistedgrant.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesPersistedGrantText } from './persistedgrant.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { PersistedGrant } from '../../../models/generated/PersistedGrant.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class PersistedGrantService {
  /* Variables */
  persistedgrantTextModel$: BehaviorSubject<PersistedGrantTextModel> = new BehaviorSubject<PersistedGrantTextModel>(<PersistedGrantTextModel>{});
  persistedgrantListModel$: BehaviorSubject<PersistedGrant[]> = new BehaviorSubject<PersistedGrant[]>(<PersistedGrant[]>{});
  persistedgrantGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  persistedgrantPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  persistedgrantPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  persistedgrantDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesPersistedGrantText(this.persistedgrantTextModel$);
    this.persistedgrantTextModel$.next(<PersistedGrantTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetPersistedGrantList() {
    this.httpClientService.BeforeHttpClient(this.persistedgrantGetModel$);

    return this.httpClient.get<PersistedGrant[]>('/api/PersistedGrant').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PersistedGrant>(this.persistedgrantListModel$, this.persistedgrantGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<PersistedGrant>(this.persistedgrantListModel$, this.persistedgrantGetModel$, e);
      })))
    );
  }

  PutPersistedGrant(persistedgrant: PersistedGrant) {
    this.httpClientService.BeforeHttpClient(this.persistedgrantPutModel$);

    return this.httpClient.put<PersistedGrant>('/api/PersistedGrant', persistedgrant, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PersistedGrant>(this.persistedgrantListModel$, this.persistedgrantPutModel$, x, HttpClientCommand.Put, persistedgrant);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<PersistedGrant>(this.persistedgrantListModel$, this.persistedgrantPutModel$, e);
      })))
    );
  }

  PostPersistedGrant(persistedgrant: PersistedGrant) {
    this.httpClientService.BeforeHttpClient(this.persistedgrantPostModel$);

    return this.httpClient.post<PersistedGrant>('/api/PersistedGrant', persistedgrant, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PersistedGrant>(this.persistedgrantListModel$, this.persistedgrantPostModel$, x, HttpClientCommand.Post, persistedgrant);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<PersistedGrant>(this.persistedgrantListModel$, this.persistedgrantPostModel$, e);
      })))
    );
  }

  DeletePersistedGrant(persistedgrant: PersistedGrant) {
    this.httpClientService.BeforeHttpClient(this.persistedgrantDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/PersistedGrant/${ persistedgrant.PersistedGrantID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PersistedGrant>(this.persistedgrantListModel$, this.persistedgrantDeleteModel$, x, HttpClientCommand.Delete, persistedgrant);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<PersistedGrant>(this.persistedgrantListModel$, this.persistedgrantDeleteModel$, e);
      })))
    );
  }
}