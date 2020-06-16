/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { MapInfoService } from './mapinfo.service';
import { LoadLocalesMapInfoText } from './mapinfo.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { TVTypeEnum_GetIDText, TVTypeEnum_GetOrderedText } from '../../../enums/generated/TVTypeEnum';
import { MapInfoDrawTypeEnum_GetIDText, MapInfoDrawTypeEnum_GetOrderedText } from '../../../enums/generated/MapInfoDrawTypeEnum';
import { MapInfo } from '../../../models/generated/MapInfo.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';

@Component({
  selector: 'app-mapinfo',
  templateUrl: './mapinfo.component.html',
  styleUrls: ['./mapinfo.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MapInfoComponent implements OnInit, OnDestroy {
  sub: Subscription;
  tVTypeList: EnumIDAndText[];
  mapInfoDrawTypeList: EnumIDAndText[];
  mapinfoFormPut: FormGroup;
  mapinfoFormPost: FormGroup;

  constructor(public mapinfoService: MapInfoService, public router: Router, public fb: FormBuilder) { }

  GetMapInfoList() {
    this.sub = this.mapinfoService.GetMapInfoList(this.router).subscribe();
  }

  PutMapInfo(mapinfo: MapInfo) {
    this.sub = this.mapinfoService.PutMapInfo(mapinfo, this.router).subscribe();
  }

  PostMapInfo(mapinfo: MapInfo) {
    this.sub = this.mapinfoService.PostMapInfo(mapinfo, this.router).subscribe();
  }

  DeleteMapInfo(mapinfo: MapInfo) {
    this.sub = this.mapinfoService.DeleteMapInfo(mapinfo, this.router).subscribe();
  }

  GetTVTypeEnumText(enumID: number) {
    return TVTypeEnum_GetIDText(enumID)
  }

  GetMapInfoDrawTypeEnumText(enumID: number) {
    return MapInfoDrawTypeEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesMapInfoText(this.mapinfoService);
    this.tVTypeList = TVTypeEnum_GetOrderedText();
    this.mapInfoDrawTypeList = MapInfoDrawTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup('Add');
    this.FillFormBuilderGroup('Update');
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(AddOrUpdate: string) {
    if (this.mapinfoService.mapinfoList.length) {
      let formGroup: FormGroup = this.fb.group(
        {
          MapInfoID: [
            {
              value: (AddOrUpdate === 'Add' ? 0 : (this.mapinfoService.mapinfoList[0]?.MapInfoID)),
              disabled: false
            }, [ Validators.required ]],
          TVItemID: [
            {
              value: this.mapinfoService.mapinfoList[0]?.TVItemID,
              disabled: false
            }, [ Validators.required ]],
          TVType: [
            {
              value: this.mapinfoService.mapinfoList[0]?.TVType,
              disabled: false
            }, [ Validators.required ]],
          LatMin: [
            {
              value: this.mapinfoService.mapinfoList[0]?.LatMin,
              disabled: false
            }, [ Validators.required ]],
          LatMax: [
            {
              value: this.mapinfoService.mapinfoList[0]?.LatMax,
              disabled: false
            }, [ Validators.required ]],
          LngMin: [
            {
              value: this.mapinfoService.mapinfoList[0]?.LngMin,
              disabled: false
            }, [ Validators.required ]],
          LngMax: [
            {
              value: this.mapinfoService.mapinfoList[0]?.LngMax,
              disabled: false
            }, [ Validators.required ]],
          MapInfoDrawType: [
            {
              value: this.mapinfoService.mapinfoList[0]?.MapInfoDrawType,
              disabled: false
            }, [ Validators.required ]],
          LastUpdateDate_UTC: [
            {
              value: this.mapinfoService.mapinfoList[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [ Validators.required ]],
          LastUpdateContactTVItemID: [
            {
              value: this.mapinfoService.mapinfoList[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [ Validators.required ]],
        }
      );

      if (AddOrUpdate === 'Add') {
        this.mapinfoFormPost = formGroup
      }
      else {
        this.mapinfoFormPut = formGroup;
      }
    }
  }
}
