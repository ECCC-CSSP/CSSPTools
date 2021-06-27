import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { MWQMSample } from 'src/app/models/generated/db/MWQMSample.model';
import { MWQMSiteModel } from 'src/app/models/generated/web/MWQMSiteModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { StatService } from 'src/app/services/helpers/stat.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-mwqm-run-item-menu-open',
  templateUrl: './mwqm-run-item-menu-open.component.html',
  styleUrls: ['./mwqm-run-item-menu-open.component.css']
})
export class MWQMRunItemMenuOpenComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  ViewVisible: boolean = true;
  ModifyVisible: boolean = false;
  CreateVisible: boolean = false;
  
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
}
