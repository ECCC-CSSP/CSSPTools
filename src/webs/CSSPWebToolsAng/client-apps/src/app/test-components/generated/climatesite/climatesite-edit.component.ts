/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { ClimateSiteService } from './climatesite.service';
import { LoadLocalesClimateSiteText } from './climatesite.locales';
import { Subscription } from 'rxjs';
import { ClimateSite } from '../../../models/generated/ClimateSite.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-climatesite-edit',
  templateUrl: './climatesite-edit.component.html',
  styleUrls: ['./climatesite-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ClimateSiteEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  climatesiteFormEdit: FormGroup;
  @Input() climatesite: ClimateSite = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public climatesiteService: ClimateSiteService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutClimateSite(climatesite: ClimateSite) {
    this.sub = this.climatesiteService.PutClimateSite(climatesite).subscribe();
  }

  PostClimateSite(climatesite: ClimateSite) {
    this.sub = this.climatesiteService.PostClimateSite(climatesite).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesClimateSiteText(this.climatesiteService);
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.climatesite) {
      let formGroup: FormGroup = this.fb.group(
        {
          ClimateSiteID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.climatesiteService.climatesiteListModel$.getValue()[0]?.ClimateSiteID)),
              disabled: false
            }, [Validators.required]],
          ClimateSiteTVItemID: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.ClimateSiteTVItemID,
              disabled: false
            }, [Validators.required]],
          ECDBID: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.ECDBID,
              disabled: false
            }, [Validators.min(1), Validators.max(100000)]],
          ClimateSiteName: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.ClimateSiteName,
              disabled: false
            }, [Validators.required, Validators.maxLength(100)]],
          Province: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.Province,
              disabled: false
            }, [Validators.required, Validators.maxLength(4)]],
          Elevation_m: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.Elevation_m,
              disabled: false
            }, [Validators.min(0), Validators.max(10000)]],
          ClimateID: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.ClimateID,
              disabled: false
            }, [Validators.maxLength(10)]],
          WMOID: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.WMOID,
              disabled: false
            }, [Validators.min(1), Validators.max(100000)]],
          TCID: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.TCID,
              disabled: false
            }, [Validators.maxLength(3)]],
          IsQuebecSite: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.IsQuebecSite,
              disabled: false
            }],
          IsCoCoRaHS: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.IsCoCoRaHS,
              disabled: false
            }],
          TimeOffset_hour: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.TimeOffset_hour,
              disabled: false
            }, [Validators.min(-10), Validators.max(0)]],
          File_desc: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.File_desc,
              disabled: false
            }, [Validators.maxLength(50)]],
          HourlyStartDate_Local: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.HourlyStartDate_Local,
              disabled: false
            }],
          HourlyEndDate_Local: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.HourlyEndDate_Local,
              disabled: false
            }],
          HourlyNow: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.HourlyNow,
              disabled: false
            }],
          DailyStartDate_Local: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.DailyStartDate_Local,
              disabled: false
            }],
          DailyEndDate_Local: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.DailyEndDate_Local,
              disabled: false
            }],
          DailyNow: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.DailyNow,
              disabled: false
            }],
          MonthlyStartDate_Local: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.MonthlyStartDate_Local,
              disabled: false
            }],
          MonthlyEndDate_Local: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.MonthlyEndDate_Local,
              disabled: false
            }],
          MonthlyNow: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.MonthlyNow,
              disabled: false
            }],
          LastUpdateDate_UTC: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.climatesiteService.climatesiteListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.climatesiteFormEdit = formGroup
    }
  }
}