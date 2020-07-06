/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { MWQMAnalysisReportParameterService } from './mwqmanalysisreportparameter.service';
import { LoadLocalesMWQMAnalysisReportParameterText } from './mwqmanalysisreportparameter.locales';
import { Subscription } from 'rxjs';
import { AnalysisCalculationTypeEnum_GetOrderedText } from '../../../enums/generated/AnalysisCalculationTypeEnum';
import { AnalysisReportExportCommandEnum_GetOrderedText } from '../../../enums/generated/AnalysisReportExportCommandEnum';
import { MWQMAnalysisReportParameter } from '../../../models/generated/MWQMAnalysisReportParameter.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mwqmanalysisreportparameter-edit',
  templateUrl: './mwqmanalysisreportparameter-edit.component.html',
  styleUrls: ['./mwqmanalysisreportparameter-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMAnalysisReportParameterEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  analysisCalculationTypeList: EnumIDAndText[];
  commandList: EnumIDAndText[];
  mwqmanalysisreportparameterFormEdit: FormGroup;
  @Input() mwqmanalysisreportparameter: MWQMAnalysisReportParameter = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public mwqmanalysisreportparameterService: MWQMAnalysisReportParameterService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutMWQMAnalysisReportParameter(mwqmanalysisreportparameter: MWQMAnalysisReportParameter) {
    this.sub = this.mwqmanalysisreportparameterService.PutMWQMAnalysisReportParameter(mwqmanalysisreportparameter).subscribe();
  }

  PostMWQMAnalysisReportParameter(mwqmanalysisreportparameter: MWQMAnalysisReportParameter) {
    this.sub = this.mwqmanalysisreportparameterService.PostMWQMAnalysisReportParameter(mwqmanalysisreportparameter).subscribe();
  }

  ngOnInit(): void {
    this.analysisCalculationTypeList = AnalysisCalculationTypeEnum_GetOrderedText();
    this.commandList = AnalysisReportExportCommandEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.mwqmanalysisreportparameter) {
      let formGroup: FormGroup = this.fb.group(
        {
          MWQMAnalysisReportParameterID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.mwqmanalysisreportparameter.MWQMAnalysisReportParameterID)),
              disabled: false
            }, [Validators.required]],
          SubsectorTVItemID: [
            {
              value: this.mwqmanalysisreportparameter.SubsectorTVItemID,
              disabled: false
            }, [Validators.required]],
          AnalysisName: [
            {
              value: this.mwqmanalysisreportparameter.AnalysisName,
              disabled: false
            }, [Validators.required, Validators.minLength(5), Validators.maxLength(250)]],
          AnalysisReportYear: [
            {
              value: this.mwqmanalysisreportparameter.AnalysisReportYear,
              disabled: false
            }, [Validators.min(1980), Validators.max(2050)]],
          StartDate: [
            {
              value: this.mwqmanalysisreportparameter.StartDate,
              disabled: false
            }, [Validators.required]],
          EndDate: [
            {
              value: this.mwqmanalysisreportparameter.EndDate,
              disabled: false
            }, [Validators.required]],
          AnalysisCalculationType: [
            {
              value: this.mwqmanalysisreportparameter.AnalysisCalculationType,
              disabled: false
            }, [Validators.required]],
          NumberOfRuns: [
            {
              value: this.mwqmanalysisreportparameter.NumberOfRuns,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(1000)]],
          FullYear: [
            {
              value: this.mwqmanalysisreportparameter.FullYear,
              disabled: false
            }, [Validators.required]],
          SalinityHighlightDeviationFromAverage: [
            {
              value: this.mwqmanalysisreportparameter.SalinityHighlightDeviationFromAverage,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(20)]],
          ShortRangeNumberOfDays: [
            {
              value: this.mwqmanalysisreportparameter.ShortRangeNumberOfDays,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(5)]],
          MidRangeNumberOfDays: [
            {
              value: this.mwqmanalysisreportparameter.MidRangeNumberOfDays,
              disabled: false
            }, [Validators.required, Validators.min(2), Validators.max(7)]],
          DryLimit24h: [
            {
              value: this.mwqmanalysisreportparameter.DryLimit24h,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(100)]],
          DryLimit48h: [
            {
              value: this.mwqmanalysisreportparameter.DryLimit48h,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(100)]],
          DryLimit72h: [
            {
              value: this.mwqmanalysisreportparameter.DryLimit72h,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(100)]],
          DryLimit96h: [
            {
              value: this.mwqmanalysisreportparameter.DryLimit96h,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(100)]],
          WetLimit24h: [
            {
              value: this.mwqmanalysisreportparameter.WetLimit24h,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(100)]],
          WetLimit48h: [
            {
              value: this.mwqmanalysisreportparameter.WetLimit48h,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(100)]],
          WetLimit72h: [
            {
              value: this.mwqmanalysisreportparameter.WetLimit72h,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(100)]],
          WetLimit96h: [
            {
              value: this.mwqmanalysisreportparameter.WetLimit96h,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(100)]],
          RunsToOmit: [
            {
              value: this.mwqmanalysisreportparameter.RunsToOmit,
              disabled: false
            }, [Validators.required, Validators.maxLength(250)]],
          ShowDataTypes: [
            {
              value: this.mwqmanalysisreportparameter.ShowDataTypes,
              disabled: false
            }, [Validators.maxLength(20)]],
          ExcelTVFileTVItemID: [
            {
              value: this.mwqmanalysisreportparameter.ExcelTVFileTVItemID,
              disabled: false
            }],
          Command: [
            {
              value: this.mwqmanalysisreportparameter.Command,
              disabled: false
            }, [Validators.required]],
          LastUpdateDate_UTC: [
            {
              value: this.mwqmanalysisreportparameter.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.mwqmanalysisreportparameter.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.mwqmanalysisreportparameterFormEdit = formGroup
    }
  }
}
