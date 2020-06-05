import { Component, OnInit, OnDestroy } from '@angular/core';
import { AddressService } from './address.service';
import { LoadLocalesAddressText } from './address.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

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

  ngOnInit(): void {
    LoadLocalesAddressText(this.addressService);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
