import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetAddressTypeEnum } from 'src/app/enums/generated/AddressTypeEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetStreetTypeEnum } from 'src/app/enums/generated/StreetTypeEnum';
import { AddressModel } from 'src/app/models/generated/web/AddressModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AddressService } from 'src/app/services/helpers/address.service';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})
export class AddressComponent implements OnInit, OnDestroy {
  @Input() TVItemID: number;

  addressModel: AddressModel;

  addressType = GetAddressTypeEnum();
  streetType = GetStreetTypeEnum();
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public addressService: AddressService) {
  }

  ngOnInit() {
    this.addressModel = this.addressService.GetAddressModel(this.TVItemID);
  }

  ngOnDestroy() {
  }
}
