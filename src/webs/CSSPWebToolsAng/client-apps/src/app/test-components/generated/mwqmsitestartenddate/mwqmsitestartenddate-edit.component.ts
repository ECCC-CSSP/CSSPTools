/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { MWQMSiteStartEndDateService } from './mwqmsitestartenddate.service';
import { LoadLocalesMWQMSiteStartEndDateText } from './mwqmsitestartenddate.locales';
import { Subscription } from 'rxjs';
import { MWQMSiteStartEndDate } from '../../../models/generated/MWQMSiteStartEndDate.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mwqmsitestartenddate-edit',
  templateUrl: './mwqmsitestartenddate-edit.component.html',
  styleUrls: ['./mwqmsitestartenddate-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSiteStartEndDateEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  mwqmsitestartenddateFormEdit: FormGroup;
  @Input() mwqmsitestartenddate: MWQMSiteStartEndDate = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public mwqmsitestartenddateService: MWQMSiteStartEndDateService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutMWQMSiteStartEndDate(mwqmsitestartenddate: MWQMSiteStartEndDate) {
    this.sub = this.mwqmsitestartenddateService.PutMWQMSiteStartEndDate(mwqmsitestartenddate).subscribe();
  }

  PostMWQMSiteStartEndDate(mwqmsitestartenddate: MWQMSiteStartEndDate) {
    this.sub = this.mwqmsitestartenddateService.PostMWQMSiteStartEndDate(mwqmsitestartenddate).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.mwqmsitestartenddate) {
      let formGroup: FormGroup = this.fb.group(
        {
          MWQMSiteStartEndDateID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.mwqmsitestartenddate.MWQMSiteStartEndDateID)),
              disabled: false
            }, [Validators.required]],
          MWQMSiteTVItemID: [
            {
              value: this.mwqmsitestartenddate.MWQMSiteTVItemID,
              disabled: false
            }, [Validators.required]],
          StartDate: [
            {
              value: this.mwqmsitestartenddate.StartDate,
              disabled: false
            }, [Validators.required]],
          EndDate: [
            {
              value: this.mwqmsitestartenddate.EndDate,
              disabled: false
            }],
          LastUpdateDate_UTC: [
            {
              value: this.mwqmsitestartenddate.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.mwqmsitestartenddate.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.mwqmsitestartenddateFormEdit = formGroup
    }
  }
}
