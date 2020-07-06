/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { BoxModelResultService } from './boxmodelresult.service';
import { LoadLocalesBoxModelResultText } from './boxmodelresult.locales';
import { Subscription } from 'rxjs';
import { BoxModelResultTypeEnum_GetOrderedText } from '../../../enums/generated/BoxModelResultTypeEnum';
import { BoxModelResult } from '../../../models/generated/BoxModelResult.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-boxmodelresult-edit',
  templateUrl: './boxmodelresult-edit.component.html',
  styleUrls: ['./boxmodelresult-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BoxModelResultEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  boxModelResultTypeList: EnumIDAndText[];
  boxmodelresultFormEdit: FormGroup;
  @Input() boxmodelresult: BoxModelResult = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public boxmodelresultService: BoxModelResultService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutBoxModelResult(boxmodelresult: BoxModelResult) {
    this.sub = this.boxmodelresultService.PutBoxModelResult(boxmodelresult).subscribe();
  }

  PostBoxModelResult(boxmodelresult: BoxModelResult) {
    this.sub = this.boxmodelresultService.PostBoxModelResult(boxmodelresult).subscribe();
  }

  ngOnInit(): void {
    this.boxModelResultTypeList = BoxModelResultTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.boxmodelresult) {
      let formGroup: FormGroup = this.fb.group(
        {
          BoxModelResultID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.boxmodelresult.BoxModelResultID)),
              disabled: false
            }, [Validators.required]],
          BoxModelID: [
            {
              value: this.boxmodelresult.BoxModelID,
              disabled: false
            }, [Validators.required]],
          BoxModelResultType: [
            {
              value: this.boxmodelresult.BoxModelResultType,
              disabled: false
            }, [Validators.required]],
          Volume_m3: [
            {
              value: this.boxmodelresult.Volume_m3,
              disabled: false
            }, [Validators.required, Validators.min(0)]],
          Surface_m2: [
            {
              value: this.boxmodelresult.Surface_m2,
              disabled: false
            }, [Validators.required, Validators.min(0)]],
          Radius_m: [
            {
              value: this.boxmodelresult.Radius_m,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(100000)]],
          LeftSideDiameterLineAngle_deg: [
            {
              value: this.boxmodelresult.LeftSideDiameterLineAngle_deg,
              disabled: false
            }, [Validators.min(0), Validators.max(360)]],
          CircleCenterLatitude: [
            {
              value: this.boxmodelresult.CircleCenterLatitude,
              disabled: false
            }, [Validators.min(-90), Validators.max(90)]],
          CircleCenterLongitude: [
            {
              value: this.boxmodelresult.CircleCenterLongitude,
              disabled: false
            }, [Validators.min(-180), Validators.max(180)]],
          FixLength: [
            {
              value: this.boxmodelresult.FixLength,
              disabled: false
            }, [Validators.required]],
          FixWidth: [
            {
              value: this.boxmodelresult.FixWidth,
              disabled: false
            }, [Validators.required]],
          RectLength_m: [
            {
              value: this.boxmodelresult.RectLength_m,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(100000)]],
          RectWidth_m: [
            {
              value: this.boxmodelresult.RectWidth_m,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(100000)]],
          LeftSideLineAngle_deg: [
            {
              value: this.boxmodelresult.LeftSideLineAngle_deg,
              disabled: false
            }, [Validators.min(0), Validators.max(360)]],
          LeftSideLineStartLatitude: [
            {
              value: this.boxmodelresult.LeftSideLineStartLatitude,
              disabled: false
            }, [Validators.min(-90), Validators.max(90)]],
          LeftSideLineStartLongitude: [
            {
              value: this.boxmodelresult.LeftSideLineStartLongitude,
              disabled: false
            }, [Validators.min(-180), Validators.max(180)]],
          LastUpdateDate_UTC: [
            {
              value: this.boxmodelresult.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.boxmodelresult.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.boxmodelresultFormEdit = formGroup
    }
  }
}
