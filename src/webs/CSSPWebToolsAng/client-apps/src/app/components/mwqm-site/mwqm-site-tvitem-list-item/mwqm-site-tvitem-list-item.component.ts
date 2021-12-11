import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { MWQMSample } from 'src/app/models/generated/db/MWQMSample.model';
import { MWQMSiteModel } from 'src/app/models/generated/models/MWQMSiteModel.model';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { StatService } from 'src/app/services/helpers/stat.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-mwqm-site-tvitem-list-item',
  templateUrl: './mwqm-site-tvitem-list-item.component.html',
  styleUrls: ['./mwqm-site-tvitem-list-item.component.css']
})
export class MWQMSiteTVItemListItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModelList: TVItemModel[] = [];

  language = GetLanguageEnum();
  tvType = GetTVTypeEnum();

  MWQMSampleList: MWQMSample[];
  Year: number = 0;

  LocalizeVisible: boolean = false;
  
  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public statService: StatService,
    public subPageService: SubPageService,
    public mapService: MapService,
    public dateFormatService: DateFormatService,
    public showTVItemService: ShowTVItemService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  SetStatRunsForDetail(runs: number) {
    this.appStateService.UserPreference.StatRunsForDetail = runs;
    this.appStateService.Working = false;
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();

    let mwqmSiteModel: MWQMSiteModel[] = this.appLoadedService.WebMWQMSites.MWQMSiteModelList;

    if (this.appStateService.GoogleJSLoaded) {
      if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites) {
        if (this.appStateService.GoogleJSLoaded) {
          this.mapService.ClearMap();
        }
        this.mapService.DrawObjects([
          //...this.appLoadedService.WebMWQMSites.MWQMSiteModelList,
          //...[this.appLoadedService.WebMWQMSites.TVItemModel
        ]);
      }
    }

  }
}

