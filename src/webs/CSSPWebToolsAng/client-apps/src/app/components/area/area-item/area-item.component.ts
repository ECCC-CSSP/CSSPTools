import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetAreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { GetTVTypeEnum, TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AscDescEnum, GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { FilterService } from 'src/app/services/tvitem/filter.service';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { JsonLoadListService, JsonLoadAllService } from 'src/app/services/json';
import { TVFileModelByPurposeService } from 'src/app/services/file';

@Component({
  selector: 'app-area-item',
  templateUrl: './area-item.component.html',
  styleUrls: ['./area-item.component.css']
})
export class AreaItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  
  areaSubComponentEnum = GetAreaSubComponentEnum();
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
    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Area, this.appStateService.UserPreference.CurrentAreaTVItemID, false);
    this.jsonLoadAllService.LoadAll();
  }

  ngOnDestroy(): void {
  }

  ChangeSortOrderForAreaSectors(ascDesc: AscDescEnum) {
    this.appStateService.UserPreference.AreaSectorsSortOrder = ascDesc;
  }

}


