/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { EmailDistributionListContactLanguageService } from './emaildistributionlistcontactlanguage.service';
import { LoadLocalesEmailDistributionListContactLanguageText } from './emaildistributionlistcontactlanguage.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetIDText } from 'src/app/enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetIDText } from 'src/app/enums/generated/TranslationStatusEnum';

@Component({
  selector: 'app-emaildistributionlistcontactlanguage',
  templateUrl: './emaildistributionlistcontactlanguage.component.html',
  styleUrls: ['./emaildistributionlistcontactlanguage.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmailDistributionListContactLanguageComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public emaildistributionlistcontactlanguageService: EmailDistributionListContactLanguageService, public router: Router) { }

  GetEmailDistributionListContactLanguage() {
    this.sub = this.emaildistributionlistcontactlanguageService.GetEmailDistributionListContactLanguage(this.router).subscribe();
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  GetTranslationStatusEnumText(enumID: number) {
    return TranslationStatusEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesEmailDistributionListContactLanguageText(this.emaildistributionlistcontactlanguageService);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
