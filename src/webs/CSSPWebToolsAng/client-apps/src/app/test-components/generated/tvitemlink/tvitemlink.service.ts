/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { TVItemLinkTextModel } from './tvitemlink.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesTVItemLinkText } from './tvitemlink.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { TVItemLink } from '../../../models/generated/TVItemLink.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class TVItemLinkService {
  /* Variables */
  tvitemlinkTextModel$: BehaviorSubject<TVItemLinkTextModel> = new BehaviorSubject<TVItemLinkTextModel>(<TVItemLinkTextModel>{});
  tvitemlinkListModel$: BehaviorSubject<TVItemLink[]> = new BehaviorSubject<TVItemLink[]>(<TVItemLink[]>{});
  tvitemlinkGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tvitemlinkPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tvitemlinkPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tvitemlinkDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesTVItemLinkText(this.tvitemlinkTextModel$);
    this.tvitemlinkTextModel$.next(<TVItemLinkTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetTVItemLinkList() {
    this.httpClientService.BeforeHttpClient(this.tvitemlinkGetModel$);

    return this.httpClient.get<TVItemLink[]>('/api/TVItemLink').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<TVItemLink>(this.tvitemlinkListModel$, this.tvitemlinkGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<TVItemLink>(this.tvitemlinkListModel$, this.tvitemlinkGetModel$, e);
      })))
    );
  }

  PutTVItemLink(tvitemlink: TVItemLink) {
    this.httpClientService.BeforeHttpClient(this.tvitemlinkPutModel$);

    return this.httpClient.put<TVItemLink>('/api/TVItemLink', tvitemlink, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<TVItemLink>(this.tvitemlinkListModel$, this.tvitemlinkPutModel$, x, HttpClientCommand.Put, tvitemlink);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<TVItemLink>(this.tvitemlinkListModel$, this.tvitemlinkPutModel$, e);
      })))
    );
  }

  PostTVItemLink(tvitemlink: TVItemLink) {
    this.httpClientService.BeforeHttpClient(this.tvitemlinkPostModel$);

    return this.httpClient.post<TVItemLink>('/api/TVItemLink', tvitemlink, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<TVItemLink>(this.tvitemlinkListModel$, this.tvitemlinkPostModel$, x, HttpClientCommand.Post, tvitemlink);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<TVItemLink>(this.tvitemlinkListModel$, this.tvitemlinkPostModel$, e);
      })))
    );
  }

  DeleteTVItemLink(tvitemlink: TVItemLink) {
    this.httpClientService.BeforeHttpClient(this.tvitemlinkDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/TVItemLink/${ tvitemlink.TVItemLinkID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<TVItemLink>(this.tvitemlinkListModel$, this.tvitemlinkDeleteModel$, x, HttpClientCommand.Delete, tvitemlink);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<TVItemLink>(this.tvitemlinkListModel$, this.tvitemlinkDeleteModel$, e);
      })))
    );
  }
}
