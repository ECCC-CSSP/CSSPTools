import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { GetAnalysisCalculationTypeEnum } from 'src/app/enums/generated/AnalysisCalculationTypeEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { EnumIDAndText } from 'src/app/models/generated/models/EnumIDAndText.model';
import { StatMWQMRun } from 'src/app/models/generated/models/StatMWQMRun.model';
import { StatMWQMSite } from 'src/app/models/generated/models/StatMWQMSite.model';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AnalysisService } from 'src/app/services/analysis/analysis.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { TogglesService } from 'src/app/services/helpers/toggles.service';

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
    public dateFormatService: DateFormatService,
    private fb: FormBuilder,
    public analysisService: AnalysisService) { }

  ngOnInit(): void {
    this.language = <number>this.appLanguageService.Language;
    this.formStat = this.fb.group({
      AnalysisStartRun: [this.appStateService.AnalysisStartRun],
      AnalysisEndRun: [this.appStateService.AnalysisEndRun],
      AnalysisRuns: [this.appStateService.UserPreference.AnalysisRuns],
      AnalysisFullYear: [this.appStateService.UserPreference.AnalysisFullYear],
      AnalysisShowOnlyUsed: [this.appStateService.AnalysisShowOnlyUsed],
      AnalysisCalculationType: [this.appStateService.UserPreference.AnalysisCalculationType],
      AnalysisHighlightSalFromAverage: [this.appStateService.UserPreference.AnalysisHighlightSalFromAverage],
      AnalysisShortRange: [this.appStateService.UserPreference.AnalysisShortRange],
      AnalysisMidRange: [this.appStateService.UserPreference.AnalysisMidRange],
      AnalysisDry24h: [this.appStateService.UserPreference.AnalysisDry24h],
      AnalysisDry48h: [this.appStateService.UserPreference.AnalysisDry48h],
      AnalysisDry72h: [this.appStateService.UserPreference.AnalysisDry72h],
      AnalysisDry96h: [this.appStateService.UserPreference.AnalysisDry96h],
      AnalysisWet24h: [this.appStateService.UserPreference.AnalysisWet24h],
      AnalysisWet48h: [this.appStateService.UserPreference.AnalysisWet48h],
      AnalysisWet72h: [this.appStateService.UserPreference.AnalysisWet72h],
      AnalysisWet96h: [this.appStateService.UserPreference.AnalysisWet96h],
    });
    this.enumIDAndTextList = this.analysisService.GetAnalysisCalculationTypeEnum_GetOrderedText();
    this.dryRain_mm_List = this.analysisService.GetDryRain();
    this.wetRain_mm_List = this.analysisService.GetWetRain();
  }

  ngOnDestroy(): void {
  }
}
