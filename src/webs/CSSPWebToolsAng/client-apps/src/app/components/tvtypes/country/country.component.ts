import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppState } from 'src/app/models/AppState.model';
import { CountrySubComponentEnum, GetCountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppHelperService } from 'src/app/services/app-helper.service';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CountryComponent implements OnInit, OnDestroy {
  subWebCountry: Subscription;
  countrySubComponentEnum = GetCountrySubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();

  constructor(public appStateService: AppStateService, 
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public appHelperService: AppHelperService) {

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

}
