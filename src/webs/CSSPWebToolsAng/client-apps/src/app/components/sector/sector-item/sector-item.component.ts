import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AscDescEnum, GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { GetSectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { FilterService } from 'src/app/services/helpers/filter.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';

@Component({
  selector: 'app-sector-item',
  templateUrl: './sector-item.component.html',
  styleUrls: ['./sector-item.component.css']
})
export class SectorItemComponent implements OnInit, OnDestroy { 
  sectorSubComponentEnum = GetSectorSubComponentEnum();
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
    this.loaderService.Load<WebSector>(WebTypeEnum.WebSector, null, false);
  }

  ngOnDestroy(): void {
  }
}
