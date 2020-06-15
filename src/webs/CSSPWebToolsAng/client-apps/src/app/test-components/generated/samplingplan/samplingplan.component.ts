/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { SamplingPlanService } from './samplingplan.service';
import { LoadLocalesSamplingPlanText } from './samplingplan.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { SampleTypeEnum_GetIDText, SampleTypeEnum_GetOrderedText } from '../../../enums/generated/SampleTypeEnum';
import { SamplingPlanTypeEnum_GetIDText, SamplingPlanTypeEnum_GetOrderedText } from '../../../enums/generated/SamplingPlanTypeEnum';
import { LabSheetTypeEnum_GetIDText, LabSheetTypeEnum_GetOrderedText } from '../../../enums/generated/LabSheetTypeEnum';
import { AnalyzeMethodEnum_GetIDText, AnalyzeMethodEnum_GetOrderedText } from '../../../enums/generated/AnalyzeMethodEnum';
import { SampleMatrixEnum_GetIDText, SampleMatrixEnum_GetOrderedText } from '../../../enums/generated/SampleMatrixEnum';
import { LaboratoryEnum_GetIDText, LaboratoryEnum_GetOrderedText } from '../../../enums/generated/LaboratoryEnum';
import { SamplingPlan } from '../../../models/generated/SamplingPlan.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';

@Component({
  selector: 'app-samplingplan',
  templateUrl: './samplingplan.component.html',
  styleUrls: ['./samplingplan.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SamplingPlanComponent implements OnInit, OnDestroy {
  sub: Subscription;
  sampleTypeList: EnumIDAndText[];
  samplingPlanTypeList: EnumIDAndText[];
  labSheetTypeList: EnumIDAndText[];
  analyzeMethodDefaultList: EnumIDAndText[];
  sampleMatrixDefaultList: EnumIDAndText[];
  laboratoryDefaultList: EnumIDAndText[];
  samplingplanFormPut: FormGroup;
  samplingplanFormPost: FormGroup;

  constructor(public samplingplanService: SamplingPlanService, public router: Router, public fb: FormBuilder) { }

  GetSamplingPlanList() {
    this.sub = this.samplingplanService.GetSamplingPlanList(this.router).subscribe();
  }

  PutSamplingPlan(samplingplan: SamplingPlan) {
    this.sub = this.samplingplanService.PutSamplingPlan(samplingplan, this.router).subscribe();
  }

  PostSamplingPlan(samplingplan: SamplingPlan) {
    this.sub = this.samplingplanService.PostSamplingPlan(samplingplan, this.router).subscribe();
  }

  DeleteSamplingPlan(samplingplan: SamplingPlan) {
    this.sub = this.samplingplanService.DeleteSamplingPlan(samplingplan, this.router).subscribe();
  }

  GetSampleTypeEnumText(enumID: number) {
    return SampleTypeEnum_GetIDText(enumID)
  }

  GetSamplingPlanTypeEnumText(enumID: number) {
    return SamplingPlanTypeEnum_GetIDText(enumID)
  }

  GetLabSheetTypeEnumText(enumID: number) {
    return LabSheetTypeEnum_GetIDText(enumID)
  }

  GetAnalyzeMethodEnumText(enumID: number) {
    return AnalyzeMethodEnum_GetIDText(enumID)
  }

  GetSampleMatrixEnumText(enumID: number) {
    return SampleMatrixEnum_GetIDText(enumID)
  }

  GetLaboratoryEnumText(enumID: number) {
    return LaboratoryEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesSamplingPlanText(this.samplingplanService);
    this.sampleTypeList = SampleTypeEnum_GetOrderedText();
    this.samplingPlanTypeList = SamplingPlanTypeEnum_GetOrderedText();
    this.labSheetTypeList = LabSheetTypeEnum_GetOrderedText();
    this.analyzeMethodDefaultList = AnalyzeMethodEnum_GetOrderedText();
    this.sampleMatrixDefaultList = SampleMatrixEnum_GetOrderedText();
    this.laboratoryDefaultList = LaboratoryEnum_GetOrderedText();
    this.FillFormBuilderGroup('Add');
    this.FillFormBuilderGroup('Update');
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(AddOrUpdate: string) {
    if (this.samplingplanService.samplingplanList.length) {
      let formGroup: FormGroup = this.fb.group(
        {
          SamplingPlanID: [
            {
              value: (AddOrUpdate === 'Add' ? 0 : (this.samplingplanService.samplingplanList[0]?.SamplingPlanID)),
              disabled: false
            }],
          IsActive: [
            {
              value: this.samplingplanService.samplingplanList[0]?.IsActive,
              disabled: false
            }],
          SamplingPlanName: [
            {
              value: this.samplingplanService.samplingplanList[0]?.SamplingPlanName,
              disabled: false
            }],
          ForGroupName: [
            {
              value: this.samplingplanService.samplingplanList[0]?.ForGroupName,
              disabled: false
            }],
          SampleType: [
            {
              value: this.samplingplanService.samplingplanList[0]?.SampleType,
              disabled: false
            }],
          SamplingPlanType: [
            {
              value: this.samplingplanService.samplingplanList[0]?.SamplingPlanType,
              disabled: false
            }],
          LabSheetType: [
            {
              value: this.samplingplanService.samplingplanList[0]?.LabSheetType,
              disabled: false
            }],
          ProvinceTVItemID: [
            {
              value: this.samplingplanService.samplingplanList[0]?.ProvinceTVItemID,
              disabled: false
            }],
          CreatorTVItemID: [
            {
              value: this.samplingplanService.samplingplanList[0]?.CreatorTVItemID,
              disabled: false
            }],
          Year: [
            {
              value: this.samplingplanService.samplingplanList[0]?.Year,
              disabled: false
            }],
          AccessCode: [
            {
              value: this.samplingplanService.samplingplanList[0]?.AccessCode,
              disabled: false
            }],
          DailyDuplicatePrecisionCriteria: [
            {
              value: this.samplingplanService.samplingplanList[0]?.DailyDuplicatePrecisionCriteria,
              disabled: false
            }],
          IntertechDuplicatePrecisionCriteria: [
            {
              value: this.samplingplanService.samplingplanList[0]?.IntertechDuplicatePrecisionCriteria,
              disabled: false
            }],
          IncludeLaboratoryQAQC: [
            {
              value: this.samplingplanService.samplingplanList[0]?.IncludeLaboratoryQAQC,
              disabled: false
            }],
          ApprovalCode: [
            {
              value: this.samplingplanService.samplingplanList[0]?.ApprovalCode,
              disabled: false
            }],
          SamplingPlanFileTVItemID: [
            {
              value: this.samplingplanService.samplingplanList[0]?.SamplingPlanFileTVItemID,
              disabled: false
            }],
          AnalyzeMethodDefault: [
            {
              value: this.samplingplanService.samplingplanList[0]?.AnalyzeMethodDefault,
              disabled: false
            }],
          SampleMatrixDefault: [
            {
              value: this.samplingplanService.samplingplanList[0]?.SampleMatrixDefault,
              disabled: false
            }],
          LaboratoryDefault: [
            {
              value: this.samplingplanService.samplingplanList[0]?.LaboratoryDefault,
              disabled: false
            }],
          BackupDirectory: [
            {
              value: this.samplingplanService.samplingplanList[0]?.BackupDirectory,
              disabled: false
            }],
          LastUpdateDate_UTC: [
            {
              value: this.samplingplanService.samplingplanList[0]?.LastUpdateDate_UTC,
              disabled: false
            }],
          LastUpdateContactTVItemID: [
            {
              value: this.samplingplanService.samplingplanList[0]?.LastUpdateContactTVItemID,
              disabled: false
            }],
        }
      );

      if (AddOrUpdate === 'Add') {
        this.samplingplanFormPost = formGroup
      }
      else {
        this.samplingplanFormPut = formGroup;
      }
    }
  }
}
