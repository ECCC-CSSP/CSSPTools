import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetRootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AscDescEnum, GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { FilterService } from 'src/app/services/helpers/filter.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';


@Component({
  selector: 'app-root-item',
  templateUrl: './root-item.component.html',
  styleUrls: ['./root-item.component.css']
})
export class RootItemComponent implements OnInit, OnDestroy {
  rootSubComponentEnum = GetRootSubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();
  sortOrderAngular = GetSortOrderAngularEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    private loaderService: LoaderService,
    public statCountService: StatCountService,
    public sortTVItemListService: SortTVItemListService,
    public filterService: FilterService,
    public componentShowService: ComponentShowService) {
  }

  ngOnInit(): void {
    this.loaderService.Load<WebRoot>(WebTypeEnum.WebRoot, null, false);
  }

  ngOnDestroy(): void {
  }

  ChangeSortOrderForRootCountries(ascDesc: AscDescEnum) {
    this.appStateService.RootCountriesSortOrder = ascDesc;
  }

}
