/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { AppTaskLanguageService } from './apptasklanguage.service';
import { LoadLocalesAppTaskLanguageText } from './apptasklanguage.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetOrderedText } from '../../../enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetOrderedText } from '../../../enums/generated/TranslationStatusEnum';
import { AppTaskLanguage } from '../../../models/generated/AppTaskLanguage.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-apptasklanguage-edit',
  templateUrl: './apptasklanguage-edit.component.html',
  styleUrls: ['./apptasklanguage-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppTaskLanguageEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  languageList: EnumIDAndText[];
  translationStatusList: EnumIDAndText[];
  apptasklanguageFormEdit: FormGroup;
  @Input() apptasklanguage: AppTaskLanguage = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public apptasklanguageService: AppTaskLanguageService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutAppTaskLanguage(apptasklanguage: AppTaskLanguage) {
    this.sub = this.apptasklanguageService.PutAppTaskLanguage(apptasklanguage).subscribe();
  }

  PostAppTaskLanguage(apptasklanguage: AppTaskLanguage) {
    this.sub = this.apptasklanguageService.PostAppTaskLanguage(apptasklanguage).subscribe();
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
    if (this.apptasklanguage) {
      let formGroup: FormGroup = this.fb.group(
        {
          AppTaskLanguageID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.apptasklanguage.AppTaskLanguageID)),
              disabled: false
            }, [Validators.required]],
          AppTaskID: [
            {
              value: this.apptasklanguage.AppTaskID,
              disabled: false
            }, [Validators.required]],
          Language: [
            {
              value: this.apptasklanguage.Language,
              disabled: false
            }, [Validators.required]],
          StatusText: [
            {
              value: this.apptasklanguage.StatusText,
              disabled: false
            }, [Validators.maxLength(250)]],
          ErrorText: [
            {
              value: this.apptasklanguage.ErrorText,
              disabled: false
            }, [Validators.maxLength(250)]],
          TranslationStatus: [
            {
              value: this.apptasklanguage.TranslationStatus,
              disabled: false
            }, [Validators.required]],
          LastUpdateDate_UTC: [
            {
              value: this.apptasklanguage.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.apptasklanguage.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.apptasklanguageFormEdit = formGroup
    }
  }
}
