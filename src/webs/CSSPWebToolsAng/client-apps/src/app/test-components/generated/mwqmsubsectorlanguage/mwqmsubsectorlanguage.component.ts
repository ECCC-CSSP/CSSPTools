/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { MWQMSubsectorLanguageService } from './mwqmsubsectorlanguage.service';
import { LoadLocalesMWQMSubsectorLanguageText } from './mwqmsubsectorlanguage.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetIDText } from '../../../enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetIDText } from '../../../enums/generated/TranslationStatusEnum';
import { MWQMSubsectorLanguage } from '../../../models/generated/MWQMSubsectorLanguage.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mwqmsubsectorlanguage',
  templateUrl: './mwqmsubsectorlanguage.component.html',
  styleUrls: ['./mwqmsubsectorlanguage.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSubsectorLanguageComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public mwqmsubsectorlanguageService: MWQMSubsectorLanguageService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(mwqmsubsectorlanguage: MWQMSubsectorLanguage) {
    if (this.IDToShow === mwqmsubsectorlanguage.MWQMSubsectorLanguageID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(mwqmsubsectorlanguage: MWQMSubsectorLanguage) {
    if (this.IDToShow === mwqmsubsectorlanguage.MWQMSubsectorLanguageID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(mwqmsubsectorlanguage: MWQMSubsectorLanguage) {
    if (this.IDToShow === mwqmsubsectorlanguage.MWQMSubsectorLanguageID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = mwqmsubsectorlanguage.MWQMSubsectorLanguageID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(mwqmsubsectorlanguage: MWQMSubsectorLanguage) {
    if (this.IDToShow === mwqmsubsectorlanguage.MWQMSubsectorLanguageID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = mwqmsubsectorlanguage.MWQMSubsectorLanguageID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetMWQMSubsectorLanguageList() {
    this.sub = this.mwqmsubsectorlanguageService.GetMWQMSubsectorLanguageList().subscribe();
  }

  DeleteMWQMSubsectorLanguage(mwqmsubsectorlanguage: MWQMSubsectorLanguage) {
    this.sub = this.mwqmsubsectorlanguageService.DeleteMWQMSubsectorLanguage(mwqmsubsectorlanguage).subscribe();
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  GetTranslationStatusEnumText(enumID: number) {
    return TranslationStatusEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesMWQMSubsectorLanguageText(this.mwqmsubsectorlanguageService.mwqmsubsectorlanguageTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
