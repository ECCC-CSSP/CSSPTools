import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { GetProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentButtonSelectionService } from 'src/app/services/helpers/component-button-selection.service';
import { ComponentDataClearService } from 'src/app/services/helpers/component-data-clear.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { TVItemSortOrderService } from 'src/app/services/helpers/tvitem-sort-order.service';
import { WebProvinceService } from 'src/app/services/loaders/web-province.service';

@Component({
  selector: 'app-province',
  templateUrl: './province.component.html',
  styleUrls: ['./province.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProvinceComponent implements OnInit, OnDestroy {
  provinceSubComponentEnum = GetProvinceSubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();
  sortOrderAngular = GetSortOrderAngularEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public webProvinceService: WebProvinceService,
    public tvItemSortOrderService: TVItemSortOrderService,
    public statCountService: StatCountService,
    public componentButtonSelectionService: ComponentButtonSelectionService,
    public componentShowService: ComponentShowService) { }

  ngOnInit(): void {
    this.webProvinceService.DoWebProvince(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ngOnDestroy(): void {
  }

}
