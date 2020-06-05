import { Injectable } from '@angular/core';
import { AddressTextModel, AddressModel } from './address.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesAddressText } from './address.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Address } from 'src/app/interfaces/generated/Address.interface';

@Injectable({
  providedIn: 'root'
})
export class AddressService {
  addressTextModel$: BehaviorSubject<AddressTextModel> = new BehaviorSubject<AddressTextModel>(<AddressTextModel>{});
  addressModel$: BehaviorSubject<AddressModel> = new BehaviorSubject<AddressModel>(<AddressModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesAddressText(this);
    this.UpdateAddressText(<AddressTextModel>{ Title: "Something2 for text" });
  }

  UpdateAddressText(addressTextModel: AddressTextModel) {
    this.addressTextModel$.next(<AddressTextModel>{ ...this.addressTextModel$.getValue(), ...addressTextModel });
  }

  UpdateAddressModel(addressModel: AddressModel) {
    this.addressModel$.next(<AddressModel>{ ...this.addressModel$.getValue(), ...addressModel });
  }

  GetAddress(router: Router) {
    let oldURL = router.url;
    this.UpdateAddressModel(<AddressModel>{ Working: true, Error: null });

    return this.httpClient.get<Address[]>('/api/Address').pipe(
      map((x: any) => {
        console.debug(`Address OK. Return: ${x}`);
        this.addressModel$.getValue().AddressList = <Address[]>x;
        if (this.addressModel$.getValue().AddressList.length > 0) {
          this.addressModel$.getValue().ObjKeys = Object.keys(this.addressModel$.getValue().AddressList[0]);
        }
        this.UpdateAddressModel(this.addressModel$.getValue());
        this.UpdateAddressModel(<AddressModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateAddressModel(<AddressModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`Address ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
