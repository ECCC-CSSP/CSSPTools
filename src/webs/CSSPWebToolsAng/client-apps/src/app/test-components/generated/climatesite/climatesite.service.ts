/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { ClimateSiteTextModel } from './climatesite.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesClimateSiteText } from './climatesite.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { ClimateSite } from '../../../models/generated/ClimateSite.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class ClimateSiteService {
  /* Variables */
  climatesiteTextModel$: BehaviorSubject<ClimateSiteTextModel> = new BehaviorSubject<ClimateSiteTextModel>(<ClimateSiteTextModel>{});
  climatesiteListModel$: BehaviorSubject<ClimateSite[]> = new BehaviorSubject<ClimateSite[]>(<ClimateSite[]>{});
  climatesiteGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  climatesitePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  climatesitePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  climatesiteDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesClimateSiteText(this);
    this.climatesiteTextModel$.next(<ClimateSiteTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetClimateSiteList() {
    this.httpClientService.BeforeHttpClient(this.climatesiteGetModel$);

    return this.httpClient.get<ClimateSite[]>('/api/ClimateSite').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ClimateSite>(this.climatesiteListModel$, this.climatesiteGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<ClimateSite>(this.climatesiteListModel$, this.climatesiteGetModel$, e);
      })))
    );
  }

  PutClimateSite(climatesite: ClimateSite) {
    this.httpClientService.BeforeHttpClient(this.climatesitePutModel$);

    return this.httpClient.put<ClimateSite>('/api/ClimateSite', climatesite, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ClimateSite>(this.climatesiteListModel$, this.climatesitePutModel$, x, HttpClientCommand.Put, climatesite);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<ClimateSite>(this.climatesiteListModel$, this.climatesitePutModel$, e);
      })))
    );
  }

  PostClimateSite(climatesite: ClimateSite) {
    this.httpClientService.BeforeHttpClient(this.climatesitePostModel$);

    return this.httpClient.post<ClimateSite>('/api/ClimateSite', climatesite, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ClimateSite>(this.climatesiteListModel$, this.climatesitePostModel$, x, HttpClientCommand.Post, climatesite);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<ClimateSite>(this.climatesiteListModel$, this.climatesitePostModel$, e);
      })))
    );
  }

  DeleteClimateSite(climatesite: ClimateSite) {
    this.httpClientService.BeforeHttpClient(this.climatesiteDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/ClimateSite/${ climatesite.ClimateSiteID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<ClimateSite>(this.climatesiteListModel$, this.climatesiteDeleteModel$, x, HttpClientCommand.Delete, climatesite);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<ClimateSite>(this.climatesiteListModel$, this.climatesiteDeleteModel$, e);
      })))
    );
  }
}
