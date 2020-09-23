/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { MapInfoTextModel } from './mapinfo.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesMapInfoText } from './mapinfo.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { MapInfo } from '../../../models/generated/MapInfo.model';
import { HttpRequestModel } from '../../../models/HttpRequest.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class MapInfoService {
  /* Variables */
  mapinfoTextModel$: BehaviorSubject<MapInfoTextModel> = new BehaviorSubject<MapInfoTextModel>(<MapInfoTextModel>{});
  mapinfoListModel$: BehaviorSubject<MapInfo[]> = new BehaviorSubject<MapInfo[]>(<MapInfo[]>{});
  mapinfoGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  mapinfoPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  mapinfoPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  mapinfoDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesMapInfoText(this.mapinfoTextModel$);
    this.mapinfoTextModel$.next(<MapInfoTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetMapInfoList() {
    this.httpClientService.BeforeHttpClient(this.mapinfoGetModel$);

    return this.httpClient.get<MapInfo[]>('/api/MapInfo').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<MapInfo>(this.mapinfoListModel$, this.mapinfoGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<MapInfo>(this.mapinfoListModel$, this.mapinfoGetModel$, e);
      })))
    );
  }

  PutMapInfo(mapinfo: MapInfo) {
    this.httpClientService.BeforeHttpClient(this.mapinfoPutModel$);

    return this.httpClient.put<MapInfo>('/api/MapInfo', mapinfo, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<MapInfo>(this.mapinfoListModel$, this.mapinfoPutModel$, x, HttpClientCommand.Put, mapinfo);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<MapInfo>(this.mapinfoListModel$, this.mapinfoPutModel$, e);
      })))
    );
  }

  PostMapInfo(mapinfo: MapInfo) {
    this.httpClientService.BeforeHttpClient(this.mapinfoPostModel$);

    return this.httpClient.post<MapInfo>('/api/MapInfo', mapinfo, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<MapInfo>(this.mapinfoListModel$, this.mapinfoPostModel$, x, HttpClientCommand.Post, mapinfo);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<MapInfo>(this.mapinfoListModel$, this.mapinfoPostModel$, e);
      })))
    );
  }

  DeleteMapInfo(mapinfo: MapInfo) {
    this.httpClientService.BeforeHttpClient(this.mapinfoDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/MapInfo/${ mapinfo.MapInfoID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<MapInfo>(this.mapinfoListModel$, this.mapinfoDeleteModel$, x, HttpClientCommand.Delete, mapinfo);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<MapInfo>(this.mapinfoListModel$, this.mapinfoDeleteModel$, e);
      })))
    );
  }
}
