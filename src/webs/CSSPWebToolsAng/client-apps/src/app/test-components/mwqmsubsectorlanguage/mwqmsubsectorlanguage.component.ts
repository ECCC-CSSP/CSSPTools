/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { MWQMSubsectorLanguageService } from './mwqmsubsectorlanguage.service';
import { LoadLocalesMWQMSubsectorLanguageText } from './mwqmsubsectorlanguage.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetIDText } from 'src/app/enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetIDText } from 'src/app/enums/generated/TranslationStatusEnum';

@Component({
  selector: 'app-mwqmsubsectorlanguage',
  templateUrl: './mwqmsubsectorlanguage.component.html',
  styleUrls: ['./mwqmsubsectorlanguage.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSubsectorLanguageComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public mwqmsubsectorlanguageService: MWQMSubsectorLanguageService, public router: Router) { }

  GetMWQMSubsectorLanguage() {
    this.sub = this.mwqmsubsectorlanguageService.GetMWQMSubsectorLanguage(this.router).subscribe();
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  GetTranslationStatusEnumText(enumID: number) {
    return TranslationStatusEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesMWQMSubsectorLanguageText(this.mwqmsubsectorlanguageService);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
