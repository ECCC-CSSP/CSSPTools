/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { MikeBoundaryConditionService } from './mikeboundarycondition.service';
import { LoadLocalesMikeBoundaryConditionText } from './mikeboundarycondition.locales';
import { Subscription } from 'rxjs';
import { MikeBoundaryConditionLevelOrVelocityEnum_GetIDText, MikeBoundaryConditionLevelOrVelocityEnum_GetOrderedText } from '../../../enums/generated/MikeBoundaryConditionLevelOrVelocityEnum';
import { WebTideDataSetEnum_GetIDText, WebTideDataSetEnum_GetOrderedText } from '../../../enums/generated/WebTideDataSetEnum';
import { TVTypeEnum_GetIDText, TVTypeEnum_GetOrderedText } from '../../../enums/generated/TVTypeEnum';
import { MikeBoundaryCondition } from '../../../models/generated/MikeBoundaryCondition.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mikeboundarycondition',
  templateUrl: './mikeboundarycondition.component.html',
  styleUrls: ['./mikeboundarycondition.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MikeBoundaryConditionComponent implements OnInit, OnDestroy {
  sub: Subscription;
  mikeBoundaryConditionLevelOrVelocityList: EnumIDAndText[];
  webTideDataSetList: EnumIDAndText[];
  tVTypeList: EnumIDAndText[];
  mikeboundaryconditionFormPut: FormGroup;
  mikeboundaryconditionFormPost: FormGroup;

  constructor(public mikeboundaryconditionService: MikeBoundaryConditionService, private router: Router, private httpClientService: HttpClientService, private fb: FormBuilder) {
    httpClientService.oldURL = router.url;
  }

  GetMikeBoundaryConditionList() {
    this.sub = this.mikeboundaryconditionService.GetMikeBoundaryConditionList().subscribe();
  }

  PutMikeBoundaryCondition(mikeboundarycondition: MikeBoundaryCondition) {
    this.sub = this.mikeboundaryconditionService.PutMikeBoundaryCondition(mikeboundarycondition).subscribe();
  }

  PostMikeBoundaryCondition(mikeboundarycondition: MikeBoundaryCondition) {
    this.sub = this.mikeboundaryconditionService.PostMikeBoundaryCondition(mikeboundarycondition).subscribe();
  }

  DeleteMikeBoundaryCondition(mikeboundarycondition: MikeBoundaryCondition) {
    this.sub = this.mikeboundaryconditionService.DeleteMikeBoundaryCondition(mikeboundarycondition).subscribe();
  }

  GetMikeBoundaryConditionLevelOrVelocityEnumText(enumID: number) {
    return MikeBoundaryConditionLevelOrVelocityEnum_GetIDText(enumID)
  }

  GetWebTideDataSetEnumText(enumID: number) {
    return WebTideDataSetEnum_GetIDText(enumID)
  }

  GetTVTypeEnumText(enumID: number) {
    return TVTypeEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesMikeBoundaryConditionText(this.mikeboundaryconditionService);
    this.mikeBoundaryConditionLevelOrVelocityList = MikeBoundaryConditionLevelOrVelocityEnum_GetOrderedText();
    this.webTideDataSetList = WebTideDataSetEnum_GetOrderedText();
    this.tVTypeList = TVTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup(HttpClientCommand.Post);
    this.FillFormBuilderGroup(HttpClientCommand.Put);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.mikeboundaryconditionService.mikeboundaryconditionListModel$.getValue().length) {
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

      if (httpClientCommand === HttpClientCommand.Post) {
        this.mikeboundaryconditionFormPost = formGroup
      }
      else {
        this.mikeboundaryconditionFormPut = formGroup;
      }
    }
  }
}
