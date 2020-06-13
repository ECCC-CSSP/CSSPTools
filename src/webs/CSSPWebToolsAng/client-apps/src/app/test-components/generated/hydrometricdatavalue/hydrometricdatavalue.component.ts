/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { HydrometricDataValueService } from './hydrometricdatavalue.service';
import { LoadLocalesHydrometricDataValueText } from './hydrometricdatavalue.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { StorageDataTypeEnum_GetIDText, StorageDataTypeEnum_GetOrderedText } from '../../../enums/generated/StorageDataTypeEnum';
import { HydrometricDataValue } from '../../../models/generated/HydrometricDataValue.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from 'src/app/models/enumidandtext.model';

@Component({
  selector: 'app-hydrometricdatavalue',
  templateUrl: './hydrometricdatavalue.component.html',
  styleUrls: ['./hydrometricdatavalue.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HydrometricDataValueComponent implements OnInit, OnDestroy {
  sub: Subscription;
  storageDataTypeList: EnumIDAndText[];
  hydrometricdatavalueFormPut: FormGroup;
  hydrometricdatavalueFormPost: FormGroup;

  constructor(public hydrometricdatavalueService: HydrometricDataValueService, public router: Router, public fb: FormBuilder) { }

  GetHydrometricDataValueList() {
    this.sub = this.hydrometricdatavalueService.GetHydrometricDataValueList(this.router).subscribe();
  }

  PutHydrometricDataValue(hydrometricdatavalue: HydrometricDataValue) {
    this.sub = this.hydrometricdatavalueService.PutHydrometricDataValue(hydrometricdatavalue, this.router).subscribe();
  }

  PostHydrometricDataValue(hydrometricdatavalue: HydrometricDataValue) {
    this.sub = this.hydrometricdatavalueService.PostHydrometricDataValue(hydrometricdatavalue, this.router).subscribe();
  }

  DeleteHydrometricDataValue(hydrometricdatavalue: HydrometricDataValue) {
    this.sub = this.hydrometricdatavalueService.DeleteHydrometricDataValue(hydrometricdatavalue, this.router).subscribe();
  }

  GetStorageDataTypeEnumText(enumID: number) {
    return StorageDataTypeEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesHydrometricDataValueText(this.hydrometricdatavalueService);
    this.storageDataTypeList = StorageDataTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup('Add');
    this.FillFormBuilderGroup('Update');
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(AddOrUpdate: string) {
    if (this.hydrometricdatavalueService.hydrometricdatavalueList.length) {
      let formGroup: FormGroup = this.fb.group(
        {
          HydrometricDataValueID: [
            {
              value: (AddOrUpdate === 'Add' ? 0 : (this.hydrometricdatavalueService.hydrometricdatavalueList[0]?.HydrometricDataValueID ?? '')),
              disabled: false
            }, Validators.required],
          HydrometricSiteID: [
            {
              value: this.hydrometricdatavalueService.hydrometricdatavalueList[0]?.HydrometricSiteID ?? '',
              disabled: false
            }, Validators.required],
          DateTime_Local: [
            {
              value: this.hydrometricdatavalueService.hydrometricdatavalueList[0]?.DateTime_Local ?? '',
              disabled: false
            }, Validators.required],
          Keep: [
            {
              value: this.hydrometricdatavalueService.hydrometricdatavalueList[0]?.Keep ?? '',
              disabled: false
            }, Validators.required],
          StorageDataType: [
            {
              value: this.hydrometricdatavalueService.hydrometricdatavalueList[0]?.StorageDataType ?? '',
              disabled: false
            }, Validators.required],
          HasBeenRead: [
            {
              value: this.hydrometricdatavalueService.hydrometricdatavalueList[0]?.HasBeenRead ?? '',
              disabled: false
            }, Validators.required],
          Discharge_m3_s: [
            {
              value: this.hydrometricdatavalueService.hydrometricdatavalueList[0]?.Discharge_m3_s ?? '',
              disabled: false
            }, Validators.required],
          DischargeEntered_m3_s: [
            {
              value: this.hydrometricdatavalueService.hydrometricdatavalueList[0]?.DischargeEntered_m3_s ?? '',
              disabled: false
            }, Validators.required],
          Level_m: [
            {
              value: this.hydrometricdatavalueService.hydrometricdatavalueList[0]?.Level_m ?? '',
              disabled: false
            }, Validators.required],
          HourlyValues: [
            {
              value: this.hydrometricdatavalueService.hydrometricdatavalueList[0]?.HourlyValues ?? '',
              disabled: false
            }, Validators.required],
          LastUpdateDate_UTC: [
            {
              value: this.hydrometricdatavalueService.hydrometricdatavalueList[0]?.LastUpdateDate_UTC ?? '',
              disabled: false
            }, Validators.required],
          LastUpdateContactTVItemID: [
            {
              value: this.hydrometricdatavalueService.hydrometricdatavalueList[0]?.LastUpdateContactTVItemID ?? '',
              disabled: false
            }, Validators.required],
        }
      );

      if (AddOrUpdate === 'Add') {
        this.hydrometricdatavalueFormPost = formGroup
      }
      else {
        this.hydrometricdatavalueFormPut = formGroup;
      }
    }
  }
}
