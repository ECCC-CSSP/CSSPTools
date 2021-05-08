import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetAreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AscDescEnum, GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { WebAreaService } from 'src/app/services/loaders/web-area.service';
//import { TVItemSortOrderService } from 'src/app/services/helpers/tvitem-sort-order.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { ComponentButtonSelectionService } from 'src/app/services/helpers/component-button-selection.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { FilterService } from 'src/app/services/helpers/filter.service';


@Component({
  selector: 'app-area-item',
  templateUrl: './area-item.component.html',
  styleUrls: ['./area-item.component.css']
})
export class AreaItemComponent implements OnInit, OnDestroy {

  
  areaSubComponentEnum = GetAreaSubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();
  sortOrderAngular = GetSortOrderAngularEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public webAreaService: WebAreaService,
    //public tvItemSortOrderService: TVItemSortOrderService,
    public statCountService: StatCountService,
    public sortTVItemListService: SortTVItemListService,
    public filterService: FilterService,
    public componentButtonSelectionService: ComponentButtonSelectionService,
    public componentShowService: ComponentShowService) { }

  ngOnInit(): void {
    this.webAreaService.DoWebArea(this.appStateService.CurrentTVItemID, false);
  }

  ngOnDestroy(): void {
  }

  ChangeSortOrderForAreaSectors(ascDesc: AscDescEnum) {
    this.appStateService.AreaSectorsSortOrder = ascDesc;
  }

}
