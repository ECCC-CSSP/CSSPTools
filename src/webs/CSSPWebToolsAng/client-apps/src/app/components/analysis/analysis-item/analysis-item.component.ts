import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetAnalysisCalculationTypeEnum } from 'src/app/enums/generated/AnalysisCalculationTypeEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

import { StatMWQMRun } from 'src/app/models/generated/web/StatMWQMRun.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AnalysisService } from 'src/app/services/analysis/analysis.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { StatService } from 'src/app/services/helpers/stat.service';
import { TogglesService } from 'src/app/services/helpers/toggles.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-analysis-item',
  templateUrl: './analysis-item.component.html',
  styleUrls: ['./analysis-item.component.css']
})
export class AnalysisItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModelList: TVItemModel[] = [];

  @Input() StatMWQMSiteList: StatMWQMSite[] = [];
  @Input() StatMWQMRunList: StatMWQMRun[] = [];

  languageEnum = GetLanguageEnum();
  tvTypeEnum = GetTVTypeEnum();
  analysisCalculationTypeEnum = GetAnalysisCalculationTypeEnum();
  language: number;

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public statService: StatService,
    public togglesService: TogglesService,
    public dateFormatService: DateFormatService,
    public mapService: MapService,
    public analysisService: AnalysisService) { }

  ngOnInit(): void {
    this.language = <number>this.appLanguageService.Language;
    this.statService.FillStatMWQMRunList();
    this.statService.FillStatMWQMSiteList();
  }

  ngOnDestroy(): void {
  }

}
