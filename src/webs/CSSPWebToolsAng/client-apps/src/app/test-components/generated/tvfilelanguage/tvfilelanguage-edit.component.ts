/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { TVFileLanguageService } from './tvfilelanguage.service';
import { LoadLocalesTVFileLanguageText } from './tvfilelanguage.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetOrderedText } from '../../../enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetOrderedText } from '../../../enums/generated/TranslationStatusEnum';
import { TVFileLanguage } from '../../../models/generated/TVFileLanguage.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-tvfilelanguage-edit',
  templateUrl: './tvfilelanguage-edit.component.html',
  styleUrls: ['./tvfilelanguage-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVFileLanguageEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  languageList: EnumIDAndText[];
  translationStatusList: EnumIDAndText[];
  tvfilelanguageFormEdit: FormGroup;
  @Input() tvfilelanguage: TVFileLanguage = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public tvfilelanguageService: TVFileLanguageService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutTVFileLanguage(tvfilelanguage: TVFileLanguage) {
    this.sub = this.tvfilelanguageService.PutTVFileLanguage(tvfilelanguage).subscribe();
  }

  PostTVFileLanguage(tvfilelanguage: TVFileLanguage) {
    this.sub = this.tvfilelanguageService.PostTVFileLanguage(tvfilelanguage).subscribe();
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
    if (this.tvfilelanguage) {
      let formGroup: FormGroup = this.fb.group(
        {
          TVFileLanguageID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.tvfilelanguage.TVFileLanguageID)),
              disabled: false
            }, [Validators.required]],
          TVFileID: [
            {
              value: this.tvfilelanguage.TVFileID,
              disabled: false
            }, [Validators.required]],
          Language: [
            {
              value: this.tvfilelanguage.Language,
              disabled: false
            }, [Validators.required]],
          FileDescription: [
            {
              value: this.tvfilelanguage.FileDescription,
              disabled: false
            }],
          TranslationStatus: [
            {
              value: this.tvfilelanguage.TranslationStatus,
              disabled: false
            }, [Validators.required]],
          LastUpdateDate_UTC: [
            {
              value: this.tvfilelanguage.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.tvfilelanguage.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.tvfilelanguageFormEdit = formGroup
    }
  }
}
