/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { TelService } from './tel.service';
import { LoadLocalesTelText } from './tel.locales';
import { Subscription } from 'rxjs';
import { TelTypeEnum_GetIDText, TelTypeEnum_GetOrderedText } from '../../../enums/generated/TelTypeEnum';
import { Tel } from '../../../models/generated/Tel.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-tel',
  templateUrl: './tel.component.html',
  styleUrls: ['./tel.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TelComponent implements OnInit, OnDestroy {
  sub: Subscription;
  telTypeList: EnumIDAndText[];
  telFormPut: FormGroup;
  telFormPost: FormGroup;

  constructor(public telService: TelService, private router: Router, private httpClientService: HttpClientService, private fb: FormBuilder) {
    httpClientService.oldURL = router.url;
  }

  GetTelList() {
    this.sub = this.telService.GetTelList().subscribe();
  }

  PutTel(tel: Tel) {
    this.sub = this.telService.PutTel(tel).subscribe();
  }

  PostTel(tel: Tel) {
    this.sub = this.telService.PostTel(tel).subscribe();
  }

  DeleteTel(tel: Tel) {
    this.sub = this.telService.DeleteTel(tel).subscribe();
  }

  GetTelTypeEnumText(enumID: number) {
    return TelTypeEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesTelText(this.telService);
    this.telTypeList = TelTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup(HttpClientCommand.Post);
    this.FillFormBuilderGroup(HttpClientCommand.Put);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.telService.telListModel$.getValue().length) {
      let formGroup: FormGroup = this.fb.group(
        {
          TelID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.telService.telListModel$.getValue()[0]?.TelID)),
              disabled: false
            }, [  Validators.required ]],
          TelTVItemID: [
            {
              value: this.telService.telListModel$.getValue()[0]?.TelTVItemID,
              disabled: false
            }, [  Validators.required ]],
          TelNumber: [
            {
              value: this.telService.telListModel$.getValue()[0]?.TelNumber,
              disabled: false
            }, [  Validators.required, Validators.maxLength(50) ]],
          TelType: [
            {
              value: this.telService.telListModel$.getValue()[0]?.TelType,
              disabled: false
            }, [  Validators.required ]],
          LastUpdateDate_UTC: [
            {
              value: this.telService.telListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [  Validators.required ]],
          LastUpdateContactTVItemID: [
            {
              value: this.telService.telListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [  Validators.required ]],
        }
      );

      if (httpClientCommand === HttpClientCommand.Post) {
        this.telFormPost = formGroup
      }
      else {
        this.telFormPut = formGroup;
      }
    }
  }
}
