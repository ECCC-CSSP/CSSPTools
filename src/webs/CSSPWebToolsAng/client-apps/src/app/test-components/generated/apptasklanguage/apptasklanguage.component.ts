/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { AppTaskLanguageService } from './apptasklanguage.service';
import { LoadLocalesAppTaskLanguageText } from './apptasklanguage.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetIDText } from '../../../enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetIDText } from '../../../enums/generated/TranslationStatusEnum';
import { AppTaskLanguage } from '../../../models/generated/AppTaskLanguage.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-apptasklanguage',
  templateUrl: './apptasklanguage.component.html',
  styleUrls: ['./apptasklanguage.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppTaskLanguageComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public apptasklanguageService: AppTaskLanguageService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(apptasklanguage: AppTaskLanguage) {
    if (this.IDToShow === apptasklanguage.AppTaskLanguageID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(apptasklanguage: AppTaskLanguage) {
    if (this.IDToShow === apptasklanguage.AppTaskLanguageID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(apptasklanguage: AppTaskLanguage) {
    if (this.IDToShow === apptasklanguage.AppTaskLanguageID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = apptasklanguage.AppTaskLanguageID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(apptasklanguage: AppTaskLanguage) {
    if (this.IDToShow === apptasklanguage.AppTaskLanguageID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = apptasklanguage.AppTaskLanguageID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetAppTaskLanguageList() {
    this.sub = this.apptasklanguageService.GetAppTaskLanguageList().subscribe();
  }

  DeleteAppTaskLanguage(apptasklanguage: AppTaskLanguage) {
    this.sub = this.apptasklanguageService.DeleteAppTaskLanguage(apptasklanguage).subscribe();
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  GetTranslationStatusEnumText(enumID: number) {
    return TranslationStatusEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesAppTaskLanguageText(this.apptasklanguageService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }
}
