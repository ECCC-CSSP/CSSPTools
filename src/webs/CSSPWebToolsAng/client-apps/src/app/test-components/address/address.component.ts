import { Component, OnInit, OnDestroy } from '@angular/core';
import { AddressService } from './address.service';
import { LoadLocalesAddressText } from './address.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AddressTypeEnum_GetIDText } from 'src/app/enums/generated/AddressTypeEnum';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})
export class AddressComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public addressService: AddressService, public router: Router) { }

  GetAddress() {
    this.sub = this.addressService.GetAddress(this.router).subscribe();
  }

  GetAddressTypeEnumText(enumID: number) {
    return AddressTypeEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesAddressText(this.addressService);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
