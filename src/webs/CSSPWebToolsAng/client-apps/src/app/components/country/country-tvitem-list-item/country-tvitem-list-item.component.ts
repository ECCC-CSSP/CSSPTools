import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { LoadModel } from 'src/app/models/generated/web/LoadModel.model';
import { MonitoringStatsByYearModel } from 'src/app/models/generated/web/MonitoringStatsByYearModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { LoadListService } from 'src/app/services/helpers/loading-list.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-country-tvitem-list-item',
  templateUrl: './country-tvitem-list-item.component.html',
  styleUrls: ['./country-tvitem-list-item.component.css']
})
export class CountryTVItemListItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModelList: TVItemModel[] = [];

  ShowView: boolean = false;
  ShowModify: boolean = false;
  ShowAdd: boolean = false;

  languageEnum = GetLanguageEnum();

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public subPageService: SubPageService,
    public mapService: MapService,
    public showTVItemService: ShowTVItemService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }
}
