/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { PolSourceSiteEffectTermTextModel } from './polsourcesiteeffectterm.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesPolSourceSiteEffectTermText } from './polsourcesiteeffectterm.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { PolSourceSiteEffectTerm } from '../../../models/generated/PolSourceSiteEffectTerm.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class PolSourceSiteEffectTermService {
  /* Variables */
  polsourcesiteeffecttermTextModel$: BehaviorSubject<PolSourceSiteEffectTermTextModel> = new BehaviorSubject<PolSourceSiteEffectTermTextModel>(<PolSourceSiteEffectTermTextModel>{});
  polsourcesiteeffecttermListModel$: BehaviorSubject<PolSourceSiteEffectTerm[]> = new BehaviorSubject<PolSourceSiteEffectTerm[]>(<PolSourceSiteEffectTerm[]>{});
  polsourcesiteeffecttermGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  polsourcesiteeffecttermPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  polsourcesiteeffecttermPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  polsourcesiteeffecttermDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesPolSourceSiteEffectTermText(this.polsourcesiteeffecttermTextModel$);
    this.polsourcesiteeffecttermTextModel$.next(<PolSourceSiteEffectTermTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetPolSourceSiteEffectTermList() {
    this.httpClientService.BeforeHttpClient(this.polsourcesiteeffecttermGetModel$);

    return this.httpClient.get<PolSourceSiteEffectTerm[]>('/api/PolSourceSiteEffectTerm').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PolSourceSiteEffectTerm>(this.polsourcesiteeffecttermListModel$, this.polsourcesiteeffecttermGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<PolSourceSiteEffectTerm>(this.polsourcesiteeffecttermListModel$, this.polsourcesiteeffecttermGetModel$, e);
      })))
    );
  }

  PutPolSourceSiteEffectTerm(polsourcesiteeffectterm: PolSourceSiteEffectTerm) {
    this.httpClientService.BeforeHttpClient(this.polsourcesiteeffecttermPutModel$);

    return this.httpClient.put<PolSourceSiteEffectTerm>('/api/PolSourceSiteEffectTerm', polsourcesiteeffectterm, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PolSourceSiteEffectTerm>(this.polsourcesiteeffecttermListModel$, this.polsourcesiteeffecttermPutModel$, x, HttpClientCommand.Put, polsourcesiteeffectterm);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<PolSourceSiteEffectTerm>(this.polsourcesiteeffecttermListModel$, this.polsourcesiteeffecttermPutModel$, e);
      })))
    );
  }

  PostPolSourceSiteEffectTerm(polsourcesiteeffectterm: PolSourceSiteEffectTerm) {
    this.httpClientService.BeforeHttpClient(this.polsourcesiteeffecttermPostModel$);

    return this.httpClient.post<PolSourceSiteEffectTerm>('/api/PolSourceSiteEffectTerm', polsourcesiteeffectterm, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PolSourceSiteEffectTerm>(this.polsourcesiteeffecttermListModel$, this.polsourcesiteeffecttermPostModel$, x, HttpClientCommand.Post, polsourcesiteeffectterm);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<PolSourceSiteEffectTerm>(this.polsourcesiteeffecttermListModel$, this.polsourcesiteeffecttermPostModel$, e);
      })))
    );
  }

  DeletePolSourceSiteEffectTerm(polsourcesiteeffectterm: PolSourceSiteEffectTerm) {
    this.httpClientService.BeforeHttpClient(this.polsourcesiteeffecttermDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/PolSourceSiteEffectTerm/${ polsourcesiteeffectterm.PolSourceSiteEffectTermID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<PolSourceSiteEffectTerm>(this.polsourcesiteeffecttermListModel$, this.polsourcesiteeffecttermDeleteModel$, x, HttpClientCommand.Delete, polsourcesiteeffectterm);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<PolSourceSiteEffectTerm>(this.polsourcesiteeffecttermListModel$, this.polsourcesiteeffecttermDeleteModel$, e);
      })))
    );
  }
}
