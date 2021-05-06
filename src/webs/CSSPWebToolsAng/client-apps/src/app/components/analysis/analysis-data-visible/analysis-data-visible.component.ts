import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AnalysisService } from 'src/app/services/helpers/analysis.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';

@Component({
  selector: 'app-analysis-data-visible',
  templateUrl: './analysis-data-visible.component.html',
  styleUrls: ['./analysis-data-visible.component.css']
})
export class AnalysisDataVisibleComponent implements OnInit, OnDestroy {


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
    this.language = <number>this.appLanguageService.Language;
    this.formDataVisible = this.fb.group({
      AnalysisFCDataVisible: [ { value: this.appStateService.AnalysisFCDataVisible, disabled: true }],
      AnalysisTempDataVisible: [this.appStateService.AnalysisTempDataVisible],
      AnalysisSalDataVisible: [this.appStateService.AnalysisSalDataVisible],
      AnalysisP90DataVisible: [this.appStateService.AnalysisP90DataVisible],
      AnalysisGeoMeanDataVisible: [this.appStateService.AnalysisGeoMeanDataVisible],
      AnalysisMedianDataVisible: [this.appStateService.AnalysisMedianDataVisible],
      AnalysisPerOver43DataVisible: [this.appStateService.AnalysisPerOver43DataVisible],
      AnalysisPerOver260DataVisible: [this.appStateService.AnalysisPerOver260DataVisible],
    });
  }

  ngOnDestroy(): void {
  }


}
