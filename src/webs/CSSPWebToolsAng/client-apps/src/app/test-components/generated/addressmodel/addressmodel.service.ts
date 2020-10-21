/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { AddressModelTextModel } from './addressmodel.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesAddressModelText } from './addressmodel.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { AddressModel } from '../../../models/generated/AddressModel.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class AddressModelService {
  /* Variables */
  addressmodelTextModel$: BehaviorSubject<AddressModelTextModel> = new BehaviorSubject<AddressModelTextModel>(<AddressModelTextModel>{});
  addressmodelListModel$: BehaviorSubject<AddressModel[]> = new BehaviorSubject<AddressModel[]>(<AddressModel[]>{});
  addressmodelGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  addressmodelPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  addressmodelPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  addressmodelDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesAddressModelText(this.addressmodelTextModel$);
    this.addressmodelTextModel$.next(<AddressModelTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetAddressModelList() {
    this.httpClientService.BeforeHttpClient(this.addressmodelGetModel$);

    return this.httpClient.get<AddressModel[]>('/api/AddressModel').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AddressModel>(this.addressmodelListModel$, this.addressmodelGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AddressModel>(this.addressmodelListModel$, this.addressmodelGetModel$, e);
      })))
    );
  }

  PutAddressModel(addressmodel: AddressModel) {
    this.httpClientService.BeforeHttpClient(this.addressmodelPutModel$);

    return this.httpClient.put<AddressModel>('/api/AddressModel', addressmodel, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AddressModel>(this.addressmodelListModel$, this.addressmodelPutModel$, x, HttpClientCommand.Put, addressmodel);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<AddressModel>(this.addressmodelListModel$, this.addressmodelPutModel$, e);
      })))
    );
  }

  PostAddressModel(addressmodel: AddressModel) {
    this.httpClientService.BeforeHttpClient(this.addressmodelPostModel$);

    return this.httpClient.post<AddressModel>('/api/AddressModel', addressmodel, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AddressModel>(this.addressmodelListModel$, this.addressmodelPostModel$, x, HttpClientCommand.Post, addressmodel);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AddressModel>(this.addressmodelListModel$, this.addressmodelPostModel$, e);
      })))
    );
  }

  DeleteAddressModel(addressmodel: AddressModel) {
    this.httpClientService.BeforeHttpClient(this.addressmodelDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/AddressModel/${ addressmodel.AddressModelID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<AddressModel>(this.addressmodelListModel$, this.addressmodelDeleteModel$, x, HttpClientCommand.Delete, addressmodel);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<AddressModel>(this.addressmodelListModel$, this.addressmodelDeleteModel$, e);
      })))
    );
  }
}
