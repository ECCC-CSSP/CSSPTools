import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { GetAnalysisCalculationTypeEnum } from 'src/app/enums/generated/AnalysisCalculationTypeEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
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

@Component({
  selector: 'app-analysis-options',
  templateUrl: './analysis-options.component.html',
  styleUrls: ['./analysis-options.component.css']
})
export class AnalysisOptionsComponent implements OnInit, OnDestroy {
  @Input() TVItemModelList: TVItemModel[] = [];
  @Input() StatMWQMSiteList: StatMWQMSite[] = [];
  @Input() StatMWQMRunList: StatMWQMRun[] = [];

  formStat: FormGroup;

  languageEnum = GetLanguageEnum();
  tvTypeEnum = GetTVTypeEnum();
  analysisCalculationTypeEnum = GetAnalysisCalculationTypeEnum();
  language: number;
  enumIDAndTextList: EnumIDAndText[] = [];
  dryRain_mm_List: number[] = [];
  wetRain_mm_List: number[] = [];
  rangeVal: number[] = [1, 2, 3, 4, 5];
  salDevVal: number[] = [3, 4, 5, 6, 7, 8, 9, 10, 11, 12];

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public togglesService: TogglesService,
    public appLanguageService: AppLanguageService,
    public componentButtonSelectionService: ComponentButtonSelectionService,
    public dateFormatService: DateFormatService,
    private fb: FormBuilder,
    public analysisService: AnalysisService,
    private webMWQMSamplesService: WebMWQMSamplesService) { }

  ngOnInit(): void {
    this.language = <number>this.appLanguageService.Language;
    this.formStat = this.fb.group({
      AnalysisStartRun: [this.appStateService.AnalysisStartRun],
      AnalysisEndRun: [this.appStateService.AnalysisEndRun],
      AnalysisRuns: [this.appStateService.AnalysisRuns],
      AnalysisFullYear: [this.appStateService.AnalysisFullYear],
      AnalysisShowOnlyUsed: [this.appStateService.AnalysisShowOnlyUsed],
      AnalysisCalculationType: [this.appStateService.AnalysisCalculationType],
      AnalysisHighlightSalFromAverage: [this.appStateService.AnalysisHighlightSalFromAverage],
      AnalysisShortRange: [this.appStateService.AnalysisShortRange],
      AnalysisMidRange: [this.appStateService.AnalysisMidRange],
      AnalysisDry24h: [this.appStateService.AnalysisDry24h],
      AnalysisDry48h: [this.appStateService.AnalysisDry48h],
      AnalysisDry72h: [this.appStateService.AnalysisDry72h],
      AnalysisDry96h: [this.appStateService.AnalysisDry96h],
      AnalysisWet24h: [this.appStateService.AnalysisWet24h],
      AnalysisWet48h: [this.appStateService.AnalysisWet48h],
      AnalysisWet72h: [this.appStateService.AnalysisWet72h],
      AnalysisWet96h: [this.appStateService.AnalysisWet96h],
    });
    this.enumIDAndTextList = this.analysisService.GetAnalysisCalculationTypeEnum_GetOrderedText();
    this.dryRain_mm_List = this.analysisService.GetDryRain();
    this.wetRain_mm_List = this.analysisService.GetWetRain();
  }

  ngOnDestroy(): void {
  }
}
