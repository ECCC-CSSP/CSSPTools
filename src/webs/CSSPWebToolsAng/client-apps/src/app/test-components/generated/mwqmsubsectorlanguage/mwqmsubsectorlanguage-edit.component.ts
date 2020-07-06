/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { MWQMSubsectorLanguageService } from './mwqmsubsectorlanguage.service';
import { LoadLocalesMWQMSubsectorLanguageText } from './mwqmsubsectorlanguage.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetOrderedText } from '../../../enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetOrderedText } from '../../../enums/generated/TranslationStatusEnum';
import { MWQMSubsectorLanguage } from '../../../models/generated/MWQMSubsectorLanguage.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mwqmsubsectorlanguage-edit',
  templateUrl: './mwqmsubsectorlanguage-edit.component.html',
  styleUrls: ['./mwqmsubsectorlanguage-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSubsectorLanguageEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  languageList: EnumIDAndText[];
  translationStatusSubsectorDescList: EnumIDAndText[];
  translationStatusLogBookList: EnumIDAndText[];
  mwqmsubsectorlanguageFormEdit: FormGroup;
  @Input() mwqmsubsectorlanguage: MWQMSubsectorLanguage = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public mwqmsubsectorlanguageService: MWQMSubsectorLanguageService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutMWQMSubsectorLanguage(mwqmsubsectorlanguage: MWQMSubsectorLanguage) {
    this.sub = this.mwqmsubsectorlanguageService.PutMWQMSubsectorLanguage(mwqmsubsectorlanguage).subscribe();
  }

  PostMWQMSubsectorLanguage(mwqmsubsectorlanguage: MWQMSubsectorLanguage) {
    this.sub = this.mwqmsubsectorlanguageService.PostMWQMSubsectorLanguage(mwqmsubsectorlanguage).subscribe();
  }

  ngOnInit(): void {
    this.languageList = LanguageEnum_GetOrderedText();
    this.translationStatusSubsectorDescList = TranslationStatusEnum_GetOrderedText();
    this.translationStatusLogBookList = TranslationStatusEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.mwqmsubsectorlanguage) {
      let formGroup: FormGroup = this.fb.group(
        {
          MWQMSubsectorLanguageID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.mwqmsubsectorlanguage.MWQMSubsectorLanguageID)),
              disabled: false
            }, [Validators.required]],
          MWQMSubsectorID: [
            {
              value: this.mwqmsubsectorlanguage.MWQMSubsectorID,
              disabled: false
            }, [Validators.required]],
          Language: [
            {
              value: this.mwqmsubsectorlanguage.Language,
              disabled: false
            }, [Validators.required]],
          SubsectorDesc: [
            {
              value: this.mwqmsubsectorlanguage.SubsectorDesc,
              disabled: false
            }, [Validators.required, Validators.maxLength(250)]],
          TranslationStatusSubsectorDesc: [
            {
              value: this.mwqmsubsectorlanguage.TranslationStatusSubsectorDesc,
              disabled: false
            }, [Validators.required]],
          LogBook: [
            {
              value: this.mwqmsubsectorlanguage.LogBook,
              disabled: false
            }],
          TranslationStatusLogBook: [
            {
              value: this.mwqmsubsectorlanguage.TranslationStatusLogBook,
              disabled: false
            }],
          LastUpdateDate_UTC: [
            {
              value: this.mwqmsubsectorlanguage.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.mwqmsubsectorlanguage.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.mwqmsubsectorlanguageFormEdit = formGroup
    }
  }
}
