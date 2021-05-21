import { Component, OnInit, OnDestroy } from '@angular/core';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { GetProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { GetSortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
import { GetTVTypeEnum, TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebClimateSites } from 'src/app/models/generated/web/WebClimateSites.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentShowService } from 'src/app/services/helpers/component-show.service';
import { FilterService } from 'src/app/services/helpers/filter.service';
import { LoadListService } from 'src/app/services/helpers/loading-list.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { SortTVItemMunicipalityListService } from 'src/app/services/helpers/sort-tvitem-municipality-list.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';
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
  filesSortPropEnum = GetFilesSortPropEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public loaderService: LoaderService,
    private loadListService: LoadListService,
    public statCountService: StatCountService,
    public sortTVItemListService: SortTVItemListService,
    public sortTVItemMunicipalityListService: SortTVItemMunicipalityListService,
    public filterService: FilterService,
    public componentShowService: ComponentShowService,
    public structureTVFileListService: StructureTVFileListService) { }

  ngOnInit(): void {
    this.loadListService.SetToLoadList(TVTypeEnum.Province, this.appStateService.UserPreference.CurrentProvinceTVItemID, false);
    this.loaderService.LoadAll();
  }

  ngOnDestroy(): void {
  }
}
