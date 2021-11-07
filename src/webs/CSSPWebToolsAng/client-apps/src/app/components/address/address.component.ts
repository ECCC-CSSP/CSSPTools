import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetAddressTypeEnum } from 'src/app/enums/generated/AddressTypeEnum';
import { GetStreetTypeEnum } from 'src/app/enums/generated/StreetTypeEnum';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AddressService } from 'src/app/services/address/address.service';
import { Address } from 'src/app/models/generated/db/Address.model';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})
export class AddressComponent implements OnInit, OnDestroy {
  @Input() TVItemID: number;

  address: Address;

  addressType = GetAddressTypeEnum();
  streetType = GetStreetTypeEnum();
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public addressService: AddressService) {
  }

  ngOnInit() {
    this.address = this.addressService.GetAddress(this.TVItemID);
  }

  ngOnDestroy() {
  }
}
