/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { MikeScenarioService } from './mikescenario.service';
import { LoadLocalesMikeScenarioText } from './mikescenario.locales';
import { Subscription } from 'rxjs';
import { ScenarioStatusEnum_GetOrderedText } from '../../../enums/generated/ScenarioStatusEnum';
import { MikeScenario } from '../../../models/generated/MikeScenario.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mikescenario-edit',
  templateUrl: './mikescenario-edit.component.html',
  styleUrls: ['./mikescenario-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MikeScenarioEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  scenarioStatusList: EnumIDAndText[];
  mikescenarioFormEdit: FormGroup;
  @Input() mikescenario: MikeScenario = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public mikescenarioService: MikeScenarioService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutMikeScenario(mikescenario: MikeScenario) {
    this.sub = this.mikescenarioService.PutMikeScenario(mikescenario).subscribe();
  }

  PostMikeScenario(mikescenario: MikeScenario) {
    this.sub = this.mikescenarioService.PostMikeScenario(mikescenario).subscribe();
  }

  ngOnInit(): void {
    this.scenarioStatusList = ScenarioStatusEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.mikescenario) {
      let formGroup: FormGroup = this.fb.group(
        {
          MikeScenarioID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.mikescenario.MikeScenarioID)),
              disabled: false
            }, [Validators.required]],
          MikeScenarioTVItemID: [
            {
              value: this.mikescenario.MikeScenarioTVItemID,
              disabled: false
            }, [Validators.required]],
          ParentMikeScenarioID: [
            {
              value: this.mikescenario.ParentMikeScenarioID,
              disabled: false
            }],
          ScenarioStatus: [
            {
              value: this.mikescenario.ScenarioStatus,
              disabled: false
            }, [Validators.required]],
          ErrorInfo: [
            {
              value: this.mikescenario.ErrorInfo,
              disabled: false
            }],
          MikeScenarioStartDateTime_Local: [
            {
              value: this.mikescenario.MikeScenarioStartDateTime_Local,
              disabled: false
            }, [Validators.required]],
          MikeScenarioEndDateTime_Local: [
            {
              value: this.mikescenario.MikeScenarioEndDateTime_Local,
              disabled: false
            }, [Validators.required]],
          MikeScenarioStartExecutionDateTime_Local: [
            {
              value: this.mikescenario.MikeScenarioStartExecutionDateTime_Local,
              disabled: false
            }],
          MikeScenarioExecutionTime_min: [
            {
              value: this.mikescenario.MikeScenarioExecutionTime_min,
              disabled: false
            }, [Validators.min(1), Validators.max(100000)]],
          WindSpeed_km_h: [
            {
              value: this.mikescenario.WindSpeed_km_h,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(100)]],
          WindDirection_deg: [
            {
              value: this.mikescenario.WindDirection_deg,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(360)]],
          DecayFactor_per_day: [
            {
              value: this.mikescenario.DecayFactor_per_day,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(100)]],
          DecayIsConstant: [
            {
              value: this.mikescenario.DecayIsConstant,
              disabled: false
            }, [Validators.required]],
          DecayFactorAmplitude: [
            {
              value: this.mikescenario.DecayFactorAmplitude,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(100)]],
          ResultFrequency_min: [
            {
              value: this.mikescenario.ResultFrequency_min,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(100)]],
          AmbientTemperature_C: [
            {
              value: this.mikescenario.AmbientTemperature_C,
              disabled: false
            }, [Validators.required, Validators.min(-10), Validators.max(40)]],
          AmbientSalinity_PSU: [
            {
              value: this.mikescenario.AmbientSalinity_PSU,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(40)]],
          GenerateDecouplingFiles: [
            {
              value: this.mikescenario.GenerateDecouplingFiles,
              disabled: false
            }],
          UseDecouplingFiles: [
            {
              value: this.mikescenario.UseDecouplingFiles,
              disabled: false
            }],
          UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID: [
            {
              value: this.mikescenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID,
              disabled: false
            }],
          ForSimulatingMWQMRunTVItemID: [
            {
              value: this.mikescenario.ForSimulatingMWQMRunTVItemID,
              disabled: false
            }],
          ManningNumber: [
            {
              value: this.mikescenario.ManningNumber,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(100)]],
          NumberOfElements: [
            {
              value: this.mikescenario.NumberOfElements,
              disabled: false
            }, [Validators.min(1), Validators.max(1000000)]],
          NumberOfTimeSteps: [
            {
              value: this.mikescenario.NumberOfTimeSteps,
              disabled: false
            }, [Validators.min(1), Validators.max(1000000)]],
          NumberOfSigmaLayers: [
            {
              value: this.mikescenario.NumberOfSigmaLayers,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          NumberOfZLayers: [
            {
              value: this.mikescenario.NumberOfZLayers,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          NumberOfHydroOutputParameters: [
            {
              value: this.mikescenario.NumberOfHydroOutputParameters,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          NumberOfTransOutputParameters: [
            {
              value: this.mikescenario.NumberOfTransOutputParameters,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          EstimatedHydroFileSize: [
            {
              value: this.mikescenario.EstimatedHydroFileSize,
              disabled: false
            }, [Validators.min(0), Validators.max(100000000)]],
          EstimatedTransFileSize: [
            {
              value: this.mikescenario.EstimatedTransFileSize,
              disabled: false
            }, [Validators.min(0), Validators.max(100000000)]],
          LastUpdateDate_UTC: [
            {
              value: this.mikescenario.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.mikescenario.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.mikescenarioFormEdit = formGroup
    }
  }
}
