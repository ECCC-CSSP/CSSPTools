/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { RainExceedanceService } from './rainexceedance.service';
import { LoadLocalesRainExceedanceText } from './rainexceedance.locales';
import { Subscription } from 'rxjs';
import { RainExceedance } from '../../../models/generated/RainExceedance.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-rainexceedance-edit',
  templateUrl: './rainexceedance-edit.component.html',
  styleUrls: ['./rainexceedance-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RainExceedanceEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  rainexceedanceFormEdit: FormGroup;
  @Input() rainexceedance: RainExceedance = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public rainexceedanceService: RainExceedanceService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutRainExceedance(rainexceedance: RainExceedance) {
    this.sub = this.rainexceedanceService.PutRainExceedance(rainexceedance).subscribe();
  }

  PostRainExceedance(rainexceedance: RainExceedance) {
    this.sub = this.rainexceedanceService.PostRainExceedance(rainexceedance).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesRainExceedanceText(this.rainexceedanceService);
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.rainexceedance) {
      let formGroup: FormGroup = this.fb.group(
        {
          RainExceedanceID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.rainexceedance.RainExceedanceID)),
              disabled: false
            }, [Validators.required]],
          RainExceedanceTVItemID: [
            {
              value: this.rainexceedance.RainExceedanceTVItemID,
              disabled: false
            }, [Validators.required]],
          StartMonth: [
            {
              value: this.rainexceedance.StartMonth,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(12)]],
          StartDay: [
            {
              value: this.rainexceedance.StartDay,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(31)]],
          EndMonth: [
            {
              value: this.rainexceedance.EndMonth,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(12)]],
          EndDay: [
            {
              value: this.rainexceedance.EndDay,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(31)]],
          RainMaximum_mm: [
            {
              value: this.rainexceedance.RainMaximum_mm,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(300)]],
          StakeholdersEmailDistributionListID: [
            {
              value: this.rainexceedance.StakeholdersEmailDistributionListID,
              disabled: false
            }],
          OnlyStaffEmailDistributionListID: [
            {
              value: this.rainexceedance.OnlyStaffEmailDistributionListID,
              disabled: false
            }],
          IsActive: [
            {
              value: this.rainexceedance.IsActive,
              disabled: false
            }, [Validators.required]],
          LastUpdateDate_UTC: [
            {
              value: this.rainexceedance.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.rainexceedance.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.rainexceedanceFormEdit = formGroup
    }
  }
}
