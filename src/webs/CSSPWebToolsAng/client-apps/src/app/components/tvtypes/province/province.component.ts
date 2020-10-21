import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetProvinceSubComponentEnum, ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppHelperService } from 'src/app/services/app-helper.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-province',
  templateUrl: './province.component.html',
  styleUrls: ['./province.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProvinceComponent implements OnInit, OnDestroy {
  subWebProvince: Subscription;
  subWebMunicipalities: Subscription;
  provinceSubComponentEnum = GetProvinceSubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();

  constructor(public appStateService: AppStateService, 
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public appHelperService: AppHelperService) { }

  ngOnInit(): void {
    let TVItemID: number = this.appStateService.AppState$.getValue().CurrentTVItemID;
    this.subWebProvince = this.appLoadedService.GetWebProvince(TVItemID).subscribe();
    this.subWebMunicipalities = this.appLoadedService.GetWebMunicipalities(TVItemID).subscribe();
  }

  ngOnDestroy(): void {
    this.subWebProvince ? this.subWebProvince.unsubscribe() : null;
    this.subWebMunicipalities ? this.subWebMunicipalities.unsubscribe() : null;
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

}
