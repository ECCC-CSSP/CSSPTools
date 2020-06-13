/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { AppErrLogService } from './apperrlog.service';
import { LoadLocalesAppErrLogText } from './apperrlog.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AppErrLog } from '../../../models/generated/AppErrLog.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-apperrlog',
  templateUrl: './apperrlog.component.html',
  styleUrls: ['./apperrlog.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppErrLogComponent implements OnInit, OnDestroy {
  sub: Subscription;
  apperrlogFormPut: FormGroup;
  apperrlogFormPost: FormGroup;

  constructor(public apperrlogService: AppErrLogService, public router: Router, public fb: FormBuilder) { }

  GetAppErrLogList() {
    this.sub = this.apperrlogService.GetAppErrLogList(this.router).subscribe();
  }

  PutAppErrLog(apperrlog: AppErrLog) {
    this.sub = this.apperrlogService.PutAppErrLog(apperrlog, this.router).subscribe();
  }

  PostAppErrLog(apperrlog: AppErrLog) {
    this.sub = this.apperrlogService.PostAppErrLog(apperrlog, this.router).subscribe();
  }

  DeleteAppErrLog(apperrlog: AppErrLog) {
    this.sub = this.apperrlogService.DeleteAppErrLog(apperrlog, this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesAppErrLogText(this.apperrlogService);
    this.FillFormBuilderGroup('Add');
    this.FillFormBuilderGroup('Update');
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(AddOrUpdate: string) {
    if (this.apperrlogService.apperrlogList.length) {
      let formGroup: FormGroup = this.fb.group(
        {
          AppErrLogID: [
            {
              value: (AddOrUpdate === 'Add' ? 0 : (this.apperrlogService.apperrlogList[0]?.AppErrLogID ?? '')),
              disabled: false
            }, Validators.required],
          Tag: [
            {
              value: this.apperrlogService.apperrlogList[0]?.Tag ?? '',
              disabled: false
            }, Validators.required],
          LineNumber: [
            {
              value: this.apperrlogService.apperrlogList[0]?.LineNumber ?? '',
              disabled: false
            }, Validators.required],
          Source: [
            {
              value: this.apperrlogService.apperrlogList[0]?.Source ?? '',
              disabled: false
            }, Validators.required],
          Message: [
            {
              value: this.apperrlogService.apperrlogList[0]?.Message ?? '',
              disabled: false
            }, Validators.required],
          DateTime_UTC: [
            {
              value: this.apperrlogService.apperrlogList[0]?.DateTime_UTC ?? '',
              disabled: false
            }, Validators.required],
          LastUpdateDate_UTC: [
            {
              value: this.apperrlogService.apperrlogList[0]?.LastUpdateDate_UTC ?? '',
              disabled: false
            }, Validators.required],
          LastUpdateContactTVItemID: [
            {
              value: this.apperrlogService.apperrlogList[0]?.LastUpdateContactTVItemID ?? '',
              disabled: false
            }, Validators.required],
        }
      );

      if (AddOrUpdate === 'Add') {
        this.apperrlogFormPost = formGroup
      }
      else {
        this.apperrlogFormPut = formGroup;
      }
    }
  }
}
