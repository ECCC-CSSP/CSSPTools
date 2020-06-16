/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { MWQMSubsectorLanguageService } from './mwqmsubsectorlanguage.service';
import { LoadLocalesMWQMSubsectorLanguageText } from './mwqmsubsectorlanguage.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetIDText, LanguageEnum_GetOrderedText } from '../../../enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetIDText, TranslationStatusEnum_GetOrderedText } from '../../../enums/generated/TranslationStatusEnum';
import { MWQMSubsectorLanguage } from '../../../models/generated/MWQMSubsectorLanguage.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';

@Component({
  selector: 'app-mwqmsubsectorlanguage',
  templateUrl: './mwqmsubsectorlanguage.component.html',
  styleUrls: ['./mwqmsubsectorlanguage.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSubsectorLanguageComponent implements OnInit, OnDestroy {
  sub: Subscription;
  languageList: EnumIDAndText[];
  translationStatusSubsectorDescList: EnumIDAndText[];
  translationStatusLogBookList: EnumIDAndText[];
  mwqmsubsectorlanguageFormPut: FormGroup;
  mwqmsubsectorlanguageFormPost: FormGroup;

  constructor(public mwqmsubsectorlanguageService: MWQMSubsectorLanguageService, public router: Router, public fb: FormBuilder) { }

  GetMWQMSubsectorLanguageList() {
    this.sub = this.mwqmsubsectorlanguageService.GetMWQMSubsectorLanguageList(this.router).subscribe();
  }

  PutMWQMSubsectorLanguage(mwqmsubsectorlanguage: MWQMSubsectorLanguage) {
    this.sub = this.mwqmsubsectorlanguageService.PutMWQMSubsectorLanguage(mwqmsubsectorlanguage, this.router).subscribe();
  }

  PostMWQMSubsectorLanguage(mwqmsubsectorlanguage: MWQMSubsectorLanguage) {
    this.sub = this.mwqmsubsectorlanguageService.PostMWQMSubsectorLanguage(mwqmsubsectorlanguage, this.router).subscribe();
  }

  DeleteMWQMSubsectorLanguage(mwqmsubsectorlanguage: MWQMSubsectorLanguage) {
    this.sub = this.mwqmsubsectorlanguageService.DeleteMWQMSubsectorLanguage(mwqmsubsectorlanguage, this.router).subscribe();
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  GetTranslationStatusEnumText(enumID: number) {
    return TranslationStatusEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesMWQMSubsectorLanguageText(this.mwqmsubsectorlanguageService);
    this.languageList = LanguageEnum_GetOrderedText();
    this.translationStatusSubsectorDescList = TranslationStatusEnum_GetOrderedText();
    this.translationStatusLogBookList = TranslationStatusEnum_GetOrderedText();
    this.FillFormBuilderGroup('Add');
    this.FillFormBuilderGroup('Update');
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(AddOrUpdate: string) {
    if (this.mwqmsubsectorlanguageService.mwqmsubsectorlanguageList.length) {
      let formGroup: FormGroup = this.fb.group(
        {
          MWQMSubsectorLanguageID: [
            {
              value: (AddOrUpdate === 'Add' ? 0 : (this.mwqmsubsectorlanguageService.mwqmsubsectorlanguageList[0]?.MWQMSubsectorLanguageID)),
              disabled: false
            }, [ Validators.required ]],
          MWQMSubsectorID: [
            {
              value: this.mwqmsubsectorlanguageService.mwqmsubsectorlanguageList[0]?.MWQMSubsectorID,
              disabled: false
            }, [ Validators.required ]],
          Language: [
            {
              value: this.mwqmsubsectorlanguageService.mwqmsubsectorlanguageList[0]?.Language,
              disabled: false
            }, [ Validators.required ]],
          SubsectorDesc: [
            {
              value: this.mwqmsubsectorlanguageService.mwqmsubsectorlanguageList[0]?.SubsectorDesc,
              disabled: false
            }, [ Validators.required ]],
          TranslationStatusSubsectorDesc: [
            {
              value: this.mwqmsubsectorlanguageService.mwqmsubsectorlanguageList[0]?.TranslationStatusSubsectorDesc,
              disabled: false
            }, [ Validators.required ]],
          LogBook: [
            {
              value: this.mwqmsubsectorlanguageService.mwqmsubsectorlanguageList[0]?.LogBook,
              disabled: false
            }, [ Validators.required ]],
          TranslationStatusLogBook: [
            {
              value: this.mwqmsubsectorlanguageService.mwqmsubsectorlanguageList[0]?.TranslationStatusLogBook,
              disabled: false
            }, [ Validators.required ]],
          LastUpdateDate_UTC: [
            {
              value: this.mwqmsubsectorlanguageService.mwqmsubsectorlanguageList[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [ Validators.required ]],
          LastUpdateContactTVItemID: [
            {
              value: this.mwqmsubsectorlanguageService.mwqmsubsectorlanguageList[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [ Validators.required ]],
        }
      );

      if (AddOrUpdate === 'Add') {
        this.mwqmsubsectorlanguageFormPost = formGroup
      }
      else {
        this.mwqmsubsectorlanguageFormPut = formGroup;
      }
    }
  }
}
