/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { TelService } from './tel.service';
import { LoadLocalesTelText } from './tel.locales';
import { Subscription } from 'rxjs';
import { TelTypeEnum_GetOrderedText } from '../../../enums/generated/TelTypeEnum';
import { Tel } from '../../../models/generated/Tel.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enum-idandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-tel-edit',
  templateUrl: './tel-edit.component.html',
  styleUrls: ['./tel-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TelEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  telTypeList: EnumIDAndText[];
  telFormEdit: FormGroup;
  @Input() tel: Tel = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public telService: TelService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutTel(tel: Tel) {
    this.sub = this.telService.PutTel(tel).subscribe();
  }

  PostTel(tel: Tel) {
    this.sub = this.telService.PostTel(tel).subscribe();
  }

  ngOnInit(): void {
    this.telTypeList = TelTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.tel) {
      let formGroup: FormGroup = this.fb.group(
        {
          TelID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.tel.TelID)),
              disabled: false
            }, [Validators.required]],
          TelTVItemID: [
            {
              value: this.tel.TelTVItemID,
              disabled: false
            }, [Validators.required]],
          TelNumber: [
            {
              value: this.tel.TelNumber,
              disabled: false
            }, [Validators.required, Validators.maxLength(50)]],
          TelType: [
            {
              value: this.tel.TelType,
              disabled: false
            }, [Validators.required]],
          LastUpdateDate_UTC: [
            {
              value: this.tel.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.tel.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.telFormEdit = formGroup
    }
  }
}
