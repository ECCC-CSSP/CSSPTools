/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { AddressTextModel } from './address.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesAddressText } from './address.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Address } from 'src/app/models/generated/Address.model';
import { HttpRequestModel } from 'src/app/models';

@Injectable({
  providedIn: 'root'
})
export class AddressService {
  /* Variables */
  addressTextModel$: BehaviorSubject<AddressTextModel> = new BehaviorSubject<AddressTextModel>(<AddressTextModel>{});
  addressListModel$: BehaviorSubject<Address[]> = new BehaviorSubject<Address[]>(<Address[]>{});
  addressGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  addressPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  addressPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  addressDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  addressList: Address[] = [];
  private oldURL: string;
  private router: Router;

  /* Constructors */
  constructor(private httpClient: HttpClient) {
    LoadLocalesAddressText(this);
    this.addressTextModel$.next(<AddressTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetAddressList(router: Router) {
    this.BeforeHttpClient(this.addressGetModel$, router);

    return this.httpClient.get<Address[]>('/api/Address').pipe(
      map((x: any) => {
        this.DoSuccess(this.addressGetModel$, x, 'Get', null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.addressGetModel$, e, 'Get');
      })))
    );
  }

  PutAddress(address: Address, router: Router) {
    this.BeforeHttpClient(this.addressPutModel$, router);

    return this.httpClient.put<Address>('/api/Address', address, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.addressPutModel$, x, 'Put', address);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.addressPutModel$, e, 'Put');
      })))
    );
  }

  PostAddress(address: Address, router: Router) {
    this.BeforeHttpClient(this.addressPostModel$, router);

    return this.httpClient.post<Address>('/api/Address', address, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.addressPostModel$, x, 'Post', address);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.addressPostModel$, e, 'Post');
      })))
    );
  }

  DeleteAddress(address: Address, router: Router) {
    this.BeforeHttpClient(this.addressDeleteModel$, router);

    return this.httpClient.delete<boolean>(`/api/Address/${address.AddressID}`).pipe(
      map((x: any) => {
        this.DoSuccess(this.addressDeleteModel$, x, 'Delete', address);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.addressDeleteModel$, e, 'Delete');
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
    this.addressListModel$.next(null);
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: <HttpErrorResponse>e, Status: 'Error' });

    this.addressList = [];
    console.debug(`Address ${command} ERROR. Return: ${<HttpErrorResponse>e}`);
    this.DoReload();
  }

  private DoReload() {
    this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
      this.router.navigate([`/${this.oldURL}`]);
    });
  }

  private DoSuccess(httpRequestModel$: BehaviorSubject<HttpRequestModel>, x: any, command: string, address?: Address) {
    console.debug(`Address ${command} OK. Return: ${x}`);
    if (command === 'Get') {
      this.addressListModel$.next(<Address[]>x);
    }
    if (command === 'Put') {
      this.addressListModel$.getValue()[0] = <Address>x;
    }
    if (command === 'Post') {
      this.addressListModel$.getValue().push(<Address>x);
    }
    if (command === 'Delete') {
      const index = this.addressListModel$.getValue().indexOf(address);
      this.addressListModel$.getValue().splice(index, 1);
    }

    this.addressListModel$.next(this.addressListModel$.getValue());
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: null, Status: 'ok' });
    this.addressList = this.addressListModel$.getValue();
    this.DoReload();
  }
}
