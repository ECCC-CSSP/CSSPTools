/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { BoxModelTextModel } from './boxmodel.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesBoxModelText } from './boxmodel.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { BoxModel } from '../../../models/generated/BoxModel.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class BoxModelService {
  /* Variables */
  boxmodelTextModel$: BehaviorSubject<BoxModelTextModel> = new BehaviorSubject<BoxModelTextModel>(<BoxModelTextModel>{});
  boxmodelListModel$: BehaviorSubject<BoxModel[]> = new BehaviorSubject<BoxModel[]>(<BoxModel[]>{});
  boxmodelGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  boxmodelPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  boxmodelPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  boxmodelDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesBoxModelText(this.boxmodelTextModel$);
    this.boxmodelTextModel$.next(<BoxModelTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetBoxModelList() {
    this.httpClientService.BeforeHttpClient(this.boxmodelGetModel$);

    return this.httpClient.get<BoxModel[]>('/api/BoxModel').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<BoxModel>(this.boxmodelListModel$, this.boxmodelGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<BoxModel>(this.boxmodelListModel$, this.boxmodelGetModel$, e);
      })))
    );
  }

  PutBoxModel(boxmodel: BoxModel) {
    this.httpClientService.BeforeHttpClient(this.boxmodelPutModel$);

    return this.httpClient.put<BoxModel>('/api/BoxModel', boxmodel, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<BoxModel>(this.boxmodelListModel$, this.boxmodelPutModel$, x, HttpClientCommand.Put, boxmodel);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<BoxModel>(this.boxmodelListModel$, this.boxmodelPutModel$, e);
      })))
    );
  }

  PostBoxModel(boxmodel: BoxModel) {
    this.httpClientService.BeforeHttpClient(this.boxmodelPostModel$);

    return this.httpClient.post<BoxModel>('/api/BoxModel', boxmodel, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<BoxModel>(this.boxmodelListModel$, this.boxmodelPostModel$, x, HttpClientCommand.Post, boxmodel);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<BoxModel>(this.boxmodelListModel$, this.boxmodelPostModel$, e);
      })))
    );
  }

  DeleteBoxModel(boxmodel: BoxModel) {
    this.httpClientService.BeforeHttpClient(this.boxmodelDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/BoxModel/${ boxmodel.BoxModelID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<BoxModel>(this.boxmodelListModel$, this.boxmodelDeleteModel$, x, HttpClientCommand.Delete, boxmodel);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<BoxModel>(this.boxmodelListModel$, this.boxmodelDeleteModel$, e);
      })))
    );
  }
}
