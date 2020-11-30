import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { MWQMSample } from 'src/app/models/generated/db/MWQMSample.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { WebMWQMSampleService } from 'src/app/services/loaders/web-mwqm-samples.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-tvitem-list-item-mwqm-site',
  templateUrl: './tvitem-list-item-mwqm-site.component.html',
  styleUrls: ['./tvitem-list-item-mwqm-site.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListItemMWQMSiteComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() IsBreadCrumb: boolean = false;
  @Input() AppState: AppState;
  @Input() Index: number;

  StatMWQMSite: StatMWQMSite;

  languageEnum = GetLanguageEnum();
  tvTypeEnum = GetTVTypeEnum();

  MWQMSampleList: MWQMSample[];

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public subPageService: SubPageService,
    public mapService: MapService,
    public dateFormatService: DateFormatService,
    public webMWQMSamplesService: WebMWQMSampleService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  SetStatRunsForDetail(runs: number) {
    this.appStateService.UpdateAppState(<AppState>{ StatRunsForDetail: runs, Working: false });
    this.webMWQMSamplesService.FillStatMWQMSiteList();

    let webBaseSubsector: WebBase[] = <WebBase[]>[
      <WebBase>{ TVItemModel: this.appLoadedService.AppLoaded$.getValue().WebSubsector.TVItemModel },
    ];

    if (this.appStateService.AppState$.getValue().SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites) {
      this.mapService.ClearMap();
      this.mapService.DrawObjects([
        ...this.appLoadedService.AppLoaded$.getValue().SubsectorMWQMSiteList,
        ...webBaseSubsector,
      ]);
    }

  }
}

