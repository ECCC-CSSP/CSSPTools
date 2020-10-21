/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { MikeSourceService } from './mikesource.service';
import { LoadLocalesMikeSourceText } from './mikesource.locales';
import { Subscription } from 'rxjs';
import { MikeSource } from '../../../models/generated/MikeSource.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mikesource-edit',
  templateUrl: './mikesource-edit.component.html',
  styleUrls: ['./mikesource-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MikeSourceEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  mikesourceFormEdit: FormGroup;
  @Input() mikesource: MikeSource = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public mikesourceService: MikeSourceService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutMikeSource(mikesource: MikeSource) {
    this.sub = this.mikesourceService.PutMikeSource(mikesource).subscribe();
  }

  PostMikeSource(mikesource: MikeSource) {
    this.sub = this.mikesourceService.PostMikeSource(mikesource).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.mikesource) {
      let formGroup: FormGroup = this.fb.group(
        {
          MikeSourceID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.mikesource.MikeSourceID)),
              disabled: false
            }, [Validators.required]],
          MikeSourceTVItemID: [
            {
              value: this.mikesource.MikeSourceTVItemID,
              disabled: false
            }, [Validators.required]],
          IsContinuous: [
            {
              value: this.mikesource.IsContinuous,
              disabled: false
            }, [Validators.required]],
          Include: [
            {
              value: this.mikesource.Include,
              disabled: false
            }, [Validators.required]],
          IsRiver: [
            {
              value: this.mikesource.IsRiver,
              disabled: false
            }, [Validators.required]],
          UseHydrometric: [
            {
              value: this.mikesource.UseHydrometric,
              disabled: false
            }, [Validators.required]],
          HydrometricTVItemID: [
            {
              value: this.mikesource.HydrometricTVItemID,
              disabled: false
            }],
          DrainageArea_km2: [
            {
              value: this.mikesource.DrainageArea_km2,
              disabled: false
            }, [Validators.min(0), Validators.max(1000000)]],
          Factor: [
            {
              value: this.mikesource.Factor,
              disabled: false
            }, [Validators.min(0), Validators.max(1000000)]],
          SourceNumberString: [
            {
              value: this.mikesource.SourceNumberString,
              disabled: false
            }, [Validators.required, Validators.maxLength(50)]],
          LastUpdateDate_UTC: [
            {
              value: this.mikesource.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.mikesource.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.mikesourceFormEdit = formGroup
    }
  }
}
