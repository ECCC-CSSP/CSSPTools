/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { MWQMSampleLanguageService } from './mwqmsamplelanguage.service';
import { LoadLocalesMWQMSampleLanguageText } from './mwqmsamplelanguage.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetOrderedText } from '../../../enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetOrderedText } from '../../../enums/generated/TranslationStatusEnum';
import { MWQMSampleLanguage } from '../../../models/generated/MWQMSampleLanguage.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mwqmsamplelanguage-edit',
  templateUrl: './mwqmsamplelanguage-edit.component.html',
  styleUrls: ['./mwqmsamplelanguage-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSampleLanguageEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  languageList: EnumIDAndText[];
  translationStatusList: EnumIDAndText[];
  mwqmsamplelanguageFormEdit: FormGroup;
  @Input() mwqmsamplelanguage: MWQMSampleLanguage = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public mwqmsamplelanguageService: MWQMSampleLanguageService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutMWQMSampleLanguage(mwqmsamplelanguage: MWQMSampleLanguage) {
    this.sub = this.mwqmsamplelanguageService.PutMWQMSampleLanguage(mwqmsamplelanguage).subscribe();
  }

  PostMWQMSampleLanguage(mwqmsamplelanguage: MWQMSampleLanguage) {
    this.sub = this.mwqmsamplelanguageService.PostMWQMSampleLanguage(mwqmsamplelanguage).subscribe();
  }

  ngOnInit(): void {
    this.languageList = LanguageEnum_GetOrderedText();
    this.translationStatusList = TranslationStatusEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.mwqmsamplelanguage) {
      let formGroup: FormGroup = this.fb.group(
        {
          MWQMSampleLanguageID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.mwqmsamplelanguage.MWQMSampleLanguageID)),
              disabled: false
            }, [Validators.required]],
          MWQMSampleID: [
            {
              value: this.mwqmsamplelanguage.MWQMSampleID,
              disabled: false
            }, [Validators.required]],
          Language: [
            {
              value: this.mwqmsamplelanguage.Language,
              disabled: false
            }, [Validators.required]],
          MWQMSampleNote: [
            {
              value: this.mwqmsamplelanguage.MWQMSampleNote,
              disabled: false
            }, [Validators.required]],
          TranslationStatus: [
            {
              value: this.mwqmsamplelanguage.TranslationStatus,
              disabled: false
            }, [Validators.required]],
          LastUpdateDate_UTC: [
            {
              value: this.mwqmsamplelanguage.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.mwqmsamplelanguage.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.mwqmsamplelanguageFormEdit = formGroup
    }
  }
}
