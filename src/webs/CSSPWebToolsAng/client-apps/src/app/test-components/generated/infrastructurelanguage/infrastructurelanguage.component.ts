/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { InfrastructureLanguageService } from './infrastructurelanguage.service';
import { LoadLocalesInfrastructureLanguageText } from './infrastructurelanguage.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetIDText } from '../../../enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetIDText } from '../../../enums/generated/TranslationStatusEnum';
import { InfrastructureLanguage } from '../../../models/generated/InfrastructureLanguage.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-infrastructurelanguage',
  templateUrl: './infrastructurelanguage.component.html',
  styleUrls: ['./infrastructurelanguage.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class InfrastructureLanguageComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public infrastructurelanguageService: InfrastructureLanguageService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(infrastructurelanguage: InfrastructureLanguage) {
    if (this.IDToShow === infrastructurelanguage.InfrastructureLanguageID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(infrastructurelanguage: InfrastructureLanguage) {
    if (this.IDToShow === infrastructurelanguage.InfrastructureLanguageID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(infrastructurelanguage: InfrastructureLanguage) {
    if (this.IDToShow === infrastructurelanguage.InfrastructureLanguageID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = infrastructurelanguage.InfrastructureLanguageID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(infrastructurelanguage: InfrastructureLanguage) {
    if (this.IDToShow === infrastructurelanguage.InfrastructureLanguageID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = infrastructurelanguage.InfrastructureLanguageID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetInfrastructureLanguageList() {
    this.sub = this.infrastructurelanguageService.GetInfrastructureLanguageList().subscribe();
  }

  DeleteInfrastructureLanguage(infrastructurelanguage: InfrastructureLanguage) {
    this.sub = this.infrastructurelanguageService.DeleteInfrastructureLanguage(infrastructurelanguage).subscribe();
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  GetTranslationStatusEnumText(enumID: number) {
    return TranslationStatusEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesInfrastructureLanguageText(this.infrastructurelanguageService.infrastructurelanguageTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
