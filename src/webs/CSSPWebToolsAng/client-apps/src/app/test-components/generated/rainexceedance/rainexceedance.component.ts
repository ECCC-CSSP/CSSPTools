/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { RainExceedanceService } from './rainexceedance.service';
import { LoadLocalesRainExceedanceText } from './rainexceedance.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { RainExceedance } from '../../../models/generated/RainExceedance.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-rainexceedance',
  templateUrl: './rainexceedance.component.html',
  styleUrls: ['./rainexceedance.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RainExceedanceComponent implements OnInit, OnDestroy {
  sub: Subscription;
  rainexceedanceFormPut: FormGroup;
  rainexceedanceFormPost: FormGroup;

  constructor(public rainexceedanceService: RainExceedanceService, public router: Router, public fb: FormBuilder) { }

  GetRainExceedanceList() {
    this.sub = this.rainexceedanceService.GetRainExceedanceList(this.router).subscribe();
  }

  PutRainExceedance(rainexceedance: RainExceedance) {
    this.sub = this.rainexceedanceService.PutRainExceedance(rainexceedance, this.router).subscribe();
  }

  PostRainExceedance(rainexceedance: RainExceedance) {
    this.sub = this.rainexceedanceService.PostRainExceedance(rainexceedance, this.router).subscribe();
  }

  DeleteRainExceedance(rainexceedance: RainExceedance) {
    this.sub = this.rainexceedanceService.DeleteRainExceedance(rainexceedance, this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesRainExceedanceText(this.rainexceedanceService);
    this.FillFormBuilderGroup('Add');
    this.FillFormBuilderGroup('Update');
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(AddOrUpdate: string) {
    if (this.rainexceedanceService.rainexceedanceList.length) {
      let formGroup: FormGroup = this.fb.group(
        {
          RainExceedanceID: [
            {
              value: (AddOrUpdate === 'Add' ? 0 : (this.rainexceedanceService.rainexceedanceList[0]?.RainExceedanceID)),
              disabled: false
            }, [ Validators.required ]],
          RainExceedanceTVItemID: [
            {
              value: this.rainexceedanceService.rainexceedanceList[0]?.RainExceedanceTVItemID,
              disabled: false
            }, [ Validators.required ]],
          StartMonth: [
            {
              value: this.rainexceedanceService.rainexceedanceList[0]?.StartMonth,
              disabled: false
            }, [ Validators.required ]],
          StartDay: [
            {
              value: this.rainexceedanceService.rainexceedanceList[0]?.StartDay,
              disabled: false
            }, [ Validators.required ]],
          EndMonth: [
            {
              value: this.rainexceedanceService.rainexceedanceList[0]?.EndMonth,
              disabled: false
            }, [ Validators.required ]],
          EndDay: [
            {
              value: this.rainexceedanceService.rainexceedanceList[0]?.EndDay,
              disabled: false
            }, [ Validators.required ]],
          RainMaximum_mm: [
            {
              value: this.rainexceedanceService.rainexceedanceList[0]?.RainMaximum_mm,
              disabled: false
            }, [ Validators.required ]],
          StakeholdersEmailDistributionListID: [
            {
              value: this.rainexceedanceService.rainexceedanceList[0]?.StakeholdersEmailDistributionListID,
              disabled: false
            }, [ Validators.required ]],
          OnlyStaffEmailDistributionListID: [
            {
              value: this.rainexceedanceService.rainexceedanceList[0]?.OnlyStaffEmailDistributionListID,
              disabled: false
            }, [ Validators.required ]],
          IsActive: [
            {
              value: this.rainexceedanceService.rainexceedanceList[0]?.IsActive,
              disabled: false
            }, [ Validators.required ]],
          LastUpdateDate_UTC: [
            {
              value: this.rainexceedanceService.rainexceedanceList[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [ Validators.required ]],
          LastUpdateContactTVItemID: [
            {
              value: this.rainexceedanceService.rainexceedanceList[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [ Validators.required ]],
        }
      );

      if (AddOrUpdate === 'Add') {
        this.rainexceedanceFormPost = formGroup
      }
      else {
        this.rainexceedanceFormPut = formGroup;
      }
    }
  }
}
