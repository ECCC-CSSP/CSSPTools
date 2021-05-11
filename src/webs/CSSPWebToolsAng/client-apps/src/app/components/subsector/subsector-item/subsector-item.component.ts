import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AscDescEnum, GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { GetSubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebMWQMSites } from 'src/app/models/generated/web/WebMWQMSites.model';
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
  selector: 'app-subsector-item',
  templateUrl: './subsector-item.component.html',
  styleUrls: ['./subsector-item.component.css']
})
export class SubsectorItemComponent implements OnInit, OnDestroy {
  subsectorSubComponentEnum = GetSubsectorSubComponentEnum();
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
    this.loaderService.Load<WebMWQMSites>(WebTypeEnum.WebMWQMSites, WebTypeEnum.WebMWQMRuns, true);
  }

  ngOnDestroy(): void {
  }

  ChangeSortOrderForSubsectorMWQMSites(ascDesc: AscDescEnum) {
    this.appStateService.SubsectorMWQMSitesSortOrder = ascDesc;
  }

  ChangeSortOrderForSubsectorMWQMRuns(ascDesc: AscDescEnum) {
    this.appStateService.SubsectorMWQMRunsSortOrder = ascDesc;
  }

  ChangeSortOrderForSubsectorPolSourceSites(ascDesc: AscDescEnum) {
    this.appStateService.SubsectorPolSourceSitesSortOrder = ascDesc;
  }
}
