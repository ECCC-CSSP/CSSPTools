/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { SamplingPlanService } from './samplingplan.service';
import { LoadLocalesSamplingPlanText } from './samplingplan.locales';
import { Subscription } from 'rxjs';
import { SampleTypeEnum_GetOrderedText } from '../../../enums/generated/SampleTypeEnum';
import { SamplingPlanTypeEnum_GetOrderedText } from '../../../enums/generated/SamplingPlanTypeEnum';
import { LabSheetTypeEnum_GetOrderedText } from '../../../enums/generated/LabSheetTypeEnum';
import { AnalyzeMethodEnum_GetOrderedText } from '../../../enums/generated/AnalyzeMethodEnum';
import { SampleMatrixEnum_GetOrderedText } from '../../../enums/generated/SampleMatrixEnum';
import { LaboratoryEnum_GetOrderedText } from '../../../enums/generated/LaboratoryEnum';
import { SamplingPlan } from '../../../models/generated/SamplingPlan.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-samplingplan-edit',
  templateUrl: './samplingplan-edit.component.html',
  styleUrls: ['./samplingplan-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SamplingPlanEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  sampleTypeList: EnumIDAndText[];
  samplingPlanTypeList: EnumIDAndText[];
  labSheetTypeList: EnumIDAndText[];
  analyzeMethodDefaultList: EnumIDAndText[];
  sampleMatrixDefaultList: EnumIDAndText[];
  laboratoryDefaultList: EnumIDAndText[];
  samplingplanFormEdit: FormGroup;
  @Input() samplingplan: SamplingPlan = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public samplingplanService: SamplingPlanService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutSamplingPlan(samplingplan: SamplingPlan) {
    this.sub = this.samplingplanService.PutSamplingPlan(samplingplan).subscribe();
  }

  PostSamplingPlan(samplingplan: SamplingPlan) {
    this.sub = this.samplingplanService.PostSamplingPlan(samplingplan).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesSamplingPlanText(this.samplingplanService);
    this.sampleTypeList = SampleTypeEnum_GetOrderedText();
    this.samplingPlanTypeList = SamplingPlanTypeEnum_GetOrderedText();
    this.labSheetTypeList = LabSheetTypeEnum_GetOrderedText();
    this.analyzeMethodDefaultList = AnalyzeMethodEnum_GetOrderedText();
    this.sampleMatrixDefaultList = SampleMatrixEnum_GetOrderedText();
    this.laboratoryDefaultList = LaboratoryEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.samplingplan) {
      let formGroup: FormGroup = this.fb.group(
        {
          SamplingPlanID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.samplingplan.SamplingPlanID)),
              disabled: false
            }, [Validators.required]],
          IsActive: [
            {
              value: this.samplingplan.IsActive,
              disabled: false
            }, [Validators.required]],
          SamplingPlanName: [
            {
              value: this.samplingplan.SamplingPlanName,
              disabled: false
            }, [Validators.required, Validators.maxLength(200)]],
          ForGroupName: [
            {
              value: this.samplingplan.ForGroupName,
              disabled: false
            }, [Validators.required, Validators.maxLength(100)]],
          SampleType: [
            {
              value: this.samplingplan.SampleType,
              disabled: false
            }, [Validators.required]],
          SamplingPlanType: [
            {
              value: this.samplingplan.SamplingPlanType,
              disabled: false
            }, [Validators.required]],
          LabSheetType: [
            {
              value: this.samplingplan.LabSheetType,
              disabled: false
            }, [Validators.required]],
          ProvinceTVItemID: [
            {
              value: this.samplingplan.ProvinceTVItemID,
              disabled: false
            }, [Validators.required]],
          CreatorTVItemID: [
            {
              value: this.samplingplan.CreatorTVItemID,
              disabled: false
            }, [Validators.required]],
          Year: [
            {
              value: this.samplingplan.Year,
              disabled: false
            }, [Validators.required, Validators.min(2000), Validators.max(2050)]],
          AccessCode: [
            {
              value: this.samplingplan.AccessCode,
              disabled: false
            }, [Validators.required, Validators.maxLength(15)]],
          DailyDuplicatePrecisionCriteria: [
            {
              value: this.samplingplan.DailyDuplicatePrecisionCriteria,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(100)]],
          IntertechDuplicatePrecisionCriteria: [
            {
              value: this.samplingplan.IntertechDuplicatePrecisionCriteria,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(100)]],
          IncludeLaboratoryQAQC: [
            {
              value: this.samplingplan.IncludeLaboratoryQAQC,
              disabled: false
            }, [Validators.required]],
          ApprovalCode: [
            {
              value: this.samplingplan.ApprovalCode,
              disabled: false
            }, [Validators.required, Validators.maxLength(15)]],
          SamplingPlanFileTVItemID: [
            {
              value: this.samplingplan.SamplingPlanFileTVItemID,
              disabled: false
            }],
          AnalyzeMethodDefault: [
            {
              value: this.samplingplan.AnalyzeMethodDefault,
              disabled: false
            }],
          SampleMatrixDefault: [
            {
              value: this.samplingplan.SampleMatrixDefault,
              disabled: false
            }],
          LaboratoryDefault: [
            {
              value: this.samplingplan.LaboratoryDefault,
              disabled: false
            }],
          BackupDirectory: [
            {
              value: this.samplingplan.BackupDirectory,
              disabled: false
            }, [Validators.required, Validators.maxLength(250)]],
          LastUpdateDate_UTC: [
            {
              value: this.samplingplan.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.samplingplan.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.samplingplanFormEdit = formGroup
    }
  }
}
