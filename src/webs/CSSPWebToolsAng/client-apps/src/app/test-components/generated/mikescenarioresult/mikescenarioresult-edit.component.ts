/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { MikeScenarioResultService } from './mikescenarioresult.service';
import { LoadLocalesMikeScenarioResultText } from './mikescenarioresult.locales';
import { Subscription } from 'rxjs';
import { MikeScenarioResult } from '../../../models/generated/MikeScenarioResult.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mikescenarioresult-edit',
  templateUrl: './mikescenarioresult-edit.component.html',
  styleUrls: ['./mikescenarioresult-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MikeScenarioResultEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  mikescenarioresultFormEdit: FormGroup;
  @Input() mikescenarioresult: MikeScenarioResult = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public mikescenarioresultService: MikeScenarioResultService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutMikeScenarioResult(mikescenarioresult: MikeScenarioResult) {
    this.sub = this.mikescenarioresultService.PutMikeScenarioResult(mikescenarioresult).subscribe();
  }

  PostMikeScenarioResult(mikescenarioresult: MikeScenarioResult) {
    this.sub = this.mikescenarioresultService.PostMikeScenarioResult(mikescenarioresult).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesMikeScenarioResultText(this.mikescenarioresultService);
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.mikescenarioresult) {
      let formGroup: FormGroup = this.fb.group(
        {
          MikeScenarioResultID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.mikescenarioresultService.mikescenarioresultListModel$.getValue()[0]?.MikeScenarioResultID)),
              disabled: false
            }, [Validators.required]],
          MikeScenarioTVItemID: [
            {
              value: this.mikescenarioresultService.mikescenarioresultListModel$.getValue()[0]?.MikeScenarioTVItemID,
              disabled: false
            }, [Validators.required]],
          MikeResultsJSON: [
            {
              value: this.mikescenarioresultService.mikescenarioresultListModel$.getValue()[0]?.MikeResultsJSON,
              disabled: false
            }],
          LastUpdateDate_UTC: [
            {
              value: this.mikescenarioresultService.mikescenarioresultListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.mikescenarioresultService.mikescenarioresultListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.mikescenarioresultFormEdit = formGroup
    }
  }
}
