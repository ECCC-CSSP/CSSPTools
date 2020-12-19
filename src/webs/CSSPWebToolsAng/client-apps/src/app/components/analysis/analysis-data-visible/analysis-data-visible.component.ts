import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AnalysisService } from 'src/app/services/helpers/analysis.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';

@Component({
  selector: 'app-analysis-data-visible',
  templateUrl: './analysis-data-visible.component.html',
  styleUrls: ['./analysis-data-visible.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AnalysisDataVisibleComponent implements OnInit, OnDestroy {
  @Input() AppState: AppState;

  formDataVisible: FormGroup;

  languageEnum = GetLanguageEnum();
  language: number;

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public analysisService: AnalysisService,
    public appLanguageService: AppLanguageService,
    public dateFormatService: DateFormatService,
    private fb: FormBuilder) { };

  ngOnInit(): void {
    this.language = <number>this.appStateService.AppState$.getValue().Language;
    this.formDataVisible = this.fb.group({
      AnalysisFCDataVisible: [ { value: this.appStateService.AppState$.getValue().AnalysisFCDataVisible, disabled: true }],
      AnalysisTempDataVisible: [this.appStateService.AppState$.getValue().AnalysisTempDataVisible],
      AnalysisSalDataVisible: [this.appStateService.AppState$.getValue().AnalysisSalDataVisible],
      AnalysisP90DataVisible: [this.appStateService.AppState$.getValue().AnalysisP90DataVisible],
      AnalysisGeoMeanDataVisible: [this.appStateService.AppState$.getValue().AnalysisGeoMeanDataVisible],
      AnalysisMedianDataVisible: [this.appStateService.AppState$.getValue().AnalysisMedianDataVisible],
      AnalysisPerOver43DataVisible: [this.appStateService.AppState$.getValue().AnalysisPerOver43DataVisible],
      AnalysisPerOver260DataVisible: [this.appStateService.AppState$.getValue().AnalysisPerOver260DataVisible],
    });
  }

  ngOnDestroy(): void {
  }


}
