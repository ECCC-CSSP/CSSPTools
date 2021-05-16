import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetAreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AscDescEnum, GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { FilterService } from 'src/app/services/helpers/filter.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';
import { GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';

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
    public loaderService: LoaderService,
    public statCountService: StatCountService,
    public sortTVItemListService: SortTVItemListService,
    public filterService: FilterService,
    public componentShowService: ComponentShowService,
    public structureTVFileListService: StructureTVFileListService) { }

  ngOnInit(): void {
    this.loaderService.Load<WebArea>(WebTypeEnum.WebArea, null, false);
  }

  ngOnDestroy(): void {
  }

  ChangeSortOrderForAreaSectors(ascDesc: AscDescEnum) {
    this.appStateService.UserPreference.AreaSectorsSortOrder = ascDesc;
  }

}


