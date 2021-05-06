import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { MWQMSample } from 'src/app/models/generated/db/MWQMSample.model';
import { MWQMSiteModel } from 'src/app/models/generated/web/MWQMSiteModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { WebMWQMSamplesService } from 'src/app/services/loaders/web-mwqm-samples.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-mwqm-site-tvitem-list-item',
  templateUrl: './mwqm-site-tvitem-list-item.component.html',
  styleUrls: ['./mwqm-site-tvitem-list-item.component.css']
})
export class MWQMSiteTVItemListItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModelList: TVItemModel[] = [];

  @Input() IsBreadCrumb: boolean = false;

  languageEnum = GetLanguageEnum();
  tvTypeEnum = GetTVTypeEnum();

  MWQMSampleList: MWQMSample[];
  Year: number = 0;

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public subPageService: SubPageService,
    public mapService: MapService,
    public dateFormatService: DateFormatService,
    public webMWQMSamplesService: WebMWQMSamplesService,
    public showTVItemService: ShowTVItemService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  SetStatRunsForDetail(runs: number) {
    this.appStateService.StatRunsForDetail = runs;
    this.appStateService.Working = false;
    this.webMWQMSamplesService.FillStatMWQMSiteList();

    let mwqmSiteModel: MWQMSiteModel[] = this.appLoadedService.WebMWQMSites.MWQMSiteModelList;

    if (this.appStateService.GoogleJSLoaded) {
      if (this.appStateService.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          //...this.appLoadedService.WebMWQMSites.MWQMSiteModelList,
          //...[this.appLoadedService.WebMWQMSites.TVItemModel
        ]);
      }
    }

  }
}

