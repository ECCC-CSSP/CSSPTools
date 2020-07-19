/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { WebMunicipalitiesTextModel } from './webmunicipalities.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesWebMunicipalitiesText } from './webmunicipalities.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { WebMunicipalities } from '../../../models/generated/WebMunicipalities.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class WebMunicipalitiesService {
  /* Variables */
  webmunicipalitiesTextModel$: BehaviorSubject<WebMunicipalitiesTextModel> = new BehaviorSubject<WebMunicipalitiesTextModel>(<WebMunicipalitiesTextModel>{});
  webmunicipalitiesListModel$: BehaviorSubject<WebMunicipalities[]> = new BehaviorSubject<WebMunicipalities[]>(<WebMunicipalities[]>{});
  webmunicipalitiesGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  webmunicipalitiesPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  webmunicipalitiesPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  webmunicipalitiesDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesWebMunicipalitiesText(this.webmunicipalitiesTextModel$);
    this.webmunicipalitiesTextModel$.next(<WebMunicipalitiesTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetWebMunicipalitiesList() {
    this.httpClientService.BeforeHttpClient(this.webmunicipalitiesGetModel$);

    return this.httpClient.get<WebMunicipalities[]>('/api/WebMunicipalities').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebMunicipalities>(this.webmunicipalitiesListModel$, this.webmunicipalitiesGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<WebMunicipalities>(this.webmunicipalitiesListModel$, this.webmunicipalitiesGetModel$, e);
      })))
    );
  }

  PutWebMunicipalities(webmunicipalities: WebMunicipalities) {
    this.httpClientService.BeforeHttpClient(this.webmunicipalitiesPutModel$);

    return this.httpClient.put<WebMunicipalities>('/api/WebMunicipalities', webmunicipalities, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebMunicipalities>(this.webmunicipalitiesListModel$, this.webmunicipalitiesPutModel$, x, HttpClientCommand.Put, webmunicipalities);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<WebMunicipalities>(this.webmunicipalitiesListModel$, this.webmunicipalitiesPutModel$, e);
      })))
    );
  }

  PostWebMunicipalities(webmunicipalities: WebMunicipalities) {
    this.httpClientService.BeforeHttpClient(this.webmunicipalitiesPostModel$);

    return this.httpClient.post<WebMunicipalities>('/api/WebMunicipalities', webmunicipalities, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebMunicipalities>(this.webmunicipalitiesListModel$, this.webmunicipalitiesPostModel$, x, HttpClientCommand.Post, webmunicipalities);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<WebMunicipalities>(this.webmunicipalitiesListModel$, this.webmunicipalitiesPostModel$, e);
      })))
    );
  }

  DeleteWebMunicipalities(webmunicipalities: WebMunicipalities) {
    this.httpClientService.BeforeHttpClient(this.webmunicipalitiesDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/WebMunicipalities/${ webmunicipalities.WebMunicipalitiesID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebMunicipalities>(this.webmunicipalitiesListModel$, this.webmunicipalitiesDeleteModel$, x, HttpClientCommand.Delete, webmunicipalities);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<WebMunicipalities>(this.webmunicipalitiesListModel$, this.webmunicipalitiesDeleteModel$, e);
      })))
    );
  }
}
