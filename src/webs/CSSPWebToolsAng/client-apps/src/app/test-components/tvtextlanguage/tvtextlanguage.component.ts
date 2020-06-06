/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { TVTextLanguageService } from './tvtextlanguage.service';
import { LoadLocalesTVTextLanguageText } from './tvtextlanguage.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetIDText } from 'src/app/enums/generated/LanguageEnum';

@Component({
  selector: 'app-tvtextlanguage',
  templateUrl: './tvtextlanguage.component.html',
  styleUrls: ['./tvtextlanguage.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVTextLanguageComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public tvtextlanguageService: TVTextLanguageService, public router: Router) { }

  GetTVTextLanguage() {
    this.sub = this.tvtextlanguageService.GetTVTextLanguage(this.router).subscribe();
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesTVTextLanguageText(this.tvtextlanguageService);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
