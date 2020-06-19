/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { SamplingPlanSubsectorSiteService } from './samplingplansubsectorsite.service';
import { LoadLocalesSamplingPlanSubsectorSiteText } from './samplingplansubsectorsite.locales';
import { Subscription } from 'rxjs';
import { SamplingPlanSubsectorSite } from '../../../models/generated/SamplingPlanSubsectorSite.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-samplingplansubsectorsite-edit',
  templateUrl: './samplingplansubsectorsite-edit.component.html',
  styleUrls: ['./samplingplansubsectorsite-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SamplingPlanSubsectorSiteEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  samplingplansubsectorsiteFormEdit: FormGroup;
  @Input() samplingplansubsectorsite: SamplingPlanSubsectorSite = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public samplingplansubsectorsiteService: SamplingPlanSubsectorSiteService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutSamplingPlanSubsectorSite(samplingplansubsectorsite: SamplingPlanSubsectorSite) {
    this.sub = this.samplingplansubsectorsiteService.PutSamplingPlanSubsectorSite(samplingplansubsectorsite).subscribe();
  }

  PostSamplingPlanSubsectorSite(samplingplansubsectorsite: SamplingPlanSubsectorSite) {
    this.sub = this.samplingplansubsectorsiteService.PostSamplingPlanSubsectorSite(samplingplansubsectorsite).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesSamplingPlanSubsectorSiteText(this.samplingplansubsectorsiteService);
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.samplingplansubsectorsite) {
      let formGroup: FormGroup = this.fb.group(
        {
          SamplingPlanSubsectorSiteID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.samplingplansubsectorsite.SamplingPlanSubsectorSiteID)),
              disabled: false
            }, [Validators.required]],
          SamplingPlanSubsectorID: [
            {
              value: this.samplingplansubsectorsite.SamplingPlanSubsectorID,
              disabled: false
            }, [Validators.required]],
          MWQMSiteTVItemID: [
            {
              value: this.samplingplansubsectorsite.MWQMSiteTVItemID,
              disabled: false
            }, [Validators.required]],
          IsDuplicate: [
            {
              value: this.samplingplansubsectorsite.IsDuplicate,
              disabled: false
            }, [Validators.required]],
          LastUpdateDate_UTC: [
            {
              value: this.samplingplansubsectorsite.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.samplingplansubsectorsite.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.samplingplansubsectorsiteFormEdit = formGroup
    }
  }
}
