import { Injectable } from '@angular/core';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
  providedIn: 'root'
})
export class ComponentButtonSelectionService {

  constructor(private appStateService: AppStateService) {
  }

  ColorSelectionArea(areaSubComponent: AreaSubComponentEnum) {
    if (this.appStateService.AppState$.getValue().AreaSubComponent == areaSubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  ColorSelectionCountry(countrySubComponent: CountrySubComponentEnum) {
    if (this.appStateService.AppState$.getValue().CountrySubComponent == countrySubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  ColorSelectionProvince(provinceSubComponent: ProvinceSubComponentEnum) {
    if (this.appStateService.AppState$.getValue().ProvinceSubComponent == provinceSubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  ColorSelectionRoot(rootSubComponent: RootSubComponentEnum) {
    if (this.appStateService.AppState$.getValue()['RootSubComponent'] == rootSubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  ColorSelectionSector(sectorSubComponent: SectorSubComponentEnum) {
    if (this.appStateService.AppState$.getValue().SectorSubComponent == sectorSubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  ColorSelectionSubsector(subsectorSubComponent: SubsectorSubComponentEnum) {
    if (this.appStateService.AppState$.getValue().SubsectorSubComponent == subsectorSubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }
}
