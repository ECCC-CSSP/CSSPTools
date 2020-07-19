/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { WebSectorTextModel } from './websector.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesWebSectorText } from './websector.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { WebSector } from '../../../models/generated/WebSector.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class WebSectorService {
  /* Variables */
  websectorTextModel$: BehaviorSubject<WebSectorTextModel> = new BehaviorSubject<WebSectorTextModel>(<WebSectorTextModel>{});
  websectorListModel$: BehaviorSubject<WebSector[]> = new BehaviorSubject<WebSector[]>(<WebSector[]>{});
  websectorGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  websectorPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  websectorPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  websectorDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesWebSectorText(this.websectorTextModel$);
    this.websectorTextModel$.next(<WebSectorTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetWebSectorList() {
    this.httpClientService.BeforeHttpClient(this.websectorGetModel$);

    return this.httpClient.get<WebSector[]>('/api/WebSector').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebSector>(this.websectorListModel$, this.websectorGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<WebSector>(this.websectorListModel$, this.websectorGetModel$, e);
      })))
    );
  }

  PutWebSector(websector: WebSector) {
    this.httpClientService.BeforeHttpClient(this.websectorPutModel$);

    return this.httpClient.put<WebSector>('/api/WebSector', websector, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebSector>(this.websectorListModel$, this.websectorPutModel$, x, HttpClientCommand.Put, websector);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<WebSector>(this.websectorListModel$, this.websectorPutModel$, e);
      })))
    );
  }

  PostWebSector(websector: WebSector) {
    this.httpClientService.BeforeHttpClient(this.websectorPostModel$);

    return this.httpClient.post<WebSector>('/api/WebSector', websector, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebSector>(this.websectorListModel$, this.websectorPostModel$, x, HttpClientCommand.Post, websector);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<WebSector>(this.websectorListModel$, this.websectorPostModel$, e);
      })))
    );
  }

  DeleteWebSector(websector: WebSector) {
    this.httpClientService.BeforeHttpClient(this.websectorDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/WebSector/${ websector.WebSectorID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<WebSector>(this.websectorListModel$, this.websectorDeleteModel$, x, HttpClientCommand.Delete, websector);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<WebSector>(this.websectorListModel$, this.websectorDeleteModel$, e);
      })))
    );
  }
}
