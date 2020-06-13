/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { MWQMSiteService } from './mwqmsite.service';
import { LoadLocalesMWQMSiteText } from './mwqmsite.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { MWQMSiteLatestClassificationEnum_GetIDText, MWQMSiteLatestClassificationEnum_GetOrderedText } from '../../../enums/generated/MWQMSiteLatestClassificationEnum';
import { MWQMSite } from '../../../models/generated/MWQMSite.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from 'src/app/models/enumidandtext.model';

@Component({
  selector: 'app-mwqmsite',
  templateUrl: './mwqmsite.component.html',
  styleUrls: ['./mwqmsite.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSiteComponent implements OnInit, OnDestroy {
  sub: Subscription;
  mWQMSiteLatestClassificationList: EnumIDAndText[];
  mwqmsiteFormPut: FormGroup;
  mwqmsiteFormPost: FormGroup;

  constructor(public mwqmsiteService: MWQMSiteService, public router: Router, public fb: FormBuilder) { }

  GetMWQMSiteList() {
    this.sub = this.mwqmsiteService.GetMWQMSiteList(this.router).subscribe();
  }

  PutMWQMSite(mwqmsite: MWQMSite) {
    this.sub = this.mwqmsiteService.PutMWQMSite(mwqmsite, this.router).subscribe();
  }

  PostMWQMSite(mwqmsite: MWQMSite) {
    this.sub = this.mwqmsiteService.PostMWQMSite(mwqmsite, this.router).subscribe();
  }

  DeleteMWQMSite(mwqmsite: MWQMSite) {
    this.sub = this.mwqmsiteService.DeleteMWQMSite(mwqmsite, this.router).subscribe();
  }

  GetMWQMSiteLatestClassificationEnumText(enumID: number) {
    return MWQMSiteLatestClassificationEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesMWQMSiteText(this.mwqmsiteService);
    this.mWQMSiteLatestClassificationList = MWQMSiteLatestClassificationEnum_GetOrderedText();
    this.FillFormBuilderGroup('Add');
    this.FillFormBuilderGroup('Update');
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(AddOrUpdate: string) {
    if (this.mwqmsiteService.mwqmsiteList.length) {
      let formGroup: FormGroup = this.fb.group(
        {
          MWQMSiteID: [
            {
              value: (AddOrUpdate === 'Add' ? 0 : (this.mwqmsiteService.mwqmsiteList[0]?.MWQMSiteID ?? '')),
              disabled: false
            }, Validators.required],
          MWQMSiteTVItemID: [
            {
              value: this.mwqmsiteService.mwqmsiteList[0]?.MWQMSiteTVItemID ?? '',
              disabled: false
            }, Validators.required],
          MWQMSiteNumber: [
            {
              value: this.mwqmsiteService.mwqmsiteList[0]?.MWQMSiteNumber ?? '',
              disabled: false
            }, Validators.required],
          MWQMSiteDescription: [
            {
              value: this.mwqmsiteService.mwqmsiteList[0]?.MWQMSiteDescription ?? '',
              disabled: false
            }, Validators.required],
          MWQMSiteLatestClassification: [
            {
              value: this.mwqmsiteService.mwqmsiteList[0]?.MWQMSiteLatestClassification ?? '',
              disabled: false
            }, Validators.required],
          Ordinal: [
            {
              value: this.mwqmsiteService.mwqmsiteList[0]?.Ordinal ?? '',
              disabled: false
            }, Validators.required],
          LastUpdateDate_UTC: [
            {
              value: this.mwqmsiteService.mwqmsiteList[0]?.LastUpdateDate_UTC ?? '',
              disabled: false
            }, Validators.required],
          LastUpdateContactTVItemID: [
            {
              value: this.mwqmsiteService.mwqmsiteList[0]?.LastUpdateContactTVItemID ?? '',
              disabled: false
            }, Validators.required],
        }
      );

      if (AddOrUpdate === 'Add') {
        this.mwqmsiteFormPost = formGroup
      }
      else {
        this.mwqmsiteFormPut = formGroup;
      }
    }
  }
}
