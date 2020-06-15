/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { RatingCurveValueService } from './ratingcurvevalue.service';
import { LoadLocalesRatingCurveValueText } from './ratingcurvevalue.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { RatingCurveValue } from '../../../models/generated/RatingCurveValue.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-ratingcurvevalue',
  templateUrl: './ratingcurvevalue.component.html',
  styleUrls: ['./ratingcurvevalue.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RatingCurveValueComponent implements OnInit, OnDestroy {
  sub: Subscription;
  ratingcurvevalueFormPut: FormGroup;
  ratingcurvevalueFormPost: FormGroup;

  constructor(public ratingcurvevalueService: RatingCurveValueService, public router: Router, public fb: FormBuilder) { }

  GetRatingCurveValueList() {
    this.sub = this.ratingcurvevalueService.GetRatingCurveValueList(this.router).subscribe();
  }

  PutRatingCurveValue(ratingcurvevalue: RatingCurveValue) {
    this.sub = this.ratingcurvevalueService.PutRatingCurveValue(ratingcurvevalue, this.router).subscribe();
  }

  PostRatingCurveValue(ratingcurvevalue: RatingCurveValue) {
    this.sub = this.ratingcurvevalueService.PostRatingCurveValue(ratingcurvevalue, this.router).subscribe();
  }

  DeleteRatingCurveValue(ratingcurvevalue: RatingCurveValue) {
    this.sub = this.ratingcurvevalueService.DeleteRatingCurveValue(ratingcurvevalue, this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesRatingCurveValueText(this.ratingcurvevalueService);
    this.FillFormBuilderGroup('Add');
    this.FillFormBuilderGroup('Update');
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(AddOrUpdate: string) {
    if (this.ratingcurvevalueService.ratingcurvevalueList.length) {
      let formGroup: FormGroup = this.fb.group(
        {
          RatingCurveValueID: [
            {
              value: (AddOrUpdate === 'Add' ? 0 : (this.ratingcurvevalueService.ratingcurvevalueList[0]?.RatingCurveValueID)),
              disabled: false
            }],
          RatingCurveID: [
            {
              value: this.ratingcurvevalueService.ratingcurvevalueList[0]?.RatingCurveID,
              disabled: false
            }],
          StageValue_m: [
            {
              value: this.ratingcurvevalueService.ratingcurvevalueList[0]?.StageValue_m,
              disabled: false
            }],
          DischargeValue_m3_s: [
            {
              value: this.ratingcurvevalueService.ratingcurvevalueList[0]?.DischargeValue_m3_s,
              disabled: false
            }],
          LastUpdateDate_UTC: [
            {
              value: this.ratingcurvevalueService.ratingcurvevalueList[0]?.LastUpdateDate_UTC,
              disabled: false
            }],
          LastUpdateContactTVItemID: [
            {
              value: this.ratingcurvevalueService.ratingcurvevalueList[0]?.LastUpdateContactTVItemID,
              disabled: false
            }],
        }
      );

      if (AddOrUpdate === 'Add') {
        this.ratingcurvevalueFormPost = formGroup
      }
      else {
        this.ratingcurvevalueFormPut = formGroup;
      }
    }
  }
}
