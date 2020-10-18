import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { CountrySubComponentEnum, GetCountrySubComponentEnum } from '../../enums/generated/CountrySubComponentEnum';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoaded } from 'src/app/models/AppLoaded.model';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CountryComponent implements OnInit, OnDestroy {
  subWebCountry: Subscription;
  countrySubComponentEnum = GetCountrySubComponentEnum();

  constructor(public appStateService: AppStateService, public appLoadedService: AppLoadedService) {

  }

  ngOnInit(): void {
    let TVItemID: number = this.appStateService.AppState$.getValue().CurrentTVItemID;
    this.subWebCountry = this.appLoadedService.GetWebCountry(TVItemID).subscribe();
  }

  ngOnDestroy(): void {
    this.subWebCountry ? this.subWebCountry.unsubscribe() : null;
  }

  ColorSelection(countrySubComponent: CountrySubComponentEnum) {
    if (this.appStateService.AppState$.getValue().CountrySubComponent == countrySubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  Show(countrySubComponent: CountrySubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ CountrySubComponent: countrySubComponent });
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
