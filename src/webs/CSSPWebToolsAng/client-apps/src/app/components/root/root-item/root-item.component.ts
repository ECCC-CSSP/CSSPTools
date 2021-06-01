import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetRootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { GetTVTypeEnum, TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { FilterService } from 'src/app/services/helpers/filter.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';
import { GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { LoadListService } from 'src/app/services/helpers/loading-list.service';


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
  filesSortPropEnum = GetFilesSortPropEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public loaderService: LoaderService,
    private loadListService: LoadListService,
    public statCountService: StatCountService,
    public sortTVItemListService: SortTVItemListService,
    public filterService: FilterService,
    public componentShowService: ComponentShowService,
    public structureTVFileListService: StructureTVFileListService) {
  }

  ngOnInit(): void {
    this.loadListService.SetToLoadList(TVTypeEnum.Root, this.appStateService.UserPreference.CurrentRootTVItemID, false);
    this.loaderService.LoadAll();
  }

  ngOnDestroy(): void {
  }
}
