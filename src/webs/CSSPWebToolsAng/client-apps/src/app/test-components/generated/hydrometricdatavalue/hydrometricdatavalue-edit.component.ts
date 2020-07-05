/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { HydrometricDataValueService } from './hydrometricdatavalue.service';
import { LoadLocalesHydrometricDataValueText } from './hydrometricdatavalue.locales';
import { Subscription } from 'rxjs';
import { StorageDataTypeEnum_GetOrderedText } from '../../../enums/generated/StorageDataTypeEnum';
import { HydrometricDataValue } from '../../../models/generated/HydrometricDataValue.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-hydrometricdatavalue-edit',
  templateUrl: './hydrometricdatavalue-edit.component.html',
  styleUrls: ['./hydrometricdatavalue-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HydrometricDataValueEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  storageDataTypeList: EnumIDAndText[];
  hydrometricdatavalueFormEdit: FormGroup;
  @Input() hydrometricdatavalue: HydrometricDataValue = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public hydrometricdatavalueService: HydrometricDataValueService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutHydrometricDataValue(hydrometricdatavalue: HydrometricDataValue) {
    this.sub = this.hydrometricdatavalueService.PutHydrometricDataValue(hydrometricdatavalue).subscribe();
  }

  PostHydrometricDataValue(hydrometricdatavalue: HydrometricDataValue) {
    this.sub = this.hydrometricdatavalueService.PostHydrometricDataValue(hydrometricdatavalue).subscribe();
  }

  ngOnInit(): void {
    this.storageDataTypeList = StorageDataTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.hydrometricdatavalue) {
      let formGroup: FormGroup = this.fb.group(
        {
          HydrometricDataValueID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.hydrometricdatavalue.HydrometricDataValueID)),
              disabled: false
            }, [Validators.required]],
          HydrometricSiteID: [
            {
              value: this.hydrometricdatavalue.HydrometricSiteID,
              disabled: false
            }, [Validators.required]],
          DateTime_Local: [
            {
              value: this.hydrometricdatavalue.DateTime_Local,
              disabled: false
            }, [Validators.required]],
          Keep: [
            {
              value: this.hydrometricdatavalue.Keep,
              disabled: false
            }, [Validators.required]],
          StorageDataType: [
            {
              value: this.hydrometricdatavalue.StorageDataType,
              disabled: false
            }, [Validators.required]],
          HasBeenRead: [
            {
              value: this.hydrometricdatavalue.HasBeenRead,
              disabled: false
            }, [Validators.required]],
          Discharge_m3_s: [
            {
              value: this.hydrometricdatavalue.Discharge_m3_s,
              disabled: false
            }, [Validators.min(0), Validators.max(100000)]],
          DischargeEntered_m3_s: [
            {
              value: this.hydrometricdatavalue.DischargeEntered_m3_s,
              disabled: false
            }, [Validators.min(0), Validators.max(100000)]],
          Level_m: [
            {
              value: this.hydrometricdatavalue.Level_m,
              disabled: false
            }, [Validators.min(0), Validators.max(10000)]],
          HourlyValues: [
            {
              value: this.hydrometricdatavalue.HourlyValues,
              disabled: false
            }],
          LastUpdateDate_UTC: [
            {
              value: this.hydrometricdatavalue.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.hydrometricdatavalue.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.hydrometricdatavalueFormEdit = formGroup
    }
  }
}
