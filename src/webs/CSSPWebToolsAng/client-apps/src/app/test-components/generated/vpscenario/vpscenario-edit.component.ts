/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { VPScenarioService } from './vpscenario.service';
import { LoadLocalesVPScenarioText } from './vpscenario.locales';
import { Subscription } from 'rxjs';
import { ScenarioStatusEnum_GetOrderedText } from '../../../enums/generated/ScenarioStatusEnum';
import { VPScenario } from '../../../models/generated/VPScenario.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-vpscenario-edit',
  templateUrl: './vpscenario-edit.component.html',
  styleUrls: ['./vpscenario-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class VPScenarioEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  vPScenarioStatusList: EnumIDAndText[];
  vpscenarioFormEdit: FormGroup;
  @Input() vpscenario: VPScenario = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public vpscenarioService: VPScenarioService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutVPScenario(vpscenario: VPScenario) {
    this.sub = this.vpscenarioService.PutVPScenario(vpscenario).subscribe();
  }

  PostVPScenario(vpscenario: VPScenario) {
    this.sub = this.vpscenarioService.PostVPScenario(vpscenario).subscribe();
  }

  ngOnInit(): void {
    this.vPScenarioStatusList = ScenarioStatusEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.vpscenario) {
      let formGroup: FormGroup = this.fb.group(
        {
          VPScenarioID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.vpscenario.VPScenarioID)),
              disabled: false
            }, [Validators.required]],
          InfrastructureTVItemID: [
            {
              value: this.vpscenario.InfrastructureTVItemID,
              disabled: false
            }, [Validators.required]],
          VPScenarioStatus: [
            {
              value: this.vpscenario.VPScenarioStatus,
              disabled: false
            }, [Validators.required]],
          UseAsBestEstimate: [
            {
              value: this.vpscenario.UseAsBestEstimate,
              disabled: false
            }, [Validators.required]],
          EffluentFlow_m3_s: [
            {
              value: this.vpscenario.EffluentFlow_m3_s,
              disabled: false
            }, [Validators.min(0), Validators.max(1000)]],
          EffluentConcentration_MPN_100ml: [
            {
              value: this.vpscenario.EffluentConcentration_MPN_100ml,
              disabled: false
            }, [Validators.min(0), Validators.max(10000000)]],
          FroudeNumber: [
            {
              value: this.vpscenario.FroudeNumber,
              disabled: false
            }, [Validators.min(0), Validators.max(10000)]],
          PortDiameter_m: [
            {
              value: this.vpscenario.PortDiameter_m,
              disabled: false
            }, [Validators.min(0), Validators.max(10)]],
          PortDepth_m: [
            {
              value: this.vpscenario.PortDepth_m,
              disabled: false
            }, [Validators.min(0), Validators.max(1000)]],
          PortElevation_m: [
            {
              value: this.vpscenario.PortElevation_m,
              disabled: false
            }, [Validators.min(0), Validators.max(1000)]],
          VerticalAngle_deg: [
            {
              value: this.vpscenario.VerticalAngle_deg,
              disabled: false
            }, [Validators.min(-90), Validators.max(90)]],
          HorizontalAngle_deg: [
            {
              value: this.vpscenario.HorizontalAngle_deg,
              disabled: false
            }, [Validators.min(-180), Validators.max(180)]],
          NumberOfPorts: [
            {
              value: this.vpscenario.NumberOfPorts,
              disabled: false
            }, [Validators.min(1), Validators.max(100)]],
          PortSpacing_m: [
            {
              value: this.vpscenario.PortSpacing_m,
              disabled: false
            }, [Validators.min(0), Validators.max(1000)]],
          AcuteMixZone_m: [
            {
              value: this.vpscenario.AcuteMixZone_m,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          ChronicMixZone_m: [
            {
              value: this.vpscenario.ChronicMixZone_m,
              disabled: false
            }, [Validators.min(0), Validators.max(40000)]],
          EffluentSalinity_PSU: [
            {
              value: this.vpscenario.EffluentSalinity_PSU,
              disabled: false
            }, [Validators.min(0), Validators.max(40)]],
          EffluentTemperature_C: [
            {
              value: this.vpscenario.EffluentTemperature_C,
              disabled: false
            }, [Validators.min(-10), Validators.max(40)]],
          EffluentVelocity_m_s: [
            {
              value: this.vpscenario.EffluentVelocity_m_s,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          RawResults: [
            {
              value: this.vpscenario.RawResults,
              disabled: false
            }],
          LastUpdateDate_UTC: [
            {
              value: this.vpscenario.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.vpscenario.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.vpscenarioFormEdit = formGroup
    }
  }
}
