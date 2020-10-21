/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { TVFileLanguageService } from './tvfilelanguage.service';
import { LoadLocalesTVFileLanguageText } from './tvfilelanguage.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetIDText } from '../../../enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetIDText } from '../../../enums/generated/TranslationStatusEnum';
import { TVFileLanguage } from '../../../models/generated/TVFileLanguage.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-tvfilelanguage',
  templateUrl: './tvfilelanguage.component.html',
  styleUrls: ['./tvfilelanguage.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVFileLanguageComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public tvfilelanguageService: TVFileLanguageService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(tvfilelanguage: TVFileLanguage) {
    if (this.IDToShow === tvfilelanguage.TVFileLanguageID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(tvfilelanguage: TVFileLanguage) {
    if (this.IDToShow === tvfilelanguage.TVFileLanguageID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(tvfilelanguage: TVFileLanguage) {
    if (this.IDToShow === tvfilelanguage.TVFileLanguageID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = tvfilelanguage.TVFileLanguageID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(tvfilelanguage: TVFileLanguage) {
    if (this.IDToShow === tvfilelanguage.TVFileLanguageID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = tvfilelanguage.TVFileLanguageID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetTVFileLanguageList() {
    this.sub = this.tvfilelanguageService.GetTVFileLanguageList().subscribe();
  }

  DeleteTVFileLanguage(tvfilelanguage: TVFileLanguage) {
    this.sub = this.tvfilelanguageService.DeleteTVFileLanguage(tvfilelanguage).subscribe();
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  GetTranslationStatusEnumText(enumID: number) {
    return TranslationStatusEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesTVFileLanguageText(this.tvfilelanguageService.tvfilelanguageTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
