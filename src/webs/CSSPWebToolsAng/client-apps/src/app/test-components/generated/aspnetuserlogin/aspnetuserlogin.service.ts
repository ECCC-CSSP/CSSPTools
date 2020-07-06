/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { AspNetUserLoginTextModel } from './aspnetuserlogin.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesAspNetUserLoginText } from './aspnetuserlogin.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { AspNetUserLogin } from '../../../models/generated/AspNetUserLogin.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class AspNetUserLoginService {
  /* Variables */
  aspnetuserloginTextModel$: BehaviorSubject<AspNetUserLoginTextModel> = new BehaviorSubject<AspNetUserLoginTextModel>(<AspNetUserLoginTextModel>{});
  aspnetuserloginListModel$: BehaviorSubject<AspNetUserLogin[]> = new BehaviorSubject<AspNetUserLogin[]>(<AspNetUserLogin[]>{});
  aspnetuserloginGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  aspnetuserloginPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  aspnetuserloginPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  aspnetuserloginDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesAspNetUserLoginText(this.aspnetuserloginTextModel$);
    this.aspnetuserloginTextModel$.next(<AspNetUserLoginTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetAspNetUserLoginList() {
    this.httpClientService.BeforeHttpClient(this.aspnetuserloginGetModel$);

    return this.httpClient.get<AspNetUserLogin[]>('/api/AspNetUserLogin').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AspNetUserLogin>(this.aspnetuserloginListModel$, this.aspnetuserloginGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AspNetUserLogin>(this.aspnetuserloginListModel$, this.aspnetuserloginGetModel$, e);
      })))
    );
  }

  PutAspNetUserLogin(aspnetuserlogin: AspNetUserLogin) {
    this.httpClientService.BeforeHttpClient(this.aspnetuserloginPutModel$);

    return this.httpClient.put<AspNetUserLogin>('/api/AspNetUserLogin', aspnetuserlogin, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AspNetUserLogin>(this.aspnetuserloginListModel$, this.aspnetuserloginPutModel$, x, HttpClientCommand.Put, aspnetuserlogin);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<AspNetUserLogin>(this.aspnetuserloginListModel$, this.aspnetuserloginPutModel$, e);
      })))
    );
  }

  PostAspNetUserLogin(aspnetuserlogin: AspNetUserLogin) {
    this.httpClientService.BeforeHttpClient(this.aspnetuserloginPostModel$);

    return this.httpClient.post<AspNetUserLogin>('/api/AspNetUserLogin', aspnetuserlogin, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AspNetUserLogin>(this.aspnetuserloginListModel$, this.aspnetuserloginPostModel$, x, HttpClientCommand.Post, aspnetuserlogin);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AspNetUserLogin>(this.aspnetuserloginListModel$, this.aspnetuserloginPostModel$, e);
      })))
    );
  }

  DeleteAspNetUserLogin(aspnetuserlogin: AspNetUserLogin) {
    this.httpClientService.BeforeHttpClient(this.aspnetuserloginDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/AspNetUserLogin/${ aspnetuserlogin.AspNetUserLoginID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AspNetUserLogin>(this.aspnetuserloginListModel$, this.aspnetuserloginDeleteModel$, x, HttpClientCommand.Delete, aspnetuserlogin);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AspNetUserLogin>(this.aspnetuserloginListModel$, this.aspnetuserloginDeleteModel$, e);
      })))
    );
  }
}
