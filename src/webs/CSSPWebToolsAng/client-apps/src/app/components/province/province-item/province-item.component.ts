import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AscDescEnum, GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { GetProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebClimateSites } from 'src/app/models/generated/web/WebClimateSites.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentButtonSelectionService } from 'src/app/services/helpers/component-button-selection.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { FilterService } from 'src/app/services/helpers/filter.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';

@Component({
  selector: 'app-province-item',
  templateUrl: './province-item.component.html',
  styleUrls: ['./province-item.component.css']
})
export class ProvinceItemComponent implements OnInit, OnDestroy { 
  provinceSubComponentEnum = GetProvinceSubComponentEnum();
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
    public componentButtonSelectionService: ComponentButtonSelectionService,
    public componentShowService: ComponentShowService) { }

  ngOnInit(): void {
    this.loaderService.Load<WebClimateSites>(WebTypeEnum.WebClimateSites, WebTypeEnum.WebHydrometricSites, false);
  }

  ngOnDestroy(): void {
  }

  ChangeSortOrderForProvinceAreas(ascDesc: AscDescEnum) {
    this.appStateService.ProvinceAreasSortOrder = ascDesc;
  }
  
  ChangeSortOrderForProvinceMunicipalities(ascDesc: AscDescEnum) {
    this.appStateService.ProvinceMunicipalitiesSortOrder = ascDesc;
  }

}
