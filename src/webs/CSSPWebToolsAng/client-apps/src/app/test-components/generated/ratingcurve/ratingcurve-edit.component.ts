/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { RatingCurveService } from './ratingcurve.service';
import { LoadLocalesRatingCurveText } from './ratingcurve.locales';
import { Subscription } from 'rxjs';
import { RatingCurve } from '../../../models/generated/RatingCurve.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-ratingcurve-edit',
  templateUrl: './ratingcurve-edit.component.html',
  styleUrls: ['./ratingcurve-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RatingCurveEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  ratingcurveFormEdit: FormGroup;
  @Input() ratingcurve: RatingCurve = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public ratingcurveService: RatingCurveService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutRatingCurve(ratingcurve: RatingCurve) {
    this.sub = this.ratingcurveService.PutRatingCurve(ratingcurve).subscribe();
  }

  PostRatingCurve(ratingcurve: RatingCurve) {
    this.sub = this.ratingcurveService.PostRatingCurve(ratingcurve).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.ratingcurve) {
      let formGroup: FormGroup = this.fb.group(
        {
          RatingCurveID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.ratingcurve.RatingCurveID)),
              disabled: false
            }, [Validators.required]],
          HydrometricSiteID: [
            {
              value: this.ratingcurve.HydrometricSiteID,
              disabled: false
            }, [Validators.required]],
          RatingCurveNumber: [
            {
              value: this.ratingcurve.RatingCurveNumber,
              disabled: false
            }, [Validators.required, Validators.maxLength(50)]],
          LastUpdateDate_UTC: [
            {
              value: this.ratingcurve.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.ratingcurve.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.ratingcurveFormEdit = formGroup
    }
  }
}
