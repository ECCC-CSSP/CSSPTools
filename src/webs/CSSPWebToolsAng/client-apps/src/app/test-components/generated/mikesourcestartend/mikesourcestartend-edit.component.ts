/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { MikeSourceStartEndService } from './mikesourcestartend.service';
import { LoadLocalesMikeSourceStartEndText } from './mikesourcestartend.locales';
import { Subscription } from 'rxjs';
import { MikeSourceStartEnd } from '../../../models/generated/MikeSourceStartEnd.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mikesourcestartend-edit',
  templateUrl: './mikesourcestartend-edit.component.html',
  styleUrls: ['./mikesourcestartend-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MikeSourceStartEndEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  mikesourcestartendFormEdit: FormGroup;
  @Input() mikesourcestartend: MikeSourceStartEnd = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public mikesourcestartendService: MikeSourceStartEndService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutMikeSourceStartEnd(mikesourcestartend: MikeSourceStartEnd) {
    this.sub = this.mikesourcestartendService.PutMikeSourceStartEnd(mikesourcestartend).subscribe();
  }

  PostMikeSourceStartEnd(mikesourcestartend: MikeSourceStartEnd) {
    this.sub = this.mikesourcestartendService.PostMikeSourceStartEnd(mikesourcestartend).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesMikeSourceStartEndText(this.mikesourcestartendService);
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.mikesourcestartend) {
      let formGroup: FormGroup = this.fb.group(
        {
          MikeSourceStartEndID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.mikesourcestartend.MikeSourceStartEndID)),
              disabled: false
            }, [Validators.required]],
          MikeSourceID: [
            {
              value: this.mikesourcestartend.MikeSourceID,
              disabled: false
            }, [Validators.required]],
          StartDateAndTime_Local: [
            {
              value: this.mikesourcestartend.StartDateAndTime_Local,
              disabled: false
            }, [Validators.required]],
          EndDateAndTime_Local: [
            {
              value: this.mikesourcestartend.EndDateAndTime_Local,
              disabled: false
            }, [Validators.required]],
          SourceFlowStart_m3_day: [
            {
              value: this.mikesourcestartend.SourceFlowStart_m3_day,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(1000000)]],
          SourceFlowEnd_m3_day: [
            {
              value: this.mikesourcestartend.SourceFlowEnd_m3_day,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(1000000)]],
          SourcePollutionStart_MPN_100ml: [
            {
              value: this.mikesourcestartend.SourcePollutionStart_MPN_100ml,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(10000000)]],
          SourcePollutionEnd_MPN_100ml: [
            {
              value: this.mikesourcestartend.SourcePollutionEnd_MPN_100ml,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(10000000)]],
          SourceTemperatureStart_C: [
            {
              value: this.mikesourcestartend.SourceTemperatureStart_C,
              disabled: false
            }, [Validators.required, Validators.min(-10), Validators.max(40)]],
          SourceTemperatureEnd_C: [
            {
              value: this.mikesourcestartend.SourceTemperatureEnd_C,
              disabled: false
            }, [Validators.required, Validators.min(-10), Validators.max(40)]],
          SourceSalinityStart_PSU: [
            {
              value: this.mikesourcestartend.SourceSalinityStart_PSU,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(40)]],
          SourceSalinityEnd_PSU: [
            {
              value: this.mikesourcestartend.SourceSalinityEnd_PSU,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(40)]],
          LastUpdateDate_UTC: [
            {
              value: this.mikesourcestartend.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.mikesourcestartend.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.mikesourcestartendFormEdit = formGroup
    }
  }
}
