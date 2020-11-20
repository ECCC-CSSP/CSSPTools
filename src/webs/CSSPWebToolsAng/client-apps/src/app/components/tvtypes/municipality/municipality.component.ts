import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetMunicipalitySubComponentEnum, MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentButtonSelectionService } from 'src/app/services/helpers/component-button-selection.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { TVItemSortOrderService } from 'src/app/services/helpers/tvitem-sort-order.service';
import { WebMunicipalityService } from 'src/app/services/loaders/web-municipalty.service';

@Component({
  selector: 'app-municipality',
  templateUrl: './municipality.component.html',
  styleUrls: ['./municipality.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MunicipalityComponent implements OnInit, OnDestroy {
  municipalitySubComponentEnum = GetMunicipalitySubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();
  sortOrderAngular = GetSortOrderAngularEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public webMunicipalityService: WebMunicipalityService,
    public tvItemSortOrderService: TVItemSortOrderService,
    public statCountService: StatCountService,
    public componentButtonSelectionService: ComponentButtonSelectionService,
    public componentShowService: ComponentShowService) { }

  ngOnInit(): void {
    this.webMunicipalityService.DoWebMunicipality(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ngOnDestroy(): void {
  }
}
