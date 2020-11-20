import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetRootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { WebRootService } from 'src/app/services/loaders/web-root.service';
import { TVItemSortOrderService } from 'src/app/services/helpers/tvitem-sort-order.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { ComponentButtonSelectionService } from 'src/app/services/helpers/component-button-selection.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { ComponentDataClearService } from 'src/app/services/helpers/component-data-clear.service';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';

@Component({
  selector: 'app-root',
  templateUrl: './root.component.html',
  styleUrls: ['./root.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RootComponent implements OnInit, OnDestroy {
  rootSubComponentEnum = GetRootSubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();
  sortOrderAngular = GetSortOrderAngularEnum();
  
  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public webRootService: WebRootService,
    public tvItemSortOrderService: TVItemSortOrderService,
    public statCountService: StatCountService,
    public componentButtonSelectionService: ComponentButtonSelectionService,
    public componentShowService: ComponentShowService,
    private componentDataClearService: ComponentDataClearService) {
  }

  ngOnInit(): void {
    this.webRootService.DoWebRoot(true);
  }

  ngOnDestroy(): void {
  }

}
