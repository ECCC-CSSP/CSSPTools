/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { MWQMSampleLanguageService } from './mwqmsamplelanguage.service';
import { LoadLocalesMWQMSampleLanguageText } from './mwqmsamplelanguage.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetIDText } from 'src/app/enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetIDText } from 'src/app/enums/generated/TranslationStatusEnum';

@Component({
  selector: 'app-mwqmsamplelanguage',
  templateUrl: './mwqmsamplelanguage.component.html',
  styleUrls: ['./mwqmsamplelanguage.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSampleLanguageComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public mwqmsamplelanguageService: MWQMSampleLanguageService, public router: Router) { }

  GetMWQMSampleLanguage() {
    this.sub = this.mwqmsamplelanguageService.GetMWQMSampleLanguage(this.router).subscribe();
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  GetTranslationStatusEnumText(enumID: number) {
    return TranslationStatusEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesMWQMSampleLanguageText(this.mwqmsamplelanguageService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}
