import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { GetProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentButtonSelectionService } from 'src/app/services/helpers/component-button-selection.service';
import { ComponentDataClearService } from 'src/app/services/helpers/component-data-clear.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { TVItemSortOrderService } from 'src/app/services/loaders/tvitem-sort-order.service';
      import { WebProvinceService } from 'src/app/services/loaders/web-province.service';

@Component({
  selector: 'app-province',
  templateUrl: './province.component.html',
  styleUrls: ['./province.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProvinceComponent implements OnInit, OnDestroy {
  subWebProvince: Subscription;
  subWebMunicipalities: Subscription;
  provinceSubComponentEnum = GetProvinceSubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public webProvinceService: WebProvinceService,
    public tvItemSortOrderService: TVItemSortOrderService,
    public statCountService: StatCountService,
    public componentButtonSelectionService: ComponentButtonSelectionService,
    public componentShowService: ComponentShowService,
    private componentDataClearService: ComponentDataClearService) { }

  ngOnInit(): void {
    let TVItemID: number = this.appStateService.AppState$.getValue().CurrentTVItemID;
    this.componentDataClearService.DataClearProvince();
    this.subWebProvince = this.webProvinceService.GetWebProvince(TVItemID).subscribe();
  }

  ngOnDestroy(): void {
    this.subWebProvince ? this.subWebProvince.unsubscribe() : null;
    this.subWebMunicipalities ? this.subWebMunicipalities.unsubscribe() : null;
  }

}
