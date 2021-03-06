import { Injectable } from '@angular/core';
import { AddressModel } from 'src/app/models/generated/web/AddressModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
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

  GetAddressModel(tvItemID: number): AddressModel {
    if (this.appLoadedService.WebAllAddresses == undefined)
    {
      return <AddressModel>{};
    }
    let addressModelList: AddressModel[] = this.appLoadedService.WebAllAddresses.AddressModelList.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemID);
    if (addressModelList == null || addressModelList == undefined || addressModelList.length == 0) {
      return <AddressModel>{};
    }
    return addressModelList[0];
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
