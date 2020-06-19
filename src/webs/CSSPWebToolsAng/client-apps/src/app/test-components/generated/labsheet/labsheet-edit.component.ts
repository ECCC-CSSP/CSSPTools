/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { LabSheetService } from './labsheet.service';
import { LoadLocalesLabSheetText } from './labsheet.locales';
import { Subscription } from 'rxjs';
import { SamplingPlanTypeEnum_GetOrderedText } from '../../../enums/generated/SamplingPlanTypeEnum';
import { SampleTypeEnum_GetOrderedText } from '../../../enums/generated/SampleTypeEnum';
import { LabSheetTypeEnum_GetOrderedText } from '../../../enums/generated/LabSheetTypeEnum';
import { LabSheetStatusEnum_GetOrderedText } from '../../../enums/generated/LabSheetStatusEnum';
import { LabSheet } from '../../../models/generated/LabSheet.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-labsheet-edit',
  templateUrl: './labsheet-edit.component.html',
  styleUrls: ['./labsheet-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LabSheetEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  samplingPlanTypeList: EnumIDAndText[];
  sampleTypeList: EnumIDAndText[];
  labSheetTypeList: EnumIDAndText[];
  labSheetStatusList: EnumIDAndText[];
  labsheetFormEdit: FormGroup;
  @Input() labsheet: LabSheet = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public labsheetService: LabSheetService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutLabSheet(labsheet: LabSheet) {
    this.sub = this.labsheetService.PutLabSheet(labsheet).subscribe();
  }

  PostLabSheet(labsheet: LabSheet) {
    this.sub = this.labsheetService.PostLabSheet(labsheet).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesLabSheetText(this.labsheetService);
    this.samplingPlanTypeList = SamplingPlanTypeEnum_GetOrderedText();
    this.sampleTypeList = SampleTypeEnum_GetOrderedText();
    this.labSheetTypeList = LabSheetTypeEnum_GetOrderedText();
    this.labSheetStatusList = LabSheetStatusEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.labsheet) {
      let formGroup: FormGroup = this.fb.group(
        {
          LabSheetID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.labsheet.LabSheetID)),
              disabled: false
            }, [Validators.required]],
          OtherServerLabSheetID: [
            {
              value: this.labsheet.OtherServerLabSheetID,
              disabled: false
            }, [Validators.required, Validators.min(1)]],
          SamplingPlanID: [
            {
              value: this.labsheet.SamplingPlanID,
              disabled: false
            }, [Validators.required]],
          SamplingPlanName: [
            {
              value: this.labsheet.SamplingPlanName,
              disabled: false
            }, [Validators.required, Validators.minLength(1), Validators.maxLength(250)]],
          Year: [
            {
              value: this.labsheet.Year,
              disabled: false
            }, [Validators.required, Validators.min(1980)]],
          Month: [
            {
              value: this.labsheet.Month,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(12)]],
          Day: [
            {
              value: this.labsheet.Day,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(31)]],
          RunNumber: [
            {
              value: this.labsheet.RunNumber,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(100)]],
          SubsectorTVItemID: [
            {
              value: this.labsheet.SubsectorTVItemID,
              disabled: false
            }, [Validators.required]],
          MWQMRunTVItemID: [
            {
              value: this.labsheet.MWQMRunTVItemID,
              disabled: false
            }],
          SamplingPlanType: [
            {
              value: this.labsheet.SamplingPlanType,
              disabled: false
            }, [Validators.required]],
          SampleType: [
            {
              value: this.labsheet.SampleType,
              disabled: false
            }, [Validators.required]],
          LabSheetType: [
            {
              value: this.labsheet.LabSheetType,
              disabled: false
            }, [Validators.required]],
          LabSheetStatus: [
            {
              value: this.labsheet.LabSheetStatus,
              disabled: false
            }, [Validators.required]],
          FileName: [
            {
              value: this.labsheet.FileName,
              disabled: false
            }, [Validators.required, Validators.minLength(1), Validators.maxLength(250)]],
          FileLastModifiedDate_Local: [
            {
              value: this.labsheet.FileLastModifiedDate_Local,
              disabled: false
            }, [Validators.required]],
          FileContent: [
            {
              value: this.labsheet.FileContent,
              disabled: false
            }, [Validators.required]],
          AcceptedOrRejectedByContactTVItemID: [
            {
              value: this.labsheet.AcceptedOrRejectedByContactTVItemID,
              disabled: false
            }],
          AcceptedOrRejectedDateTime: [
            {
              value: this.labsheet.AcceptedOrRejectedDateTime,
              disabled: false
            }],
          RejectReason: [
            {
              value: this.labsheet.RejectReason,
              disabled: false
            }, [Validators.maxLength(250)]],
          LastUpdateDate_UTC: [
            {
              value: this.labsheet.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.labsheet.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.labsheetFormEdit = formGroup
    }
  }
}
