import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { GetAreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { WebAreaService } from 'src/app/services/loaders/web-area.service';
import { TVItemSortOrderService } from 'src/app/services/helpers/tvitem-sort-order.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { ComponentButtonSelectionService } from 'src/app/services/helpers/component-button-selection.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';

@Component({
  selector: 'app-area-item',
  templateUrl: './area-item.component.html',
  styleUrls: ['./area-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
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
    public tvItemSortOrderService: TVItemSortOrderService,
    public statCountService: StatCountService,
    public componentButtonSelectionService: ComponentButtonSelectionService,
    public componentShowService: ComponentShowService) { }

  ngOnInit(): void {
    this.webAreaService.DoWebArea(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ngOnDestroy(): void {
  }

}
