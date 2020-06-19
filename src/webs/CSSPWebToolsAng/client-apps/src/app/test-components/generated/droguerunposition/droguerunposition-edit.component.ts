/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { DrogueRunPositionService } from './droguerunposition.service';
import { LoadLocalesDrogueRunPositionText } from './droguerunposition.locales';
import { Subscription } from 'rxjs';
import { DrogueRunPosition } from '../../../models/generated/DrogueRunPosition.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-droguerunposition-edit',
  templateUrl: './droguerunposition-edit.component.html',
  styleUrls: ['./droguerunposition-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DrogueRunPositionEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  droguerunpositionFormEdit: FormGroup;
  @Input() droguerunposition: DrogueRunPosition = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public droguerunpositionService: DrogueRunPositionService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutDrogueRunPosition(droguerunposition: DrogueRunPosition) {
    this.sub = this.droguerunpositionService.PutDrogueRunPosition(droguerunposition).subscribe();
  }

  PostDrogueRunPosition(droguerunposition: DrogueRunPosition) {
    this.sub = this.droguerunpositionService.PostDrogueRunPosition(droguerunposition).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesDrogueRunPositionText(this.droguerunpositionService);
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.droguerunposition) {
      let formGroup: FormGroup = this.fb.group(
        {
          DrogueRunPositionID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.droguerunpositionService.droguerunpositionListModel$.getValue()[0]?.DrogueRunPositionID)),
              disabled: false
            }, [Validators.required]],
          DrogueRunID: [
            {
              value: this.droguerunpositionService.droguerunpositionListModel$.getValue()[0]?.DrogueRunID,
              disabled: false
            }, [Validators.required]],
          Ordinal: [
            {
              value: this.droguerunpositionService.droguerunpositionListModel$.getValue()[0]?.Ordinal,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(100000)]],
          StepLat: [
            {
              value: this.droguerunpositionService.droguerunpositionListModel$.getValue()[0]?.StepLat,
              disabled: false
            }, [Validators.required, Validators.min(-180), Validators.max(180)]],
          StepLng: [
            {
              value: this.droguerunpositionService.droguerunpositionListModel$.getValue()[0]?.StepLng,
              disabled: false
            }, [Validators.required, Validators.min(-90), Validators.max(90)]],
          StepDateTime_Local: [
            {
              value: this.droguerunpositionService.droguerunpositionListModel$.getValue()[0]?.StepDateTime_Local,
              disabled: false
            }, [Validators.required]],
          CalculatedSpeed_m_s: [
            {
              value: this.droguerunpositionService.droguerunpositionListModel$.getValue()[0]?.CalculatedSpeed_m_s,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(10)]],
          CalculatedDirection_deg: [
            {
              value: this.droguerunpositionService.droguerunpositionListModel$.getValue()[0]?.CalculatedDirection_deg,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(360)]],
          LastUpdateDate_UTC: [
            {
              value: this.droguerunpositionService.droguerunpositionListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.droguerunpositionService.droguerunpositionListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.droguerunpositionFormEdit = formGroup
    }
  }
}