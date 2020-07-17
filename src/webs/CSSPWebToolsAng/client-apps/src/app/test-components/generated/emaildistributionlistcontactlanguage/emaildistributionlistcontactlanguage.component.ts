/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { EmailDistributionListContactLanguageService } from './emaildistributionlistcontactlanguage.service';
import { LoadLocalesEmailDistributionListContactLanguageText } from './emaildistributionlistcontactlanguage.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetIDText } from '../../../enums/generated/LanguageEnum';
import { TranslationStatusEnum_GetIDText } from '../../../enums/generated/TranslationStatusEnum';
import { EmailDistributionListContactLanguage } from '../../../models/generated/EmailDistributionListContactLanguage.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-emaildistributionlistcontactlanguage',
  templateUrl: './emaildistributionlistcontactlanguage.component.html',
  styleUrls: ['./emaildistributionlistcontactlanguage.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmailDistributionListContactLanguageComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public emaildistributionlistcontactlanguageService: EmailDistributionListContactLanguageService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(emaildistributionlistcontactlanguage: EmailDistributionListContactLanguage) {
    if (this.IDToShow === emaildistributionlistcontactlanguage.EmailDistributionListContactLanguageID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(emaildistributionlistcontactlanguage: EmailDistributionListContactLanguage) {
    if (this.IDToShow === emaildistributionlistcontactlanguage.EmailDistributionListContactLanguageID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(emaildistributionlistcontactlanguage: EmailDistributionListContactLanguage) {
    if (this.IDToShow === emaildistributionlistcontactlanguage.EmailDistributionListContactLanguageID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = emaildistributionlistcontactlanguage.EmailDistributionListContactLanguageID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(emaildistributionlistcontactlanguage: EmailDistributionListContactLanguage) {
    if (this.IDToShow === emaildistributionlistcontactlanguage.EmailDistributionListContactLanguageID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = emaildistributionlistcontactlanguage.EmailDistributionListContactLanguageID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetEmailDistributionListContactLanguageList() {
    this.sub = this.emaildistributionlistcontactlanguageService.GetEmailDistributionListContactLanguageList().subscribe();
  }

  DeleteEmailDistributionListContactLanguage(emaildistributionlistcontactlanguage: EmailDistributionListContactLanguage) {
    this.sub = this.emaildistributionlistcontactlanguageService.DeleteEmailDistributionListContactLanguage(emaildistributionlistcontactlanguage).subscribe();
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  GetTranslationStatusEnumText(enumID: number) {
    return TranslationStatusEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesEmailDistributionListContactLanguageText(this.emaildistributionlistcontactlanguageService.emaildistributionlistcontactlanguageTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
