import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { GetCountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { WebCountryService } from 'src/app/services/loaders/web-country.service';
import { TVItemSortOrderService } from 'src/app/services/loaders/tvitem-sort-order.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { ComponentButtonSelectionService } from 'src/app/services/helpers/component-button-selection.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { ComponentDataClearService } from 'src/app/services/helpers/component-data-clear.service';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CountryComponent implements OnInit, OnDestroy {
  subWebCountry: Subscription;
  countrySubComponentEnum = GetCountrySubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public webCountryService: WebCountryService,
    public tvItemSortOrderService: TVItemSortOrderService,
    public statCountService: StatCountService,
    public componentButtonSelectionService: ComponentButtonSelectionService,
    public componentShowService: ComponentShowService,
    private componentDataClearService: ComponentDataClearService) {

  }

  ngOnInit(): void {
    let TVItemID: number = this.appStateService.AppState$.getValue().CurrentTVItemID;
    this.componentDataClearService.DataClearCountry();
    this.subWebCountry = this.webCountryService.GetWebCountry(TVItemID).subscribe();
  }

  ngOnDestroy(): void {
    this.subWebCountry ? this.subWebCountry.unsubscribe() : null;
  }

}
