/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { MWQMSampleService } from './mwqmsample.service';
import { LoadLocalesMWQMSampleText } from './mwqmsample.locales';
import { Subscription } from 'rxjs';
import { SampleTypeEnum_GetIDText, SampleTypeEnum_GetOrderedText } from '../../../enums/generated/SampleTypeEnum';
import { MWQMSample } from '../../../models/generated/MWQMSample.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mwqmsample',
  templateUrl: './mwqmsample.component.html',
  styleUrls: ['./mwqmsample.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSampleComponent implements OnInit, OnDestroy {
  sub: Subscription;
  sampleType_oldList: EnumIDAndText[];
  mwqmsampleFormPut: FormGroup;
  mwqmsampleFormPost: FormGroup;

  constructor(public mwqmsampleService: MWQMSampleService, private router: Router, private httpClientService: HttpClientService, private fb: FormBuilder) {
    httpClientService.oldURL = router.url;
  }

  GetMWQMSampleList() {
    this.sub = this.mwqmsampleService.GetMWQMSampleList().subscribe();
  }

  PutMWQMSample(mwqmsample: MWQMSample) {
    this.sub = this.mwqmsampleService.PutMWQMSample(mwqmsample).subscribe();
  }

  PostMWQMSample(mwqmsample: MWQMSample) {
    this.sub = this.mwqmsampleService.PostMWQMSample(mwqmsample).subscribe();
  }

  DeleteMWQMSample(mwqmsample: MWQMSample) {
    this.sub = this.mwqmsampleService.DeleteMWQMSample(mwqmsample).subscribe();
  }

  GetSampleTypeEnumText(enumID: number) {
    return SampleTypeEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesMWQMSampleText(this.mwqmsampleService);
    this.sampleType_oldList = SampleTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup(HttpClientCommand.Post);
    this.FillFormBuilderGroup(HttpClientCommand.Put);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.mwqmsampleService.mwqmsampleListModel$.getValue().length) {
      let formGroup: FormGroup = this.fb.group(
        {
          MWQMSampleID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.MWQMSampleID)),
              disabled: false
            }, [  Validators.required ]],
          MWQMSiteTVItemID: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.MWQMSiteTVItemID,
              disabled: false
            }, [  Validators.required ]],
          MWQMRunTVItemID: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.MWQMRunTVItemID,
              disabled: false
            }, [  Validators.required ]],
          SampleDateTime_Local: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.SampleDateTime_Local,
              disabled: false
            }, [  Validators.required ]],
          TimeText: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.TimeText,
              disabled: false
            }, [  Validators.maxLength(6) ]],
          Depth_m: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.Depth_m,
              disabled: false
            }, [  Validators.min(0), Validators.max(1000) ]],
          FecCol_MPN_100ml: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.FecCol_MPN_100ml,
              disabled: false
            }, [  Validators.required, Validators.min(0), Validators.max(10000000) ]],
          Salinity_PPT: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.Salinity_PPT,
              disabled: false
            }, [  Validators.min(0), Validators.max(40) ]],
          WaterTemp_C: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.WaterTemp_C,
              disabled: false
            }, [  Validators.min(-10), Validators.max(40) ]],
          PH: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.PH,
              disabled: false
            }, [  Validators.min(0), Validators.max(14) ]],
          SampleTypesText: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.SampleTypesText,
              disabled: false
            }, [  Validators.required, Validators.maxLength(50) ]],
          SampleType_old: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.SampleType_old,
              disabled: false
            }],
          Tube_10: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.Tube_10,
              disabled: false
            }, [  Validators.min(0), Validators.max(5) ]],
          Tube_1_0: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.Tube_1_0,
              disabled: false
            }, [  Validators.min(0), Validators.max(5) ]],
          Tube_0_1: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.Tube_0_1,
              disabled: false
            }, [  Validators.min(0), Validators.max(5) ]],
          ProcessedBy: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.ProcessedBy,
              disabled: false
            }, [  Validators.maxLength(10) ]],
          UseForOpenData: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.UseForOpenData,
              disabled: false
            }, [  Validators.required ]],
          LastUpdateDate_UTC: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [  Validators.required ]],
          LastUpdateContactTVItemID: [
            {
              value: this.mwqmsampleService.mwqmsampleListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [  Validators.required ]],
        }
      );

      if (httpClientCommand === HttpClientCommand.Post) {
        this.mwqmsampleFormPost = formGroup
      }
      else {
        this.mwqmsampleFormPut = formGroup;
      }
    }
  }
}
