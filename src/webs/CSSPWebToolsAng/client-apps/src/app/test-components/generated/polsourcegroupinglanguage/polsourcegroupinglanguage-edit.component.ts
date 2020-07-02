/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { PolSourceGroupingLanguageService } from './polsourcegroupinglanguage.service';
import { LoadLocalesPolSourceGroupingLanguageText } from './polsourcegroupinglanguage.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetOrderedText } from '../../../enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetOrderedText } from '../../../enums/generated/TranslationStatusEnum';
import { PolSourceGroupingLanguage } from '../../../models/generated/PolSourceGroupingLanguage.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-polsourcegroupinglanguage-edit',
  templateUrl: './polsourcegroupinglanguage-edit.component.html',
  styleUrls: ['./polsourcegroupinglanguage-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PolSourceGroupingLanguageEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  languageList: EnumIDAndText[];
  translationStatusSourceNameList: EnumIDAndText[];
  translationStatusInitList: EnumIDAndText[];
  translationStatusDescriptionList: EnumIDAndText[];
  translationStatusReportList: EnumIDAndText[];
  translationStatusTextList: EnumIDAndText[];
  polsourcegroupinglanguageFormEdit: FormGroup;
  @Input() polsourcegroupinglanguage: PolSourceGroupingLanguage = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public polsourcegroupinglanguageService: PolSourceGroupingLanguageService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutPolSourceGroupingLanguage(polsourcegroupinglanguage: PolSourceGroupingLanguage) {
    this.sub = this.polsourcegroupinglanguageService.PutPolSourceGroupingLanguage(polsourcegroupinglanguage).subscribe();
  }

  PostPolSourceGroupingLanguage(polsourcegroupinglanguage: PolSourceGroupingLanguage) {
    this.sub = this.polsourcegroupinglanguageService.PostPolSourceGroupingLanguage(polsourcegroupinglanguage).subscribe();
  }

  ngOnInit(): void {
    this.languageList = LanguageEnum_GetOrderedText();
    this.translationStatusSourceNameList = TranslationStatusEnum_GetOrderedText();
    this.translationStatusInitList = TranslationStatusEnum_GetOrderedText();
    this.translationStatusDescriptionList = TranslationStatusEnum_GetOrderedText();
    this.translationStatusReportList = TranslationStatusEnum_GetOrderedText();
    this.translationStatusTextList = TranslationStatusEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.polsourcegroupinglanguage) {
      let formGroup: FormGroup = this.fb.group(
        {
          PolSourceGroupingLanguageID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.polsourcegroupinglanguage.PolSourceGroupingLanguageID)),
              disabled: false
            }, [Validators.required]],
          PolSourceGroupingID: [
            {
              value: this.polsourcegroupinglanguage.PolSourceGroupingID,
              disabled: false
            }, [Validators.required]],
          Language: [
            {
              value: this.polsourcegroupinglanguage.Language,
              disabled: false
            }, [Validators.required]],
          SourceName: [
            {
              value: this.polsourcegroupinglanguage.SourceName,
              disabled: false
            }, [Validators.required, Validators.maxLength(500)]],
          SourceNameOrder: [
            {
              value: this.polsourcegroupinglanguage.SourceNameOrder,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(1000)]],
          TranslationStatusSourceName: [
            {
              value: this.polsourcegroupinglanguage.TranslationStatusSourceName,
              disabled: false
            }, [Validators.required]],
          Init: [
            {
              value: this.polsourcegroupinglanguage.Init,
              disabled: false
            }, [Validators.required, Validators.maxLength(50)]],
          TranslationStatusInit: [
            {
              value: this.polsourcegroupinglanguage.TranslationStatusInit,
              disabled: false
            }, [Validators.required]],
          Description: [
            {
              value: this.polsourcegroupinglanguage.Description,
              disabled: false
            }, [Validators.required, Validators.maxLength(500)]],
          TranslationStatusDescription: [
            {
              value: this.polsourcegroupinglanguage.TranslationStatusDescription,
              disabled: false
            }, [Validators.required]],
          Report: [
            {
              value: this.polsourcegroupinglanguage.Report,
              disabled: false
            }, [Validators.required, Validators.maxLength(500)]],
          TranslationStatusReport: [
            {
              value: this.polsourcegroupinglanguage.TranslationStatusReport,
              disabled: false
            }, [Validators.required]],
          Text: [
            {
              value: this.polsourcegroupinglanguage.Text,
              disabled: false
            }, [Validators.required, Validators.maxLength(500)]],
          TranslationStatusText: [
            {
              value: this.polsourcegroupinglanguage.TranslationStatusText,
              disabled: false
            }, [Validators.required]],
          LastUpdateDate_UTC: [
            {
              value: this.polsourcegroupinglanguage.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.polsourcegroupinglanguage.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.polsourcegroupinglanguageFormEdit = formGroup
    }
  }
}
