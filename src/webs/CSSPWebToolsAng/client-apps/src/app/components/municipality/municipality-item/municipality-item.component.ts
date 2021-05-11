import { Component, OnInit, OnDestroy } from '@angular/core';
import { AscDescEnum, GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { GetMunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { FilterService } from 'src/app/services/helpers/filter.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
//import { WebMunicipalityService } from 'src/app/services/loaders/web-municipalty.service';

@Component({
  selector: 'app-municipality-item',
  templateUrl: './municipality-item.component.html',
  styleUrls: ['./municipality-item.component.css']
})
export class MunicipalityItemComponent implements OnInit, OnDestroy {
  municipalitySubComponentEnum = GetMunicipalitySubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();
  sortOrderAngular = GetSortOrderAngularEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    //public webMunicipalityService: WebMunicipalityService,
    public loaderService: LoaderService,
    public sortTVItemListService: SortTVItemListService,
    public filterService: FilterService,
    public statCountService: StatCountService,
    public componentShowService: ComponentShowService) { }

  ngOnInit(): void {
    this.loaderService.Load<WebMunicipality>(WebTypeEnum.WebMunicipality, null, false);
  }

  ngOnDestroy(): void {
  }

  ChangeSortOrderForMunicipalityMikeScenarios(ascDesc: AscDescEnum) {
    this.appStateService.MunicipalityMikeScenariosSortOrder = ascDesc;
  }
}
