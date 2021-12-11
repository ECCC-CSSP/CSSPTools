import { Injectable } from '@angular/core';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { WebRoot } from 'src/app/models/generated/models/WebRoot.model';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebArea } from 'src/app/models/generated/models/WebArea.model';
import { WebCountry } from 'src/app/models/generated/models/WebCountry.model';
import { WebMunicipality } from 'src/app/models/generated/models/WebMunicipality.model';
import { WebProvince } from 'src/app/models/generated/models/WebProvince.model';
import { WebSector } from 'src/app/models/generated/models/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/models/WebSubsector.model';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { JsonLoadAllService, JsonLoadListService } from '../json';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

@Injectable({
  providedIn: 'root'
})
export class ComponentShowService {

  constructor(private appStateService: AppStateService,
    private jsonLoadAllService: JsonLoadAllService,
    private jsonLoadListService: JsonLoadListService){
  }

  ShowArea(areaSubComponent: AreaSubComponentEnum) {
    this.appStateService.UserPreference.AreaSubComponent = areaSubComponent;
    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Area, this.appStateService.UserPreference.CurrentAreaTVItemID, false);
    this.jsonLoadAllService.LoadAll();
  }

  ShowCountry(countrySubComponent: CountrySubComponentEnum) {
    this.appStateService.UserPreference.CountrySubComponent = countrySubComponent;
    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Country, this.appStateService.UserPreference.CurrentCountryTVItemID, false);
    this.jsonLoadAllService.LoadAll();
  }

  ShowMunicipality(municipalitySubComponent: MunicipalitySubComponentEnum) {
    this.appStateService.UserPreference.MunicipalitySubComponent = municipalitySubComponent;
    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Municipality, this.appStateService.UserPreference.CurrentMunicipalityTVItemID, false);
    this.jsonLoadAllService.LoadAll();
  }

  ShowProvince(provinceSubComponent: ProvinceSubComponentEnum) {
    this.appStateService.UserPreference.ProvinceSubComponent = provinceSubComponent;
    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Province, this.appStateService.UserPreference.CurrentProvinceTVItemID, false);
    this.jsonLoadAllService.LoadAll();
  }

  ShowRoot(rootSubComponent: RootSubComponentEnum) {
    this.appStateService.UserPreference.RootSubComponent = rootSubComponent;
    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Root, this.appStateService.UserPreference.CurrentRootTVItemID, false);
    this.jsonLoadAllService.LoadAll();
  }

  ShowSector(sectorSubComponent: SectorSubComponentEnum) {
    this.appStateService.UserPreference.SectorSubComponent = sectorSubComponent;
    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Sector, this.appStateService.UserPreference.CurrentSectorTVItemID, false);
    this.jsonLoadAllService.LoadAll();
  }

  ShowSubsector(subsectorSubComponent: SubsectorSubComponentEnum) {
    this.appStateService.UserPreference.SubsectorSubComponent = subsectorSubComponent;
    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Subsector, this.appStateService.UserPreference.CurrentSubsectorTVItemID, false);
    this.jsonLoadAllService.LoadAll();
  }

}
