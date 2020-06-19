/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { MWQMRunLanguageService } from './mwqmrunlanguage.service';
import { LoadLocalesMWQMRunLanguageText } from './mwqmrunlanguage.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetOrderedText } from '../../../enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetOrderedText } from '../../../enums/generated/TranslationStatusEnum';
import { MWQMRunLanguage } from '../../../models/generated/MWQMRunLanguage.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mwqmrunlanguage-edit',
  templateUrl: './mwqmrunlanguage-edit.component.html',
  styleUrls: ['./mwqmrunlanguage-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMRunLanguageEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  languageList: EnumIDAndText[];
  translationStatusRunCommentList: EnumIDAndText[];
  translationStatusRunWeatherCommentList: EnumIDAndText[];
  mwqmrunlanguageFormEdit: FormGroup;
  @Input() mwqmrunlanguage: MWQMRunLanguage = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public mwqmrunlanguageService: MWQMRunLanguageService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutMWQMRunLanguage(mwqmrunlanguage: MWQMRunLanguage) {
    this.sub = this.mwqmrunlanguageService.PutMWQMRunLanguage(mwqmrunlanguage).subscribe();
  }

  PostMWQMRunLanguage(mwqmrunlanguage: MWQMRunLanguage) {
    this.sub = this.mwqmrunlanguageService.PostMWQMRunLanguage(mwqmrunlanguage).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesMWQMRunLanguageText(this.mwqmrunlanguageService);
    this.languageList = LanguageEnum_GetOrderedText();
    this.translationStatusRunCommentList = TranslationStatusEnum_GetOrderedText();
    this.translationStatusRunWeatherCommentList = TranslationStatusEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.mwqmrunlanguage) {
      let formGroup: FormGroup = this.fb.group(
        {
          MWQMRunLanguageID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.mwqmrunlanguageService.mwqmrunlanguageListModel$.getValue()[0]?.MWQMRunLanguageID)),
              disabled: false
            }, [Validators.required]],
          MWQMRunID: [
            {
              value: this.mwqmrunlanguageService.mwqmrunlanguageListModel$.getValue()[0]?.MWQMRunID,
              disabled: false
            }, [Validators.required]],
          Language: [
            {
              value: this.mwqmrunlanguageService.mwqmrunlanguageListModel$.getValue()[0]?.Language,
              disabled: false
            }, [Validators.required]],
          RunComment: [
            {
              value: this.mwqmrunlanguageService.mwqmrunlanguageListModel$.getValue()[0]?.RunComment,
              disabled: false
            }, [Validators.required]],
          TranslationStatusRunComment: [
            {
              value: this.mwqmrunlanguageService.mwqmrunlanguageListModel$.getValue()[0]?.TranslationStatusRunComment,
              disabled: false
            }, [Validators.required]],
          RunWeatherComment: [
            {
              value: this.mwqmrunlanguageService.mwqmrunlanguageListModel$.getValue()[0]?.RunWeatherComment,
              disabled: false
            }, [Validators.required]],
          TranslationStatusRunWeatherComment: [
            {
              value: this.mwqmrunlanguageService.mwqmrunlanguageListModel$.getValue()[0]?.TranslationStatusRunWeatherComment,
              disabled: false
            }, [Validators.required]],
          LastUpdateDate_UTC: [
            {
              value: this.mwqmrunlanguageService.mwqmrunlanguageListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.mwqmrunlanguageService.mwqmrunlanguageListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.mwqmrunlanguageFormEdit = formGroup
    }
  }
}