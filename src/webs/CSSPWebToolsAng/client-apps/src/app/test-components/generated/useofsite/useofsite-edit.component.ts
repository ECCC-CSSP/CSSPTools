/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { UseOfSiteService } from './useofsite.service';
import { LoadLocalesUseOfSiteText } from './useofsite.locales';
import { Subscription } from 'rxjs';
import { TVTypeEnum_GetOrderedText } from '../../../enums/generated/TVTypeEnum';
import { UseOfSite } from '../../../models/generated/UseOfSite.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enum-idandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-useofsite-edit',
  templateUrl: './useofsite-edit.component.html',
  styleUrls: ['./useofsite-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UseOfSiteEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  tVTypeList: EnumIDAndText[];
  useofsiteFormEdit: FormGroup;
  @Input() useofsite: UseOfSite = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public useofsiteService: UseOfSiteService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutUseOfSite(useofsite: UseOfSite) {
    this.sub = this.useofsiteService.PutUseOfSite(useofsite).subscribe();
  }

  PostUseOfSite(useofsite: UseOfSite) {
    this.sub = this.useofsiteService.PostUseOfSite(useofsite).subscribe();
  }

  ngOnInit(): void {
    this.tVTypeList = TVTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.useofsite) {
      let formGroup: FormGroup = this.fb.group(
        {
          UseOfSiteID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.useofsite.UseOfSiteID)),
              disabled: false
            }, [Validators.required]],
          SiteTVItemID: [
            {
              value: this.useofsite.SiteTVItemID,
              disabled: false
            }, [Validators.required]],
          SubsectorTVItemID: [
            {
              value: this.useofsite.SubsectorTVItemID,
              disabled: false
            }, [Validators.required]],
          TVType: [
            {
              value: this.useofsite.TVType,
              disabled: false
            }, [Validators.required]],
          Ordinal: [
            {
              value: this.useofsite.Ordinal,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(1000)]],
          StartYear: [
            {
              value: this.useofsite.StartYear,
              disabled: false
            }, [Validators.required, Validators.min(1980), Validators.max(2050)]],
          EndYear: [
            {
              value: this.useofsite.EndYear,
              disabled: false
            }, [Validators.min(1980), Validators.max(2050)]],
          UseWeight: [
            {
              value: this.useofsite.UseWeight,
              disabled: false
            }],
          Weight_perc: [
            {
              value: this.useofsite.Weight_perc,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          UseEquation: [
            {
              value: this.useofsite.UseEquation,
              disabled: false
            }],
          Param1: [
            {
              value: this.useofsite.Param1,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          Param2: [
            {
              value: this.useofsite.Param2,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          Param3: [
            {
              value: this.useofsite.Param3,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          Param4: [
            {
              value: this.useofsite.Param4,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          LastUpdateDate_UTC: [
            {
              value: this.useofsite.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.useofsite.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.useofsiteFormEdit = formGroup
    }
  }
}
