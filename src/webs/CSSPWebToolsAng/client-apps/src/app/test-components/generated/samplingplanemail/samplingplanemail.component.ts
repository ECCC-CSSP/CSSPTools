/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { SamplingPlanEmailService } from './samplingplanemail.service';
import { LoadLocalesSamplingPlanEmailText } from './samplingplanemail.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { SamplingPlanEmail } from '../../../models/generated/SamplingPlanEmail.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-samplingplanemail',
  templateUrl: './samplingplanemail.component.html',
  styleUrls: ['./samplingplanemail.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SamplingPlanEmailComponent implements OnInit, OnDestroy {
  sub: Subscription;
  samplingplanemailFormPut: FormGroup;
  samplingplanemailFormPost: FormGroup;

  constructor(public samplingplanemailService: SamplingPlanEmailService, public router: Router, public fb: FormBuilder) { }

  GetSamplingPlanEmailList() {
    this.sub = this.samplingplanemailService.GetSamplingPlanEmailList(this.router).subscribe();
  }

  PutSamplingPlanEmail(samplingplanemail: SamplingPlanEmail) {
    this.sub = this.samplingplanemailService.PutSamplingPlanEmail(samplingplanemail, this.router).subscribe();
  }

  PostSamplingPlanEmail(samplingplanemail: SamplingPlanEmail) {
    this.sub = this.samplingplanemailService.PostSamplingPlanEmail(samplingplanemail, this.router).subscribe();
  }

  DeleteSamplingPlanEmail(samplingplanemail: SamplingPlanEmail) {
    this.sub = this.samplingplanemailService.DeleteSamplingPlanEmail(samplingplanemail, this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesSamplingPlanEmailText(this.samplingplanemailService);
    this.FillFormBuilderGroup('Add');
    this.FillFormBuilderGroup('Update');
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(AddOrUpdate: string) {
    if (this.samplingplanemailService.samplingplanemailList.length) {
      let formGroup: FormGroup = this.fb.group(
        {
          SamplingPlanEmailID: [
            {
              value: (AddOrUpdate === 'Add' ? 0 : (this.samplingplanemailService.samplingplanemailList[0]?.SamplingPlanEmailID ?? '')),
              disabled: false
            }, Validators.required],
          SamplingPlanID: [
            {
              value: this.samplingplanemailService.samplingplanemailList[0]?.SamplingPlanID ?? '',
              disabled: false
            }, Validators.required],
          Email: [
            {
              value: this.samplingplanemailService.samplingplanemailList[0]?.Email ?? '',
              disabled: false
            }, Validators.required],
          IsContractor: [
            {
              value: this.samplingplanemailService.samplingplanemailList[0]?.IsContractor ?? '',
              disabled: false
            }, Validators.required],
          LabSheetHasValueOver500: [
            {
              value: this.samplingplanemailService.samplingplanemailList[0]?.LabSheetHasValueOver500 ?? '',
              disabled: false
            }, Validators.required],
          LabSheetReceived: [
            {
              value: this.samplingplanemailService.samplingplanemailList[0]?.LabSheetReceived ?? '',
              disabled: false
            }, Validators.required],
          LabSheetAccepted: [
            {
              value: this.samplingplanemailService.samplingplanemailList[0]?.LabSheetAccepted ?? '',
              disabled: false
            }, Validators.required],
          LabSheetRejected: [
            {
              value: this.samplingplanemailService.samplingplanemailList[0]?.LabSheetRejected ?? '',
              disabled: false
            }, Validators.required],
          LastUpdateDate_UTC: [
            {
              value: this.samplingplanemailService.samplingplanemailList[0]?.LastUpdateDate_UTC ?? '',
              disabled: false
            }, Validators.required],
          LastUpdateContactTVItemID: [
            {
              value: this.samplingplanemailService.samplingplanemailList[0]?.LastUpdateContactTVItemID ?? '',
              disabled: false
            }, Validators.required],
        }
      );

      if (AddOrUpdate === 'Add') {
        this.samplingplanemailFormPost = formGroup
      }
      else {
        this.samplingplanemailFormPut = formGroup;
      }
    }
  }
}
