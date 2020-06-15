/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { ClassificationService } from './classification.service';
import { LoadLocalesClassificationText } from './classification.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ClassificationTypeEnum_GetIDText, ClassificationTypeEnum_GetOrderedText } from '../../../enums/generated/ClassificationTypeEnum';
import { Classification } from '../../../models/generated/Classification.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';

@Component({
  selector: 'app-classification',
  templateUrl: './classification.component.html',
  styleUrls: ['./classification.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ClassificationComponent implements OnInit, OnDestroy {
  sub: Subscription;
  classificationTypeList: EnumIDAndText[];
  classificationFormPut: FormGroup;
  classificationFormPost: FormGroup;

  constructor(public classificationService: ClassificationService, public router: Router, public fb: FormBuilder) { }

  GetClassificationList() {
    this.sub = this.classificationService.GetClassificationList(this.router).subscribe();
  }

  PutClassification(classification: Classification) {
    this.sub = this.classificationService.PutClassification(classification, this.router).subscribe();
  }

  PostClassification(classification: Classification) {
    this.sub = this.classificationService.PostClassification(classification, this.router).subscribe();
  }

  DeleteClassification(classification: Classification) {
    this.sub = this.classificationService.DeleteClassification(classification, this.router).subscribe();
  }

  GetClassificationTypeEnumText(enumID: number) {
    return ClassificationTypeEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesClassificationText(this.classificationService);
    this.classificationTypeList = ClassificationTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup('Add');
    this.FillFormBuilderGroup('Update');
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(AddOrUpdate: string) {
    if (this.classificationService.classificationList.length) {
      let formGroup: FormGroup = this.fb.group(
        {
          ClassificationID: [
            {
              value: (AddOrUpdate === 'Add' ? 0 : (this.classificationService.classificationList[0]?.ClassificationID)),
              disabled: false
            }],
          ClassificationTVItemID: [
            {
              value: this.classificationService.classificationList[0]?.ClassificationTVItemID,
              disabled: false
            }],
          ClassificationType: [
            {
              value: this.classificationService.classificationList[0]?.ClassificationType,
              disabled: false
            }],
          Ordinal: [
            {
              value: this.classificationService.classificationList[0]?.Ordinal,
              disabled: false
            }],
          LastUpdateDate_UTC: [
            {
              value: this.classificationService.classificationList[0]?.LastUpdateDate_UTC,
              disabled: false
            }],
          LastUpdateContactTVItemID: [
            {
              value: this.classificationService.classificationList[0]?.LastUpdateContactTVItemID,
              disabled: false
            }],
        }
      );

      if (AddOrUpdate === 'Add') {
        this.classificationFormPost = formGroup
      }
      else {
        this.classificationFormPut = formGroup;
      }
    }
  }
}
