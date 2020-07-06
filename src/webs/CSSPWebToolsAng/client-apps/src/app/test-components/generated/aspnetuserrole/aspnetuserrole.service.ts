/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { AspNetUserRoleTextModel } from './aspnetuserrole.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesAspNetUserRoleText } from './aspnetuserrole.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { AspNetUserRole } from '../../../models/generated/AspNetUserRole.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class AspNetUserRoleService {
  /* Variables */
  aspnetuserroleTextModel$: BehaviorSubject<AspNetUserRoleTextModel> = new BehaviorSubject<AspNetUserRoleTextModel>(<AspNetUserRoleTextModel>{});
  aspnetuserroleListModel$: BehaviorSubject<AspNetUserRole[]> = new BehaviorSubject<AspNetUserRole[]>(<AspNetUserRole[]>{});
  aspnetuserroleGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  aspnetuserrolePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  aspnetuserrolePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  aspnetuserroleDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesAspNetUserRoleText(this.aspnetuserroleTextModel$);
    this.aspnetuserroleTextModel$.next(<AspNetUserRoleTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetAspNetUserRoleList() {
    this.httpClientService.BeforeHttpClient(this.aspnetuserroleGetModel$);

    return this.httpClient.get<AspNetUserRole[]>('/api/AspNetUserRole').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AspNetUserRole>(this.aspnetuserroleListModel$, this.aspnetuserroleGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AspNetUserRole>(this.aspnetuserroleListModel$, this.aspnetuserroleGetModel$, e);
      })))
    );
  }

  PutAspNetUserRole(aspnetuserrole: AspNetUserRole) {
    this.httpClientService.BeforeHttpClient(this.aspnetuserrolePutModel$);

    return this.httpClient.put<AspNetUserRole>('/api/AspNetUserRole', aspnetuserrole, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AspNetUserRole>(this.aspnetuserroleListModel$, this.aspnetuserrolePutModel$, x, HttpClientCommand.Put, aspnetuserrole);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<AspNetUserRole>(this.aspnetuserroleListModel$, this.aspnetuserrolePutModel$, e);
      })))
    );
  }

  PostAspNetUserRole(aspnetuserrole: AspNetUserRole) {
    this.httpClientService.BeforeHttpClient(this.aspnetuserrolePostModel$);

    return this.httpClient.post<AspNetUserRole>('/api/AspNetUserRole', aspnetuserrole, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AspNetUserRole>(this.aspnetuserroleListModel$, this.aspnetuserrolePostModel$, x, HttpClientCommand.Post, aspnetuserrole);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AspNetUserRole>(this.aspnetuserroleListModel$, this.aspnetuserrolePostModel$, e);
      })))
    );
  }

  DeleteAspNetUserRole(aspnetuserrole: AspNetUserRole) {
    this.httpClientService.BeforeHttpClient(this.aspnetuserroleDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/AspNetUserRole/${ aspnetuserrole.AspNetUserRoleID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AspNetUserRole>(this.aspnetuserroleListModel$, this.aspnetuserroleDeleteModel$, x, HttpClientCommand.Delete, aspnetuserrole);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AspNetUserRole>(this.aspnetuserroleListModel$, this.aspnetuserroleDeleteModel$, e);
      })))
    );
  }
}
