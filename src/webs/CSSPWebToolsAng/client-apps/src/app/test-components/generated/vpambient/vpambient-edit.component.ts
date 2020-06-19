/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { VPAmbientService } from './vpambient.service';
import { LoadLocalesVPAmbientText } from './vpambient.locales';
import { Subscription } from 'rxjs';
import { VPAmbient } from '../../../models/generated/VPAmbient.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-vpambient-edit',
  templateUrl: './vpambient-edit.component.html',
  styleUrls: ['./vpambient-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class VPAmbientEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  vpambientFormEdit: FormGroup;
  @Input() vpambient: VPAmbient = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public vpambientService: VPAmbientService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutVPAmbient(vpambient: VPAmbient) {
    this.sub = this.vpambientService.PutVPAmbient(vpambient).subscribe();
  }

  PostVPAmbient(vpambient: VPAmbient) {
    this.sub = this.vpambientService.PostVPAmbient(vpambient).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesVPAmbientText(this.vpambientService);
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.vpambient) {
      let formGroup: FormGroup = this.fb.group(
        {
          VPAmbientID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.vpambientService.vpambientListModel$.getValue()[0]?.VPAmbientID)),
              disabled: false
            }, [Validators.required]],
          VPScenarioID: [
            {
              value: this.vpambientService.vpambientListModel$.getValue()[0]?.VPScenarioID,
              disabled: false
            }, [Validators.required]],
          Row: [
            {
              value: this.vpambientService.vpambientListModel$.getValue()[0]?.Row,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(10)]],
          MeasurementDepth_m: [
            {
              value: this.vpambientService.vpambientListModel$.getValue()[0]?.MeasurementDepth_m,
              disabled: false
            }, [Validators.min(0), Validators.max(1000)]],
          CurrentSpeed_m_s: [
            {
              value: this.vpambientService.vpambientListModel$.getValue()[0]?.CurrentSpeed_m_s,
              disabled: false
            }, [Validators.min(0), Validators.max(10)]],
          CurrentDirection_deg: [
            {
              value: this.vpambientService.vpambientListModel$.getValue()[0]?.CurrentDirection_deg,
              disabled: false
            }, [Validators.min(-180), Validators.max(180)]],
          AmbientSalinity_PSU: [
            {
              value: this.vpambientService.vpambientListModel$.getValue()[0]?.AmbientSalinity_PSU,
              disabled: false
            }, [Validators.min(0), Validators.max(40)]],
          AmbientTemperature_C: [
            {
              value: this.vpambientService.vpambientListModel$.getValue()[0]?.AmbientTemperature_C,
              disabled: false
            }, [Validators.min(-10), Validators.max(40)]],
          BackgroundConcentration_MPN_100ml: [
            {
              value: this.vpambientService.vpambientListModel$.getValue()[0]?.BackgroundConcentration_MPN_100ml,
              disabled: false
            }, [Validators.min(0), Validators.max(10000000)]],
          PollutantDecayRate_per_day: [
            {
              value: this.vpambientService.vpambientListModel$.getValue()[0]?.PollutantDecayRate_per_day,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          FarFieldCurrentSpeed_m_s: [
            {
              value: this.vpambientService.vpambientListModel$.getValue()[0]?.FarFieldCurrentSpeed_m_s,
              disabled: false
            }, [Validators.min(0), Validators.max(10)]],
          FarFieldCurrentDirection_deg: [
            {
              value: this.vpambientService.vpambientListModel$.getValue()[0]?.FarFieldCurrentDirection_deg,
              disabled: false
            }, [Validators.min(-180), Validators.max(180)]],
          FarFieldDiffusionCoefficient: [
            {
              value: this.vpambientService.vpambientListModel$.getValue()[0]?.FarFieldDiffusionCoefficient,
              disabled: false
            }, [Validators.min(0), Validators.max(1)]],
          LastUpdateDate_UTC: [
            {
              value: this.vpambientService.vpambientListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.vpambientService.vpambientListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.vpambientFormEdit = formGroup
    }
  }
}
