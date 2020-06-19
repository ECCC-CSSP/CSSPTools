/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { MWQMSiteService } from './mwqmsite.service';
import { LoadLocalesMWQMSiteText } from './mwqmsite.locales';
import { Subscription } from 'rxjs';
import { MWQMSiteLatestClassificationEnum_GetOrderedText } from '../../../enums/generated/MWQMSiteLatestClassificationEnum';
import { MWQMSite } from '../../../models/generated/MWQMSite.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mwqmsite-edit',
  templateUrl: './mwqmsite-edit.component.html',
  styleUrls: ['./mwqmsite-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSiteEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  mWQMSiteLatestClassificationList: EnumIDAndText[];
  mwqmsiteFormEdit: FormGroup;
  @Input() mwqmsite: MWQMSite = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public mwqmsiteService: MWQMSiteService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutMWQMSite(mwqmsite: MWQMSite) {
    this.sub = this.mwqmsiteService.PutMWQMSite(mwqmsite).subscribe();
  }

  PostMWQMSite(mwqmsite: MWQMSite) {
    this.sub = this.mwqmsiteService.PostMWQMSite(mwqmsite).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesMWQMSiteText(this.mwqmsiteService);
    this.mWQMSiteLatestClassificationList = MWQMSiteLatestClassificationEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.mwqmsite) {
      let formGroup: FormGroup = this.fb.group(
        {
          MWQMSiteID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.mwqmsiteService.mwqmsiteListModel$.getValue()[0]?.MWQMSiteID)),
              disabled: false
            }, [Validators.required]],
          MWQMSiteTVItemID: [
            {
              value: this.mwqmsiteService.mwqmsiteListModel$.getValue()[0]?.MWQMSiteTVItemID,
              disabled: false
            }, [Validators.required]],
          MWQMSiteNumber: [
            {
              value: this.mwqmsiteService.mwqmsiteListModel$.getValue()[0]?.MWQMSiteNumber,
              disabled: false
            }, [Validators.required, Validators.maxLength(8)]],
          MWQMSiteDescription: [
            {
              value: this.mwqmsiteService.mwqmsiteListModel$.getValue()[0]?.MWQMSiteDescription,
              disabled: false
            }, [Validators.required, Validators.maxLength(200)]],
          MWQMSiteLatestClassification: [
            {
              value: this.mwqmsiteService.mwqmsiteListModel$.getValue()[0]?.MWQMSiteLatestClassification,
              disabled: false
            }, [Validators.required]],
          Ordinal: [
            {
              value: this.mwqmsiteService.mwqmsiteListModel$.getValue()[0]?.Ordinal,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(1000)]],
          LastUpdateDate_UTC: [
            {
              value: this.mwqmsiteService.mwqmsiteListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.mwqmsiteService.mwqmsiteListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.mwqmsiteFormEdit = formGroup
    }
  }
}
