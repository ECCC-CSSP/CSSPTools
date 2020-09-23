/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { InfrastructureTextModel } from './infrastructure.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesInfrastructureText } from './infrastructure.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Infrastructure } from '../../../models/generated/Infrastructure.model';
import { HttpRequestModel } from '../../../models/HttpRequest.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class InfrastructureService {
  /* Variables */
  infrastructureTextModel$: BehaviorSubject<InfrastructureTextModel> = new BehaviorSubject<InfrastructureTextModel>(<InfrastructureTextModel>{});
  infrastructureListModel$: BehaviorSubject<Infrastructure[]> = new BehaviorSubject<Infrastructure[]>(<Infrastructure[]>{});
  infrastructureGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  infrastructurePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  infrastructurePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  infrastructureDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesInfrastructureText(this.infrastructureTextModel$);
    this.infrastructureTextModel$.next(<InfrastructureTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetInfrastructureList() {
    this.httpClientService.BeforeHttpClient(this.infrastructureGetModel$);

    return this.httpClient.get<Infrastructure[]>('/api/Infrastructure').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Infrastructure>(this.infrastructureListModel$, this.infrastructureGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<Infrastructure>(this.infrastructureListModel$, this.infrastructureGetModel$, e);
      })))
    );
  }

  PutInfrastructure(infrastructure: Infrastructure) {
    this.httpClientService.BeforeHttpClient(this.infrastructurePutModel$);

    return this.httpClient.put<Infrastructure>('/api/Infrastructure', infrastructure, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Infrastructure>(this.infrastructureListModel$, this.infrastructurePutModel$, x, HttpClientCommand.Put, infrastructure);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<Infrastructure>(this.infrastructureListModel$, this.infrastructurePutModel$, e);
      })))
    );
  }

  PostInfrastructure(infrastructure: Infrastructure) {
    this.httpClientService.BeforeHttpClient(this.infrastructurePostModel$);

    return this.httpClient.post<Infrastructure>('/api/Infrastructure', infrastructure, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Infrastructure>(this.infrastructureListModel$, this.infrastructurePostModel$, x, HttpClientCommand.Post, infrastructure);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<Infrastructure>(this.infrastructureListModel$, this.infrastructurePostModel$, e);
      })))
    );
  }

  DeleteInfrastructure(infrastructure: Infrastructure) {
    this.httpClientService.BeforeHttpClient(this.infrastructureDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/Infrastructure/${ infrastructure.InfrastructureID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Infrastructure>(this.infrastructureListModel$, this.infrastructureDeleteModel$, x, HttpClientCommand.Delete, infrastructure);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<Infrastructure>(this.infrastructureListModel$, this.infrastructureDeleteModel$, e);
      })))
    );
  }
}
