/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { BaseModelServiceTextModel } from './basemodelservice.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesBaseModelServiceText } from './basemodelservice.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { BaseModelService } from '../../../models/generated/BaseModelService.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class BaseModelServiceService {
  /* Variables */
  basemodelserviceTextModel$: BehaviorSubject<BaseModelServiceTextModel> = new BehaviorSubject<BaseModelServiceTextModel>(<BaseModelServiceTextModel>{});
  basemodelserviceListModel$: BehaviorSubject<BaseModelService[]> = new BehaviorSubject<BaseModelService[]>(<BaseModelService[]>{});
  basemodelserviceGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  basemodelservicePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  basemodelservicePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  basemodelserviceDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesBaseModelServiceText(this.basemodelserviceTextModel$);
    this.basemodelserviceTextModel$.next(<BaseModelServiceTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetBaseModelServiceList() {
    this.httpClientService.BeforeHttpClient(this.basemodelserviceGetModel$);

    return this.httpClient.get<BaseModelService[]>('/api/BaseModelService').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<BaseModelService>(this.basemodelserviceListModel$, this.basemodelserviceGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<BaseModelService>(this.basemodelserviceListModel$, this.basemodelserviceGetModel$, e);
      })))
    );
  }

  PutBaseModelService(basemodelservice: BaseModelService) {
    this.httpClientService.BeforeHttpClient(this.basemodelservicePutModel$);

    return this.httpClient.put<BaseModelService>('/api/BaseModelService', basemodelservice, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<BaseModelService>(this.basemodelserviceListModel$, this.basemodelservicePutModel$, x, HttpClientCommand.Put, basemodelservice);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<BaseModelService>(this.basemodelserviceListModel$, this.basemodelservicePutModel$, e);
      })))
    );
  }

  PostBaseModelService(basemodelservice: BaseModelService) {
    this.httpClientService.BeforeHttpClient(this.basemodelservicePostModel$);

    return this.httpClient.post<BaseModelService>('/api/BaseModelService', basemodelservice, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<BaseModelService>(this.basemodelserviceListModel$, this.basemodelservicePostModel$, x, HttpClientCommand.Post, basemodelservice);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<BaseModelService>(this.basemodelserviceListModel$, this.basemodelservicePostModel$, e);
      })))
    );
  }

  DeleteBaseModelService(basemodelservice: BaseModelService) {
    this.httpClientService.BeforeHttpClient(this.basemodelserviceDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/BaseModelService/${ basemodelservice.BaseModelServiceID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<BaseModelService>(this.basemodelserviceListModel$, this.basemodelserviceDeleteModel$, x, HttpClientCommand.Delete, basemodelservice);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<BaseModelService>(this.basemodelserviceListModel$, this.basemodelserviceDeleteModel$, e);
      })))
    );
  }
}
