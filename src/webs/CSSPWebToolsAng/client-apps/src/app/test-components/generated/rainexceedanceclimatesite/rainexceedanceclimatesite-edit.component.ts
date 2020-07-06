/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { RainExceedanceClimateSiteService } from './rainexceedanceclimatesite.service';
import { LoadLocalesRainExceedanceClimateSiteText } from './rainexceedanceclimatesite.locales';
import { Subscription } from 'rxjs';
import { RainExceedanceClimateSite } from '../../../models/generated/RainExceedanceClimateSite.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-rainexceedanceclimatesite-edit',
  templateUrl: './rainexceedanceclimatesite-edit.component.html',
  styleUrls: ['./rainexceedanceclimatesite-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RainExceedanceClimateSiteEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  rainexceedanceclimatesiteFormEdit: FormGroup;
  @Input() rainexceedanceclimatesite: RainExceedanceClimateSite = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public rainexceedanceclimatesiteService: RainExceedanceClimateSiteService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutRainExceedanceClimateSite(rainexceedanceclimatesite: RainExceedanceClimateSite) {
    this.sub = this.rainexceedanceclimatesiteService.PutRainExceedanceClimateSite(rainexceedanceclimatesite).subscribe();
  }

  PostRainExceedanceClimateSite(rainexceedanceclimatesite: RainExceedanceClimateSite) {
    this.sub = this.rainexceedanceclimatesiteService.PostRainExceedanceClimateSite(rainexceedanceclimatesite).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.rainexceedanceclimatesite) {
      let formGroup: FormGroup = this.fb.group(
        {
          RainExceedanceClimateSiteID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.rainexceedanceclimatesite.RainExceedanceClimateSiteID)),
              disabled: false
            }, [Validators.required]],
          RainExceedanceTVItemID: [
            {
              value: this.rainexceedanceclimatesite.RainExceedanceTVItemID,
              disabled: false
            }, [Validators.required]],
          ClimateSiteTVItemID: [
            {
              value: this.rainexceedanceclimatesite.ClimateSiteTVItemID,
              disabled: false
            }, [Validators.required]],
          LastUpdateDate_UTC: [
            {
              value: this.rainexceedanceclimatesite.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.rainexceedanceclimatesite.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.rainexceedanceclimatesiteFormEdit = formGroup
    }
  }
}
