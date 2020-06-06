/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { MWQMSiteService } from './mwqmsite.service';
import { LoadLocalesMWQMSiteText } from './mwqmsite.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { MWQMSiteLatestClassificationEnum_GetIDText } from 'src/app/enums/generated/MWQMSiteLatestClassificationEnum';

@Component({
  selector: 'app-mwqmsite',
  templateUrl: './mwqmsite.component.html',
  styleUrls: ['./mwqmsite.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSiteComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public mwqmsiteService: MWQMSiteService, public router: Router) { }

  GetMWQMSite() {
    this.sub = this.mwqmsiteService.GetMWQMSite(this.router).subscribe();
  }

  GetMWQMSiteLatestClassificationEnumText(enumID: number) {
    return MWQMSiteLatestClassificationEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesMWQMSiteText(this.mwqmsiteService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}
