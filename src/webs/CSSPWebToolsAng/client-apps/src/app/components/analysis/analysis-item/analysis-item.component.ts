import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetAnalysisCalculationTypeEnum } from 'src/app/enums/generated/AnalysisCalculationTypeEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { StatMWQMRun } from 'src/app/models/generated/web/StatMWQMRun.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AnalysisService } from 'src/app/services/helpers/analysis.service';
import { ComponentButtonSelectionService } from 'src/app/services/helpers/component-button-selection.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { TogglesService } from 'src/app/services/helpers/toggles.service';
import { WebMWQMSamplesService } from 'src/app/services/loaders/web-mwqm-samples.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-analysis-item',
  templateUrl: './analysis-item.component.html',
  styleUrls: ['./analysis-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AnalysisItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModelList: TVItemModel[] = [];
  @Input() AppState: AppState;
  @Input() StatMWQMSiteList: StatMWQMSite[] = [];
  @Input() StatMWQMRunList: StatMWQMRun[] = [];

  languageEnum = GetLanguageEnum();
  tvTypeEnum = GetTVTypeEnum();
  analysisCalculationTypeEnum = GetAnalysisCalculationTypeEnum();
  language: number;

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public togglesService: TogglesService,
    public appLanguageService: AppLanguageService,
    public componentButtonSelectionService: ComponentButtonSelectionService,
    public dateFormatService: DateFormatService,
    public mapService: MapService,
    private webMWQMSamplesService: WebMWQMSamplesService,
    public analysisService: AnalysisService) { }

  ngOnInit(): void {
    this.language = <number>this.appStateService.AppState$.getValue().Language;
    this.webMWQMSamplesService.FillStatMWQMSiteList();
  }

  ngOnDestroy(): void {
  }

}
