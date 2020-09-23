/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { PolSourceSiteTextModel } from './polsourcesite.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesPolSourceSiteText } from './polsourcesite.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { PolSourceSite } from '../../../models/generated/PolSourceSite.model';
import { HttpRequestModel } from '../../../models/HttpRequest.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class PolSourceSiteService {
  /* Variables */
  polsourcesiteTextModel$: BehaviorSubject<PolSourceSiteTextModel> = new BehaviorSubject<PolSourceSiteTextModel>(<PolSourceSiteTextModel>{});
  polsourcesiteListModel$: BehaviorSubject<PolSourceSite[]> = new BehaviorSubject<PolSourceSite[]>(<PolSourceSite[]>{});
  polsourcesiteGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  polsourcesitePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  polsourcesitePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  polsourcesiteDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesPolSourceSiteText(this.polsourcesiteTextModel$);
    this.polsourcesiteTextModel$.next(<PolSourceSiteTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetPolSourceSiteList() {
    this.httpClientService.BeforeHttpClient(this.polsourcesiteGetModel$);

    return this.httpClient.get<PolSourceSite[]>('/api/PolSourceSite').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PolSourceSite>(this.polsourcesiteListModel$, this.polsourcesiteGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<PolSourceSite>(this.polsourcesiteListModel$, this.polsourcesiteGetModel$, e);
      })))
    );
  }

  PutPolSourceSite(polsourcesite: PolSourceSite) {
    this.httpClientService.BeforeHttpClient(this.polsourcesitePutModel$);

    return this.httpClient.put<PolSourceSite>('/api/PolSourceSite', polsourcesite, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PolSourceSite>(this.polsourcesiteListModel$, this.polsourcesitePutModel$, x, HttpClientCommand.Put, polsourcesite);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<PolSourceSite>(this.polsourcesiteListModel$, this.polsourcesitePutModel$, e);
      })))
    );
  }

  PostPolSourceSite(polsourcesite: PolSourceSite) {
    this.httpClientService.BeforeHttpClient(this.polsourcesitePostModel$);

    return this.httpClient.post<PolSourceSite>('/api/PolSourceSite', polsourcesite, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PolSourceSite>(this.polsourcesiteListModel$, this.polsourcesitePostModel$, x, HttpClientCommand.Post, polsourcesite);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<PolSourceSite>(this.polsourcesiteListModel$, this.polsourcesitePostModel$, e);
      })))
    );
  }

  DeletePolSourceSite(polsourcesite: PolSourceSite) {
    this.httpClientService.BeforeHttpClient(this.polsourcesiteDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/PolSourceSite/${ polsourcesite.PolSourceSiteID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PolSourceSite>(this.polsourcesiteListModel$, this.polsourcesiteDeleteModel$, x, HttpClientCommand.Delete, polsourcesite);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<PolSourceSite>(this.polsourcesiteListModel$, this.polsourcesiteDeleteModel$, e);
      })))
    );
  }
}
