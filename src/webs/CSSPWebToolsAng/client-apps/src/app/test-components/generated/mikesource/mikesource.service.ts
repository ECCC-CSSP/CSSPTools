/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { MikeSourceTextModel } from './mikesource.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesMikeSourceText } from './mikesource.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { MikeSource } from '../../../models/generated/MikeSource.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class MikeSourceService {
  /* Variables */
  mikesourceTextModel$: BehaviorSubject<MikeSourceTextModel> = new BehaviorSubject<MikeSourceTextModel>(<MikeSourceTextModel>{});
  mikesourceListModel$: BehaviorSubject<MikeSource[]> = new BehaviorSubject<MikeSource[]>(<MikeSource[]>{});
  mikesourceGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  mikesourcePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  mikesourcePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  mikesourceDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesMikeSourceText(this);
    this.mikesourceTextModel$.next(<MikeSourceTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetMikeSourceList() {
    this.httpClientService.BeforeHttpClient(this.mikesourceGetModel$);

    return this.httpClient.get<MikeSource[]>('/api/MikeSource').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<MikeSource>(this.mikesourceListModel$, this.mikesourceGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<MikeSource>(this.mikesourceListModel$, this.mikesourceGetModel$, e);
      })))
    );
  }

  PutMikeSource(mikesource: MikeSource) {
    this.httpClientService.BeforeHttpClient(this.mikesourcePutModel$);

    return this.httpClient.put<MikeSource>('/api/MikeSource', mikesource, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<MikeSource>(this.mikesourceListModel$, this.mikesourcePutModel$, x, HttpClientCommand.Put, mikesource);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<MikeSource>(this.mikesourceListModel$, this.mikesourcePutModel$, e);
      })))
    );
  }

  PostMikeSource(mikesource: MikeSource) {
    this.httpClientService.BeforeHttpClient(this.mikesourcePostModel$);

    return this.httpClient.post<MikeSource>('/api/MikeSource', mikesource, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<MikeSource>(this.mikesourceListModel$, this.mikesourcePostModel$, x, HttpClientCommand.Post, mikesource);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<MikeSource>(this.mikesourceListModel$, this.mikesourcePostModel$, e);
      })))
    );
  }

  DeleteMikeSource(mikesource: MikeSource) {
    this.httpClientService.BeforeHttpClient(this.mikesourceDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/MikeSource/${ mikesource.MikeSourceID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<MikeSource>(this.mikesourceListModel$, this.mikesourceDeleteModel$, x, HttpClientCommand.Delete, mikesource);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<MikeSource>(this.mikesourceListModel$, this.mikesourceDeleteModel$, e);
      })))
    );
  }
}
