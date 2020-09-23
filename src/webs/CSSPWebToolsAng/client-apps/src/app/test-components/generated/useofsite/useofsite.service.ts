/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { UseOfSiteTextModel } from './useofsite.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesUseOfSiteText } from './useofsite.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { UseOfSite } from '../../../models/generated/UseOfSite.model';
import { HttpRequestModel } from '../../../models/HttpRequest.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class UseOfSiteService {
  /* Variables */
  useofsiteTextModel$: BehaviorSubject<UseOfSiteTextModel> = new BehaviorSubject<UseOfSiteTextModel>(<UseOfSiteTextModel>{});
  useofsiteListModel$: BehaviorSubject<UseOfSite[]> = new BehaviorSubject<UseOfSite[]>(<UseOfSite[]>{});
  useofsiteGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  useofsitePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  useofsitePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  useofsiteDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesUseOfSiteText(this.useofsiteTextModel$);
    this.useofsiteTextModel$.next(<UseOfSiteTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetUseOfSiteList() {
    this.httpClientService.BeforeHttpClient(this.useofsiteGetModel$);

    return this.httpClient.get<UseOfSite[]>('/api/UseOfSite').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<UseOfSite>(this.useofsiteListModel$, this.useofsiteGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<UseOfSite>(this.useofsiteListModel$, this.useofsiteGetModel$, e);
      })))
    );
  }

  PutUseOfSite(useofsite: UseOfSite) {
    this.httpClientService.BeforeHttpClient(this.useofsitePutModel$);

    return this.httpClient.put<UseOfSite>('/api/UseOfSite', useofsite, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<UseOfSite>(this.useofsiteListModel$, this.useofsitePutModel$, x, HttpClientCommand.Put, useofsite);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<UseOfSite>(this.useofsiteListModel$, this.useofsitePutModel$, e);
      })))
    );
  }

  PostUseOfSite(useofsite: UseOfSite) {
    this.httpClientService.BeforeHttpClient(this.useofsitePostModel$);

    return this.httpClient.post<UseOfSite>('/api/UseOfSite', useofsite, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<UseOfSite>(this.useofsiteListModel$, this.useofsitePostModel$, x, HttpClientCommand.Post, useofsite);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<UseOfSite>(this.useofsiteListModel$, this.useofsitePostModel$, e);
      })))
    );
  }

  DeleteUseOfSite(useofsite: UseOfSite) {
    this.httpClientService.BeforeHttpClient(this.useofsiteDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/UseOfSite/${ useofsite.UseOfSiteID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<UseOfSite>(this.useofsiteListModel$, this.useofsiteDeleteModel$, x, HttpClientCommand.Delete, useofsite);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<UseOfSite>(this.useofsiteListModel$, this.useofsiteDeleteModel$, e);
      })))
    );
  }
}
