import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { GetCountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AscDescEnum, GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { FilterService } from 'src/app/services/helpers/filter.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';


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

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public loaderService: LoaderService,
    public statCountService: StatCountService,
    public sortTVItemListService: SortTVItemListService,
    public filterService: FilterService,
    public componentShowService: ComponentShowService,
    public structureTVFileListService: StructureTVFileListService) {
  }

  ngOnInit(): void {
    this.loaderService.Load<WebCountry>(WebTypeEnum.WebCountry, null, false);
  }

  ngOnDestroy(): void {
  }

  ChangeSortOrderForCountryProvinces(ascDesc: AscDescEnum) {
    this.appStateService.CountryProvincesSortOrder = ascDesc;
  }
}
