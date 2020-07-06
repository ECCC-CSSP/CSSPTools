/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { RatingCurveValueService } from './ratingcurvevalue.service';
import { LoadLocalesRatingCurveValueText } from './ratingcurvevalue.locales';
import { Subscription } from 'rxjs';
import { RatingCurveValue } from '../../../models/generated/RatingCurveValue.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-ratingcurvevalue-edit',
  templateUrl: './ratingcurvevalue-edit.component.html',
  styleUrls: ['./ratingcurvevalue-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RatingCurveValueEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  ratingcurvevalueFormEdit: FormGroup;
  @Input() ratingcurvevalue: RatingCurveValue = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public ratingcurvevalueService: RatingCurveValueService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutRatingCurveValue(ratingcurvevalue: RatingCurveValue) {
    this.sub = this.ratingcurvevalueService.PutRatingCurveValue(ratingcurvevalue).subscribe();
  }

  PostRatingCurveValue(ratingcurvevalue: RatingCurveValue) {
    this.sub = this.ratingcurvevalueService.PostRatingCurveValue(ratingcurvevalue).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.ratingcurvevalue) {
      let formGroup: FormGroup = this.fb.group(
        {
          RatingCurveValueID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.ratingcurvevalue.RatingCurveValueID)),
              disabled: false
            }, [Validators.required]],
          RatingCurveID: [
            {
              value: this.ratingcurvevalue.RatingCurveID,
              disabled: false
            }, [Validators.required]],
          StageValue_m: [
            {
              value: this.ratingcurvevalue.StageValue_m,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(1000)]],
          DischargeValue_m3_s: [
            {
              value: this.ratingcurvevalue.DischargeValue_m3_s,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(1000000)]],
          LastUpdateDate_UTC: [
            {
              value: this.ratingcurvevalue.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.ratingcurvevalue.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.ratingcurvevalueFormEdit = formGroup
    }
  }
}
