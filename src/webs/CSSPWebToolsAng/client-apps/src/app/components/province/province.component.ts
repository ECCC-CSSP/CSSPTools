import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';
import { GetProvinceSubComponentEnum, ProvinceSubComponentEnum } from '../../enums/generated/ProvinceSubComponentEnum';
import { AppStateService } from '../../services/app-state.service';
import { AppState } from '../../models/AppState.model';
import { AppLoadedService } from '../../services/app-loaded.service';
import { AppLoaded } from '../../models/AppLoaded.model';

@Component({
  selector: 'app-province',
  templateUrl: './province.component.html',
  styleUrls: ['./province.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProvinceComponent implements OnInit, OnDestroy {
  subWebProvince: Subscription;
  provinceSubComponentEnum = GetProvinceSubComponentEnum();

  constructor(public appStateService: AppStateService, public appLoadedService: AppLoadedService) { }

  ngOnInit(): void {
    let TVItemID: number = this.appStateService.AppState$.getValue().CurrentTVItemID;
    this.subWebProvince = this.appLoadedService.GetWebProvince(TVItemID).subscribe();
  }

  ngOnDestroy(): void {
    this.subWebProvince ? this.subWebProvince.unsubscribe() : null;
  }

  GetT(language: number): string
  {
    let a: LanguageEnum = language;
    return LanguageEnum[language];
  }

  ColorSelection(provinceSubComponent: ProvinceSubComponentEnum) {
    if (this.appStateService.AppState$.getValue().ProvinceSubComponent == provinceSubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  Show(provinceSubComponent: ProvinceSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ ProvinceSubComponent: provinceSubComponent });
  }

  ToggleInactive(): void {
    this.appStateService.UpdateAppState(<AppState> { InactVisible: !this.appStateService.AppState$.getValue().InactVisible });
    this.appLoadedService.UpdateAppLoaded(<AppLoaded> { Working: false });
  }

  ToggleDetail(): void {
    this.appStateService.UpdateAppState(<AppState> { DetailVisible: !this.appStateService.AppState$.getValue().DetailVisible });
    this.appLoadedService.UpdateAppLoaded(<AppLoaded> { Working: false });
  }

  ToggleEdit(): void {
    this.appStateService.UpdateAppState(<AppState> { EditVisible: !this.appStateService.AppState$.getValue().EditVisible });
    this.appLoadedService.UpdateAppLoaded(<AppLoaded> { Working: false });
  }

}
