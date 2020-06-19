/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { LabSheetTubeMPNDetailService } from './labsheettubempndetail.service';
import { LoadLocalesLabSheetTubeMPNDetailText } from './labsheettubempndetail.locales';
import { Subscription } from 'rxjs';
import { SampleTypeEnum_GetOrderedText } from '../../../enums/generated/SampleTypeEnum';
import { LabSheetTubeMPNDetail } from '../../../models/generated/LabSheetTubeMPNDetail.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-labsheettubempndetail-edit',
  templateUrl: './labsheettubempndetail-edit.component.html',
  styleUrls: ['./labsheettubempndetail-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LabSheetTubeMPNDetailEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  sampleTypeList: EnumIDAndText[];
  labsheettubempndetailFormEdit: FormGroup;
  @Input() labsheettubempndetail: LabSheetTubeMPNDetail = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public labsheettubempndetailService: LabSheetTubeMPNDetailService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutLabSheetTubeMPNDetail(labsheettubempndetail: LabSheetTubeMPNDetail) {
    this.sub = this.labsheettubempndetailService.PutLabSheetTubeMPNDetail(labsheettubempndetail).subscribe();
  }

  PostLabSheetTubeMPNDetail(labsheettubempndetail: LabSheetTubeMPNDetail) {
    this.sub = this.labsheettubempndetailService.PostLabSheetTubeMPNDetail(labsheettubempndetail).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesLabSheetTubeMPNDetailText(this.labsheettubempndetailService);
    this.sampleTypeList = SampleTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.labsheettubempndetail) {
      let formGroup: FormGroup = this.fb.group(
        {
          LabSheetTubeMPNDetailID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.labsheettubempndetail.LabSheetTubeMPNDetailID)),
              disabled: false
            }, [Validators.required]],
          LabSheetDetailID: [
            {
              value: this.labsheettubempndetail.LabSheetDetailID,
              disabled: false
            }, [Validators.required]],
          Ordinal: [
            {
              value: this.labsheettubempndetail.Ordinal,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(1000)]],
          MWQMSiteTVItemID: [
            {
              value: this.labsheettubempndetail.MWQMSiteTVItemID,
              disabled: false
            }, [Validators.required]],
          SampleDateTime: [
            {
              value: this.labsheettubempndetail.SampleDateTime,
              disabled: false
            }],
          MPN: [
            {
              value: this.labsheettubempndetail.MPN,
              disabled: false
            }, [Validators.min(1), Validators.max(10000000)]],
          Tube10: [
            {
              value: this.labsheettubempndetail.Tube10,
              disabled: false
            }, [Validators.min(0), Validators.max(5)]],
          Tube1_0: [
            {
              value: this.labsheettubempndetail.Tube1_0,
              disabled: false
            }, [Validators.min(0), Validators.max(5)]],
          Tube0_1: [
            {
              value: this.labsheettubempndetail.Tube0_1,
              disabled: false
            }, [Validators.min(0), Validators.max(5)]],
          Salinity: [
            {
              value: this.labsheettubempndetail.Salinity,
              disabled: false
            }, [Validators.min(0), Validators.max(40)]],
          Temperature: [
            {
              value: this.labsheettubempndetail.Temperature,
              disabled: false
            }, [Validators.min(-10), Validators.max(40)]],
          ProcessedBy: [
            {
              value: this.labsheettubempndetail.ProcessedBy,
              disabled: false
            }, [Validators.maxLength(10)]],
          SampleType: [
            {
              value: this.labsheettubempndetail.SampleType,
              disabled: false
            }, [Validators.required]],
          SiteComment: [
            {
              value: this.labsheettubempndetail.SiteComment,
              disabled: false
            }, [Validators.maxLength(250)]],
          LastUpdateDate_UTC: [
            {
              value: this.labsheettubempndetail.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.labsheettubempndetail.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.labsheettubempndetailFormEdit = formGroup
    }
  }
}
