import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup } from '@angular/forms';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AnalysisService } from 'src/app/services/analysis/analysis.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';

@Component({
  selector: 'app-analysis-data-visible',
  templateUrl: './analysis-data-visible.component.html',
  styleUrls: ['./analysis-data-visible.component.css']
})
export class AnalysisDataVisibleComponent implements OnInit, OnDestroy {


  formDataVisible: UntypedFormGroup;

  languageEnum = GetLanguageEnum();
  language: number;

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public analysisService: AnalysisService,
    public appLanguageService: AppLanguageService,
    public dateFormatService: DateFormatService,
    private fb: UntypedFormBuilder) { };

  ngOnInit(): void {
    this.language = <number>this.appLanguageService.Language;
    this.formDataVisible = this.fb.group({
      AnalysisFCDataVisible: [ { value: this.appStateService.UserPreference.AnalysisFCDataVisible, disabled: true }],
      AnalysisTempDataVisible: [this.appStateService.UserPreference.AnalysisTempDataVisible],
      AnalysisSalDataVisible: [this.appStateService.UserPreference.AnalysisSalDataVisible],
      AnalysisP90DataVisible: [this.appStateService.UserPreference.AnalysisP90DataVisible],
      AnalysisGeoMeanDataVisible: [this.appStateService.UserPreference.AnalysisGeoMeanDataVisible],
      AnalysisMedianDataVisible: [this.appStateService.UserPreference.AnalysisMedianDataVisible],
      AnalysisPerOver43DataVisible: [this.appStateService.UserPreference.AnalysisPerOver43DataVisible],
      AnalysisPerOver260DataVisible: [this.appStateService.UserPreference.AnalysisPerOver260DataVisible],
    });
  }

  ngOnDestroy(): void {
  }


}
