import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { GetMunicipalitySubComponentEnum, MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentButtonSelectionService } from 'src/app/services/helpers/component-button-selection.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { TVItemSortOrderService } from 'src/app/services/helpers/tvitem-sort-order.service';
import { WebMunicipalityService } from 'src/app/services/loaders/web-municipalty.service';

@Component({
  selector: 'app-municipality-item',
  templateUrl: './municipality-item.component.html',
  styleUrls: ['./municipality-item.component.css']
})
export class MunicipalityItemComponent implements OnInit, OnDestroy {


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
    this.webMunicipalityService.DoWebMunicipality(this.appStateService.CurrentTVItemID, true);
  }

  ngOnDestroy(): void {
  }
}
