/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { EmailDistributionListLanguageService } from './emaildistributionlistlanguage.service';
import { LoadLocalesEmailDistributionListLanguageText } from './emaildistributionlistlanguage.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetOrderedText } from '../../../enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetOrderedText } from '../../../enums/generated/TranslationStatusEnum';
import { EmailDistributionListLanguage } from '../../../models/generated/EmailDistributionListLanguage.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-emaildistributionlistlanguage-edit',
  templateUrl: './emaildistributionlistlanguage-edit.component.html',
  styleUrls: ['./emaildistributionlistlanguage-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmailDistributionListLanguageEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  languageList: EnumIDAndText[];
  translationStatusList: EnumIDAndText[];
  emaildistributionlistlanguageFormEdit: FormGroup;
  @Input() emaildistributionlistlanguage: EmailDistributionListLanguage = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public emaildistributionlistlanguageService: EmailDistributionListLanguageService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutEmailDistributionListLanguage(emaildistributionlistlanguage: EmailDistributionListLanguage) {
    this.sub = this.emaildistributionlistlanguageService.PutEmailDistributionListLanguage(emaildistributionlistlanguage).subscribe();
  }

  PostEmailDistributionListLanguage(emaildistributionlistlanguage: EmailDistributionListLanguage) {
    this.sub = this.emaildistributionlistlanguageService.PostEmailDistributionListLanguage(emaildistributionlistlanguage).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesEmailDistributionListLanguageText(this.emaildistributionlistlanguageService);
    this.languageList = LanguageEnum_GetOrderedText();
    this.translationStatusList = TranslationStatusEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.emaildistributionlistlanguage) {
      let formGroup: FormGroup = this.fb.group(
        {
          EmailDistributionListLanguageID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.emaildistributionlistlanguage.EmailDistributionListLanguageID)),
              disabled: false
            }, [Validators.required]],
          EmailDistributionListID: [
            {
              value: this.emaildistributionlistlanguage.EmailDistributionListID,
              disabled: false
            }, [Validators.required]],
          Language: [
            {
              value: this.emaildistributionlistlanguage.Language,
              disabled: false
            }, [Validators.required]],
          EmailListName: [
            {
              value: this.emaildistributionlistlanguage.EmailListName,
              disabled: false
            }, [Validators.required, Validators.minLength(1), Validators.maxLength(100)]],
          TranslationStatus: [
            {
              value: this.emaildistributionlistlanguage.TranslationStatus,
              disabled: false
            }, [Validators.required]],
          LastUpdateDate_UTC: [
            {
              value: this.emaildistributionlistlanguage.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.emaildistributionlistlanguage.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.emaildistributionlistlanguageFormEdit = formGroup
    }
  }
}
