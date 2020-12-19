import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { MWQMSample } from 'src/app/models/generated/db/MWQMSample.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { ShowItemForEditService } from 'src/app/services/helpers/show-item-for-edit.service';
import { ShowItemService } from 'src/app/services/helpers/show-item.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { WebMWQMSampleService } from 'src/app/services/loaders/web-mwqm-samples.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-mwqm-site-tvitem-list-item',
  templateUrl: './mwqm-site-tvitem-list-item.component.html',
  styleUrls: ['./mwqm-site-tvitem-list-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSiteTVItemListItemComponent implements OnInit, OnDestroy {
  @Input() TVItemList: WebBase[] = [];
  @Input() AppState: AppState;
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
    public webMWQMSamplesService: WebMWQMSampleService,
    public showItemService: ShowItemService,
    public showItemForEditService: ShowItemForEditService) {
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

    if (this.appStateService.AppState$.getValue().GoogleJSLoaded) {
      if (this.appStateService.AppState$.getValue().SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.AppLoaded$.getValue().SubsectorMWQMSiteList,
          ...webBaseSubsector,
        ]);
      }
    }

  }
}

