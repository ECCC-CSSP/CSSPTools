/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { InfrastructureLanguageService } from './infrastructurelanguage.service';
import { LoadLocalesInfrastructureLanguageText } from './infrastructurelanguage.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetIDText } from 'src/app/enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetIDText } from 'src/app/enums/generated/TranslationStatusEnum';

@Component({
  selector: 'app-infrastructurelanguage',
  templateUrl: './infrastructurelanguage.component.html',
  styleUrls: ['./infrastructurelanguage.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class InfrastructureLanguageComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public infrastructurelanguageService: InfrastructureLanguageService, public router: Router) { }

  GetInfrastructureLanguage() {
    this.sub = this.infrastructurelanguageService.GetInfrastructureLanguage(this.router).subscribe();
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  GetTranslationStatusEnumText(enumID: number) {
    return TranslationStatusEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesInfrastructureLanguageText(this.infrastructurelanguageService);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
