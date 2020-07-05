/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { BoxModelLanguageService } from './boxmodellanguage.service';
import { LoadLocalesBoxModelLanguageText } from './boxmodellanguage.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetIDText } from '../../../enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetIDText } from '../../../enums/generated/TranslationStatusEnum';
import { BoxModelLanguage } from '../../../models/generated/BoxModelLanguage.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-boxmodellanguage',
  templateUrl: './boxmodellanguage.component.html',
  styleUrls: ['./boxmodellanguage.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BoxModelLanguageComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public boxmodellanguageService: BoxModelLanguageService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(boxmodellanguage: BoxModelLanguage) {
    if (this.IDToShow === boxmodellanguage.BoxModelLanguageID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(boxmodellanguage: BoxModelLanguage) {
    if (this.IDToShow === boxmodellanguage.BoxModelLanguageID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(boxmodellanguage: BoxModelLanguage) {
    if (this.IDToShow === boxmodellanguage.BoxModelLanguageID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = boxmodellanguage.BoxModelLanguageID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(boxmodellanguage: BoxModelLanguage) {
    if (this.IDToShow === boxmodellanguage.BoxModelLanguageID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = boxmodellanguage.BoxModelLanguageID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetBoxModelLanguageList() {
    this.sub = this.boxmodellanguageService.GetBoxModelLanguageList().subscribe();
  }

  DeleteBoxModelLanguage(boxmodellanguage: BoxModelLanguage) {
    this.sub = this.boxmodellanguageService.DeleteBoxModelLanguage(boxmodellanguage).subscribe();
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  GetTranslationStatusEnumText(enumID: number) {
    return TranslationStatusEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesBoxModelLanguageText(this.boxmodellanguageService.boxmodellanguageTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
