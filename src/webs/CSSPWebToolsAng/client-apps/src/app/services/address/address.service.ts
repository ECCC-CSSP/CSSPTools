import { Injectable } from '@angular/core';
import { Address } from 'src/app/models/generated/db/Address.model';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLoadedService } from '../app/app-loaded.service';
import { AppStateService } from '../app/app-state.service';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
  ) {
  }

  GetAddress(tvItemID: number): Address {
    if (this.appLoadedService.WebAllAddresses == undefined || tvItemID == 0)
    {
      return <Address>{};
    }
    let addressList: Address[] = this.appLoadedService.WebAllAddresses.AddressList.filter(c => c.AddressTVItemID == tvItemID);
    if (addressList == null || addressList == undefined || addressList.length == 0) {
      return <Address>{};
    }
    return addressList[0];
  }

  GetCountryTVItemModel(tvItemID: number): TVItemModel {
    if (this.appLoadedService.WebAllCountries == undefined)
    {
      return <TVItemModel>{};
    }
    let tvItemModelList: TVItemModel[] = this.appLoadedService.WebAllCountries.TVItemModelList.filter(c => c.TVItem.TVItemID == tvItemID);
    if (tvItemModelList == null || tvItemModelList == undefined || tvItemModelList.length == 0) {
      return <TVItemModel>{};
    }
    return tvItemModelList[0];
  }

  GetProvinceTVItemModel(tvItemID: number): TVItemModel {
    if (this.appLoadedService.WebAllProvinces == undefined)
    {
      return <TVItemModel>{};
    }
    let tvItemModelList: TVItemModel[] = this.appLoadedService.WebAllProvinces.TVItemModelList.filter(c => c.TVItem.TVItemID == tvItemID);
    if (tvItemModelList == null || tvItemModelList == undefined || tvItemModelList.length == 0) {
      return <TVItemModel>{};
    }
    return tvItemModelList[0];
  }

  GetMunicipalityTVItemModel(tvItemID: number): TVItemModel {
    if (this.appLoadedService.WebAllMunicipalities == undefined)
    {
      return <TVItemModel>{};
    }
    let tvItemModelList: TVItemModel[] = this.appLoadedService.WebAllMunicipalities.TVItemModelList.filter(c => c.TVItem.TVItemID == tvItemID);
    if (tvItemModelList == null || tvItemModelList == undefined || tvItemModelList.length == 0) {
      return <TVItemModel>{};
    }
    return tvItemModelList[0];
  }


}
