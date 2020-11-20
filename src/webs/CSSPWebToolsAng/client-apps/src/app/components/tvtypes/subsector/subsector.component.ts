import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { GetSubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentButtonSelectionService } from 'src/app/services/helpers/component-button-selection.service';
import { ComponentDataClearService } from 'src/app/services/helpers/component-data-clear.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { TVItemSortOrderService } from 'src/app/services/helpers/tvitem-sort-order.service';
import { WebMWQMSampleService } from 'src/app/services/loaders/web-mwqm-samples.service';
import { WebSubsectorService } from 'src/app/services/loaders/web-subsector.service';

@Component({
  selector: 'app-subsector',
  templateUrl: './subsector.component.html',
  styleUrls: ['./subsector.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SubsectorComponent implements OnInit, OnDestroy {
  subsectorSubComponentEnum = GetSubsectorSubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();
  sortOrderAngular = GetSortOrderAngularEnum();
  
  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public webSubsectorService: WebSubsectorService,
    public webMWQMSampleService: WebMWQMSampleService,
    public tvItemSortOrderService: TVItemSortOrderService,
    public statCountService: StatCountService,
    public componentButtonSelectionService: ComponentButtonSelectionService,
    public componentShowService: ComponentShowService,
    private componentDataClearService: ComponentDataClearService) { }

  ngOnInit(): void {
    this.webSubsectorService.DoWebSubsector(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ngOnDestroy(): void {
  }

}
