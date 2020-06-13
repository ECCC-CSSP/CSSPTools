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
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { MapInfo } from '../../../models/generated/MapInfo.model';
import { HttpRequestModel } from '../../../models/http.model';

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
  mapinfoList: MapInfo[] = [];
  private oldURL: string;
  private router: Router;

  /* Constructors */
  constructor(private httpClient: HttpClient) {
    LoadLocalesMapInfoText(this);
    this.mapinfoTextModel$.next(<MapInfoTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetMapInfoList(router: Router) {
    this.BeforeHttpClient(this.mapinfoGetModel$, router);

    return this.httpClient.get<MapInfo[]>('/api/MapInfo').pipe(
      map((x: any) => {
        this.DoSuccess(this.mapinfoGetModel$, x, 'Get', null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.mapinfoGetModel$, e, 'Get');
      })))
    );
  }

  PutMapInfo(mapinfo: MapInfo, router: Router) {
    this.BeforeHttpClient(this.mapinfoPutModel$, router);

    return this.httpClient.put<MapInfo>('/api/MapInfo', mapinfo, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.mapinfoPutModel$, x, 'Put', mapinfo);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.mapinfoPutModel$, e, 'Put');
      })))
    );
  }

  PostMapInfo(mapinfo: MapInfo, router: Router) {
    this.BeforeHttpClient(this.mapinfoPostModel$, router);

    return this.httpClient.post<MapInfo>('/api/MapInfo', mapinfo, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.mapinfoPostModel$, x, 'Post', mapinfo);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.mapinfoPostModel$, e, 'Post');
      })))
    );
  }

  DeleteMapInfo(mapinfo: MapInfo, router: Router) {
    this.BeforeHttpClient(this.mapinfoDeleteModel$, router);

    return this.httpClient.delete<boolean>(`/api/MapInfo/${ mapinfo.MapInfoID }`).pipe(
      map((x: any) => {
        this.DoSuccess(this.mapinfoDeleteModel$, x, 'Delete', mapinfo);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.mapinfoDeleteModel$, e, 'Delete');
      })))
    );
  }

  /* Functions private */
  private BeforeHttpClient(httpRequestModel$: BehaviorSubject<HttpRequestModel>, router: Router) {
    this.router = router;
    this.oldURL = router.url;
    httpRequestModel$.next(<HttpRequestModel>{ Working: true, Error: null, Status: null });
  }

  private DoCatchError(httpRequestModel$: BehaviorSubject<HttpRequestModel>, e: any, command: string) {
    this.mapinfoListModel$.next(null);
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: <HttpErrorResponse>e, Status: 'Error' });

    this.mapinfoList = [];
    console.debug(`MapInfo ${ command } ERROR. Return: ${ <HttpErrorResponse>e }`);
    this.DoReload();
  }

  private DoReload() {
    this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
      this.router.navigate([`/${this.oldURL}`]);
    });
  }

  private DoSuccess(httpRequestModel$: BehaviorSubject<HttpRequestModel>, x: any, command: string, mapinfo?: MapInfo) {
    console.debug(`MapInfo ${ command } OK. Return: ${ x }`);
    if (command === 'Get') {
      this.mapinfoListModel$.next(<MapInfo[]>x);
    }
    if (command === 'Put') {
      this.mapinfoListModel$.getValue()[0] = <MapInfo>x;
    }
    if (command === 'Post') {
      this.mapinfoListModel$.getValue().push(<MapInfo>x);
    }
    if (command === 'Delete') {
      const index = this.mapinfoListModel$.getValue().indexOf(mapinfo);
      this.mapinfoListModel$.getValue().splice(index, 1);
    }

    this.mapinfoListModel$.next(this.mapinfoListModel$.getValue());
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: null, Status: 'ok' });
    this.mapinfoList = this.mapinfoListModel$.getValue();
    this.DoReload();
  }
}
