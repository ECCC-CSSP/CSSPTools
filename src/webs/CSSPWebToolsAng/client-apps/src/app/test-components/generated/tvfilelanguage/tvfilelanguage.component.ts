/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { TVFileLanguageService } from './tvfilelanguage.service';
import { LoadLocalesTVFileLanguageText } from './tvfilelanguage.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetIDText } from 'src/app/enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetIDText } from 'src/app/enums/generated/TranslationStatusEnum';

@Component({
  selector: 'app-tvfilelanguage',
  templateUrl: './tvfilelanguage.component.html',
  styleUrls: ['./tvfilelanguage.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVFileLanguageComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public tvfilelanguageService: TVFileLanguageService, public router: Router) { }

  GetTVFileLanguage() {
    this.sub = this.tvfilelanguageService.GetTVFileLanguage(this.router).subscribe();
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  GetTranslationStatusEnumText(enumID: number) {
    return TranslationStatusEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesTVFileLanguageText(this.tvfilelanguageService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}
