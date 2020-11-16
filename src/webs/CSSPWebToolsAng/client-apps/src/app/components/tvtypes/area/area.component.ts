import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetAreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { WebAreaService } from 'src/app/services/loaders/web-area.service';
import { TVItemSortOrderService } from 'src/app/services/loaders/tvitem-sort-order.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { ComponentButtonSelectionService } from 'src/app/services/helpers/component-button-selection.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { ComponentDataClearService } from 'src/app/services/helpers/component-data-clear.service';

@Component({
  selector: 'app-area',
  templateUrl: './area.component.html',
  styleUrls: ['./area.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AreaComponent implements OnInit, OnDestroy {
  subWebArea: Subscription;
  areaSubComponentEnum = GetAreaSubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public webAreaService: WebAreaService,
    public tvItemSortOrderService: TVItemSortOrderService,
    public statCountService: StatCountService,
    public componentButtonSelectionService: ComponentButtonSelectionService,
    public componentShowService: ComponentShowService,
    private componentDataClearService: ComponentDataClearService) { }

  ngOnInit(): void {
    let TVItemID: number = this.appStateService.AppState$.getValue().CurrentTVItemID;
    this.componentDataClearService.DataClearArea();
    this.subWebArea = this.webAreaService.GetWebArea(TVItemID).subscribe();
  }

  ngOnDestroy(): void {
    this.subWebArea ? this.subWebArea.unsubscribe() : null;
  }

}
