/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { AspNetUserTokenTextModel } from './aspnetusertoken.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesAspNetUserTokenText } from './aspnetusertoken.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { AspNetUserToken } from '../../../models/generated/AspNetUserToken.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class AspNetUserTokenService {
  /* Variables */
  aspnetusertokenTextModel$: BehaviorSubject<AspNetUserTokenTextModel> = new BehaviorSubject<AspNetUserTokenTextModel>(<AspNetUserTokenTextModel>{});
  aspnetusertokenListModel$: BehaviorSubject<AspNetUserToken[]> = new BehaviorSubject<AspNetUserToken[]>(<AspNetUserToken[]>{});
  aspnetusertokenGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  aspnetusertokenPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  aspnetusertokenPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  aspnetusertokenDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesAspNetUserTokenText(this.aspnetusertokenTextModel$);
    this.aspnetusertokenTextModel$.next(<AspNetUserTokenTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetAspNetUserTokenList() {
    this.httpClientService.BeforeHttpClient(this.aspnetusertokenGetModel$);

    return this.httpClient.get<AspNetUserToken[]>('/api/AspNetUserToken').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AspNetUserToken>(this.aspnetusertokenListModel$, this.aspnetusertokenGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AspNetUserToken>(this.aspnetusertokenListModel$, this.aspnetusertokenGetModel$, e);
      })))
    );
  }

  PutAspNetUserToken(aspnetusertoken: AspNetUserToken) {
    this.httpClientService.BeforeHttpClient(this.aspnetusertokenPutModel$);

    return this.httpClient.put<AspNetUserToken>('/api/AspNetUserToken', aspnetusertoken, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AspNetUserToken>(this.aspnetusertokenListModel$, this.aspnetusertokenPutModel$, x, HttpClientCommand.Put, aspnetusertoken);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<AspNetUserToken>(this.aspnetusertokenListModel$, this.aspnetusertokenPutModel$, e);
      })))
    );
  }

  PostAspNetUserToken(aspnetusertoken: AspNetUserToken) {
    this.httpClientService.BeforeHttpClient(this.aspnetusertokenPostModel$);

    return this.httpClient.post<AspNetUserToken>('/api/AspNetUserToken', aspnetusertoken, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AspNetUserToken>(this.aspnetusertokenListModel$, this.aspnetusertokenPostModel$, x, HttpClientCommand.Post, aspnetusertoken);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AspNetUserToken>(this.aspnetusertokenListModel$, this.aspnetusertokenPostModel$, e);
      })))
    );
  }

  DeleteAspNetUserToken(aspnetusertoken: AspNetUserToken) {
    this.httpClientService.BeforeHttpClient(this.aspnetusertokenDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/AspNetUserToken/${ aspnetusertoken.AspNetUserTokenID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AspNetUserToken>(this.aspnetusertokenListModel$, this.aspnetusertokenDeleteModel$, x, HttpClientCommand.Delete, aspnetusertoken);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AspNetUserToken>(this.aspnetusertokenListModel$, this.aspnetusertokenDeleteModel$, e);
      })))
    );
  }
}
