import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetMunicipalitySubComponentEnum, MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { TVItemSortOrderService } from 'src/app/services/loaders/tvitem-sort-order.service';
import { WebMunicipalityService } from 'src/app/services/loaders/web-municipalty.service';

@Component({
  selector: 'app-municipality',
  templateUrl: './municipality.component.html',
  styleUrls: ['./municipality.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MunicipalityComponent implements OnInit, OnDestroy {
  subWebMunicipality: Subscription;
  municipalitySubComponentEnum = GetMunicipalitySubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public webMunicipalityService: WebMunicipalityService,
    public tvItemSortOrderService: TVItemSortOrderService,
    public statCountService: StatCountService) { }

  ngOnInit(): void {
    let TVItemID: number = this.appStateService.AppState$.getValue().CurrentTVItemID;
    this.subWebMunicipality = this.webMunicipalityService.GetWebMunicipality(TVItemID).subscribe();
  }

  ngOnDestroy(): void {
    this.subWebMunicipality ? this.subWebMunicipality.unsubscribe() : null;
  }

  GetT(language: number): string
  {
    let a: LanguageEnum = language;
    return LanguageEnum[language];
  }

  ColorSelection(municipalitySubComponent: MunicipalitySubComponentEnum) {
    if (this.appStateService.AppState$.getValue().MunicipalitySubComponent == municipalitySubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  Show(municipalitySubComponent: MunicipalitySubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ MunicipalitySubComponent: municipalitySubComponent });
    this.webMunicipalityService.UpdateWebMunicipality(this.appLoadedService.AppLoaded$.getValue().WebMunicipality);
  }
}
