/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { MikeBoundaryConditionService } from './mikeboundarycondition.service';
import { LoadLocalesMikeBoundaryConditionText } from './mikeboundarycondition.locales';
import { Subscription } from 'rxjs';
import { MikeBoundaryConditionLevelOrVelocityEnum_GetOrderedText } from '../../../enums/generated/MikeBoundaryConditionLevelOrVelocityEnum';
import { WebTideDataSetEnum_GetOrderedText } from '../../../enums/generated/WebTideDataSetEnum';
import { TVTypeEnum_GetOrderedText } from '../../../enums/generated/TVTypeEnum';
import { MikeBoundaryCondition } from '../../../models/generated/MikeBoundaryCondition.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mikeboundarycondition-edit',
  templateUrl: './mikeboundarycondition-edit.component.html',
  styleUrls: ['./mikeboundarycondition-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MikeBoundaryConditionEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  mikeBoundaryConditionLevelOrVelocityList: EnumIDAndText[];
  webTideDataSetList: EnumIDAndText[];
  tVTypeList: EnumIDAndText[];
  mikeboundaryconditionFormEdit: FormGroup;
  @Input() mikeboundarycondition: MikeBoundaryCondition = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public mikeboundaryconditionService: MikeBoundaryConditionService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutMikeBoundaryCondition(mikeboundarycondition: MikeBoundaryCondition) {
    this.sub = this.mikeboundaryconditionService.PutMikeBoundaryCondition(mikeboundarycondition).subscribe();
  }

  PostMikeBoundaryCondition(mikeboundarycondition: MikeBoundaryCondition) {
    this.sub = this.mikeboundaryconditionService.PostMikeBoundaryCondition(mikeboundarycondition).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesMikeBoundaryConditionText(this.mikeboundaryconditionService);
    this.mikeBoundaryConditionLevelOrVelocityList = MikeBoundaryConditionLevelOrVelocityEnum_GetOrderedText();
    this.webTideDataSetList = WebTideDataSetEnum_GetOrderedText();
    this.tVTypeList = TVTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.mikeboundarycondition) {
      let formGroup: FormGroup = this.fb.group(
        {
          MikeBoundaryConditionID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.mikeboundaryconditionService.mikeboundaryconditionListModel$.getValue()[0]?.MikeBoundaryConditionID)),
              disabled: false
            }, [  Validators.required ]],
          MikeBoundaryConditionTVItemID: [
            {
              value: this.mikeboundaryconditionService.mikeboundaryconditionListModel$.getValue()[0]?.MikeBoundaryConditionTVItemID,
              disabled: false
            }, [  Validators.required ]],
          MikeBoundaryConditionCode: [
            {
              value: this.mikeboundaryconditionService.mikeboundaryconditionListModel$.getValue()[0]?.MikeBoundaryConditionCode,
              disabled: false
            }, [  Validators.required, Validators.maxLength(100) ]],
          MikeBoundaryConditionName: [
            {
              value: this.mikeboundaryconditionService.mikeboundaryconditionListModel$.getValue()[0]?.MikeBoundaryConditionName,
              disabled: false
            }, [  Validators.required, Validators.maxLength(100) ]],
          MikeBoundaryConditionLength_m: [
            {
              value: this.mikeboundaryconditionService.mikeboundaryconditionListModel$.getValue()[0]?.MikeBoundaryConditionLength_m,
              disabled: false
            }, [  Validators.required, Validators.min(1), Validators.max(100000) ]],
          MikeBoundaryConditionFormat: [
            {
              value: this.mikeboundaryconditionService.mikeboundaryconditionListModel$.getValue()[0]?.MikeBoundaryConditionFormat,
              disabled: false
            }, [  Validators.required, Validators.maxLength(100) ]],
          MikeBoundaryConditionLevelOrVelocity: [
            {
              value: this.mikeboundaryconditionService.mikeboundaryconditionListModel$.getValue()[0]?.MikeBoundaryConditionLevelOrVelocity,
              disabled: false
            }, [  Validators.required ]],
          WebTideDataSet: [
            {
              value: this.mikeboundaryconditionService.mikeboundaryconditionListModel$.getValue()[0]?.WebTideDataSet,
              disabled: false
            }, [  Validators.required ]],
          NumberOfWebTideNodes: [
            {
              value: this.mikeboundaryconditionService.mikeboundaryconditionListModel$.getValue()[0]?.NumberOfWebTideNodes,
              disabled: false
            }, [  Validators.required, Validators.min(0), Validators.max(1000) ]],
          WebTideDataFromStartToEndDate: [
            {
              value: this.mikeboundaryconditionService.mikeboundaryconditionListModel$.getValue()[0]?.WebTideDataFromStartToEndDate,
              disabled: false
            }, [  Validators.required ]],
          TVType: [
            {
              value: this.mikeboundaryconditionService.mikeboundaryconditionListModel$.getValue()[0]?.TVType,
              disabled: false
            }, [  Validators.required ]],
          LastUpdateDate_UTC: [
            {
              value: this.mikeboundaryconditionService.mikeboundaryconditionListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [  Validators.required ]],
          LastUpdateContactTVItemID: [
            {
              value: this.mikeboundaryconditionService.mikeboundaryconditionListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [  Validators.required ]],
        }
      );

      this.mikeboundaryconditionFormEdit = formGroup
    }
  }
}
