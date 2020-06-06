/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { PolSourceGroupingLanguageService } from './polsourcegroupinglanguage.service';
import { LoadLocalesPolSourceGroupingLanguageText } from './polsourcegroupinglanguage.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetIDText } from 'src/app/enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetIDText } from 'src/app/enums/generated/TranslationStatusEnum';

@Component({
  selector: 'app-polsourcegroupinglanguage',
  templateUrl: './polsourcegroupinglanguage.component.html',
  styleUrls: ['./polsourcegroupinglanguage.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PolSourceGroupingLanguageComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public polsourcegroupinglanguageService: PolSourceGroupingLanguageService, public router: Router) { }

  GetPolSourceGroupingLanguage() {
    this.sub = this.polsourcegroupinglanguageService.GetPolSourceGroupingLanguage(this.router).subscribe();
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  GetTranslationStatusEnumText(enumID: number) {
    return TranslationStatusEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesPolSourceGroupingLanguageText(this.polsourcegroupinglanguageService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}
