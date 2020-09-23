/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { AppTaskService } from './apptask.service';
import { LoadLocalesAppTaskText } from './apptask.locales';
import { Subscription } from 'rxjs';
import { AppTaskCommandEnum_GetOrderedText } from '../../../enums/generated/AppTaskCommandEnum';
import { AppTaskStatusEnum_GetOrderedText } from '../../../enums/generated/AppTaskStatusEnum';
import { LanguageEnum_GetOrderedText } from '../../../enums/generated/LanguageEnum';
import { AppTask } from '../../../models/generated/AppTask.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enum-idandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-apptask-edit',
  templateUrl: './apptask-edit.component.html',
  styleUrls: ['./apptask-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppTaskEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  appTaskCommandList: EnumIDAndText[];
  appTaskStatusList: EnumIDAndText[];
  languageList: EnumIDAndText[];
  apptaskFormEdit: FormGroup;
  @Input() apptask: AppTask = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public apptaskService: AppTaskService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutAppTask(apptask: AppTask) {
    this.sub = this.apptaskService.PutAppTask(apptask).subscribe();
  }

  PostAppTask(apptask: AppTask) {
    this.sub = this.apptaskService.PostAppTask(apptask).subscribe();
  }

  ngOnInit(): void {
    this.appTaskCommandList = AppTaskCommandEnum_GetOrderedText();
    this.appTaskStatusList = AppTaskStatusEnum_GetOrderedText();
    this.languageList = LanguageEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.apptask) {
      let formGroup: FormGroup = this.fb.group(
        {
          AppTaskID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.apptask.AppTaskID)),
              disabled: false
            }, [Validators.required]],
          TVItemID: [
            {
              value: this.apptask.TVItemID,
              disabled: false
            }, [Validators.required]],
          TVItemID2: [
            {
              value: this.apptask.TVItemID2,
              disabled: false
            }, [Validators.required]],
          AppTaskCommand: [
            {
              value: this.apptask.AppTaskCommand,
              disabled: false
            }, [Validators.required]],
          AppTaskStatus: [
            {
              value: this.apptask.AppTaskStatus,
              disabled: false
            }, [Validators.required]],
          PercentCompleted: [
            {
              value: this.apptask.PercentCompleted,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(100)]],
          Parameters: [
            {
              value: this.apptask.Parameters,
              disabled: false
            }, [Validators.required]],
          Language: [
            {
              value: this.apptask.Language,
              disabled: false
            }, [Validators.required]],
          StartDateTime_UTC: [
            {
              value: this.apptask.StartDateTime_UTC,
              disabled: false
            }, [Validators.required]],
          EndDateTime_UTC: [
            {
              value: this.apptask.EndDateTime_UTC,
              disabled: false
            }],
          EstimatedLength_second: [
            {
              value: this.apptask.EstimatedLength_second,
              disabled: false
            }, [Validators.min(0), Validators.max(1000000)]],
          RemainingTime_second: [
            {
              value: this.apptask.RemainingTime_second,
              disabled: false
            }, [Validators.min(0), Validators.max(1000000)]],
          LastUpdateDate_UTC: [
            {
              value: this.apptask.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.apptask.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.apptaskFormEdit = formGroup
    }
  }
}
