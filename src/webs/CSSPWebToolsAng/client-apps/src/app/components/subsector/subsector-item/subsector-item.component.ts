import { Component, OnInit, OnDestroy } from '@angular/core';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { GetSubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { GetTVTypeEnum, TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { FilterService } from 'src/app/services/tvitem/filter.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { JsonLoadListService } from 'src/app/services/json/json-loading-list.service';
import { JsonLoadAllService } from 'src/app/services/json';
import { TVFileModelByPurposeService } from 'src/app/services/file';

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
  filesSortPropEnum = GetFilesSortPropEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public jsonLoadAllService: JsonLoadAllService,
    private jsonLoadListService: JsonLoadListService,
    public statCountService: StatCountService,
    public sortTVItemListService: SortTVItemListService,
    public filterService: FilterService,
    public componentShowService: ComponentShowService,
    public tvFileModelByPurposeService: TVFileModelByPurposeService) { }

  ngOnInit(): void {
    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Subsector, this.appStateService.UserPreference.CurrentSubsectorTVItemID, false);
    this.jsonLoadAllService.LoadAll();
  }

  ngOnDestroy(): void {
  }
}
