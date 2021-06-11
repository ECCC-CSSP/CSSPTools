import { Component, OnInit, OnDestroy } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { GetCountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { GetTVTypeEnum, TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { FilterService } from 'src/app/services/tvitem/filter.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { JsonLoadListService } from 'src/app/services/json/json-loading-list.service';
import { JsonLoadAllService } from 'src/app/services/json';
import { TVFileModelByPurposeService } from 'src/app/services/file';

@Component({
  selector: 'app-country-item',
  templateUrl: './country-item.component.html',
  styleUrls: ['./country-item.component.css']
})
export class CountryItemComponent implements OnInit, OnDestroy {
  countrySubComponentEnum = GetCountrySubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();
  sortOrderAngular = GetSortOrderAngularEnum();
  filesSortPropEnum = GetFilesSortPropEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public jsonLoadAllService: JsonLoadAllService,
    public jsonLoadListService: JsonLoadListService,
    public statCountService: StatCountService,
    public sortTVItemListService: SortTVItemListService,
    public filterService: FilterService,
    public componentShowService: ComponentShowService,
    public tvFileModelByPurposeService: TVFileModelByPurposeService) {
  }

  ngOnInit(): void {
    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Country, this.appStateService.UserPreference.CurrentCountryTVItemID, false);
    this.jsonLoadAllService.LoadAll();
  }

  ngOnDestroy(): void {
  }
}
