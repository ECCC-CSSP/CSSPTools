import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AscDescEnum, GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { GetSectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentButtonSelectionService } from 'src/app/services/helpers/component-button-selection.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { FilterService } from 'src/app/services/helpers/filter.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
//import { TVItemSortOrderService } from 'src/app/services/helpers/tvitem-sort-order.service';
import { WebSectorService } from 'src/app/services/loaders/web-sector.service';

@Component({
  selector: 'app-sector-item',
  templateUrl: './sector-item.component.html',
  styleUrls: ['./sector-item.component.css']
})
export class SectorItemComponent implements OnInit, OnDestroy {

  
  sectorSubComponentEnum = GetSectorSubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();
  sortOrderAngular = GetSortOrderAngularEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public webSectorService: WebSectorService,
    //public tvItemSortOrderService: TVItemSortOrderService,
    public statCountService: StatCountService,
    public sortTVItemListService: SortTVItemListService,
    public filterService: FilterService,
    public componentButtonSelectionService: ComponentButtonSelectionService,
    public componentShowService: ComponentShowService) { }

  ngOnInit(): void {
    this.webSectorService.DoWebSector(this.appStateService.CurrentTVItemID, true);
  }

  ngOnDestroy(): void {
  }

  ChangeSortOrderForSectorSubsectors(ascDesc: AscDescEnum) {
    this.appStateService.SectorSubsectorsSortOrder = ascDesc;
  }
}
